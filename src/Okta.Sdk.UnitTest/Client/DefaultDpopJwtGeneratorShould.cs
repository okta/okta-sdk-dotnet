using System;
using System.IdentityModel.Tokens.Jwt;
using FluentAssertions;
using Microsoft.IdentityModel.Tokens;
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
        [InlineData("POST", "http://foo.com/resource", "foo")]
        [InlineData("PUT", "http://foo.com/resource/1", "bar")]
        [InlineData("DELETE", "http://foo.com", "baz")]
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
            decodedJwt.Payload["htm"].ToString().Should().Be(httpMethod);
            decodedJwt.Payload["htu"].ToString().Should()
                .Be(uri);
            decodedJwt.Payload["ath"].Should().NotBeNull();
        }
    }
}
