using EnergyEfficiencyBE.Models.Dtos;
using EnergyEfficiencyBE.Services.Interfaces.EfficiencyAdvices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnergyEfficiencyBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AdviceController : ControllerBase
    {
        private readonly IAdviceService _service;

        public AdviceController(IAdviceService service) { _service = service; }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.FindAllAsync();
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _service.FindByIdAsync(id);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Message);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetFor([FromBody] AdviceCriteriaDto data)
        {
            var result = await _service
                .FindByConditionAsync(val => (data.BuildingType == Constants.BuildingType.Any ? true : data.BuildingType == val.BuildingType) && val.MinPrice >= data.MinPrice && val.MaxPrice <= data.MaxPrice);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AdviceDto data)
        {
            var result = await _service.CreateAsync(data);
            return result.IsSuccess ? Ok("Success!") : NotFound(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _service.DeleteAsync(id);
            return result.IsSuccess ? Ok("Success!") : NotFound(result.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AdviceDto data)
        {
            var result = await _service.UpdateAsync(data);
            return result.IsSuccess ? Ok("Success!") : NotFound(result.Message);
        }
    }
}
