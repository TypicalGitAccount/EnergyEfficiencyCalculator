using EnergyEfficiencyBE.Models.EfficiencyClass;
using EnergyEfficiencyBE.Repositories.Interfaces.EfficiencyClass;
using EnergyEfficiencyBE.Services.Interfaces.EfficiencyClass;
using Serilog.Formatting.Json;
using static EnergyEfficiencyBE.Constants;

namespace EnergyEfficiencyBE.Services.Implementations.EfficiencyClass
{
    public class CoolingEnergyConsumptionService : ICoolingEnergyConsumptionService
    {
        private IAverageCoolingSystemFactorsRepository _averageCoolingSystemFactorsRepository;
        private IYearlyCoolingMachinesEfficiencyRepository _yearlyCoolingMachineRepository;

        private CoolingEnergyConsumptionModel _data;

        public CoolingEnergyConsumptionService(
            IYearlyCoolingMachinesEfficiencyRepository yearlyCoolingMachineEfficiencyRepository,
            IAverageCoolingSystemFactorsRepository averageCoolingSystemFactorsRepository
            )
        {
            _averageCoolingSystemFactorsRepository = averageCoolingSystemFactorsRepository;
            _yearlyCoolingMachineRepository = yearlyCoolingMachineEfficiencyRepository;
        }

        public decimal GetCoolingEnergyConsumption(CoolingEnergyConsumptionModel data)
        {
            _data = data;

            return _getYearlyCoolingEnergyConsumption() / _data.ConditionedAreaOrVolume;
        }

        private decimal _getYearlyCoolingEnergyConsumption()
        {
            return _getGeneralGeneratingSubsystemHeatLoss() + _getGeneratingSubsystemExitEnergy();
        }

        private decimal _getGeneralGeneratingSubsystemHeatLoss()
        {
            var factor = _yearlyCoolingMachineRepository.FindOneByCondition(val => val.CoolingMachineType == _data.CoolingMachineType)?.Efficiency;
            if (factor == null)
            {
                throw new Exception($"Не знайдено коефіцієнта для типу холодильної машини: {_data.CoolingMachineType}");
            }

            if (_data.CoolingMachineType == CoolingMachineTypes.Absorbal)
            {
                factor *= _data.heatGenerationEfficiency;
            } else
            {
                factor *= _data.electicityGenerationEfficiency;
            }

            return _getGeneratingSubsystemExitEnergy() * (1 - (decimal)factor) / (decimal)factor;
        }

        private decimal _getGeneratingSubsystemExitEnergy()
        { return _getDistributionSubsystemEnterEnergy() / AutoRegulationEfficiency[_data.RegulationSystemEfficiencyClass]; }

        private decimal _getDistributionSubsystemEnterEnergy()
        {
            return _data.YearlyCoolingEnergy / 1000 + _getYearlyCooledAirDistributionSubsystemHeatLoss();
        }

        private decimal _getYearlyCooledAirDistributionSubsystemHeatLoss()
        {
            var factors = _averageCoolingSystemFactorsRepository.FindOneByCondition(val => val.CoolingSystemType == _data.CoolingSystemType);

            if (factors == null)
            {
                throw new Exception($"No yearly cooled air distribution system heatloss factors for ${_data.CoolingSystemType}");
            }

            return _data.YearlyCoolingEnergy * (1 - (decimal)factors.coolingExplicitUtilisationLevel + (1 - (decimal)factors.distributionSubsystemUtilisationLevel)
                + (1 - (decimal)factors.coolingUtilisationLevel));
        }
    }
}
