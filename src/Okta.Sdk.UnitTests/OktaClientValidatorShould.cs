// <copyright file="OktaClientValidatorShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using FluentAssertions;
using Okta.Sdk.Configuration;
using Okta.Sdk.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class OktaClientValidatorShould
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void FailIfOktaDomainIsNullOrEmpty(string oktaDomain)
        {
            var configuration = new OktaClientConfiguration();
            configuration.OktaDomain = oktaDomain;
            configuration.Token = "foo";

            Action action = () => OktaClientConfigurationValidator.Validate(configuration);
            action.Should().Throw<ArgumentNullException>().Where(e => e.ParamName == nameof(configuration.OktaDomain));
        }

        [Theory]
        [InlineData("https://{Youroktadomain}")]
        [InlineData("https://{yourOktaDomain}")]
        [InlineData("https://{YourOktaDomain}")]
        public void FailIfOktaDomainIsNotDefined(string oktaDomain)
        {
            var configuration = new OktaClientConfiguration();
            configuration.OktaDomain = oktaDomain;
            configuration.Token = "foo";

            Action action = () => OktaClientConfigurationValidator.Validate(configuration);
            action.Should().Throw<ArgumentException>().Where(e => e.ParamName == nameof(configuration.OktaDomain));
        }

        [Theory]
        [InlineData("https://foo-admin.okta.com")]
        [InlineData("https://foo-admin.oktapreview.com")]
        [InlineData("https://https://foo-admin.okta-emea.com")]
        public void FailIfOktaDomainContainsAdminKeyword(string oktaDomain)
        {
            var configuration = new OktaClientConfiguration();
            configuration.OktaDomain = oktaDomain;
            configuration.Token = "foo";

            Action action = () => OktaClientConfigurationValidator.Validate(configuration);
            action.Should().Throw<ArgumentException>().Where(e => e.ParamName == nameof(configuration.OktaDomain));
        }

        [Theory]
        [InlineData("https://foo.oktapreview.com://foo")]
        [InlineData("https://foo.oktapreview.com.com")]
        public void FailIfOktaDomainHasTypo(string oktaDomain)
        {
            var configuration = new OktaClientConfiguration();
            configuration.OktaDomain = oktaDomain;
            configuration.Token = "foo";

            Action action = () => OktaClientConfigurationValidator.Validate(configuration);
            action.Should().Throw<ArgumentException>().Where(e => e.ParamName == nameof(configuration.OktaDomain));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void FailIfTokenIsNullOrEmpty(string token)
        {
            var configuration = new OktaClientConfiguration();
            configuration.OktaDomain = "https://foo.oktapreview.com";
            configuration.Token = token;

            Action action = () => OktaClientConfigurationValidator.Validate(configuration);
            action.Should().Throw<ArgumentNullException>().Where(e => e.ParamName == nameof(configuration.Token));
        }

        [Theory]
        [InlineData("{apiToken}")]
        [InlineData("{APIToken}")]
        public void FailIfTokenIsNotDefined(string token)
        {
            var configuration = new OktaClientConfiguration();
            configuration.OktaDomain = "https://foo.oktapreview.com";
            configuration.Token = token;

            Action action = () => OktaClientConfigurationValidator.Validate(configuration);
            action.Should().Throw<ArgumentException>().Where(e => e.ParamName == nameof(configuration.Token));
        }

        [Theory]
        [InlineData("http://myOktaDomain.oktapreview.com")]
        [InlineData("httsp://myOktaDomain.oktapreview.com")]
        [InlineData("invalidOktaDomain")]
        public void FailIfOktaDomainIsNotStartingWithHttps(string oktaDomain)
        {
            var configuration = new OktaClientConfiguration();
            configuration.OktaDomain = oktaDomain;
            configuration.Token = "foo";
            configuration.DisableHttpsCheck = false;

            Action action = () => OktaClientConfigurationValidator.Validate(configuration);
            action.Should().Throw<ArgumentException>().Where(e => e.ParamName == nameof(configuration.OktaDomain));
        }

        [Theory]
        [InlineData("http://myOktaDomain.oktapreview.com")]
        [InlineData("https://myOktaDomain.oktapreview.com")]
        public void NotFailIfOktaDomainIsNotStartingWithHttpsAndDisableHttpsCheckIsTrue(string oktaDomain)
        {
            var configuration = new OktaClientConfiguration();
            configuration.OktaDomain = oktaDomain;
            configuration.Token = "foo";
            configuration.DisableHttpsCheck = true;

            Action action = () => OktaClientConfigurationValidator.Validate(configuration);
            action.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void FailForNullPrivateKeyWhenAuthorizationModeIsPrivateKey()
        {
            var configuration = new OktaClientConfiguration();
            configuration.OktaDomain = "https://myOktaDomain.oktapreview.com";
            configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
            configuration.ClientId = "foo";
            configuration.PrivateKey = null;
            configuration.Scopes = new List<string> { "foo" };

            Action action = () => OktaClientConfigurationValidator.Validate(configuration);
            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("{ClientId}")]
        public void FailForEmptyOrInvalidClientIdWhenAuthorizationModeIsPrivateKey(string clientId)
        {
            var configuration = new OktaClientConfiguration();
            configuration.OktaDomain = "https://myOktaDomain.oktapreview.com";
            configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
            configuration.ClientId = clientId;
            configuration.PrivateKey = new JsonWebKeyConfiguration();
            configuration.Scopes = new List<string> { "foo" };

            Action action = () => OktaClientConfigurationValidator.Validate(configuration);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ThrowForEmptyScopesWhenAuthorizationModeIsPrivateKey()
        {
            var configuration = new OktaClientConfiguration();
            configuration.OktaDomain = "https://myOktaDomain.oktapreview.com";
            configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
            configuration.ClientId = "foo";
            configuration.PrivateKey = new JsonWebKeyConfiguration();
            configuration.Scopes = new List<string>();

            Action action = () => OktaClientConfigurationValidator.Validate(configuration);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ThrowForNullScopesWhenAuthorizationModeIsPrivateKey()
        {
            var configuration = new OktaClientConfiguration();
            configuration.OktaDomain = "https://myOktaDomain.oktapreview.com";
            configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
            configuration.ClientId = "foo";
            configuration.PrivateKey = new JsonWebKeyConfiguration();
            configuration.Scopes = null;

            Action action = () => OktaClientConfigurationValidator.Validate(configuration);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void NotFailWhenValidConfigWhenAuthorizationModeIsPrivateKey()
        {
            var configuration = new OktaClientConfiguration();
            configuration.OktaDomain = "https://myOktaDomain.oktapreview.com";
            configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
            configuration.ClientId = "foo";
            configuration.PrivateKey = new JsonWebKeyConfiguration();
            configuration.Scopes = new List<string> { "foo" };

            Action action = () => OktaClientConfigurationValidator.Validate(configuration);
            action.Should().NotThrow();
        }

        [Fact]
        public void FailWhenAccessTokenNotProvidedAndAuthorizationModeIsOAuthAccessToken()
        {
            var configuration = new OktaClientConfiguration
            {
                OktaDomain = "https://myOktaDomain.oktapreview.com",
                AuthorizationMode = AuthorizationMode.OAuthAccessToken,
                ClientId = "foo",
                Scopes = new List<string> { "foo" },
            };

            Action action = () => OktaClientConfigurationValidator.Validate(configuration);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void NotFailWhenAccessTokenProvidedAndAuthorizationModeIsOAuthAccessToken()
        {
            var configuration = new OktaClientConfiguration
            {
                OktaDomain = "https://myOktaDomain.oktapreview.com",
                AuthorizationMode = AuthorizationMode.OAuthAccessToken,
                OAuthAccessToken = "AnyToken",
                ClientId = "foo",
                Scopes = new List<string> { "foo" },
            };

            Action action = () => OktaClientConfigurationValidator.Validate(configuration);
            action.Should().NotThrow();
        }
    }
}
