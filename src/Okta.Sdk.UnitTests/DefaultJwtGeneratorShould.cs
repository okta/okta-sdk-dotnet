// <copyright file="DefaultJwtGeneratorShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using FluentAssertions;
using Microsoft.IdentityModel.Tokens;
using Okta.Sdk.Configuration;
using Okta.Sdk.Internal;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class DefaultJwtGeneratorShould
    {
        [Theory]
        [InlineData("foo")]
        [InlineData("bar")]
        public void FailForUnsupportedKty(string kty)
        {
            var mockPrivateKeyConfiguration = TestCryptoKeys.GetMockRSAPrivateKeyConfiguration();
            mockPrivateKeyConfiguration.Kty = kty;

            var configuration = new OktaClientConfiguration();
            configuration.OktaDomain = "https://myOktaDomain.oktapreview.com";
            configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
            configuration.ClientId = "foo";
            configuration.PrivateKey = mockPrivateKeyConfiguration;
            configuration.Scopes = new List<string> { "foo" };

            Action action = () => new DefaultJwtGenerator(configuration).GenerateSignedJWT();
            action.Should().Throw<NotSupportedException>();
        }

        [Fact]
        public void FailForInvalidPrivateKey()
        {
            var mockPrivateKeyConfiguration = TestCryptoKeys.GetMockRSAPrivateKeyConfiguration();
            mockPrivateKeyConfiguration.P = "foo";
            mockPrivateKeyConfiguration.Qi = "bar";
            mockPrivateKeyConfiguration.N = string.Empty;

            var configuration = new OktaClientConfiguration();
            configuration.OktaDomain = "https://myOktaDomain.oktapreview.com";
            configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
            configuration.ClientId = "foo";
            configuration.PrivateKey = mockPrivateKeyConfiguration;
            configuration.Scopes = new List<string> { "foo" };

            Action action = () => new DefaultJwtGenerator(configuration).GenerateSignedJWT();
            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void GenerateRSASignedJWT()
        {
            var mockPrivateKeyConfiguration = TestCryptoKeys.GetMockRSAPrivateKeyConfiguration();

            var configuration = new OktaClientConfiguration();
            configuration.OktaDomain = "https://myOktaDomain.oktapreview.com";
            configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
            configuration.ClientId = "foo";
            configuration.PrivateKey = mockPrivateKeyConfiguration;
            configuration.Scopes = new List<string> { "foo" };

            var signedJwt = new DefaultJwtGenerator(configuration).GenerateSignedJWT();

            // Verify signature with public key
            var claimsPrincipal = new JwtSecurityTokenHandler().ValidateToken(
                signedJwt,
                new TokenValidationParameters
                {
                    ValidAudience = $"{configuration.OktaDomain}oauth2/v1/token",
                    ValidIssuer = configuration.ClientId,
                    IssuerSigningKey = TestCryptoKeys.GetMockRSAPublicKey(),
                }, out _);

            claimsPrincipal.Should().NotBeNull();
        }

        [Fact]
        public void GenerateECSignedJWT()
        {
            var mockPrivateKeyConfiguration = TestCryptoKeys.GetMockECPrivateKeyConfiguration();

            var configuration = new OktaClientConfiguration();
            configuration.OktaDomain = "https://myOktaDomain.oktapreview.com";
            configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
            configuration.ClientId = "foo";
            configuration.PrivateKey = mockPrivateKeyConfiguration;
            configuration.Scopes = new List<string> { "foo" };

            var signedJwt = new DefaultJwtGenerator(configuration).GenerateSignedJWT();

            // Verify signature with public key
            var claimsPrincipal = new JwtSecurityTokenHandler().ValidateToken(
                signedJwt,
                new TokenValidationParameters
                {
                    ValidAudience = $"{configuration.OktaDomain}oauth2/v1/token",
                    ValidIssuer = configuration.ClientId,
                    IssuerSigningKey = TestCryptoKeys.GetMockECPublicKey(),
                }, out _);

            claimsPrincipal.Should().NotBeNull();
        }
    }
}
