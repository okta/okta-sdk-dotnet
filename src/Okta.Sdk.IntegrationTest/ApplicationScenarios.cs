using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{

    [Collection(name: nameof(ApplicationScenarios))]
    public class ApplicationScenarios
    {
        private ApplicationApi _applicationApi;
        private UserApi _userApi;
        private GroupApi _groupApi;
        private ApplicationTokensApi _applicationTokensApi;
        private ApplicationLogosApi _applicationlogoApi;
        private ApplicationUsersApi _applicationUsersApi;
        private ApplicationGroupsApi _applicationGroupApi;
        private ApplicationCredentialsApi _applicationCredentialsApi;
        private ApplicationGrantsApi _applicationGrantsApi;
        private ApplicationConnectionsApi _applicationConnectionsApi;

        public ApplicationScenarios()
        {
            _applicationApi = new ApplicationApi();
            _userApi = new UserApi();
            _groupApi = new GroupApi();
            _applicationTokensApi = new ApplicationTokensApi();
            _applicationlogoApi = new ApplicationLogosApi();
            _applicationGroupApi = new ApplicationGroupsApi();
            _applicationCredentialsApi = new ApplicationCredentialsApi();
            _applicationGrantsApi = new ApplicationGrantsApi();
            _applicationConnectionsApi = new ApplicationConnectionsApi();
            _applicationUsersApi = new ApplicationUsersApi();
            CleanApps().Wait();
        }

        private async Task CleanApps()
        {
            var appsToRemove = await _applicationApi.ListApplications().ToListAsync();

            foreach (var app in appsToRemove)
            {
                if (app.Label.StartsWith("dotnet-sdk"))
                {
                    await _applicationApi.DeactivateApplicationAsync(app.Id);
                    await _applicationApi.DeleteApplicationAsync(app.Id);
                }
            }
        }

        [Fact]
        public async Task AddBookmarkApp()
        {
            var guid = Guid.NewGuid();

            var app = new BookmarkApplication
            {
                Name = "bookmark",
                Label = $"dotnet-sdk: AddBookmarkApp {guid}",
                SignOnMode = "BOOKMARK",
                Settings = new BookmarkApplicationSettings
                {
                    App = new BookmarkApplicationSettingsApplication
                    {
                        RequestIntegration = false,
                        Url = "https://example.com/bookmark.htm",
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app);

            try
            {
                var retrievedApp = await _applicationApi.GetApplicationAsync(createdApp.Id) as BookmarkApplication;
                retrievedApp.Name.Value.Should().Be("bookmark");
                retrievedApp.Label.Should().Be($"dotnet-sdk: AddBookmarkApp {guid}");
                retrievedApp.SignOnMode.Value.Should().Be("BOOKMARK");
                retrievedApp.Settings.App.RequestIntegration.Should().Be(false);
                retrievedApp.Settings.App.Url.Should().Be("https://example.com/bookmark.htm");
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task UploadLogo()
        {
            var guid = Guid.NewGuid();

            var app = new BookmarkApplication
            {
                Name = "bookmark",
                Label = $"dotnet-sdk: UploadLogo {guid}",
                SignOnMode = ApplicationSignOnMode.BOOKMARK,
                Settings = new BookmarkApplicationSettings
                {
                    App = new BookmarkApplicationSettingsApplication
                    {
                        RequestIntegration = false,
                        Url = "https://example.com/bookmark.htm",
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app);

            try
            {
                var defaultLogo = createdApp.Links.Logo.FirstOrDefault().Href.ToString();
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Assets/okta_logo_white.png");
                var file = File.OpenRead(filePath);

                await _applicationlogoApi.UploadApplicationLogoAsync(createdApp.Id, file);

                var retrievedApp = await _applicationApi.GetApplicationAsync(createdApp.Id) as BookmarkApplication;
                var updatedLogo = retrievedApp.Links.Logo.FirstOrDefault().Href.ToString();
                defaultLogo.Should().NotBeEquivalentTo(updatedLogo);

            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task AddBasicAuthenticationApp()
        {
            var guid = Guid.NewGuid();

            var app = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: AddBasicAuthenticationApp {guid}",
                SignOnMode = "BASIC_AUTH",
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app);
            try
            {
                var retrieved = await _applicationApi.GetApplicationAsync(createdApp.Id) as BasicAuthApplication;
                retrieved.Name.Value.Should().Be("template_basic_auth");
                retrieved.Label.Should().Be($"dotnet-sdk: AddBasicAuthenticationApp {guid}");
                retrieved.SignOnMode.Value.Should().Be("BASIC_AUTH");

                retrieved.Settings.App.AuthURL.Should().Be("https://example.com/auth.html");
                retrieved.Settings.App.Url.Should().Be("https://example.com/login.html");
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task AddOpenIdConnectApp()
        {
            var guid = Guid.NewGuid();
            var testClientId = $"{nameof(AddOpenIdConnectApp)}_TestClientId";

            var jwk = new JsonWebKey()
            {
                N = "MIIBIzANBgkqhkiG9w0BAQEFAAOCARAAMIIBCwKCAQIAnFo/4e91na8x/BsPkNS5QkwankewxJ1uZU6p827W/gkRcNHtNi/cE644W5OVdB4UaXV6koT+TsC1prhUEhRR3g5ggE0B/lwYqBaLq/Ejy19Crc4XYU3Aah67Y6HiHWcHGZ+BbpebtTixJv/UYW/Gw+k8M+zj4O001mOeBPpwlEiZZLIo33m/Xkfn28jaCFqTQBJHr67IQh4zEUFs4e5D5D6UE8ee93yeSUJyhbifeIgYh3tS/+ZW4Uo1KLIc0rcLRrnEMsS3aOQbrv/SEKij+Syx4KXI0Gi2xMdXctnFOVT6NM6/EkLxFp2POEdv9SNBtTvXcxIGRwK51W4Jdgh/xZcCAwEAAQ==",
            };

            var keys = new List<JsonWebKey>() { jwk };

            var app = new OpenIdConnectApplication
            {
                Name = "oidc_client",
                SignOnMode = "OPENID_CONNECT",
                Label = $"dotnet-sdk: AddOpenIdConnectApp {guid}",
                Credentials = new OAuthApplicationCredentials()
                {
                    OauthClient = new ApplicationCredentialsOAuthClient()
                    {
                        ClientId = testClientId,
                        TokenEndpointAuthMethod = "client_secret_post",
                        AutoKeyRotation = true,
                    },
                },
                Settings = new OpenIdConnectApplicationSettings
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient()
                    {
                        ClientUri = "https://example.com/client",
                        LogoUri = "https://example.com/assets/images/logo-new.png",
                        ResponseTypes = new List<OAuthResponseType>
                        {
                            "token",
                            "id_token",
                            "code",
                        },
                        RedirectUris = new List<string>
                        {
                            "https://example.com/oauth2/callback",
                            "myapp://callback",
                        },
                        PostLogoutRedirectUris = new List<string>
                        {
                            "https://example.com/postlogout",
                            "myapp://postlogoutcallback",
                        },
                        GrantTypes = new List<OAuthGrantType>
                        {
                            "implicit",
                            "authorization_code",
                        },
                        ApplicationType = "native",

                        TosUri = "https://example.com/client/tos",
                        PolicyUri = "https://example.com/client/policy",
                    },
                }
            };

            app.Settings.OauthClient.Jwks = new OpenIdConnectApplicationSettingsClientKeys()
            {
                Keys = keys,
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app);

            try
            {
                var retrieved = await _applicationApi.GetApplicationAsync(createdApp.Id) as OpenIdConnectApplication;

                retrieved.Name.Should().Be(OpenIdConnectApplication.NameEnum.OidcClient);
                retrieved.Label.Should().Be($"dotnet-sdk: AddOpenIdConnectApp {guid}");
                retrieved.SignOnMode.Value.Should().Be("OPENID_CONNECT");
                retrieved.Credentials.OauthClient.ClientId.Should().Be(testClientId);
                retrieved.Credentials.OauthClient.AutoKeyRotation.Should().BeTrue();
                retrieved.Credentials.OauthClient.TokenEndpointAuthMethod.Should()
                    .Be(OAuthEndpointAuthenticationMethod.ClientSecretPost);

                retrieved.Settings.OauthClient.ClientUri.Should().Be("https://example.com/client");
                retrieved.Settings.OauthClient.LogoUri.Should().Be("https://example.com/assets/images/logo-new.png");
                retrieved.Settings.OauthClient.RedirectUris.Should().HaveCount(2);
                retrieved.Settings.OauthClient.RedirectUris.First().Should().Be("https://example.com/oauth2/callback");
                retrieved.Settings.OauthClient.RedirectUris.Last().Should().Be("myapp://callback");
                retrieved.Settings.OauthClient.PostLogoutRedirectUris.Should().HaveCount(2);
                retrieved.Settings.OauthClient.PostLogoutRedirectUris.First().Should()
                    .Be("https://example.com/postlogout");
                retrieved.Settings.OauthClient.PostLogoutRedirectUris.Last().Should().Be("myapp://postlogoutcallback");

                retrieved.Settings.OauthClient.ResponseTypes.Should().HaveCount(3);
                retrieved.Settings.OauthClient.ResponseTypes.First().Value.Should().Be("token");
                retrieved.Settings.OauthClient.ResponseTypes.Should().Contain(OAuthResponseType.IdToken);
                retrieved.Settings.OauthClient.ResponseTypes.Should().Contain(OAuthResponseType.Code);

                retrieved.Settings.OauthClient.GrantTypes.Should().HaveCount(2);
                retrieved.Settings.OauthClient.GrantTypes.First().Value.Should().Be("implicit");
                retrieved.Settings.OauthClient.GrantTypes.Last().Should().Be(OAuthGrantType.AuthorizationCode);
                retrieved.Settings.OauthClient.ApplicationType.Should().Be(OpenIdConnectApplicationType.Native);
                // retrieved.Settings.OauthClient.TosUri.Should().Be("https://example.com/client/tos");  // There appears to be a bug in the API causing this value not to be returned.

                retrieved.Settings.OauthClient.Jwks.Keys.Should().NotBeNullOrEmpty();
                retrieved.Settings.OauthClient.Jwks.Keys.FirstOrDefault().Alg.Should().Be(jwk.Alg);
                retrieved.Settings.OauthClient.Jwks.Keys.FirstOrDefault().Kty.Should().Be("RSA");
                retrieved.Settings.OauthClient.Jwks.Keys.FirstOrDefault().E.Should().Be(jwk.E);
                retrieved.Settings.OauthClient.Jwks.Keys.FirstOrDefault().N.Should().Be(jwk.N);
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task GetApplication()
        {

            var guid = Guid.NewGuid();

            var app = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: GetBasicAuthenticationApp {guid}",
                SignOnMode = "BASICAUTH",
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app);
            Thread.Sleep(3000);
            try
            {
                var retrievedById = await _applicationApi.GetApplicationAsync(createdApp.Id);
                retrievedById.Id.Should().Be(createdApp.Id);
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }


        private async Task CreateRandomApp(ConcurrentBag<Application> createdApps)
        {
            var guid = Guid.NewGuid();

            var app = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: CreateRandomApp {guid}",
                SignOnMode = "BASICAUTH",
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

           var createdApp = await _applicationApi.CreateApplicationAsync(app);
           createdApps.Add(createdApp);

        }

        [Fact]
        public async Task EnumerateCollectionManually()
        {
            var successful = true;
            var createdApps = new ConcurrentBag<Application>();

            try
            {
                // Create 10 users (in parallel)
                var tasks = new List<Task>();
                for (var i = 0; i < 2; i++)
                {
                    tasks.Add(CreateRandomApp(createdApps));
                }

                await Task.WhenAll(tasks);

                // Alright, all set up. Try enumerating users by pages of 2:
                var retrievedApps = new List<Application>();
                
                var appsCollectionClient = _applicationApi.ListApplications(limit: 1/*, q: "label startsWith \"dotnet-sdk: CreateRandomApp\""*/);

                var enumerator = appsCollectionClient.GetAsyncEnumerator();

                while (await enumerator.MoveNextAsync())
                {
                    if (enumerator.Current.Label.Contains("CreateRandomApp", StringComparison.InvariantCultureIgnoreCase))
                    {
                        retrievedApps.Add(enumerator.Current);
                    }
                }

                retrievedApps.Count.Should().Be(2);
            }
            catch (Exception e)
            {
                successful = false;
            }
            finally
            {
                foreach (var app in createdApps)
                {
                    await _applicationApi.DeactivateApplicationAsync(app.Id);
                    await _applicationApi.DeleteApplicationAsync(app.Id);
                }
            }

            successful.Should().BeTrue();
        }

        [Fact]
        public async Task EnumerateCollectionPageManually()
        {
            var successful = true;
            var createdApps = new ConcurrentBag<Application>();

            try
            {
                // Create 10 users (in parallel)
                var tasks = new List<Task>();
                for (var i = 0; i < 2; i++)
                {
                    tasks.Add(CreateRandomApp(createdApps));
                }

                await Task.WhenAll(tasks);

                // Alright, all set up. Try enumerating users by pages of 2:
                var retrievedApps = new List<Application>();

                var appsCollectionClient = _applicationApi.ListApplications(limit: 1/*, q: "label startsWith \"dotnet-sdk: CreateRandomApp\""*/);

                var enumerator = appsCollectionClient.GetPagedEnumerator();

                while (await enumerator.MoveNextAsync())
                {
                    
                    retrievedApps.AddRange(enumerator.CurrentPage.Items.Where(x => x.Label.Contains("CreateRandomApp", StringComparison.InvariantCultureIgnoreCase)).ToList());
                    
                }

                retrievedApps.Count.Should().Be(2);
            }
            catch (Exception e)
            {
                successful = false;
            }
            finally
            {
                foreach (var app in createdApps)
                {
                    await _applicationApi.DeactivateApplicationAsync(app.Id);
                    await _applicationApi.DeleteApplicationAsync(app.Id);
                }
            }

            successful.Should().BeTrue();
        }

        [Fact]
        public async Task ListApplications()
        {

            var guid = Guid.NewGuid();

            var app = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: ListApps {guid}",
                SignOnMode = "BASICAUTH",
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app);

            try
            {
                var appList = await _applicationApi.ListApplications(limit:1).ToListAsync();
                appList.Any(a => a.Id == createdApp.Id).Should().BeTrue();
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task UpdateSWAApplicationAdminSetUsernameAndPassword()
        {
            var app = new BrowserPluginApplication
            {
                Label = $"dotnet-sdk: UpdateSWAApplicationAdminSetUsernameAndPassword {Guid.NewGuid()}",
                SignOnMode = ApplicationSignOnMode.BROWSERPLUGIN,
                Name = "template_swa",
                Settings = new SwaApplicationSettings
                {
                    App = new SwaApplicationSettingsApplication
                    {
                        ButtonField = "btn-login",
                        PasswordField = "txtbox-password",
                        UsernameField = "txtbox-username",
                        Url = "https://example.com/login.html",
                        LoginUrlRegex = "^https://example.com/login.html",
                    }
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app);

            try
            {
                var retrieved = await _applicationApi.GetApplicationAsync(createdApp.Id) as BrowserPluginApplication ;

                // Checking defaults
                retrieved.Credentials.Scheme.Should().Be(ApplicationCredentialsScheme.EDITUSERNAMEANDPASSWORD);
                retrieved.Credentials.UserNameTemplate.Template.Should().Be("${source.login}");
                retrieved.Credentials.UserNameTemplate.Type.Should().Be("BUILT_IN");

                var schemeAppCredentials = new SchemeApplicationCredentials()
                {
                    Scheme = "ADMIN_SETS_CREDENTIALS",
                    UserNameTemplate = new ApplicationCredentialsUsernameTemplate()
                    {
                        Template = "${source.login}",
                        Type = "BUILT_IN",
                    },
                };

                retrieved.Credentials.Scheme = "ADMIN_SETS_CREDENTIALS";
                retrieved.Credentials.UserNameTemplate.Template = "${source.login}";
                retrieved.Credentials.UserNameTemplate.Type = "BUILT_IN";

                retrieved = await _applicationApi.ReplaceApplicationAsync(retrieved.Id, retrieved) as BrowserPluginApplication;

                retrieved.Credentials.Scheme.Should().Be(ApplicationCredentialsScheme.ADMINSETSCREDENTIALS);
                retrieved.Credentials.UserNameTemplate.Template.Should().Be("${source.login}");
                retrieved.Credentials.UserNameTemplate.Type.Should().Be("BUILT_IN");
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task UpdateSWAApplicationSetUserEditablePassword()
        {
            var app = new BrowserPluginApplication
            {
                Label = $"dotnet-sdk: UpdateSWAApplicationSetUserEditablePassword {Guid.NewGuid()}",
                SignOnMode = ApplicationSignOnMode.BROWSERPLUGIN,
                Name = "template_swa",
                Settings = new SwaApplicationSettings
                {
                    App = new SwaApplicationSettingsApplication
                    {
                        ButtonField = "btn-login",
                        PasswordField = "txtbox-password",
                        UsernameField = "txtbox-username",
                        Url = "https://example.com/login.html",
                        LoginUrlRegex = "^https://example.com/login.html",
                    }
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app);

            try
            {
                var retrieved = await _applicationApi.GetApplicationAsync(createdApp.Id) as BrowserPluginApplication;

                // Checking defaults
                retrieved.Credentials.Scheme.Should().Be(ApplicationCredentialsScheme.EDITUSERNAMEANDPASSWORD);
                retrieved.Credentials.UserNameTemplate.Template.Should().Be("${source.login}");
                retrieved.Credentials.UserNameTemplate.Type.Should().Be("BUILT_IN");

                retrieved.Credentials.Scheme = ApplicationCredentialsScheme.EDITPASSWORDONLY;
                retrieved.Credentials.UserNameTemplate.Template = "${source.login}";
                retrieved.Credentials.UserNameTemplate.Type = "BUILT_IN";

                retrieved = await _applicationApi.ReplaceApplicationAsync(retrieved.Id, retrieved) as BrowserPluginApplication;

                retrieved.Credentials.Scheme.Should().Be(ApplicationCredentialsScheme.EDITPASSWORDONLY);
                retrieved.Credentials.UserNameTemplate.Template.Should().Be("${source.login}");
                retrieved.Credentials.UserNameTemplate.Type.Should().Be("BUILT_IN");
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task UpdateSWAApplicationSetSharedCredentials()
        {

            var app = new BrowserPluginApplication
            {
                Label = $"dotnet-sdk: UpdateSWAApplicationSetSharedCredentials {Guid.NewGuid()}",
                SignOnMode = ApplicationSignOnMode.BROWSERPLUGIN,
                Name = "template_swa",
                Settings = new SwaApplicationSettings
                {
                    App = new SwaApplicationSettingsApplication
                    {
                        ButtonField = "btn-login",
                        PasswordField = "txtbox-password",
                        UsernameField = "txtbox-username",
                        Url = "https://example.com/login.html",
                        LoginUrlRegex = "^https://example.com/login.html",
                    }
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app);

            try
            {
                var retrieved = await _applicationApi.GetApplicationAsync(createdApp.Id) as BrowserPluginApplication;

                // Checking defaults
                retrieved.Credentials.Scheme.Should().Be(ApplicationCredentialsScheme.EDITUSERNAMEANDPASSWORD);
                retrieved.Credentials.UserNameTemplate.Template.Should().Be("${source.login}");
                retrieved.Credentials.UserNameTemplate.Type.Should().Be("BUILT_IN");

                retrieved.Credentials.Scheme = ApplicationCredentialsScheme.SHAREDUSERNAMEANDPASSWORD;
                retrieved.Credentials.UserNameTemplate.Template = "${source.login}";
                retrieved.Credentials.UserNameTemplate.Type = "BUILT_IN";
                retrieved.Credentials.UserName = "sharedusername";
                retrieved.Credentials.Password = new PasswordCredential() { Value = "sharedpassword" };

                retrieved = await _applicationApi.ReplaceApplicationAsync(retrieved.Id, retrieved) as BrowserPluginApplication;

                retrieved.Credentials.Scheme.Should().Be(ApplicationCredentialsScheme.SHAREDUSERNAMEANDPASSWORD);
                retrieved.Credentials.UserNameTemplate.Template.Should().Be("${source.login}");
                retrieved.Credentials.UserNameTemplate.Type.Should().Be("BUILT_IN");
                retrieved.Credentials.UserName.Should().Be("sharedusername");
                retrieved.Credentials.Password.Value.Should().BeNullOrEmpty();
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task NotDeleteActiveApplication()
        {

            var app = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: NotDeleteActiveApplication {Guid.NewGuid()}",
                SignOnMode = "BASICAUTH",
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app);

            try
            {
                // Deleting by ID should result in 403 Forbidden
                await Assert.ThrowsAsync<ApiException>(async () =>
                    await _applicationApi.DeleteApplicationAsync(createdApp.Id));
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task DeleteDeactivatedApplication()
        {
            var app = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: DeleteDeactivatedApplication {Guid.NewGuid()}",
                SignOnMode = "BASICAUTH",
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app);

            var appId = createdApp.Id;

            await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
            await _applicationApi.DeleteApplicationAsync(createdApp.Id);

            // Getting by ID should result in 404 Not found
            await Assert.ThrowsAsync<ApiException>(async () => await _applicationApi.GetApplicationAsync(appId));
        }

        [Fact]
        public async Task ActivateApplication()
        {
            var app = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: ActivateApplication {Guid.NewGuid()}",
                SignOnMode = ApplicationSignOnMode.BASICAUTH,
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app, false);
            try
            {
                var retrievedApp = await _applicationApi.GetApplicationAsync(createdApp.Id);
                retrievedApp.Status.Should().Be(ApplicationLifecycleStatus.INACTIVE);

                await _applicationApi.ActivateApplicationAsync(createdApp.Id);
                retrievedApp = await _applicationApi.GetApplicationAsync(createdApp.Id);
                retrievedApp.Status.Value.Should().Be("ACTIVE");
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task CreateActiveApplication()
        {
            var app = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: CreateActiveApplication {Guid.NewGuid()}",
                SignOnMode = "BASICAUTH",
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app, true);

            try
            {
                var retrievedApp = await _applicationApi.GetApplicationAsync(createdApp.Id);
                retrievedApp.Status.Value.Should().Be("ACTIVE");
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task CreateAssignUserForSSOApplication()
        {
            var guid = Guid.NewGuid();

            var userRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Okta",
                    Email = $"john-sso-dotnet-sdk-{guid}@example.com",
                    Login = $"john-sso-dotnet-sdk-{guid}@example.com",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Okta1234",
                    }
                },
            };

            // Create a user
            var createdUser = await _userApi.CreateUserAsync(userRequest, true);


            var app = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: CreateAssignUserForSSOApplication {Guid.NewGuid()}",
                SignOnMode = "BASICAUTH",
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app, true);

            var appUser = new AppUserAssignRequest()
            {
                Id = createdUser.Id,

                Credentials = new AppUserCredentials()
                {
                    Password = new AppUserPasswordCredential() { Value = "Okta1234" },
                    UserName = createdUser.Profile.Email,
                },
            };

            try
            {
                var createdAppUser = await _applicationUsersApi.AssignUserToApplicationAsync(createdApp.Id, appUser);

                // TODO: Revisit Enum
                createdAppUser.Scope.Should().Be(AppUser.ScopeEnum.USER);
                createdAppUser.Credentials.UserName.Should().Be($"john-sso-dotnet-sdk-{guid}@example.com");
                createdAppUser.Status.Value.Should().Be("ACTIVE");
                createdAppUser.SyncState.Value.Should().Be("DISABLED");
            }
            finally
            {
                // Remove the user
                await _userApi.DeactivateUserAsync(createdUser.Id);
                await _userApi.DeleteUserAsync(createdUser.Id);

                // Remove App
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task GetAssignedUsersForApplication()
        {
            var guid = Guid.NewGuid();
            var userId = string.Empty;
            var appId = string.Empty;
            
            try
            {
                var userRequest = new CreateUserRequest
                {
                    Profile = new UserProfile
                    {
                        FirstName = "John",
                        LastName = "Okta",
                        Email = $"john-assigned-user-dotnet-sdk-{guid}@example.com",
                        Login = $"john-assigned-user-dotnet-sdk-{guid}@example.com",
                    },
                    Credentials = new UserCredentials
                    {
                        Password = new PasswordCredential
                        {
                            Value = "Okta1234",
                        }
                    },
                };

                // Create a user
                var createdUser = await _userApi.CreateUserAsync(userRequest, true);
                userId = createdUser.Id;

                var app = new BasicAuthApplication
                {
                    Name = "template_basic_auth",
                    Label = $"dotnet-sdk: CreateAssignUserForSSOApplication {Guid.NewGuid()}",
                    SignOnMode = "BASICAUTH",
                    Settings = new BasicApplicationSettings
                    {
                        App = new BasicApplicationSettingsApplication
                        {
                            Url = "https://example.com/login.html",
                            AuthURL = "https://example.com/auth.html",
                        },
                    },
                };

                var createdApp = await _applicationApi.CreateApplicationAsync(app, true);
                appId = createdApp.Id;

                var appUser = new AppUserAssignRequest()
                {
                    Id = createdUser.Id,

                    Credentials = new AppUserCredentials()
                    {
                        Password = new AppUserPasswordCredential() { Value = "Okta1234" },
                        UserName = createdUser.Profile.Email,
                    },
                };


                var createdAppUser = await _applicationUsersApi.AssignUserToApplicationAsync(createdApp.Id, appUser);
                var retrievedAppUser = await _applicationUsersApi.GetApplicationUserAsync(createdApp.Id, createdUser.Id);

                retrievedAppUser.Should().NotBeNull();
                retrievedAppUser.Id.Should().Be(createdAppUser.Id);
                retrievedAppUser.Scope.Should().Be(AppUser.ScopeEnum.USER);
                retrievedAppUser.Credentials.UserName.Should().Be($"john-assigned-user-dotnet-sdk-{guid}@example.com");
            }
            finally
            {
                if (!string.IsNullOrEmpty(userId))
                {
                    // Remove the user
                    await _userApi.DeactivateUserAsync(userId);
                    await _userApi.DeleteUserAsync(userId);
                }

                if (!string.IsNullOrEmpty(appId))
                {
                    // Remove App
                    await _applicationApi.DeactivateApplicationAsync(appId);
                    await _applicationApi.DeleteApplicationAsync(appId);
                }
            }
        }

        [Fact]
        public async Task GetAssignedUsersWithoutCredentialsForApplication()
        {
            var guid = Guid.NewGuid();
            var userId = string.Empty;
            var appId = string.Empty;

            try
            {
                var userRequest = new CreateUserRequest
                {
                    Profile = new UserProfile
                    {
                        FirstName = "John",
                        LastName = "Okta",
                        Email = $"john-assigned-user-dotnet-sdk-no-creds-{guid}@example.com",
                        Login = $"john-assigned-user-dotnet-sdk-no-creds-{guid}@example.com",
                    },
                };

                // Create a user
                var createdUser = await _userApi.CreateUserAsync(userRequest, true);
                userId = createdUser.Id;

                var app = new BasicAuthApplication
                {
                    Name = "template_basic_auth",
                    Label = $"dotnet-sdk: CreateAssignUserForSSOApplication {Guid.NewGuid()}",
                    SignOnMode = "BASICAUTH",
                    Settings = new BasicApplicationSettings
                    {
                        App = new BasicApplicationSettingsApplication
                        {
                            Url = "https://example.com/login.html",
                            AuthURL = "https://example.com/auth.html",
                        },
                    },
                };

                var createdApp = await _applicationApi.CreateApplicationAsync(app, true);
                appId = createdApp.Id;

                var appUser = new AppUserAssignRequest
                {
                    Id = createdUser.Id,

                    Credentials = new AppUserCredentials()
                    {
                        UserName = createdUser.Profile.Email,
                    },
                };

                var createdAppUser = await _applicationUsersApi.AssignUserToApplicationAsync(createdApp.Id, appUser);
                var retrievedAppUser = await _applicationUsersApi.GetApplicationUserAsync(createdApp.Id, createdUser.Id);

                retrievedAppUser.Should().NotBeNull();
                retrievedAppUser.Id.Should().Be(createdAppUser.Id);
                retrievedAppUser.Scope.Should().Be(AppUser.ScopeEnum.USER);
                retrievedAppUser.Credentials.UserName.Should().Be($"john-assigned-user-dotnet-sdk-no-creds-{guid}@example.com");
                retrievedAppUser.PasswordChanged.Should().BeNull();
            }
            finally
            {
                if (!string.IsNullOrEmpty(userId))
                {
                    // Remove the user
                    await _userApi.DeactivateUserAsync(userId);
                    await _userApi.DeleteUserAsync(userId);
                }

                if (!string.IsNullOrEmpty(appId))
                {
                    // Remove App
                    await _applicationApi.DeactivateApplicationAsync(appId);
                    await _applicationApi.DeleteApplicationAsync(appId);
                }
            }
        }

        [Fact]
        public async Task ListUsersForApplication()
        {
            var guid = Guid.NewGuid();

            var userRequest1 = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Okta",
                    Email = $"john-list-users-dotnet-sdk-{guid}@example.com",
                    Login = $"john-list-users-dotnet-sdk-{guid}@example.com",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Okta1234",
                    }
                },
            };

            // Create a user
            var createdUser1 = await _userApi.CreateUserAsync(userRequest1, true);

            var userRequest2 = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "Bob",
                    LastName = "Okta",
                    Email = $"bob-list-users-dotnet-sdk-{guid}@example.com",
                    Login = $"bob-list-users-dotnet-sdk-{guid}@example.com",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Okta1234",
                    }
                },
            };

            // Create a user
            var createdUser2 = await _userApi.CreateUserAsync(userRequest2, true);

            var app = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: ListUsersForApplication {Guid.NewGuid()}",
                SignOnMode = "BASICAUTH",
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app, true);

            var appUser1 = new AppUserAssignRequest()
            {
                Id = createdUser1.Id,

                Credentials = new AppUserCredentials()
                {
                    Password = new AppUserPasswordCredential() { Value = "Okta1234" },
                    UserName = createdUser1.Profile.Email,
                },
            };

            var appUser2 = new AppUserAssignRequest()
            {
                Id = createdUser2.Id,

                Credentials = new AppUserCredentials()
                {
                    Password = new AppUserPasswordCredential() { Value = "Okta1234" },
                    UserName = createdUser2.Profile.Email,
                },
            };

            try
            {
                var createdAppUser1 = await _applicationUsersApi.AssignUserToApplicationAsync(createdApp.Id, appUser1);
                var createdAppUser2 = await _applicationUsersApi.AssignUserToApplicationAsync(createdApp.Id, appUser2);

                var appUserList = await _applicationUsersApi.ListApplicationUsers(createdApp.Id).ToListAsync();

                appUserList.Should().NotBeNullOrEmpty();
                appUserList.Should().HaveCount(2);
                appUserList.FirstOrDefault(x => x.Credentials.UserName == createdUser1.Profile.Email).Should()
                    .NotBeNull();
                appUserList.FirstOrDefault(x => x.Credentials.UserName == createdUser2.Profile.Email).Should()
                    .NotBeNull();
            }
            finally
            {
                // Remove the user
                await _userApi.DeactivateUserAsync(createdUser1.Id);
                await _userApi.DeleteUserAsync(createdUser1.Id);
                await _userApi.DeactivateUserAsync(createdUser2.Id);
                await _userApi.DeleteUserAsync(createdUser2.Id);

                // Remove App
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task UpdateApplicationCredentialsForAssignedUser()
        {
            var guid = Guid.NewGuid();

            var userRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Okta",
                    Email = $"john-update-creds-dotnet-sdk-{guid}@example.com",
                    Login = $"john-update-creds-dotnet-sdk-{guid}@example.com",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Okta1234",
                    }
                },
            };

            // Create a user
            var createdUser = await _userApi.CreateUserAsync(userRequest, true);


            var app = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: CreateAssignUserForSSOApplication {Guid.NewGuid()}",
                SignOnMode = "BASICAUTH",
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app, true);

            var appUser = new AppUserAssignRequest()
            {
                Id = createdUser.Id,

                Credentials = new AppUserCredentials()
                {
                    Password = new AppUserPasswordCredential() { Value = "Okta1234" },
                    UserName = createdUser.Profile.Email,
                },
            };

            try
            {
                var createdAppUser = await _applicationUsersApi.AssignUserToApplicationAsync(createdApp.Id, appUser);
                var retrievedAppUser = await _applicationUsersApi.GetApplicationUserAsync(createdApp.Id, createdUser.Id);

                retrievedAppUser.Should().NotBeNull();
                retrievedAppUser.Id.Should().Be(createdAppUser.Id);
                retrievedAppUser.Scope.Should().Be(AppUser.ScopeEnum.USER);
                retrievedAppUser.Credentials.UserName.Should().Be($"john-update-creds-dotnet-sdk-{guid}@example.com");

                // Update credentials
                var appUserCredentialsRequestPayload = new AppUserCredentialsRequestPayload
                {
                    Credentials = new AppUserCredentials()
                    {
                        UserName = "$john-update-creds-updated-dotnet-sdk-{guid}@example.com",
                        Password = new AppUserPasswordCredential() { Value = "Okta12345" }
                    }
                };
                
                var appUserUpdateRequest = new AppUserUpdateRequest(appUserCredentialsRequestPayload);
                var updatedAppUser =
                    await _applicationUsersApi.UpdateApplicationUserAsync(createdApp.Id, createdUser.Id, appUserUpdateRequest);

                updatedAppUser.Should().NotBeNull();
                updatedAppUser.Credentials.UserName.Should()
                    .Be("$john-update-creds-updated-dotnet-sdk-{guid}@example.com");
            }
            finally
            {
                // Remove the user
                await _userApi.DeactivateUserAsync(createdUser.Id);
                await _userApi.DeleteUserAsync(createdUser.Id);

                // Remove App
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task RemoveUserForApplication()
        {
            var guid = Guid.NewGuid();

            var userRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Okta",
                    Email = $"john-remove-user-dotnet-sdk-{guid}@example.com",
                    Login = $"john-remove-user-dotnet-sdk-{guid}@example.com",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Okta1234",
                    }
                },
            };

            // Create a user
            var createdUser = await _userApi.CreateUserAsync(userRequest, true);


            var app = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: RemoveUserForApplication {Guid.NewGuid()}",
                SignOnMode = "BASICAUTH",
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app, true);

            var appUser = new AppUserAssignRequest()
            {
                Id = createdUser.Id,

                Credentials = new AppUserCredentials()
                {
                    Password = new AppUserPasswordCredential() { Value = "Okta1234" },
                    UserName = createdUser.Profile.Email,
                },
            };

            try
            {
                var createdAppUser = await _applicationUsersApi.AssignUserToApplicationAsync(createdApp.Id, appUser);
                var retrievedAppUser = await _applicationUsersApi.GetApplicationUserAsync(createdApp.Id, createdUser.Id);

                retrievedAppUser.Should().NotBeNull();
                retrievedAppUser.Id.Should().Be(createdAppUser.Id);
                retrievedAppUser.Scope.Should().Be(AppUser.ScopeEnum.USER);
                retrievedAppUser.Credentials.UserName.Should().Be($"john-remove-user-dotnet-sdk-{guid}@example.com");

                await _applicationUsersApi.UnassignUserFromApplicationAsync(createdApp.Id, createdUser.Id);

                var appUserList = await _applicationUsersApi.ListApplicationUsers(createdApp.Id).ToListAsync();
                appUserList.Should().BeNullOrEmpty();
            }
            finally
            {
                // Remove the user
                await _userApi.DeactivateUserAsync(createdUser.Id);
                await _userApi.DeleteUserAsync(createdUser.Id);

                // Remove App
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task AssignGroupForApplication()
        {
            var guid = Guid.NewGuid();

            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: AssignGroupForApplication {guid}",
                }
            };

            var createdGroup = await _groupApi.CreateGroupAsync(group);


            var app = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: AssignGroupForApplication {Guid.NewGuid()}",
                SignOnMode = "BASICAUTH",
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app, true);

            try
            {
                var groupAssignment = new ApplicationGroupAssignment
                {
                    Priority = 0,
                };

                var createdAppGroup =
                    await _applicationGroupApi.AssignGroupToApplicationAsync(createdApp.Id, createdGroup.Id,
                        groupAssignment);
                createdAppGroup.Should().NotBeNull();
                createdAppGroup.Priority.Should().Be(0);
            }
            finally
            {
                // Remove the user
                await _groupApi.DeleteGroupAsync(createdGroup.Id);

                // Remove App
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task GetAssignmentGroupForApplication()
        {
            var guid = Guid.NewGuid();

            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: GetAssignmentGroupForApplication {guid}",
                }
            };

            var createdGroup = await _groupApi.CreateGroupAsync(group);


            var app = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: AssignGroupForApplication {Guid.NewGuid()}",
                SignOnMode = "BASICAUTH",
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app, true);

            Thread.Sleep(3000);

            try
            {
                var groupAssignment = new ApplicationGroupAssignment
                {
                    Priority = 0,
                };

                var createdAppGroup =
                    await _applicationGroupApi.AssignGroupToApplicationAsync(createdApp.Id, createdGroup.Id,
                        groupAssignment);
                var retrievedAppGroup =
                    await _applicationGroupApi.GetApplicationGroupAssignmentAsync(createdApp.Id, createdGroup.Id);

                retrievedAppGroup.Should().NotBeNull();
                retrievedAppGroup.Priority.Should().Be(0);
            }
            finally
            {
                // Remove the user
                await _groupApi.DeleteGroupAsync(createdGroup.Id);

                // Remove App
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task ListAssignmentGroupsForApplication()
        {
            var guid = Guid.NewGuid();

            var group1 = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: ListAssignmentGroupsForApplication1 {guid}",
                }
            };

            var createdGroup1 = await _groupApi.CreateGroupAsync(group1);

            var group2 = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: ListAssignmentGroupsForApplication2 {guid}",
                }
            };

            var createdGroup2 = await _groupApi.CreateGroupAsync(group2);


            var app = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: AssignGroupForApplication {Guid.NewGuid()}",
                SignOnMode = "BASICAUTH",
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app, true);

            try
            {
                var groupAssignment = new ApplicationGroupAssignment
                {
                    Priority = 0,
                };

                var createdAppGroup1 =
                    await _applicationGroupApi.AssignGroupToApplicationAsync(createdApp.Id, createdGroup1.Id,
                        groupAssignment);
                var createdAppGroup2 =
                    await _applicationGroupApi.AssignGroupToApplicationAsync(createdApp.Id, createdGroup2.Id,
                        groupAssignment);

                var groupAssignmentList = await _applicationGroupApi.ListApplicationGroupAssignments(createdApp.Id).ToListAsync();

                groupAssignmentList.Should().NotBeNullOrEmpty();
                groupAssignmentList.Should().HaveCount(2);
                groupAssignmentList.FirstOrDefault(x => x.Id == createdAppGroup1.Id).Should().NotBeNull();
                groupAssignmentList.FirstOrDefault(x => x.Id == createdAppGroup2.Id).Should().NotBeNull();
            }
            finally
            {
                await _groupApi.DeleteGroupAsync(createdGroup1.Id);
                await _groupApi.DeleteGroupAsync(createdGroup2.Id);

                // Remove App
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }


        [Fact]
        public async Task RemoveGroupForApplication()
        {
            var guid = Guid.NewGuid();

            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: AssignGroupForApplication {guid}",
                }
            };

            var createdGroup = await _groupApi.CreateGroupAsync(group);


            var app = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: RemoveGroupForApplication {Guid.NewGuid()}",
                SignOnMode = "BASICAUTH",
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app, true);

            try
            {
                var groupAssignment = new ApplicationGroupAssignment
                {
                    Priority = 0,
                };

                var createdAppGroup =
                    await _applicationGroupApi.AssignGroupToApplicationAsync(createdApp.Id, createdGroup.Id,
                        groupAssignment);
                createdAppGroup.Should().NotBeNull();

                await _applicationGroupApi.UnassignApplicationFromGroupAsync(createdApp.Id, createdGroup.Id);

                var assignments = await _applicationGroupApi.ListApplicationGroupAssignments(createdApp.Id).ToListAsync();
                assignments.Should().BeNullOrEmpty();
            }
            finally
            {
                // Remove the user
                await _groupApi.DeleteGroupAsync(createdGroup.Id);

                // Remove App
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task ListApplicationKeyCredentials()
        {
            var guid = Guid.NewGuid();

            var app = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: ListApplicationKeyCredentials {Guid.NewGuid()}",
                SignOnMode = "BASICAUTH",
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app, true);

            try
            {
                var appKeys = await _applicationCredentialsApi.ListApplicationKeys(createdApp.Id).ToListAsync();

                // A key is created by default
                appKeys.Should().NotBeNull();
                appKeys.Should().HaveCount(1);
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task GetApplicationKeyCredentials()
        {
            var guid = Guid.NewGuid();

            var app = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: GetApplicationKeyCredentials {Guid.NewGuid()}",
                SignOnMode = "BASICAUTH",
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app, true);

            try
            {
                var appKeys = await _applicationCredentialsApi.ListApplicationKeys(createdApp.Id).ToListAsync();
                var defaultAppKey = appKeys.First();
                var retrievedAppKey = await _applicationCredentialsApi.GetApplicationKeyAsync(createdApp.Id, defaultAppKey.Kid);

                retrievedAppKey.Should().NotBeNull();
                retrievedAppKey.Kid.Should().Be(defaultAppKey.Kid);
                retrievedAppKey.Created.Should().Be(defaultAppKey.Created);
                retrievedAppKey.ExpiresAt.Should().Be(defaultAppKey.ExpiresAt);
                retrievedAppKey.X5c.Should().BeEquivalentTo(defaultAppKey.X5c);
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task GenerateApplicationKey()
        {
            var guid = Guid.NewGuid();

            var app = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: GenerateApplicationKey {Guid.NewGuid()}",
                SignOnMode = "BASICAUTH",
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app, true);

            try
            {
                var generatedKey = await _applicationCredentialsApi.GenerateApplicationKeyAsync(createdApp.Id, 2);
                
                var retrievedAppKey = await _applicationCredentialsApi.GetApplicationKeyAsync(createdApp.Id, generatedKey.Kid);

                retrievedAppKey.Should().NotBeNull();
                retrievedAppKey.Kid.Should().Be(generatedKey.Kid);
                retrievedAppKey.Created.Should().Be(generatedKey.Created);
                retrievedAppKey.ExpiresAt.Should().Be(generatedKey.ExpiresAt);
                retrievedAppKey.X5c.Should().BeEquivalentTo(generatedKey.X5c);
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task CloneApplicationKey()
        {
            var guid = Guid.NewGuid();

            var app1 = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: CloneApplicationKey1 {Guid.NewGuid()}",
                SignOnMode = "BASICAUTH",
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

            var createdApp1 = await _applicationApi.CreateApplicationAsync(app1, true);

            var app2 = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: CloneApplicationKey1 {Guid.NewGuid()}",
                SignOnMode = "BASICAUTH",
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

            var createdApp2 = await _applicationApi.CreateApplicationAsync(app1, true);

            try
            {
                var generatedKey1 = await _applicationCredentialsApi.GenerateApplicationKeyAsync(createdApp1.Id, 2);
                var clonedKey2 = await _applicationCredentialsApi.CloneApplicationKeyAsync(createdApp1.Id, generatedKey1.Kid, createdApp2.Id);
                
                clonedKey2.Should().NotBeNull();
                clonedKey2.Kid.Should().Be(generatedKey1.Kid);
                clonedKey2.ExpiresAt.Should().Be(generatedKey1.ExpiresAt);
                clonedKey2.X5c.Should().BeEquivalentTo(generatedKey1.X5c);
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp1.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp1.Id);

                await _applicationApi.DeactivateApplicationAsync(createdApp2.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp2.Id);
            }
        }

        [Fact]
        public async Task GenerateCsr()
        {
            var guid = Guid.NewGuid();

            var app = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: GenerateCsr {Guid.NewGuid()}",
                SignOnMode = "BASICAUTH",
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app, true);

            try
            {
                var csrMetadata = new CsrMetadata
                {
                    Subject = new CsrMetadataSubject()
                    {
                        CountryName = "US",
                        StateOrProvinceName = "California",
                        LocalityName = "San Francisco",
                        OrganizationName = "Okta, Inc.",
                        OrganizationalUnitName = "Dev",
                        CommonName = "SP Issuer",
                    },
                    SubjectAltNames = new CsrMetadataSubjectAltNames()
                    {
                        DnsNames = new List<string>() { "dev.okta.com" },
                    },
                };

                var generatedCsr = await _applicationCredentialsApi.GenerateCsrForApplicationAsync(createdApp.Id, csrMetadata);

                generatedCsr.Should().NotBeNull();
                generatedCsr.Kty.Should().Be("RSA");
                // TODO: Review _Csr in the spec
                generatedCsr._Csr.Should().NotBeNullOrEmpty();
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task GetCsr()
        {
            var guid = Guid.NewGuid();

            var app = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: GetCsr {Guid.NewGuid()}",
                SignOnMode = "BASICAUTH",
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app, true);

            try
            {
                var csrMetadata = new CsrMetadata
                {
                    Subject = new CsrMetadataSubject()
                    {
                        CountryName = "US",
                        StateOrProvinceName = "California",
                        LocalityName = "San Francisco",
                        OrganizationName = "Okta, Inc.",
                        OrganizationalUnitName = "Dev",
                        CommonName = "SP Issuer",
                    },
                    SubjectAltNames = new CsrMetadataSubjectAltNames()
                    {
                        DnsNames = new List<string>() { "dev.okta.com" },
                    },
                };

                var generatedCsr = await _applicationCredentialsApi.GenerateCsrForApplicationAsync(createdApp.Id, csrMetadata);

                var retrievedCsr = await _applicationCredentialsApi.GetCsrForApplicationAsync(createdApp.Id, generatedCsr.Id);
                retrievedCsr.Should().NotBeNull();
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task RevokeCsr()
        {
            var guid = Guid.NewGuid();

            var app = new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = $"dotnet-sdk: RevokeCsr {Guid.NewGuid()}",
                SignOnMode = "BASICAUTH",
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthURL = "https://example.com/auth.html",
                    },
                },
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app, true);

            try
            {
                var csrMetadata = new CsrMetadata
                {
                    Subject = new CsrMetadataSubject()
                    {
                        CountryName = "US",
                        StateOrProvinceName = "California",
                        LocalityName = "San Francisco",
                        OrganizationName = "Okta, Inc.",
                        OrganizationalUnitName = "Dev",
                        CommonName = "SP Issuer",
                    },
                    SubjectAltNames = new CsrMetadataSubjectAltNames()
                    {
                        DnsNames = new List<string>() { "dev.okta.com" },
                    },
                };

                var generatedCsr = await _applicationCredentialsApi.GenerateCsrForApplicationAsync(createdApp.Id, csrMetadata);

                var csrList = await _applicationCredentialsApi.ListCsrsForApplication(createdApp.Id).ToListAsync();
                csrList.Any(x => x.Id == generatedCsr.Id).Should().BeTrue();

                await _applicationCredentialsApi.RevokeCsrFromApplicationAsync(createdApp.Id, generatedCsr.Id);

                csrList = await _applicationCredentialsApi.ListCsrsForApplication(createdApp.Id).ToListAsync();
                csrList.Any(x => x.Id == generatedCsr.Id).Should().BeFalse();
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task GrantConsentToScope()
        {
            var guid = Guid.NewGuid();
            var testClientId = $"{nameof(GrantConsentToScope)}_TestClientId";

            var app = new OpenIdConnectApplication
            {
                Name = "oidc_client",
                SignOnMode = "OPENID_CONNECT",
                Label = $"dotnet-sdk: AddOpenIdConnectApp {guid}",
                Credentials = new OAuthApplicationCredentials()
                {
                    OauthClient = new ApplicationCredentialsOAuthClient()
                    {
                        ClientId = testClientId,
                        TokenEndpointAuthMethod = "client_secret_post",
                        AutoKeyRotation = true,
                    },
                },
                Settings = new OpenIdConnectApplicationSettings
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient()
                    {
                        ClientUri = "https://example.com/client",
                        LogoUri = "https://example.com/assets/images/logo-new.png",
                        ResponseTypes = new List<OAuthResponseType>
                        {
                            "token",
                            "id_token",
                            "code",
                        },
                        RedirectUris = new List<string>
                        {
                            "https://example.com/oauth2/callback",
                            "myapp://callback",
                        },
                        PostLogoutRedirectUris = new List<string>
                        {
                            "https://example.com/postlogout",
                            "myapp://postlogoutcallback",
                        },
                        GrantTypes = new List<OAuthGrantType>
                        {
                            "implicit",
                            "authorization_code",
                        },
                        ApplicationType = "native",

                        TosUri = "https://example.com/client/tos",
                        PolicyUri = "https://example.com/client/policy",
                    },
                }
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app);

            try
            {

                var issuer = _applicationApi.Configuration.OktaDomain;
                issuer = issuer.EndsWith("/") ? issuer.Substring(0, issuer.Length - 1) : issuer;

                await _applicationGrantsApi.GrantConsentToScopeAsync(createdApp.Id, new OAuth2ScopeConsentGrant()
                {
                    Issuer = issuer,
                    ScopeId = "okta.users.read",
                });
                
                var appConsentGrants = await _applicationGrantsApi.ListScopeConsentGrants(createdApp.Id).ToListAsync();
                appConsentGrants.Should().NotBeNull();

                var retrievedConsent = appConsentGrants.FirstOrDefault(x => x.ScopeId == "okta.users.read" && x.Issuer == issuer);
                retrievedConsent.Should().NotBeNull();
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task RevokeConsentGrant()
        {
            var guid = Guid.NewGuid();
            var testClientId = $"{nameof(RevokeConsentGrant)}_TestClientId";

            var app = new OpenIdConnectApplication
            {
                Name = "oidc_client",
                SignOnMode = "OPENID_CONNECT",
                Label = $"dotnet-sdk: RevokeConsentGrant {guid}",
                Credentials = new OAuthApplicationCredentials()
                {
                    OauthClient = new ApplicationCredentialsOAuthClient()
                    {
                        ClientId = testClientId,
                        TokenEndpointAuthMethod = "client_secret_post",
                        AutoKeyRotation = true,
                    },
                },
                Settings = new OpenIdConnectApplicationSettings
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient()
                    {
                        ClientUri = "https://example.com/client",
                        LogoUri = "https://example.com/assets/images/logo-new.png",
                        ResponseTypes = new List<OAuthResponseType>
                        {
                            "token",
                            "id_token",
                            "code",
                        },
                        RedirectUris = new List<string>
                        {
                            "https://example.com/oauth2/callback",
                            "myapp://callback",
                        },
                        PostLogoutRedirectUris = new List<string>
                        {
                            "https://example.com/postlogout",
                            "myapp://postlogoutcallback",
                        },
                        GrantTypes = new List<OAuthGrantType>
                        {
                            "implicit",
                            "authorization_code",
                        },
                        ApplicationType = "native",

                        TosUri = "https://example.com/client/tos",
                        PolicyUri = "https://example.com/client/policy",
                    },
                }
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app);

            try
            {

                var issuer = _applicationApi.Configuration.OktaDomain;
                issuer = issuer.EndsWith("/") ? issuer.Substring(0, issuer.Length - 1) : issuer;

                // TODO: Review the spec. This method should return void
                await _applicationGrantsApi.GrantConsentToScopeAsync(createdApp.Id, new OAuth2ScopeConsentGrant()
                {
                    Issuer = issuer,
                    ScopeId = "okta.users.read",
                });

                var appConsentGrants = await _applicationGrantsApi.ListScopeConsentGrants(createdApp.Id).ToListAsync();
                var retrievedConsent = appConsentGrants.FirstOrDefault(x => x.ScopeId == "okta.users.read" && x.Issuer == issuer);
                retrievedConsent.Should().NotBeNull();

                await _applicationGrantsApi.RevokeScopeConsentGrantAsync(createdApp.Id, retrievedConsent.Id);

                appConsentGrants = await _applicationGrantsApi.ListScopeConsentGrants(createdApp.Id).ToListAsync();
                retrievedConsent = appConsentGrants.FirstOrDefault(x => x.ScopeId == "okta.users.read" && x.Issuer == issuer);
                retrievedConsent.Should().BeNull();
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task GetConsentGrant()
        {
            var guid = Guid.NewGuid();
            var testClientId = $"{nameof(GetConsentGrant)}_TestClientId";

            var app = new OpenIdConnectApplication
            {
                Name = "oidc_client",
                SignOnMode = "OPENID_CONNECT",
                Label = $"dotnet-sdk: GetConsentGrant {guid}",
                Credentials = new OAuthApplicationCredentials()
                {
                    OauthClient = new ApplicationCredentialsOAuthClient()
                    {
                        ClientId = testClientId,
                        TokenEndpointAuthMethod = "client_secret_post",
                        AutoKeyRotation = true,
                    },
                },
                Settings = new OpenIdConnectApplicationSettings
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient()
                    {
                        ClientUri = "https://example.com/client",
                        LogoUri = "https://example.com/assets/images/logo-new.png",
                        ResponseTypes = new List<OAuthResponseType>
                        {
                            "token",
                            "id_token",
                            "code",
                        },
                        RedirectUris = new List<string>
                        {
                            "https://example.com/oauth2/callback",
                            "myapp://callback",
                        },
                        PostLogoutRedirectUris = new List<string>
                        {
                            "https://example.com/postlogout",
                            "myapp://postlogoutcallback",
                        },
                        GrantTypes = new List<OAuthGrantType>
                        {
                            "implicit",
                            "authorization_code",
                        },
                        ApplicationType = "native",

                        TosUri = "https://example.com/client/tos",
                        PolicyUri = "https://example.com/client/policy",
                    },
                }
            };


            var createdApp = await _applicationApi.CreateApplicationAsync(app);

            try
            {

                var issuer = _applicationApi.Configuration.OktaDomain;
                issuer = issuer.EndsWith("/") ? issuer.Substring(0, issuer.Length - 1) : issuer;
                // TODO: Review the spec. This method should return void
                await _applicationGrantsApi.GrantConsentToScopeAsync(createdApp.Id, new OAuth2ScopeConsentGrant()
                {
                    Issuer = issuer,
                    ScopeId = "okta.users.read",
                });

                var appConsentGrants = await _applicationGrantsApi.ListScopeConsentGrants(createdApp.Id).ToListAsync();
                var retrievedConsent = appConsentGrants.FirstOrDefault(x => x.ScopeId == "okta.users.read" && x.Issuer == issuer);
                retrievedConsent.Should().NotBeNull();

                retrievedConsent = await _applicationGrantsApi.GetScopeConsentGrantAsync(createdApp.Id, retrievedConsent.Id);
                retrievedConsent.Should().NotBeNull();
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task UpdateApplicationProfile()
        {
            var guid = Guid.NewGuid();
            var testClientId = $"{nameof(UpdateApplicationProfile)}_TestClientId";

            var app = new OpenIdConnectApplication
            {
                Name = "oidc_client",
                SignOnMode = "OPENID_CONNECT",
                Label = $"dotnet-sdk: UpdateApplicationProfile {guid}",
                Settings = new OpenIdConnectApplicationSettings
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient()
                    {
                        ClientUri = "https://example.com/client",
                        LogoUri = "https://example.com/assets/images/logo-new.png",
                        ResponseTypes = new List<OAuthResponseType>
                        {
                            "code",
                        },
                        RedirectUris = new List<string>
                        {
                            "https://example.com/oauth2/callback",
                            "myapp://callback",
                        },
                        
                        GrantTypes = new List<OAuthGrantType>
                        {
                            "authorization_code",
                            "client_credentials",
                        },
                        ApplicationType = "service",

                    },
                }
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app);

            try
            {

                createdApp.Profile = new Dictionary<string, object>();
                createdApp.Profile.Add("somelist", new List<string> { "test" });

                await _applicationApi.ReplaceApplicationAsync(createdApp.Id, createdApp);
                var persistedApp = await _applicationApi.GetApplicationAsync(createdApp.Id) as OpenIdConnectApplication;
                var listProperty = JsonConvert.DeserializeObject<List<string>>(persistedApp.Profile["somelist"].ToString());
                listProperty.Should().HaveCount(1);
                listProperty.First().Should().Be("test");

            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task GetDefaultProvisioningConnection()
        {
            var guid = Guid.NewGuid();
            var testClientId = $"{nameof(GetDefaultProvisioningConnection)}_TestClientId";

            var app = new OpenIdConnectApplication
            {
                Name = "oidc_client",
                SignOnMode = "OPENID_CONNECT",
                Label = $"dotnet-sdk: UpdateApplicationProfile {guid}",
                Settings = new OpenIdConnectApplicationSettings
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient()
                    {
                        ClientUri = "https://example.com/client",
                        LogoUri = "https://example.com/assets/images/logo-new.png",
                        ResponseTypes = new List<OAuthResponseType>
                        {
                            "code",
                        },
                        RedirectUris = new List<string>
                        {
                            "https://example.com/oauth2/callback",
                            "myapp://callback",
                        },

                        GrantTypes = new List<OAuthGrantType>
                        {
                            OAuthGrantType.AuthorizationCode,
                            OAuthGrantType.ClientCredentials,
                        },
                        ApplicationType = "service",

                    },
                }
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app);

            try
            {

                var connection = await _applicationConnectionsApi.GetDefaultProvisioningConnectionForApplicationAsync(createdApp.Id);
                connection.Profile.AuthScheme.Value.Should().Be("UNKNOWN");
                connection.Status.Should().Be(ProvisioningConnectionStatus.UNKNOWN);

            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task CreateOrg2OrgApplication()
        {
            var guid = Guid.NewGuid();

            var org2orgApp = new SamlApplication
            {
                Label = $"dotnet-sdk: okta_org2org {guid}",
                SignOnMode = "SAML_2_0",
                Settings = new SamlApplicationSettings()
                {
                    App = new SamlApplicationSettingsApplication()
                    {
                        AcsUrl = "https://example.okta.com/sso/saml2/exampleid",
                        AudRestriction = "https://www.okta.com/saml2/service-provider/exampleid",
                        BaseUrl = "https://example.okta.com",
                    },
                },
                Visibility = new ApplicationVisibility
                {
                    AutoLaunch = true,
                    AutoSubmitToolbar = true,
                },
            };

            var newApp = await _applicationApi.CreateApplicationAsync(org2orgApp);

            try
            {

                newApp.Id.Should().NotBeNullOrEmpty();
                newApp.SignOnMode.Value.Should().Be("SAML_2_0");
                ((SamlApplication)newApp).Name.Should().Be(org2orgApp.Name);
                newApp.Label.Should().Be(org2orgApp.Label);

                var retrievedApp = await _applicationApi.GetApplicationAsync(newApp.Id);
                retrievedApp.Should().NotBeNull();

            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(newApp.Id);
                await _applicationApi.DeleteApplicationAsync(newApp.Id);
            }
        }

        [Fact]
        public async Task GetAccessTokenUsingPrivateKeyWithDPoP()
        {
            //Create an OAuth 2.0 Service App with Private Key JWT authentication
            var guid = Guid.NewGuid();
            var testClientId = $"{nameof(GetAccessTokenUsingPrivateKeyWithDPoP)}_TestClientId";

            var jwk = new JsonWebKey()
            {
                Kty = "RSA",
                E = "AQAB",
                N = "i_FQrwnt4phLQtO0XAJAwqEcuOr_bCQE4TzhhEQnornk-8VIQWPYpXELUIjRBSSr2TFz8u-dGML6u4g_NctJ0XprSjWMSuVrXWGinVYpay6gJ_rozCnBsubCitPTnrTlJticH3AISqJGZH2q83meHM5AaYltNx4-EFjXmO__5AU9uhePMMUUs7G4QJ9-WLDc0CI1seHM8ibMab-m62gnw8pM-Ylpjd2dOZzCrMCtkfkU7LYjAiwNC8izliN3ssGpeHWzr3oPfJ9EMtZLxJM462JGa-_7y-8Scmwome6owVFbOy11Bg00GeuzdIMAGwJCkbKhhEz7Qx2AysSdq5gfdw",
                Kid = "7x5EXowOpzsdG3MjrWJFgPYYfUDC-KplgJjOzhJkkys"
            };

            var keys = new List<JsonWebKey>() { jwk };
            var app = new OpenIdConnectApplication
            {
                Name = "oidc_client",
                SignOnMode = "OPENID_CONNECT",
                Label = $"dotnet-sdk: DPoP Test {guid}",
                Credentials = new OAuthApplicationCredentials()
                {
                    OauthClient = new ApplicationCredentialsOAuthClient()
                    {
                        ClientId = testClientId,
                        TokenEndpointAuthMethod = "private_key_jwt",
                        AutoKeyRotation = true
                    }
                },
                Settings = new OpenIdConnectApplicationSettings()
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient()
                    {
                        DpopBoundAccessTokens = true,
                        ClientUri = "https://example.com/client",
                        LogoUri = "https://example.com/assets/images/logo-new.png",
                        ResponseTypes = new List<OAuthResponseType>
                        {
                            "token",
                            "code"
                        },
                        GrantTypes = new List<OAuthGrantType>()
                        {
                            OAuthGrantType.AuthorizationCode,
                            OAuthGrantType.ClientCredentials,
                        },
                        RedirectUris = new List<string>
                        {
                            "https://example.com/oauth2/callback",
                            "myapp://callback",
                        },
                        PostLogoutRedirectUris = new List<string>
                        {
                            "https://example.com/postlogout",
                            "myapp://postlogoutcallback",
                        },
                        ApplicationType = "service",
                        TosUri = "https://example.com/client/tos",
                        PolicyUri = "https://example.com/client/policy",
                    }
                }
            };
            app.Settings.OauthClient.Jwks = new OpenIdConnectApplicationSettingsClientKeys()
            {
                Keys = keys,
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app);
            var clientId = createdApp.Id;
            try
            {
                var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;

                // Remove '/' at the end since endpoint fails otherwise
                if (oktaDomain.EndsWith($"/"))
                {
                    oktaDomain = oktaDomain.Remove(oktaDomain.Length - 1);
                }

                var apiClient = new ApiClient(oktaDomain);
                var grantPayload = $@"{{
                                        ""scopeId"" : ""okta.users.read"",
                                        ""issuer"" : ""{oktaDomain}""
                                    }}";
                ;
                var requestOptions = GetBasicRequestOptions();
                requestOptions.Data = JObject.Parse(grantPayload);
                var apiCLient = await apiClient.PostAsync<JObject>($"/api/v1/apps/{clientId}/grants", requestOptions);
                //Private key used for the authentication
                var jsonPrivateKey = @"{
                                    ""p"":""wcXl0oxzwZRvpOBSiy-myHqqMKQMYdZtpwVpiu25BPYGt5YqGvyAkvhuJRAcpulsog60lLKAsygV_nQGLpypsyE6UJeXy9UbVvWuFegVjAhMNenIs6VM-MjvrlUMVArflLYcpKZf1YyNJbmhdTQTCkgkwA6nb0twsYZAJTBMROs"",
                                    ""kty"":""RSA"",
                                    ""q"":""uOIDsF5FbynrxJl7cGN-wBBWhcPu7nwqAvtJ4sLK76h0EADWcRtfm_6WloHXRk16wxnMNDRFqa_bmhwNdu96kD9pm22EOlz4Vct4KhDi0YSPinISzKL83MlUDVo6KEFJAMt8FJtf3Q_mC2lSUGNhPZYFdYAEmJvVObGnq_cyHKU"",
                                    ""d"":""IhAK45A3JwCK0SlWrU6fFMDCjQAmS9w4k9qNyfQM8b7tzZqni8MR6LMrXd7vgaD7c1JmNqu8QVq0TRFM0Xs57JMvqlB-ZXySNZieTE28pyoiMZkRMSC41SL2F3SX_flqDZqL5dsPKZt2Jt-vzLO9mKVbaFTbEJ97297EG6XPU2DXCoXK1wHt6rmnUx2MBylyyaDtqr8_dlcQuSEQjRUeneZNQT6vKRkWzX7Tu-I6r_AOKGQUGrcVvIiPO1p-fIezYfjd8MoS2OJBapq_RD_dRZTY7PEPX2vI9Ybhe_yTVbEm75UUXyO-cRv0HIYQaBUXALwkCxWyJpjC_4xe-4iIgQ"",
                                    ""e"":""AQAB"",
                                    ""kid"": ""7x5EXowOpzsdG3MjrWJFgPYYfUDC-KplgJjOzhJkkys"",
                                    ""qi"":""d5b5XZsMHrH8eeCUus6kixpTo0kYDhubpHsNCPky_QptE9o1X9UTxtaGLZhbymV6YUm2-Pr5-ippFj6DIBUVvw0YczSBe-OhWOHh7CXuzZA3mUNwAN0uRZv-2zjgHDgwjiE9pXTTQ3YsD4Fs53YngcprL1Jupiiu52xhqb1EyA"",""dp"":""b9D87-Swn5JCYog32a2jtqhiMTNZGdQc7naHEu5fB-fYtHPo1C3FHApTtPt5LTAhydpmhjADaF7HYlAdiSRKIN4ZwovXwn21Cxc2X9nPJUFciPfhIxlOM3nwJU9aj9y-bBgyqyh-wMIcaRqXewSTwCklW9aY8_Y6j5aCyXL3cAU"",""dq"":""Es-MKImu7tyJDHvBP3IgF1KSOxHwYXtomt0Oa2_-TdwJ0wcCyodKdwi0MaQMTy7a6rbZPAaFf_pQkaGBDTTYd4y8JgBCj92dtrz5AO6u5TpjkGaC2ydKKvyg_KrNeAMMdnQ9r6sPWeKgOVEB-wPhhO6ap5Xa4dwZGcGlma2Q_7E"",""n"":""i_FQrwnt4phLQtO0XAJAwqEcuOr_bCQE4TzhhEQnornk-8VIQWPYpXELUIjRBSSr2TFz8u-dGML6u4g_NctJ0XprSjWMSuVrXWGinVYpay6gJ_rozCnBsubCitPTnrTlJticH3AISqJGZH2q83meHM5AaYltNx4-EFjXmO__5AU9uhePMMUUs7G4QJ9-WLDc0CI1seHM8ibMab-m62gnw8pM-Ylpjd2dOZzCrMCtkfkU7LYjAiwNC8izliN3ssGpeHWzr3oPfJ9EMtZLxJM462JGa-_7y-8Scmwome6owVFbOy11Bg00GeuzdIMAGwJCkbKhhEz7Qx2AysSdq5gfdw""
                                 }";
                var configuration = new Configuration
                {
                    Scopes = new HashSet<string> { "okta.users.read" },
                    ClientId = testClientId,
                    PrivateKey = new JsonWebKeyConfiguration(jsonPrivateKey),
                    AuthorizationMode = AuthorizationMode.PrivateKey,
                    OktaDomain = oktaDomain
                };

                var oauthApi = new OAuthApi(configuration);
                var tokenResponse = await oauthApi.GetBearerTokenAsync();

                tokenResponse.Should().NotBeNull();
                tokenResponse.AccessToken.Should().NotBeNullOrEmpty();
            }
            finally
            {
                await _applicationApi.DeactivateApplicationAsync(createdApp.Id);
                await _applicationApi.DeleteApplicationAsync(createdApp.Id);   
            }
        }

        private RequestOptions GetBasicRequestOptions()
            {
                string[] _contentTypes = new string[] {
                    "application/json"
                };

                // to determine the Accept header
                string[] _accepts = new string[] {
                    "application/json"
                };

                var requestOptions = new RequestOptions();

                var localVarContentType = Okta.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
                if (localVarContentType != null)
                {
                    requestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
                }

                var localVarAccept = Okta.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
                if (localVarAccept != null)
                {
                    requestOptions.HeaderParameters.Add("Accept", localVarAccept);
                }

                // authentication (API_Token) required
                if (!string.IsNullOrEmpty(Configuration.GetConfigurationOrDefault().GetApiKeyWithPrefix("Authorization")))
                {
                    requestOptions.HeaderParameters.Add("Authorization", Configuration.GetConfigurationOrDefault().GetApiKeyWithPrefix("Authorization"));
                }
                return requestOptions;
            }
        
    }
}
