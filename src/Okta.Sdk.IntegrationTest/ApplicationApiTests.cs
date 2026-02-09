// <copyright file="ApplicationApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    public class ApplicationApiTestFixture : IAsyncLifetime
    {
        private readonly ApplicationApi _applicationApi = new();

        public async Task InitializeAsync()
        {
            // Cleanup any leftover test apps
            await CleanupTestApps();
        }

        public async Task DisposeAsync()
        {
            // Final cleanup
            await CleanupTestApps();
        }

        private async Task CleanupTestApps()
        {
            var appsToRemove = await _applicationApi.ListApplications().ToListAsync();

            foreach (var app in appsToRemove)
            {
                if (app.Label != null && app.Label.StartsWith("dotnet-sdk-test:"))
                {
                    try
                    {
                        // Deactivate first if active
                        if (app.Status == ApplicationLifecycleStatus.ACTIVE)
                        {
                            await _applicationApi.DeactivateApplicationAsync(app.Id);
                        }
                        await _applicationApi.DeleteApplicationAsync(app.Id);
                    }
                    catch (ApiException) { }
                }
            }
        }
    }

    [CollectionDefinition(nameof(ApplicationApiTests))]
    public class ApplicationApiTestsCollection : ICollectionFixture<ApplicationApiTestFixture>;

    [Collection(nameof(ApplicationApiTests))]
    public class ApplicationApiTests : IDisposable
    {
        private readonly ApplicationApi _applicationApi = new();
        private readonly List<string> _createdAppIds = new List<string>();

        public void Dispose()
        {
            CleanupApps().GetAwaiter().GetResult();
        }

        private async Task CleanupApps()
        {
            foreach (var appId in _createdAppIds)
            {
                try
                {
                    var app = await _applicationApi.GetApplicationAsync(appId);
                    if (app.Status == ApplicationLifecycleStatus.ACTIVE)
                    {
                        await _applicationApi.DeactivateApplicationAsync(appId);
                    }
                    await _applicationApi.DeleteApplicationAsync(appId);
                }
                catch (ApiException) { }
            }
            _createdAppIds.Clear();
        }

        /// <summary>
        /// Comprehensive test covering all Application API operations and endpoints.
        /// Tests all CRUD operations, lifecycle management (activate/deactivate),
        /// HttpInfo variants, pagination, filtering, search, and error handling.
        /// Follow the pattern: Create → Read → Update → List/Search → Lifecycle → Delete
        /// </summary>
        [Fact]
        public async Task GivenApplicationApi_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            var guid = Guid.NewGuid();
            string bookmarkAppId = null;
            string basicAuthAppId = null;
            string oidcAppId = null;
            string browserPluginAppId = null;

            try
            {
                // ==================== CREATE OPERATIONS (POST /api/v1/apps) ====================
                
                // CreateApplicationAsync - Create a Bookmark application
                var bookmarkApp = new BookmarkApplication
                {
                    Name = "bookmark",
                    Label = $"dotnet-sdk-test: BookmarkApp {guid}",
                    SignOnMode = ApplicationSignOnMode.BOOKMARK,
                    Visibility = new ApplicationVisibility
                    {
                        AutoSubmitToolbar = false,
                        Hide = new ApplicationVisibilityHide
                        {
                            IOS = false,
                            Web = false
                        }
                    },
                    Settings = new BookmarkApplicationSettings
                    {
                        App = new BookmarkApplicationSettingsApplication
                        {
                            RequestIntegration = false,
                            Url = "https://example.com/bookmark.html",
                        },
                    },
                };

                var createdBookmarkApp = await _applicationApi.CreateApplicationAsync(bookmarkApp);
                bookmarkAppId = createdBookmarkApp.Id;
                _createdAppIds.Add(bookmarkAppId);

                createdBookmarkApp.Should().NotBeNull();
                createdBookmarkApp.Id.Should().NotBeNullOrEmpty();
                createdBookmarkApp.Label.Should().Be($"dotnet-sdk-test: BookmarkApp {guid}");
                createdBookmarkApp.Status.Should().Be(ApplicationLifecycleStatus.ACTIVE);
                createdBookmarkApp.SignOnMode.Should().Be(ApplicationSignOnMode.BOOKMARK);
                createdBookmarkApp.Created.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
                createdBookmarkApp.LastUpdated.Should().BeOnOrBefore(DateTimeOffset.UtcNow);

                var bookmarkAppTyped = createdBookmarkApp as BookmarkApplication;
                bookmarkAppTyped.Should().NotBeNull();
                bookmarkAppTyped?.Settings.App.Url.Should().Be("https://example.com/bookmark.html");
                bookmarkAppTyped?.Settings.App.RequestIntegration.Should().BeFalse();

                // CreateApplicationWithHttpInfoAsync - Create app and verify HTTP response
                var basicAuthApp = new BasicAuthApplication
                {
                    Name = "template_basic_auth",
                    Label = $"dotnet-sdk-test: BasicAuthApp {guid}",
                    SignOnMode = ApplicationSignOnMode.BASICAUTH,
                    Visibility = new ApplicationVisibility
                    {
                        AutoSubmitToolbar = false,
                        Hide = new ApplicationVisibilityHide
                        {
                            IOS = false,
                            Web = false
                        }
                    },
                    Settings = new BasicApplicationSettings
                    {
                        App = new BasicApplicationSettingsApplication
                        {
                            Url = "https://example.com/login.html",
                            AuthURL = "https://example.com/auth.html",
                        },
                    },
                };

                var createResponse = await _applicationApi.CreateApplicationWithHttpInfoAsync(basicAuthApp);
                basicAuthAppId = createResponse.Data.Id;
                _createdAppIds.Add(basicAuthAppId);

                createResponse.Should().NotBeNull();
                createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                createResponse.Headers.Should().NotBeNull();
                createResponse.Data.Should().NotBeNull();
                createResponse.Data.Id.Should().NotBeNullOrEmpty();
                createResponse.Data.Label.Should().Be($"dotnet-sdk-test: BasicAuthApp {guid}");
                createResponse.Data.Status.Should().Be(ApplicationLifecycleStatus.ACTIVE);

                var basicAuthTyped = createResponse.Data as BasicAuthApplication;
                basicAuthTyped.Should().NotBeNull();
                basicAuthTyped?.Settings.App.Url.Should().Be("https://example.com/login.html");
                basicAuthTyped?.Settings.App.AuthURL.Should().Be("https://example.com/auth.html");

                // Create with activating=false
                var inactiveApp = new BookmarkApplication
                {
                    Name = "bookmark",
                    Label = $"dotnet-sdk-test: InactiveApp {guid}",
                    SignOnMode = ApplicationSignOnMode.BOOKMARK,
                    Visibility = new ApplicationVisibility
                    {
                        AutoSubmitToolbar = false,
                        Hide = new ApplicationVisibilityHide
                        {
                            IOS = false,
                            Web = false
                        }
                    },
                    Settings = new BookmarkApplicationSettings
                    {
                        App = new BookmarkApplicationSettingsApplication
                        {
                            Url = "https://example.com/inactive.html",
                            RequestIntegration = false,
                        },
                    },
                };

                var createdInactiveApp = await _applicationApi.CreateApplicationAsync(inactiveApp, activate: false);
                _createdAppIds.Add(createdInactiveApp.Id);

                createdInactiveApp.Should().NotBeNull();
                createdInactiveApp.Status.Should().Be(ApplicationLifecycleStatus.INACTIVE);

                // Create OIDC application (different app type)
                var oidcApp = new OpenIdConnectApplication
                {
                    Name = "oidc_client",
                    Label = $"dotnet-sdk-test: OIDCApp {guid}",
                    SignOnMode = ApplicationSignOnMode.OPENIDCONNECT,
                    Visibility = new ApplicationVisibility
                    {
                        AutoSubmitToolbar = false,
                        Hide = new ApplicationVisibilityHide
                        {
                            IOS = false,
                            Web = false
                        }
                    },
                    Credentials = new OAuthApplicationCredentials
                    {
                        OauthClient = new ApplicationCredentialsOAuthClient
                        {
                            TokenEndpointAuthMethod = "client_secret_post",
                            AutoKeyRotation = true,
                        },
                    },
                    Settings = new OpenIdConnectApplicationSettings
                    {
                        OauthClient = new OpenIdConnectApplicationSettingsClient
                        {
                            ClientUri = "https://example.com/client",
                            LogoUri = "https://example.com/logo.png",
                            ResponseTypes = new List<OAuthResponseType>(),
                            RedirectUris = new List<string>(),
                            GrantTypes = new List<GrantType>(),
                            ApplicationType = OpenIdConnectApplicationType.Web,
                        },
                    },
                };
                oidcApp.Settings.OauthClient.GrantTypes.Add(GrantType.AuthorizationCode);
                oidcApp.Settings.OauthClient.RedirectUris.Add("https://example.com/oauth2/callback");
                oidcApp.Settings.OauthClient.ResponseTypes.Add(OAuthResponseType.Code);

                var createdOidcApp = await _applicationApi.CreateApplicationAsync(oidcApp);
                oidcAppId = createdOidcApp.Id;
                _createdAppIds.Add(oidcAppId);

                createdOidcApp.Should().NotBeNull();
                createdOidcApp.SignOnMode.Should().Be(ApplicationSignOnMode.OPENIDCONNECT);
                var oidcTyped = createdOidcApp as OpenIdConnectApplication;
                oidcTyped.Should().NotBeNull();
                oidcTyped?.Credentials.OauthClient.ClientId.Should().NotBeNullOrEmpty();
                oidcTyped?.Settings.OauthClient.RedirectUris.Should().Contain("https://example.com/oauth2/callback");

                // Create Browser Plugin application
                var browserPluginApp = new BrowserPluginApplication
                {
                    Name = "template_swa",
                    Label = $"dotnet-sdk-test: BrowserPluginApp {guid}",
                    SignOnMode = ApplicationSignOnMode.BROWSERPLUGIN,
                    Visibility = new ApplicationVisibility
                    {
                        AutoSubmitToolbar = false,
                        Hide = new ApplicationVisibilityHide
                        {
                            IOS = false,
                            Web = false
                        }
                    },
                    Settings = new SwaApplicationSettings
                    {
                        App = new SwaApplicationSettingsApplication
                        {
                            ButtonField = "btn-login",
                            PasswordField = "textboxes-password",
                            UsernameField = "textboxes-username",
                            Url = "https://example.com/login.html",
                        },
                    },
                };

                var createdBrowserPluginApp = await _applicationApi.CreateApplicationAsync(browserPluginApp);
                browserPluginAppId = createdBrowserPluginApp.Id;
                _createdAppIds.Add(browserPluginAppId);

                createdBrowserPluginApp.Should().NotBeNull();
                createdBrowserPluginApp.SignOnMode.Should().Be(ApplicationSignOnMode.BROWSERPLUGIN);

                // ==================== READ OPERATIONS (GET /api/v1/apps/{appId}) ====================

                // GetApplicationAsync - Retrieve application by ID
                var retrievedBookmarkApp = await _applicationApi.GetApplicationAsync(bookmarkAppId);

                retrievedBookmarkApp.Should().NotBeNull();
                retrievedBookmarkApp.Id.Should().Be(bookmarkAppId);
                retrievedBookmarkApp.Label.Should().Be($"dotnet-sdk-test: BookmarkApp {guid}");
                retrievedBookmarkApp.Status.Should().Be(ApplicationLifecycleStatus.ACTIVE);
                retrievedBookmarkApp.SignOnMode.Should().Be(ApplicationSignOnMode.BOOKMARK);

                var retrievedBookmarkTyped = retrievedBookmarkApp as BookmarkApplication;
                retrievedBookmarkTyped.Should().NotBeNull();
                retrievedBookmarkTyped?.Settings.App.Url.Should().Be("https://example.com/bookmark.html");

                // GetApplicationWithHttpInfoAsync - Verify HTTP response
                var getResponse = await _applicationApi.GetApplicationWithHttpInfoAsync(basicAuthAppId);

                getResponse.Should().NotBeNull();
                getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                getResponse.Headers.Should().NotBeNull();
                getResponse.Data.Should().NotBeNull();
                getResponse.Data.Id.Should().Be(basicAuthAppId);
                getResponse.Data.Label.Should().Be($"dotnet-sdk-test: BasicAuthApp {guid}");

                // GetApplicationAsync with expanded parameter
                var expandedApp = await _applicationApi.GetApplicationAsync(bookmarkAppId, expand: null);
                expandedApp.Should().NotBeNull();
                expandedApp.Id.Should().Be(bookmarkAppId);

                // ==================== UPDATE OPERATIONS (PUT /api/v1/apps/{appId}) ====================

                // ReplaceApplicationAsync - Update application properties
                if (retrievedBookmarkApp is BookmarkApplication updatedBookmarkApp)
                {
                    updatedBookmarkApp.Label = $"dotnet-sdk-test: BookmarkApp {guid} - UPDATED";
                    var bookmarkSettings = updatedBookmarkApp.Settings;
                    bookmarkSettings.App.Url = "https://example.com/bookmark-updated.html";
                    bookmarkSettings.App.RequestIntegration = true;
                    updatedBookmarkApp.Settings = bookmarkSettings;

                    var replacedApp = await _applicationApi.ReplaceApplicationAsync(bookmarkAppId, updatedBookmarkApp);

                    replacedApp.Should().NotBeNull();
                    replacedApp.Id.Should().Be(bookmarkAppId);
                    replacedApp.Label.Should().Be($"dotnet-sdk-test: BookmarkApp {guid} - UPDATED");

                    var replacedBookmarkTyped = replacedApp as BookmarkApplication;
                    replacedBookmarkTyped.Should().NotBeNull();
                    replacedBookmarkTyped.Settings.App.Url.Should().Be("https://example.com/bookmark-updated.html");
                    replacedBookmarkTyped.Settings.App.RequestIntegration.Should().BeTrue();
                }

                // ReplaceApplicationWithHttpInfoAsync - Update with HTTP response
                if (await _applicationApi.GetApplicationAsync(basicAuthAppId) is BasicAuthApplication updatedBasicAuthApp)
                {
                    updatedBasicAuthApp.Label = $"dotnet-sdk-test: BasicAuthApp {guid} - UPDATED";
                    var basicSettings = updatedBasicAuthApp.Settings;
                    basicSettings.App.Url = "https://example.com/login-updated.html";
                    updatedBasicAuthApp.Settings = basicSettings;

                    var replaceResponse =
                        await _applicationApi.ReplaceApplicationWithHttpInfoAsync(basicAuthAppId, updatedBasicAuthApp);

                    replaceResponse.Should().NotBeNull();
                    replaceResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                    replaceResponse.Headers.Should().NotBeNull();
                    replaceResponse.Data.Should().NotBeNull();
                    replaceResponse.Data.Label.Should().Be($"dotnet-sdk-test: BasicAuthApp {guid} - UPDATED");

                    var replacedBasicTyped = replaceResponse.Data as BasicAuthApplication;
                    replacedBasicTyped.Should().NotBeNull();
                    replacedBasicTyped?.Settings.App.Url.Should().Be("https://example.com/login-updated.html");
                }

                // Verify the update persisted
                var verifyUpdated = await _applicationApi.GetApplicationAsync(bookmarkAppId) as BookmarkApplication;
                verifyUpdated?.Label.Should().Be($"dotnet-sdk-test: BookmarkApp {guid} - UPDATED");
                verifyUpdated?.Settings.App.Url.Should().Be("https://example.com/bookmark-updated.html");

                // ==================== LIST OPERATIONS (GET /api/v1/apps) ====================

                // Wait for indexing
                await Task.Delay(2000);

                // ListApplications - Basic listing
                var allApps = await _applicationApi.ListApplications().ToListAsync();

                allApps.Should().NotBeNull();
                allApps.Should().NotBeEmpty();
                allApps.Should().Contain(a => a.Id == bookmarkAppId);
                allApps.Should().Contain(a => a.Id == basicAuthAppId);
                allApps.Should().Contain(a => a.Id == oidcAppId);

                // ListApplications with limit (pagination)
                var limitedApps = await _applicationApi.ListApplications(limit: 2).ToListAsync();
                limitedApps.Should().NotBeNull();
                // Note: We can't guarantee exact count due to other apps that might exist

                // ListApplications with query parameter (q)
                var searchByLabel = await _applicationApi.ListApplications(q: $"dotnet-sdk-test: BookmarkApp {guid}").ToListAsync();
                searchByLabel.Should().NotBeNull();
                searchByLabel.Should().Contain(a => a.Id == bookmarkAppId);

                // ListApplications with filter parameter
                var activeApps = await _applicationApi.ListApplications(filter: "status eq \"ACTIVE\"").ToListAsync();
                activeApps.Should().NotBeNull();
                activeApps.Should().NotBeEmpty();
                activeApps.Should().Contain(a => a.Id == bookmarkAppId);
                activeApps.Should().OnlyContain(a => a.Status == ApplicationLifecycleStatus.ACTIVE);

                // ListApplications with filter by name
                var filterByName = await _applicationApi.ListApplications(filter: "name eq \"bookmark\"").ToListAsync();
                filterByName.Should().NotBeNull();
                filterByName.Should().Contain(a => a.Id == bookmarkAppId);

                // ListApplicationsWithHttpInfoAsync
                var listResponse = await _applicationApi.ListApplicationsWithHttpInfoAsync(limit: 5);
                listResponse.Should().NotBeNull();
                listResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                listResponse.Headers.Should().NotBeNull();
                listResponse.Data.Should().NotBeNull();
                listResponse.Data.Should().NotBeEmpty();

                // ListApplications with useOptimization
                var optimizedApps = await _applicationApi.ListApplications(useOptimization: true, limit: 5).ToListAsync();
                optimizedApps.Should().NotBeNull();

                // ListApplications with includeNonDeleted
                var includeNonDeletedApps = await _applicationApi.ListApplications(includeNonDeleted: true, limit: 5).ToListAsync();
                includeNonDeletedApps.Should().NotBeNull();

                // ==================== LIFECYCLE OPERATIONS ====================

                // DeactivateApplicationAsync (POST /api/v1/apps/{appId}/lifecycle/deactivate)
                await _applicationApi.DeactivateApplicationAsync(bookmarkAppId);

                var deactivatedApp = await _applicationApi.GetApplicationAsync(bookmarkAppId);
                deactivatedApp.Status.Should().Be(ApplicationLifecycleStatus.INACTIVE);

                // DeactivateApplicationWithHttpInfoAsync
                var deactivateResponse = await _applicationApi.DeactivateApplicationWithHttpInfoAsync(basicAuthAppId);
                deactivateResponse.Should().NotBeNull();
                deactivateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

                var deactivatedBasicApp = await _applicationApi.GetApplicationAsync(basicAuthAppId);
                deactivatedBasicApp.Status.Should().Be(ApplicationLifecycleStatus.INACTIVE);

                // ActivateApplicationAsync (POST /api/v1/apps/{appId}/lifecycle/activate)
                await _applicationApi.ActivateApplicationAsync(bookmarkAppId);

                var reactivatedApp = await _applicationApi.GetApplicationAsync(bookmarkAppId);
                reactivatedApp.Status.Should().Be(ApplicationLifecycleStatus.ACTIVE);

                // ActivateApplicationWithHttpInfoAsync
                var activateResponse = await _applicationApi.ActivateApplicationWithHttpInfoAsync(basicAuthAppId);
                activateResponse.Should().NotBeNull();
                activateResponse.StatusCode.Should().Be(HttpStatusCode.OK);

                var reactivatedBasicApp = await _applicationApi.GetApplicationAsync(basicAuthAppId);
                reactivatedBasicApp.Status.Should().Be(ApplicationLifecycleStatus.ACTIVE);

                // Activate the previously created inactive app
                await _applicationApi.ActivateApplicationAsync(createdInactiveApp.Id);
                var nowActiveApp = await _applicationApi.GetApplicationAsync(createdInactiveApp.Id);
                nowActiveApp.Status.Should().Be(ApplicationLifecycleStatus.ACTIVE);

                // ==================== DELETE OPERATIONS (DELETE /api/v1/apps/{appId}) ====================

                // Deactivate apps before deletion (required)
                // Check if apps still exist before deactivating
                try
                {
                    var bookmarkAppCheck = await _applicationApi.GetApplicationAsync(bookmarkAppId);
                    if (bookmarkAppCheck.Status == ApplicationLifecycleStatus.ACTIVE)
                    {
                        await _applicationApi.DeactivateApplicationAsync(bookmarkAppId);
                    }
                }
                catch (ApiException) { }

                try
                {
                    var basicAuthAppCheck = await _applicationApi.GetApplicationAsync(basicAuthAppId);
                    if (basicAuthAppCheck.Status == ApplicationLifecycleStatus.ACTIVE)
                    {
                        await _applicationApi.DeactivateApplicationAsync(basicAuthAppId);
                    }
                }
                catch (ApiException) { }

                try
                {
                    var oidcAppCheck = await _applicationApi.GetApplicationAsync(oidcAppId);
                    if (oidcAppCheck.Status == ApplicationLifecycleStatus.ACTIVE)
                    {
                        await _applicationApi.DeactivateApplicationAsync(oidcAppId);
                    }
                }
                catch (ApiException) { }

                try
                {
                    var browserPluginAppCheck = await _applicationApi.GetApplicationAsync(browserPluginAppId);
                    if (browserPluginAppCheck.Status == ApplicationLifecycleStatus.ACTIVE)
                    {
                        await _applicationApi.DeactivateApplicationAsync(browserPluginAppId);
                    }
                }
                catch (ApiException) { }

                try
                {
                    var inactiveAppCheck = await _applicationApi.GetApplicationAsync(createdInactiveApp.Id);
                    if (inactiveAppCheck.Status == ApplicationLifecycleStatus.ACTIVE)
                    {
                        await _applicationApi.DeactivateApplicationAsync(createdInactiveApp.Id);
                    }
                }
                catch (ApiException) { }

                // DeleteApplicationAsync
                await _applicationApi.DeleteApplicationAsync(bookmarkAppId);

                // Verify deletion - should throw 404
                Func<Task> getDeletedApp = async () => await _applicationApi.GetApplicationAsync(bookmarkAppId);
                await getDeletedApp.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404);

                _createdAppIds.Remove(bookmarkAppId);

                // DeleteApplicationWithHttpInfoAsync
                var deleteResponse = await _applicationApi.DeleteApplicationWithHttpInfoAsync(basicAuthAppId);
                deleteResponse.Should().NotBeNull();
                deleteResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

                // Verify deletion
                Func<Task> getDeletedBasicApp = async () => await _applicationApi.GetApplicationAsync(basicAuthAppId);
                await getDeletedBasicApp.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404);

                _createdAppIds.Remove(basicAuthAppId);

                // Delete remaining test apps
                await _applicationApi.DeleteApplicationAsync(oidcAppId);
                _createdAppIds.Remove(oidcAppId);

                await _applicationApi.DeleteApplicationAsync(browserPluginAppId);
                _createdAppIds.Remove(browserPluginAppId);

                await _applicationApi.DeleteApplicationAsync(createdInactiveApp.Id);
                _createdAppIds.Remove(createdInactiveApp.Id);

                // ==================== ERROR HANDLING TESTS ====================

                // GetApplicationAsync with non-existent ID
                Func<Task> getNonExistent = async () => await _applicationApi.GetApplicationAsync("nonexistent123");
                await getNonExistent.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404);

                // DeleteApplicationAsync on already deleted app
                var deleteAlreadyDeleted = async () => await _applicationApi.DeleteApplicationAsync(bookmarkAppId);
                await deleteAlreadyDeleted.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404);

                // ActivateApplicationAsync on non-existent app
                var activateNonExistent = async () => await _applicationApi.ActivateApplicationAsync("nonexistent123");
                await activateNonExistent.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404);

                // DeactivateApplicationAsync on non-existent app
                var deactivateNonExistent = async () => await _applicationApi.DeactivateApplicationAsync("nonexistent123");
                await deactivateNonExistent.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404);

                // ReplaceApplicationAsync on non-existent app
                var dummyApp = new BookmarkApplication
                {
                    Name = "bookmark",
                    Label = "Dummy",
                    SignOnMode = ApplicationSignOnMode.BOOKMARK,
                    Visibility = new ApplicationVisibility
                    {
                        AutoSubmitToolbar = false,
                        Hide = new ApplicationVisibilityHide
                        {
                            IOS = false,
                            Web = false
                        }
                    },
                    Settings = new BookmarkApplicationSettings
                    {
                        App = new BookmarkApplicationSettingsApplication
                        {
                            Url = "https://example.com",
                            RequestIntegration = false,
                        },
                    },
                };

                Func<Task> replaceNonExistent = async () => await _applicationApi.ReplaceApplicationAsync("nonexistent123", dummyApp);
                await replaceNonExistent.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404);

                // ==================== PAGINATION TEST ====================

                // Manual pagination with after cursor
                var createdAppsForPagination = new List<string>();
                
                try
                {
                    // Create multiple apps for pagination testing
                    for (var i = 0; i < 3; i++)
                    {
                        var paginationApp = new BookmarkApplication
                        {
                            Name = "bookmark",
                            Label = $"dotnet-sdk-test: PaginationApp-{i}-{guid}",
                            SignOnMode = ApplicationSignOnMode.BOOKMARK,
                            Visibility = new ApplicationVisibility
                            {
                                AutoSubmitToolbar = false,
                                Hide = new ApplicationVisibilityHide
                                {
                                    IOS = false,
                                    Web = false
                                }
                            },
                            Settings = new BookmarkApplicationSettings
                            {
                                App = new BookmarkApplicationSettingsApplication
                                {
                                    Url = $"https://example.com/page{i}.html",
                                    RequestIntegration = false,
                                },
                            },
                        };

                        var paginatedApp = await _applicationApi.CreateApplicationAsync(paginationApp);
                        createdAppsForPagination.Add(paginatedApp.Id);
                        _createdAppIds.Add(paginatedApp.Id);
                    }

                    await Task.Delay(2000); // Wait for indexing

                    // Test pagination with limit
                    var firstPage = await _applicationApi.ListApplicationsWithHttpInfoAsync(limit: 2);
                    firstPage.Data.Should().NotBeNull();
                    firstPage.Data.Count.Should().BeLessThanOrEqualTo(2);

                    // Verify we can list all created pagination apps
                    var allPaginationApps = await _applicationApi.ListApplications().ToListAsync();
                    var foundPaginationApps = allPaginationApps.Where(a => createdAppsForPagination.Contains(a.Id)).ToList();
                    foundPaginationApps.Should().HaveCount(3);

                    // Cleanup pagination test apps
                    foreach (var appId in createdAppsForPagination)
                    {
                        await _applicationApi.DeactivateApplicationAsync(appId);
                        await _applicationApi.DeleteApplicationAsync(appId);
                        _createdAppIds.Remove(appId);
                    }
                }
                catch
                {
                    // Ensure cleanup even if test fails
                    foreach (var appId in createdAppsForPagination)
                    {
                        try
                        {
                            await _applicationApi.DeactivateApplicationAsync(appId);
                            await _applicationApi.DeleteApplicationAsync(appId);
                            _createdAppIds.Remove(appId);
                        }
                        catch
                        {
                            // ignored
                        }
                    }
                    throw;
                }

                // ==================== VALIDATION TESTS ====================

                // CreateApplicationAsync with invalid data - Try to delete an active app (should fail)
                var testActiveAppForDelete = new BookmarkApplication
                {
                    Name = "bookmark",
                    Label = $"dotnet-sdk-test: ActiveDeleteTest {guid}",
                    SignOnMode = ApplicationSignOnMode.BOOKMARK,
                    Visibility = new ApplicationVisibility
                    {
                        AutoSubmitToolbar = false,
                        Hide = new ApplicationVisibilityHide
                        {
                            IOS = false,
                            Web = false
                        }
                    },
                    Settings = new BookmarkApplicationSettings
                    {
                        App = new BookmarkApplicationSettingsApplication
                        {
                            Url = "https://example.com",
                            RequestIntegration = false,
                        },
                    },
                };
                var activeAppForDelete = await _applicationApi.CreateApplicationAsync(testActiveAppForDelete);
                _createdAppIds.Add(activeAppForDelete.Id);

                // Try to delete an active app (should require deactivation first)
                var deleteActiveApp = async () => await _applicationApi.DeleteApplicationAsync(activeAppForDelete.Id);
                await deleteActiveApp.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 403);

                // Clean up the test app
                await _applicationApi.DeactivateApplicationAsync(activeAppForDelete.Id);
                await _applicationApi.DeleteApplicationAsync(activeAppForDelete.Id);
                _createdAppIds.Remove(activeAppForDelete.Id);

            }
            catch (Exception)
            {
                // Clean up any apps created during the test if an exception occurs
                foreach (var appId in new[] { bookmarkAppId, basicAuthAppId, oidcAppId, browserPluginAppId })
                {
                    if (!string.IsNullOrEmpty(appId))
                    {
                        try
                        {
                            var app = await _applicationApi.GetApplicationAsync(appId);
                            if (app.Status == ApplicationLifecycleStatus.ACTIVE)
                            {
                                await _applicationApi.DeactivateApplicationAsync(appId);
                            }
                            await _applicationApi.DeleteApplicationAsync(appId);
                        }
                        catch
                        {
                            // ignored
                        }
                    }
                }
                throw;
            }
        }

        /// <summary>
        /// Tests collection enumeration behavior with async iterators
        /// </summary>
        [Fact]
        public async Task GivenMultipleApplications_WhenEnumeratingManually_ThenEnumerationWorksCorrectly()
        {
            var guid = Guid.NewGuid();
            var createdApps = new List<string>();

            try
            {
                // Create test apps
                for (var i = 0; i < 3; i++)
                {
                    var app = new BookmarkApplication
                    {
                        Name = "bookmark",
                        Label = $"dotnet-sdk-test: EnumerationTest-{i}-{guid}",
                        SignOnMode = ApplicationSignOnMode.BOOKMARK,
                        Visibility = new ApplicationVisibility
                        {
                            AutoSubmitToolbar = false,
                            Hide = new ApplicationVisibilityHide
                            {
                                IOS = false,
                                Web = false
                            }
                        },
                        Settings = new BookmarkApplicationSettings
                        {
                            App = new BookmarkApplicationSettingsApplication
                            {
                                Url = $"https://example.com/enum{i}.html",
                                RequestIntegration = false,
                            },
                        },
                    };

                    var createdApp = await _applicationApi.CreateApplicationAsync(app);
                    createdApps.Add(createdApp.Id);
                    _createdAppIds.Add(createdApp.Id);
                }

                await Task.Delay(2000); // Wait for indexing

                // Enumerate manually with async iterator
                var retrievedApps = new List<Application>();
                var appsCollectionClient = _applicationApi.ListApplications(limit: 1);
                var enumerator = appsCollectionClient.GetAsyncEnumerator();

                while (await enumerator.MoveNextAsync())
                {
                    if (enumerator.Current.Label != null && 
                        enumerator.Current.Label.Contains($"EnumerationTest", StringComparison.InvariantCultureIgnoreCase) &&
                        enumerator.Current.Label.Contains(guid.ToString()))
                    {
                        retrievedApps.Add(enumerator.Current);
                    }

                    // Break after finding all our test apps to avoid long enumeration
                    if (retrievedApps.Count >= 3)
                        break;
                }

                retrievedApps.Count.Should().BeGreaterThanOrEqualTo(3);
            }
            finally
            {
                // Cleanup
                foreach (var appId in createdApps)
                {
                    try
                    {
                        await _applicationApi.DeactivateApplicationAsync(appId);
                        await _applicationApi.DeleteApplicationAsync(appId);
                        _createdAppIds.Remove(appId);
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }
        }

        /// <summary>
        /// Tests edge cases and boundary conditions
        /// </summary>
        [Fact]
        public async Task GivenEdgeCases_WhenCallingApi_ThenEdgeCasesAreHandledCorrectly()
        {
            var guid = Guid.NewGuid();
            string appId = null;

            try
            {
                // Test: Create app with minimum required fields
                var minimalApp = new BookmarkApplication
                {
                    Name = "bookmark",
                    Label = $"dotnet-sdk-test: MinimalApp {guid}",
                    SignOnMode = ApplicationSignOnMode.BOOKMARK,
                    Visibility = new ApplicationVisibility
                    {
                        AutoSubmitToolbar = false,
                        Hide = new ApplicationVisibilityHide
                        {
                            IOS = false,
                            Web = false
                        }
                    },
                    Settings = new BookmarkApplicationSettings
                    {
                        App = new BookmarkApplicationSettingsApplication
                        {
                            Url = "https://example.com",
                            RequestIntegration = false,
                        },
                    },
                };

                var createdApp = await _applicationApi.CreateApplicationAsync(minimalApp);
                appId = createdApp.Id;
                _createdAppIds.Add(appId);

                createdApp.Should().NotBeNull();
                createdApp.Label.Should().Be($"dotnet-sdk-test: MinimalApp {guid}");

                // Update with same values (idempotent)
                var retrievedForUpdate = await _applicationApi.GetApplicationAsync(appId) as BookmarkApplication;
                var updatedSame = await _applicationApi.ReplaceApplicationAsync(appId, retrievedForUpdate);
                updatedSame.Should().NotBeNull();
                updatedSame.Label.Should().Be(retrievedForUpdate?.Label);

                // Deactivate already inactive app should not fail
                await _applicationApi.DeactivateApplicationAsync(appId);
                await _applicationApi.DeactivateApplicationAsync(appId); // Second deactivation
                var stillInactive = await _applicationApi.GetApplicationAsync(appId);
                stillInactive.Status.Should().Be(ApplicationLifecycleStatus.INACTIVE);

                // Activate already active app
                await _applicationApi.ActivateApplicationAsync(appId);
                await _applicationApi.ActivateApplicationAsync(appId); // Second activation
                var stillActive = await _applicationApi.GetApplicationAsync(appId);
                stillActive.Status.Should().Be(ApplicationLifecycleStatus.ACTIVE);

                // Cleanup
                await _applicationApi.DeactivateApplicationAsync(appId);
                await _applicationApi.DeleteApplicationAsync(appId);
                _createdAppIds.Remove(appId);
                appId = null;
            }
            finally
            {
                if (!string.IsNullOrEmpty(appId))
                {
                    try
                    {
                        await _applicationApi.DeactivateApplicationAsync(appId);
                        await _applicationApi.DeleteApplicationAsync(appId);
                        _createdAppIds.Remove(appId);
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }
        }
    }
}
