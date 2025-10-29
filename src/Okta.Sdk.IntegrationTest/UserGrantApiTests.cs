// <copyright file="UserGrantApiTests.cs" company="Okta, Inc">
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
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    [Collection(nameof(UserGrantApiTests))]
    public class UserGrantApiTests : IDisposable
    {
        private readonly UserGrantApi _userGrantApi = new();
        private readonly UserApi _userApi = new();
        private readonly ApplicationApi _applicationApi = new();
        private readonly List<string> _createdUserIds = [];
        private readonly List<string> _createdAppIds = [];

        public void Dispose()
        {
            CleanupResources().GetAwaiter().GetResult();
        }

        private async Task CleanupResources()
        {
            // Cleanup applications
            foreach (var appId in _createdAppIds)
            {
                try
                {
                    await _applicationApi.DeactivateApplicationAsync(appId);
                    await _applicationApi.DeleteApplicationAsync(appId);
                }
                catch (ApiException)
                {
                    // Ignore cleanup errors
                }
            }
            _createdAppIds.Clear();

            // Cleanup users
            foreach (var userId in _createdUserIds)
            {
                try
                {
                    await _userApi.DeleteUserAsync(userId);
                    await _userApi.DeleteUserAsync(userId);
                }
                catch (ApiException)
                {
                    // Ignore cleanup errors
                }
            }
            _createdUserIds.Clear();
        }

        #region Complete User Grant API CRUD Lifecycle Test

        [Fact]
        public async Task GivenUserAndClient_WhenPerformingCrudOperations_ThenAllEndpointsAndMethodsWork()
        {
            var guid = Guid.NewGuid();
            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;
            
            if (oktaDomain.EndsWith("/"))
            {
                oktaDomain.TrimEnd('/');
            }

            // Create test user
            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "UserGrant",
                    LastName = "TestUser",
                    Email = $"user-grant-test-{guid}@example.com",
                    Login = $"user-grant-test-{guid}@example.com"
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest, activate: true);
            _createdUserIds.Add(createdUser.Id);

            createdUser.Should().NotBeNull();
            createdUser.Id.Should().NotBeNullOrEmpty();
            var allowedStatuses = new[] { UserStatus.ACTIVE.Value, UserStatus.PROVISIONED.Value };
            allowedStatuses.Should().Contain(createdUser.Status.Value);

            var userId = createdUser.Id;

            // Create OAuth application
            var app = new OpenIdConnectApplication
            {
                Name = "oidc_client",
                Label = $"dotnet-sdk: UserGrantApiTest {guid}",
                SignOnMode = "OPENID_CONNECT",
                Credentials = new OAuthApplicationCredentials
                {
                    OauthClient = new ApplicationCredentialsOAuthClient
                    {
                        ClientId = $"test_client_{guid}",
                        AutoKeyRotation = true,
                        TokenEndpointAuthMethod = "client_secret_post"
                    }
                },
                Settings = new OpenIdConnectApplicationSettings
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient
                    {
                        ClientUri = "https://example.com/client",
                        LogoUri = "https://example.com/logo.png",
                        RedirectUris = ["https://example.com/oauth2/callback"],
                        PostLogoutRedirectUris = ["https://example.com/postlogout"],
                        ResponseTypes =
                        [
                            OAuthResponseType.Code,
                            OAuthResponseType.Token,
                            OAuthResponseType.IdToken
                        ],
                        GrantTypes =
                        [
                            GrantType.AuthorizationCode,
                            GrantType.Implicit,
                            GrantType.RefreshToken
                        ],
                        ApplicationType = "web",
                        ConsentMethod = "REQUIRED",
                        IssuerMode = "ORG_URL"
                    }
                }
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app, activate: true);
            _createdAppIds.Add(createdApp.Id);

            createdApp.Should().NotBeNull();
            createdApp.Id.Should().NotBeNullOrEmpty();
            createdApp.Status.Should().Be(ApplicationLifecycleStatus.ACTIVE);

            var clientId = ((OpenIdConnectApplication)createdApp).Credentials?.OauthClient?.ClientId;
            clientId.Should().NotBeNullOrEmpty();

            // Check for existing grants (user grants are created through OAuth consent flows, not via API)
            var initialUserGrants = await _userGrantApi.ListUserGrants(userId).ToListAsync();
            
            // GET /api/v1/users/{userId}/grants - ListUserGrants
            var userGrants = await _userGrantApi.ListUserGrants(userId).ToListAsync();

            userGrants.Should().NotBeNull("API should return a valid collection, not null");
            userGrants.Should().BeOfType<List<OAuth2ScopeConsentGrant>>("API should return correct type");
            
            if (userGrants.Any())
            {
                var grant = userGrants.First();
                grant.Id.Should().NotBeNullOrEmpty();
                grant.ClientId.Should().NotBeNullOrEmpty();
                grant.UserId.Should().NotBeNullOrEmpty();
                grant.ScopeId.Should().NotBeNullOrEmpty();
                grant.Issuer.Should().NotBeNullOrEmpty();
                grant.Status.Should().NotBeNull();
                grant.Created.Should().NotBe(default(DateTimeOffset));
                grant.LastUpdated.Should().NotBe(default(DateTimeOffset));
            }

            // GET /api/v1/users/{userId}/grants?scopeId=okta.users.read - ListUserGrants with filter
            var filteredGrants = await _userGrantApi.ListUserGrants(userId, scopeId: "okta.users.read").ToListAsync();

            filteredGrants.Should().NotBeNull();
            filteredGrants.Should().BeOfType<List<OAuth2ScopeConsentGrant>>();
            
            if (filteredGrants.Any())
            {
                filteredGrants.Should().OnlyContain(g => g.ScopeId == "okta.users.read");
            }

            // GET /api/v1/users/{userId}/grants?expand=scope - ListUserGrants with expanding
            var expandedGrants = await _userGrantApi.ListUserGrants(userId, expand: "scope").ToListAsync();

            expandedGrants.Should().NotBeNull();
            
            if (expandedGrants.Any())
            {
                var expandedGrant = expandedGrants.First();
                expandedGrant.Embedded.Should().NotBeNull();
                expandedGrant.Embedded.Scope.Should().NotBeNull();
                expandedGrant.Embedded.Scope.Id.Should().NotBeNullOrEmpty();
            }

            // GET /api/v1/users/{userId}/grants?limit=1 - ListUserGrants with pagination
            var paginatedGrants = await _userGrantApi.ListUserGrants(userId, limit: 1).ToListAsync();

            paginatedGrants.Should().NotBeNull();
            paginatedGrants.Count.Should().BeLessThanOrEqualTo(1);

            // GET /api/v1/users/{userId}/clients/{clientId}/grants - ListGrantsForUserAndClient
            var clientGrants = await _userGrantApi.ListGrantsForUserAndClient(userId, clientId).ToListAsync();

            clientGrants.Should().NotBeNull();
            clientGrants.Should().BeOfType<List<OAuth2ScopeConsentGrant>>();
            
            if (clientGrants.Any())
            {
                clientGrants.Should().OnlyContain(g => g.ClientId == clientId);
                clientGrants.Should().OnlyContain(g => g.UserId == userId);
            }

            // GET /api/v1/users/{userId}/clients/{clientId}/grants?expand=scope - ListGrantsForUserAndClient with expanding
            var expandedClientGrants = await _userGrantApi.ListGrantsForUserAndClient(
                userId, 
                clientId, 
                expand: "scope"
            ).ToListAsync();

            expandedClientGrants.Should().NotBeNull();
            
            if (expandedClientGrants.Any())
            {
                var expandedClientGrant = expandedClientGrants.First();
                expandedClientGrant.Embedded.Should().NotBeNull();
                expandedClientGrant.Embedded.Scope.Should().NotBeNull();
            }

            // GET /api/v1/users/{userId}/clients/{clientId}/grants?limit=1 - ListGrantsForUserAndClient with pagination
            var paginatedClientGrants = await _userGrantApi.ListGrantsForUserAndClient(
                userId, 
                clientId, 
                limit: 1
            ).ToListAsync();

            paginatedClientGrants.Should().NotBeNull();
            paginatedClientGrants.Count.Should().BeLessThanOrEqualTo(1);

            // GET /api/v1/users/{userId}/grants/{grantId} - GetUserGrant (with and without expanding)
            if (initialUserGrants.Any())
            {
                var testGrant = initialUserGrants.First();
                var grantId = testGrant.Id;

                var retrievedGrant = await _userGrantApi.GetUserGrantAsync(userId, grantId);

                retrievedGrant.Should().NotBeNull();
                retrievedGrant.Id.Should().Be(grantId);
                retrievedGrant.ClientId.Should().NotBeNullOrEmpty();
                retrievedGrant.UserId.Should().Be(userId);
                retrievedGrant.ScopeId.Should().NotBeNullOrEmpty();
                retrievedGrant.Issuer.Should().NotBeNullOrEmpty();
                retrievedGrant.Status.Should().NotBeNull();
                
                var validStatuses = new[] { 
                    GrantOrTokenStatus.ACTIVE.Value, 
                    GrantOrTokenStatus.REVOKED.Value 
                };
                validStatuses.Should().Contain(retrievedGrant.Status.Value);
                
                retrievedGrant.Created.Should().NotBe(default(DateTimeOffset));
                retrievedGrant.Created.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
                retrievedGrant.LastUpdated.Should().NotBe(default(DateTimeOffset));
                retrievedGrant.LastUpdated.Should().BeOnOrAfter(retrievedGrant.Created);

                var expandedGrant = await _userGrantApi.GetUserGrantAsync(userId, grantId, expand: "scope");

                expandedGrant.Should().NotBeNull();
                expandedGrant.Id.Should().Be(grantId);
                expandedGrant.Embedded.Should().NotBeNull();
                expandedGrant.Embedded.Scope.Should().NotBeNull();
                expandedGrant.Embedded.Scope.Id.Should().NotBeNullOrEmpty();
                expandedGrant.Embedded.Scope.Id.Should().Be(expandedGrant.ScopeId);
            }

            // DELETE /api/v1/users/{userId}/grants/{grantId} - RevokeUserGrant
            if (initialUserGrants.Any())
            {
                var grantToRevoke = initialUserGrants.First();
                var revokeGrantId = grantToRevoke.Id;

                await _userGrantApi.RevokeUserGrantAsync(userId, revokeGrantId);

                await Task.Delay(1000);

                await Assert.ThrowsAsync<ApiException>(async () =>
                {
                    await _userGrantApi.GetUserGrantAsync(userId, revokeGrantId);
                });

                var grantsAfterSingleRevoke = await _userGrantApi.ListUserGrants(userId).ToListAsync();
                grantsAfterSingleRevoke.Should().NotContain(g => g.Id == revokeGrantId);
            }

            // DELETE /api/v1/users/{userId}/grants - RevokeUserGrants
            await _userGrantApi.RevokeUserGrantsAsync(userId);

            await Task.Delay(2000);

            var grantsAfterRevoke = await _userGrantApi.ListUserGrants(userId).ToListAsync();
            grantsAfterRevoke.Should().BeEmpty();

            // DELETE /api/v1/users/{userId}/clients/{clientId}/grants - RevokeGrantsForUserAndClient
            await _userGrantApi.RevokeGrantsForUserAndClientAsync(userId, clientId);

            await Task.Delay(1000);

            var clientGrantsAfterRevoke = await _userGrantApi.ListGrantsForUserAndClient(userId, clientId).ToListAsync();
            clientGrantsAfterRevoke.Should().BeEmpty();
        }

        [Fact]
        public async Task GivenHttpInfoMethods_WhenCallingApi_ThenHttpMetadataIsReturned()
        {
            var guid = Guid.NewGuid();
            
            // Create test user
            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "UserGrantHttpInfo",
                    LastName = "TestUser",
                    Email = $"user-grant-http-info-{guid}@example.com",
                    Login = $"user-grant-http-info-{guid}@example.com"
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest, activate: true);
            _createdUserIds.Add(createdUser.Id);
            var userId = createdUser.Id;

            // Create OAuth application
            var app = new OpenIdConnectApplication
            {
                Name = "oidc_client",
                Label = $"dotnet-sdk: UserGrantHttpInfoTest {guid}",
                SignOnMode = "OPENID_CONNECT",
                Credentials = new OAuthApplicationCredentials
                {
                    OauthClient = new ApplicationCredentialsOAuthClient
                    {
                        ClientId = $"test_client_http-info_{guid}",
                        AutoKeyRotation = true,
                        TokenEndpointAuthMethod = "client_secret_post"
                    }
                },
                Settings = new OpenIdConnectApplicationSettings
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient
                    {
                        ClientUri = "https://example.com/client",
                        LogoUri = "https://example.com/logo.png",
                        RedirectUris = ["https://example.com/oauth2/callback"],
                        PostLogoutRedirectUris = ["https://example.com/postlogout"],
                        ResponseTypes =
                        [
                            OAuthResponseType.Code,
                            OAuthResponseType.Token,
                            OAuthResponseType.IdToken
                        ],
                        GrantTypes =
                        [
                            GrantType.AuthorizationCode,
                            GrantType.Implicit,
                            GrantType.RefreshToken
                        ],
                        ApplicationType = "web",
                        ConsentMethod = "REQUIRED",
                        IssuerMode = "ORG_URL"
                    }
                }
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app, activate: true);
            _createdAppIds.Add(createdApp.Id);
            var clientId = ((OpenIdConnectApplication)createdApp).Credentials?.OauthClient?.ClientId;

            // Check for existing grants
            var initialUserGrants = await _userGrantApi.ListUserGrants(userId).ToListAsync();

            // TEST 1: ListUserGrantsWithHttpInfoAsync - Verify HTTP response metadata
            var listResponse = await _userGrantApi.ListUserGrantsWithHttpInfoAsync(userId);
            
            listResponse.Should().NotBeNull();
            listResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            listResponse.Data.Should().NotBeNull();
            listResponse.Data.Should().BeOfType<List<OAuth2ScopeConsentGrant>>();
            listResponse.Headers.Should().NotBeNull();
            listResponse.Headers.Should().ContainKey("Content-Type");

            // TEST 2: ListUserGrantsWithHttpInfoAsync with parameters
            var listWithParamsResponse = await _userGrantApi.ListUserGrantsWithHttpInfoAsync(
                userId, 
                scopeId: "okta.users.read", 
                expand: "scope", 
                limit: 10
            );
            
            listWithParamsResponse.Should().NotBeNull();
            listWithParamsResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            listWithParamsResponse.Data.Should().NotBeNull();

            // TEST 3: ListGrantsForUserAndClientWithHttpInfoAsync
            var clientListResponse = await _userGrantApi.ListGrantsForUserAndClientWithHttpInfoAsync(userId, clientId);
            
            clientListResponse.Should().NotBeNull();
            clientListResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            clientListResponse.Data.Should().NotBeNull();
            clientListResponse.Data.Should().BeOfType<List<OAuth2ScopeConsentGrant>>();

            // TEST 4: ListGrantsForUserAndClientWithHttpInfoAsync with parameters
            var clientListWithParamsResponse = await _userGrantApi.ListGrantsForUserAndClientWithHttpInfoAsync(
                userId, 
                clientId, 
                expand: "scope", 
                limit: 5
            );
            
            clientListWithParamsResponse.Should().NotBeNull();
            clientListWithParamsResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            clientListWithParamsResponse.Data.Should().NotBeNull();

            // TEST 5: GetUserGrantWithHttpInfoAsync (if grants exist)
            if (initialUserGrants.Any())
            {
                var grantId = initialUserGrants.First().Id;
                var getResponse = await _userGrantApi.GetUserGrantWithHttpInfoAsync(userId, grantId);
                
                getResponse.Should().NotBeNull();
                getResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
                getResponse.Data.Should().NotBeNull();
                getResponse.Data.Id.Should().Be(grantId);
                getResponse.Headers.Should().NotBeNull();

                // TEST 6: GetUserGrantWithHttpInfoAsync with expanding
                var getExpandResponse = await _userGrantApi.GetUserGrantWithHttpInfoAsync(userId, grantId, expand: "scope");
                
                getExpandResponse.Should().NotBeNull();
                getExpandResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
                getExpandResponse.Data.Should().NotBeNull();
                getExpandResponse.Data.Embedded.Should().NotBeNull();
            }

            // TEST 7: RevokeUserGrantWithHttpInfoAsync (if grants exist)
            if (initialUserGrants.Any())
            {
                var grantToRevoke = initialUserGrants.First();
                var revokeResponse = await _userGrantApi.RevokeUserGrantWithHttpInfoAsync(userId, grantToRevoke.Id);
                
                revokeResponse.Should().NotBeNull();
                revokeResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
                revokeResponse.Headers.Should().NotBeNull();

                await Task.Delay(1000);
            }

            // TEST 8: RevokeUserGrantsWithHttpInfoAsync
            var revokeAllResponse = await _userGrantApi.RevokeUserGrantsWithHttpInfoAsync(userId);
            
            revokeAllResponse.Should().NotBeNull();
            revokeAllResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
            revokeAllResponse.Headers.Should().NotBeNull();

            await Task.Delay(1000);

            // TEST 9: RevokeGrantsForUserAndClientWithHttpInfoAsync
            var revokeClientResponse = await _userGrantApi.RevokeGrantsForUserAndClientWithHttpInfoAsync(userId, clientId);
            
            revokeClientResponse.Should().NotBeNull();
            revokeClientResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
            revokeClientResponse.Headers.Should().NotBeNull();
        }

        #endregion

        #region Error Scenarios

        /// <summary>
        /// Tests error scenarios with invalid inputs for all methods.
        /// </summary>
        [Fact]
        public async Task GivenInvalidScenarios_WhenCallingApi_ThenApiExceptionIsThrown()
        {
            const string invalidUserId = "invalid_user_id_12345";
            const string invalidGrantId = "invalid_grant_id_12345";
            const string invalidClientId = "invalid_client_id_12345";

            // ListUserGrants with invalid userId - should throw 404
            var listException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userGrantApi.ListUserGrants(invalidUserId).ToListAsync();
            });
            listException.ErrorCode.Should().Be(404);

            // GetUserGrantAsync with invalid userId - should throw 404
            var getException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userGrantApi.GetUserGrantAsync(invalidUserId, invalidGrantId);
            });
            getException.ErrorCode.Should().Be(404);

            // ListGrantsForUserAndClient with invalid userId - should throw 404
            var listClientException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userGrantApi.ListGrantsForUserAndClient(invalidUserId, invalidClientId).ToListAsync();
            });
            listClientException.ErrorCode.Should().Be(404);

            // RevokeUserGrantAsync with invalid userId - should throw 404
            var revokeException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userGrantApi.RevokeUserGrantAsync(invalidUserId, invalidGrantId);
            });
            revokeException.ErrorCode.Should().Be(404);

            // RevokeUserGrantsAsync with invalid userId - should throw 404
            var revokeAllException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userGrantApi.RevokeUserGrantsAsync(invalidUserId);
            });
            revokeAllException.ErrorCode.Should().Be(404);

            // RevokeGrantsForUserAndClientAsync with invalid userId - should throw 404
            var revokeClientException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userGrantApi.RevokeGrantsForUserAndClientAsync(invalidUserId, invalidClientId);
            });
            revokeClientException.ErrorCode.Should().Be(404);

            // ListUserGrantsWithHttpInfoAsync with invalid userId - should throw 404
            var listHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userGrantApi.ListUserGrantsWithHttpInfoAsync(invalidUserId);
            });
            listHttpInfoException.ErrorCode.Should().Be(404);

            // GetUserGrantWithHttpInfoAsync with invalid userId - should throw 404
            var getHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userGrantApi.GetUserGrantWithHttpInfoAsync(invalidUserId, invalidGrantId);
            });
            getHttpInfoException.ErrorCode.Should().Be(404);

            // ListGrantsForUserAndClientWithHttpInfoAsync with invalid userId - should throw 404
            var listClientHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userGrantApi.ListGrantsForUserAndClientWithHttpInfoAsync(invalidUserId, invalidClientId);
            });
            listClientHttpInfoException.ErrorCode.Should().Be(404);

            // RevokeUserGrantWithHttpInfoAsync with invalid userId - should throw 404
            var revokeHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userGrantApi.RevokeUserGrantWithHttpInfoAsync(invalidUserId, invalidGrantId);
            });
            revokeHttpInfoException.ErrorCode.Should().Be(404);

            // RevokeUserGrantsWithHttpInfoAsync with invalid userId - should throw 404
            var revokeAllHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userGrantApi.RevokeUserGrantsWithHttpInfoAsync(invalidUserId);
            });
            revokeAllHttpInfoException.ErrorCode.Should().Be(404);

            // RevokeGrantsForUserAndClientWithHttpInfoAsync with invalid userId - should throw 404
            var revokeClientHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userGrantApi.RevokeGrantsForUserAndClientWithHttpInfoAsync(invalidUserId, invalidClientId);
            });
            revokeClientHttpInfoException.ErrorCode.Should().Be(404);
        }

        #endregion
    }
}
