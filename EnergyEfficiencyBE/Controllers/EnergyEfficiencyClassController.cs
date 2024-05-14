using EnergyEfficiencyBE.Models.EfficiencyClass;
using EnergyEfficiencyBE.Services.Interfaces.EfficiencyClass;
using Microsoft.AspNetCore.Mvc;

namespace EnergyEfficiencyBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnergyEfficiencyController : ControllerBase
    {
        private readonly IEnergyEfficiencyClassService _service;
        private readonly IPaymentService _paymentService;

        public EnergyEfficiencyController(IEnergyEfficiencyClassService service, IPaymentService paymentService)
        {
            _service = service;
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> GetClass([FromBody] EnergyEfficiencyInputModel data)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).FirstOrDefault()
                    );

                return BadRequest(errors);
            }

            var result = _service.getClass(data);
            return Ok(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetFromMeter([FromBody] EfficiencyMeterInputModel data)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).FirstOrDefault()
                    );

                return BadRequest(errors);
            }

            var result = _service.GetClassFromMeter(data);
            return Ok(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Payments([FromBody] EnergyMeterEfficiencyModel data)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).FirstOrDefault()
                    );

                return BadRequest(errors);
            }

            var result = _paymentService.GetHeatingPayment(data);
            return Ok(result);
        }
    }
}
