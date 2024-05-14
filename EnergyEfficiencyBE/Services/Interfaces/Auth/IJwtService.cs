using EnergyEfficiencyBE.Models.Auth;
using EnergyEfficiencyBE.Models.Entities.Auth;
using EnergyEfficiencyBE.Models.ResultPattern;

namespace EnergyEfficiencyBE.Services.Interfaces.Auth
{
    public interface IJwtService
    {
        Task<Result<TokenModel>> GenerateTokenPairAsync(AuthUser user);
        Task<Result<TokenModel>> RefreshTokenAsync(RefreshTokenModel tokenModel);
    }
}
