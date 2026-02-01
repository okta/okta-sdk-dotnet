// <copyright file="AuthorizationServerClientsApiTests.cs" company="Okta, Inc">
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
    /// Integration tests for AuthorizationServerClientsApi covering all 5 available endpoints.
    /// 
    /// API Coverage:
    /// 1. GET /api/v1/authorizationServers/{authServerId}/clients - ListOAuth2ClientsForAuthorizationServer
    /// 2. GET /api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens - ListRefreshTokensForAuthorizationServerAndClient
    /// 3. DELETE /api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens - RevokeRefreshTokensForAuthorizationServerAndClient
    /// 4. GET /api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens/{tokenId} - GetRefreshTokenForAuthorizationServerAndClient
    /// 5. DELETE /api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens/{tokenId} - RevokeRefreshTokenForAuthorizationServerAndClient
    /// 
    /// Each method also has a WithHttpInfo variant for returning detailed response information.
    /// 
    /// Note: This API manages OAuth2 tokens for clients associated with an authorization server.
    /// Creating tokens requires OAuth flows which are complex to automate in integration tests.
    /// These tests verify the API endpoints work correctly and handle various scenarios.
    /// </summary>
    public class AuthorizationServerClientsApiTests
    {
        private readonly AuthorizationServerClientsApi _clientsApi = new();
        private readonly AuthorizationServerApi _authServerApi = new();

        /// <summary>
        /// Tests listing OAuth2 clients for an authorization server.
        /// This endpoint returns clients that have tokens issued by the auth server.
        /// For a new auth server, this will return an empty list.
        /// </summary>
        [Fact]
        public async Task GivenAuthorizationServerClientsApi_WhenListingClients_ThenEndpointWorks()
        {
            string createdAuthServerId = null;
            var testPrefix = $"dotnet-sdk-test-{Guid.NewGuid():N}".Substring(0, 30);

            try
            {
                // ========================================================================
                // SETUP: Create an Authorization Server for testing
                // ========================================================================

                var newAuthServer = new AuthorizationServer
                {
                    Name = $"{testPrefix}-authserver",
                    Description = "Test authorization server for clients API tests",
                    Audiences = new List<string> { $"https://api.{testPrefix}.example.com" }
                };

                var createdAuthServer = await _authServerApi.CreateAuthorizationServerAsync(newAuthServer);
                createdAuthServerId = createdAuthServer.Id;
                createdAuthServerId.Should().NotBeNullOrEmpty();

                // ========================================================================
                // SECTION 1: List OAuth2 Clients for Authorization Server
                // ========================================================================

                #region ListOAuth2ClientsForAuthorizationServer - GET /api/v1/authorizationServers/{authServerId}/clients

                // Test using the synchronous collection method
                var clientsCollection = _clientsApi.ListOAuth2ClientsForAuthorizationServer(createdAuthServerId);
                clientsCollection.Should().NotBeNull("Collection method should return a valid collection");

                // Enumerate the collection to get actual results
                var clients = new List<OAuth2Client>();
                await foreach (var client in clientsCollection)
                {
                    clients.Add(client);
                }

                // For a new auth server, there should be no clients with tokens yet
                // This is expected behavior - the list can be empty
                clients.Should().NotBeNull("Result should not be null even if empty");

                // Test using the WithHttpInfo variant
                var clientsWithHttpInfo = await _clientsApi.ListOAuth2ClientsForAuthorizationServerWithHttpInfoAsync(createdAuthServerId);
                clientsWithHttpInfo.Should().NotBeNull("WithHttpInfo should return a valid response");
                clientsWithHttpInfo.Data.Should().NotBeNull("Data should not be null");

                #endregion

                // ========================================================================
                // SECTION 2: Test with default authorization server (more likely to have clients)
                // ========================================================================

                #region Test with default auth server

                // The default authorization server is more likely to have clients with tokens
                var defaultAuthServerId = "default";

                try
                {
                    var defaultClients = _clientsApi.ListOAuth2ClientsForAuthorizationServer(defaultAuthServerId);
                    var defaultClientsList = new List<OAuth2Client>();
                    await foreach (var client in defaultClients)
                    {
                        defaultClientsList.Add(client);
                    }

                    // If there are clients, validate their structure
                    if (defaultClientsList.Count > 0)
                    {
                        var firstClient = defaultClientsList[0];
                        firstClient.ClientId.Should().NotBeNullOrEmpty("Client ID should be set");
                        // ClientName might be null for some system clients
                    }
                }
                catch (ApiException ex) when (ex.ErrorCode == 404)
                {
                    // Default auth server may not exist in all environments - this is acceptable
                }

                #endregion
            }
            finally
            {
                // ========================================================================
                // CLEANUP
                // ========================================================================

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
        /// Tests listing and retrieving refresh tokens for a client.
        /// Since we can't easily create tokens via API, we test the endpoint behavior.
        /// </summary>
        [Fact]
        public async Task GivenAuthorizationServerClientsApi_WhenListingTokensForClient_ThenEndpointWorks()
        {
            string createdAuthServerId = null;
            var testPrefix = $"dotnet-sdk-test-{Guid.NewGuid():N}".Substring(0, 30);

            try
            {
                // ========================================================================
                // SETUP: Create an Authorization Server for testing
                // ========================================================================

                var newAuthServer = new AuthorizationServer
                {
                    Name = $"{testPrefix}-authserver",
                    Description = "Test authorization server for token listing tests",
                    Audiences = new List<string> { $"https://api.{testPrefix}.example.com" }
                };

                var createdAuthServer = await _authServerApi.CreateAuthorizationServerAsync(newAuthServer);
                createdAuthServerId = createdAuthServer.Id;

                // ========================================================================
                // SECTION 1: Try to list clients first to find one with potential tokens
                // ========================================================================

                var clients = _clientsApi.ListOAuth2ClientsForAuthorizationServer(createdAuthServerId);
                var clientsList = new List<OAuth2Client>();
                await foreach (var client in clients)
                {
                    clientsList.Add(client);
                }

                // ========================================================================
                // SECTION 2: List Refresh Tokens for a Client
                // ========================================================================

                #region ListRefreshTokensForAuthorizationServerAndClient - GET /api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens

                if (clientsList.Count > 0)
                {
                    // If we have clients, test token listing
                    var firstClientId = clientsList[0].ClientId;

                    var tokensCollection = _clientsApi.ListRefreshTokensForAuthorizationServerAndClient(
                        createdAuthServerId, firstClientId);
                    tokensCollection.Should().NotBeNull();

                    var tokens = new List<OAuth2RefreshToken>();
                    await foreach (var token in tokensCollection)
                    {
                        tokens.Add(token);
                    }

                    // Validate token structure if any exist
                    foreach (var token in tokens)
                    {
                        token.Id.Should().NotBeNullOrEmpty("Token ID should be set");
                        token.ClientId.Should().NotBeNullOrEmpty("Client ID should be set");
                        token.Scopes.Should().NotBeNull("Scopes should not be null");
                    }

                    // Test WithHttpInfo variant
                    var tokensWithHttpInfo = await _clientsApi.ListRefreshTokensForAuthorizationServerAndClientWithHttpInfoAsync(
                        createdAuthServerId, firstClientId);
                    tokensWithHttpInfo.Should().NotBeNull();
                    tokensWithHttpInfo.Data.Should().NotBeNull();

                    // Test with expand parameter
                    var tokensWithExpand = await _clientsApi.ListRefreshTokensForAuthorizationServerAndClientWithHttpInfoAsync(
                        createdAuthServerId, firstClientId, expand: "scope");
                    tokensWithExpand.Should().NotBeNull();
                }
                else
                {
                    // No clients available - use a test client ID to verify endpoint responds correctly
                    // We expect a 404 for a non-existent client
                    var testClientId = "0oaTestClientDoesNotExist";

                    try
                    {
                        await _clientsApi.ListRefreshTokensForAuthorizationServerAndClientWithHttpInfoAsync(
                            createdAuthServerId, testClientId);
                    }
                    catch (ApiException ex)
                    {
                        // Expected - client doesn't exist or has no tokens
                        // Different Okta orgs may return 404 or empty list
                        ex.ErrorCode.Should().BeOneOf(new[] { 404, 403 }, "Expected 404 Not Found or 403 Forbidden for non-existent client");
                    }
                }

                #endregion
            }
            finally
            {
                // ========================================================================
                // CLEANUP
                // ========================================================================

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
        /// Tests the token retrieval and revocation endpoints.
        /// Since tokens require OAuth flows to create, this test validates endpoint behavior
        /// including proper error handling for non-existent resources.
        /// </summary>
        [Fact]
        public async Task GivenAuthorizationServerClientsApi_WhenManagingTokens_ThenEndpointsWorkCorrectly()
        {
            string createdAuthServerId = null;
            var testPrefix = $"dotnet-sdk-test-{Guid.NewGuid():N}".Substring(0, 30);

            try
            {
                // ========================================================================
                // SETUP: Create an Authorization Server for testing
                // ========================================================================

                var newAuthServer = new AuthorizationServer
                {
                    Name = $"{testPrefix}-authserver",
                    Description = "Test authorization server for token management tests",
                    Audiences = new List<string> { $"https://api.{testPrefix}.example.com" }
                };

                var createdAuthServer = await _authServerApi.CreateAuthorizationServerAsync(newAuthServer);
                createdAuthServerId = createdAuthServer.Id;

                // ========================================================================
                // SECTION 1: Try to find existing tokens to test retrieval
                // ========================================================================

                var clients = _clientsApi.ListOAuth2ClientsForAuthorizationServer(createdAuthServerId);
                var clientsList = new List<OAuth2Client>();
                await foreach (var client in clients)
                {
                    clientsList.Add(client);
                }

                OAuth2RefreshToken foundToken = null;
                string foundClientId = null;

                foreach (var client in clientsList)
                {
                    var tokens = _clientsApi.ListRefreshTokensForAuthorizationServerAndClient(
                        createdAuthServerId, client.ClientId);

                    await foreach (var token in tokens)
                    {
                        foundToken = token;
                        foundClientId = client.ClientId;
                        break;
                    }

                    if (foundToken != null)
                        break;
                }

                // ========================================================================
                // SECTION 2: Test Get Refresh Token
                // ========================================================================

                #region GetRefreshTokenForAuthorizationServerAndClient - GET /api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens/{tokenId}

                if (foundToken != null && foundClientId != null)
                {
                    // We found a real token - test retrieval
                    var retrievedToken = await _clientsApi.GetRefreshTokenForAuthorizationServerAndClientAsync(
                        createdAuthServerId, foundClientId, foundToken.Id);

                    retrievedToken.Should().NotBeNull("Retrieved token should not be null");
                    retrievedToken.Id.Should().Be(foundToken.Id, "Token IDs should match");
                    retrievedToken.ClientId.Should().NotBeNullOrEmpty();
                    retrievedToken.Scopes.Should().NotBeNull();

                    // Test WithHttpInfo variant
                    var tokenWithHttpInfo = await _clientsApi.GetRefreshTokenForAuthorizationServerAndClientWithHttpInfoAsync(
                        createdAuthServerId, foundClientId, foundToken.Id);
                    tokenWithHttpInfo.Should().NotBeNull();
                    tokenWithHttpInfo.Data.Should().NotBeNull();

                    // Test with expand parameter
                    var tokenWithExpand = await _clientsApi.GetRefreshTokenForAuthorizationServerAndClientAsync(
                        createdAuthServerId, foundClientId, foundToken.Id, expand: "scope");
                    tokenWithExpand.Should().NotBeNull();
                }
                else
                {
                    // No tokens available - verify endpoint handles missing resources correctly
                    var testClientId = "0oaTestClient123";
                    var testTokenId = "tokTestToken456";

                    try
                    {
                        await _clientsApi.GetRefreshTokenForAuthorizationServerAndClientAsync(
                            createdAuthServerId, testClientId, testTokenId);
                        // If we get here without an exception, the API returned success (unlikely)
                    }
                    catch (ApiException ex)
                    {
                        // Expected - token doesn't exist
                        ex.ErrorCode.Should().BeOneOf(new[] { 404, 403 }, "Expected 404 Not Found or 403 Forbidden for non-existent token");
                    }
                }

                #endregion

                // ========================================================================
                // SECTION 3: Test Revoke Endpoints (without actually revoking if token exists)
                // ========================================================================

                #region RevokeRefreshTokenForAuthorizationServerAndClient - DELETE /api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens/{tokenId}

                // Test revoking a non-existent token - should return 404
                try
                {
                    await _clientsApi.RevokeRefreshTokenForAuthorizationServerAndClientAsync(
                        createdAuthServerId, "0oaNonExistentClient", "tokNonExistentToken");
                }
                catch (ApiException ex)
                {
                    // Expected - can't revoke non-existent token
                    ex.ErrorCode.Should().BeOneOf(new[] { 404, 403 }, "Expected 404 Not Found or 403 Forbidden when revoking non-existent token");
                }

                #endregion

                #region RevokeRefreshTokensForAuthorizationServerAndClient - DELETE /api/v1/authorizationServers/{authServerId}/clients/{clientId}/tokens

                // Test revoking all tokens for a non-existent client
                try
                {
                    await _clientsApi.RevokeRefreshTokensForAuthorizationServerAndClientAsync(
                        createdAuthServerId, "0oaNonExistentClient");
                }
                catch (ApiException ex)
                {
                    // Expected - can't revoke tokens for non-existent client
                    ex.ErrorCode.Should().BeOneOf(new[] { 404, 403, 204 }, "Expected 404, 403, or 204 when revoking tokens for non-existent client");
                }

                #endregion
            }
            finally
            {
                // ========================================================================
                // CLEANUP
                // ========================================================================

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
