using EnergyEfficiencyBE.Models.Dtos;
using EnergyEfficiencyBE.Models.Validation;
using EnergyEfficiencyBE.Services.Interfaces.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnergyEfficiencyBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
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

        [HttpDelete("{id}")]
        [ActionAccess("manage-user")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _service.DeleteAsync(id);
            return result.IsSuccess ? Ok("Success!") : NotFound(result.Message);
        }

        [HttpPut]
        [ActionAccess("manage-user")]
        public async Task<IActionResult> Update([FromBody] UserUpdateDto param)
        {
            var result = await _service.UpdateAsync(param);
            return result.IsSuccess ? Ok("Success!") : NotFound(result.Message);
        }
    }
}
