using System.Threading.Tasks;
using OidcApiAuthorization.Base.Models;

namespace OidcApiAuthorization.Base.Interfaces
{
    public interface IApiAuthorization<T> where T: class
    {
        Task<ApiAuthorizationResult> AuthorizeAsync(T headers);

        Task<HealthCheckResult> HealthCheckAsync();
    }
}
