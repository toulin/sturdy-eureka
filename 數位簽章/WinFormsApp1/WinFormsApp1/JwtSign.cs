using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using OpenSSL.PrivateKeyDecoder;
using OpenSSL.PublicKeyDecoder;

namespace WinFormsApp1
{
    public class JwtSign
    {
        private const string _issuer = "761326798069-r5mljlln1rd4lrbhg75efgigp36m78j5@developer.gserviceaccount.com";
        private const string _audience = "https://accounts.google.com/o/oauth2/token";

        private const string _scope1 = "https://www.googleapis.com/auth/cloud-platform";
        private const string _scope2 = "https://www.googleapis.com/auth/firebase.messaging";

        private class CustomClaimTypes
        {
            public const string Scope = "scope";
        }

        /// <summary>
        /// Redis之類的儲存體
        /// </summary>
        public Dictionary<string, string[]> AccessTokenMapScopes { get; set; }

        /// <summary>
        /// Server App Create and sign JWT
        /// </summary>
        /// <returns></returns>
        public string SignJwt()
        {
            const string _privateKey =
"-----BEGIN RSA PRIVATE KEY-----"
+ "MIIEpAIBAAKCAQEA0ZcbV96cEo1Irsf2laOrsRjabBrzhF6OcJUIHaepUDCHD3FQ"
+ "AlJDbpJMjWz/8GmHSV/h2cigiOU6nk+2rrzVTvmi1ga8vUXoEip+8nuIm2AP0r8B"
+ "gOTBLpe+6XFpaFBbqytsMpq09tAl6z2V8M0VELUsXC+sdts/bPmmhNi9E+r5vLA3"
+ "4J6XgPUDeYiY3lPCgj1UNpvsjpCa/FECfoPC69Ar3cDDNEcbRWLhoIoUMFOQQQI3"
+ "ylFuURAmxG4dm7U5kVgukb4NZZfg7hfmgcxUYpSm70fbrKQBNj+dR0Ee58gxOdK3"
+ "cnp7Dpz1GLAaJsXNgVdtU3BOwJn2EsqpNaxg0wIDAQABAoIBADvH8vekOjYccF/S"
+ "D2ZtMbqo0RxGr7DQ26YHDDKRMPz7anqgImcXGb6/IfCw52umXf0yyRO6YvfJEmg3"
+ "am7604jcMXMEpu8BsokD8AOv8q4Gv1yoOICQPv3QMJcbTyp+yTbQguMIN5eylS48"
+ "+biedmS2mHmO641XSgcGSlXYEE5OkjqisvCf2EyQMGCzWmHmHlLwLlurxM8YfQ+M"
+ "EFBAU64MFGVCu+0NAptrgIY2lRLwlkf9C7rMzPaf3wyv3OWdzSxc83Wyc/qTbucm"
+ "CjdfEjElmo0K9oRF8RCwmDh5NbngmUv6SJMc5s3ulJ14paxm0T5biqDTQnNWUFWF"
+ "zyvnT9ECgYEA8ghqJzBOQfVf/GCi8W+1mOIynYm6lH74GnjnhJpZUATiJr30hJoY"
+ "fofrcGasSyeQYMBe9HrLOwEL4TH7JID90XFmHQ2Is7qErHJBkTGY1CMv9TpGIgXR"
+ "gLyhRd123CbcFsUWNfNCYAXT+FBFSLOe+fV0PEDQ56iss97+vSu27OkCgYEA3a9p"
+ "uBBtku8mzDlfHRGDOLdbgoNh/Oi5rsnC6/sVGW1/8pAYQ0LyLlpQQwJp+gqWqQKS"
+ "M+7tJhPQ3YYVcTBfT1WrUpmIXCIJnKrFSq4sDpAPOl+8HqYXFOR4p3WaWmBQRBSv"
+ "g/Tku1YPfs1biFhtEpv+5ZTA9x2A/Z7EF7rSmlsCgYB78mc6bniFOr3PJ0YK0qRz"
+ "CNPW7aOJTISOOgCGXe0DF50hLgI8rhWBJuYhh9MQIdDEW3/FP+U38E8/IjN0/EH/"
+ "sk0S781kDU7IaTK+wmF7shFrSk6EOeqSPQdyGfo2wAfR+VhohI0nU5S8A4+XrbTq"
+ "WRMPkDnriOv4qWhXRD3HkQKBgQDbgpxOVIYLnp9uTcjuwa6L9JO6cloO0ms6tjI6"
+ "9Q55dUHib+h2gc3JNEiRccx6eQ2iIRegMQ/GSozhLaoBwII/znasfbbWdCXMahSd"
+ "1EVvzhomFTHzr0bfuzP1ra+/mesg3tLE+TOchKUnTDU8l0K50JnfvyIsD5zwhctq"
+ "K+XqTQKBgQDGn5ujA/lsYSGOeQFz17XdfP4tFnqQw/lr6F3oDVFnL2RrEvXfANTl"
+ "6pHFVJleYhaTglAuGYUh9X8db7q2i0odvqBdzvXc9GNld4xN2hGscZj5rQ+5UWgr"
+ "GQAgAwF6ZlcK/2yFWe5sTSW48HSRQo7IyXGuP9lM9JQ+szXPht41Yw=="
+ "-----END RSA PRIVATE KEY-----";

            var decoder = new OpenSSLPrivateKeyDecoder();
            var rsaParameters = decoder.DecodeParameters(_privateKey);
            var privateKey = new RsaSecurityKey(rsaParameters);

            // header
            var signingCredentials = new SigningCredentials(privateKey, SecurityAlgorithms.RsaSha256);
            var header = new JwtHeader(signingCredentials);

            // payload
            var claims = new Claim[]
            {
                new Claim(CustomClaimTypes.Scope, _scope1),
                new Claim(CustomClaimTypes.Scope, _scope2)
            };
            var now = DateTime.UtcNow;
            var payload = new JwtPayload(_issuer, _audience, claims, now.AddHours(-1), now.AddDays(1), now);

            // sign jwt 
            var token = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }

