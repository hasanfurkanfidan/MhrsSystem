using System;

namespace Core.Utilities.Security.Jwt
{
    internal class AccessToken : IAccessToken
    {
        public DateTime Expiration { get ; set ; }
        public string Token { get; set ; }

    }
}
