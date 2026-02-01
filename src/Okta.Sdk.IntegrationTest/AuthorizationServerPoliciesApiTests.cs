// <copyright file="AuthorizationServerPoliciesApiTests.cs" company="Okta, Inc">
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
    /// Integration tests for AuthorizationServerPoliciesApi covering all 7 available endpoints.
    /// 
    /// API Coverage:
    /// 1. GET /api/v1/authorizationServers/{authServerId}/policies - ListAuthorizationServerPolicies
    /// 2. POST /api/v1/authorizationServers/{authServerId}/policies - CreateAuthorizationServerPolicy
    /// 3. GET /api/v1/authorizationServers/{authServerId}/policies/{policyId} - GetAuthorizationServerPolicy
    /// 4. PUT /api/v1/authorizationServers/{authServerId}/policies/{policyId} - ReplaceAuthorizationServerPolicy
    /// 5. DELETE /api/v1/authorizationServers/{authServerId}/policies/{policyId} - DeleteAuthorizationServerPolicy
    /// 6. POST /api/v1/authorizationServers/{authServerId}/policies/{policyId}/lifecycle/activate - ActivateAuthorizationServerPolicy
    /// 7. POST /api/v1/authorizationServers/{authServerId}/policies/{policyId}/lifecycle/deactivate - DeactivateAuthorizationServerPolicy
    /// 
    /// Each method also has a WithHttpInfo variant for returning detailed response information.
    /// </summary>
    public class AuthorizationServerPoliciesApiTests
    {
        private readonly AuthorizationServerPoliciesApi _policiesApi = new();
        private readonly AuthorizationServerApi _authServerApi = new();

        /// <summary>
        /// Comprehensive test covering all AuthorizationServerPoliciesApi operations.
        /// This single test covers the complete policy lifecycle:
        /// - Listing policies
        /// - Creating a new policy
        /// - Getting a policy by ID
        /// - Updating a policy
        /// - Deactivating the policy
        /// - Activating the policy
        /// - Deleting the policy (must be deactivated first)
        /// </summary>
        [Fact]
        public async Task GivenAuthorizationServerPoliciesApi_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            string createdAuthServerId = null;
            string createdPolicyId = null;
            var testPrefix = $"dotnet-sdk-test-{Guid.NewGuid():N}".Substring(0, 30);

            try
            {
                // ========================================================================
                // SETUP: Create an Authorization Server for testing
                // ========================================================================

                var newAuthServer = new AuthorizationServer
                {
                    Name = $"{testPrefix}-authserver",
                    Description = "Test authorization server for policies API tests",
                    Audiences = new List<string> { $"https://api.{testPrefix}.example.com" }
                };

                var createdAuthServer = await _authServerApi.CreateAuthorizationServerAsync(newAuthServer);
                createdAuthServerId = createdAuthServer.Id;
                createdAuthServerId.Should().NotBeNullOrEmpty();

                // ========================================================================
                // SECTION 1: List All Policies (Initial State)
                // ========================================================================

                #region ListAuthorizationServerPolicies - GET /api/v1/authorizationServers/{authServerId}/policies

                // Test using the synchronous collection method
                var policiesCollection = _policiesApi.ListAuthorizationServerPolicies(createdAuthServerId);
                policiesCollection.Should().NotBeNull("Collection method should return a valid collection");

                // Enumerate the collection to get actual results
                var initialPolicies = new List<AuthorizationServerPolicy>();
                await foreach (var policy in policiesCollection)
                {
                    initialPolicies.Add(policy);
                }

                // A new auth server may have a default policy
                initialPolicies.Should().NotBeNull("Policies list should not be null");
                var initialCount = initialPolicies.Count;

                // Test using the WithHttpInfo variant
                var policiesWithHttpInfo = await _policiesApi.ListAuthorizationServerPoliciesWithHttpInfoAsync(createdAuthServerId);
                policiesWithHttpInfo.Should().NotBeNull("WithHttpInfo should return a valid response");

                #endregion

                // ========================================================================
                // SECTION 2: Create a New Policy
                // ========================================================================

                #region CreateAuthorizationServerPolicy - POST /api/v1/authorizationServers/{authServerId}/policies

                var newPolicy = new AuthorizationServerPolicy
                {
                    Type = AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY,
                    Name = $"{testPrefix}-policy",
                    Description = "Test policy for SDK integration tests",
                    Priority = 1,
                    Status = AuthorizationServerPolicy.StatusEnum.ACTIVE,
                    Conditions = new AuthorizationServerPolicyConditions
                    {
                        Clients = new ClientPolicyCondition
                        {
                            Include = new List<string> { "ALL_CLIENTS" }
                        }
                    }
                };

                var createdPolicy = await _policiesApi.CreateAuthorizationServerPolicyAsync(createdAuthServerId, newPolicy);

                createdPolicy.Should().NotBeNull("Created policy should not be null");
                createdPolicy.Id.Should().NotBeNullOrEmpty("Created policy should have an ID");
                createdPolicy.Type.Should().Be(AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY, 
                    "Type should be OAUTH_AUTHORIZATION_POLICY");
                createdPolicy.Status.Should().Be(AuthorizationServerPolicy.StatusEnum.ACTIVE, 
                    "Newly created policy should be ACTIVE");
                createdPolicy.Name.Should().Be($"{testPrefix}-policy", "Name should match the request");
                createdPolicy.Description.Should().Be("Test policy for SDK integration tests", 
                    "Description should match");
                createdPolicy.Priority.Should().Be(1, "Priority should match");
                createdPolicy.System.Should().BeFalse("Custom policy should not be a system policy");
                createdPolicy.Conditions.Should().NotBeNull("Conditions should not be null");
                createdPolicy.Conditions.Clients.Should().NotBeNull("Clients condition should not be null");
                createdPolicy.Conditions.Clients.Include.Should().Contain("ALL_CLIENTS", 
                    "Should include ALL_CLIENTS");

                createdPolicyId = createdPolicy.Id;

                // Test CreateAuthorizationServerPolicyWithHttpInfo
                var secondPolicy = new AuthorizationServerPolicy
                {
                    Type = AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY,
                    Name = $"{testPrefix}-policy-2",
                    Description = "Second test policy",
                    Priority = 2,
                    Status = AuthorizationServerPolicy.StatusEnum.ACTIVE, // API creates policies as ACTIVE by default
                    Conditions = new AuthorizationServerPolicyConditions
                    {
                        Clients = new ClientPolicyCondition
                        {
                            Include = new List<string> { "ALL_CLIENTS" }
                        }
                    }
                };

                var createWithHttpInfo = await _policiesApi.CreateAuthorizationServerPolicyWithHttpInfoAsync(
                    createdAuthServerId, secondPolicy);
                createWithHttpInfo.Should().NotBeNull();
                createWithHttpInfo.Data.Should().NotBeNull();
                var secondPolicyId = createWithHttpInfo.Data.Id;
                createWithHttpInfo.Data.Status.Should().Be(AuthorizationServerPolicy.StatusEnum.ACTIVE);

                #endregion

                // ========================================================================
                // SECTION 3: Get Individual Policy
                // ========================================================================

                #region GetAuthorizationServerPolicy - GET /api/v1/authorizationServers/{authServerId}/policies/{policyId}

                // Test GetAuthorizationServerPolicyAsync
                var retrievedPolicy = await _policiesApi.GetAuthorizationServerPolicyAsync(
                    createdAuthServerId, createdPolicyId);

                retrievedPolicy.Should().NotBeNull("Retrieved policy should not be null");
                retrievedPolicy.Id.Should().Be(createdPolicyId, "Policy ID should match");
                retrievedPolicy.Name.Should().Be($"{testPrefix}-policy", "Name should match");
                retrievedPolicy.Type.Should().Be(AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY);
                retrievedPolicy.Status.Should().Be(AuthorizationServerPolicy.StatusEnum.ACTIVE);
                retrievedPolicy.Created.Should().NotBe(default, "Created timestamp should be set");
                retrievedPolicy.LastUpdated.Should().NotBe(default, "LastUpdated timestamp should be set");

                // Test GetAuthorizationServerPolicyWithHttpInfoAsync
                var policyWithHttpInfo = await _policiesApi.GetAuthorizationServerPolicyWithHttpInfoAsync(
                    createdAuthServerId, createdPolicyId);
                policyWithHttpInfo.Should().NotBeNull();
                policyWithHttpInfo.Data.Should().NotBeNull();
                policyWithHttpInfo.Data.Id.Should().Be(createdPolicyId);

                #endregion

                // ========================================================================
                // SECTION 4: Replace (Update) Policy
                // ========================================================================

                #region ReplaceAuthorizationServerPolicy - PUT /api/v1/authorizationServers/{authServerId}/policies/{policyId}

                // Update the policy
                var updatedPolicy = new AuthorizationServerPolicy
                {
                    Id = createdPolicyId,
                    Type = AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY,
                    Name = $"{testPrefix}-policy-updated",
                    Description = "Updated description for test policy",
                    Priority = 1,
                    Status = AuthorizationServerPolicy.StatusEnum.ACTIVE,
                    Conditions = new AuthorizationServerPolicyConditions
                    {
                        Clients = new ClientPolicyCondition
                        {
                            Include = new List<string> { "ALL_CLIENTS" }
                        }
                    }
                };

                var replacedPolicy = await _policiesApi.ReplaceAuthorizationServerPolicyAsync(
                    createdAuthServerId, createdPolicyId, updatedPolicy);

                replacedPolicy.Should().NotBeNull("Replaced policy should not be null");
                replacedPolicy.Id.Should().Be(createdPolicyId, "Policy ID should remain the same");
                replacedPolicy.Name.Should().Be($"{testPrefix}-policy-updated", "Name should be updated");
                replacedPolicy.Description.Should().Be("Updated description for test policy", 
                    "Description should be updated");

                // Verify the update by getting the policy again
                var verifyUpdate = await _policiesApi.GetAuthorizationServerPolicyAsync(
                    createdAuthServerId, createdPolicyId);
                verifyUpdate.Name.Should().Be($"{testPrefix}-policy-updated");

                // Test ReplaceAuthorizationServerPolicyWithHttpInfoAsync
                var replaceWithHttpInfo = await _policiesApi.ReplaceAuthorizationServerPolicyWithHttpInfoAsync(
                    createdAuthServerId, createdPolicyId, updatedPolicy);
                replaceWithHttpInfo.Should().NotBeNull();
                replaceWithHttpInfo.Data.Should().NotBeNull();

                #endregion

                // ========================================================================
                // SECTION 5: Deactivate Policy
                // ========================================================================

                #region DeactivateAuthorizationServerPolicy - POST /api/v1/authorizationServers/{authServerId}/policies/{policyId}/lifecycle/deactivate

                // Deactivate the policy
                await _policiesApi.DeactivateAuthorizationServerPolicyAsync(createdAuthServerId, createdPolicyId);

                // Verify the policy is now inactive
                var deactivatedPolicy = await _policiesApi.GetAuthorizationServerPolicyAsync(
                    createdAuthServerId, createdPolicyId);
                deactivatedPolicy.Status.Should().Be(AuthorizationServerPolicy.StatusEnum.INACTIVE, 
                    "Policy should now be INACTIVE");

                // Test DeactivateAuthorizationServerPolicyWithHttpInfoAsync on the second policy (already inactive, but should work)
                // First activate it
                await _policiesApi.ActivateAuthorizationServerPolicyAsync(createdAuthServerId, secondPolicyId);
                var deactivateWithHttpInfo = await _policiesApi.DeactivateAuthorizationServerPolicyWithHttpInfoAsync(
                    createdAuthServerId, secondPolicyId);
                deactivateWithHttpInfo.Should().NotBeNull();

                #endregion

                // ========================================================================
                // SECTION 6: Activate Policy
                // ========================================================================

                #region ActivateAuthorizationServerPolicy - POST /api/v1/authorizationServers/{authServerId}/policies/{policyId}/lifecycle/activate

                // Activate the policy
                await _policiesApi.ActivateAuthorizationServerPolicyAsync(createdAuthServerId, createdPolicyId);

                // Verify the policy is now active
                var activatedPolicy = await _policiesApi.GetAuthorizationServerPolicyAsync(
                    createdAuthServerId, createdPolicyId);
                activatedPolicy.Status.Should().Be(AuthorizationServerPolicy.StatusEnum.ACTIVE, 
                    "Policy should now be ACTIVE");

                // Test ActivateAuthorizationServerPolicyWithHttpInfoAsync
                // First deactivate second policy
                await _policiesApi.DeactivateAuthorizationServerPolicyAsync(createdAuthServerId, secondPolicyId);
                var activateWithHttpInfo = await _policiesApi.ActivateAuthorizationServerPolicyWithHttpInfoAsync(
                    createdAuthServerId, secondPolicyId);
                activateWithHttpInfo.Should().NotBeNull();

                #endregion

                // ========================================================================
                // SECTION 7: Delete Policy
                // ========================================================================

                #region DeleteAuthorizationServerPolicy - DELETE /api/v1/authorizationServers/{authServerId}/policies/{policyId}

                // Note: Must deactivate policies before deleting them
                // Deactivate first policy
                await _policiesApi.DeactivateAuthorizationServerPolicyAsync(createdAuthServerId, createdPolicyId);

                // Test DeleteAuthorizationServerPolicyAsync
                await _policiesApi.DeleteAuthorizationServerPolicyAsync(createdAuthServerId, createdPolicyId);

                // Verify the policy is deleted (should throw 404)
                var deleteException = await Assert.ThrowsAsync<ApiException>(
                    () => _policiesApi.GetAuthorizationServerPolicyAsync(createdAuthServerId, createdPolicyId));
                deleteException.ErrorCode.Should().Be(404, "Deleted policy should return 404");

                createdPolicyId = null; // Mark as deleted for cleanup

                // Test DeleteAuthorizationServerPolicyWithHttpInfoAsync
                await _policiesApi.DeactivateAuthorizationServerPolicyAsync(createdAuthServerId, secondPolicyId);
                var deleteWithHttpInfo = await _policiesApi.DeleteAuthorizationServerPolicyWithHttpInfoAsync(
                    createdAuthServerId, secondPolicyId);
                deleteWithHttpInfo.Should().NotBeNull();

                #endregion

                // ========================================================================
                // SECTION 8: Verify Final State
                // ========================================================================

                #region Verify Final Policy State

                // List all policies again to verify the final state
                var finalPoliciesResponse = await _policiesApi.ListAuthorizationServerPoliciesWithHttpInfoAsync(
                    createdAuthServerId);
                
                // Both custom policies should be deleted
                if (finalPoliciesResponse.Data != null)
                {
                    finalPoliciesResponse.Data.Should().NotContain(p => p.Id == createdPolicyId);
                    finalPoliciesResponse.Data.Should().NotContain(p => p.Id == secondPolicyId);
                }

                #endregion
            }
            finally
            {
                // ========================================================================
                // CLEANUP
                // ========================================================================

                // Delete any remaining test policy
                if (!string.IsNullOrEmpty(createdPolicyId) && !string.IsNullOrEmpty(createdAuthServerId))
                {
                    try
                    {
                        // First try to deactivate, then delete
                        try
                        {
                            await _policiesApi.DeactivateAuthorizationServerPolicyAsync(
                                createdAuthServerId, createdPolicyId);
                        }
                        catch (ApiException)
                        {
                            // May already be inactive
                        }
                        await _policiesApi.DeleteAuthorizationServerPolicyAsync(
                            createdAuthServerId, createdPolicyId);
                    }
                    catch (ApiException)
                    {
                        // Ignore cleanup errors
                    }
                }

                if (!string.IsNullOrEmpty(createdAuthServerId))
                {
                    try
                    {
                        await _authServerApi.DeactivateAuthorizationServerAsync(createdAuthServerId);
                        await _authServerApi.DeleteAuthorizationServerAsync(createdAuthServerId);
                    }
                    catch (ApiException)
                    {
                        // Ignore cleanup errors
                    }
                }
            }
        }

        /// <summary>
        /// Tests error handling when accessing non-existent policy.
        /// </summary>
        [Fact]
        public async Task GivenAuthorizationServerPoliciesApi_WhenAccessingNonExistentPolicy_ThenReturns404()
        {
            string createdAuthServerId = null;
            var testPrefix = $"dotnet-sdk-test-{Guid.NewGuid():N}".Substring(0, 30);

            try
            {
                // Setup: Create an Authorization Server
                var newAuthServer = new AuthorizationServer
                {
                    Name = $"{testPrefix}-authserver",
                    Description = "Test for non-existent policy access",
                    Audiences = new List<string> { $"https://api.{testPrefix}.example.com" }
                };

                var createdAuthServer = await _authServerApi.CreateAuthorizationServerAsync(newAuthServer);
                createdAuthServerId = createdAuthServer.Id;

                // Try to get a non-existent policy
                var nonExistentPolicyId = "00pNonExistent123456";

                var exception = await Assert.ThrowsAsync<ApiException>(
                    () => _policiesApi.GetAuthorizationServerPolicyAsync(createdAuthServerId, nonExistentPolicyId));

                exception.ErrorCode.Should().Be(404, "Should return 404 for non-existent policy");
            }
            finally
            {
                if (!string.IsNullOrEmpty(createdAuthServerId))
                {
                    try
                    {
                        await _authServerApi.DeactivateAuthorizationServerAsync(createdAuthServerId);
                        await _authServerApi.DeleteAuthorizationServerAsync(createdAuthServerId);
                    }
                    catch (ApiException)
                    {
                        // Ignore cleanup errors
                    }
                }
            }
        }

        /// <summary>
        /// Tests policy lifecycle operations and validates the deactivate/activate cycle.
        /// </summary>
        [Fact]
        public async Task GivenAuthorizationServerPoliciesApi_WhenPerformingLifecycleOperations_ThenStatusChangesCorrectly()
        {
            string createdAuthServerId = null;
            string createdPolicyId = null;
            var testPrefix = $"dotnet-sdk-test-{Guid.NewGuid():N}".Substring(0, 30);

            try
            {
                // Setup: Create an Authorization Server
                var newAuthServer = new AuthorizationServer
                {
                    Name = $"{testPrefix}-authserver",
                    Description = "Test for policy lifecycle",
                    Audiences = new List<string> { $"https://api.{testPrefix}.example.com" }
                };

                var createdAuthServer = await _authServerApi.CreateAuthorizationServerAsync(newAuthServer);
                createdAuthServerId = createdAuthServer.Id;

                // Create an active policy
                var newPolicy = new AuthorizationServerPolicy
                {
                    Type = AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY,
                    Name = $"{testPrefix}-lifecycle-policy",
                    Description = "Policy for lifecycle test",
                    Priority = 1,
                    Status = AuthorizationServerPolicy.StatusEnum.ACTIVE,
                    Conditions = new AuthorizationServerPolicyConditions
                    {
                        Clients = new ClientPolicyCondition
                        {
                            Include = new List<string> { "ALL_CLIENTS" }
                        }
                    }
                };

                var createdPolicy = await _policiesApi.CreateAuthorizationServerPolicyAsync(
                    createdAuthServerId, newPolicy);
                createdPolicyId = createdPolicy.Id;

                // Verify the policy is active
                createdPolicy.Status.Should().Be(AuthorizationServerPolicy.StatusEnum.ACTIVE,
                    "Newly created policy should be ACTIVE");

                // Deactivate the policy
                await _policiesApi.DeactivateAuthorizationServerPolicyAsync(createdAuthServerId, createdPolicyId);

                // Verify the policy is now inactive
                var deactivatedPolicy = await _policiesApi.GetAuthorizationServerPolicyAsync(
                    createdAuthServerId, createdPolicyId);
                deactivatedPolicy.Status.Should().Be(AuthorizationServerPolicy.StatusEnum.INACTIVE,
                    "Policy should be INACTIVE after deactivation");

                // Activate the policy
                await _policiesApi.ActivateAuthorizationServerPolicyAsync(createdAuthServerId, createdPolicyId);

                // Verify the policy is active again
                var activatedPolicy = await _policiesApi.GetAuthorizationServerPolicyAsync(
                    createdAuthServerId, createdPolicyId);
                activatedPolicy.Status.Should().Be(AuthorizationServerPolicy.StatusEnum.ACTIVE,
                    "Policy should be ACTIVE after activation");

                // Deactivate again and delete
                await _policiesApi.DeactivateAuthorizationServerPolicyAsync(createdAuthServerId, createdPolicyId);
                await _policiesApi.DeleteAuthorizationServerPolicyAsync(createdAuthServerId, createdPolicyId);

                // Verify the policy is deleted
                var deleteException = await Assert.ThrowsAsync<ApiException>(
                    () => _policiesApi.GetAuthorizationServerPolicyAsync(createdAuthServerId, createdPolicyId));
                deleteException.ErrorCode.Should().Be(404);

                createdPolicyId = null; // Mark as deleted
            }
            finally
            {
                // Cleanup
                if (!string.IsNullOrEmpty(createdPolicyId) && !string.IsNullOrEmpty(createdAuthServerId))
                {
                    try
                    {
                        await _policiesApi.DeactivateAuthorizationServerPolicyAsync(
                            createdAuthServerId, createdPolicyId);
                        await _policiesApi.DeleteAuthorizationServerPolicyAsync(
                            createdAuthServerId, createdPolicyId);
                    }
                    catch (ApiException)
                    {
                        // Ignore cleanup errors
                    }
                }

                if (!string.IsNullOrEmpty(createdAuthServerId))
                {
                    try
                    {
                        await _authServerApi.DeactivateAuthorizationServerAsync(createdAuthServerId);
                        await _authServerApi.DeleteAuthorizationServerAsync(createdAuthServerId);
                    }
                    catch (ApiException)
                    {
                        // Ignore cleanup errors
                    }
                }
            }
        }
    }
}
