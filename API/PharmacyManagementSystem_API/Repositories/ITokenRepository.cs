using Microsoft.AspNetCore.Identity;

namespace PharmacyManagementSystem.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> role);
    }
}
