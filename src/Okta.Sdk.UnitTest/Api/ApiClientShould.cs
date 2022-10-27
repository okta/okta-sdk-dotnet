using System;
using System.Linq;
using System.Net;
using Xunit;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.UnitTest.Internal;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using RestSharp;

namespace Okta.Sdk.UnitTest.Api
{
    public class ApiClientShould
    {
        [Fact]
        public void SendUserAgent()
        {

            var apiClient = new ApiClient();
            var client = apiClient.GetConfiguredClient(new Configuration(), null);

            client.UserAgent.Should().Contain("okta-sdk-dotnet");
        }

        [Fact]
        public void UseProxySetViaConfiguration()
        {

            var apiClient = new ApiClient();
            var configuration = new Configuration
            {
                Proxy = new ProxyConfiguration
                {
                    Host = "foo.com",
                    Port = 8081,
                    Username = "bar",
                    Password = "baz"

                }
            };

            var client = apiClient.GetConfiguredClient(configuration, null);
            client.Proxy.Should().NotBeNull();

            var webProxy = (WebProxy)client.Proxy;
            webProxy.Address.ToString().Should().Be("http://foo.com:8081/");
            webProxy.Credentials.Should().NotBeNull();

            ((NetworkCredential)webProxy.Credentials).UserName.Should().Be("bar");
            ((NetworkCredential)webProxy.Credentials).Password.Should().Be("baz");
        }

        [Fact]
        public void UseProxySetViaConstructor()
        {
            var proxy = new WebProxy("foo.com", 8081);
            proxy.Credentials = new NetworkCredential("bar", "baz");
            
            var apiClient = new ApiClient(webProxy: proxy);

            var client = apiClient.GetConfiguredClient(new Configuration(), null);
            client.Proxy.Should().NotBeNull();

            var webProxy = (WebProxy)client.Proxy;
            webProxy.Address.ToString().Should().Be("http://foo.com:8081/");
            webProxy.Credentials.Should().NotBeNull();

            ((NetworkCredential)webProxy.Credentials).UserName.Should().Be("bar");
            ((NetworkCredential)webProxy.Credentials).Password.Should().Be("baz");
        }
    }
}
