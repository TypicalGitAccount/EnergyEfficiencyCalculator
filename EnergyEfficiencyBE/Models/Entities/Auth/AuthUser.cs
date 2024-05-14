namespace EnergyEfficiencyBE.Models.Entities.Auth
{
    public class AuthUser : Microsoft.AspNetCore.Identity.IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
