// <copyright file="AuthorizationServerScopesApiTests.cs" company="Okta, Inc">
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
    /// Integration tests for AuthorizationServerScopesApi.
    /// 
    /// These tests verify the complete lifecycle of Authorization Server OAuth2 Scopes
    /// against a real Okta environment, covering all 5 API endpoints:
    /// 1. ListOAuth2Scopes
    /// 2. CreateOAuth2ScopeAsync
    /// 3. GetOAuth2ScopeAsync
    /// 4. ReplaceOAuth2ScopeAsync
    /// 5. DeleteOAuth2ScopeAsync
    /// </summary>
    public class AuthorizationServerScopesApiTests
    {
        private readonly AuthorizationServerScopesApi _scopesApi;
        private readonly AuthorizationServerApi _authServerApi;

        public AuthorizationServerScopesApiTests()
        {
            _scopesApi = new AuthorizationServerScopesApi();
            _authServerApi = new AuthorizationServerApi();
        }

        /// <summary>
        /// Helper method to create a test authorization server for scope operations.
        /// </summary>
        private async Task<AuthorizationServer> CreateTestAuthorizationServerAsync(string testName)
        {
            var uniqueId = Guid.NewGuid().ToString().Substring(0, 8);
            var authServerRequest = new AuthorizationServer
            {
                Name = $"Test-Scopes-{testName}-{uniqueId}",
                Description = $"Test Auth Server for Scopes API Integration Tests - {testName}",
                Audiences = [$"api://scopes-test-{uniqueId}"]
            };

            return await _authServerApi.CreateAuthorizationServerAsync(authServerRequest);
        }

        /// <summary>
        /// Helper method to clean up a test authorization server.
        /// </summary>
        private async Task CleanupAuthorizationServerAsync(string authServerId)
        {
            try
            {
                // Deactivate first
                await _authServerApi.DeactivateAuthorizationServerAsync(authServerId);
                // Then delete
                await _authServerApi.DeleteAuthorizationServerAsync(authServerId);
            }
            catch (ApiException)
            {
                // Ignore cleanup errors - server may already be deleted
            }
        }

        #region Full Lifecycle Test

        /// <summary>
        /// Tests the complete lifecycle of an OAuth2 Scope:
        /// Create -> Get -> Replace -> Delete
        /// </summary>
        [Fact]
        public async Task OAuth2Scope_FullLifecycle_WorksCorrectly()
        {
            AuthorizationServer authServer = null;
            OAuth2Scope createdScope = null;

            try
            {
                // Setup - Create an authorization server
                authServer = await CreateTestAuthorizationServerAsync("Lifecycle");
                authServer.Should().NotBeNull("Authorization server should be created successfully");
                authServer.Id.Should().NotBeNullOrEmpty();

                // ========================================
                // Step 1: Create a custom OAuth2 scope
                // ========================================
                var uniqueId = Guid.NewGuid().ToString().Substring(0, 8);
                var scopeRequest = new OAuth2Scope
                {
                    Name = $"api:read:{uniqueId}",
                    Description = "Read access to API",
                    DisplayName = "API Read Access",
                    Consent = OAuth2ScopeConsentType.REQUIRED,
                    Default = false,
                    Optional = false,
                    MetadataPublish = OAuth2ScopeMetadataPublish.NOCLIENTS
                };

                createdScope = await _scopesApi.CreateOAuth2ScopeAsync(authServer.Id, scopeRequest);

                // Verify created scope
                createdScope.Should().NotBeNull("Scope should be created successfully");
                createdScope.Id.Should().NotBeNullOrEmpty("Scope should have an ID");
                createdScope.Name.Should().Be(scopeRequest.Name, "Scope name should match request");
                createdScope.Description.Should().Be(scopeRequest.Description, "Scope description should match request");
                createdScope.DisplayName.Should().Be(scopeRequest.DisplayName, "Scope display name should match request");
                createdScope.Consent.Should().Be(OAuth2ScopeConsentType.REQUIRED, "Consent type should be REQUIRED");
                createdScope.Default.Should().BeFalse("Default should be false");
                createdScope.Optional.Should().BeFalse("Optional should be false");
                createdScope.System.Should().BeFalse("System should be false for custom scopes");
                createdScope.MetadataPublish.Should().Be(OAuth2ScopeMetadataPublish.NOCLIENTS, "MetadataPublish should be NO_CLIENTS");

                // ========================================
                // Step 2: Get the scope by ID
                // ========================================
                var retrievedScope = await _scopesApi.GetOAuth2ScopeAsync(authServer.Id, createdScope.Id);

                // Verify retrieved scope matches created scope
                retrievedScope.Should().NotBeNull("Retrieved scope should not be null");
                retrievedScope.Id.Should().Be(createdScope.Id, "Retrieved scope ID should match");
                retrievedScope.Name.Should().Be(createdScope.Name, "Retrieved scope name should match");
                retrievedScope.Description.Should().Be(createdScope.Description, "Retrieved scope description should match");
                retrievedScope.DisplayName.Should().Be(createdScope.DisplayName, "Retrieved scope display name should match");
                retrievedScope.Consent.Should().Be(createdScope.Consent, "Retrieved scope consent should match");
                retrievedScope.Default.Should().Be(createdScope.Default, "Retrieved scope default should match");
                retrievedScope.Optional.Should().Be(createdScope.Optional, "Retrieved scope optional should match");
                retrievedScope.MetadataPublish.Should().Be(createdScope.MetadataPublish, "Retrieved scope metadataPublish should match");

                // ========================================
                // Step 3: Replace (update) the scope
                // ========================================
                var updateRequest = new OAuth2Scope
                {
                    Name = $"api:write:{uniqueId}",
                    Description = "Write access to API - Updated",
                    DisplayName = "API Write Access",
                    Consent = OAuth2ScopeConsentType.IMPLICIT,
                    Default = true,
                    Optional = false, // Must be false when consent is IMPLICIT
                    MetadataPublish = OAuth2ScopeMetadataPublish.ALLCLIENTS
                };

                var updatedScope = await _scopesApi.ReplaceOAuth2ScopeAsync(authServer.Id, createdScope.Id, updateRequest);

                // Verify updated scope
                updatedScope.Should().NotBeNull("Updated scope should not be null");
                updatedScope.Id.Should().Be(createdScope.Id, "Scope ID should remain the same after update");
                updatedScope.Name.Should().Be(updateRequest.Name, "Updated scope name should match");
                updatedScope.Description.Should().Be(updateRequest.Description, "Updated scope description should match");
                updatedScope.DisplayName.Should().Be(updateRequest.DisplayName, "Updated scope display name should match");
                updatedScope.Consent.Should().Be(OAuth2ScopeConsentType.IMPLICIT, "Updated consent should be IMPLICIT");
                updatedScope.Default.Should().BeTrue("Updated default should be true");
                updatedScope.Optional.Should().BeFalse("Updated optional should be false when consent is IMPLICIT");
                updatedScope.MetadataPublish.Should().Be(OAuth2ScopeMetadataPublish.ALLCLIENTS, "Updated metadataPublish should be ALL_CLIENTS");

                // ========================================
                // Step 4: Verify update by getting again
                // ========================================
                var verifyUpdatedScope = await _scopesApi.GetOAuth2ScopeAsync(authServer.Id, createdScope.Id);
                verifyUpdatedScope.Name.Should().Be(updateRequest.Name, "Verified scope name should be updated");
                verifyUpdatedScope.Description.Should().Be(updateRequest.Description, "Verified scope description should be updated");
                verifyUpdatedScope.Consent.Should().Be(OAuth2ScopeConsentType.IMPLICIT, "Verified consent should be updated");
                verifyUpdatedScope.MetadataPublish.Should().Be(OAuth2ScopeMetadataPublish.ALLCLIENTS, "Verified metadataPublish should be updated");

                // ========================================
                // Step 5: Delete the scope
                // ========================================
                await _scopesApi.DeleteOAuth2ScopeAsync(authServer.Id, createdScope.Id);
                createdScope = null; // Mark as deleted for cleanup

                // ========================================
                // Step 6: Verify deletion
                // ========================================
                var getDeletedAction = async () => await _scopesApi.GetOAuth2ScopeAsync(authServer.Id, updatedScope.Id);
                await getDeletedAction.Should().ThrowAsync<ApiException>(
                    "Getting a deleted scope should throw an exception");
            }
            finally
            {
                // Cleanup
                if (createdScope != null)
                {
                    try
                    {
                        await _scopesApi.DeleteOAuth2ScopeAsync(authServer.Id, createdScope.Id);
                    }
                    catch (ApiException) { }
                }

                if (authServer != null)
                {
                    await CleanupAuthorizationServerAsync(authServer.Id);
                }
            }
        }

        #endregion

        #region List Scopes Tests

        /// <summary>
        /// Tests listing OAuth2 scopes using enumeration and WithHttpInfo.
        /// </summary>
        [Fact]
        public async Task ListOAuth2Scopes_ReturnsAllScopes()
        {
            AuthorizationServer authServer = null;
            var createdScopeIds = new List<string>();

            try
            {
                // Setup - Create an authorization server
                authServer = await CreateTestAuthorizationServerAsync("List");
                authServer.Should().NotBeNull();

                // Create multiple scopes with a searchable prefix
                var uniqueId = Guid.NewGuid().ToString().Substring(0, 8);
                var searchPrefix = $"testscope{uniqueId}";
                var scopeNames = new[] { "read", "write", "delete" };

                foreach (var scopeName in scopeNames)
                {
                    var scopeRequest = new OAuth2Scope
                    {
                        Name = $"{searchPrefix}:{scopeName}",
                        Description = $"{scopeName} access",
                        DisplayName = $"API {scopeName} Access",
                        Consent = OAuth2ScopeConsentType.IMPLICIT
                    };

                    var createdScope = await _scopesApi.CreateOAuth2ScopeAsync(authServer.Id, scopeRequest);
                    createdScopeIds.Add(createdScope.Id);
                }

                // ========================================
                // Test 1: List using collection enumeration
                // ========================================
                var scopesList = new List<OAuth2Scope>();
                await foreach (var scope in _scopesApi.ListOAuth2Scopes(authServer.Id))
                {
                    scopesList.Add(scope);
                }

                // Verify we got all our created scopes (plus any default scopes)
                scopesList.Should().HaveCountGreaterThanOrEqualTo(3,
                    "Should have at least the three scopes we created");

                foreach (var scopeId in createdScopeIds)
                {
                    scopesList.Should().Contain(s => s.Id == scopeId,
                        $"Scope list should contain scope with ID {scopeId}");
                }

                // ========================================
                // Test 2: List with query parameter (q) - with retry for indexing
                // ========================================
                var filteredList = new List<OAuth2Scope>();
                for (int i = 0; i < 5; i++)
                {
                    await Task.Delay(2000);
                    filteredList.Clear();
                    await foreach (var scope in _scopesApi.ListOAuth2Scopes(authServer.Id, q: searchPrefix))
                    {
                        filteredList.Add(scope);
                    }
                    if (filteredList.Any(s => s.Name.StartsWith(searchPrefix)))
                        break;
                }

                // Should find our scopes matching the search prefix
                filteredList.Should().Contain(s => s.Name.StartsWith(searchPrefix),
                    "Filtered list should contain scopes with our search prefix");

                // ========================================
                // Test 3: List with WithHttpInfo
                // ========================================
                var listWithHttpInfo = await _scopesApi.ListOAuth2ScopesWithHttpInfoAsync(authServer.Id);

                listWithHttpInfo.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
                listWithHttpInfo.Data.Should().NotBeNull();
                listWithHttpInfo.Data.Should().HaveCountGreaterThanOrEqualTo(3);
            }
            finally
            {
                // Cleanup
                foreach (var scopeId in createdScopeIds)
                {
                    try
                    {
                        await _scopesApi.DeleteOAuth2ScopeAsync(authServer?.Id, scopeId);
                    }
                    catch (ApiException) { }
                }

                if (authServer != null)
                {
                    await CleanupAuthorizationServerAsync(authServer.Id);
                }
            }
        }

        #endregion

        #region Scope Configuration Tests

        /// <summary>
        /// Tests creating scopes with different consent types.
        /// </summary>
        [Fact]
        public async Task CreateOAuth2Scope_WithDifferentConsentTypes_WorksCorrectly()
        {
            AuthorizationServer authServer = null;
            var createdScopeIds = new List<string>();

            try
            {
                // Setup
                authServer = await CreateTestAuthorizationServerAsync("Consent");
                authServer.Should().NotBeNull();

                var uniqueId = Guid.NewGuid().ToString().Substring(0, 8);

                // ========================================
                // Test 1: Create scope with REQUIRED consent
                // ========================================
                var requiredScopeRequest = new OAuth2Scope
                {
                    Name = $"required:scope:{uniqueId}",
                    Description = "Scope with REQUIRED consent",
                    Consent = OAuth2ScopeConsentType.REQUIRED
                };

                var requiredScope = await _scopesApi.CreateOAuth2ScopeAsync(authServer.Id, requiredScopeRequest);
                createdScopeIds.Add(requiredScope.Id);

                requiredScope.Consent.Should().Be(OAuth2ScopeConsentType.REQUIRED);

                // ========================================
                // Test 2: Create scope with IMPLICIT consent
                // ========================================
                var implicitScopeRequest = new OAuth2Scope
                {
                    Name = $"implicit:scope:{uniqueId}",
                    Description = "Scope with IMPLICIT consent",
                    Consent = OAuth2ScopeConsentType.IMPLICIT
                };

                var implicitScope = await _scopesApi.CreateOAuth2ScopeAsync(authServer.Id, implicitScopeRequest);
                createdScopeIds.Add(implicitScope.Id);

                implicitScope.Consent.Should().Be(OAuth2ScopeConsentType.IMPLICIT);

                // ========================================
                // Test 3: Create scope with FLEXIBLE consent
                // ========================================
                var flexibleScopeRequest = new OAuth2Scope
                {
                    Name = $"flexible:scope:{uniqueId}",
                    Description = "Scope with FLEXIBLE consent",
                    Consent = OAuth2ScopeConsentType.FLEXIBLE
                };

                var flexibleScope = await _scopesApi.CreateOAuth2ScopeAsync(authServer.Id, flexibleScopeRequest);
                createdScopeIds.Add(flexibleScope.Id);

                flexibleScope.Consent.Should().Be(OAuth2ScopeConsentType.FLEXIBLE);

                // ========================================
                // Verify all scopes via Get
                // ========================================
                var verifyRequired = await _scopesApi.GetOAuth2ScopeAsync(authServer.Id, requiredScope.Id);
                verifyRequired.Consent.Should().Be(OAuth2ScopeConsentType.REQUIRED);

                var verifyImplicit = await _scopesApi.GetOAuth2ScopeAsync(authServer.Id, implicitScope.Id);
                verifyImplicit.Consent.Should().Be(OAuth2ScopeConsentType.IMPLICIT);

                var verifyFlexible = await _scopesApi.GetOAuth2ScopeAsync(authServer.Id, flexibleScope.Id);
                verifyFlexible.Consent.Should().Be(OAuth2ScopeConsentType.FLEXIBLE);
            }
            finally
            {
                // Cleanup
                foreach (var scopeId in createdScopeIds)
                {
                    try
                    {
                        await _scopesApi.DeleteOAuth2ScopeAsync(authServer?.Id, scopeId);
                    }
                    catch (ApiException) { }
                }

                if (authServer != null)
                {
                    await CleanupAuthorizationServerAsync(authServer.Id);
                }
            }
        }

        /// <summary>
        /// Tests creating scopes with different metadataPublish settings.
        /// </summary>
        [Fact]
        public async Task CreateOAuth2Scope_WithDifferentMetadataPublish_WorksCorrectly()
        {
            AuthorizationServer authServer = null;
            var createdScopeIds = new List<string>();

            try
            {
                // Setup
                authServer = await CreateTestAuthorizationServerAsync("Metadata");
                authServer.Should().NotBeNull();

                var uniqueId = Guid.NewGuid().ToString().Substring(0, 8);

                // ========================================
                // Test 1: Create scope with NO_CLIENTS
                // ========================================
                var noClientsScopeRequest = new OAuth2Scope
                {
                    Name = $"no:clients:{uniqueId}",
                    Description = "Scope not published to clients",
                    MetadataPublish = OAuth2ScopeMetadataPublish.NOCLIENTS
                };

                var noClientsScope = await _scopesApi.CreateOAuth2ScopeAsync(authServer.Id, noClientsScopeRequest);
                createdScopeIds.Add(noClientsScope.Id);

                noClientsScope.MetadataPublish.Should().Be(OAuth2ScopeMetadataPublish.NOCLIENTS);

                // ========================================
                // Test 2: Create scope with ALL_CLIENTS
                // ========================================
                var allClientsScopeRequest = new OAuth2Scope
                {
                    Name = $"all:clients:{uniqueId}",
                    Description = "Scope published to all clients",
                    MetadataPublish = OAuth2ScopeMetadataPublish.ALLCLIENTS
                };

                var allClientsScope = await _scopesApi.CreateOAuth2ScopeAsync(authServer.Id, allClientsScopeRequest);
                createdScopeIds.Add(allClientsScope.Id);

                allClientsScope.MetadataPublish.Should().Be(OAuth2ScopeMetadataPublish.ALLCLIENTS);

                // ========================================
                // Verify via Get
                // ========================================
                var verifyNoClients = await _scopesApi.GetOAuth2ScopeAsync(authServer.Id, noClientsScope.Id);
                verifyNoClients.MetadataPublish.Should().Be(OAuth2ScopeMetadataPublish.NOCLIENTS);

                var verifyAllClients = await _scopesApi.GetOAuth2ScopeAsync(authServer.Id, allClientsScope.Id);
                verifyAllClients.MetadataPublish.Should().Be(OAuth2ScopeMetadataPublish.ALLCLIENTS);
            }
            finally
            {
                // Cleanup
                foreach (var scopeId in createdScopeIds)
                {
                    try
                    {
                        await _scopesApi.DeleteOAuth2ScopeAsync(authServer?.Id, scopeId);
                    }
                    catch (ApiException) { }
                }

                if (authServer != null)
                {
                    await CleanupAuthorizationServerAsync(authServer.Id);
                }
            }
        }

        /// <summary>
        /// Tests creating scopes with default and optional flags.
        /// </summary>
        [Fact]
        public async Task CreateOAuth2Scope_WithDefaultAndOptionalFlags_WorksCorrectly()
        {
            AuthorizationServer authServer = null;
            var createdScopeIds = new List<string>();

            try
            {
                // Setup
                authServer = await CreateTestAuthorizationServerAsync("Flags");
                authServer.Should().NotBeNull();

                var uniqueId = Guid.NewGuid().ToString().Substring(0, 8);

                // ========================================
                // Test 1: Create default scope
                // ========================================
                var defaultScopeRequest = new OAuth2Scope
                {
                    Name = $"default:scope:{uniqueId}",
                    Description = "A default scope",
                    Default = true,
                    Optional = false,
                    Consent = OAuth2ScopeConsentType.IMPLICIT
                };

                var defaultScope = await _scopesApi.CreateOAuth2ScopeAsync(authServer.Id, defaultScopeRequest);
                createdScopeIds.Add(defaultScope.Id);

                defaultScope.Default.Should().BeTrue("Default flag should be true");
                defaultScope.Optional.Should().BeFalse("Optional flag should be false");

                // ========================================
                // Test 2: Create optional scope
                // ========================================
                var optionalScopeRequest = new OAuth2Scope
                {
                    Name = $"optional:scope:{uniqueId}",
                    Description = "An optional scope",
                    Default = false,
                    Optional = true,
                    Consent = OAuth2ScopeConsentType.REQUIRED
                };

                var optionalScope = await _scopesApi.CreateOAuth2ScopeAsync(authServer.Id, optionalScopeRequest);
                createdScopeIds.Add(optionalScope.Id);

                optionalScope.Default.Should().BeFalse("Default flag should be false");
                optionalScope.Optional.Should().BeTrue("Optional flag should be true");

                // ========================================
                // Test 3: Create scope with both flags
                // ========================================
                var bothFlagsScopeRequest = new OAuth2Scope
                {
                    Name = $"both:flags:{uniqueId}",
                    Description = "A scope with both default and optional flags",
                    Default = true,
                    Optional = true,
                    Consent = OAuth2ScopeConsentType.FLEXIBLE
                };

                var bothFlagsScope = await _scopesApi.CreateOAuth2ScopeAsync(authServer.Id, bothFlagsScopeRequest);
                createdScopeIds.Add(bothFlagsScope.Id);

                bothFlagsScope.Default.Should().BeTrue("Default flag should be true");
                bothFlagsScope.Optional.Should().BeTrue("Optional flag should be true");

                // ========================================
                // Verify via Get
                // ========================================
                var verifyDefault = await _scopesApi.GetOAuth2ScopeAsync(authServer.Id, defaultScope.Id);
                verifyDefault.Default.Should().BeTrue();
                verifyDefault.Optional.Should().BeFalse();

                var verifyOptional = await _scopesApi.GetOAuth2ScopeAsync(authServer.Id, optionalScope.Id);
                verifyOptional.Default.Should().BeFalse();
                verifyOptional.Optional.Should().BeTrue();

                var verifyBoth = await _scopesApi.GetOAuth2ScopeAsync(authServer.Id, bothFlagsScope.Id);
                verifyBoth.Default.Should().BeTrue();
                verifyBoth.Optional.Should().BeTrue();
            }
            finally
            {
                // Cleanup
                foreach (var scopeId in createdScopeIds)
                {
                    try
                    {
                        await _scopesApi.DeleteOAuth2ScopeAsync(authServer?.Id, scopeId);
                    }
                    catch (ApiException) { }
                }

                if (authServer != null)
                {
                    await CleanupAuthorizationServerAsync(authServer.Id);
                }
            }
        }

        #endregion
    }
}
