// <copyright file="AuthorizationServerClaimsApiTests.cs" company="Okta, Inc">
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
    /// <summary>
    /// Integration tests for AuthorizationServerClaimsApi covering all 5 available endpoints.
    /// 
    /// API Coverage:
    /// 1. GET /api/v1/authorizationServers/{authServerId}/claims - ListOAuth2Claims
    /// 2. POST /api/v1/authorizationServers/{authServerId}/claims - CreateOAuth2ClaimAsync
    /// 3. GET /api/v1/authorizationServers/{authServerId}/claims/{claimId} - GetOAuth2ClaimAsync
    /// 4. PUT /api/v1/authorizationServers/{authServerId}/claims/{claimId} - ReplaceOAuth2ClaimAsync
    /// 5. DELETE /api/v1/authorizationServers/{authServerId}/claims/{claimId} - DeleteOAuth2ClaimAsync
    /// 
    /// Each method also has a WithHttpInfo variant for returning detailed response information.
    /// </summary>
    public class AuthorizationServerClaimsApiTests
    {
        private readonly AuthorizationServerClaimsApi _claimsApi = new();
        private readonly AuthorizationServerApi _authServerApi = new();

        /// <summary>
        /// Comprehensive test covering all AuthorizationServerClaimsApi operations and endpoints.
        /// This single test covers the complete claim lifecycle:
        /// - Creating a custom token claim
        /// - Listing claims
        /// - Getting an individual claim
        /// - Replacing (updating) a claim
        /// - Deleting a claim
        /// </summary>
        [Fact]
        public async Task GivenAuthorizationServerClaimsApi_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            string createdAuthServerId = null;
            string createdClaimId = null;
            var testPrefix = $"dotnet-sdk-test-{Guid.NewGuid():N}".Substring(0, 30);

            try
            {
                // ========================================================================
                // SETUP: Create an Authorization Server for testing
                // ========================================================================

                var newAuthServer = new AuthorizationServer
                {
                    Name = $"{testPrefix}-authserver",
                    Description = "Test authorization server for claims API tests",
                    Audiences = new List<string> { $"https://api.{testPrefix}.example.com" }
                };

                var createdAuthServer = await _authServerApi.CreateAuthorizationServerAsync(newAuthServer);
                createdAuthServerId = createdAuthServer.Id;
                createdAuthServerId.Should().NotBeNullOrEmpty();

                // ========================================================================
                // SECTION 1: Create Custom Token Claim
                // ========================================================================

                #region CreateOAuth2Claim - POST /api/v1/authorizationServers/{authServerId}/claims

                var newClaim = new OAuth2Claim
                {
                    Name = $"{testPrefix}_custom_claim",
                    Status = LifecycleStatus.ACTIVE,
                    ClaimType = OAuth2ClaimType.RESOURCE,  // For access tokens
                    ValueType = OAuth2ClaimValueType.EXPRESSION,
                    Value = "user.email",
                    AlwaysIncludeInToken = true,
                    Conditions = new OAuth2ClaimConditions
                    {
                        Scopes = new List<string>() // Empty means all scopes
                    }
                };

                var createdClaim = await _claimsApi.CreateOAuth2ClaimAsync(createdAuthServerId, newClaim);

                createdClaim.Should().NotBeNull();
                createdClaim.Id.Should().NotBeNullOrEmpty();
                createdClaim.Name.Should().Be(newClaim.Name);
                createdClaim.ClaimType.Should().Be(OAuth2ClaimType.RESOURCE);
                createdClaim.ValueType.Should().Be(OAuth2ClaimValueType.EXPRESSION);
                createdClaim.Value.Should().Be("user.email");
                createdClaim.AlwaysIncludeInToken.Should().BeTrue();
                createdClaim.System.Should().BeFalse("Custom claims are not system claims");
                createdClaim.Status.Should().Be(LifecycleStatus.ACTIVE);

                createdClaimId = createdClaim.Id;

                // Verify WithHttpInfo variant for Create
                var newClaim2 = new OAuth2Claim
                {
                    Name = $"{testPrefix}_claim2",
                    Status = LifecycleStatus.ACTIVE,
                    ClaimType = OAuth2ClaimType.IDENTITY,  // For ID tokens
                    ValueType = OAuth2ClaimValueType.EXPRESSION,
                    Value = "user.firstName",
                    AlwaysIncludeInToken = false
                };

                var createResponse = await _claimsApi.CreateOAuth2ClaimWithHttpInfoAsync(createdAuthServerId, newClaim2);
                createResponse.Should().NotBeNull();
                createResponse.Data.Should().NotBeNull();
                createResponse.Data.Id.Should().NotBeNullOrEmpty();
                createResponse.Data.ClaimType.Should().Be(OAuth2ClaimType.IDENTITY);

                var secondClaimId = createResponse.Data.Id;

                #endregion

                // ========================================================================
                // SECTION 2: List Custom Token Claims
                // ========================================================================

                #region ListOAuth2Claims - GET /api/v1/authorizationServers/{authServerId}/claims

                var allClaims = await _claimsApi.ListOAuth2Claims(createdAuthServerId).ToListAsync();

                allClaims.Should().NotBeNull();
                allClaims.Should().NotBeEmpty();
                
                // Should contain both custom claims created and system claims
                allClaims.Should().Contain(c => c.Id == createdClaimId);
                allClaims.Should().Contain(c => c.Id == secondClaimId);
                
                // Verify system claims exist (like sub, iss, aud)
                var systemClaims = allClaims.Where(c => c.System).ToList();
                systemClaims.Should().NotBeEmpty("Authorization servers have system claims by default");

                // Custom claims should not be system claims
                var customClaim = allClaims.FirstOrDefault(c => c.Id == createdClaimId);
                customClaim.Should().NotBeNull();
                customClaim!.System.Should().BeFalse();
                customClaim.Name.Should().Be(newClaim.Name);

                // WithHttpInfo variant
                var listResponse = await _claimsApi.ListOAuth2ClaimsWithHttpInfoAsync(createdAuthServerId);
                listResponse.Should().NotBeNull();
                listResponse.Data.Should().NotBeNull();
                listResponse.Data.Count.Should().BeGreaterThanOrEqualTo(2, "At least our 2 custom claims should exist");

                #endregion

                // ========================================================================
                // SECTION 3: Get Individual Custom Token Claim
                // ========================================================================

                #region GetOAuth2Claim - GET /api/v1/authorizationServers/{authServerId}/claims/{claimId}

                var retrievedClaim = await _claimsApi.GetOAuth2ClaimAsync(createdAuthServerId, createdClaimId);

                retrievedClaim.Should().NotBeNull();
                retrievedClaim.Id.Should().Be(createdClaimId);
                retrievedClaim.Name.Should().Be(newClaim.Name);
                retrievedClaim.ClaimType.Should().Be(OAuth2ClaimType.RESOURCE);
                retrievedClaim.ValueType.Should().Be(OAuth2ClaimValueType.EXPRESSION);
                retrievedClaim.Value.Should().Be("user.email");
                retrievedClaim.AlwaysIncludeInToken.Should().BeTrue();
                retrievedClaim.System.Should().BeFalse();
                retrievedClaim.Status.Should().Be(LifecycleStatus.ACTIVE);
                retrievedClaim.Links.Should().NotBeNull();

                // WithHttpInfo variant
                var getResponse = await _claimsApi.GetOAuth2ClaimWithHttpInfoAsync(createdAuthServerId, createdClaimId);
                getResponse.Should().NotBeNull();
                getResponse.Data.Should().NotBeNull();
                getResponse.Data.Id.Should().Be(createdClaimId);

                #endregion

                // ========================================================================
                // SECTION 4: Replace (Update) Custom Token Claim
                // ========================================================================

                #region ReplaceOAuth2Claim - PUT /api/v1/authorizationServers/{authServerId}/claims/{claimId}

                var updatedClaim = new OAuth2Claim
                {
                    Name = $"{testPrefix}_updated_claim",
                    Status = LifecycleStatus.ACTIVE,
                    ClaimType = OAuth2ClaimType.RESOURCE,
                    ValueType = OAuth2ClaimValueType.EXPRESSION,
                    Value = "user.displayName",  // Changed expression
                    AlwaysIncludeInToken = true,  // For RESOURCE claims this is always true
                    Conditions = new OAuth2ClaimConditions
                    {
                        Scopes = new List<string> { "openid", "profile" }  // Added scope conditions
                    }
                };

                var replacedClaim = await _claimsApi.ReplaceOAuth2ClaimAsync(createdAuthServerId, createdClaimId, updatedClaim);

                replacedClaim.Should().NotBeNull();
                replacedClaim.Id.Should().Be(createdClaimId);
                replacedClaim.Name.Should().Be(updatedClaim.Name);
                replacedClaim.Value.Should().Be("user.displayName");
                replacedClaim.AlwaysIncludeInToken.Should().BeTrue("For RESOURCE type claims, AlwaysIncludeInToken is always true");
                replacedClaim.Conditions.Should().NotBeNull();
                replacedClaim.Conditions.Scopes.Should().NotBeNull();
                replacedClaim.Conditions.Scopes.Should().Contain("openid");
                replacedClaim.Conditions.Scopes.Should().Contain("profile");

                // Verify the update persisted by fetching again
                var verifiedClaim = await _claimsApi.GetOAuth2ClaimAsync(createdAuthServerId, createdClaimId);
                verifiedClaim.Name.Should().Be(updatedClaim.Name);
                verifiedClaim.Value.Should().Be("user.displayName");

                // WithHttpInfo variant - update back to verify
                var revertClaim = new OAuth2Claim
                {
                    Name = $"{testPrefix}_reverted_claim",
                    Status = LifecycleStatus.ACTIVE,
                    ClaimType = OAuth2ClaimType.RESOURCE,
                    ValueType = OAuth2ClaimValueType.EXPRESSION,
                    Value = "user.lastName",
                    AlwaysIncludeInToken = true
                };

                var replaceResponse = await _claimsApi.ReplaceOAuth2ClaimWithHttpInfoAsync(
                    createdAuthServerId, 
                    createdClaimId, 
                    revertClaim);

                replaceResponse.Should().NotBeNull();
                replaceResponse.Data.Should().NotBeNull();
                replaceResponse.Data.Value.Should().Be("user.lastName");
                replaceResponse.Data.AlwaysIncludeInToken.Should().BeTrue();

                #endregion

                // ========================================================================
                // SECTION 5: Delete Custom Token Claim
                // ========================================================================

                #region DeleteOAuth2Claim - DELETE /api/v1/authorizationServers/{authServerId}/claims/{claimId}

                // Delete the second claim using basic method
                await _claimsApi.DeleteOAuth2ClaimAsync(createdAuthServerId, secondClaimId);

                // Verify deletion - Get should throw ApiException with 404
                var getDeletedAction = async () => await _claimsApi.GetOAuth2ClaimAsync(createdAuthServerId, secondClaimId);
                await getDeletedAction.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404);

                // Delete the first claim using WithHttpInfo variant
                var deleteResponse = await _claimsApi.DeleteOAuth2ClaimWithHttpInfoAsync(createdAuthServerId, createdClaimId);
                deleteResponse.Should().NotBeNull();
                // DELETE returns 204 No Content

                // Verify deletion
                var getFirstDeletedAction = async () => await _claimsApi.GetOAuth2ClaimAsync(createdAuthServerId, createdClaimId);
                await getFirstDeletedAction.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404);

                // Mark claim as deleted for cleanup
                createdClaimId = null;

                // Verify claims are no longer in the list
                var remainingClaims = await _claimsApi.ListOAuth2Claims(createdAuthServerId).ToListAsync();
                remainingClaims.Should().NotContain(c => c.Name.StartsWith(testPrefix));

                #endregion
            }
            finally
            {
                // Cleanup: Delete the authorization server (which will also delete any remaining claims)
                if (createdAuthServerId != null)
                {
                    try
                    {
                        await _authServerApi.DeactivateAuthorizationServerAsync(createdAuthServerId);
                        await _authServerApi.DeleteAuthorizationServerAsync(createdAuthServerId);
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }
            }
        }

        /// <summary>
        /// Test creating a GROUPS type claim with group filter.
        /// </summary>
        [Fact]
        public async Task GivenGroupsValueType_WhenCreatingClaim_ThenClaimIsCreatedWithGroupFilter()
        {
            string createdAuthServerId = null;
            var testPrefix = $"dotnet-sdk-test-{Guid.NewGuid():N}".Substring(0, 30);

            try
            {
                // Setup: Create an Authorization Server
                var authServer = new AuthorizationServer
                {
                    Name = $"{testPrefix}-authserver",
                    Description = "Test auth server for groups claim",
                    Audiences = new List<string> { $"https://api.{testPrefix}.example.com" }
                };

                var createdAuthServer = await _authServerApi.CreateAuthorizationServerAsync(authServer);
                createdAuthServerId = createdAuthServer.Id;

                // Create a GROUPS type claim
                var groupsClaim = new OAuth2Claim
                {
                    Name = "groups",
                    Status = LifecycleStatus.ACTIVE,
                    ClaimType = OAuth2ClaimType.RESOURCE,
                    ValueType = OAuth2ClaimValueType.GROUPS,
                    Value = ".*",  // Regex to match all groups
                    GroupFilterType = OAuth2ClaimGroupFilterType.REGEX,
                    AlwaysIncludeInToken = true
                };

                var createdClaim = await _claimsApi.CreateOAuth2ClaimAsync(createdAuthServerId, groupsClaim);

                createdClaim.Should().NotBeNull();
                createdClaim.ValueType.Should().Be(OAuth2ClaimValueType.GROUPS);
                createdClaim.Value.Should().Be(".*");
                createdClaim.GroupFilterType.Should().Be(OAuth2ClaimGroupFilterType.REGEX);

                // Verify via Get
                var retrievedClaim = await _claimsApi.GetOAuth2ClaimAsync(createdAuthServerId, createdClaim.Id);
                retrievedClaim.ValueType.Should().Be(OAuth2ClaimValueType.GROUPS);
                retrievedClaim.GroupFilterType.Should().Be(OAuth2ClaimGroupFilterType.REGEX);
            }
            finally
            {
                if (createdAuthServerId != null)
                {
                    try
                    {
                        await _authServerApi.DeactivateAuthorizationServerAsync(createdAuthServerId);
                        await _authServerApi.DeleteAuthorizationServerAsync(createdAuthServerId);
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }
            }
        }

        /// <summary>
        /// Test creating an IDENTITY type claim (for ID tokens).
        /// </summary>
        [Fact]
        public async Task GivenIdentityClaimType_WhenCreatingClaim_ThenClaimIsCreatedForIdTokens()
        {
            string createdAuthServerId = null;
            var testPrefix = $"dotnet-sdk-test-{Guid.NewGuid():N}".Substring(0, 30);

            try
            {
                // Setup: Create an Authorization Server
                var authServer = new AuthorizationServer
                {
                    Name = $"{testPrefix}-authserver",
                    Description = "Test auth server for identity claim",
                    Audiences = new List<string> { $"https://api.{testPrefix}.example.com" }
                };

                var createdAuthServer = await _authServerApi.CreateAuthorizationServerAsync(authServer);
                createdAuthServerId = createdAuthServer.Id;

                // Create an IDENTITY type claim for ID tokens (use unique name to avoid conflict with system claims)
                var identityClaim = new OAuth2Claim
                {
                    Name = $"{testPrefix}_username",
                    Status = LifecycleStatus.ACTIVE,
                    ClaimType = OAuth2ClaimType.IDENTITY,  // For ID tokens
                    ValueType = OAuth2ClaimValueType.EXPRESSION,
                    Value = "user.login",
                    AlwaysIncludeInToken = false  // Can be false for ID token claims
                };

                var createdClaim = await _claimsApi.CreateOAuth2ClaimAsync(createdAuthServerId, identityClaim);

                createdClaim.Should().NotBeNull();
                createdClaim.ClaimType.Should().Be(OAuth2ClaimType.IDENTITY);
                createdClaim.AlwaysIncludeInToken.Should().BeFalse();

                // Verify via Get
                var retrievedClaim = await _claimsApi.GetOAuth2ClaimAsync(createdAuthServerId, createdClaim.Id);
                retrievedClaim.ClaimType.Should().Be(OAuth2ClaimType.IDENTITY);
                retrievedClaim.Name.Should().Be($"{testPrefix}_username");
                retrievedClaim.Value.Should().Be("user.login");
            }
            finally
            {
                if (createdAuthServerId != null)
                {
                    try
                    {
                        await _authServerApi.DeactivateAuthorizationServerAsync(createdAuthServerId);
                        await _authServerApi.DeleteAuthorizationServerAsync(createdAuthServerId);
                    }
                    catch
                    {
                        // Ignore cleanup errors
                    }
                }
            }
        }
    }
}
