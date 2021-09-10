using Microsoft.IdentityModel.Tokens;

namespace OidcApiAuthorization.Base.Interfaces
{
    public interface IJwtSecurityTokenHandlerWrapper
    {
        void ValidateToken(string token, TokenValidationParameters tokenValidationParameters);
    }
}
