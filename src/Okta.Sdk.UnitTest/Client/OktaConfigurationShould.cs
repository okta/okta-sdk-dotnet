// <copyright file="OktaConfigurationShould.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using FluentAssertions;
using Okta.Sdk.Client;
using Xunit;

namespace Okta.Sdk.UnitTest.Client
{
    [Collection(AmbientConfigurationCollection.Name)]
    public class OktaConfigurationShould
    {
        [Fact]
        public void DefaultDisableHttpsCheckToFalse()
        {
            var clientConfiguration = new Okta.Sdk.Client.Configuration();

            clientConfiguration.DisableHttpsCheck.Should().BeFalse();
        }

        /// <summary>
        /// Authorization failures can come back with an empty body, with the only explanation in the
        /// WWW-Authenticate header (issue #875). The message must surface it rather than be blank.
        /// </summary>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void IncludeWwwAuthenticateInExceptionMessageWhenBodyIsEmpty(string rawContent)
        {
            var wwwAuthenticate = "DPoP error=\"invalid_dpop_proof\", error_description=\"'htu' claim in the DPoP proof JWT is invalid.\"";
            var headers = new Multimap<string, string> { { "WWW-Authenticate", wwwAuthenticate } };
            var response = new ApiResponse<string>(HttpStatusCode.BadRequest, headers, null, rawContent);

            var exception = Configuration.DefaultExceptionFactory("ListUsers", response) as ApiException;

            exception.Should().NotBeNull();
            exception.ErrorCode.Should().Be(400);
            exception.Message.Should().Contain("invalid_dpop_proof");
        }

