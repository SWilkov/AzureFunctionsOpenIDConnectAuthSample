using System;
using System.Linq;
using System.Net.Http.Headers;
using Microsoft.Azure.Functions.Worker.Http;
using OidcApiAuthorization.Base.Interfaces;

namespace OidcApiAuthorization.Services
{
    public class AuthorizationHeaderBearerTokenExtractor : IAuthorizationHeaderBearerTokenExtractor<HttpHeadersCollection>
    {
        /// <summary>
        /// Extracts the Bearer token from the Authorization header of the given HTTP request headers.
        /// </summary>
        /// <param name="headers">
        /// The headers from an HTTP request.
        /// </param>
        /// <returns>
        /// The Bearer token extracted from the Authorization header (without the "Bearer " prefix),
        /// or null if the Authorization header was not found, it is in an invalid format,
        /// or its value is not a Bearer token.
        /// </returns>
        public string GetToken(HttpHeadersCollection headers)
        {

            var rawAuthorizationHeaderValue = headers.SingleOrDefault(x => x.Key == "Authorization").Value;
            if (rawAuthorizationHeaderValue.Count() != 1)
            {
                return null;
            }

            // We got a value from the Authorization header.
            if (!AuthenticationHeaderValue.TryParse(
                    rawAuthorizationHeaderValue.First(), 
                    out AuthenticationHeaderValue authenticationHeaderValue))
            {
                // Invalid token format.
                return null;
            }

            if (!string.Equals(
                    authenticationHeaderValue.Scheme,
                    "Bearer",
                    StringComparison.InvariantCultureIgnoreCase)) // Case insenitive.
            {
                // The Authorization header's value is not a Bearer token.
                return null;
            }

            // Return the token from the Athorization header.
            // This is the token with the "Bearer " prefix removed.
            // The Parameter will be null, if nothing followed the "Bearer " prefix.
            return authenticationHeaderValue.Parameter;
        }
    }
}
