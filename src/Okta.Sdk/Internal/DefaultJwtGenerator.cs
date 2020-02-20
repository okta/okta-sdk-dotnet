// <copyright file="JWTGenerator.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Okta.Sdk.Configuration;

namespace Okta.Sdk.Internal
{
    public class DefaultJwtGenerator : IJwtGenerator
    {
        /// <summary>
        /// Gets a new SigningCredentials instance.
        /// </summary>
        /// <param name="jsonWebKeyConfiguration">The JWK configuration.</param>
        /// <returns>A <c>SigningCredentials</c> instance. </returns>
        private SigningCredentials GetSigningCredentials(JsonWebKeyConfiguration jsonWebKeyConfiguration)
        {
            var jsonWebKey = new Microsoft.IdentityModel.Tokens.JsonWebKey(JsonConvert.SerializeObject(jsonWebKeyConfiguration));

            return new SigningCredentials(jsonWebKey, GetSecurityAlgorithm(jsonWebKeyConfiguration.Kty));
        }

        private string GetSecurityAlgorithm(string kty)
        {
            if (kty == "RSA")
            {
                return SecurityAlgorithms.RsaSha256;
            }
            else if (kty == "EC")
            {
                return SecurityAlgorithms.EcdsaSha256;
            }
            else
            {
                throw new NotSupportedException($"The kty {kty} is not supported. Use 'EC' or 'RSA'.");
            }
        }

        /// <summary>
        /// Generates a signed JWT.
        /// </summary>
        /// <param name="configuration">The Okta client configuration.</param>
        /// <returns>The generated JWT.</returns>
        public string GenerateSignedJWT(OktaClientConfiguration configuration)
        {
            try
            {
                TimeSpan timeSpanIat = DateTime.UtcNow - new DateTime(1970, 1, 1);
                TimeSpan timeSpanExp = DateTime.UtcNow.AddHours(1) - new DateTime(1970, 1, 1);

                var payload = new JwtPayload
                {
                    { "sub", configuration.ClientId },
                    { "iat", (int)timeSpanIat.TotalSeconds },
                    { "exp", (int)timeSpanExp.TotalSeconds },
                    { "iss", configuration.ClientId },
                    { "aud", $"{configuration.OktaDomain}oauth2/v1/token" },
                };

                var jsonWebKey = new Microsoft.IdentityModel.Tokens.JsonWebKey(JsonConvert.SerializeObject(configuration.PrivateKey));

                var securityToken = new JwtSecurityToken(new JwtHeader(GetSigningCredentials(configuration.PrivateKey)), payload);

                return new JwtSecurityTokenHandler().WriteToken(securityToken);
            }
            catch (NotSupportedException)
            {
                throw;
            }

            catch (Exception e)
            {
                throw new InvalidOperationException("Something went wrong when creating the signed JWT. Verify your private key.", e);
            }
        }
    }
}
