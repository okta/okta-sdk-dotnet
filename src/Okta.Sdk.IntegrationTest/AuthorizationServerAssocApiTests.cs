// <copyright file="AuthorizationServerAssocApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Model;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for AuthorizationServerAssocApi.
    /// Tests all 3 endpoints:
    /// 1. POST /api/v1/authorizationServers/{authServerId}/associatedServers - CreateAssociatedServers
    /// 2. GET /api/v1/authorizationServers/{authServerId}/associatedServers - ListAssociatedServersByTrustedType
    /// 3. DELETE /api/v1/authorizationServers/{authServerId}/associatedServers/{associatedServerId} - DeleteAssociatedServerAsync
    /// </summary>
    [Collection(nameof(AuthorizationServerAssocApiTests))]
    public class AuthorizationServerAssocApiTests : IAsyncLifetime
    {
        private AuthorizationServerApi _authServerApi;
        private AuthorizationServerAssocApi _authServerAssocApi;
        private AuthorizationServer _primaryAuthServer;
        private AuthorizationServer _secondaryAuthServer;

        public async Task InitializeAsync()
        {
            _authServerApi = new AuthorizationServerApi();
            _authServerAssocApi = new AuthorizationServerAssocApi();

            // Create two authorization servers for testing associations
            var timestamp = DateTime.UtcNow.Ticks;
            
            _primaryAuthServer = await _authServerApi.CreateAuthorizationServerAsync(new AuthorizationServer
            {
                Name = $"Primary Test Server {timestamp}",
                Description = "Primary server for association tests",
                Audiences = new List<string> { $"https://primary-api-{timestamp}.example.com" }
            });

            _secondaryAuthServer = await _authServerApi.CreateAuthorizationServerAsync(new AuthorizationServer
            {
                Name = $"Secondary Test Server {timestamp}",
                Description = "Secondary server for association tests",
                Audiences = new List<string> { $"https://secondary-api-{timestamp}.example.com" }
            });
        }

        public async Task DisposeAsync()
        {
            // Clean up: deactivate and delete both auth servers
            if (_primaryAuthServer?.Id != null)
            {
                try
                {
                    await _authServerApi.DeactivateAuthorizationServerAsync(_primaryAuthServer.Id);
                    await _authServerApi.DeleteAuthorizationServerAsync(_primaryAuthServer.Id);
                }
                catch { /* Ignore cleanup errors */ }
            }

            if (_secondaryAuthServer?.Id != null)
            {
                try
                {
                    await _authServerApi.DeactivateAuthorizationServerAsync(_secondaryAuthServer.Id);
                    await _authServerApi.DeleteAuthorizationServerAsync(_secondaryAuthServer.Id);
                }
                catch { /* Ignore cleanup errors */ }
            }
        }

        /// <summary>
        /// Tests the complete lifecycle of associated authorization servers:
        /// 1. List associated servers (should be empty initially)
        /// 2. Create an association between two auth servers
        /// 3. List associated servers (should show the association)
        /// 4. Delete the association
        /// 5. List associated servers (should be empty again)
        /// </summary>
        [Fact]
        public async Task AssociatedServers_FullLifecycle_WorksCorrectly()
        {
            // Step 1: List associated servers - should be empty initially
            // Note: The trusted parameter is required by the API
            var initialAssociations = await _authServerAssocApi.ListAssociatedServersByTrustedTypeWithHttpInfoAsync(_primaryAuthServer.Id, trusted: true);
            initialAssociations.Data.Should().BeEmpty("no associations exist initially");

            // Step 2: Create an association - make secondary server trusted by primary
            var associationRequest = new AssociatedServerMediated
            {
                Trusted = new List<string> { _secondaryAuthServer.Id }
            };

            var createdAssociations = await _authServerAssocApi.CreateAssociatedServersWithHttpInfoAsync(_primaryAuthServer.Id, associationRequest);
            createdAssociations.Data.Should().NotBeNullOrEmpty("association should be created");
            createdAssociations.Data.Should().Contain(a => a.Id == _secondaryAuthServer.Id, "secondary server should be in the associations");

            // Step 3: List associated servers - should show the association
            var listedAssociations = await _authServerAssocApi.ListAssociatedServersByTrustedTypeWithHttpInfoAsync(_primaryAuthServer.Id, trusted: true);
            listedAssociations.Data.Should().NotBeNullOrEmpty("associations should exist after creation");
            listedAssociations.Data.Should().Contain(a => a.Id == _secondaryAuthServer.Id);

            // Step 4: Delete the association
            await _authServerAssocApi.DeleteAssociatedServerAsync(_primaryAuthServer.Id, _secondaryAuthServer.Id);

            // Step 5: List associated servers - should be empty after deletion
            var finalAssociations = await _authServerAssocApi.ListAssociatedServersByTrustedTypeWithHttpInfoAsync(_primaryAuthServer.Id, trusted: true);
            finalAssociations.Data.Should().BeEmpty("association should be removed after deletion");
        }

        /// <summary>
        /// Tests listing associated servers with query parameters.
        /// </summary>
        [Fact]
        public async Task ListAssociatedServersByTrustedType_WithQueryParameters_FiltersCorrectly()
        {
            // First create an association
            var associationRequest = new AssociatedServerMediated
            {
                Trusted = new List<string> { _secondaryAuthServer.Id }
            };
            await _authServerAssocApi.CreateAssociatedServersWithHttpInfoAsync(_primaryAuthServer.Id, associationRequest);

            try
            {
                // Test with limit parameter - using WithHttpInfo since trusted is required
                var limitedList = await _authServerAssocApi.ListAssociatedServersByTrustedTypeWithHttpInfoAsync(
                    _primaryAuthServer.Id,
                    trusted: true,
                    limit: 1
                );
                limitedList.Data.Should().NotBeNull();

                // Test searching by name
                var searchList = await _authServerAssocApi.ListAssociatedServersByTrustedTypeWithHttpInfoAsync(
                    _primaryAuthServer.Id,
                    trusted: true,
                    q: "Secondary"
                );
                searchList.Data.Should().NotBeNullOrEmpty("should find server by name search");
            }
            finally
            {
                // Cleanup - delete the association
                await _authServerAssocApi.DeleteAssociatedServerAsync(_primaryAuthServer.Id, _secondaryAuthServer.Id);
            }
        }

        /// <summary>
        /// Tests creating associations with HttpInfo variant to verify response details.
        /// </summary>
        [Fact]
        public async Task CreateAssociatedServersWithHttpInfo_ReturnsCorrectResponse()
        {
            var associationRequest = new AssociatedServerMediated
            {
                Trusted = new List<string> { _secondaryAuthServer.Id }
            };

            try
            {
                var response = await _authServerAssocApi.CreateAssociatedServersWithHttpInfoAsync(_primaryAuthServer.Id, associationRequest);
                
                response.Should().NotBeNull();
                response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
                response.Data.Should().NotBeNullOrEmpty();
                response.Data.Should().Contain(a => a.Id == _secondaryAuthServer.Id);
            }
            finally
            {
                // Cleanup
                try
                {
                    await _authServerAssocApi.DeleteAssociatedServerAsync(_primaryAuthServer.Id, _secondaryAuthServer.Id);
                }
                catch { /* Ignore cleanup errors */ }
            }
        }
    }
}
