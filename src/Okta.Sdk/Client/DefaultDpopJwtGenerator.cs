using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Okta.Sdk.Client
{
    public class DefaultDpopJwtGenerator
    {
        
        private readonly IReadableConfiguration _configuration;
        private readonly RSA _rsa;

        public DefaultDpopJwtGenerator(IReadableConfiguration configuration)
        {
            _rsa = RSA.Create();

            if (configuration == null)
            {
                throw new ArgumentNullException("The Okta configuration cannot be null.");
            }

            _configuration = configuration;
        }

        public string GenerateJWT(String? nonce = null)
        {
            try
            {
                TimeSpan timeSpanIat = DateTime.UtcNow - new DateTime(1970, 1, 1);

                var payload = new JwtPayload
                {
                    { "htm", "POST" },
                    { "htu", $"{ClientUtils.EnsureTrailingSlash(_configuration.OktaDomain)}oauth2/v1/token" },
                    { "iat", (int)timeSpanIat.TotalSeconds },
                    { "jti", Guid.NewGuid()}
                };

                if (!nonce.IsNullOrEmpty())
                {
                    payload.AddClaim(new Claim("nonce", nonce));
                }

                var publicKey = new RsaSecurityKey(_rsa.ExportParameters(false));
                var publicJsonWebKey = JsonWebKeyConverter.ConvertFromRSASecurityKey(publicKey);

                RsaSecurityKey keys = new RsaSecurityKey(_rsa.ExportParameters(true));

                var signingCredentials = new SigningCredentials(keys, SecurityAlgorithms.RsaSha256);
                
                var outboundAlgorithmMap = new Dictionary<string, string> { { "alg", SecurityAlgorithms.RsaSha256 } };

                var additionalHeaders = new Dictionary<string, object> { { "jwk", publicJsonWebKey } };

                var securityToken =
                    new JwtSecurityToken(
                        new JwtHeader(signingCredentials, outboundAlgorithmMap, "dpop+jwt", additionalHeaders),
                        payload);

                return new JwtSecurityTokenHandler().WriteToken(securityToken);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Something went wrong when creating the signed JWT. Verify your private key.", e);
            }
        }

    }
}
