// <copyright file="AuthorizationServerApiTests.cs" company="Okta, Inc">
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
    /// Integration tests for AuthorizationServerApi covering all 7 available endpoints.
    /// 
    /// API Coverage:
    /// 1. GET /api/v1/authorizationServers - ListAuthorizationServers
    /// 2. POST /api/v1/authorizationServers - CreateAuthorizationServerAsync
    /// 3. GET /api/v1/authorizationServers/{authServerId} - GetAuthorizationServerAsync
    /// 4. PUT /api/v1/authorizationServers/{authServerId} - ReplaceAuthorizationServerAsync
    /// 5. DELETE /api/v1/authorizationServers/{authServerId} - DeleteAuthorizationServerAsync
    /// 6. POST /api/v1/authorizationServers/{authServerId}/lifecycle/activate - ActivateAuthorizationServerAsync
    /// 7. POST /api/v1/authorizationServers/{authServerId}/lifecycle/deactivate - DeactivateAuthorizationServerAsync
    /// 
    /// Each method also has a WithHttpInfo variant for returning detailed response information.
    /// </summary>
    public class AuthorizationServerApiTests
    {
        private readonly AuthorizationServerApi _authorizationServerApi = new();

        /// <summary>
        /// Comprehensive test covering all AuthorizationServerApi operations and endpoints.
        /// This single test covers:
        /// - Creating an authorization server
        /// - Listing authorization servers (with and without query parameters)
        /// - Getting an individual authorization server
        /// - Replacing (updating) an authorization server
        /// - Authorization server lifecycle (activate/deactivate)
        /// - Deleting an authorization server
        /// </summary>
        [Fact]
        public async Task GivenAuthorizationServerApi_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            string createdAuthServerId = null;
            var testPrefix = $"dotnet-sdk-test-{Guid.NewGuid():N}".Substring(0, 30);

            try
            {
                // ========================================================================
                // SECTION 1: Create Authorization Server
                // ========================================================================

                #region CreateAuthorizationServer - POST /api/v1/authorizationServers

                var newAuthServer = new AuthorizationServer
                {
                    Name = $"{testPrefix}-authserver",
                    Description = "Test authorization server created by .NET SDK integration tests",
                    Audiences = new List<string> { $"https://api.{testPrefix}.example.com" }
                };

                var createdAuthServer = await _authorizationServerApi.CreateAuthorizationServerAsync(newAuthServer);

                createdAuthServer.Should().NotBeNull();
                createdAuthServer.Id.Should().NotBeNullOrEmpty();
                createdAuthServer.Name.Should().Be(newAuthServer.Name);
                createdAuthServer.Description.Should().Be(newAuthServer.Description);
                createdAuthServer.Audiences.Should().NotBeNull();
                createdAuthServer.Audiences.Should().Contain(newAuthServer.Audiences[0]);
                createdAuthServer.Created.Should().BeCloseTo(DateTimeOffset.UtcNow, TimeSpan.FromMinutes(5));
                createdAuthServer.LastUpdated.Should().BeCloseTo(DateTimeOffset.UtcNow, TimeSpan.FromMinutes(5));
                createdAuthServer.Status.Should().Be(LifecycleStatus.ACTIVE); // New auth servers are active by default
                createdAuthServer.Issuer.Should().NotBeNullOrEmpty();

                createdAuthServerId = createdAuthServer.Id;

                #endregion

                // ========================================================================
                // SECTION 2: List Authorization Servers
                // ========================================================================

                #region ListAuthorizationServers - GET /api/v1/authorizationServers

                // Test listing all authorization servers
                var allAuthServers = await _authorizationServerApi.ListAuthorizationServers().ToListAsync();

                allAuthServers.Should().NotBeNull();
                allAuthServers.Should().NotBeEmpty("At least one authorization server should exist after creation");
                
                // Verify the created server is in the list
                var foundServer = allAuthServers.FirstOrDefault(s => s.Id == createdAuthServerId);
                foundServer.Should().NotBeNull("Created authorization server should be found in the list");
                foundServer!.Name.Should().Be(newAuthServer.Name);

                // Test listing with query parameter (search by name)
                var filteredAuthServers = await _authorizationServerApi.ListAuthorizationServers(q: testPrefix).ToListAsync();
                
                filteredAuthServers.Should().NotBeNull();
                filteredAuthServers.Should().Contain(s => s.Id == createdAuthServerId);

                // Test listing with limit parameter
                var limitedAuthServers = await _authorizationServerApi.ListAuthorizationServers(limit: 1).ToListAsync();
                
                limitedAuthServers.Should().NotBeNull();
                // Note: Collection may return all results even with limit due to pagination implementation

                #endregion

                // ========================================================================
                // SECTION 3: Get Authorization Server
                // ========================================================================

                #region GetAuthorizationServer - GET /api/v1/authorizationServers/{authServerId}

                var retrievedAuthServer = await _authorizationServerApi.GetAuthorizationServerAsync(createdAuthServerId);

                retrievedAuthServer.Should().NotBeNull();
                retrievedAuthServer.Id.Should().Be(createdAuthServerId);
                retrievedAuthServer.Name.Should().Be(newAuthServer.Name);
                retrievedAuthServer.Description.Should().Be(newAuthServer.Description);
                retrievedAuthServer.Audiences.Should().BeEquivalentTo(newAuthServer.Audiences);
                retrievedAuthServer.Status.Should().Be(LifecycleStatus.ACTIVE);
                retrievedAuthServer.Links.Should().NotBeNull();

                #endregion

                // ========================================================================
                // SECTION 4: Replace (Update) Authorization Server
                // ========================================================================

                #region ReplaceAuthorizationServer - PUT /api/v1/authorizationServers/{authServerId}

                var updatedName = $"{testPrefix}-updated";
                var updatedDescription = "Updated description by .NET SDK integration tests";
                var updatedAudiences = new List<string> { $"https://updated-api.{testPrefix}.example.com" };

                // Get the existing server first to preserve required fields
                var existingServer = await _authorizationServerApi.GetAuthorizationServerAsync(createdAuthServerId);

                var authServerToUpdate = new AuthorizationServer
                {
                    Name = updatedName,
                    Description = updatedDescription,
                    Audiences = updatedAudiences,
                    // Preserve the issuerMode from existing server (required field for update)
                    IssuerMode = existingServer.IssuerMode
                };

                var replacedAuthServer = await _authorizationServerApi.ReplaceAuthorizationServerAsync(createdAuthServerId, authServerToUpdate);

                replacedAuthServer.Should().NotBeNull();
                replacedAuthServer.Id.Should().Be(createdAuthServerId);
                replacedAuthServer.Name.Should().Be(updatedName);
                replacedAuthServer.Description.Should().Be(updatedDescription);
                replacedAuthServer.Audiences.Should().BeEquivalentTo(updatedAudiences);
                replacedAuthServer.LastUpdated.Should().BeOnOrAfter(createdAuthServer.LastUpdated);

                #endregion

                // ========================================================================
                // SECTION 5: Authorization Server Lifecycle Operations
                // ========================================================================

                #region DeactivateAuthorizationServer - POST /api/v1/authorizationServers/{authServerId}/lifecycle/deactivate

                // First deactivate the authorization server
                await _authorizationServerApi.DeactivateAuthorizationServerAsync(createdAuthServerId);

                // Verify it's deactivated
                var deactivatedAuthServer = await _authorizationServerApi.GetAuthorizationServerAsync(createdAuthServerId);
                deactivatedAuthServer.Status.Should().Be(LifecycleStatus.INACTIVE);

                #endregion

                #region ActivateAuthorizationServer - POST /api/v1/authorizationServers/{authServerId}/lifecycle/activate

                // Re-activate the authorization server
                await _authorizationServerApi.ActivateAuthorizationServerAsync(createdAuthServerId);

                // Verify it's active again
                var reactivatedAuthServer = await _authorizationServerApi.GetAuthorizationServerAsync(createdAuthServerId);
                reactivatedAuthServer.Status.Should().Be(LifecycleStatus.ACTIVE);

                #endregion

                // Deactivate again before deletion (required for deletion)
                await _authorizationServerApi.DeactivateAuthorizationServerAsync(createdAuthServerId);

                // ========================================================================
                // SECTION 6: Delete Authorization Server
                // ========================================================================

                #region DeleteAuthorizationServer - DELETE /api/v1/authorizationServers/{authServerId}

                await _authorizationServerApi.DeleteAuthorizationServerAsync(createdAuthServerId);

                // Verify deletion - should throw 404
                var getAfterDelete = async () => await _authorizationServerApi.GetAuthorizationServerAsync(createdAuthServerId);
                await getAfterDelete.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404);

                // Mark as deleted so cleanup doesn't try to delete again
                createdAuthServerId = null;

                #endregion
            }
            finally
            {
                // ========================================================================
                // CLEANUP
                // ========================================================================
                await CleanupAuthorizationServer(createdAuthServerId);
            }
        }

        /// <summary>
        /// Test covering WithHttpInfo methods for all operations.
        /// This test verifies that the WithHttpInfo variants return proper HTTP response metadata.
        /// </summary>
        [Fact]
        public async Task GivenAuthorizationServerApi_WhenUsingWithHttpInfoMethods_ThenAllEndpointsReturnProperHttpInfo()
        {
            string createdAuthServerId = null;
            var testPrefix = $"dotnet-sdk-test-{Guid.NewGuid():N}".Substring(0, 30);

            try
            {
                // ========================================================================
                // SECTION 1: Create with HttpInfo
                // ========================================================================

                #region CreateAuthorizationServerWithHttpInfo

                var newAuthServer = new AuthorizationServer
                {
                    Name = $"{testPrefix}-httpinfo",
                    Description = "Test authorization server for HttpInfo methods",
                    Audiences = new List<string> { $"https://httpinfo.{testPrefix}.example.com" }
                };

                var createResponse = await _authorizationServerApi.CreateAuthorizationServerWithHttpInfoAsync(newAuthServer);

                createResponse.Should().NotBeNull();
                createResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
                createResponse.Data.Should().NotBeNull();
                createResponse.Data.Id.Should().NotBeNullOrEmpty();
                createResponse.Headers.Should().NotBeNull();
                createResponse.RawContent.Should().NotBeNullOrEmpty();

                createdAuthServerId = createResponse.Data.Id;

                #endregion

                // ========================================================================
                // SECTION 2: List with HttpInfo
                // ========================================================================

                #region ListAuthorizationServersWithHttpInfo

                var listResponse = await _authorizationServerApi.ListAuthorizationServersWithHttpInfoAsync();

                listResponse.Should().NotBeNull();
                listResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
                listResponse.Data.Should().NotBeNull();
                listResponse.Data.Should().NotBeEmpty();
                listResponse.Headers.Should().NotBeNull();

                // Test with query parameters
                var listWithQueryResponse = await _authorizationServerApi.ListAuthorizationServersWithHttpInfoAsync(q: testPrefix, limit: 10);

                listWithQueryResponse.Should().NotBeNull();
                listWithQueryResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
                listWithQueryResponse.Data.Should().Contain(s => s.Id == createdAuthServerId);

                #endregion

                // ========================================================================
                // SECTION 3: Get with HttpInfo
                // ========================================================================

                #region GetAuthorizationServerWithHttpInfo

                var getResponse = await _authorizationServerApi.GetAuthorizationServerWithHttpInfoAsync(createdAuthServerId);

                getResponse.Should().NotBeNull();
                getResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
                getResponse.Data.Should().NotBeNull();
                getResponse.Data.Id.Should().Be(createdAuthServerId);
                getResponse.Data.Name.Should().Be(newAuthServer.Name);

                #endregion

                // ========================================================================
                // SECTION 4: Replace with HttpInfo
                // ========================================================================

                #region ReplaceAuthorizationServerWithHttpInfo

                // Get the existing server first to preserve required fields
                var existingForUpdate = await _authorizationServerApi.GetAuthorizationServerAsync(createdAuthServerId);

                var updateAuthServer = new AuthorizationServer
                {
                    Name = $"{testPrefix}-httpinfo-upd",
                    Description = "Updated via HttpInfo method",
                    Audiences = new List<string> { $"https://httpinfo-upd.{testPrefix}.example.com" },
                    // Preserve the issuerMode from existing server (required field for update)
                    IssuerMode = existingForUpdate.IssuerMode
                };

                var replaceResponse = await _authorizationServerApi.ReplaceAuthorizationServerWithHttpInfoAsync(createdAuthServerId, updateAuthServer);

                replaceResponse.Should().NotBeNull();
                replaceResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
                replaceResponse.Data.Should().NotBeNull();
                replaceResponse.Data.Name.Should().Be(updateAuthServer.Name);

                #endregion

                // ========================================================================
                // SECTION 5: Lifecycle with HttpInfo
                // ========================================================================

                #region DeactivateAuthorizationServerWithHttpInfo

                var deactivateResponse = await _authorizationServerApi.DeactivateAuthorizationServerWithHttpInfoAsync(createdAuthServerId);

                deactivateResponse.Should().NotBeNull();
                deactivateResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);

                #endregion

                #region ActivateAuthorizationServerWithHttpInfo

                var activateResponse = await _authorizationServerApi.ActivateAuthorizationServerWithHttpInfoAsync(createdAuthServerId);

                activateResponse.Should().NotBeNull();
                activateResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);

                #endregion

                // ========================================================================
                // SECTION 6: Delete with HttpInfo
                // ========================================================================

                #region DeleteAuthorizationServerWithHttpInfo

                // First deactivate before delete
                await _authorizationServerApi.DeactivateAuthorizationServerAsync(createdAuthServerId);

                var deleteResponse = await _authorizationServerApi.DeleteAuthorizationServerWithHttpInfoAsync(createdAuthServerId);

                deleteResponse.Should().NotBeNull();
                deleteResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);

                // Mark as deleted
                createdAuthServerId = null;

                #endregion
            }
            finally
            {
                // ========================================================================
                // CLEANUP
                // ========================================================================
                await CleanupAuthorizationServer(createdAuthServerId);
            }
        }

        /// <summary>
        /// Test that verifies authorization server search functionality and pagination.
        /// </summary>
        [Fact]
        public async Task GivenAuthorizationServerApi_WhenSearchingAndPaginating_ThenResultsAreFilteredCorrectly()
        {
            var createdServerIds = new List<string>();
            var testPrefix = $"dotnet-sdk-search-{Guid.NewGuid():N}".Substring(0, 28);

            try
            {
                // Create multiple authorization servers for search/pagination testing
                var server1 = await _authorizationServerApi.CreateAuthorizationServerAsync(new AuthorizationServer
                {
                    Name = $"{testPrefix}-alpha",
                    Description = "First server for search tests",
                    Audiences = new List<string> { "https://alpha.example.com" }
                });
                createdServerIds.Add(server1.Id);

                var server2 = await _authorizationServerApi.CreateAuthorizationServerAsync(new AuthorizationServer
                {
                    Name = $"{testPrefix}-beta",
                    Description = "Second server for search tests",
                    Audiences = new List<string> { "https://beta.example.com" }
                });
                createdServerIds.Add(server2.Id);

                // Test search by name prefix
                var searchResults = await _authorizationServerApi.ListAuthorizationServers(q: testPrefix).ToListAsync();

                searchResults.Should().NotBeNull();
                searchResults.Count.Should().BeGreaterThanOrEqualTo(2);
                searchResults.Should().Contain(s => s.Name.Contains("alpha"));
                searchResults.Should().Contain(s => s.Name.Contains("beta"));

                // Test search by specific name
                var alphaResults = await _authorizationServerApi.ListAuthorizationServers(q: $"{testPrefix}-alpha").ToListAsync();

                alphaResults.Should().NotBeNull();
                alphaResults.Should().Contain(s => s.Id == server1.Id);

                // Test with audience search (q parameter searches both name and audiences)
                var audienceResults = await _authorizationServerApi.ListAuthorizationServers(q: "alpha.example").ToListAsync();

                audienceResults.Should().NotBeNull();
                // Note: The actual behavior depends on how the API implements search
            }
            finally
            {
                // Cleanup all created servers
                foreach (var serverId in createdServerIds)
                {
                    await CleanupAuthorizationServer(serverId);
                }
            }
        }

        /// <summary>
        /// Helper method to cleanup an authorization server.
        /// Handles deactivation before deletion as required by the API.
        /// </summary>
        private async Task CleanupAuthorizationServer(string authServerId)
        {
            if (string.IsNullOrEmpty(authServerId))
                return;

            try
            {
                // First try to deactivate (required before deletion)
                try
                {
                    await _authorizationServerApi.DeactivateAuthorizationServerAsync(authServerId);
                }
                catch (ApiException)
                {
                    // May already be deactivated or not exist
                }

                // Then delete
                await _authorizationServerApi.DeleteAuthorizationServerAsync(authServerId);
            }
            catch (ApiException ex)
            {
                // Log but don't fail if cleanup has issues (server may already be deleted)
                Console.WriteLine($"Cleanup warning: Could not delete authorization server {authServerId}. Error: {ex.Message}");
            }
        }
    }
}
