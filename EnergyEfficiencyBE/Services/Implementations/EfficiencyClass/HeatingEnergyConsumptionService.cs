using EnergyEfficiencyBE.Models.EfficiencyClass;
using EnergyEfficiencyBE.Repositories.Interfaces.EfficiencyClass;
using EnergyEfficiencyBE.Services.Interfaces.EfficiencyClass;
using static EnergyEfficiencyBE.Constants;

namespace EnergyEfficiencyBE.Services.Implementations.EfficiencyClass
{
    public class HeatingEnergyConsumptionService : IHeatingEnergyConsumptionService
    {
        private ILinearHeatTransferFactorRepository _linearHeatTransferFactorRepository;
        private IHidraulicAdjustmentFactorRepository _hidraulicAdjustmentFactorRepository;
        private IHeatingSystemEfficiencyComponentsRepository _heatingSystemEfficiencyComponentsRepository;
        private ISeasonalHeatGenerationEfficiencyFactorRepository _seasonalHeatGenerationEfficiencyFactorRepository;

        private HeatingEnergyConsumptionModel _data;


        public HeatingEnergyConsumptionService(
            ILinearHeatTransferFactorRepository linearHeatTransferFactorRepository,
            IHidraulicAdjustmentFactorRepository hidraulicAdjustmentFactorRepository,
            IHeatingSystemEfficiencyComponentsRepository heatingSystemEfficiencyComponentsRepository,
            ISeasonalHeatGenerationEfficiencyFactorRepository seasonalHeatGenerationEfficiencyFactorRepository
        )
        {
            _linearHeatTransferFactorRepository = linearHeatTransferFactorRepository;
            _hidraulicAdjustmentFactorRepository = hidraulicAdjustmentFactorRepository;
            _heatingSystemEfficiencyComponentsRepository = heatingSystemEfficiencyComponentsRepository;
            _seasonalHeatGenerationEfficiencyFactorRepository = seasonalHeatGenerationEfficiencyFactorRepository;
        }

        public decimal GetHeatingEnergyConsumption(HeatingEnergyConsumptionModel data)
        {
            _data = data;
            return _getYearlyHeatingEnergyConsumption() / data.HeatedAreaOrVolume;
        }

        protected decimal _getYearlyHeatingEnergyConsumption() => _getYearlyWarmthSystemExitEnergy() + _getYearlyWarmthSystemHeatLoss();

        protected decimal _getYearlyWarmthSystemExitEnergy() => _getYearlyUnutilizedDistributionHeatLoss() + _getYearlyDistributionSystemExitEnergy();

        protected decimal _getYearlyUnutilizedDistributionHeatLoss() => _getUtilisationalHeatLoss() + (_getUtilisationalHeatLoss() - _getUtilisedHeatLoss());

        protected float? _getLinearHeatTransferFactor()
        {
            var factorSum = 0f;

            switch (_data.PipelineType)
            {
                case PipelineTypes.InsulatedOpen:
                    var factors = _linearHeatTransferFactorRepository
                        .FindByConditionAsync(
                        val => val.PipelineType == _data.PipelineType &&
                        val.InsulatedDate == _data.InsulatedDate
                        && _data.PipelineSections.Contains(val.PipelineSection)).Result?.Select(val => val.FactorValue)
                        .ToArray();

                    if (factors == null)
                    {
                        return null;
                    }

                    foreach (var f in factors)
                    {
                        factorSum += f;
                    }

                    return factorSum;
                case PipelineTypes.UnIinsulated:
                    var buildingSize = BuildingAreaConstraints.AreaLessThan200;
                    if (_data.HeatedAreaOrVolume < 200 && _data.HeatedAreaOrVolume <= 500)
                    {
                        buildingSize = BuildingAreaConstraints.AreaFro200To500;
                    }
                    else if (_data.HeatedAreaOrVolume > 500)
                    {
                        buildingSize = BuildingAreaConstraints.AreaFrom500;
                    }

                    var factorsData = _linearHeatTransferFactorRepository
                        .FindByConditionAsync(
                        val => val.PipelineType == _data.PipelineType &&
                        val.BuildingSize == buildingSize &&
                        _data.PipelineSections.Contains(val.PipelineSection)).Result?.Select(val => val.FactorValue)
                        .ToArray();

                    if (factorsData == null)
                    {
                        return null;
                    }

                    foreach (var f in factorsData)
                    {
                        factorSum += f;
                    }

                    return factorSum;
                case PipelineTypes.OuterWalls:
                    return _linearHeatTransferFactorRepository
                        .FindOneByCondition(
                        val => val.PipelineType == _data.PipelineType &&
                        val.OuterWallsPipeline == _data.OuterWallsPipeline)?.FactorValue;
                default:
                    return null;
            }
        }

