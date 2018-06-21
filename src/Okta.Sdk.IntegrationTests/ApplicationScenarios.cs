// <copyright file="ApplicationScenarios.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

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

                retrievedSettings.App.ButtonField.Should().Be("btn-login");
                retrievedSettings.App.PasswordField.Should().Be("txtbox-password");
                retrievedSettings.App.UsernameField.Should().Be("txtbox-username");
                retrievedSettings.App.Url.Should().Be("https://example.com/login.html");
                retrievedSettings.App.LoginUrlRegex.Should().Be("^https://example.com/login.html");
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }

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

                retrievedSettings.App.ButtonSelector.Should().Be("#btn-login");
                retrievedSettings.App.PasswordSelector.Should().Be("#txtbox-password");
                retrievedSettings.App.UserNameSelector.Should().Be("#txtbox-username");
                retrievedSettings.App.TargetUrl.Should().Be("https://example.com/login.html");
                retrievedSettings.App.LoginUrlRegex.Should().Be("^https://example.com/login.html");
                retrievedSettings.App.ExtraFieldSelector.Should().Be(".login");
                retrievedSettings.App.ExtraFieldValue.Should().Be("SOMEVALUE");

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

                retrievedSettings.App.PasswordField.Should().Be("#txtbox-password");
                retrievedSettings.App.UsernameField.Should().Be("#txtbox-username");
                retrievedSettings.App.Url.Should().Be("https://example.com/login.html");
                retrievedSettings.App.OptionalField1.Should().Be("param1");
                retrievedSettings.App.OptionalField1Value.Should().Be("somevalue");
                retrievedSettings.App.OptionalField2.Should().Be("param2");
                retrievedSettings.App.OptionalField2Value.Should().Be("yetanothervalue");
                retrievedSettings.App.OptionalField3.Should().Be("param3");
                retrievedSettings.App.OptionalField3Value.Should().Be("finalvalue");
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

                retrievedSettings.SignOn.RedirectUrl.Should().Be("http://swasecondaryredirecturl.okta.com");
                retrievedSettings.SignOn.LoginUrl.Should().Be("http://swaprimaryloginurl.okta.com");
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
                SignOnMode = ApplicationSignOnMode.Saml2,
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
                        HonorForceAuthentication = true,
                        AuthenticationContextClassName = "urn:oasis:names:tc:SAML:2.0:ac:classes:PasswordProtectedTransport",
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
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.Saml2);
                retrieved.Features.Should().BeEmpty();
                retrieved.Visibility.AutoSubmitToolbar.Should().BeFalse();
                retrieved.Visibility.Hide.IOs.Should().BeFalse();
                retrieved.Visibility.Hide.Web.Should().BeFalse();

                var retrievedSettings = retrieved.GetProperty<SamlApplicationSettings>("settings");

                retrievedSettings.SignOn.DefaultRelayState.Should().BeNullOrEmpty();
                retrievedSettings.SignOn.SsoAcsUrl.Should().Be("http://testorgone.okta");
                retrievedSettings.SignOn.IdpIssuer.Should().Be("http://www.okta.com/${org.externalKey}");
                retrievedSettings.SignOn.Audience.Should().Be("asdqwe123");
                retrievedSettings.SignOn.Recipient.Should().Be("http://testorgone.okta");
                retrievedSettings.SignOn.Destination.Should().Be("http://testorgone.okta");
                retrievedSettings.SignOn.SubjectNameIdTemplate.Should().Be("${user.userName}");
                retrievedSettings.SignOn.SubjectNameIdFormat.Should().Be("urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified");
                retrievedSettings.SignOn.ResponseSigned.Should().BeTrue();
                retrievedSettings.SignOn.AssertionSigned.Should().BeTrue();
                retrievedSettings.SignOn.SignatureAlgorithm.Should().Be("RSA_SHA256");
                retrievedSettings.SignOn.DigestAlgorithm.Should().Be("SHA256");
                retrievedSettings.SignOn.HonorForceAuthentication.Should().BeTrue();
                retrievedSettings.SignOn.AuthenticationContextClassName.Should().Be("urn:oasis:names:tc:SAML:2.0:ac:classes:PasswordProtectedTransport");
                retrievedSettings.SignOn.SpIssuer.Should().BeNull();
                retrievedSettings.SignOn.RequestCompressed.Should().BeFalse();

                retrievedSettings.SignOn.AttributeStatements.Should().HaveCount(1);
                retrievedSettings.SignOn.AttributeStatements.First().Type.Should().Be("EXPRESSION");
                retrievedSettings.SignOn.AttributeStatements.First().Name.Should().Be("Attribute");
                retrievedSettings.SignOn.AttributeStatements.First().Namespace.Should().Be("urn:oasis:names:tc:SAML:2.0:attrname-format:unspecified");
                retrievedSettings.SignOn.AttributeStatements.First().Values.Should().HaveCount(1);
                retrievedSettings.SignOn.AttributeStatements.First().Values.First().Should().Be("Value");
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }

        /// <summary>
        /// FAIL: GroupName expected to be null or empty but is not
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
                        AuthenticationContextClassName = "urn:oasis:names:tc:SAML:2.0:ac:classes:PasswordProtectedTransport",
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

                retrievedSettings.App.AudienceRestriction.Should().Be("urn:example:app");
                retrievedSettings.App.GroupName.Should().BeNullOrEmpty();
                retrievedSettings.App.GroupValueFormat.Should().Be("windowsDomainQualifiedName");
                retrievedSettings.App.Realm.Should().Be("urn:example:app");
                retrievedSettings.App.WReplyUrl.Should().Be("https://example.com/");
                retrievedSettings.App.AttributeStatements.Should().BeNull();
                retrievedSettings.App.NameIdFormat.Should().Be("urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified");
                retrievedSettings.App.AuthenticationContextClassName.Should().Be("urn:oasis:names:tc:SAML:2.0:ac:classes:PasswordProtectedTransport");
                retrievedSettings.App.SiteUrl.Should().Be("https://example.com");
                retrievedSettings.App.WReplyOverride.Should().BeFalse();
                retrievedSettings.App.GroupFilter.Should().BeNull();
                retrievedSettings.App.UsernameAttribute.Should().Be("username");
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
        public async Task AddOpenIdConnectApp()
        {
            var client = GetClient();

            var createdApp = await client.Applications.CreateApplicationAsync(new OpenIdConnectApplication
            {
                Name = "oidc_client",
                Label = "Sample Client",
                SignOnMode = ApplicationSignOnMode.OpenIdConnect,

                Credentials = new OAuthApplicationCredentials()
                {
                    OauthClient = new ApplicationCredentialsOAuthClient()
                    {
                        ClientId = "0oae8mnt9tZcGcMXG0h3",
                        TokenEndpointAuthMethod = OAuthEndpointAuthenticationMethod.ClientSecretPost,
                        AutoKeyRotation = true,
                    },
                },

                // MISSING PROPERTY: "post_logout_redirect_uris": [ "https://example.com/oauth2/postLogoutRedirectUri"],
                Settings = new OpenIdConnectApplicationSettings
                {
                    OAuthClient = new OpenIdConnectApplicationSettingsClient()
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
                        TermsOfServiceUri = "https://example.com/client/tos",
                        PolicyUri = "https://example.com/client/policy",
                    },
                },
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync(createdApp.Id);
                retrieved.Name.Should().Be("oidc_client");
                retrieved.Label.Should().Be("Sample Client");
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.OpenIdConnect);

                var retrievedCredentials = retrieved.GetProperty<OAuthApplicationCredentials>("credentials");

                retrievedCredentials.OauthClient.ClientId.Should().Be("0oae8mnt9tZcGcMXG0h3");
                retrievedCredentials.OauthClient.AutoKeyRotation.Should().BeTrue();
                retrievedCredentials.OauthClient.TokenEndpointAuthMethod.Should().Be(OAuthEndpointAuthenticationMethod.ClientSecretPost);

                var retrievedSettings = retrieved.GetProperty<OpenIdConnectApplicationSettings>("settings");

                retrievedSettings.OAuthClient.ClientUri.Should().Be("https://example.com/client");
                retrievedSettings.OAuthClient.LogoUri.Should().Be("https://example.com/assets/images/logo-new.png");
                retrievedSettings.OAuthClient.RedirectUris.Should().HaveCount(2);
                retrievedSettings.OAuthClient.RedirectUris.First().Should().Be("https://example.com/oauth2/callback");
                retrievedSettings.OAuthClient.RedirectUris.Last().Should().Be("myapp://callback");

                retrievedSettings.OAuthClient.ResponseTypes.Should().HaveCount(3);
                retrievedSettings.OAuthClient.ResponseTypes.ToList().Should().Contain(OAuthResponseType.Token);
                retrievedSettings.OAuthClient.ResponseTypes.ToList().Should().Contain(OAuthResponseType.IdToken);
                retrievedSettings.OAuthClient.ResponseTypes.ToList().Should().Contain(OAuthResponseType.Code);

                retrievedSettings.OAuthClient.GrantTypes.Should().HaveCount(2);
                retrievedSettings.OAuthClient.GrantTypes.ToList().First().Should().Be(OAuthGrantType.Implicit);
                retrievedSettings.OAuthClient.GrantTypes.ToList().Last().Should().Be(OAuthGrantType.AuthorizationCode);

                retrievedSettings.OAuthClient.ApplicationType.Should().Be(OpenIdConnectApplicationType.Native);
                // FAIL: tos & PolicyUri are not being sent
                retrievedSettings.OAuthClient.TermsOfServiceUri.Should().Be("https://example.com/client/tos");
                retrievedSettings.OAuthClient.PolicyUri.Should().Be("https://example.com/client/policy");
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task GetApplication()
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
                var retrievedById = await client.Applications.GetApplicationAsync(createdApp.Id);
                retrievedById.Id.Should().Be(createdApp.Id);
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task ListApplications()
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
                var appList = await client.Applications.ListApplications().ToArray();
                appList.SingleOrDefault(a => a.Id == createdApp.Id).Should().NotBeNull();
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task UpdateSWAApplicationAdminSetUsernameAndPassword()
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

                // Checking defaults
                var retrievedCredentials = retrieved.GetProperty<SchemeApplicationCredentials>("credentials");
                retrievedCredentials.Scheme.Should().Be(ApplicationCredentialsScheme.EditUsernameAndPassword);
                retrievedCredentials.UserNameTemplate.Template.Should().Be("${source.login}");
                retrievedCredentials.UserNameTemplate.Type.Should().Be("BUILT_IN");

                var schemeAppCredentials = new SchemeApplicationCredentials()
                {
                    Scheme = ApplicationCredentialsScheme.AdminSetsCredentials,
                    UserNameTemplate = new ApplicationCredentialsUsernameTemplate()
                    {
                        Template = "${source.login}",
                        Type = "BUILT_IN",
                    },
                };

                retrieved.Credentials = schemeAppCredentials;
                retrieved = await client.Applications.UpdateApplicationAsync(retrieved, retrieved.Id);

                retrievedCredentials = retrieved.GetProperty<SchemeApplicationCredentials>("credentials");
                retrievedCredentials.Scheme.Should().Be(ApplicationCredentialsScheme.AdminSetsCredentials);
                retrievedCredentials.UserNameTemplate.Template.Should().Be("${source.login}");
                retrievedCredentials.UserNameTemplate.Type.Should().Be("BUILT_IN");
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task UpdateSWAApplicationSetUserEditablePassword()
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

                // Checking defaults
                var retrievedCredentials = retrieved.GetProperty<SchemeApplicationCredentials>("credentials");
                retrievedCredentials.Scheme.Should().Be(ApplicationCredentialsScheme.EditUsernameAndPassword);
                retrievedCredentials.UserNameTemplate.Template.Should().Be("${source.login}");
                retrievedCredentials.UserNameTemplate.Type.Should().Be("BUILT_IN");

                var schemeAppCredentials = new SchemeApplicationCredentials()
                {
                    Scheme = ApplicationCredentialsScheme.EditPasswordOnly,
                    UserNameTemplate = new ApplicationCredentialsUsernameTemplate()
                    {
                        Template = "${source.login}",
                        Type = "BUILT_IN",
                    },
                };

                retrieved.Credentials = schemeAppCredentials;
                retrieved = await client.Applications.UpdateApplicationAsync(retrieved, retrieved.Id);

                retrievedCredentials = retrieved.GetProperty<SchemeApplicationCredentials>("credentials");
                retrievedCredentials.Scheme.Should().Be(ApplicationCredentialsScheme.EditPasswordOnly);
                retrievedCredentials.UserNameTemplate.Template.Should().Be("${source.login}");
                retrievedCredentials.UserNameTemplate.Type.Should().Be("BUILT_IN");
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task UpdateSWAApplicationSetSharedCredentials()
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

                // Checking defaults
                var retrievedCredentials = retrieved.GetProperty<SchemeApplicationCredentials>("credentials");
                retrievedCredentials.Scheme.Should().Be(ApplicationCredentialsScheme.EditUsernameAndPassword);
                retrievedCredentials.UserNameTemplate.Template.Should().Be("${source.login}");
                retrievedCredentials.UserNameTemplate.Type.Should().Be("BUILT_IN");

                var schemeAppCredentials = new SchemeApplicationCredentials()
                {
                    Scheme = ApplicationCredentialsScheme.SharedUsernameAndPassword,
                    UserNameTemplate = new ApplicationCredentialsUsernameTemplate()
                    {
                        Template = "${source.login}",
                        Type = "BUILT_IN",
                    },
                    UserName = "sharedusername",
                    Password = new PasswordCredential()
                    {
                        Value = "sharedpassword",
                    },
                };

                retrieved.Credentials = schemeAppCredentials;
                retrieved = await client.Applications.UpdateApplicationAsync(retrieved, retrieved.Id);

                retrievedCredentials = retrieved.GetProperty<SchemeApplicationCredentials>("credentials");
                retrievedCredentials.Scheme.Should().Be(ApplicationCredentialsScheme.SharedUsernameAndPassword);
                retrievedCredentials.UserNameTemplate.Template.Should().Be("${source.login}");
                retrievedCredentials.UserNameTemplate.Type.Should().Be("BUILT_IN");
                retrievedCredentials.UserName.Should().Be("sharedusername");
                retrievedCredentials.Password.Value.Should().BeNullOrEmpty();
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }
    }
}
