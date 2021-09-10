namespace OidApiAuthorization.Base.Interfaces
{
    public interface IAuthorizationHeaderBearerTokenExtractor<T> where T: class
  {
        string GetToken(T headers);
  }
}