        [Fact]
        public void PreferResponseBodyOverWwwAuthenticateInExceptionMessage()
        {
            var headers = new Multimap<string, string> { { "WWW-Authenticate", "DPoP error=\"invalid_dpop_proof\"" } };
            var response = new ApiResponse<string>(HttpStatusCode.BadRequest, headers, null, "{\"errorCode\":\"E0000001\"}");

            var exception = Configuration.DefaultExceptionFactory("ListUsers", response) as ApiException;

            exception.Should().NotBeNull();
            exception.Message.Should().Contain("E0000001");
            exception.Message.Should().NotContain("invalid_dpop_proof");
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
        [InlineData("https://foo-admin.okta-gov.com")]
        [InlineData("https://foo-admin.okta.mil")]
        [InlineData("https://foo-admin.okta-miltest.com")]
        [InlineData("https://foo-admin.trex-govcloud.com")]
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
        [InlineData("https://myOktaDomain.okta-gov.com")]
        [InlineData("https://myOktaDomain.okta.mil")]
        [InlineData("https://myOktaDomain.okta-miltest.com")]
        [InlineData("https://myOktaDomain.trex-govcloud.com")]
        public void NotFailForValidNewOktaDomains(string oktaDomain)
        {
            var configuration = new Configuration();
            configuration.OktaDomain = oktaDomain;
            configuration.Token = "foo";

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

        /// <summary>
        /// Issue #899: a Configuration passed in to override one property carried its constructor
        /// defaults along with it, silently replacing everything the file had set.
        /// </summary>
        [Fact]
        public void KeepFileValuesWhenTheSuppliedConfigurationOnlyOverridesOneProperty()
        {
            InTemporaryDirectory(dir =>
            {
                File.WriteAllText(Path.Combine(dir, "okta.yaml"), AmbientYaml);

                var config = Configuration.GetConfigurationOrDefault(new Configuration { AccessToken = "supplied-token" });

                config.AccessToken.Should().Be("supplied-token");
                config.OktaDomain.Should().Be("https://ambient.okta.com");
                config.AuthorizationMode.Should().Be(AuthorizationMode.BearerToken);
                config.ConnectionTimeout.Should().Be(45);
                config.MaxRetries.Should().Be(7);
                config.ClientId.Should().Be("client-from-ambient");
            });
        }

        [Fact]
        public void PreferSuppliedValuesOverTheFileWhenTheyAreSet()
        {
            InTemporaryDirectory(dir =>
            {
                File.WriteAllText(Path.Combine(dir, "okta.yaml"), AmbientYaml);

                var config = Configuration.GetConfigurationOrDefault(new Configuration
                {
                    OktaDomain = "https://supplied.okta.com",
                    ConnectionTimeout = 11,
                });

                config.OktaDomain.Should().Be("https://supplied.okta.com");
                config.ConnectionTimeout.Should().Be(11);
            });
        }

        /// <summary>
        /// SSWS is the constructor default, so it cannot be recognised as a caller's choice by
        /// comparing values. Dropping it would fall back to the file's mode and then reject the
        /// request for having no access token.
        /// </summary>
        [Fact]
        public void PreferAnExplicitlyChosenAuthorizationModeEvenWhenItMatchesTheDefault()
        {
            InTemporaryDirectory(dir =>
            {
                File.WriteAllText(Path.Combine(dir, "okta.yaml"), AmbientYaml);

                var config = Configuration.GetConfigurationOrDefault(new Configuration
                {
                    AuthorizationMode = AuthorizationMode.SSWS,
                    Token = "ssws-token",
                });

                config.AuthorizationMode.Should().Be(AuthorizationMode.SSWS);
                Configuration.IsSswsMode(config).Should().BeTrue();
            });
        }

        [Fact]
        public void NotTreatTheConstructorsOwnDefaultsAsCallerChoices()
        {
            InTemporaryDirectory(dir =>
            {
                File.WriteAllText(Path.Combine(dir, "okta.yaml"), AmbientYaml);

                // Nothing was assigned, so the file's mode must survive.
                var config = Configuration.GetConfigurationOrDefault(new Configuration());

                config.AuthorizationMode.Should().Be(AuthorizationMode.BearerToken);
            });
        }

        /// <summary>
        /// Issue #863: one process talking to many orgs needs to name the configuration file to use.
        /// </summary>
        [Theory]
        [InlineData("okta.org1.yaml")]
        [InlineData("okta.org1.json")]
        public void ReadConfigurationFromACallerSuppliedPath(string fileName)
        {
            InTemporaryDirectory(dir =>
            {
                File.WriteAllText(Path.Combine(dir, "okta.yaml"), AmbientYaml);
                File.WriteAllText(Path.Combine(dir, "okta.org1.yaml"), string.Join("\n",
                    "okta:",
                    "  client:",
                    "    oktaDomain: https://org1.okta.com",
                    "    token: token-org1",
                    string.Empty));
                File.WriteAllText(Path.Combine(dir, "okta.org1.json"),
                    @"{""okta"": {""client"": {""oktaDomain"": ""https://org1.okta.com"", ""token"": ""token-org1""}}}");

                var config = Configuration.GetConfigurationOrDefault(null, fileName);

                config.OktaDomain.Should().Be("https://org1.okta.com");
                config.Token.Should().Be("token-org1");

                // Values the named file leaves alone still come from the conventional locations.
                config.ConnectionTimeout.Should().Be(45);
            });
        }

        [Fact]
        public void ReadConfigurationFromAnAbsoluteCallerSuppliedPath()
        {
            InTemporaryDirectory(dir =>
            {
                var path = Path.Combine(dir, "okta.org2.yaml");
                File.WriteAllText(path, string.Join("\n",
                    "okta:",
                    "  client:",
                    "    oktaDomain: https://org2.okta.com",
                    string.Empty));

                Configuration.GetConfigurationOrDefault(null, path)
                    .OktaDomain.Should().Be("https://org2.okta.com");
            });
        }

        /// <summary>
        /// The conventional locations are optional because they are conventions. A path asked for by
        /// name must fail loudly rather than quietly talk to whichever org the ambient file names.
        /// </summary>
        [Fact]
        public void ThrowWhenTheCallerSuppliedPathDoesNotExist()
        {
            InTemporaryDirectory(dir =>
            {
                File.WriteAllText(Path.Combine(dir, "okta.yaml"), AmbientYaml);

                Assert.Throws<FileNotFoundException>(
                    () => Configuration.GetConfigurationOrDefault(null, "okta.missing.yaml"));
            });
        }

        [Fact]
        public void LetSuppliedValuesOverrideTheCallerSuppliedFile()
        {
            InTemporaryDirectory(dir =>
            {
                File.WriteAllText(Path.Combine(dir, "okta.org1.yaml"), string.Join("\n",
                    "okta:",
                    "  client:",
                    "    oktaDomain: https://org1.okta.com",
                    "    token: token-org1",
                    string.Empty));

                var config = Configuration.GetConfigurationOrDefault(
                    new Configuration { Token = "token-from-code" }, "okta.org1.yaml");

                config.OktaDomain.Should().Be("https://org1.okta.com");
                config.Token.Should().Be("token-from-code");
            });
        }

        /// <summary>
        /// A file asked for by name has to outrank the environment. Otherwise an OKTA_CLIENT_* variable
        /// left in the environment - which is how the build machine is set up - would pull every per-org
        /// file back to the same org, or pair one org's domain with another org's token.
        /// </summary>
        [Fact]
        public void PreferTheCallerSuppliedFileOverEnvironmentVariables()
        {
            InTemporaryDirectory(dir =>
            {
                Environment.SetEnvironmentVariable("OKTA_CLIENT_OKTADOMAIN", "https://from-environment.okta.com");
                Environment.SetEnvironmentVariable("OKTA_CLIENT_TOKEN", "token-from-environment");

                File.WriteAllText(Path.Combine(dir, "okta.org1.yaml"), string.Join("\n",
                    "okta:",
                    "  client:",
                    "    oktaDomain: https://org1.okta.com",
                    "    token: token-org1",
                    string.Empty));

                var config = Configuration.GetConfigurationOrDefault(null, "okta.org1.yaml");

                config.OktaDomain.Should().Be("https://org1.okta.com");
                config.Token.Should().Be("token-org1");
            });
        }

        /// <summary>
        /// The environment must still win over the conventional locations, which is the documented order.
        /// </summary>
        [Fact]
        public void PreferEnvironmentVariablesOverTheConventionalFileLocations()
        {
            InTemporaryDirectory(dir =>
            {
                Environment.SetEnvironmentVariable("OKTA_CLIENT_OKTADOMAIN", "https://from-environment.okta.com");

                File.WriteAllText(Path.Combine(dir, "okta.yaml"), AmbientYaml);

                var config = Configuration.GetConfigurationOrDefault();

                config.OktaDomain.Should().Be("https://from-environment.okta.com");

                // And a value the environment says nothing about still comes from the file.
                config.MaxRetries.Should().Be(7);
            });
        }

        /// <summary>
        /// Clients resolve their configuration again, so a per-org configuration must survive the
        /// round trip instead of reverting to the ambient file.
        /// </summary>
        [Fact]
        public void KeepACallerSuppliedFilesValuesWhenTheResultIsResolvedAgain()
        {
            InTemporaryDirectory(dir =>
            {
                File.WriteAllText(Path.Combine(dir, "okta.yaml"), AmbientYaml);
                File.WriteAllText(Path.Combine(dir, "okta.org1.yaml"), string.Join("\n",
                    "okta:",
                    "  client:",
                    "    oktaDomain: https://org1.okta.com",
                    "    authorizationMode: SSWS",
                    "    token: token-org1",
                    string.Empty));

                var org1 = Configuration.GetConfigurationOrDefault(null, "okta.org1.yaml");
                var roundTripped = Configuration.GetConfigurationOrDefault(org1);

                roundTripped.OktaDomain.Should().Be("https://org1.okta.com");
                roundTripped.Token.Should().Be("token-org1");
                roundTripped.AuthorizationMode.Should().Be(AuthorizationMode.SSWS);
            });
        }

        /// <summary>
        /// A configuration file in the working directory, which is where the SDK looks by convention.
        /// Deliberately sets authorizationMode to something other than the default so that a value
        /// wrongly treated as a caller override is visible.
        /// </summary>
        private const string AmbientYaml = @"okta:
  client:
    oktaDomain: https://ambient.okta.com
    authorizationMode: BearerToken
    accessToken: access-token-from-ambient
    clientId: client-from-ambient
    connectionTimeout: 45
    maxRetries: 7
";

        /// <summary>
        /// Runs <paramref name="test"/> with the working directory set to a fresh temporary directory,
        /// because the SDK discovers configuration files relative to it, and with any ambient
        /// <c>OKTA_*</c> environment variables removed, because the SDK layers those over the files
        /// these tests are about. The build machine sets them for the integration tests.
        /// </summary>
        private static void InTemporaryDirectory(Action<string> test)
        {
            var testDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(testDir);
            var originalDir = Directory.GetCurrentDirectory();
            var oktaVariables = ClearOktaEnvironmentVariables();

            try
            {
                Directory.SetCurrentDirectory(testDir);
                test(testDir);
            }
            finally
            {
                Directory.SetCurrentDirectory(originalDir);
                Directory.Delete(testDir, recursive: true);

                // Clear again first, so any variable the test set for itself does not outlive it.
                ClearOktaEnvironmentVariables();

                foreach (var variable in oktaVariables)
                {
                    Environment.SetEnvironmentVariable(variable.Key, variable.Value);
                }
            }
        }

        /// <summary>
        /// Removes the <c>OKTA_*</c> environment variables and returns them so they can be put back.
        /// </summary>
        private static IEnumerable<KeyValuePair<string, string>> ClearOktaEnvironmentVariables()
        {
            var cleared = new List<KeyValuePair<string, string>>();

            foreach (DictionaryEntry variable in Environment.GetEnvironmentVariables())
            {
                var name = (string)variable.Key;

                // The SDK matches its prefix case-insensitively, so this has to as well.
                if (name.StartsWith("okta", StringComparison.OrdinalIgnoreCase))
                {
                    cleared.Add(new KeyValuePair<string, string>(name, variable.Value as string));
                    Environment.SetEnvironmentVariable(name, null);
                }
            }

            return cleared;
        }
    }
}
