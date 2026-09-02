// <copyright file="DefaultClientAssertionJwtGeneratorShould.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using FluentAssertions;
using Microsoft.IdentityModel.Tokens;
using Okta.Sdk.Client;
using Xunit;

namespace Okta.Sdk.UnitTest.Client
{
    /// <summary>
    /// Issue #864: a private key that authenticates a Super Admin application had to be written to
    /// okta.yaml or appsettings.json, where anyone who can read the file can take the tenant. Signing
    /// credentials can be supplied instead, so the key can stay in a TPM or an HSM and only ever sign.
    /// </summary>
    public class DefaultClientAssertionJwtGeneratorShould
    {
        [Fact]
        public void SignTheClientAssertionWithSuppliedCredentials()
        {
            using (var rsa = RSA.Create(2048))
            {
                var configuration = PrivateKeyConfiguration();
                configuration.PrivateKeySigningCredentials =
                    new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256);

                var jwt = new DefaultClientAssertionJwtGenerator(configuration).GenerateJwt();

                var decoded = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
                decoded.Header.Alg.Should().Be(SecurityAlgorithms.RsaSha256);
                decoded.Payload.Sub.Should().Be("test-client-id");
                decoded.Payload.Iss.Should().Be("test-client-id");
                decoded.Payload.Aud.Should().Contain("https://test.okta.com/oauth2/v1/token");
                decoded.Payload.Jti.Should().NotBeNullOrEmpty();

                // The signature has to verify against the key that was supplied, otherwise the JWK path
                // was silently used instead.
                new JwtSecurityTokenHandler().ValidateToken(
                    jwt,
                    new TokenValidationParameters
                    {
                        IssuerSigningKey = new RsaSecurityKey(rsa),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                    },
                    out _);
            }
        }

        /// <summary>
        /// An ECDsa key covers the other algorithm Okta accepts, and proves nothing in the generator
        /// assumes RSA once credentials are supplied.
        /// </summary>
        [Fact]
        public void SignTheClientAssertionWithSuppliedEllipticCurveCredentials()
        {
            using (var ecdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256))
            {
                var configuration = PrivateKeyConfiguration();
                configuration.PrivateKeySigningCredentials =
                    new SigningCredentials(new ECDsaSecurityKey(ecdsa), SecurityAlgorithms.EcdsaSha256);

                var jwt = new DefaultClientAssertionJwtGenerator(configuration).GenerateJwt();

                new JwtSecurityTokenHandler().ReadJwtToken(jwt).Header.Alg.Should().Be(SecurityAlgorithms.EcdsaSha256);
            }
        }

        /// <summary>
        /// The kty check exists for JWKs read from configuration. Supplied credentials carry their own
        /// algorithm, so there is no kty to reject.
        /// </summary>
        [Fact]
        public void NotRequireAJsonWebKeyWhenCredentialsAreSupplied()
        {
            using (var rsa = RSA.Create(2048))
            {
                var configuration = PrivateKeyConfiguration();
                configuration.PrivateKey.Should().BeNull();
                configuration.PrivateKeySigningCredentials =
                    new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256);

                var generator = new DefaultClientAssertionJwtGenerator(configuration);

                generator.GenerateJwt().Should().NotBeNullOrEmpty();
            }
        }

        [Fact]
        public void StillRejectAnUnsupportedJsonWebKeyWhenNoCredentialsAreSupplied()
        {
            var configuration = PrivateKeyConfiguration();
            configuration.PrivateKey = new JsonWebKeyConfiguration { Kty = "oct" };

            Assert.Throws<NotSupportedException>(() => new DefaultClientAssertionJwtGenerator(configuration));
        }

        /// <summary>
        /// Supplied credentials must win, because the caller's reason for supplying them is that the key
        /// behind them is not available as a JWK.
        /// </summary>
        [Fact]
        public void PreferSuppliedCredentialsOverAConfiguredJsonWebKey()
        {
            using (var suppliedKey = RSA.Create(2048))
            using (var jwkKey = RSA.Create(2048))
            {
                var configuration = PrivateKeyConfiguration();
                configuration.PrivateKey = JwkFrom(jwkKey);
                configuration.PrivateKeySigningCredentials =
                    new SigningCredentials(new RsaSecurityKey(suppliedKey), SecurityAlgorithms.RsaSha256);

                var jwt = new DefaultClientAssertionJwtGenerator(configuration).GenerateJwt();

                Assert.Throws<SecurityTokenSignatureKeyNotFoundException>(() =>
                    new JwtSecurityTokenHandler().ValidateToken(
                        jwt,
                        new TokenValidationParameters
                        {
                            IssuerSigningKey = new RsaSecurityKey(jwkKey),
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateLifetime = false,
                        },
                        out _));
            }
        }

        [Fact]
        public void AcceptPrivateKeyModeWhenOnlyCredentialsAreSupplied()
        {
            using (var rsa = RSA.Create(2048))
            {
                var configuration = PrivateKeyConfiguration();
                configuration.PrivateKeySigningCredentials =
                    new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256);

                Configuration.Validate(configuration);
            }
        }

        [Fact]
        public void StillRequireAKeyInPrivateKeyMode()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => Configuration.Validate(PrivateKeyConfiguration()));

            exception.Message.Should().Contain("PrivateKeySigningCredentials",
                "because the message has to mention the alternative it is now offering");
        }

        /// <summary>
        /// Clients resolve their configuration through GetConfigurationOrDefault, and credentials cannot
        /// travel through the configuration providers, so they have to be carried across explicitly.
        /// </summary>
        [Fact]
        public void SurviveConfigurationResolution()
        {
            using (var rsa = RSA.Create(2048))
            {
                var credentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256);
                var configuration = PrivateKeyConfiguration();
                configuration.PrivateKeySigningCredentials = credentials;

                Configuration.GetConfigurationOrDefault(configuration)
                    .PrivateKeySigningCredentials.Should().BeSameAs(credentials);
            }
        }

        [Fact]
        public void SurviveConfigurationMerging()
        {
            using (var rsa = RSA.Create(2048))
            {
                var credentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256);
                var withCredentials = new Configuration { PrivateKeySigningCredentials = credentials };

                Configuration.MergeConfigurations(withCredentials, new Configuration())
                    .PrivateKeySigningCredentials.Should().BeSameAs(credentials);

                Configuration.MergeConfigurations(new Configuration(), withCredentials)
                    .PrivateKeySigningCredentials.Should().BeSameAs(credentials);
            }
        }

        private static Configuration PrivateKeyConfiguration() => new Configuration
        {
            OktaDomain = "https://test.okta.com",
            AuthorizationMode = AuthorizationMode.PrivateKey,
            ClientId = "test-client-id",
            Scopes = new HashSet<string> { "okta.users.read" },
        };

        private static JsonWebKeyConfiguration JwkFrom(RSA rsa)
        {
            var parameters = rsa.ExportParameters(includePrivateParameters: true);

            return new JsonWebKeyConfiguration
            {
                Kty = "RSA",
                N = Base64UrlEncoder.Encode(parameters.Modulus),
                E = Base64UrlEncoder.Encode(parameters.Exponent),
                D = Base64UrlEncoder.Encode(parameters.D),
                P = Base64UrlEncoder.Encode(parameters.P),
                Q = Base64UrlEncoder.Encode(parameters.Q),
                Dp = Base64UrlEncoder.Encode(parameters.DP),
                Dq = Base64UrlEncoder.Encode(parameters.DQ),
                Qi = Base64UrlEncoder.Encode(parameters.InverseQ),
            };
        }
    }
}
