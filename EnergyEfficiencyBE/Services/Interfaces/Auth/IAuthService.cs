using EnergyEfficiencyBE.Models.Auth;
using EnergyEfficiencyBE.Models.Entities.Auth;
using EnergyEfficiencyBE.Models.ResultPattern;
using Microsoft.AspNetCore.Identity;

namespace EnergyEfficiencyBE.Services.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<Result<(IdentityResult, User)>> RegisterUserAsync(RegisterModel model);
        Task<Result<TokenModel>> LoginUserAsync(LoginModel model);
        Task<Result<TokenModel>> ChangePasswordAsync(ChangePasswordModel model);
    }
}
