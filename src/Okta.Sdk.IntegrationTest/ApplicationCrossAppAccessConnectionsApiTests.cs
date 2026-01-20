// <copyright file="ApplicationCrossAppAccessConnectionsApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for the ApplicationCrossAppAccessConnectionsApi.
    /// 
    /// IMPORTANT: Cross App Access is an Early Access (EA) feature that requires:
    /// 1. Okta Identity Engine
    /// 2. Cross-app access feature enabled in the org (contact Okta support)
    /// 3. Applications configured as Service apps with Client Credentials grant type
    /// 4. Possibly additional org-level or app-level configuration
    /// 
    /// If tests fail with "Invalid client app id" (E0000013), it indicates that either:
    /// - The applications need additional configuration in the Admin Console
    /// - The applications need to be explicitly enabled for cross-app access
    /// - Additional org-level settings may be required
    /// 
    /// These tests validate the SDK's implementation of the API endpoints.
    /// </summary>
    public class ApplicationCrossAppAccessConnectionsApiTests : IDisposable
    {
        private readonly ApplicationCrossAppAccessConnectionsApi _applicationCrossAppAccessConnectionsApi;
        private readonly ApplicationApi _applicationApi;
        private readonly List<string> _appIdsToCleanup = [];

        public ApplicationCrossAppAccessConnectionsApiTests()
        {
            _applicationCrossAppAccessConnectionsApi = new ApplicationCrossAppAccessConnectionsApi();
            _applicationApi = new ApplicationApi();
        }

        public void Dispose()
        {
            // Clean up test applications
            foreach (var appId in _appIdsToCleanup)
            {
                try
                {
                    _applicationApi.DeactivateApplicationAsync(appId).Wait();
                    _applicationApi.DeleteApplicationAsync(appId).Wait();
                }
                catch
                {
                    // Ignore cleanup errors
                }
            }
        }

        private async Task<OpenIdConnectApplication> CreateTestOidcApplication(string label, bool supportsCrossAppAccess = true)
        {
            var guid = Guid.NewGuid();
            
            // For cross-app access, we need to use client_credentials grant type
            // and create service applications (ApplicationType = Service)
            var grantTypes = supportsCrossAppAccess 
                ? new List<GrantType> { GrantType.ClientCredentials }
                : new List<GrantType> { GrantType.AuthorizationCode };
            
            var applicationType = supportsCrossAppAccess
                ? OpenIdConnectApplicationType.Service
                : OpenIdConnectApplicationType.Web;
            
            var app = new OpenIdConnectApplication
            {
                Name = "oidc_client",
                Label = label,
                SignOnMode = "OPENID_CONNECT",
                Credentials = new OAuthApplicationCredentials
                {
                    OauthClient = new ApplicationCredentialsOAuthClient
                    {
                        ClientId = $"test-client-{guid}",
                        AutoKeyRotation = true,
                        TokenEndpointAuthMethod = OAuthEndpointAuthenticationMethod.ClientSecretPost,
                    },
                },
                Settings = new OpenIdConnectApplicationSettings
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient
                    {
                        ClientUri = "https://example.com",
                        LogoUri = "https://example.com/logo.png",
                        ResponseTypes = supportsCrossAppAccess ? [OAuthResponseType.Token] : [OAuthResponseType.Code],
                        GrantTypes = grantTypes,
                        ApplicationType = applicationType,
                        RedirectUris = supportsCrossAppAccess ? null : ["https://example.com/callback"],
                        PostLogoutRedirectUris = supportsCrossAppAccess ? null : ["https://example.com/logout"]
                    }
                }
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app);
            _appIdsToCleanup.Add(createdApp.Id);
            return (OpenIdConnectApplication)createdApp;
        }

        [Fact(Skip = "Requires manual Admin Console configuration - EA feature. See CROSS_APP_ACCESS_INVESTIGATION.md for details. " +
                     "Service apps need explicit cross-app access enablement in Okta Admin Console beyond SDK configuration. " +
                     "Error: E0000013 'Invalid client app id' despite correct Service app setup with client_credentials grant.")]
        public async Task GivenCrossAppAccessConnections_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            // Arrange: Create two test applications - requesting app and resource app
            var requestingApp = await CreateTestOidcApplication($"SDK Test Requesting App {Guid.NewGuid()}");
            var resourceApp = await CreateTestOidcApplication($"SDK Test Resource App {Guid.NewGuid()}");

            requestingApp.Should().NotBeNull("requesting application should be created successfully");
            requestingApp.Id.Should().NotBeNullOrEmpty("requesting application should have an ID");
            resourceApp.Should().NotBeNull("resource application should be created successfully");
            resourceApp.Id.Should().NotBeNullOrEmpty("resource application should have an ID");

            string connectionId = null;

            try
            {
                // Test 1: CreateCrossAppAccessConnectionAsync
                // Purpose: Creates a Cross App Access connection between two apps
                var connectionRequest = new OrgCrossAppAccessConnection
                {
                    RequestingAppInstanceId = requestingApp.Id,
                    ResourceAppInstanceId = resourceApp.Id,
                    Status = OrgCrossAppAccessConnection.StatusEnum.ACTIVE
                };

                var createdConnection = await _applicationCrossAppAccessConnectionsApi
                    .CreateCrossAppAccessConnectionAsync(requestingApp.Id, connectionRequest);

                createdConnection.Should().NotBeNull("connection should be created successfully");
                createdConnection.Id.Should().NotBeNullOrEmpty("connection should have an ID");
                createdConnection.RequestingAppInstanceId.Should().Be(requestingApp.Id, 
                    "connection should link to the requesting app");
                createdConnection.ResourceAppInstanceId.Should().Be(resourceApp.Id, 
                    "connection should link to the resource app");
                createdConnection.Status.Should().Be(OrgCrossAppAccessConnection.StatusEnum.ACTIVE, 
                    "connection should be created with ACTIVE status");
                createdConnection.Created.Should().BeCloseTo(DateTimeOffset.UtcNow, TimeSpan.FromMinutes(5), 
                    "created timestamp should be recent");
                createdConnection.LastUpdated.Should().BeCloseTo(DateTimeOffset.UtcNow, TimeSpan.FromMinutes(5), 
                    "lastUpdated timestamp should be recent");

                connectionId = createdConnection.Id;

                // Test 2: CreateCrossAppAccessConnectionWithHttpInfoAsync
                // Purpose: Creates a connection and validates HTTP response details
                var connectionRequest2 = new OrgCrossAppAccessConnection
                {
                    RequestingAppInstanceId = requestingApp.Id,
                    ResourceAppInstanceId = resourceApp.Id,
                    Status = OrgCrossAppAccessConnection.StatusEnum.INACTIVE
                };

                var createHttpResponse = await _applicationCrossAppAccessConnectionsApi
                    .CreateCrossAppAccessConnectionWithHttpInfoAsync(requestingApp.Id, connectionRequest2);

                createHttpResponse.Should().NotBeNull("HTTP response should be returned");
                createHttpResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.Created, 
                    "creating a connection should return 201 Created");
                createHttpResponse.Data.Should().NotBeNull("response should contain connection data");
                createHttpResponse.Data.Status.Should().Be(OrgCrossAppAccessConnection.StatusEnum.INACTIVE, 
                    "second connection should be created with INACTIVE status");

                var secondConnectionId = createHttpResponse.Data.Id;

                // Test 3: GetAllCrossAppAccessConnections (Collection)
                // Purpose: Retrieves all Cross App Access connections for an app with pagination
                var allConnections = _applicationCrossAppAccessConnectionsApi
                    .GetAllCrossAppAccessConnections(requestingApp.Id, limit: 10);

                var connectionsList = new List<OrgCrossAppAccessConnection>();
                await foreach (var connection in allConnections)
                {
                    connectionsList.Add(connection);
                }

                connectionsList.Should().NotBeEmpty("requesting app should have connections");
                connectionsList.Count.Should().BeGreaterThanOrEqualTo(2, 
                    "should retrieve at least the two connections we created");
                connectionsList.Should().Contain(c => c.Id == connectionId, 
                    "list should contain the first connection");
                connectionsList.Should().Contain(c => c.Id == secondConnectionId, 
                    "list should contain the second connection");

                foreach (var conn in connectionsList)
                {
                    conn.RequestingAppInstanceId.Should().Be(requestingApp.Id, 
                        "all connections should belong to the requesting app");
                    conn.ResourceAppInstanceId.Should().NotBeNullOrEmpty("connection should have a resource app");
                    conn.Status.Should().NotBeNull("connection should have a status");
                    conn.Status.Value.Should().BeOneOf(["ACTIVE", "INACTIVE"], 
                        "status should be either ACTIVE or INACTIVE");
                }

                // Test 4: GetAllCrossAppAccessConnectionsWithHttpInfoAsync
                // Purpose: Retrieves connections with HTTP response validation
                var getAllHttpResponse = await _applicationCrossAppAccessConnectionsApi
                    .GetAllCrossAppAccessConnectionsWithHttpInfoAsync(requestingApp.Id, limit: 10);

                getAllHttpResponse.Should().NotBeNull("HTTP response should be returned");
                getAllHttpResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK, 
                    "getting connections should return 200 OK");
                getAllHttpResponse.Data.Should().NotBeNull("response should contain connection list");
                getAllHttpResponse.Data.Count.Should().BeGreaterThanOrEqualTo(2, 
                    "HTTP response data should contain at least two connections");

                // Test 5: GetCrossAppAccessConnectionAsync
                // Purpose: Retrieves a specific Cross App Access connection by ID
                var retrievedConnection = await _applicationCrossAppAccessConnectionsApi
                    .GetCrossAppAccessConnectionAsync(requestingApp.Id, connectionId);

                retrievedConnection.Should().NotBeNull("connection should be retrieved successfully");
                retrievedConnection.Id.Should().Be(connectionId, "retrieved connection should have the correct ID");
                retrievedConnection.RequestingAppInstanceId.Should().Be(requestingApp.Id, 
                    "retrieved connection should have the correct requesting app ID");
                retrievedConnection.ResourceAppInstanceId.Should().Be(resourceApp.Id, 
                    "retrieved connection should have the correct resource app ID");
                retrievedConnection.Status.Should().Be(OrgCrossAppAccessConnection.StatusEnum.ACTIVE, 
                    "retrieved connection should maintain its ACTIVE status");

                // Test 6: GetCrossAppAccessConnectionWithHttpInfoAsync
                // Purpose: Retrieves a connection with HTTP response validation
                var getHttpResponse = await _applicationCrossAppAccessConnectionsApi
                    .GetCrossAppAccessConnectionWithHttpInfoAsync(requestingApp.Id, connectionId);

                getHttpResponse.Should().NotBeNull("HTTP response should be returned");
                getHttpResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK, 
                    "getting a connection should return 200 OK");
                getHttpResponse.Data.Should().NotBeNull("response should contain connection data");
                getHttpResponse.Data.Id.Should().Be(connectionId, "HTTP response data should match the requested connection");

                // Test 7: UpdateCrossAppAccessConnectionAsync
                // Purpose: Updates a Cross App Access connection status
                var updateRequest = new OrgCrossAppAccessConnectionPatchRequest
                {
                    Status = OrgCrossAppAccessConnectionPatchRequest.StatusEnum.INACTIVE
                };

                var updatedConnection = await _applicationCrossAppAccessConnectionsApi
                    .UpdateCrossAppAccessConnectionAsync(requestingApp.Id, connectionId, updateRequest);

                updatedConnection.Should().NotBeNull("connection should be updated successfully");
                updatedConnection.Id.Should().Be(connectionId, "updated connection should maintain the same ID");
                updatedConnection.Status.Should().Be(OrgCrossAppAccessConnection.StatusEnum.INACTIVE, 
                    "connection status should be updated to INACTIVE");
                updatedConnection.LastUpdated.Should().BeAfter(createdConnection.LastUpdated, 
                    "lastUpdated timestamp should be updated after the modification");

                // Test 8: UpdateCrossAppAccessConnectionWithHttpInfoAsync
                // Purpose: Updates a connection with HTTP response validation
                var updateRequest2 = new OrgCrossAppAccessConnectionPatchRequest
                {
                    Status = OrgCrossAppAccessConnectionPatchRequest.StatusEnum.ACTIVE
                };

                var updateHttpResponse = await _applicationCrossAppAccessConnectionsApi
                    .UpdateCrossAppAccessConnectionWithHttpInfoAsync(requestingApp.Id, connectionId, updateRequest2);

                updateHttpResponse.Should().NotBeNull("HTTP response should be returned");
                updateHttpResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK, 
                    "updating a connection should return 200 OK");
                updateHttpResponse.Data.Should().NotBeNull("response should contain updated connection data");
                updateHttpResponse.Data.Status.Should().Be(OrgCrossAppAccessConnection.StatusEnum.ACTIVE, 
                    "connection status should be toggled back to ACTIVE");

                // Test 9: Idempotency - Multiple updates to the same status
                var idempotentUpdate = new OrgCrossAppAccessConnectionPatchRequest
                {
                    Status = OrgCrossAppAccessConnectionPatchRequest.StatusEnum.ACTIVE
                };

                var idempotentResult = await _applicationCrossAppAccessConnectionsApi
                    .UpdateCrossAppAccessConnectionAsync(requestingApp.Id, connectionId, idempotentUpdate);

                idempotentResult.Should().NotBeNull("idempotent update should succeed");
                idempotentResult.Status.Should().Be(OrgCrossAppAccessConnection.StatusEnum.ACTIVE, 
                    "status should remain ACTIVE after idempotent update");

                // Test 10: DeleteCrossAppAccessConnectionAsync (for second connection)
                // Purpose: Deletes a Cross App Access connection
                await _applicationCrossAppAccessConnectionsApi
                    .DeleteCrossAppAccessConnectionAsync(requestingApp.Id, secondConnectionId);

                // Verify deletion by attempting to retrieve the deleted connection
                var getDeletedAction = async () => await _applicationCrossAppAccessConnectionsApi
                    .GetCrossAppAccessConnectionAsync(requestingApp.Id, secondConnectionId);

                await getDeletedAction.Should().ThrowAsync<ApiException>(
                    "retrieving a deleted connection should throw an exception")
                    .Where(ex => ex.ErrorCode == 404, "error should be 404 Not Found");

                // Test 11: DeleteCrossAppAccessConnectionWithHttpInfoAsync
                // Purpose: Deletes a connection with HTTP response validation
                var deleteHttpResponse = await _applicationCrossAppAccessConnectionsApi
                    .DeleteCrossAppAccessConnectionWithHttpInfoAsync(requestingApp.Id, connectionId);

                deleteHttpResponse.Should().NotBeNull("HTTP response should be returned");
                deleteHttpResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent, 
                    "deleting a connection should return 204 No Content");

                // Verify deletion
                var getDeletedAction2 = async () => await _applicationCrossAppAccessConnectionsApi
                    .GetCrossAppAccessConnectionAsync(requestingApp.Id, connectionId);

                await getDeletedAction2.Should().ThrowAsync<ApiException>(
                    "retrieving the second deleted connection should throw an exception")
                    .Where(ex => ex.ErrorCode == 404, "error should be 404 Not Found");

                // Test 12: List connections after deletions
                var connectionsAfterDeletion = _applicationCrossAppAccessConnectionsApi
                    .GetAllCrossAppAccessConnections(requestingApp.Id);

                var afterDeletionList = new List<OrgCrossAppAccessConnection>();
                await foreach (var connection in connectionsAfterDeletion)
                {
                    afterDeletionList.Add(connection);
                }

                afterDeletionList.Should().NotContain(c => c.Id == connectionId, 
                    "deleted first connection should not appear in the list");
                afterDeletionList.Should().NotContain(c => c.Id == secondConnectionId, 
                    "deleted second connection should not appear in the list");
            }
            finally
            {
                // Cleanup any remaining connections
                if (!string.IsNullOrEmpty(connectionId))
                {
                    try
                    {
                        await _applicationCrossAppAccessConnectionsApi
                            .DeleteCrossAppAccessConnectionAsync(requestingApp.Id, connectionId);
                    }
                    catch
                    {
                        // Connection might already be deleted
                    }
                }
            }
        }

        [Fact]
        public async Task GivenInvalidParameters_WhenCreatingConnection_ThenExceptionIsThrown()
        {
            // Arrange
            var requestingApp = await CreateTestOidcApplication($"SDK Test Invalid Connection App {Guid.NewGuid()}");

            // Test 1: Invalid resource app ID
            var invalidConnection = new OrgCrossAppAccessConnection
            {
                RequestingAppInstanceId = requestingApp.Id,
                ResourceAppInstanceId = "invalid_app_id_12345",
                Status = OrgCrossAppAccessConnection.StatusEnum.ACTIVE
            };

            var createInvalidAction = async () => await _applicationCrossAppAccessConnectionsApi
                .CreateCrossAppAccessConnectionAsync(requestingApp.Id, invalidConnection);

            var exception = await createInvalidAction.Should().ThrowAsync<ApiException>(
                "creating a connection with invalid resource app should throw an exception");
            exception.Which.ErrorCode.Should().BeOneOf([400, 403, 404], 
                "error should be 400 Bad Request, 403 Forbidden, or 404 Not Found");
            exception.Which.Message.Should().NotBeNullOrEmpty("exception should have a descriptive message");

            // Test 2: Non-existent requesting app
            var nonExistentConnection = new OrgCrossAppAccessConnection
            {
                RequestingAppInstanceId = requestingApp.Id,
                ResourceAppInstanceId = requestingApp.Id,
                Status = OrgCrossAppAccessConnection.StatusEnum.ACTIVE
            };

            var createNonExistentAction = async () => await _applicationCrossAppAccessConnectionsApi
                .CreateCrossAppAccessConnectionAsync("non_existent_app_id", nonExistentConnection);

            var nonExistentException = await createNonExistentAction.Should().ThrowAsync<ApiException>(
                "creating a connection for non-existent app should throw an exception");
            nonExistentException.Which.ErrorCode.Should().BeOneOf([400, 404], 
                "error should be 400 Bad Request or 404 Not Found for non-existent app");
        }

        [Fact]
        public async Task GivenNonExistentId_WhenGettingConnection_ThenExceptionIsThrown()
        {
            // Arrange
            var app = await CreateTestOidcApplication($"SDK Test Get Connection App {Guid.NewGuid()}");

            // Act & Assert
            var getNonExistentAction = async () => await _applicationCrossAppAccessConnectionsApi
                .GetCrossAppAccessConnectionAsync(app.Id, "non_existent_connection_id");

            var exception = await getNonExistentAction.Should().ThrowAsync<ApiException>(
                "getting a non-existent connection should throw an exception");
            exception.Which.ErrorCode.Should().Be(404, "error should be 404 Not Found");
            exception.Which.Message.Should().NotBeNullOrEmpty("exception should have a descriptive message");
        }

        [Fact]
        public async Task GivenNonExistentId_WhenUpdatingConnection_ThenExceptionIsThrown()
        {
            // Arrange
            var app = await CreateTestOidcApplication($"SDK Test Update Connection App {Guid.NewGuid()}");
            var updateRequest = new OrgCrossAppAccessConnectionPatchRequest
            {
                Status = OrgCrossAppAccessConnectionPatchRequest.StatusEnum.INACTIVE
            };

            // Act & Assert
            var updateNonExistentAction = async () => await _applicationCrossAppAccessConnectionsApi
                .UpdateCrossAppAccessConnectionAsync(app.Id, "non_existent_connection_id", updateRequest);

            var exception = await updateNonExistentAction.Should().ThrowAsync<ApiException>(
                "updating a non-existent connection should throw an exception");
            exception.Which.ErrorCode.Should().Be(404, "error should be 404 Not Found");
            exception.Which.Message.Should().NotBeNullOrEmpty("exception should have a descriptive message");
        }

        [Fact]
        public async Task GivenNonExistentId_WhenDeletingConnection_ThenNoExceptionIsThrown()
        {
            // Arrange
            var app = await CreateTestOidcApplication($"SDK Test Delete Connection App {Guid.NewGuid()}");

            // Act & Assert
            // Note: The API returns 204 No Content even when deleting a non-existent connection (idempotent delete)
            // This is the expected behavior, so we verify it completes successfully without throwing
            var deleteAction = async () => await _applicationCrossAppAccessConnectionsApi
                .DeleteCrossAppAccessConnectionAsync(app.Id, "non_existent_connection_id");

            await deleteAction.Should().NotThrowAsync(
                "deleting a non-existent connection should succeed idempotently");
        }

        [Fact(Skip = "Requires manual Admin Console configuration - EA feature. See CROSS_APP_ACCESS_INVESTIGATION.md for details. " +
                     "Service apps need explicit cross-app access enablement in Okta Admin Console beyond SDK configuration. " +
                     "Error: E0000013 'Invalid client app id' despite correct Service app setup with client_credentials grant.")]
        public async Task GivenMultipleConnections_WhenPaginating_ThenPaginationWorks()
        {
            // Arrange: Create requesting and resource apps, then create multiple connections
            var requestingApp = await CreateTestOidcApplication($"SDK Test Pagination Requesting App {Guid.NewGuid()}");
            var resourceApp1 = await CreateTestOidcApplication($"SDK Test Pagination Resource App 1 {Guid.NewGuid()}");
            var resourceApp2 = await CreateTestOidcApplication($"SDK Test Pagination Resource App 2 {Guid.NewGuid()}");

            var connectionIds = new List<string>();

            try
            {
                // Create multiple connections
                var connection1 = new OrgCrossAppAccessConnection
                {
                    RequestingAppInstanceId = requestingApp.Id,
                    ResourceAppInstanceId = resourceApp1.Id,
                    Status = OrgCrossAppAccessConnection.StatusEnum.ACTIVE
                };

                var connection2 = new OrgCrossAppAccessConnection
                {
                    RequestingAppInstanceId = requestingApp.Id,
                    ResourceAppInstanceId = resourceApp2.Id,
                    Status = OrgCrossAppAccessConnection.StatusEnum.INACTIVE
                };

                var created1 = await _applicationCrossAppAccessConnectionsApi
                    .CreateCrossAppAccessConnectionAsync(requestingApp.Id, connection1);
                connectionIds.Add(created1.Id);

                var created2 = await _applicationCrossAppAccessConnectionsApi
                    .CreateCrossAppAccessConnectionAsync(requestingApp.Id, connection2);
                connectionIds.Add(created2.Id);

                // Test pagination with limit
                var pagedConnections = _applicationCrossAppAccessConnectionsApi
                    .GetAllCrossAppAccessConnections(requestingApp.Id, limit: 1);

                var pagedList = new List<OrgCrossAppAccessConnection>();
                await foreach (var connection in pagedConnections)
                {
                    pagedList.Add(connection);
                }

                pagedList.Should().NotBeEmpty("pagination should return at least one connection");
                pagedList.Count.Should().BeGreaterThanOrEqualTo(1, "should retrieve connections with pagination");

                // Test retrieving all connections
                var allConnections = _applicationCrossAppAccessConnectionsApi
                    .GetAllCrossAppAccessConnections(requestingApp.Id, limit: -1);

                var allList = new List<OrgCrossAppAccessConnection>();
                await foreach (var connection in allConnections)
                {
                    allList.Add(connection);
                }

                allList.Should().NotBeEmpty("should retrieve all connections");
                allList.Count.Should().BeGreaterThanOrEqualTo(2, "should retrieve at least the two connections we created");
            }
            finally
            {
                // Cleanup connections
                foreach (var connId in connectionIds)
                {
                    try
                    {
                        await _applicationCrossAppAccessConnectionsApi
                            .DeleteCrossAppAccessConnectionAsync(requestingApp.Id, connId);
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
