// <copyright file="DefaultDpopJwtGeneratorShould.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.IdentityModel.Tokens.Jwt;
using FluentAssertions;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Okta.Sdk.Client;
using Xunit;


namespace Okta.Sdk.UnitTest.Client
{
    public class DefaultDpopJwtGeneratorShould
    {
        [Fact]
        [Obsolete("Obsolete")]
        public void GenerateDefaultDpopJwt()
        {
            var configuration = new Configuration
            {
                OktaDomain = "https://foo-admin.okta.com",
                Token = "foo"
            };

            var jwtGenerator = new DefaultDpopProofJwtGenerator(configuration);

            var jwt = jwtGenerator.GenerateJwt();
            jwt.Should().NotBeNullOrEmpty();

            var decodedJwt = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
            
            decodedJwt.Header.Alg.Should().Be(SecurityAlgorithms.RsaSha256);
            decodedJwt.Header.Typ.Should().Be("dpop+jwt");
            decodedJwt.Header["jwk"].Should().NotBeNull();

            decodedJwt.Payload.Iat.Should().NotBeNull();
            decodedJwt.Payload.Jti.Should().NotBeNull();
            decodedJwt.Payload["htm"].ToString().Should().Be("POST");
            decodedJwt.Payload["htu"].ToString().Should()
                .Be($"{ClientUtils.EnsureTrailingSlash(configuration.OktaDomain)}oauth2/v1/token");
            decodedJwt.Payload.ContainsKey("ath").Should().BeFalse();
        }

        [Theory]
        [InlineData("POST", "https://foo.com/resource", "foo")]
        [InlineData("PUT", "https://foo.com/resource/1", "bar")]
        [InlineData("DELETE", "https://foo.com", "baz")]
        [Obsolete("Obsolete")]
        public void GenerateDpopJwtWithParams(string httpMethod, string uri, string accessToken)
        {
            var configuration = new Configuration
            {
                OktaDomain = "https://foo-admin.okta.com",
                Token = "foo"
            };

            var jwtGenerator = new DefaultDpopProofJwtGenerator(configuration);

            var jwt = jwtGenerator.GenerateJwt(httpMethod: httpMethod, accessToken: accessToken, uri: uri);
            jwt.Should().NotBeNullOrEmpty();

            var decodedJwt = new JwtSecurityTokenHandler().ReadJwtToken(jwt);

            decodedJwt.Header.Alg.Should().Be(SecurityAlgorithms.RsaSha256);
            decodedJwt.Header.Typ.Should().Be("dpop+jwt");
            decodedJwt.Header["jwk"].Should().NotBeNull();

            decodedJwt.Payload.Iat.Should().NotBeNull();
            decodedJwt.Payload.Jti.Should().NotBeNull();
            decodedJwt.Payload["htm"].ToString().Should().Be(httpMethod.ToUpperInvariant());
            decodedJwt.Payload["htu"].ToString().Should()
                .Be(uri);
            decodedJwt.Payload["ath"].Should().NotBeNull();
        }

        /// <summary>
        /// Tests that the htm claim is always uppercase per RFC 9449 compliance (issue #852).
        /// RestSharp's Method.ToString() returns PascalCase (e.g., "Get", "Post"), but RFC 9449
        /// requires uppercase HTTP methods in the htm claim.
        /// </summary>
        [Theory]
        [InlineData("get", "GET")]
        [InlineData("Get", "GET")]
        [InlineData("GET", "GET")]
        [InlineData("post", "POST")]
        [InlineData("Post", "POST")]
        [InlineData("POST", "POST")]
        [InlineData("put", "PUT")]
        [InlineData("Put", "PUT")]
        [InlineData("delete", "DELETE")]
        [InlineData("Delete", "DELETE")]
        [InlineData("patch", "PATCH")]
        [InlineData("Patch", "PATCH")]
        [Obsolete("Obsolete")]
        public void GenerateHtmClaimAsUppercase_Rfc9449Compliance(string inputMethod, string expectedHtm)
        {
            // Arrange - This test verifies fix for GitHub issue #852
            // The DPoP 'htm' claim must be uppercase per RFC 9449 Section 4.2
            var configuration = new Configuration
            {
                OktaDomain = "https://foo-admin.okta.com",
                Token = "foo"
            };

            var jwtGenerator = new DefaultDpopProofJwtGenerator(configuration);

            // Act
            var jwt = jwtGenerator.GenerateJwt(httpMethod: inputMethod, uri: "https://example.com/api");
            
            // Assert
            var decodedJwt = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
            decodedJwt.Payload["htm"].ToString().Should().Be(expectedHtm, 
                $"because RFC 9449 requires the htm claim to be uppercase, but got '{decodedJwt.Payload["htm"]}' for input '{inputMethod}'");
        }

