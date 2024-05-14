using EnergyEfficiencyBE.Models.EfficiencyClass;

namespace EnergyEfficiencyBE.Services.Interfaces.EfficiencyClass
{
    public interface IPaymentService
    {
        public decimal[] GetHeatingPayment(EnergyMeterEfficiencyModel data);
    }
}
