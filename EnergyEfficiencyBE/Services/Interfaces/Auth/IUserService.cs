using EnergyEfficiencyBE.Models.Dtos;
using EnergyEfficiencyBE.Models.Entities.Auth;
using EnergyEfficiencyBE.Models.ResultPattern;

namespace EnergyEfficiencyBE.Services.Interfaces.Auth
{
    public interface IUserService : IBaseService<User, UserBaseDto>
    {
        Task<Result> DeleteAsync(Guid applicationUserId);
        Task<Result> UpdateAsync(UserUpdateDto dto);
    }
}