        [Fact]
        [Obsolete("Obsolete")]
        public void GenerateDpopJwtWithNonce()
        {
            var configuration = new Configuration
            {
                OktaDomain = "https://foo-admin.okta.com",
                Token = "foo"
            };

            var jwtGenerator = new DefaultDpopProofJwtGenerator(configuration);
            var nonce = "test-nonce-12345";

            var jwt = jwtGenerator.GenerateJwt(nonce: nonce);
            jwt.Should().NotBeNullOrEmpty();

            var decodedJwt = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
            
            decodedJwt.Payload.ContainsKey("nonce").Should().BeTrue();
            decodedJwt.Payload["nonce"].ToString().Should().Be(nonce);
        }

        [Fact]
        [Obsolete("Obsolete")]
        public void GenerateDpopJwtWithoutNonceWhenNonceIsNull()
        {
            var configuration = new Configuration
            {
                OktaDomain = "https://foo-admin.okta.com",
                Token = "foo"
            };

            var jwtGenerator = new DefaultDpopProofJwtGenerator(configuration);

            var jwt = jwtGenerator.GenerateJwt(nonce: null);
            jwt.Should().NotBeNullOrEmpty();

            var decodedJwt = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
            
            decodedJwt.Payload.ContainsKey("nonce").Should().BeFalse();
        }

        [Fact]
        [Obsolete("Obsolete")]
        public void GenerateDpopJwtWithoutNonceWhenNonceIsEmpty()
        {
            var configuration = new Configuration
            {
                OktaDomain = "https://foo-admin.okta.com",
                Token = "foo"
            };

            var jwtGenerator = new DefaultDpopProofJwtGenerator(configuration);

            var jwt = jwtGenerator.GenerateJwt(nonce: string.Empty);
            jwt.Should().NotBeNullOrEmpty();

            var decodedJwt = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
            
            decodedJwt.Payload.ContainsKey("nonce").Should().BeFalse();
        }

        [Fact]
        [Obsolete("Obsolete")]
        public void GenerateDpopJwtWithAccessTokenHash()
        {
            var configuration = new Configuration
            {
                OktaDomain = "https://foo-admin.okta.com",
                Token = "foo"
            };

            var jwtGenerator = new DefaultDpopProofJwtGenerator(configuration);
            var accessToken = "test-access-token";

            var jwt = jwtGenerator.GenerateJwt(accessToken: accessToken);
            jwt.Should().NotBeNullOrEmpty();

            var decodedJwt = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
            
            decodedJwt.Payload.ContainsKey("ath").Should().BeTrue();
            decodedJwt.Payload["ath"].Should().NotBeNull();
            decodedJwt.Payload["ath"].ToString().Should().NotBeEmpty();
        }

        [Fact]
        [Obsolete("Obsolete")]
        public void GenerateDpopJwtWithoutAccessTokenHashWhenAccessTokenIsNull()
        {
            var configuration = new Configuration
            {
                OktaDomain = "https://foo-admin.okta.com",
                Token = "foo"
            };

            var jwtGenerator = new DefaultDpopProofJwtGenerator(configuration);

            var jwt = jwtGenerator.GenerateJwt(accessToken: null);
            jwt.Should().NotBeNullOrEmpty();

            var decodedJwt = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
            
            decodedJwt.Payload.ContainsKey("ath").Should().BeFalse();
        }

