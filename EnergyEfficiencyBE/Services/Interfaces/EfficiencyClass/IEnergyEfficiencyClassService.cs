using EnergyEfficiencyBE.Models.EfficiencyClass;

namespace EnergyEfficiencyBE.Services.Interfaces.EfficiencyClass
{
    public interface IEnergyEfficiencyClassService
    {
        public string getClass(EnergyEfficiencyInputModel data);
        string GetClassFromMeter(EfficiencyMeterInputModel data);
    }
}
