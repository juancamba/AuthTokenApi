using AuthApi.Data;

namespace AuthApi.Services
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);
    }
}