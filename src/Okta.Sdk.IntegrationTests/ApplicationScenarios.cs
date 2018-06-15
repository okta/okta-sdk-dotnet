// <copyright file="ApplicationScenarios.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using System.Linq;

namespace Okta.Sdk.IntegrationTests
{
    [Collection(nameof(ScenariosCollection))]
    public class ApplicationScenarios : ScenarioGroup
    {
        [Fact]
        public async Task AddBookmarkApp()
        {
            var client = GetClient();

            var createdApp = await client.Applications.CreateApplicationAsync(new BookmarkApplication
            {
                Name = "bookmark",
                Label = "Sample Bookmark App",
                SignOnMode = ApplicationSignOnMode.Bookmark,
                Settings = new BookmarkApplicationSettings
                {
                    App = new BookmarkApplicationSettingsApplication
                    {
                        RequestIntegration = false,
                        Url = "https://example.com/bookmark.htm",
                    },
                },
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync(createdApp.Id);
                retrieved.Name.Should().Be("bookmark");
                retrieved.Label.Should().Be("Sample Bookmark App");
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.Bookmark);


                ((BookmarkApplication)retrieved).Settings.App.RequestIntegration.Should().Be(false);
                ((BookmarkApplication)retrieved).Settings.App.Url.Should().Be("https://example.com/bookmark.htm");
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task AddBasicAuthenticationApp()
        {
            var client = GetClient();

            var createdApp = await client.Applications.CreateApplicationAsync(new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = "Sample Basic Auth App",
                SignOnMode = ApplicationSignOnMode.BasicAuth,
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthUrl = "https://example.com/auth.html",
                    },
                },
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync(createdApp.Id);
                retrieved.Name.Should().Be("template_basic_auth");
                retrieved.Label.Should().Be("Sample Basic Auth App");
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.BasicAuth);


                ((BasicAuthApplication)retrieved).Settings.App.AuthUrl.Should().Be("https://example.com/auth.html");
                ((BasicAuthApplication)retrieved).Settings.App.Url.Should().Be("https://example.com/login.html");
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task AddSwaApp()
        {
            var client = GetClient();

            var createdApp = await client.Applications.CreateApplicationAsync(new SwaApplication
            {
                Name = "template_swa",
                Label = "Sample Plugin App",
                SignOnMode = ApplicationSignOnMode.BrowserPlugin,
                Settings = new SwaApplicationSettings
                {
                    App = new SwaApplicationSettingsApplication
                    {
                          ButtonField = "btn-login",
                          PasswordField = "txtbox-password",
                          UsernameField = "txtbox-username",
                          Url = "https://example.com/login.html",
                          LoginUrlRegex = "^https://example.com/login.html",
                    },
                },
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync(createdApp.Id);
                retrieved.Name.Should().Be("template_swa");
                retrieved.Label.Should().Be("Sample Plugin App");
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.BrowserPlugin);

                var retrievedSettings = retrieved.GetProperty<SwaApplicationSettings>("settings");

                ((SwaApplicationSettingsApplication)retrievedSettings.App).ButtonField.Should().Be("btn-login");
                ((SwaApplicationSettingsApplication)retrievedSettings.App).PasswordField.Should().Be("txtbox-password");
                ((SwaApplicationSettingsApplication)retrievedSettings.App).UsernameField.Should().Be("txtbox-username");
                ((SwaApplicationSettingsApplication)retrievedSettings.App).Url.Should().Be("https://example.com/login.html");
                ((SwaApplicationSettingsApplication)retrievedSettings.App).LoginUrlRegex.Should().Be("^https://example.com/login.html");
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }

        /// <Fail>
        /// This test FAILS because the expected name for the TargetUrl field in the request is TargetURL.
        /// If I change    set => this["targetUrl"] = value; by    set => this["targetURL"] = value; it works as expected
        /// </Fail>
        [Fact]
        public async Task AddSwaThreeFieldApp()
        {
            var client = GetClient();

            var createdApp = await client.Applications.CreateApplicationAsync(new SwaThreeFieldApplication
            {
                Name = "template_swa3field",
                Label = "Sample Plugin App",
                SignOnMode = ApplicationSignOnMode.BrowserPlugin,
                Settings = new SwaThreeFieldApplicationSettings
                {
                    App = new SwaThreeFieldApplicationSettingsApplication
                    {
                        ButtonSelector = "#btn-login",
                        PasswordSelector = "#txtbox-password",
                        UserNameSelector = "#txtbox-username",
                        TargetUrl = "https://example.com/login.html",
                        ExtraFieldSelector = ".login",
                        ExtraFieldValue = "SOMEVALUE",
                        LoginUrlRegex = "^https://example.com/login.html",
                    },
                },
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync(createdApp.Id);
                retrieved.Name.Should().Be("template_swa3field");
                retrieved.Label.Should().Be("Sample Plugin App");
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.BrowserPlugin);

                var retrievedSettings = retrieved.GetProperty<SwaThreeFieldApplicationSettings>("settings");

                ((ISwaThreeFieldApplicationSettingsApplication)retrievedSettings.App).ButtonSelector.Should().Be("#btn-login");
                ((ISwaThreeFieldApplicationSettingsApplication)retrievedSettings.App).PasswordSelector.Should().Be("#txtbox-password");
                ((ISwaThreeFieldApplicationSettingsApplication)retrievedSettings.App).UserNameSelector.Should().Be("#txtbox-username");
                ((ISwaThreeFieldApplicationSettingsApplication)retrievedSettings.App).TargetUrl.Should().Be("https://example.com/login.html");
                ((ISwaThreeFieldApplicationSettingsApplication)retrievedSettings.App).LoginUrlRegex.Should().Be("^https://example.com/login.html");
                ((ISwaThreeFieldApplicationSettingsApplication)retrievedSettings.App).ExtraFieldSelector.Should().Be(".login");
                ((ISwaThreeFieldApplicationSettingsApplication)retrievedSettings.App).ExtraFieldValue.Should().Be("SOMEVALUE");

            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task AddSwaNoPluginApp()
        {
            var client = GetClient();

            var createdApp = await client.Applications.CreateApplicationAsync(new SecurePasswordStoreApplication
            {
                Name = "template_sps",
                Label = "Sample Plugin App",
                SignOnMode = ApplicationSignOnMode.SecurePasswordStore,
                Settings = new SecurePasswordStoreApplicationSettings
                {
                    App = new SecurePasswordStoreApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        PasswordField = "#txtbox-password",
                        UsernameField = "#txtbox-username",
                        OptionalField1 = "param1",
                        OptionalField1Value = "somevalue",
                        OptionalField2 = "param2",
                        OptionalField2Value = "yetanothervalue",
                        OptionalField3 = "param3",
                        OptionalField3Value = "finalvalue",

                    },
                },
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync(createdApp.Id);
                retrieved.Name.Should().Be("template_sps");
                retrieved.Label.Should().Be("Sample Plugin App");
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.SecurePasswordStore);

                var retrievedSettings = retrieved.GetProperty<SecurePasswordStoreApplicationSettings>("settings");

                ((ISecurePasswordStoreApplicationSettingsApplication)retrievedSettings.App).PasswordField.Should().Be("#txtbox-password");
                ((ISecurePasswordStoreApplicationSettingsApplication)retrievedSettings.App).UsernameField.Should().Be("#txtbox-username");
                ((ISecurePasswordStoreApplicationSettingsApplication)retrievedSettings.App).Url.Should().Be("https://example.com/login.html");
                ((ISecurePasswordStoreApplicationSettingsApplication)retrievedSettings.App).OptionalField1.Should().Be("param1");
                ((ISecurePasswordStoreApplicationSettingsApplication)retrievedSettings.App).OptionalField1Value.Should().Be("somevalue");
                ((ISecurePasswordStoreApplicationSettingsApplication)retrievedSettings.App).OptionalField2.Should().Be("param2");
                ((ISecurePasswordStoreApplicationSettingsApplication)retrievedSettings.App).OptionalField2Value.Should().Be("yetanothervalue");
                ((ISecurePasswordStoreApplicationSettingsApplication)retrievedSettings.App).OptionalField3.Should().Be("param3");
                ((ISecurePasswordStoreApplicationSettingsApplication)retrievedSettings.App).OptionalField3Value.Should().Be("finalvalue");
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task AddSwaCustomApp()
        {
            var client = GetClient();

            var createdApp = await client.Applications.CreateApplicationAsync(new AutoLoginApplication
            {
                Label = "Sample SWA Custom App",
                SignOnMode = ApplicationSignOnMode.AutoLogin,
                Features = new List<string>(),
                Visibility = new ApplicationVisibility()
                {
                    AutoSubmitToolbar = false,
                    Hide = new ApplicationVisibilityHide()
                    {
                        IOs = false,
                        Web = false,
                    },
                },
                Settings = new AutoLoginApplicationSettings
                {
                    SignOn = new AutoLoginApplicationSettingsSignOn()
                    {
                        RedirectUrl = "http://swasecondaryredirecturl.okta.com",
                        LoginUrl = "http://swaprimaryloginurl.okta.com",
                    },
                },
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync(createdApp.Id);
                retrieved.Label.Should().Be("Sample SWA Custom App");
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.AutoLogin);
                retrieved.Features.Should().BeEmpty();
                retrieved.Visibility.AutoSubmitToolbar.Should().BeFalse();
                retrieved.Visibility.Hide.IOs.Should().BeFalse();
                retrieved.Visibility.Hide.Web.Should().BeFalse();

                var retrievedSettings = retrieved.GetProperty<AutoLoginApplicationSettings>("settings");

                ((AutoLoginApplicationSettingsSignOn)retrievedSettings.SignOn).RedirectUrl.Should().Be("http://swasecondaryredirecturl.okta.com");
                ((AutoLoginApplicationSettingsSignOn)retrievedSettings.SignOn).LoginUrl.Should().Be("http://swaprimaryloginurl.okta.com");
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task AddSamlCustomApp()
        {
            var client = GetClient();

            var createdApp = await client.Applications.CreateApplicationAsync(new SamlApplication
            {
                Label = "Sample SAML Custom App",
                SignOnMode = ApplicationSignOnMode.Saml20,
                Features = new List<string>(),
                Visibility = new ApplicationVisibility()
                {
                    AutoSubmitToolbar = false,
                    Hide = new ApplicationVisibilityHide()
                    {
                        IOs = false,
                        Web = false,
                    },
                },
                Settings = new SamlApplicationSettings
                {
                    SignOn = new SamlApplicationSettingsSignOn()
                    {
                        DefaultRelayState = string.Empty,
                        SsoAcsUrl = "http://testorgone.okta",
                        IdpIssuer = "http://www.okta.com/${org.externalKey}",
                        Audience = "asdqwe123",
                        Recipient = "http://testorgone.okta",
                        Destination = "http://testorgone.okta",
                        SubjectNameIdTemplate = "${user.userName}",
                        SubjectNameIdFormat = "urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified",
                        ResponseSigned = true,
                        AssertionSigned = true,
                        SignatureAlgorithm = "RSA_SHA256",
                        DigestAlgorithm = "SHA256",
                        HonorForceAuthn = true,
                        AuthnContextClassRef = "urn:oasis:names:tc:SAML:2.0:ac:classes:PasswordProtectedTransport",
                        SpIssuer = null,
                        RequestCompressed = false,
                        AttributeStatements = new List<SamlAttributeStatement>
                        {
                            new SamlAttributeStatement()
                             {
                                Name = "Attribute",
                                Type = "EXPRESSION",
                                Namespace = "urn:oasis:names:tc:SAML:2.0:attrname-format:unspecified",
                                Values = new List<string>() { "Value" },
                            },
                        },
                    },
                },
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync(createdApp.Id);
                retrieved.Label.Should().Be("Sample SAML Custom App");
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.Saml20);
                retrieved.Features.Should().BeEmpty();
                retrieved.Visibility.AutoSubmitToolbar.Should().BeFalse();
                retrieved.Visibility.Hide.IOs.Should().BeFalse();
                retrieved.Visibility.Hide.Web.Should().BeFalse();

                var retrievedSettings = retrieved.GetProperty<SamlApplicationSettings>("settings");

                ((SamlApplicationSettingsSignOn)retrievedSettings.SignOn).DefaultRelayState.Should().BeNullOrEmpty();
                ((SamlApplicationSettingsSignOn)retrievedSettings.SignOn).SsoAcsUrl.Should().Be("http://testorgone.okta");
                ((SamlApplicationSettingsSignOn)retrievedSettings.SignOn).IdpIssuer.Should().Be("http://www.okta.com/${org.externalKey}");
                ((SamlApplicationSettingsSignOn)retrievedSettings.SignOn).Audience.Should().Be("asdqwe123");
                ((SamlApplicationSettingsSignOn)retrievedSettings.SignOn).Recipient.Should().Be("http://testorgone.okta");
                ((SamlApplicationSettingsSignOn)retrievedSettings.SignOn).Destination.Should().Be("http://testorgone.okta");
                ((SamlApplicationSettingsSignOn)retrievedSettings.SignOn).SubjectNameIdTemplate.Should().Be("${user.userName}");
                ((SamlApplicationSettingsSignOn)retrievedSettings.SignOn).SubjectNameIdFormat.Should().Be("urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified");
                ((SamlApplicationSettingsSignOn)retrievedSettings.SignOn).ResponseSigned.Should().BeTrue();
                ((SamlApplicationSettingsSignOn)retrievedSettings.SignOn).AssertionSigned.Should().BeTrue();
                ((SamlApplicationSettingsSignOn)retrievedSettings.SignOn).SignatureAlgorithm.Should().Be("RSA_SHA256");
                ((SamlApplicationSettingsSignOn)retrievedSettings.SignOn).DigestAlgorithm.Should().Be("SHA256");
                ((SamlApplicationSettingsSignOn)retrievedSettings.SignOn).HonorForceAuthn.Should().BeTrue();
                ((SamlApplicationSettingsSignOn)retrievedSettings.SignOn).AuthnContextClassRef.Should().Be("urn:oasis:names:tc:SAML:2.0:ac:classes:PasswordProtectedTransport");
                ((SamlApplicationSettingsSignOn)retrievedSettings.SignOn).SpIssuer.Should().BeNull();
                ((SamlApplicationSettingsSignOn)retrievedSettings.SignOn).RequestCompressed.Should().BeFalse();

                ((SamlApplicationSettingsSignOn)retrievedSettings.SignOn).AttributeStatements.Should().HaveCount(1);
                ((SamlApplicationSettingsSignOn)retrievedSettings.SignOn).AttributeStatements.First().Type.Should().Be("EXPRESSION");
                ((SamlApplicationSettingsSignOn)retrievedSettings.SignOn).AttributeStatements.First().Name.Should().Be("Attribute");
                ((SamlApplicationSettingsSignOn)retrievedSettings.SignOn).AttributeStatements.First().Namespace.Should().Be("urn:oasis:names:tc:SAML:2.0:attrname-format:unspecified");
                ((SamlApplicationSettingsSignOn)retrievedSettings.SignOn).AttributeStatements.First().Values.Should().HaveCount(1);
                ((SamlApplicationSettingsSignOn)retrievedSettings.SignOn).AttributeStatements.First().Values.First().Should().Be("Value");
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }

        /// <summary>
        /// FAIL: GroupName expected to be null or empty but is not
        /// FAIL: wReplyOverride expected to be https://example.com but it came with a final `/`
        /// </summary>
        [Fact]
        public async Task AddWsFederationApp()
        {
            var client = GetClient();

            var createdApp = await client.Applications.CreateApplicationAsync(new WsFederationApplication
            {
                Name = "template_wsfed",
                Label = "Sample WS-Fed App",
                SignOnMode = ApplicationSignOnMode.WsFederation,
                Settings = new WsFederationApplicationSettings
                {
                    App = new WsFederationApplicationSettingsApplication()
                    {
                        AudienceRestriction = "urn:example:app",
                        GroupName = null,
                        GroupValueFormat = "windowsDomainQualifiedName",
                        Realm = "urn:example:app",
                        WReplyUrl = "https://example.com/",
                        AttributeStatements = null,
                        NameIdFormat = "urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified",
                        AuthnContextClassRef = "urn:oasis:names:tc:SAML:2.0:ac:classes:PasswordProtectedTransport",
                        SiteUrl = "https://example.com",
                        WReplyOverride = false,
                        GroupFilter = null,
                        UsernameAttribute = "username",
                    },
                },
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync(createdApp.Id);
                retrieved.Name.Should().Be("template_wsfed");
                retrieved.Label.Should().Be("Sample WS-Fed App");
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.WsFederation);

                var retrievedSettings = retrieved.GetProperty<WsFederationApplicationSettings>("settings");

                ((IWsFederationApplicationSettingsApplication)retrievedSettings.App).AudienceRestriction.Should().Be("urn:example:app");
                ((IWsFederationApplicationSettingsApplication)retrievedSettings.App).GroupName.Should().BeNullOrEmpty();
                ((IWsFederationApplicationSettingsApplication)retrievedSettings.App).GroupValueFormat.Should().Be("windowsDomainQualifiedName");
                ((IWsFederationApplicationSettingsApplication)retrievedSettings.App).Realm.Should().Be("urn:example:app");
                ((IWsFederationApplicationSettingsApplication)retrievedSettings.App).WReplyUrl.Should().Be("https://example.com");
                ((IWsFederationApplicationSettingsApplication)retrievedSettings.App).AttributeStatements.Should().BeNull();
                ((IWsFederationApplicationSettingsApplication)retrievedSettings.App).NameIdFormat.Should().Be("urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified");
                ((IWsFederationApplicationSettingsApplication)retrievedSettings.App).AuthnContextClassRef.Should().Be("urn:oasis:names:tc:SAML:2.0:ac:classes:PasswordProtectedTransport");
                ((IWsFederationApplicationSettingsApplication)retrievedSettings.App).SiteUrl.Should().Be("https://example.com");
                ((IWsFederationApplicationSettingsApplication)retrievedSettings.App).WReplyOverride.Should().BeFalse();
                ((IWsFederationApplicationSettingsApplication)retrievedSettings.App).GroupFilter.Should().BeNull();
                ((IWsFederationApplicationSettingsApplication)retrievedSettings.App).UsernameAttribute.Should().Be("username");
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }

        /// <summary>
        /// FAIL: Invalid grantTypes & responseTypes
        /// </summary>
        [Fact]
        public async Task AddOAuthTwoApp()
        {
            var client = GetClient();

            var createdApp = await client.Applications.CreateApplicationAsync(new OpenIdConnectApplication
            {
                Name = "oidc_client",
                Label = "Sample Client",
                SignOnMode = ApplicationSignOnMode.OpenidConnect,

                Credentials = new OAuthApplicationCredentials()
                {
                    OauthClient = new ApplicationCredentialsOAuthClient()
                    {
                        ClientId = "0oa1hm4POxgJM6CPu0g4",
                        TokenEndpointAuthMethod = OAuthEndpointAuthenticationMethod.ClientSecretPost,
                        AutoKeyRotation = true,
                    },
                },

                // MISSING PROPERTY: "post_logout_redirect_uris": [ "https://example.com/oauth2/postLogoutRedirectUri"],
                Settings = new OpenIdConnectApplicationSettings
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient()
                    {
                        ClientUri = "https://example.com/client",
                        LogoUri = "https://example.com/assets/images/logo-new.png",
                        ResponseTypes = new List<OAuthResponseType>
                        {
                            OAuthResponseType.Token,
                            OAuthResponseType.IdToken,
                            OAuthResponseType.Code,
                        },
                        RedirectUris = new List<string>
                        {
                             "https://example.com/oauth2/callback",
                             "myapp://callback",
                        },
                        GrantTypes = new List<OAuthGrantType>
                        {
                            OAuthGrantType.Implicit,
                            OAuthGrantType.AuthorizationCode,
                        },
                        ApplicationType = OpenIdConnectApplicationType.Native,
                        TosUri = "https://example.com/client/tos",
                        PolicyUri = "https://example.com/client/policy",
                    },
                },
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync(createdApp.Id);
                retrieved.Name.Should().Be("oidc_client");
                retrieved.Label.Should().Be("Sample Client");
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.OpenidConnect);

                var retrievedCredentials = retrieved.GetProperty<ApplicationCredentialsOAuthClient>("credentials");

                retrievedCredentials.ClientId.Should().Be("0oa1hm4POxgJM6CPu0g4");
                retrievedCredentials.AutoKeyRotation.Should().BeTrue();
                retrievedCredentials.TokenEndpointAuthMethod.Should().Be(OAuthEndpointAuthenticationMethod.ClientSecretPost);

                var retrievedSettings = retrieved.GetProperty<OpenIdConnectApplicationSettings>("settings");

                ((OpenIdConnectApplicationSettingsClient)retrievedSettings.OauthClient).ClientUri.Should().Be("https://example.com/client");
                ((OpenIdConnectApplicationSettingsClient)retrievedSettings.OauthClient).LogoUri.Should().Be("https://example.com/assets/images/logo-new.png");
                ((OpenIdConnectApplicationSettingsClient)retrievedSettings.OauthClient).RedirectUris.Should().HaveCount(2);
                ((OpenIdConnectApplicationSettingsClient)retrievedSettings.OauthClient).RedirectUris.First().Should().Be("https://example.com/oauth2/callback");
                ((OpenIdConnectApplicationSettingsClient)retrievedSettings.OauthClient).RedirectUris.Last().Should().Be("myapp://callback");

                ((OpenIdConnectApplicationSettingsClient)retrievedSettings.OauthClient).ResponseTypes.Should().HaveCount(3);
                ((OpenIdConnectApplicationSettingsClient)retrievedSettings.OauthClient).ResponseTypes.ToArray()[0].Should().Be(OAuthResponseType.Token);
                ((OpenIdConnectApplicationSettingsClient)retrievedSettings.OauthClient).ResponseTypes.ToArray()[1].Should().Be(OAuthResponseType.IdToken);
                ((OpenIdConnectApplicationSettingsClient)retrievedSettings.OauthClient).ResponseTypes.ToArray()[1].Should().Be(OAuthResponseType.Code);

                ((OpenIdConnectApplicationSettingsClient)retrievedSettings.OauthClient).GrantTypes.Should().HaveCount(2);
                ((OpenIdConnectApplicationSettingsClient)retrievedSettings.OauthClient).GrantTypes.First().Should().Be(OAuthGrantType.Implicit);
                ((OpenIdConnectApplicationSettingsClient)retrievedSettings.OauthClient).GrantTypes.Last().Should().Be(OAuthGrantType.AuthorizationCode);

                ((OpenIdConnectApplicationSettingsClient)retrievedSettings.OauthClient).ApplicationType.Should().Be(OpenIdConnectApplicationType.Native);
                ((OpenIdConnectApplicationSettingsClient)retrievedSettings.OauthClient).TosUri.Should().Be("https://example.com/client/tos");
                ((OpenIdConnectApplicationSettingsClient)retrievedSettings.OauthClient).PolicyUri.Should().Be("https://example.com/client/policy");
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }
    }
}
