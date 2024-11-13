using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NSubstitute;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Okta.Sdk.UnitTest.Internal;
using RestSharp.Interceptors;
using Xunit;

namespace Okta.Sdk.UnitTest.Api;

public class OktaApiServiceBuilderShould
{
    [Fact]
    public async Task UseApiClientOptions()
    {
        string testDomain = "https://my.test.domain.com";
        string testToken = "my.test.token";

        Configuration testConfiguration = new Configuration()
        {
            OktaDomain = testDomain,
            Token = testToken
        };

        UserApi userApi = OktaApiServiceBuilder
            .UseApiClientOptions(new OktaApiClientOptions(testConfiguration, httpMessageHandler: new TestHttpMessageHandler(new HttpResponseMessage())))
            .BuildApi<UserApi>();

        userApi.Configuration.OktaDomain.Should().BeEquivalentTo(testConfiguration.OktaDomain);
        userApi.Configuration.Token.Should().BeEquivalentTo(testConfiguration.Token);
    }
    
    [Fact]
    public async Task UseHttpMessageHandler()
    {
        string testDomain = "https://my.test.domain.com";
        string testToken = "my.test.token";

        Configuration testConfiguration = new Configuration()
        {
            OktaDomain = testDomain,
            Token = testToken
        };

        TestHttpMessageHandler testHttpMessageHandler = new TestHttpMessageHandler(new HttpResponseMessage());
        testHttpMessageHandler.ReceivedCall.Should().BeFalse();
        testHttpMessageHandler.ReceivedRequestMessage.Should().BeNull();
        
        UserApi userApi = OktaApiServiceBuilder
            .UseApiClientOptions(new OktaApiClientOptions(testConfiguration))
            .UseHttpMessageHandler(testHttpMessageHandler)
            .BuildApi<UserApi>();

        await userApi.CreateUserAsync(new CreateUserRequest());
        
        testHttpMessageHandler.ReceivedCall.Should().BeTrue();
        testHttpMessageHandler.ReceivedRequestMessage.Should().NotBeNull();
    }

    [Fact]
    public async Task UseWebProxy()
    {
        WebProxy webProxy = new WebProxy(new Uri("https://my.webproxy.fake"));
        
        OktaApiClientOptions options = OktaApiServiceBuilder
            .UseApiClientOptions(new OktaApiClientOptions(Configuration.GetConfigurationOrDefault()))
            .UseWebProxy(webProxy)
            .GetOktaApiClientOptions();

        options.WebProxy.Should().Be(webProxy);
    }
    
    [Fact]
    public async Task UseOAuthTokenProvider()
    {
        IOAuthTokenProvider tokenProvider = Substitute.For<IOAuthTokenProvider>();
        
        OktaApiClientOptions options = OktaApiServiceBuilder
            .UseApiClientOptions(new OktaApiClientOptions(Configuration.GetConfigurationOrDefault()))
            .UseOAuthTokenProvider(tokenProvider)
            .GetOktaApiClientOptions();

        options.OAuthTokenProvider.Should().Be(tokenProvider);
    }
    
    [Fact]
    public async Task UseInterceptors()
    {
        OktaApiClientOptions options = OktaApiServiceBuilder
            .UseApiClientOptions(new OktaApiClientOptions(Configuration.GetConfigurationOrDefault()))
            .For<SubDependency>().Use<SubDependency>()
            .For<IMockDependency>().Use<MockDependency>()
            .UseInterceptor<MockInterceptor>()
            .UseInterceptors(Substitute.For<Interceptor>(), Substitute.For<Interceptor>())
            .GetOktaApiClientOptions();

        options.Interceptors.Count.Should().Be(3);
    }

    [Fact]
    public async Task UseGenericDependency()
    {
        OktaApiClientOptions options = OktaApiServiceBuilder
            .UseApiClientOptions(new OktaApiClientOptions(Configuration.GetConfigurationOrDefault()))
            .For<SubDependency>().Use<SubDependency>()
            .For<IMockDependency>().Use<MockDependency>()
            .UseInterceptor<MockInterceptor>()
            .GetOktaApiClientOptions();

        options.Interceptors.Count.Should().Be(1);
        options.Interceptors[0].Should().BeOfType(typeof(MockInterceptor));
        MockInterceptor mockInterceptor = (MockInterceptor)options.Interceptors[0];
        mockInterceptor.MockDependency.Should().BeOfType(typeof(MockDependency));
        MockDependency mockDependency = (MockDependency)mockInterceptor.MockDependency;
        mockDependency.SubDependency.Should().NotBeNull();
    }
}