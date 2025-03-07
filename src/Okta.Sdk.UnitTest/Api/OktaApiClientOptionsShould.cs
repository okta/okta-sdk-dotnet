using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Okta.Sdk.UnitTest.Internal;
using Xunit;

namespace Okta.Sdk.UnitTest.Api;

public class OktaApiClientOptionsShould
{
    [Fact]
    public async Task UseDefaultConfiguration()
    {
        Configuration forComparison = Configuration.GetConfigurationOrDefault();
        (UserApi userApi, GroupApi groupApi, ApplicationApi applicationApi) = OktaApiClientOptions
            .UseDefaultConfiguration()
            .BuildApis<UserApi, GroupApi, ApplicationApi>();

        userApi.Configuration.OktaDomain.Should().BeEquivalentTo(forComparison.OktaDomain);
        userApi.Configuration.Token.Should().BeEquivalentTo(forComparison.Token);
        
        groupApi.Configuration.OktaDomain.Should().BeEquivalentTo(forComparison.OktaDomain);
        groupApi.Configuration.Token.Should().BeEquivalentTo(forComparison.Token);
        
        applicationApi.Configuration.OktaDomain.Should().BeEquivalentTo(forComparison.OktaDomain);
        applicationApi.Configuration.Token.Should().BeEquivalentTo(forComparison.Token);
    }

    [Fact]
    public async Task UseSpecifiedConfiguration()
    {
        string testDomain = "https://my.test.domain.com";
        string testToken = "my.test.token";

        Configuration testConfiguration = new Configuration()
        {
            OktaDomain = testDomain,
            Token = testToken
        };

        (UserApi userApi, GroupApi groupApi, ApplicationApi applicationApi) = OktaApiClientOptions
            .UseConfiguration(testConfiguration)
            .BuildApis<UserApi, GroupApi, ApplicationApi>();

        userApi.Configuration.OktaDomain.Should().BeEquivalentTo(testDomain);
        userApi.Configuration.Token.Should().BeEquivalentTo(testToken);
        
        groupApi.Configuration.OktaDomain.Should().BeEquivalentTo(testDomain);
        groupApi.Configuration.Token.Should().BeEquivalentTo(testToken);
        
        applicationApi.Configuration.OktaDomain.Should().BeEquivalentTo(testDomain);
        applicationApi.Configuration.Token.Should().BeEquivalentTo(testToken);
    }
    
    [Fact]
    public async Task UseConfigurationLoader()
    {
        string testDomain = "https://my.test.domain.com";
        string testToken = "my.test.token";

        Configuration testConfiguration = new Configuration()
        {
            OktaDomain = testDomain,
            Token = testToken
        };

        (UserApi userApi, GroupApi groupApi, ApplicationApi applicationApi) = OktaApiClientOptions
            .UseConfiguration((_ => testConfiguration))
            .BuildApis<UserApi, GroupApi, ApplicationApi>();

        userApi.Configuration.OktaDomain.Should().BeEquivalentTo(testDomain);
        userApi.Configuration.Token.Should().BeEquivalentTo(testToken);
        
        groupApi.Configuration.OktaDomain.Should().BeEquivalentTo(testDomain);
        groupApi.Configuration.Token.Should().BeEquivalentTo(testToken);
        
        applicationApi.Configuration.OktaDomain.Should().BeEquivalentTo(testDomain);
        applicationApi.Configuration.Token.Should().BeEquivalentTo(testToken);
    }
}