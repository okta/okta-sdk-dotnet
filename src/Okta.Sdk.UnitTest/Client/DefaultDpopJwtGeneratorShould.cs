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
        public void GenerateRamdonDPoPJWT()
        {
            var configuration = new Configuration();
            configuration.OktaDomain = "https://foo-admin.okta.com";
            configuration.Token = "foo";

            var jwtGenerator = new DefaultDpopProofJwtGenerator(configuration);

            var jwt = jwtGenerator.GenerateJWT();
            jwt.Should().NotBeNullOrEmpty();

            var decodedJWt = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
            
            decodedJWt.Header.Alg.Should().Be(SecurityAlgorithms.RsaSha256);
            decodedJWt.Header.Typ.Should().Be("dpop+jwt");
            decodedJWt.Header["jwk"].Should().NotBeNull();

            decodedJWt.Payload.Iat.Should().NotBeNull();
            decodedJWt.Payload.Jti.Should().NotBeNull();
            decodedJWt.Payload["htm"].ToString().Should().Be("POST");
            decodedJWt.Payload["htu"].ToString().Should()
                .Be($"{ClientUtils.EnsureTrailingSlash(configuration.OktaDomain)}oauth2/v1/token");
        }
    }
}
