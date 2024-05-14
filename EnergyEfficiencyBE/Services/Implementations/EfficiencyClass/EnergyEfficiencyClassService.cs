using AutoMapper;
using EnergyEfficiencyBE.Models.EfficiencyClass;
using EnergyEfficiencyBE.Repositories.Interfaces.EfficiencyClass;
using EnergyEfficiencyBE.Services.Interfaces.EfficiencyClass;
using Microsoft.IdentityModel.Tokens;
using NCalc;

using static EnergyEfficiencyBE.Constants;

namespace EnergyEfficiencyBE.Services.Implementations.EfficiencyClass
{
    public class EnergyEfficiencyClassService : IEnergyEfficiencyClassService
    {
        protected IPeakEnergyConsumptionRepository _peakEnergyConsumptionRepository;
        protected IYearlyCoolingMachinesEfficiencyRepository _yearlyCoolingMachineRepository;
        protected IAverageCoolingSystemFactorsRepository _averageCoolingSystemFactorsRepository;
        protected ILinearHeatTransferFactorRepository _linearHeatTransferFactorRepository;
        protected IHidraulicAdjustmentFactorRepository _hidraulicAdjustmentFactorRepository;
        protected IHeatingSystemEfficiencyComponentsRepository _heatingSystemEfficiencyComponentsRepository;
        protected ISeasonalHeatGenerationEfficiencyFactorRepository _seasonalHeatGenerationEfficiencyFactorRepository;

        protected ICoolingEnergyConsumptionService _coolingEnergyConsumptionService;
        protected IHeatingEnergyConsumptionService _heatingEnergyConsumptionService;
        protected IMapper _mapper;

        protected EnergyEfficiencyInputModel _data { get; set; }

        public EnergyEfficiencyClassService(
            IPeakEnergyConsumptionRepository peakEnergyConsumptionRepository,
            IYearlyCoolingMachinesEfficiencyRepository yearlyCoolingMachineEfficiencyRepository,
            IAverageCoolingSystemFactorsRepository averageCoolingSystemFactorsRepositoriey,
            ILinearHeatTransferFactorRepository linearHeatTransferFactorRepository,
            IHidraulicAdjustmentFactorRepository hidraulicSystemsAdjustmentFactorRepository,
            IHeatingSystemEfficiencyComponentsRepository heatingSystemEfficiencyComponentsRepository,
            ISeasonalHeatGenerationEfficiencyFactorRepository seasonalHeatGenerationEfficiencyFactorRepository,

            IHeatingEnergyConsumptionService heatingEnergyConsumptionService,
            ICoolingEnergyConsumptionService coolingEnergyConsumptionService,
            IMapper mapper
        )
        {
            _peakEnergyConsumptionRepository = peakEnergyConsumptionRepository;
            _yearlyCoolingMachineRepository = yearlyCoolingMachineEfficiencyRepository;
            _averageCoolingSystemFactorsRepository = averageCoolingSystemFactorsRepositoriey;
            _linearHeatTransferFactorRepository = linearHeatTransferFactorRepository;
            _hidraulicAdjustmentFactorRepository = hidraulicSystemsAdjustmentFactorRepository;
            _heatingSystemEfficiencyComponentsRepository = heatingSystemEfficiencyComponentsRepository;
            _seasonalHeatGenerationEfficiencyFactorRepository = seasonalHeatGenerationEfficiencyFactorRepository;

            _coolingEnergyConsumptionService = coolingEnergyConsumptionService;
            _heatingEnergyConsumptionService = heatingEnergyConsumptionService;
            _mapper = mapper;
        }

        public string getClass(EnergyEfficiencyInputModel data)
        {
            _data = data;

            var efficiencyValue = getEfficiencyValue(data.Building, data.TempZone, data.Stories, null);

            if (efficiencyValue < -50)
            {
                return EnergyEfficiencyClass.a;
            }
            else if (-50 <= efficiencyValue && efficiencyValue < -20)
            {
                return EnergyEfficiencyClass.b;
            }
            else if (-20 <= efficiencyValue && efficiencyValue < 0)
            {
                return EnergyEfficiencyClass.c;
            }
            else if (0 <= efficiencyValue && efficiencyValue < 20)
            {
                return EnergyEfficiencyClass.d;
            }
            else if (20 <= efficiencyValue && efficiencyValue < 35)
            {
                return EnergyEfficiencyClass.e;
            }
            else if (35 <= efficiencyValue && efficiencyValue < 50)
            {
                return EnergyEfficiencyClass.f;
            }

            return EnergyEfficiencyClass.g;
        }

        public string GetClassFromMeter(EfficiencyMeterInputModel data)
        {
            var efficiencyValue = getEfficiencyValue(data.Building, data.TempZone, data.Stories, data.efficiencyValue);

            if (efficiencyValue < -50)
            {
                return EnergyEfficiencyClass.a;
            }
            else if (-50 <= efficiencyValue && efficiencyValue < -20)
            {
                return EnergyEfficiencyClass.b;
            }
            else if (-20 <= efficiencyValue && efficiencyValue < 0)
            {
                return EnergyEfficiencyClass.c;
            }
            else if (0 <= efficiencyValue && efficiencyValue < 20)
            {
                return EnergyEfficiencyClass.d;
            }
            else if (20 <= efficiencyValue && efficiencyValue < 35)
            {
                return EnergyEfficiencyClass.e;
            }
            else if (35 <= efficiencyValue && efficiencyValue < 50)
            {
                return EnergyEfficiencyClass.f;
            }

            return EnergyEfficiencyClass.g;
        }

        protected virtual decimal getEfficiencyValue(BuildingType building, TemperatureZone tempZone, int stories, decimal? consumption)
        {
            var peak = getPeakEnergyConsumption(building, tempZone, stories);
            if (consumption != null)
            {
                return ((decimal)consumption - peak) / peak * 100;
            }
            return (getEnergyConsumption() - peak) / peak * 100;
        }

        protected virtual decimal getEnergyConsumption()
        {
            return _coolingEnergyConsumptionService.GetCoolingEnergyConsumption(_mapper.Map<CoolingEnergyConsumptionModel>(_data))
                + _heatingEnergyConsumptionService.GetHeatingEnergyConsumption(_mapper.Map<HeatingEnergyConsumptionModel>(_data));
        }

        protected decimal getPeakEnergyConsumption(BuildingType building, TemperatureZone tempZone, int stories)
        {
            var formula = _peakEnergyConsumptionRepository
                .FindOneByCondition(val => val.BuildingType == building && val.TemperatureZone == tempZone && val.StoriesMin <= stories && val.StoriesMax >= stories)?.Formula;

            if (formula.IsNullOrEmpty())
            {
                throw new Exception($"No formula found for {building} building type!");
            }

            var expression = new Expression(formula);
            var obj = new object();
            expression.Parameters["factor"] = _data == null ? 1 : getBuildingCompactnessFactor(_data.TotalInnerArea, _data.TotalHeatedArea);

            return Convert.ToDecimal(expression.Evaluate());
        }

        protected decimal getBuildingCompactnessFactor(decimal innerArea, decimal heatedArea) => innerArea / heatedArea;
    }
}
