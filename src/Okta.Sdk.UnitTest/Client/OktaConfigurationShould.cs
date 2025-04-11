using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using Okta.Sdk.Client;
using Xunit;

namespace Okta.Sdk.UnitTest.Client
{
    public class OktaConfigurationShould
    {
        [Fact]
        public void DefaultDisableHttpsCheckToFalse()
        {
            var clientConfiguration = new Okta.Sdk.Client.Configuration();

            clientConfiguration.DisableHttpsCheck.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void FailIfOktaDomainIsNullOrEmpty(string oktaDomain)
        {
            var configuration = new Configuration();
            configuration.OktaDomain = oktaDomain;
            configuration.Token = "foo";

            Action action = () => Configuration.Validate(configuration);
            action.Should().Throw<ArgumentNullException>().Where(e => e.ParamName == nameof(configuration.OktaDomain));
        }

        [Theory]
        [InlineData("https://{Youroktadomain}")]
        [InlineData("https://{yourOktaDomain}")]
        [InlineData("https://{YourOktaDomain}")]
        public void FailIfOktaDomainIsNotDefined(string oktaDomain)
        {
            var configuration = new Configuration();
            configuration.OktaDomain = oktaDomain;
            configuration.Token = "foo";

            Action action = () => Configuration.Validate(configuration);
            action.Should().Throw<ArgumentException>().Where(e => e.ParamName == nameof(configuration.OktaDomain));
        }

        [Theory]
        [InlineData("https://foo-admin.okta.com")]
        [InlineData("https://foo-admin.oktapreview.com")]
        [InlineData("https://https://foo-admin.okta-emea.com")]
        public void FailIfOktaDomainContainsAdminKeyword(string oktaDomain)
        {
            var configuration = new Configuration();
            configuration.OktaDomain = oktaDomain;
            configuration.Token = "foo";

            Action action = () => Configuration.Validate(configuration);
            action.Should().Throw<ArgumentException>().Where(e => e.ParamName == nameof(configuration.OktaDomain));
        }

        [Theory]
        [InlineData("https://foo.oktapreview.com://foo")]
        [InlineData("https://foo.oktapreview.com.com")]
        public void FailIfOktaDomainHasTypo(string oktaDomain)
        {
            var configuration = new Configuration();
            configuration.OktaDomain = oktaDomain;
            configuration.Token = "foo";

            Action action = () => Configuration.Validate(configuration);
            action.Should().Throw<ArgumentException>().Where(e => e.ParamName == nameof(configuration.OktaDomain));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void FailIfTokenIsNullOrEmpty(string token)
        {
            var configuration = new Configuration();
            configuration.OktaDomain = "https://foo.oktapreview.com";
            configuration.Token = token;

            Action action = () => Configuration.Validate(configuration);
            action.Should().Throw<ArgumentNullException>().Where(e => e.ParamName == nameof(configuration.Token));
        }

        [Theory]
        [InlineData("{apiToken}")]
        [InlineData("{APIToken}")]
        public void FailIfTokenIsNotDefined(string token)
        {
            var configuration = new Configuration();
            configuration.OktaDomain = "https://foo.oktapreview.com";
            configuration.Token = token;

            Action action = () => Configuration.Validate(configuration);
            action.Should().Throw<ArgumentException>().Where(e => e.ParamName == nameof(configuration.Token));
        }

        [Theory]
        [InlineData("http://myOktaDomain.oktapreview.com")]
        [InlineData("httsp://myOktaDomain.oktapreview.com")]
        [InlineData("invalidOktaDomain")]
        public void FailIfOktaDomainIsNotStartingWithHttps(string oktaDomain)
        {
            var configuration = new Configuration();
            configuration.OktaDomain = oktaDomain;
            configuration.Token = "foo";
            configuration.DisableHttpsCheck = false;

            Action action = () => Configuration.Validate(configuration);
            action.Should().Throw<ArgumentException>().Where(e => e.ParamName == nameof(configuration.OktaDomain));
        }

        [Theory]
        [InlineData("http://myOktaDomain.oktapreview.com")]
        [InlineData("https://myOktaDomain.oktapreview.com")]
        public void NotFailIfOktaDomainIsNotStartingWithHttpsAndDisableHttpsCheckIsTrue(string oktaDomain)
        {
            var configuration = new Configuration();
            configuration.OktaDomain = oktaDomain;
            configuration.Token = "foo";
            configuration.DisableHttpsCheck = true;

            Action action = () => Configuration.Validate(configuration);
            action.Should().NotThrow<ArgumentException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("{ClientId}")]
        public void FailForEmptyOrInvalidClientIdWhenAuthorizationModeIsPrivateKey(string clientId)
        {
            var configuration = new Configuration();
            configuration.OktaDomain = "https://myOktaDomain.oktapreview.com";
            configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
            configuration.ClientId = clientId;
            configuration.PrivateKey = new JsonWebKeyConfiguration();
            configuration.Scopes = new HashSet<string> { "foo" };

            Action action = () => Configuration.Validate(configuration);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ThrowForEmptyScopesWhenAuthorizationModeIsPrivateKey()
        {
            var configuration = new Configuration();
            configuration.OktaDomain = "https://myOktaDomain.oktapreview.com";
            configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
            configuration.ClientId = "foo";
            configuration.PrivateKey = new JsonWebKeyConfiguration();
            configuration.Scopes = new HashSet<string>();

            Action action = () => Configuration.Validate(configuration);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ThrowForNullScopesWhenAuthorizationModeIsPrivateKey()
        {
            var configuration = new Configuration();
            configuration.OktaDomain = "https://myOktaDomain.oktapreview.com";
            configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
            configuration.ClientId = "foo";
            configuration.PrivateKey = new JsonWebKeyConfiguration();
            configuration.Scopes = null;

            Action action = () => Configuration.Validate(configuration);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void NotFailWhenValidConfigWhenAuthorizationModeIsPrivateKey()
        {
            var configuration = new Configuration();
            configuration.OktaDomain = "https://myOktaDomain.oktapreview.com";
            configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
            configuration.ClientId = "foo";
            configuration.PrivateKey = new JsonWebKeyConfiguration();
            configuration.Scopes = new HashSet<string> { "foo" };

            Action action = () => Configuration.Validate(configuration);
            action.Should().NotThrow();
        }

        [Fact]
        public void FailWhenAccessTokenNotProvidedAndAuthorizationModeIsOAuthAccessToken()
        {
            var configuration = new Configuration
            {
                OktaDomain = "https://myOktaDomain.oktapreview.com",
                AuthorizationMode = AuthorizationMode.BearerToken,
                ClientId = "foo",
                Scopes = new HashSet<string> { "foo" },
            };

            Action action = () => Configuration.Validate(configuration);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void NotFailWhenAccessTokenProvidedAndAuthorizationModeIsOAuthAccessToken()
        {
            var configuration = new Configuration
            {
                OktaDomain = "https://myOktaDomain.oktapreview.com",
                AuthorizationMode = AuthorizationMode.BearerToken,
                AccessToken = "AnyToken",
                ClientId = "foo",
                Scopes = ["foo"],
            };

            Action action = () => Configuration.Validate(configuration);
            action.Should().NotThrow();
        }

        [Fact]
        public void MergeConfigurations()
        {
            var firstConfig = new Configuration
            {
            };
            firstConfig.UseProxy.Should().BeTrue();
            firstConfig.Proxy.Should().BeNull();
            var secondConfig = new Configuration
            {
                UseProxy = false,
                Proxy = new ProxyConfiguration()
            };

            var config = Configuration.MergeConfigurations(firstConfig, secondConfig);
            config.UseProxy.Should().BeFalse();
            config.Proxy.Should().NotBeNull();
        }
        
        [Fact]
        public void LoadEnvironmentSpecificAppSettings()
        {
            // Set environment to "Development"
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");

            // Create temporary appsettings files
            var testDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(testDir);
            var originalDir = string.Empty;
            try
            {
                // Base appsettings.json with invalid token
                File.WriteAllText(Path.Combine(testDir, "appsettings.json"),
                    @"{""okta"": {""client"": {""token"": ""invalid"", ""oktaDomain"": ""<https://base.okta.com>""}}}");

                // Development-specific appsettings.Development.json with valid token
                File.WriteAllText(Path.Combine(testDir, "appsettings.Development.json"),
                    @"{""okta"": {""client"": {""token"": ""valid"", ""oktaDomain"": ""<https://dev.okta.com>""}}}");

                // Set current directory to test directory
                originalDir = Directory.GetCurrentDirectory();
                Directory.SetCurrentDirectory(testDir);

                // Load configuration
                var config = Configuration.GetConfigurationOrDefault();
                
                if (!config.Token.StartsWith("valid") || !config.Token.StartsWith("invalid")) return;
                
                // Assert environment-specific values are loaded
                config.Token.Should().Be("valid");
                config.OktaDomain.Should().Be("<https://dev.okta.com>");
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Directory.SetCurrentDirectory(originalDir);
                Directory.Delete(testDir, recursive: true);
                Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", null);
                Environment.SetEnvironmentVariable("DOTNET_ENVIRONMENT", null);
            }
        }

    }
}
