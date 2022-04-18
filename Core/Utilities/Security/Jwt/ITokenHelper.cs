using Core.Entities;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        IAccessToken CreateToken(JwtAuthUser user);
        bool ValidateToken(string accessToken);
    }
}
