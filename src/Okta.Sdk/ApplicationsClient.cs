using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public sealed partial class ApplicationsClient : OktaClient, IApplicationsClient, IAsyncEnumerable<IApplication>
    {
        /// <inheritdoc/>
        public IAsyncEnumerator<IApplication> GetEnumerator() => ListApplications().GetEnumerator();

        public async Task<T> GetApplicationAsync<T>(string appId, CancellationToken cancellationToken = default(CancellationToken))
            where T : class, IApplication
            => await GetApplicationAsync(appId, null, cancellationToken).ConfigureAwait(false) as T;

        public async Task<T> UpdateApplicationAsync<T>(IApplication application, string appId, CancellationToken cancellationToken = default(CancellationToken))
            where T : class, IApplication
            => await UpdateApplicationAsync(application, appId, cancellationToken).ConfigureAwait(false) as T;

        public Task<IApplication> CreateApplicationAsync(CreateBasicAuthApplicationOptions basicAuthApplicationOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (basicAuthApplicationOptions == null)
            {
                throw new ArgumentNullException(nameof(basicAuthApplicationOptions));
            }

            var app = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = basicAuthApplicationOptions.Label,
                SignOnMode = ApplicationSignOnMode.BasicAuth,
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = basicAuthApplicationOptions.Url,
                        AuthUrl = basicAuthApplicationOptions.AuthUrl,
                    },
                },
            };

            return CreateApplicationAsync(app, basicAuthApplicationOptions.Activate, cancellationToken);
        }

        public Task<IApplication> CreateApplicationAsync(CreateBookmarkApplicationOptions bookmarkApplicationOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (bookmarkApplicationOptions == null)
            {
                throw new ArgumentNullException(nameof(bookmarkApplicationOptions));
            }

            var app = new BookmarkApplication
            {
                Name = "bookmark",
                Label = bookmarkApplicationOptions.Label,
                SignOnMode = ApplicationSignOnMode.Bookmark,
                Settings = new BookmarkApplicationSettings
                {
                    App = new BookmarkApplicationSettingsApplication
                    {
                        RequestIntegration = bookmarkApplicationOptions.RequestIntegration,
                        Url = bookmarkApplicationOptions.Url,
                    },
                },
            };

            return CreateApplicationAsync(app, bookmarkApplicationOptions.Activate, cancellationToken);
        }

        public Task<IApplication> CreateApplicationAsync(CreateSwaApplicationOptions swaApplicationOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (swaApplicationOptions == null)
            {
                throw new ArgumentNullException(nameof(swaApplicationOptions));
            }

            var app = new SwaApplication
            {
                Name = "template_swa",
                Label = swaApplicationOptions.Label,
                SignOnMode = ApplicationSignOnMode.BrowserPlugin,
                Settings = new SwaApplicationSettings
                {
                    App = new SwaApplicationSettingsApplication
                    {
                        ButtonField = swaApplicationOptions.ButtonField,
                        PasswordField = swaApplicationOptions.PasswordField,
                        UsernameField = swaApplicationOptions.UsernameField,
                        Url = swaApplicationOptions.Url,
                        LoginUrlRegex = swaApplicationOptions.LoginUrlRegex,
                    },
                },
            };

            return CreateApplicationAsync(app, swaApplicationOptions.Activate, cancellationToken);
        }

        public Task<IApplication> CreateApplicationAsync(CreateSwaNoPluginApplicationOptions swaNoPluginApplicationOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (swaNoPluginApplicationOptions == null)
            {
                throw new ArgumentNullException(nameof(swaNoPluginApplicationOptions));
            }

            var app = new SecurePasswordStoreApplication
            {
                Name = "template_sps",
                Label = swaNoPluginApplicationOptions.Label,
                SignOnMode = ApplicationSignOnMode.SecurePasswordStore,
                Settings = new SecurePasswordStoreApplicationSettings
                {
                    App = new SecurePasswordStoreApplicationSettingsApplication
                    {
                        Url = swaNoPluginApplicationOptions.Url,
                        PasswordField = swaNoPluginApplicationOptions.PasswordField,
                        UsernameField = swaNoPluginApplicationOptions.UsernameField,
                        OptionalField1 = swaNoPluginApplicationOptions.OptionalField1,
                        OptionalField1Value = swaNoPluginApplicationOptions.OptionalField1Value,
                        OptionalField2 = swaNoPluginApplicationOptions.OptionalField2,
                        OptionalField2Value = swaNoPluginApplicationOptions.OptionalField2Value,
                        OptionalField3 = swaNoPluginApplicationOptions.OptionalField3,
                        OptionalField3Value = swaNoPluginApplicationOptions.OptionalField3Value,

                    },
                },
            };

            return CreateApplicationAsync(app, swaNoPluginApplicationOptions.Activate, cancellationToken);
        }

        public Task<IApplication> CreateApplicationAsync(CreateSwaThreeFieldApplicationOptions swaThreeFieldApplicationOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (swaThreeFieldApplicationOptions == null)
            {
                throw new ArgumentNullException(nameof(swaThreeFieldApplicationOptions));
            }

            var app = new SwaThreeFieldApplication
            {
                Name = "template_swa3field",
                Label = swaThreeFieldApplicationOptions.Label,
                SignOnMode = ApplicationSignOnMode.BrowserPlugin,
                Settings = new SwaThreeFieldApplicationSettings
                {
                    App = new SwaThreeFieldApplicationSettingsApplication
                    {
                        ButtonSelector = swaThreeFieldApplicationOptions.ButtonSelector,
                        PasswordSelector = swaThreeFieldApplicationOptions.PasswordSelector,
                        UserNameSelector = swaThreeFieldApplicationOptions.UserNameSelector,
                        TargetUrl = swaThreeFieldApplicationOptions.TargetUrl,
                        ExtraFieldSelector = swaThreeFieldApplicationOptions.ExtraFieldSelector,
                        ExtraFieldValue = swaThreeFieldApplicationOptions.ExtraFieldValue,
                        LoginUrlRegex = swaThreeFieldApplicationOptions.LoginUrlRegex,
                    },
                },
            };

            return CreateApplicationAsync(app, swaThreeFieldApplicationOptions.Activate, cancellationToken);
        }

        public Task<IApplication> CreateApplicationAsync(CreateSwaCustomApplicationOptions swaCustomApplicationOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (swaCustomApplicationOptions == null)
            {
                throw new ArgumentNullException(nameof(swaCustomApplicationOptions));
            }

            var app = new AutoLoginApplication
            {
                Label = swaCustomApplicationOptions.Label,
                SignOnMode = ApplicationSignOnMode.AutoLogin,
                Features = swaCustomApplicationOptions.Features,
                Visibility = new ApplicationVisibility()
                {
                    AutoSubmitToolbar = swaCustomApplicationOptions.AutoSubmitToolbar,
                    Hide = new ApplicationVisibilityHide()
                    {
                        IOs = swaCustomApplicationOptions.HideIOs,
                        Web = swaCustomApplicationOptions.HideWeb,
                    },
                },
                Settings = new AutoLoginApplicationSettings
                {
                    SignOn = new AutoLoginApplicationSettingsSignOn()
                    {
                        RedirectUrl = swaCustomApplicationOptions.RedirectUrl,
                        LoginUrl = swaCustomApplicationOptions.LoginUrl,
                    },
                },
            };

            return CreateApplicationAsync(app, swaCustomApplicationOptions.Activate, cancellationToken);
        }

        public Task<IApplication> CreateApplicationAsync(CreateSamlApplicationOptions samlApplicationOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (samlApplicationOptions == null)
            {
                throw new ArgumentNullException(nameof(samlApplicationOptions));
            }

            var app = new SamlApplication
            {
                Label = samlApplicationOptions.Label,
                SignOnMode = ApplicationSignOnMode.Saml2,
                Features = samlApplicationOptions.Features,
                Visibility = new ApplicationVisibility()
                {
                    AutoSubmitToolbar = samlApplicationOptions.AutoSubmitToolbar,
                    Hide = new ApplicationVisibilityHide()
                    {
                        IOs = samlApplicationOptions.HideIOs,
                        Web = samlApplicationOptions.HideWeb,
                    },
                },
                Settings = new SamlApplicationSettings
                {
                    SignOn = new SamlApplicationSettingsSignOn()
                    {
                        DefaultRelayState = samlApplicationOptions.DefaultRelayState,
                        SsoAcsUrl = samlApplicationOptions.SsoAcsUrl,
                        IdpIssuer = samlApplicationOptions.IdpIssuer,
                        Audience = samlApplicationOptions.Audience,
                        Recipient = samlApplicationOptions.Recipient,
                        Destination = samlApplicationOptions.Destination,
                        SubjectNameIdTemplate = samlApplicationOptions.SubjectNameIdTemplate,
                        SubjectNameIdFormat = samlApplicationOptions.SubjectNameIdFormat,
                        ResponseSigned = samlApplicationOptions.ResponseSigned,
                        AssertionSigned = samlApplicationOptions.AssertionSigned,
                        SignatureAlgorithm = samlApplicationOptions.SignatureAlgorithm,
                        DigestAlgorithm = samlApplicationOptions.DigestAlgorithm,
                        HonorForceAuthentication = samlApplicationOptions.HonorForceAuthentication,
                        AuthenticationContextClassName = samlApplicationOptions.AuthenticationContextClassName,
                        SpIssuer = samlApplicationOptions.SpIssuer,
                        RequestCompressed = samlApplicationOptions.RequestCompressed,
                        AttributeStatements = samlApplicationOptions.AttributeStatements,
                    },
                },
            };

            return CreateApplicationAsync(app, samlApplicationOptions.Activate, cancellationToken);
        }

        public Task<IApplication> CreateApplicationAsync(CreateWsFederationApplicationOptions wsFederationApplicationOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (wsFederationApplicationOptions == null)
            {
                throw new ArgumentNullException(nameof(wsFederationApplicationOptions));
            }

            var app = new WsFederationApplication
            {
                Name = "template_wsfed",
                Label = wsFederationApplicationOptions.Label,
                SignOnMode = ApplicationSignOnMode.WsFederation,
                Settings = new WsFederationApplicationSettings
                {
                    App = new WsFederationApplicationSettingsApplication()
                    {
                        AudienceRestriction = wsFederationApplicationOptions.AudienceRestriction,
                        GroupName = wsFederationApplicationOptions.GroupName,
                        GroupValueFormat = wsFederationApplicationOptions.GroupValueFormat,
                        Realm = wsFederationApplicationOptions.Realm,
                        WReplyUrl = wsFederationApplicationOptions.WReplyUrl,
                        AttributeStatements = wsFederationApplicationOptions.AttributeStatements,
                        NameIdFormat = wsFederationApplicationOptions.NameIdFormat,
                        AuthenticationContextClassName = wsFederationApplicationOptions.AuthenticationContextClassName,
                        SiteUrl = wsFederationApplicationOptions.SiteUrl,
                        WReplyOverride = wsFederationApplicationOptions.WReplyOverride,
                        GroupFilter = wsFederationApplicationOptions.GroupFilter,
                        UsernameAttribute = wsFederationApplicationOptions.UsernameAttribute,
                    },
                },
            };

            return CreateApplicationAsync(app, wsFederationApplicationOptions.Activate, cancellationToken);
        }

        public Task<IApplication> CreateApplicationAsync(CreateOpenIdConnectApplication openIdApplicationOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (openIdApplicationOptions == null)
            {
                throw new ArgumentNullException(nameof(openIdApplicationOptions));
            }

            var app = new OpenIdConnectApplication
            {
                Name = "oidc_client",
                Label = openIdApplicationOptions.Label,
                SignOnMode = ApplicationSignOnMode.OpenIdConnect,

                Credentials = new OAuthApplicationCredentials()
                {
                    OauthClient = new ApplicationCredentialsOAuthClient()
                    {
                        ClientId = openIdApplicationOptions.ClientId,
                        TokenEndpointAuthMethod = openIdApplicationOptions.TokenEndpointAuthMethod,
                        AutoKeyRotation = openIdApplicationOptions.AutoKeyRotation,
                    },
                },

                Settings = new OpenIdConnectApplicationSettings
                {
                    OAuthClient = new OpenIdConnectApplicationSettingsClient()
                    {
                        ClientUri = openIdApplicationOptions.ClientUri,
                        LogoUri = openIdApplicationOptions.LogoUri,
                        ResponseTypes = openIdApplicationOptions.ResponseTypes,
                        RedirectUris = openIdApplicationOptions.RedirectUris,
                        GrantTypes = openIdApplicationOptions.GrantTypes,
                        ApplicationType = openIdApplicationOptions.ApplicationType,
                        TermsOfServiceUri = openIdApplicationOptions.TermsOfServiceUri,
                        PolicyUri = openIdApplicationOptions.PolicyUri,
                    },
                },
            };

            return CreateApplicationAsync(app, openIdApplicationOptions.Activate, cancellationToken);
        }

        public Task<IApplicationGroupAssignment> CreateApplicationGroupAssignmentAsync(CreateApplicationGroupAssignmentOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            var appGroup = new ApplicationGroupAssignment()
            {
                Priority = options.Priority,
            };

            return CreateApplicationGroupAssignmentAsync(appGroup, options.ApplicationId, options.GroupId, cancellationToken);
        }

        public Task<IAppUser> AssignUserToApplicationAsync(AssignUserToApplicationOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            var appUser = new AppUser()
            {
                Id = options.UserId,
                Scope = options.Scope,

                Credentials = new AppUserCredentials()
                {
                    Password = new AppUserPasswordCredential() { Value = options.Password },
                    UserName = options.UserName,
                },
            };

            return AssignUserToApplicationAsync(appUser, options.ApplicationId, cancellationToken);
        }
    }
}
