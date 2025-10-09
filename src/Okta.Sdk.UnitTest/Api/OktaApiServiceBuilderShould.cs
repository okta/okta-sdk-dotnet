// using System;
// using System.Net;
// using System.Net.Http;
// using System.Threading.Tasks;
// using FluentAssertions;
// using NSubstitute;
// using Okta.Sdk.Api;
// using Okta.Sdk.Client;
// using Okta.Sdk.Model;
// using Okta.Sdk.UnitTest.Internal;
// using RestSharp.Interceptors;
// using Xunit;
// using Moq;
//
// namespace Okta.Sdk.UnitTest.Api;
//
// public class OktaApiServiceBuilderShould
// {
//     [Fact]
//     public Task UseApiClientOptions()
//     {
//         const string testDomain = "https://my.test.domain.com";
//         const string testToken = "my.test.token";
//
//         var testConfiguration = new Configuration()
//         {
//             OktaDomain = testDomain,
//             Token = testToken
//         };
//
//         var userApi = OktaApiServiceBuilder
//             .UseApiClientOptions(new OktaApiClientOptions(testConfiguration, httpMessageHandler: new TestHttpMessageHandler(new HttpResponseMessage())))
//             .BuildApi<UserApi>();
//
//         userApi.Configuration.OktaDomain.Should().BeEquivalentTo(testConfiguration.OktaDomain);
//         userApi.Configuration.Token.Should().BeEquivalentTo(testConfiguration.Token);
//         return Task.CompletedTask;
//     }
//     
//     [Fact]
//     public async Task UseHttpMessageHandler()
//     {
//         const string testDomain = "https://my.test.domain.com";
//         const string testToken = "my.test.token";
//
//         var testConfiguration = new Configuration()
//         {
//             OktaDomain = testDomain,
//             Token = testToken
//         };
//
//         var testHttpMessageHandler = new TestHttpMessageHandler(new HttpResponseMessage());
//         testHttpMessageHandler.ReceivedCall.Should().BeFalse();
//         testHttpMessageHandler.ReceivedRequestMessage.Should().BeNull();
//         
//         var userApi = OktaApiServiceBuilder
//             .UseApiClientOptions(new OktaApiClientOptions(testConfiguration))
//             .UseHttpMessageHandler(testHttpMessageHandler)
//             .BuildApi<UserApi>();
//
//         await userApi.CreateUserAsync(new CreateUserRequest());
//         
//         testHttpMessageHandler.ReceivedCall.Should().BeTrue();
//         testHttpMessageHandler.ReceivedRequestMessage.Should().NotBeNull();
//     }
//
//     [Fact]
//     public Task UseInterceptors()
//     {
//         var options = OktaApiServiceBuilder
//             .UseApiClientOptions(new OktaApiClientOptions(Configuration.GetConfigurationOrDefault()))
//             .For<SubDependency>().Use<SubDependency>()
//             .For<IMockDependency>().Use<MockDependency>()
//             .UseInterceptor<MockInterceptor>()
//             .UseInterceptors(Substitute.For<Interceptor>(), Substitute.For<Interceptor>())
//             .GetOktaApiClientOptions();
//
//         options.Interceptors.Count.Should().Be(3);
//         return Task.CompletedTask;
//     }
//
//     [Fact]
//     public Task UseWebProxy()
//     {
//         var webProxy = new WebProxy(new Uri("https://my.webproxy.fake"));
//         
//         var options = OktaApiServiceBuilder
//             .UseApiClientOptions(new OktaApiClientOptions(Configuration.GetConfigurationOrDefault()))
//             .UseWebProxy(webProxy)
//             .GetOktaApiClientOptions();
//
//         options.WebProxy.Should().Be(webProxy);
//         return Task.CompletedTask;
//     }
//     
//     [Fact]
//     public Task UseOAuthTokenProvider()
//     {
//         var tokenProvider = Substitute.For<IOAuthTokenProvider>();
//         
//         var options = OktaApiServiceBuilder
//             .UseApiClientOptions(new OktaApiClientOptions(Configuration.GetConfigurationOrDefault()))
//             .UseOAuthTokenProvider(tokenProvider)
//             .GetOktaApiClientOptions();
//
//         options.OAuthTokenProvider.Should().Be(tokenProvider);
//         return Task.CompletedTask;
//     }
//
//     [Fact]
//     public Task UseGenericDependency()
//     {
//         var options = OktaApiServiceBuilder
//             .UseApiClientOptions(new OktaApiClientOptions(Configuration.GetConfigurationOrDefault()))
//             .For<SubDependency>().Use<SubDependency>()
//             .For<IMockDependency>().Use<MockDependency>()
//             .UseInterceptor<MockInterceptor>()
//             .GetOktaApiClientOptions();
//
//         options.Interceptors.Count.Should().Be(1);
//         options.Interceptors[0].Should().BeOfType(typeof(MockInterceptor));
//         var mockInterceptor = (MockInterceptor)options.Interceptors[0];
//         mockInterceptor.MockDependency.Should().BeOfType(typeof(MockDependency));
//         var mockDependency = (MockDependency)mockInterceptor.MockDependency;
//         mockDependency.SubDependency.Should().NotBeNull();
//         return Task.CompletedTask;
//     }
// }