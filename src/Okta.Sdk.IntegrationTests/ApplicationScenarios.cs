﻿// <copyright file="ApplicationScenarios.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
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

            var createdApp = await client.Applications.CreateApplicationAsync(new CreateBookmarkApplicationOptions()
            {
                Label = "Sample Bookmark App",
                RequestIntegration = false,
                Url = "https://example.com/bookmark.htm",
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync<IBookmarkApplication>(createdApp.Id);
                retrieved.Name.Should().Be("bookmark");
                retrieved.Label.Should().Be("Sample Bookmark App");
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.Bookmark);

                retrieved.Settings.App.RequestIntegration.Should().Be(false);
                retrieved.Settings.App.Url.Should().Be("https://example.com/bookmark.htm");
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

            var createdApp = await client.Applications.CreateApplicationAsync(new CreateBasicAuthApplicationOptions()
            {
                Label = "Sample Basic Auth App",
                Url = "https://example.com/login.html",
                AuthUrl = "https://example.com/auth.html",
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync<IBasicAuthApplication>(createdApp.Id);
                retrieved.Name.Should().Be("template_basic_auth");
                retrieved.Label.Should().Be("Sample Basic Auth App");
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.BasicAuth);

                retrieved.Settings.App.AuthUrl.Should().Be("https://example.com/auth.html");
                retrieved.Settings.App.Url.Should().Be("https://example.com/login.html");
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

            var createdApp = await client.Applications.CreateApplicationAsync(new CreateSwaApplicationOptions
            {
                Label = "Sample Plugin App",
                ButtonField = "btn-login",
                PasswordField = "txtbox-password",
                UsernameField = "txtbox-username",
                Url = "https://example.com/login.html",
                LoginUrlRegex = "^https://example.com/login.html",
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync<ISwaApplication>(createdApp.Id);
                retrieved.Name.Should().Be("template_swa");
                retrieved.Label.Should().Be("Sample Plugin App");
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.BrowserPlugin);
                retrieved.Settings.App.ButtonField.Should().Be("btn-login");
                retrieved.Settings.App.PasswordField.Should().Be("txtbox-password");
                retrieved.Settings.App.UsernameField.Should().Be("txtbox-username");
                retrieved.Settings.App.Url.Should().Be("https://example.com/login.html");
                retrieved.Settings.App.LoginUrlRegex.Should().Be("^https://example.com/login.html");
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

            var createdApp = await client.Applications.CreateApplicationAsync(new CreateSwaThreeFieldApplicationOptions
            {
                Label = "Sample Plugin App",
                ButtonSelector = "#btn-login",
                PasswordSelector = "#txtbox-password",
                UserNameSelector = "#txtbox-username",
                TargetUrl = "https://example.com/login.html",
                ExtraFieldSelector = ".login",
                ExtraFieldValue = "SOMEVALUE",
                LoginUrlRegex = "^https://example.com/login.html",
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync<ISwaThreeFieldApplication>(createdApp.Id);
                retrieved.Name.Should().Be("template_swa3field");
                retrieved.Label.Should().Be("Sample Plugin App");
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.BrowserPlugin);
                retrieved.Settings.App.ButtonSelector.Should().Be("#btn-login");
                retrieved.Settings.App.PasswordSelector.Should().Be("#txtbox-password");
                retrieved.Settings.App.UserNameSelector.Should().Be("#txtbox-username");
                retrieved.Settings.App.TargetUrl.Should().Be("https://example.com/login.html");
                retrieved.Settings.App.LoginUrlRegex.Should().Be("^https://example.com/login.html");
                retrieved.Settings.App.ExtraFieldSelector.Should().Be(".login");
                retrieved.Settings.App.ExtraFieldValue.Should().Be("SOMEVALUE");

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

            var createdApp = await client.Applications.CreateApplicationAsync(new CreateSwaNoPluginApplicationOptions
            {
                Label = "Sample Plugin App",
                Url = "https://example.com/login.html",
                PasswordField = "#txtbox-password",
                UsernameField = "#txtbox-username",
                OptionalField1 = "param1",
                OptionalField1Value = "somevalue",
                OptionalField2 = "param2",
                OptionalField2Value = "yetanothervalue",
                OptionalField3 = "param3",
                OptionalField3Value = "finalvalue",
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync<ISecurePasswordStoreApplication>(createdApp.Id);
                retrieved.Name.Should().Be("template_sps");
                retrieved.Label.Should().Be("Sample Plugin App");
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.SecurePasswordStore);
                retrieved.Settings.App.PasswordField.Should().Be("#txtbox-password");
                retrieved.Settings.App.UsernameField.Should().Be("#txtbox-username");
                retrieved.Settings.App.Url.Should().Be("https://example.com/login.html");
                retrieved.Settings.App.OptionalField1.Should().Be("param1");
                retrieved.Settings.App.OptionalField1Value.Should().Be("somevalue");
                retrieved.Settings.App.OptionalField2.Should().Be("param2");
                retrieved.Settings.App.OptionalField2Value.Should().Be("yetanothervalue");
                retrieved.Settings.App.OptionalField3.Should().Be("param3");
                retrieved.Settings.App.OptionalField3Value.Should().Be("finalvalue");
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

            var createdApp = await client.Applications.CreateApplicationAsync(new CreateSwaCustomApplicationOptions
            {
                Label = "Sample SWA Custom App",
                Features = new List<string>(),
                AutoSubmitToolbar = false,
                HideIOs = false,
                HideWeb = false,
                RedirectUrl = "http://swasecondaryredirecturl.okta.com",
                LoginUrl = "http://swaprimaryloginurl.okta.com",
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync<IAutoLoginApplication>(createdApp.Id);
                retrieved.Label.Should().Be("Sample SWA Custom App");
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.AutoLogin);
                retrieved.Features.Should().BeEmpty();
                retrieved.Visibility.AutoSubmitToolbar.Should().BeFalse();
                retrieved.Visibility.Hide.IOs.Should().BeFalse();
                retrieved.Visibility.Hide.Web.Should().BeFalse();
                retrieved.Settings.SignOn.RedirectUrl.Should().Be("http://swasecondaryredirecturl.okta.com");
                retrieved.Settings.SignOn.LoginUrl.Should().Be("http://swaprimaryloginurl.okta.com");
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

            var createdApp = await client.Applications.CreateApplicationAsync(new CreateSamlApplicationOptions
            {
                Label = "Sample SAML Custom App",
                Features = new List<string>(),
                AutoSubmitToolbar = false,
                HideIOs = false,
                HideWeb = false,
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
                // Enum here?
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
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync<ISamlApplication>(createdApp.Id);
                retrieved.Label.Should().Be("Sample SAML Custom App");
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.Saml2);
                retrieved.Features.Should().BeEmpty();
                retrieved.Visibility.AutoSubmitToolbar.Should().BeFalse();
                retrieved.Visibility.Hide.IOs.Should().BeFalse();
                retrieved.Visibility.Hide.Web.Should().BeFalse();
                retrieved.Settings.SignOn.DefaultRelayState.Should().BeNullOrEmpty();
                retrieved.Settings.SignOn.SsoAcsUrl.Should().Be("http://testorgone.okta");
                retrieved.Settings.SignOn.IdpIssuer.Should().Be("http://www.okta.com/${org.externalKey}");
                retrieved.Settings.SignOn.Audience.Should().Be("asdqwe123");
                retrieved.Settings.SignOn.Recipient.Should().Be("http://testorgone.okta");
                retrieved.Settings.SignOn.Destination.Should().Be("http://testorgone.okta");
                retrieved.Settings.SignOn.SubjectNameIdTemplate.Should().Be("${user.userName}");
                retrieved.Settings.SignOn.SubjectNameIdFormat.Should().Be("urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified");
                retrieved.Settings.SignOn.ResponseSigned.Should().BeTrue();
                retrieved.Settings.SignOn.AssertionSigned.Should().BeTrue();
                retrieved.Settings.SignOn.SignatureAlgorithm.Should().Be("RSA_SHA256");
                retrieved.Settings.SignOn.DigestAlgorithm.Should().Be("SHA256");
                retrieved.Settings.SignOn.HonorForceAuthentication.Should().BeTrue();
                retrieved.Settings.SignOn.AuthenticationContextClassName.Should().Be("urn:oasis:names:tc:SAML:2.0:ac:classes:PasswordProtectedTransport");
                retrieved.Settings.SignOn.SpIssuer.Should().BeNull();
                retrieved.Settings.SignOn.RequestCompressed.Should().BeFalse();
                retrieved.Settings.SignOn.AttributeStatements.Should().HaveCount(1);
                retrieved.Settings.SignOn.AttributeStatements.First().Type.Should().Be("EXPRESSION");
                retrieved.Settings.SignOn.AttributeStatements.First().Name.Should().Be("Attribute");
                retrieved.Settings.SignOn.AttributeStatements.First().Namespace.Should().Be("urn:oasis:names:tc:SAML:2.0:attrname-format:unspecified");
                retrieved.Settings.SignOn.AttributeStatements.First().Values.Should().HaveCount(1);
                retrieved.Settings.SignOn.AttributeStatements.First().Values.First().Should().Be("Value");
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

            var createdApp = await client.Applications.CreateApplicationAsync(new CreateWsFederationApplicationOptions
            {
                Label = "Sample WS-Fed App",
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
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync<IWsFederationApplication>(createdApp.Id);
                retrieved.Name.Should().Be("template_wsfed");
                retrieved.Label.Should().Be("Sample WS-Fed App");
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.WsFederation);
                retrieved.Settings.App.AudienceRestriction.Should().Be("urn:example:app");
                retrieved.Settings.App.GroupName.Should().BeNullOrEmpty();
                retrieved.Settings.App.GroupValueFormat.Should().Be("windowsDomainQualifiedName");
                retrieved.Settings.App.Realm.Should().Be("urn:example:app");
                retrieved.Settings.App.WReplyUrl.Should().Be("https://example.com/");
                retrieved.Settings.App.AttributeStatements.Should().BeNull();
                retrieved.Settings.App.NameIdFormat.Should().Be("urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified");
                retrieved.Settings.App.AuthenticationContextClassName.Should().Be("urn:oasis:names:tc:SAML:2.0:ac:classes:PasswordProtectedTransport");
                retrieved.Settings.App.SiteUrl.Should().Be("https://example.com");
                retrieved.Settings.App.WReplyOverride.Should().BeFalse();
                retrieved.Settings.App.GroupFilter.Should().BeNull();
                retrieved.Settings.App.UsernameAttribute.Should().Be("username");
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }

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
                var retrieved = await client.Applications.GetApplicationAsync<IOpenIdConnectApplication>(createdApp.Id);
                retrieved.Name.Should().Be("oidc_client");
                retrieved.Label.Should().Be("Sample Client");
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.OpenIdConnect);
                retrieved.Credentials.OauthClient.ClientId.Should().Be("0oae8mnt9tZcGcMXG0h3");
                retrieved.Credentials.OauthClient.AutoKeyRotation.Should().BeTrue();
                retrieved.Credentials.OauthClient.TokenEndpointAuthMethod.Should().Be(OAuthEndpointAuthenticationMethod.ClientSecretPost);

                retrieved.Settings.OAuthClient.ClientUri.Should().Be("https://example.com/client");
                retrieved.Settings.OAuthClient.LogoUri.Should().Be("https://example.com/assets/images/logo-new.png");
                retrieved.Settings.OAuthClient.RedirectUris.Should().HaveCount(2);
                retrieved.Settings.OAuthClient.RedirectUris.First().Should().Be("https://example.com/oauth2/callback");
                retrieved.Settings.OAuthClient.RedirectUris.Last().Should().Be("myapp://callback");

                retrieved.Settings.OAuthClient.ResponseTypes.Should().HaveCount(3);
                retrieved.Settings.OAuthClient.ResponseTypes.ToList().Should().Contain(OAuthResponseType.Token);
                retrieved.Settings.OAuthClient.ResponseTypes.ToList().Should().Contain(OAuthResponseType.IdToken);
                retrieved.Settings.OAuthClient.ResponseTypes.ToList().Should().Contain(OAuthResponseType.Code);

                retrieved.Settings.OAuthClient.GrantTypes.Should().HaveCount(2);
                retrieved.Settings.OAuthClient.GrantTypes.ToList().First().Should().Be(OAuthGrantType.Implicit);
                retrieved.Settings.OAuthClient.GrantTypes.ToList().Last().Should().Be(OAuthGrantType.AuthorizationCode);

                retrieved.Settings.OAuthClient.ApplicationType.Should().Be(OpenIdConnectApplicationType.Native);
                // FAIL: tos & PolicyUri are not being sent
                retrieved.Settings.OAuthClient.TermsOfServiceUri.Should().Be("https://example.com/client/tos");
                retrieved.Settings.OAuthClient.PolicyUri.Should().Be("https://example.com/client/policy");
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

            var createdApp = await client.Applications.CreateApplicationAsync(new CreateBasicAuthApplicationOptions()
            {
                Label = "Sample Basic Auth App",
                Url = "https://example.com/login.html",
                AuthUrl = "https://example.com/auth.html",
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

            var createdApp = await client.Applications.CreateApplicationAsync(new CreateBasicAuthApplicationOptions()
            {
                Label = "Sample Basic Auth App",
                Url = "https://example.com/login.html",
                AuthUrl = "https://example.com/auth.html",
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

            var createdApp = await client.Applications.CreateApplicationAsync(new CreateSwaApplicationOptions
            {
                Label = "Sample Plugin App",
                ButtonField = "btn-login",
                PasswordField = "txtbox-password",
                UsernameField = "txtbox-username",
                Url = "https://example.com/login.html",
                LoginUrlRegex = "^https://example.com/login.html",
            });


            try
            {
                var retrieved = await client.Applications.GetApplicationAsync<ISwaApplication>(createdApp.Id);

                // Checking defaults
                retrieved.Credentials.Scheme.Should().Be(ApplicationCredentialsScheme.EditUsernameAndPassword);
                retrieved.Credentials.UserNameTemplate.Template.Should().Be("${source.login}");
                retrieved.Credentials.UserNameTemplate.Type.Should().Be("BUILT_IN");

                var schemeAppCredentials = new SchemeApplicationCredentials()
                {
                    Scheme = ApplicationCredentialsScheme.AdminSetsCredentials,
                    UserNameTemplate = new ApplicationCredentialsUsernameTemplate()
                    {
                        Template = "${source.login}",
                        Type = "BUILT_IN",
                    },
                };

                retrieved.Credentials.Scheme = ApplicationCredentialsScheme.AdminSetsCredentials;
                retrieved.Credentials.UserNameTemplate.Template = "${source.login}";
                retrieved.Credentials.UserNameTemplate.Type = "BUILT_IN";

                retrieved = await client.Applications.UpdateApplicationAsync<ISwaApplication>(retrieved, retrieved.Id);

                retrieved.Credentials.Scheme.Should().Be(ApplicationCredentialsScheme.AdminSetsCredentials);
                retrieved.Credentials.UserNameTemplate.Template.Should().Be("${source.login}");
                retrieved.Credentials.UserNameTemplate.Type.Should().Be("BUILT_IN");
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

            var createdApp = await client.Applications.CreateApplicationAsync(new CreateSwaApplicationOptions
            {
                Label = "Sample Plugin App",
                ButtonField = "btn-login",
                PasswordField = "txtbox-password",
                UsernameField = "txtbox-username",
                Url = "https://example.com/login.html",
                LoginUrlRegex = "^https://example.com/login.html",
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync<ISwaApplication>(createdApp.Id);

                // Checking defaults
                retrieved.Credentials.Scheme.Should().Be(ApplicationCredentialsScheme.EditUsernameAndPassword);
                retrieved.Credentials.UserNameTemplate.Template.Should().Be("${source.login}");
                retrieved.Credentials.UserNameTemplate.Type.Should().Be("BUILT_IN");

                retrieved.Credentials.Scheme = ApplicationCredentialsScheme.EditPasswordOnly;
                retrieved.Credentials.UserNameTemplate.Template = "${source.login}";
                retrieved.Credentials.UserNameTemplate.Type = "BUILT_IN";

                retrieved = await client.Applications.UpdateApplicationAsync<ISwaApplication>(retrieved, retrieved.Id);

                retrieved.Credentials.Scheme.Should().Be(ApplicationCredentialsScheme.EditPasswordOnly);
                retrieved.Credentials.UserNameTemplate.Template.Should().Be("${source.login}");
                retrieved.Credentials.UserNameTemplate.Type.Should().Be("BUILT_IN");
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

            var createdApp = await client.Applications.CreateApplicationAsync(new CreateSwaApplicationOptions
            {
                Label = "Sample Plugin App",
                ButtonField = "btn-login",
                PasswordField = "txtbox-password",
                UsernameField = "txtbox-username",
                Url = "https://example.com/login.html",
                LoginUrlRegex = "^https://example.com/login.html",
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync<ISwaApplication>(createdApp.Id);

                // Checking defaults
                retrieved.Credentials.Scheme.Should().Be(ApplicationCredentialsScheme.EditUsernameAndPassword);
                retrieved.Credentials.UserNameTemplate.Template.Should().Be("${source.login}");
                retrieved.Credentials.UserNameTemplate.Type.Should().Be("BUILT_IN");

                retrieved.Credentials.Scheme = ApplicationCredentialsScheme.SharedUsernameAndPassword;
                retrieved.Credentials.UserNameTemplate.Template = "${source.login}";
                retrieved.Credentials.UserNameTemplate.Type = "BUILT_IN";
                retrieved.Credentials.UserName = "sharedusername";
                retrieved.Credentials.Password = new PasswordCredential() { Value = "sharedpassword" };

                retrieved = await client.Applications.UpdateApplicationAsync<ISwaApplication>(retrieved, retrieved.Id);

                retrieved.Credentials = retrieved.GetProperty<SchemeApplicationCredentials>("credentials");
                retrieved.Credentials.Scheme.Should().Be(ApplicationCredentialsScheme.SharedUsernameAndPassword);
                retrieved.Credentials.UserNameTemplate.Template.Should().Be("${source.login}");
                retrieved.Credentials.UserNameTemplate.Type.Should().Be("BUILT_IN");
                retrieved.Credentials.UserName.Should().Be("sharedusername");
                retrieved.Credentials.Password.Value.Should().BeNullOrEmpty();
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }
    }
}
