// <copyright file="DefaultJwtGenerator.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Okta.Sdk.Configuration;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// Default JWT generator.
    /// </summary>
    public class DefaultJwtGenerator : IJwtGenerator
    {
        private readonly OktaClientConfiguration _configuration;

        private static IList<string> _supportedKeys = new List<string>() { "RSA", "EC" };

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultJwtGenerator"/> class.
        /// </summary>
        /// <param name="configuration">The Okta client configuration.</param>
        public DefaultJwtGenerator(OktaClientConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("The Okta configuration cannot be null.");
            }

            if (!_supportedKeys.Contains(configuration.PrivateKey?.Kty))
            {
                throw new NotSupportedException($"The kty {configuration.PrivateKey?.Kty} is not supported. Use 'EC' or 'RSA'.");
            }

            _configuration = configuration;
        }

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
            else
            {
                return SecurityAlgorithms.EcdsaSha256;
            }
        }

        /// <inheritdoc/>
        public string GenerateSignedJWT()
        {
            try
            {
                TimeSpan timeSpanIat = DateTime.UtcNow - new DateTime(1970, 1, 1);
		TimeSpan timeSpanExp = DateTime.UtcNow.AddMinutes(50) - new DateTime(1970, 1, 1);

                var payload = new JwtPayload
                {
                    { "sub", _configuration.ClientId },
                    { "iat", (int)timeSpanIat.TotalSeconds },
                    { "exp", (int)timeSpanExp.TotalSeconds },
                    { "iss", _configuration.ClientId },
                    { "aud", $"{_configuration.OktaDomain}oauth2/v1/token" },
                    { "jti", Guid.NewGuid() },
                };

                var jsonWebKey = new Microsoft.IdentityModel.Tokens.JsonWebKey(JsonConvert.SerializeObject(_configuration.PrivateKey));

                var securityToken = new JwtSecurityToken(new JwtHeader(GetSigningCredentials(_configuration.PrivateKey)), payload);

                return new JwtSecurityTokenHandler().WriteToken(securityToken);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Something went wrong when creating the signed JWT. Verify your private key.", e);
            }
        }
    }
}
