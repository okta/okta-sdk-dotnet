using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Xunit;

namespace Okta.Sdk.UnitTest.Api;

public class OktaApiClientOptionsShould
{
    [Fact(Skip = "TODO")]
    public Task UseDefaultConfiguration()
    {
        var forComparison = Configuration.GetConfigurationOrDefault();

        var (userApi, groupApi, applicationApi) = OktaApiClientOptions
            .UseDefaultConfiguration()
            .BuildApis<UserApi, GroupApi, ApplicationApi>();

        userApi.Configuration.OktaDomain.Should().BeEquivalentTo(forComparison.OktaDomain);
        userApi.Configuration.Token.Should().BeEquivalentTo(forComparison.Token);
        
        groupApi.Configuration.OktaDomain.Should().BeEquivalentTo(forComparison.OktaDomain);
        groupApi.Configuration.Token.Should().BeEquivalentTo(forComparison.Token);
        
        applicationApi.Configuration.OktaDomain.Should().BeEquivalentTo(forComparison.OktaDomain);
        applicationApi.Configuration.Token.Should().BeEquivalentTo(forComparison.Token);
        return Task.CompletedTask;
    }

    [Fact]
    public Task UseSpecifiedConfiguration()
    {
        const string testDomain = "https://my.test.domain.com";
        const string testToken = "my.test.token";

        var testConfiguration = new Configuration()
        {
            OktaDomain = testDomain,
            Token = testToken,
            PrivateKey = GeneratePrivateKey()
        };

        var (userApi, groupApi, applicationApi) = OktaApiClientOptions
            .UseConfiguration((_ => testConfiguration))
            .BuildApis<UserApi, GroupApi, ApplicationApi>();

        userApi.Configuration.OktaDomain.Should().BeEquivalentTo(testDomain);
        userApi.Configuration.Token.Should().BeEquivalentTo(testToken);
        
        groupApi.Configuration.OktaDomain.Should().BeEquivalentTo(testDomain);
        groupApi.Configuration.Token.Should().BeEquivalentTo(testToken);
        
        applicationApi.Configuration.OktaDomain.Should().BeEquivalentTo(testDomain);
        applicationApi.Configuration.Token.Should().BeEquivalentTo(testToken);
        return Task.CompletedTask;
    }

    [Fact]
    public Task UseConfigurationLoader()
    {
        const string testDomain = "https://my.test.domain.com";
        const string testToken = "my.test.token";

        var testConfiguration = new Configuration
        {
            OktaDomain = testDomain,
            Token = testToken,
            PrivateKey = GeneratePrivateKey()
        };

        var (userApi, groupApi, applicationApi) = OktaApiClientOptions
            .UseConfiguration((_ => testConfiguration))
            .BuildApis<UserApi, GroupApi, ApplicationApi>();

        userApi.Configuration.OktaDomain.Should().BeEquivalentTo(testDomain);
        userApi.Configuration.Token.Should().BeEquivalentTo(testToken);

        groupApi.Configuration.OktaDomain.Should().BeEquivalentTo(testDomain);
        groupApi.Configuration.Token.Should().BeEquivalentTo(testToken);

        applicationApi.Configuration.OktaDomain.Should().BeEquivalentTo(testDomain);
        applicationApi.Configuration.Token.Should().BeEquivalentTo(testToken);
        return Task.CompletedTask;
    }

    private static JsonWebKeyConfiguration GeneratePrivateKey()
    {
        using var rsa = new RSACryptoServiceProvider(2048);
        var rsaParameters = rsa.ExportParameters(true);

        return new JsonWebKeyConfiguration
        {
            Kty = "RSA",
            N = Convert.ToBase64String(rsaParameters.Modulus), // RSA modulus
            E = Convert.ToBase64String(rsaParameters.Exponent), // RSA public exponent
            D = Convert.ToBase64String(rsaParameters.D), // RSA private exponent
            P = Convert.ToBase64String(rsaParameters.P), // RSA secret prime P
            Q = Convert.ToBase64String(rsaParameters.Q), // RSA secret prime Q
            Dp = Convert.ToBase64String(rsaParameters.DP), // RSA exponent DP
            Dq = Convert.ToBase64String(rsaParameters.DQ), // RSA exponent DQ
            Qi = Convert.ToBase64String(rsaParameters.InverseQ) // RSA coefficient Q^-1
        };
    }
}