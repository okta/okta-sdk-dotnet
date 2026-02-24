// <copyright file="IdentityProviderUsersApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for IdentityProviderUsersApi covering all 12 methods.
    /// 
    /// API Coverage:
    /// 1. POST /api/v1/idps/{idpId}/users/{userId} - LinkUserToIdentityProviderAsync, LinkUserToIdentityProviderWithHttpInfoAsync
    /// 2. GET /api/v1/idps/{idpId}/users/{userId} - GetIdentityProviderApplicationUserAsync, GetIdentityProviderApplicationUserWithHttpInfoAsync
    /// 3. GET /api/v1/idps/{idpId}/users - ListIdentityProviderApplicationUsers, ListIdentityProviderApplicationUsersWithHttpInfoAsync
    /// 4. GET /api/v1/users/{id}/idps - ListUserIdentityProviders, ListUserIdentityProvidersWithHttpInfoAsync
    /// 5. GET /api/v1/idps/{idpId}/users/{userId}/credentials/tokens - ListSocialAuthTokens, ListSocialAuthTokensWithHttpInfoAsync
    /// 6. DELETE /api/v1/idps/{idpId}/users/{userId} - UnlinkUserFromIdentityProviderAsync, UnlinkUserFromIdentityProviderWithHttpInfoAsync
    /// </summary>
    public class IdentityProviderUsersApiTests
    {
        private readonly IdentityProviderUsersApi _idpUsersApi = new();
        private readonly IdentityProviderApi _idpApi = new();
        private readonly UserApi _userApi = new();
        private readonly UserLifecycleApi _userLifecycleApi = new();

        [Fact]
        public async Task GivenIdentityProviderUsersApi_WhenPerformingLifecycleOperations_ThenAll12MethodsWork()
        {
            string idpId = null;
            string userId = null;

            try
            {
                // SETUP: Create temporary Identity Provider and User
                var idp = await _idpApi.CreateIdentityProviderAsync(CreateDummyIdpTemplate($"UsersLifecycleTest-{Guid.NewGuid()}"));
                idpId = idp.Id;

                var uniqueEmail = $"idp-user-test-{Guid.NewGuid()}@okta.test.com";
                var user = await _userApi.CreateUserAsync(new CreateUserRequest
                {
                    Profile = new UserProfile
                    {
                        FirstName = "IdpUserTest",
                        LastName = "User",
                        Email = uniqueEmail,
                        Login = uniqueEmail
                    }
                });
                userId = user.Id;

                // 1. Link User to IdP
                var externalId = $"external-{Guid.NewGuid()}";
                var linkRequest = new UserIdentityProviderLinkRequest { ExternalId = externalId };
                
                var linkedUser = await _idpUsersApi.LinkUserToIdentityProviderAsync(idpId, userId, linkRequest);
                linkedUser.ExternalId.Should().Be(externalId);

                await _idpUsersApi.UnlinkUserFromIdentityProviderAsync(idpId, userId);
                var linkHttp = await _idpUsersApi.LinkUserToIdentityProviderWithHttpInfoAsync(idpId, userId, linkRequest);
                linkHttp.StatusCode.Should().Be(HttpStatusCode.OK);

                // 2. Get Linked User
                var fetchedUser = await _idpUsersApi.GetIdentityProviderApplicationUserAsync(idpId, userId);
                fetchedUser.Id.Should().Be(userId);

                var fetchedHttp = await _idpUsersApi.GetIdentityProviderApplicationUserWithHttpInfoAsync(idpId, userId);
                fetchedHttp.StatusCode.Should().Be(HttpStatusCode.OK);

                // 3. List Users for IdP
                var users = await _idpUsersApi.ListIdentityProviderApplicationUsers(idpId).ToListAsync();
                users.Should().Contain(u => u.Id == userId);

                var usersHttp = await _idpUsersApi.ListIdentityProviderApplicationUsersWithHttpInfoAsync(idpId);
                usersHttp.StatusCode.Should().Be(HttpStatusCode.OK);

                // 4. List IdPs for User
                var userIdps = await _idpUsersApi.ListUserIdentityProviders(userId).ToListAsync();
                userIdps.Should().Contain(i => i.Id == idpId);

                var userIdpsHttp = await _idpUsersApi.ListUserIdentityProvidersWithHttpInfoAsync(userId);
                userIdpsHttp.StatusCode.Should().Be(HttpStatusCode.OK);

                // 5. List Social Auth Tokens
                var tokens = await _idpUsersApi.ListSocialAuthTokens(idpId, userId).ToListAsync();
                tokens.Should().NotBeNull();

                var tokensHttp = await _idpUsersApi.ListSocialAuthTokensWithHttpInfoAsync(idpId, userId);
                tokensHttp.StatusCode.Should().Be(HttpStatusCode.OK);

                // 6. Unlink User
                var unlinkHttp = await _idpUsersApi.UnlinkUserFromIdentityProviderWithHttpInfoAsync(idpId, userId);
                unlinkHttp.StatusCode.Should().BeOneOf(HttpStatusCode.OK, HttpStatusCode.NoContent);
            }
            finally
            {
                // CLEANUP
                if (!string.IsNullOrEmpty(idpId))
                {
                    try
                    {
                        var currentIdp = await _idpApi.GetIdentityProviderAsync(idpId);
                        if (currentIdp.Status == LifecycleStatus.ACTIVE)
                        {
                            await _idpApi.DeactivateIdentityProviderAsync(idpId);
                            await Task.Delay(1000);
                        }
                        await _idpApi.DeleteIdentityProviderAsync(idpId);
                    }
                    catch (ApiException) { }
                }

                if (!string.IsNullOrEmpty(userId))
                {
                    try
                    {
                        await _userLifecycleApi.DeactivateUserAsync(userId);
                        await Task.Delay(1000);
                        await _userApi.DeleteUserAsync(userId);
                    }
                    catch (ApiException) { }
                }
            }
        }

        private IdentityProvider CreateDummyIdpTemplate(string name) => new()
        {
            Type = IdentityProviderType.OIDC,
            Name = name,
            Protocol = new IdentityProviderProtocol(new ProtocolOidc
            {
                // FIX: Added explicit Protocol Type
                Type = ProtocolOidc.TypeEnum.OIDC,
                Endpoints = new OAuthEndpoints 
                {
                    Authorization = new OAuthAuthorizationEndpoint { Url = "https://test.example.com/auth", Binding = "HTTP-REDIRECT" },
                    Token = new OAuthTokenEndpoint { Url = "https://test.example.com/token", Binding = "HTTP-POST" },
                    UserInfo = new OidcUserInfoEndpoint { Url = "https://test.example.com/userinfo", Binding = "HTTP-REDIRECT" },
                    Jwks = new OidcJwksEndpoint { Url = "https://test.example.com/jwks", Binding = "HTTP-REDIRECT" }
                },
                Scopes = ["openid"],
                Issuer = new ProtocolEndpointOidcIssuer { Url = "https://test.example.com" },
                Credentials = new OAuthCredentials { _Client = new OAuthCredentialsClient { ClientId = "id", ClientSecret = "sec" } }
            }),
            Policy = new IdentityProviderPolicy 
            {
                Provisioning = new Provisioning 
                { 
                    Action = "AUTO",
                    // FIX: Added missing Provisioning sub-objects
                    Groups = new ProvisioningGroups { Action = "NONE" },
                    Conditions = new ProvisioningConditions { Deprovisioned = new ProvisioningDeprovisionedCondition { Action = "NONE" }, Suspended = new ProvisioningSuspendedCondition { Action = "NONE" } }
                },
                AccountLink = new PolicyAccountLink { Action = "AUTO" },
                Subject = new PolicySubject { MatchType = "USERNAME", UserNameTemplate = new PolicyUserNameTemplate { Template = "idpuser.email" } }
            }
        };
    }
}