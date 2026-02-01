// <copyright file="AuthorizationServerRulesApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for AuthorizationServerRulesApi.
    /// 
    /// These tests verify the complete lifecycle of Authorization Server Policy Rules
    /// against a real Okta environment, covering all 7 API endpoints:
    /// 1. ListAuthorizationServerPolicyRules
    /// 2. CreateAuthorizationServerPolicyRule
    /// 3. GetAuthorizationServerPolicyRule
    /// 4. ReplaceAuthorizationServerPolicyRule
    /// 5. DeleteAuthorizationServerPolicyRule
    /// 6. ActivateAuthorizationServerPolicyRule
    /// 7. DeactivateAuthorizationServerPolicyRule
    /// </summary>
    public class AuthorizationServerRulesApiTests
    {
        private readonly AuthorizationServerRulesApi _rulesApi;
        private readonly AuthorizationServerPoliciesApi _policiesApi;
        private readonly AuthorizationServerApi _authServerApi;

        public AuthorizationServerRulesApiTests()
        {
            var config = new Configuration
            {
                OktaDomain = Environment.GetEnvironmentVariable("OKTA_DOMAIN"),
                Token = Environment.GetEnvironmentVariable("OKTA_API_TOKEN")
            };

            _rulesApi = new AuthorizationServerRulesApi(config);
            _policiesApi = new AuthorizationServerPoliciesApi(config);
            _authServerApi = new AuthorizationServerApi(config);
        }

        /// <summary>
        /// Tests the complete lifecycle of Authorization Server Policy Rules:
        /// Create, List, Get, Update, Deactivate, Activate, and Delete operations.
        /// </summary>
        [Fact]
        public async Task GivenAuthorizationServerRulesApi_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            string createdAuthServerId = null;
            string createdPolicyId = null;
            string createdRuleId = null;
            string secondRuleId = null;
            var testPrefix = $"dotnet-sdk-test-{Guid.NewGuid():N}".Substring(0, 30);

            try
            {
                // Setup: Create an Authorization Server
                var newAuthServer = new AuthorizationServer
                {
                    Name = $"{testPrefix}-authserver",
                    Description = "Test Authorization Server for Rules API tests",
                    Audiences = new List<string> { $"https://api.{testPrefix}.example.com" }
                };

                var createdAuthServer = await _authServerApi.CreateAuthorizationServerAsync(newAuthServer);
                createdAuthServerId = createdAuthServer.Id;
                createdAuthServerId.Should().NotBeNullOrEmpty();

                // Setup: Create a Policy for the Authorization Server
                var newPolicy = new AuthorizationServerPolicy
                {
                    Type = AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY,
                    Name = $"{testPrefix}-policy",
                    Description = "Test policy for rules API tests",
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
                createdPolicyId.Should().NotBeNullOrEmpty();

                // =============================================
                // Test 1: CreateAuthorizationServerPolicyRule
                // =============================================
                var newRule = new AuthorizationServerPolicyRuleRequest
                {
                    Type = AuthorizationServerPolicyRuleRequest.TypeEnum.RESOURCEACCESS,
                    Name = $"{testPrefix}-rule-1",
                    Priority = 1,
                    Conditions = new AuthorizationServerPolicyRuleConditions
                    {
                        People = new AuthorizationServerPolicyPeopleCondition
                        {
                            Groups = new AuthorizationServerPolicyRuleGroupCondition
                            {
                                Include = new List<string> { "EVERYONE" }
                            }
                        },
                        GrantTypes = new GrantTypePolicyRuleCondition
                        {
                            Include = new List<string> { "authorization_code", "implicit" }
                        },
                        Scopes = new OAuth2ScopesMediationPolicyRuleCondition
                        {
                            Include = new List<string> { "*" }
                        }
                    },
                    Actions = new AuthorizationServerPolicyRuleActions
                    {
                        Token = new TokenAuthorizationServerPolicyRuleAction
                        {
                            AccessTokenLifetimeMinutes = 60,
                            RefreshTokenLifetimeMinutes = 0,
                            RefreshTokenWindowMinutes = 10080
                        }
                    }
                };

                var createdRule = await _rulesApi.CreateAuthorizationServerPolicyRuleAsync(
                    createdAuthServerId, createdPolicyId, newRule);

                createdRule.Should().NotBeNull("CreateAuthorizationServerPolicyRule should return a rule");
                createdRuleId = createdRule.Id;
                createdRuleId.Should().NotBeNullOrEmpty("Created rule should have an ID");
                createdRule.Name.Should().Be($"{testPrefix}-rule-1");
                createdRule.Type.Should().Be(AuthorizationServerPolicyRule.TypeEnum.RESOURCEACCESS);
                createdRule.Status.Should().Be(AuthorizationServerPolicyRule.StatusEnum.ACTIVE,
                    "Newly created rule should be ACTIVE by default");
                createdRule.Priority.Should().Be(1);
                createdRule.Actions.Should().NotBeNull();
                createdRule.Actions.Token.Should().NotBeNull();
                createdRule.Actions.Token.AccessTokenLifetimeMinutes.Should().Be(60);
                createdRule.Conditions.Should().NotBeNull();
                createdRule.Conditions.GrantTypes.Should().NotBeNull();
                createdRule.Conditions.GrantTypes.Include.Should().Contain("authorization_code");
                createdRule.Conditions.GrantTypes.Include.Should().Contain("implicit");

                // =============================================
                // Test 2: CreateAuthorizationServerPolicyRuleWithHttpInfo
                // =============================================
                var secondRule = new AuthorizationServerPolicyRuleRequest
                {
                    Type = AuthorizationServerPolicyRuleRequest.TypeEnum.RESOURCEACCESS,
                    Name = $"{testPrefix}-rule-2",
                    Priority = 2,
                    Conditions = new AuthorizationServerPolicyRuleConditions
                    {
                        People = new AuthorizationServerPolicyPeopleCondition
                        {
                            Groups = new AuthorizationServerPolicyRuleGroupCondition
                            {
                                Include = new List<string> { "EVERYONE" }
                            }
                        },
                        GrantTypes = new GrantTypePolicyRuleCondition
                        {
                            Include = new List<string> { "client_credentials" }
                        },
                        Scopes = new OAuth2ScopesMediationPolicyRuleCondition
                        {
                            Include = new List<string> { "*" }
                        }
                    },
                    Actions = new AuthorizationServerPolicyRuleActions
                    {
                        Token = new TokenAuthorizationServerPolicyRuleAction
                        {
                            AccessTokenLifetimeMinutes = 30,
                            RefreshTokenLifetimeMinutes = 0,
                            RefreshTokenWindowMinutes = 5040
                        }
                    }
                };

                var createWithHttpInfo = await _rulesApi.CreateAuthorizationServerPolicyRuleWithHttpInfoAsync(
                    createdAuthServerId, createdPolicyId, secondRule);
                createWithHttpInfo.Should().NotBeNull();
                createWithHttpInfo.Data.Should().NotBeNull();
                secondRuleId = createWithHttpInfo.Data.Id;
                createWithHttpInfo.Data.Status.Should().Be(AuthorizationServerPolicyRule.StatusEnum.ACTIVE);
                createWithHttpInfo.Data.Actions.Token.AccessTokenLifetimeMinutes.Should().Be(30);

                // =============================================
                // Test 3: ListAuthorizationServerPolicyRules
                // =============================================
                var rulesList = await _rulesApi.ListAuthorizationServerPolicyRules(
                    createdAuthServerId, createdPolicyId).ToListAsync();

                rulesList.Should().NotBeNull("ListAuthorizationServerPolicyRules should return a list");
                rulesList.Should().HaveCountGreaterThanOrEqualTo(2,
                    "Should have at least the two rules we created");
                rulesList.Should().Contain(r => r.Id == createdRuleId,
                    "List should contain the first created rule");
                rulesList.Should().Contain(r => r.Id == secondRuleId,
                    "List should contain the second created rule");

                // =============================================
                // Test 4: ListAuthorizationServerPolicyRulesWithHttpInfo
                // =============================================
                var listWithHttpInfo = await _rulesApi.ListAuthorizationServerPolicyRulesWithHttpInfoAsync(
                    createdAuthServerId, createdPolicyId);

                listWithHttpInfo.Should().NotBeNull();
                listWithHttpInfo.Data.Should().NotBeNull();
                listWithHttpInfo.Data.Should().HaveCountGreaterThanOrEqualTo(2);

                // =============================================
                // Test 5: GetAuthorizationServerPolicyRule
                // =============================================
                var retrievedRule = await _rulesApi.GetAuthorizationServerPolicyRuleAsync(
                    createdAuthServerId, createdPolicyId, createdRuleId);

                retrievedRule.Should().NotBeNull("GetAuthorizationServerPolicyRule should return the rule");
                retrievedRule.Id.Should().Be(createdRuleId);
                retrievedRule.Name.Should().Be($"{testPrefix}-rule-1");
                retrievedRule.Type.Should().Be(AuthorizationServerPolicyRule.TypeEnum.RESOURCEACCESS);
                retrievedRule.Actions.Token.AccessTokenLifetimeMinutes.Should().Be(60);

                // =============================================
                // Test 6: GetAuthorizationServerPolicyRuleWithHttpInfo
                // =============================================
                var getWithHttpInfo = await _rulesApi.GetAuthorizationServerPolicyRuleWithHttpInfoAsync(
                    createdAuthServerId, createdPolicyId, createdRuleId);

                getWithHttpInfo.Should().NotBeNull();
                getWithHttpInfo.Data.Should().NotBeNull();
                getWithHttpInfo.Data.Id.Should().Be(createdRuleId);

                // =============================================
                // Test 7: ReplaceAuthorizationServerPolicyRule
                // =============================================
                var updatedRule = new AuthorizationServerPolicyRuleRequest
                {
                    Type = AuthorizationServerPolicyRuleRequest.TypeEnum.RESOURCEACCESS,
                    Name = $"{testPrefix}-rule-1-updated",
                    Priority = 1,
                    Status = AuthorizationServerPolicyRuleRequest.StatusEnum.ACTIVE,
                    Conditions = new AuthorizationServerPolicyRuleConditions
                    {
                        People = new AuthorizationServerPolicyPeopleCondition
                        {
                            Groups = new AuthorizationServerPolicyRuleGroupCondition
                            {
                                Include = new List<string> { "EVERYONE" }
                            }
                        },
                        GrantTypes = new GrantTypePolicyRuleCondition
                        {
                            Include = new List<string> { "authorization_code", "implicit", "password" }
                        },
                        Scopes = new OAuth2ScopesMediationPolicyRuleCondition
                        {
                            Include = new List<string> { "*" }
                        }
                    },
                    Actions = new AuthorizationServerPolicyRuleActions
                    {
                        Token = new TokenAuthorizationServerPolicyRuleAction
                        {
                            AccessTokenLifetimeMinutes = 120,
                            RefreshTokenLifetimeMinutes = 0,
                            RefreshTokenWindowMinutes = 20160
                        }
                    }
                };

                var replacedRule = await _rulesApi.ReplaceAuthorizationServerPolicyRuleAsync(
                    createdAuthServerId, createdPolicyId, createdRuleId, updatedRule);

                replacedRule.Should().NotBeNull("ReplaceAuthorizationServerPolicyRule should return updated rule");
                replacedRule.Id.Should().Be(createdRuleId);
                replacedRule.Name.Should().Be($"{testPrefix}-rule-1-updated");
                replacedRule.Actions.Token.AccessTokenLifetimeMinutes.Should().Be(120,
                    "Token lifetime should be updated");
                replacedRule.Actions.Token.RefreshTokenWindowMinutes.Should().Be(20160);
                replacedRule.Conditions.GrantTypes.Include.Should().HaveCount(3);
                replacedRule.Conditions.GrantTypes.Include.Should().Contain("password");

                // =============================================
                // Test 8: ReplaceAuthorizationServerPolicyRuleWithHttpInfo
                // =============================================
                updatedRule.Name = $"{testPrefix}-rule-1-updated-again";
                updatedRule.Actions.Token.AccessTokenLifetimeMinutes = 90;

                var replaceWithHttpInfo = await _rulesApi.ReplaceAuthorizationServerPolicyRuleWithHttpInfoAsync(
                    createdAuthServerId, createdPolicyId, createdRuleId, updatedRule);

                replaceWithHttpInfo.Should().NotBeNull();
                replaceWithHttpInfo.Data.Should().NotBeNull();
                replaceWithHttpInfo.Data.Name.Should().Be($"{testPrefix}-rule-1-updated-again");
                replaceWithHttpInfo.Data.Actions.Token.AccessTokenLifetimeMinutes.Should().Be(90);

                // =============================================
                // Test 9: DeactivateAuthorizationServerPolicyRule
                // =============================================
                await _rulesApi.DeactivateAuthorizationServerPolicyRuleAsync(
                    createdAuthServerId, createdPolicyId, createdRuleId);

                var deactivatedRule = await _rulesApi.GetAuthorizationServerPolicyRuleAsync(
                    createdAuthServerId, createdPolicyId, createdRuleId);
                deactivatedRule.Status.Should().Be(AuthorizationServerPolicyRule.StatusEnum.INACTIVE,
                    "Rule should be INACTIVE after deactivation");

                // =============================================
                // Test 10: DeactivateAuthorizationServerPolicyRuleWithHttpInfo
                // =============================================
                // First activate the rule so we can deactivate with HttpInfo
                await _rulesApi.ActivateAuthorizationServerPolicyRuleAsync(
                    createdAuthServerId, createdPolicyId, createdRuleId);

                var deactivateWithHttpInfo = await _rulesApi.DeactivateAuthorizationServerPolicyRuleWithHttpInfoAsync(
                    createdAuthServerId, createdPolicyId, createdRuleId);
                deactivateWithHttpInfo.Should().NotBeNull();

                // Verify deactivation
                var checkDeactivated = await _rulesApi.GetAuthorizationServerPolicyRuleAsync(
                    createdAuthServerId, createdPolicyId, createdRuleId);
                checkDeactivated.Status.Should().Be(AuthorizationServerPolicyRule.StatusEnum.INACTIVE);

                // =============================================
                // Test 11: ActivateAuthorizationServerPolicyRule
                // =============================================
                await _rulesApi.ActivateAuthorizationServerPolicyRuleAsync(
                    createdAuthServerId, createdPolicyId, createdRuleId);

                var activatedRule = await _rulesApi.GetAuthorizationServerPolicyRuleAsync(
                    createdAuthServerId, createdPolicyId, createdRuleId);
                activatedRule.Status.Should().Be(AuthorizationServerPolicyRule.StatusEnum.ACTIVE,
                    "Rule should be ACTIVE after activation");

                // =============================================
                // Test 12: ActivateAuthorizationServerPolicyRuleWithHttpInfo
                // =============================================
                // First deactivate so we can activate with HttpInfo
                await _rulesApi.DeactivateAuthorizationServerPolicyRuleAsync(
                    createdAuthServerId, createdPolicyId, createdRuleId);

                var activateWithHttpInfo = await _rulesApi.ActivateAuthorizationServerPolicyRuleWithHttpInfoAsync(
                    createdAuthServerId, createdPolicyId, createdRuleId);
                activateWithHttpInfo.Should().NotBeNull();

                // Verify activation
                var checkActivated = await _rulesApi.GetAuthorizationServerPolicyRuleAsync(
                    createdAuthServerId, createdPolicyId, createdRuleId);
                checkActivated.Status.Should().Be(AuthorizationServerPolicyRule.StatusEnum.ACTIVE);

                // =============================================
                // Test 13: DeleteAuthorizationServerPolicyRule
                // =============================================
                // Deactivate before deleting
                await _rulesApi.DeactivateAuthorizationServerPolicyRuleAsync(
                    createdAuthServerId, createdPolicyId, secondRuleId);

                await _rulesApi.DeleteAuthorizationServerPolicyRuleAsync(
                    createdAuthServerId, createdPolicyId, secondRuleId);

                // Verify deletion by trying to get the rule (should throw 404)
                var deleteException = await Assert.ThrowsAsync<ApiException>(
                    () => _rulesApi.GetAuthorizationServerPolicyRuleAsync(
                        createdAuthServerId, createdPolicyId, secondRuleId));
                deleteException.ErrorCode.Should().Be(404,
                    "Getting deleted rule should return 404");

                secondRuleId = null; // Mark as deleted to avoid cleanup attempt

                // =============================================
                // Test 14: DeleteAuthorizationServerPolicyRuleWithHttpInfo
                // =============================================
                // Deactivate first rule before deleting
                await _rulesApi.DeactivateAuthorizationServerPolicyRuleAsync(
                    createdAuthServerId, createdPolicyId, createdRuleId);

                var deleteWithHttpInfo = await _rulesApi.DeleteAuthorizationServerPolicyRuleWithHttpInfoAsync(
                    createdAuthServerId, createdPolicyId, createdRuleId);
                deleteWithHttpInfo.Should().NotBeNull();

                // Verify deletion
                var verifyDeleteException = await Assert.ThrowsAsync<ApiException>(
                    () => _rulesApi.GetAuthorizationServerPolicyRuleAsync(
                        createdAuthServerId, createdPolicyId, createdRuleId));
                verifyDeleteException.ErrorCode.Should().Be(404);

                createdRuleId = null; // Mark as deleted
            }
            finally
            {
                // Cleanup in reverse order: rules -> policy -> auth server
                if (!string.IsNullOrEmpty(secondRuleId))
                {
                    try
                    {
                        await _rulesApi.DeactivateAuthorizationServerPolicyRuleAsync(
                            createdAuthServerId, createdPolicyId, secondRuleId);
                        await _rulesApi.DeleteAuthorizationServerPolicyRuleAsync(
                            createdAuthServerId, createdPolicyId, secondRuleId);
                    }
                    catch (ApiException) { /* Ignore cleanup errors */ }
                }

                if (!string.IsNullOrEmpty(createdRuleId))
                {
                    try
                    {
                        await _rulesApi.DeactivateAuthorizationServerPolicyRuleAsync(
                            createdAuthServerId, createdPolicyId, createdRuleId);
                        await _rulesApi.DeleteAuthorizationServerPolicyRuleAsync(
                            createdAuthServerId, createdPolicyId, createdRuleId);
                    }
                    catch (ApiException) { /* Ignore cleanup errors */ }
                }

                if (!string.IsNullOrEmpty(createdPolicyId))
                {
                    try
                    {
                        await _policiesApi.DeactivateAuthorizationServerPolicyAsync(
                            createdAuthServerId, createdPolicyId);
                        await _policiesApi.DeleteAuthorizationServerPolicyAsync(
                            createdAuthServerId, createdPolicyId);
                    }
                    catch (ApiException) { /* Ignore cleanup errors */ }
                }

                if (!string.IsNullOrEmpty(createdAuthServerId))
                {
                    try
                    {
                        await _authServerApi.DeactivateAuthorizationServerAsync(createdAuthServerId);
                        await _authServerApi.DeleteAuthorizationServerAsync(createdAuthServerId);
                    }
                    catch (ApiException) { /* Ignore cleanup errors */ }
                }
            }
        }

        /// <summary>
        /// Tests error handling when accessing non-existent resources.
        /// </summary>
        [Fact]
        public async Task GivenAuthorizationServerRulesApi_WhenAccessingNonExistentRule_ThenReturns404()
        {
            string createdAuthServerId = null;
            string createdPolicyId = null;
            var testPrefix = $"dotnet-sdk-test-{Guid.NewGuid():N}".Substring(0, 30);

            try
            {
                // Setup: Create an Authorization Server and Policy
                var newAuthServer = new AuthorizationServer
                {
                    Name = $"{testPrefix}-authserver",
                    Description = "Test for 404 error handling",
                    Audiences = new List<string> { $"https://api.{testPrefix}.example.com" }
                };

                var createdAuthServer = await _authServerApi.CreateAuthorizationServerAsync(newAuthServer);
                createdAuthServerId = createdAuthServer.Id;

                var newPolicy = new AuthorizationServerPolicy
                {
                    Type = AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY,
                    Name = $"{testPrefix}-policy",
                    Description = "Test policy",
                    Priority = 1,
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

                // Try to get a non-existent rule
                var nonExistentRuleId = "rul_nonexistent_123456789";
                var exception = await Assert.ThrowsAsync<ApiException>(
                    () => _rulesApi.GetAuthorizationServerPolicyRuleAsync(
                        createdAuthServerId, createdPolicyId, nonExistentRuleId));

                exception.ErrorCode.Should().Be(404,
                    "Should return 404 for non-existent rule");
            }
            finally
            {
                // Cleanup
                if (!string.IsNullOrEmpty(createdPolicyId))
                {
                    try
                    {
                        await _policiesApi.DeactivateAuthorizationServerPolicyAsync(
                            createdAuthServerId, createdPolicyId);
                        await _policiesApi.DeleteAuthorizationServerPolicyAsync(
                            createdAuthServerId, createdPolicyId);
                    }
                    catch (ApiException) { /* Ignore cleanup errors */ }
                }

                if (!string.IsNullOrEmpty(createdAuthServerId))
                {
                    try
                    {
                        await _authServerApi.DeactivateAuthorizationServerAsync(createdAuthServerId);
                        await _authServerApi.DeleteAuthorizationServerAsync(createdAuthServerId);
                    }
                    catch (ApiException) { /* Ignore cleanup errors */ }
                }
            }
        }

        /// <summary>
        /// Tests the rule lifecycle operations: activate and deactivate cycles with proper status verification.
        /// </summary>
        [Fact]
        public async Task GivenAuthorizationServerRulesApi_WhenPerformingLifecycleOperations_ThenStatusChangesCorrectly()
        {
            string createdAuthServerId = null;
            string createdPolicyId = null;
            string createdRuleId = null;
            var testPrefix = $"dotnet-sdk-test-{Guid.NewGuid():N}".Substring(0, 30);

            try
            {
                // Setup: Create an Authorization Server
                var newAuthServer = new AuthorizationServer
                {
                    Name = $"{testPrefix}-authserver",
                    Description = "Test for rule lifecycle operations",
                    Audiences = new List<string> { $"https://api.{testPrefix}.example.com" }
                };

                var createdAuthServer = await _authServerApi.CreateAuthorizationServerAsync(newAuthServer);
                createdAuthServerId = createdAuthServer.Id;

                // Setup: Create a Policy
                var newPolicy = new AuthorizationServerPolicy
                {
                    Type = AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY,
                    Name = $"{testPrefix}-policy",
                    Description = "Test policy for lifecycle",
                    Priority = 1,
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

                // Create an active rule
                var newRule = new AuthorizationServerPolicyRuleRequest
                {
                    Type = AuthorizationServerPolicyRuleRequest.TypeEnum.RESOURCEACCESS,
                    Name = $"{testPrefix}-lifecycle-rule",
                    Priority = 1,
                    Conditions = new AuthorizationServerPolicyRuleConditions
                    {
                        People = new AuthorizationServerPolicyPeopleCondition
                        {
                            Groups = new AuthorizationServerPolicyRuleGroupCondition
                            {
                                Include = new List<string> { "EVERYONE" }
                            }
                        },
                        GrantTypes = new GrantTypePolicyRuleCondition
                        {
                            Include = new List<string> { "authorization_code" }
                        },
                        Scopes = new OAuth2ScopesMediationPolicyRuleCondition
                        {
                            Include = new List<string> { "*" }
                        }
                    },
                    Actions = new AuthorizationServerPolicyRuleActions
                    {
                        Token = new TokenAuthorizationServerPolicyRuleAction
                        {
                            AccessTokenLifetimeMinutes = 60,
                            RefreshTokenLifetimeMinutes = 0,
                            RefreshTokenWindowMinutes = 10080
                        }
                    }
                };

                var createdRule = await _rulesApi.CreateAuthorizationServerPolicyRuleAsync(
                    createdAuthServerId, createdPolicyId, newRule);
                createdRuleId = createdRule.Id;

                // Verify the rule is active
                createdRule.Status.Should().Be(AuthorizationServerPolicyRule.StatusEnum.ACTIVE,
                    "Newly created rule should be ACTIVE");

                // Deactivate the rule
                await _rulesApi.DeactivateAuthorizationServerPolicyRuleAsync(
                    createdAuthServerId, createdPolicyId, createdRuleId);

                // Verify the rule is now inactive
                var deactivatedRule = await _rulesApi.GetAuthorizationServerPolicyRuleAsync(
                    createdAuthServerId, createdPolicyId, createdRuleId);
                deactivatedRule.Status.Should().Be(AuthorizationServerPolicyRule.StatusEnum.INACTIVE,
                    "Rule should be INACTIVE after deactivation");

                // Activate the rule
                await _rulesApi.ActivateAuthorizationServerPolicyRuleAsync(
                    createdAuthServerId, createdPolicyId, createdRuleId);

                // Verify the rule is active again
                var activatedRule = await _rulesApi.GetAuthorizationServerPolicyRuleAsync(
                    createdAuthServerId, createdPolicyId, createdRuleId);
                activatedRule.Status.Should().Be(AuthorizationServerPolicyRule.StatusEnum.ACTIVE,
                    "Rule should be ACTIVE after activation");

                // Deactivate again and delete
                await _rulesApi.DeactivateAuthorizationServerPolicyRuleAsync(
                    createdAuthServerId, createdPolicyId, createdRuleId);
                await _rulesApi.DeleteAuthorizationServerPolicyRuleAsync(
                    createdAuthServerId, createdPolicyId, createdRuleId);

                // Verify the rule is deleted
                var deleteException = await Assert.ThrowsAsync<ApiException>(
                    () => _rulesApi.GetAuthorizationServerPolicyRuleAsync(
                        createdAuthServerId, createdPolicyId, createdRuleId));
                deleteException.ErrorCode.Should().Be(404);

                createdRuleId = null; // Mark as deleted
            }
            finally
            {
                // Cleanup
                if (!string.IsNullOrEmpty(createdRuleId))
                {
                    try
                    {
                        await _rulesApi.DeactivateAuthorizationServerPolicyRuleAsync(
                            createdAuthServerId, createdPolicyId, createdRuleId);
                        await _rulesApi.DeleteAuthorizationServerPolicyRuleAsync(
                            createdAuthServerId, createdPolicyId, createdRuleId);
                    }
                    catch (ApiException) { /* Ignore cleanup errors */ }
                }

                if (!string.IsNullOrEmpty(createdPolicyId))
                {
                    try
                    {
                        await _policiesApi.DeactivateAuthorizationServerPolicyAsync(
                            createdAuthServerId, createdPolicyId);
                        await _policiesApi.DeleteAuthorizationServerPolicyAsync(
                            createdAuthServerId, createdPolicyId);
                    }
                    catch (ApiException) { /* Ignore cleanup errors */ }
                }

                if (!string.IsNullOrEmpty(createdAuthServerId))
                {
                    try
                    {
                        await _authServerApi.DeactivateAuthorizationServerAsync(createdAuthServerId);
                        await _authServerApi.DeleteAuthorizationServerAsync(createdAuthServerId);
                    }
                    catch (ApiException) { /* Ignore cleanup errors */ }
                }
            }
        }
    }
}
