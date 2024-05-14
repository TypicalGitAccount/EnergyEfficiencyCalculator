using EnergyEfficiencyBE.Models.EfficiencyClass;
using EnergyEfficiencyBE.Services.Interfaces.EfficiencyClass;

namespace EnergyEfficiencyBE.Services.Implementations.EfficiencyClass
{
    public class PaymentService : IPaymentService
    {
        protected EnergyMeterEfficiencyModel _data { get; set; }

        public decimal[] GetHeatingPayment(EnergyMeterEfficiencyModel data)
        {
            _data = data;

            var results = new decimal[12];

            for (int i = 0; i < results.Length; i++)
            {
                if (_data.heatingConsumptionMonths[i] > 0)
                {
                    results[i] = _data.heatingConsumptionMonths[i] * _data.Price;
                } else
                {
                    results[i] = 0;
                }
            }

            return results;
        }
    }
}