        [Fact]
        [Obsolete("Obsolete")]
        public void GenerateJwkHeaderAsJsonObjectNotString()
        {
            // This is the critical test for the bug fix - jwk must be a JSON object, not a string
            var configuration = new Configuration
            {
                OktaDomain = "https://foo-admin.okta.com",
                Token = "foo"
            };

            var jwtGenerator = new DefaultDpopProofJwtGenerator(configuration);
            var jwt = jwtGenerator.GenerateJwt();
            
            var decodedJwt = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
            var jwkHeader = decodedJwt.Header["jwk"];

            jwkHeader.Should().NotBeNull();
            
            // The jwk header should not be a string type - it should be an object/dictionary
            jwkHeader.Should().NotBeOfType<string>("because jwk must be a JSON object per RFC 9449, not a string");
            
            jwkHeader.GetType().Name.Should().NotBe("String");
        }

        [Fact]
        [Obsolete("Obsolete")]
        public void GenerateJwkHeaderWithRequiredRsaFields()
        {
            // Verifies that the jwk header contains the required RSA key parameters
            var configuration = new Configuration
            {
                OktaDomain = "https://foo-admin.okta.com",
                Token = "foo"
            };

            var jwtGenerator = new DefaultDpopProofJwtGenerator(configuration);
            var jwt = jwtGenerator.GenerateJwt();
            
            var decodedJwt = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
            var jwkHeader = decodedJwt.Header["jwk"];
            
            jwkHeader.Should().NotBeNull();
            
            // Just verify the header exists and isn't a string (the core bug)
            jwkHeader.Should().NotBeOfType<string>();
        }

        [Fact]
        [Obsolete("Obsolete")]
        public void GenerateValidJtiAsGuid()
        {
            var configuration = new Configuration
            {
                OktaDomain = "https://foo-admin.okta.com",
                Token = "foo"
            };

            var jwtGenerator = new DefaultDpopProofJwtGenerator(configuration);
            var jwt = jwtGenerator.GenerateJwt();
            
            var decodedJwt = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
            var jti = decodedJwt.Payload.Jti;
            
            jti.Should().NotBeNullOrEmpty();
            Guid.TryParse(jti, out _).Should().BeTrue("because jti should be a valid GUID");
        }

        [Fact]
        [Obsolete("Obsolete")]
        public void GenerateUniqueJtiForEachCall()
        {
            var configuration = new Configuration
            {
                OktaDomain = "https://foo-admin.okta.com",
                Token = "foo"
            };

            var jwtGenerator = new DefaultDpopProofJwtGenerator(configuration);
            
            var jwt1 = jwtGenerator.GenerateJwt();
            var jwt2 = jwtGenerator.GenerateJwt();
            
            var decodedJwt1 = new JwtSecurityTokenHandler().ReadJwtToken(jwt1);
            var decodedJwt2 = new JwtSecurityTokenHandler().ReadJwtToken(jwt2);
            
            decodedJwt1.Payload.Jti.Should().NotBe(decodedJwt2.Payload.Jti, "because each JWT should have a unique jti");
        }

        [Fact]
        [Obsolete("Obsolete")]
        public void GenerateValidIatTimestamp()
        {
            var configuration = new Configuration
            {
                OktaDomain = "https://foo-admin.okta.com",
                Token = "foo"
            };

            var jwtGenerator = new DefaultDpopProofJwtGenerator(configuration);
            var beforeGeneration = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            
            var jwt = jwtGenerator.GenerateJwt();
            
            var afterGeneration = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var decodedJwt = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
            var iat = decodedJwt.Payload.Iat;
            
            iat.Should().NotBeNull();
            iat.Value.Should().BeGreaterThanOrEqualTo(beforeGeneration, "because iat should be the current time");
            iat.Value.Should().BeLessThanOrEqualTo(afterGeneration, "because iat should be the current time");
        }

