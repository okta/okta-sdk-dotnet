using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.IdentityModel.Tokens;
using Okta.Sdk.Client;
using Okta.Sdk.UnitTest.Internal;
using RestSharp;
using RichardSzalay.MockHttp;
using Xunit;
using Xunit.Abstractions;


namespace Okta.Sdk.UnitTest.Client
{
    public class DefaultDpopJwtGeneratorShould
    {
        [Fact]
        public void GenerateDefaultDpopJwt()
        {
            var configuration = new Configuration();
            configuration.OktaDomain = "https://foo-admin.okta.com";
            configuration.Token = "foo";

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
        public void GenerateDpopJwtWithParams(string httpMethod, string uri, string accessToken)
        {
            var configuration = new Configuration();
            configuration.OktaDomain = "https://foo-admin.okta.com";
            configuration.Token = "foo";

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