        protected decimal _getUtilisationalHeatLoss()
        {
            var factor = _getLinearHeatTransferFactor();

            if (factor == null)
            {
                throw new Exception($"No linear heat transfer factor for pipeline type; {_data.PipelineType}");
            }

            var result = 1m;

            for (int month = 0; month < 11; month++)
            {
                result += (decimal)factor * (decimal)(_data.AvgYearlyHeatCarrierTemp[month] - _data.AvgYearlyEnvironmentTemp[month]) * (decimal)_data.PipelineLength * (decimal)_data.AvgYearlyHeatingHours[month];
            }

            return result;
        }

        protected decimal _getUtilisedHeatLoss() { return _getUtilisationalHeatLoss() * 0.9m * _data.HeatingUsageFactor; }

        protected decimal _getYearlyDistributionSystemExitEnergy() { return _data.YearlyHeatingSubsystemExitEnergy + (1m - 0.8m * _data.HeatingUsageFactor) * _getYearlyUtlisableHeatingSubsystemHeatLoss(); }

        protected decimal _getYearlyUtlisableHeatingSubsystemHeatLoss()
        {
            var hidraulicFactor = _hidraulicAdjustmentFactorRepository.FindOneByCondition(val => val.SystemType == _data.HidraulicSystemType && val.SystemDescription == _data.HidraulicSystemDescription)
                ?.FactorValue;

            if (hidraulicFactor == null)
            {
                throw new Exception($"No hidraulic adjustment factor for system {_data.HidraulicSystemType} with description {_data.HidraulicSystemDescription}");
            }

            return ((decimal)hidraulicFactor * PeriodicHeatingModeFactor[_data.PeriodicHeatingType] * (_data.IsRadiantHeatingSystem ? RadiantHeatingSystemTypeFactor : 1m)
                / _getHeatingSystemComponentEfficiency() - 1) * _data.YearlyHeatingSubsystemExitEnergy;
        }

        protected decimal _getHeatingSystemComponentEfficiency()
        {
            var components = _heatingSystemEfficiencyComponentsRepository
                .FindOneByCondition(val => val.TemperatureComponentType == _data.TemperatureComponentType
                && val.RegulationOptions == _data.RegulationOptions
                && val.TemperaturDifference == _data.TemperaturDifference
                && val.HeatLoss == _data.HeatLoss);

            if (components == null)
            {
                throw new Exception($"There are no heating system efficiency component factors for {_data.TemperatureComponentType}");
            }

            return 1 / (4 - (components.VerticalTemperatureProfileComponentFactor + components.TemperatureRegulationComponentFactor + components.ExteriorEnclosureHeatLossComponentFactor));
        }

        protected decimal _getYearlyWarmthSystemHeatLoss()
        {
            var seasonalEfficiency = _seasonalHeatGenerationEfficiencyFactorRepository
                        .FindByConditionAsync(val => val.HeaterType == _data.SeasonalHeaterType)
                .Result?.FirstOrDefault();
            var factor = 1;

            if (seasonalEfficiency == null)
            {
                throw new Exception($"No seasonal efficiency factor for heater {_data.SeasonalHeaterType} {SeasonalHeatGenerationFactorFieldNames[_data.HeaterFactorFieldName]}");
            }

            switch(_data.HeaterFactorFieldName) {
                case HeaterFactors.Before1994:
                    factor = seasonalEfficiency.Before1994Factor ?? 1; 
                    break;
                case HeaterFactors.From1994To2008:
                    factor = seasonalEfficiency.From1994To2008Factor ?? 1;
                    break;
                case HeaterFactors.After2008:
                    factor = seasonalEfficiency.From2008Factor ?? 1;
                    break;
                default:
                    factor = seasonalEfficiency.AnyDateFactor ?? 1;
                    break;
            }

            return _data.YearlyHeatingSubsystemExitEnergy * (1m - factor) / factor;
        }
    }
}