        /// <summary>
        /// Use JWT to request token
        /// </summary>
        /// <param name="jwt"></param>
        /// <returns></returns>
        public TokenResponse ValidateJwt(string jwt)
        {
            const string _publicKey =
"-----BEGIN PUBLIC KEY-----"
+ "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA0ZcbV96cEo1Irsf2laOr"
+ "sRjabBrzhF6OcJUIHaepUDCHD3FQAlJDbpJMjWz/8GmHSV/h2cigiOU6nk+2rrzV"
+ "Tvmi1ga8vUXoEip+8nuIm2AP0r8BgOTBLpe+6XFpaFBbqytsMpq09tAl6z2V8M0V"
+ "ELUsXC+sdts/bPmmhNi9E+r5vLA34J6XgPUDeYiY3lPCgj1UNpvsjpCa/FECfoPC"
+ "69Ar3cDDNEcbRWLhoIoUMFOQQQI3ylFuURAmxG4dm7U5kVgukb4NZZfg7hfmgcxU"
+ "YpSm70fbrKQBNj+dR0Ee58gxOdK3cnp7Dpz1GLAaJsXNgVdtU3BOwJn2EsqpNaxg"
+ "0wIDAQAB"
+ "-----END PUBLIC KEY-----";

            var handler = new JwtSecurityTokenHandler();
            if (!handler.CanReadToken(jwt))
            {
                return new TokenResponse(false, null);
            }

            try
            {
                var decoder = new OpenSSLPublicKeyDecoder();
                var rsaParameters = decoder.DecodeParameters(_publicKey);
                var publicKey = new RsaSecurityKey(rsaParameters);

                var tokenValidationParameters = new TokenValidationParameters
                {
                    // Verify Signature
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = publicKey,

                    // Validate Audience
                    ValidateAudience = true,
                    ValidAudiences = new string[] { _audience },

                    // Validate Issuer
                    ValidateIssuer = true,
                    ValidIssuer = _issuer,

                    // Validate token life time
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.Zero,
                };

                var claimsPrincipal = handler.ValidateToken(jwt, tokenValidationParameters, out var validToken);
                var scopes = claimsPrincipal.FindAll(CustomClaimTypes.Scope).Select(claim => claim.Value).ToArray();

                var someAccessToken = Guid.NewGuid().ToString();
                AccessTokenMapScopes.Add(someAccessToken, scopes);

                return new TokenResponse(true, someAccessToken);
            }
            catch
            {
                return new TokenResponse(false, null);
            }
        }

        public class TokenResponse
        {
            public TokenResponse(bool isValid, string accessToken)
            {
                IsValid = isValid;
                AccessToken = accessToken;
            }

            public bool IsValid { get; set; }

            public string AccessToken { get; set; }
        }

        /// <summary>
        /// Access resource of scope1
        /// </summary>
        /// <param name="access_token"></param>
        public int AccessResource1(string access_token)
        {
            if (!AccessTokenMapScopes.TryGetValue(access_token, out var scopes))
            {
                return StatusCodes.Status401Unauthorized;
            }

            if (!scopes.Contains(_scope1))
            {
                return StatusCodes.Status403Forbidden;
            }
            return StatusCodes.Status200OK;
        }

        /// <summary>
        /// Access resource of scope2
        /// </summary>
        /// <param name="access_token"></param>
        public int AccessResource2(string access_token)
        {
            if (!AccessTokenMapScopes.TryGetValue(access_token, out var scopes))
            {
                return StatusCodes.Status401Unauthorized;
            }

            if (!scopes.Contains(_scope2))
            {
                return StatusCodes.Status403Forbidden;
            }
            return StatusCodes.Status200OK;
        }
    }
}
