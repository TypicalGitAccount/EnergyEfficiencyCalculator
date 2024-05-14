using EnergyEfficiencyBE.Models.EfficiencyClass;

namespace EnergyEfficiencyBE.Services.Interfaces.EfficiencyClass
{
    public interface IHeatingEnergyConsumptionService
    {
        decimal GetHeatingEnergyConsumption(HeatingEnergyConsumptionModel data);
    }
}
