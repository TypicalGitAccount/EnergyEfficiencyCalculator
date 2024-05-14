using EnergyEfficiencyBE.Models.EfficiencyClass;

namespace EnergyEfficiencyBE.Services.Interfaces.EfficiencyClass
{
    public interface ICoolingEnergyConsumptionService
    {
        decimal GetCoolingEnergyConsumption(CoolingEnergyConsumptionModel data);
    }
}