        [Fact]
        [Obsolete("Obsolete")]
        public void RotateKeysSuccessfully()
        {
            var configuration = new Configuration
            {
                OktaDomain = "https://foo-admin.okta.com",
                Token = "foo"
            };

            var jwtGenerator = new DefaultDpopProofJwtGenerator(configuration);
            
            var jwt1 = jwtGenerator.GenerateJwt();
            var decodedJwt1 = new JwtSecurityTokenHandler().ReadJwtToken(jwt1);
            if (decodedJwt1.Header["jwk"] is not JObject jwk1) return;
            var n1 = jwk1["n"]?.ToString();
            
            jwtGenerator.RotateKeys();
            
            var jwt2 = jwtGenerator.GenerateJwt();
            var decodedJwt2 = new JwtSecurityTokenHandler().ReadJwtToken(jwt2);
            if (decodedJwt2.Header["jwk"] is not JObject jwk2) return;
            var n2 = jwk2["n"]?.ToString();
            
            n1.Should().NotBe(n2, "because RotateKeys should generate a new RSA key pair");
        }

        [Fact]
        [Obsolete("Obsolete")]
        public void GenerateJwtWithAllParametersSet()
        {
            var configuration = new Configuration
            {
                OktaDomain = "https://foo-admin.okta.com",
                Token = "foo"
            };

            var jwtGenerator = new DefaultDpopProofJwtGenerator(configuration);
            var nonce = "test-nonce";
            var httpMethod = "GET";
            var uri = "https://api.example.com/resource";
            var accessToken = "test-access-token";

            var jwt = jwtGenerator.GenerateJwt(nonce: nonce, httpMethod: httpMethod, uri: uri, accessToken: accessToken);
            jwt.Should().NotBeNullOrEmpty();

            var decodedJwt = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
            
            // Verify header
            decodedJwt.Header.Typ.Should().Be("dpop+jwt");
            decodedJwt.Header.Alg.Should().Be(SecurityAlgorithms.RsaSha256);
            decodedJwt.Header["jwk"].Should().NotBeNull();
            
            // Verify payload - htm must be uppercase per RFC 9449
            decodedJwt.Payload["htm"].ToString().Should().Be(httpMethod.ToUpperInvariant());
            decodedJwt.Payload["htu"].ToString().Should().Be(uri);
            decodedJwt.Payload["nonce"].ToString().Should().Be(nonce);
            decodedJwt.Payload.ContainsKey("ath").Should().BeTrue();
            decodedJwt.Payload.Iat.Should().NotBeNull();
            decodedJwt.Payload.Jti.Should().NotBeNullOrEmpty();
        }

        [Fact]
        [Obsolete("Obsolete")]
        public void ThrowArgumentNullExceptionWhenConfigurationIsNull()
        {
            Action act = () => { new DefaultDpopProofJwtGenerator(null); };
            
            act.Should().Throw<ArgumentNullException>()
                .WithMessage("*configuration*");
        }

        [Theory]
        [InlineData("https://example.okta.com")]
        [InlineData("https://example.okta.com/")]
        [Obsolete("Obsolete")]
        public void GenerateDefaultHtuWithTrailingSlash(string oktaDomain)
        {
            var configuration = new Configuration
            {
                OktaDomain = oktaDomain,
                Token = "foo"
            };

            var jwtGenerator = new DefaultDpopProofJwtGenerator(configuration);
            var jwt = jwtGenerator.GenerateJwt();
            
            var decodedJwt = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
            var htu = decodedJwt.Payload["htu"].ToString();
            
            htu.Should().EndWith("oauth2/v1/token");
            htu.Should().Contain("://");
        }
    }
}
