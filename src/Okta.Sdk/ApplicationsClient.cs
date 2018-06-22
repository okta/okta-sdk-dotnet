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

        public Task<IApplication> CreateApplicationAsync(CreateBasicAuthApplicationOptions basicAuthApplicationOptions, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken))
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

            return CreateApplicationAsync(app, activate, cancellationToken);
        }

        public Task<IApplication> CreateApplicationAsync(CreateBookmarkApplicationOptions bookmarkApplicationOptions, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken))
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

            return CreateApplicationAsync(app, activate, cancellationToken);
        }

        public Task<IApplication> CreateApplicationAsync(CreateSwaApplicationOptions swaApplicationOptions, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken))
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

            return CreateApplicationAsync(app, activate, cancellationToken);
        }

        public Task<IApplication> CreateApplicationAsync(CreateSwaNoPluginApplicationOptions swaNoPluginApplicationOptions, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken))
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
                        UsernameField = swaNoPluginApplicationOptions.UserNameField,
                        OptionalField1 = swaNoPluginApplicationOptions.OptionalField1,
                        OptionalField1Value = swaNoPluginApplicationOptions.OptionalField1Value,
                        OptionalField2 = swaNoPluginApplicationOptions.OptionalField2,
                        OptionalField2Value = swaNoPluginApplicationOptions.OptionalField2Value,
                        OptionalField3 = swaNoPluginApplicationOptions.OptionalField3,
                        OptionalField3Value = swaNoPluginApplicationOptions.OptionalField3,

                    },
                },
            };

            return CreateApplicationAsync(app, activate, cancellationToken);
        }

        public Task<IApplication> CreateApplicationAsync(CreateSwaThreeFieldApplicationOptions swaThreeFieldApplicationOptions, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken))
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

            return CreateApplicationAsync(app, activate, cancellationToken);
        }

        public Task<IApplication> CreateApplicationAsync(CreateSwaCustomApplicationOptions swaCustomApplicationOptions, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken))
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

            return CreateApplicationAsync(app, activate, cancellationToken);
        }

        public Task<IApplication> CreateApplicationAsync(CreateSamlApplicationOptions samlApplicationOptions, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken))
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
                        AttributeStatements = new List<SamlAttributeStatement>
                        {
                            new SamlAttributeStatement()
                             {
                                Name = samlApplicationOptions.StatementName,
                                Type = samlApplicationOptions.StatementType,
                                Namespace = samlApplicationOptions.StatementNamespace,
                                Values = samlApplicationOptions.StatementValues,
                            },
                        },
                    },
                },
            };

            return CreateApplicationAsync(app, activate, cancellationToken);
        }

        public Task<IApplication> CreateApplicationAsync(CreateWsFederationApplicationOptions wsFederationApplicationOptions, bool? activate = true, CancellationToken cancellationToken = default(CancellationToken))
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

            return CreateApplicationAsync(app, activate, cancellationToken);
        }
    }
}
