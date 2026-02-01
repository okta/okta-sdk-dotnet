// <copyright file="AuthorizationServerKeysApiTests.cs" company="Okta, Inc">
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
    /// Integration tests for AuthorizationServerKeysApi covering all 3 available endpoints.
    /// 
    /// API Coverage:
    /// 1. GET /api/v1/authorizationServers/{authServerId}/credentials/keys - ListAuthorizationServerKeys
    /// 2. GET /api/v1/authorizationServers/{authServerId}/credentials/keys/{keyId} - GetAuthorizationServerKey
    /// 3. POST /api/v1/authorizationServers/{authServerId}/credentials/lifecycle/keyRotate - RotateAuthorizationServerKeys
    /// 
    /// Each method also has a WithHttpInfo variant for returning detailed response information.
    /// 
    /// Key statuses:
    /// - ACTIVE: Currently used to sign tokens
    /// - NEXT: Will become ACTIVE on next rotation
    /// - EXPIRED: Previous ACTIVE key after rotation
    /// </summary>
    public class AuthorizationServerKeysApiTests
    {
        private readonly AuthorizationServerKeysApi _keysApi = new();
        private readonly AuthorizationServerApi _authServerApi = new();

        /// <summary>
        /// Comprehensive test covering all AuthorizationServerKeysApi operations and endpoints.
        /// This single test covers the complete key lifecycle:
        /// - Listing all credential keys
        /// - Getting an individual key by ID
        /// - Rotating keys and verifying status changes
        /// </summary>
        [Fact]
        public async Task GivenAuthorizationServerKeysApi_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
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
                    Description = "Test authorization server for keys API tests",
                    Audiences = new List<string> { $"https://api.{testPrefix}.example.com" }
                };

                var createdAuthServer = await _authServerApi.CreateAuthorizationServerAsync(newAuthServer);
                createdAuthServerId = createdAuthServer.Id;
                createdAuthServerId.Should().NotBeNullOrEmpty();

                // ========================================================================
                // SECTION 1: List All Credential Keys
                // ========================================================================

                #region ListAuthorizationServerKeys - GET /api/v1/authorizationServers/{authServerId}/credentials/keys

                // Test using the synchronous collection method
                var keysCollection = _keysApi.ListAuthorizationServerKeys(createdAuthServerId);
                keysCollection.Should().NotBeNull("Collection method should return a valid collection");

                // Enumerate the collection to get actual results
                var keys = new List<AuthorizationServerJsonWebKey>();
                await foreach (var key in keysCollection)
                {
                    keys.Add(key);
                }

                // A new auth server should have at least one ACTIVE key
                keys.Should().NotBeNull("Keys list should not be null");
                keys.Should().NotBeEmpty("A new auth server should have at least one key");
                
                // Verify the ACTIVE key exists and has proper structure
                var activeKey = keys.FirstOrDefault(k => k.Status == "ACTIVE");
                activeKey.Should().NotBeNull("There should be an ACTIVE key");
                activeKey.Alg.Should().Be("RS256", "Algorithm should be RS256");
                activeKey.Kty.Should().Be("RSA", "Key type should be RSA");
                activeKey.Use.Should().Be("sig", "Key use should be sig (signature)");
                activeKey.Kid.Should().NotBeNullOrEmpty("Key ID should be set");
                activeKey.E.Should().NotBeNullOrEmpty("Public exponent should be set");
                activeKey.N.Should().NotBeNullOrEmpty("Modulus should be set");

                // Test using the WithHttpInfo variant
                var keysWithHttpInfo = await _keysApi.ListAuthorizationServerKeysWithHttpInfoAsync(createdAuthServerId);
                keysWithHttpInfo.Should().NotBeNull("WithHttpInfo should return a valid response");
                keysWithHttpInfo.Data.Should().NotBeNull("Data should not be null");
                keysWithHttpInfo.Data.Should().NotBeEmpty("Keys list should not be empty");

                #endregion

                // ========================================================================
                // SECTION 2: Get Individual Key
                // ========================================================================

                #region GetAuthorizationServerKey - GET /api/v1/authorizationServers/{authServerId}/credentials/keys/{keyId}

                var keyIdToGet = activeKey.Kid;

                // Test GetAuthorizationServerKeyAsync
                var retrievedKey = await _keysApi.GetAuthorizationServerKeyAsync(createdAuthServerId, keyIdToGet);

                retrievedKey.Should().NotBeNull("Retrieved key should not be null");
                retrievedKey.Kid.Should().Be(keyIdToGet, "Key ID should match");
                retrievedKey.Status.Should().Be("ACTIVE", "Retrieved key should have ACTIVE status");
                retrievedKey.Alg.Should().Be("RS256");
                retrievedKey.Kty.Should().Be("RSA");
                retrievedKey.Use.Should().Be("sig");
                retrievedKey.E.Should().Be(activeKey.E, "Public exponent should match");
                retrievedKey.N.Should().Be(activeKey.N, "Modulus should match");

                // Test GetAuthorizationServerKeyWithHttpInfoAsync
                var keyWithHttpInfo = await _keysApi.GetAuthorizationServerKeyWithHttpInfoAsync(createdAuthServerId, keyIdToGet);
                keyWithHttpInfo.Should().NotBeNull();
                keyWithHttpInfo.Data.Should().NotBeNull();
                keyWithHttpInfo.Data.Kid.Should().Be(keyIdToGet);

                #endregion

                // ========================================================================
                // SECTION 3: Rotate Keys
                // ========================================================================

                #region RotateAuthorizationServerKeys - POST /api/v1/authorizationServers/{authServerId}/credentials/lifecycle/keyRotate

                // Store the current ACTIVE key ID before rotation
                var activeKeyIdBeforeRotation = activeKey.Kid;

                // Rotate the keys
                var jwkUse = new JwkUse { Use = JwkUseType.Sig };

                // Use WithHttpInfo to get the rotated keys
                var rotatedKeysResponse = await _keysApi.RotateAuthorizationServerKeysWithHttpInfoAsync(createdAuthServerId, jwkUse);
                rotatedKeysResponse.Should().NotBeNull("Rotation response should not be null");
                rotatedKeysResponse.Data.Should().NotBeNull("Rotated keys should not be null");
                rotatedKeysResponse.Data.Should().NotBeEmpty("Rotated keys list should not be empty");

                // After rotation:
                // - A new ACTIVE key is created
                // - The previous ACTIVE key becomes EXPIRED
                // - A NEXT key may or may not be present depending on the org configuration
                var rotatedKeys = rotatedKeysResponse.Data;

                // Verify new ACTIVE key
                var newActiveKey = rotatedKeys.FirstOrDefault(k => k.Status == "ACTIVE");
                newActiveKey.Should().NotBeNull("There should be an ACTIVE key after rotation");
                newActiveKey.Kid.Should().NotBeNullOrEmpty();
                newActiveKey.Kid.Should().NotBe(activeKeyIdBeforeRotation, 
                    "After rotation, a new key should be ACTIVE");
                newActiveKey.Alg.Should().Be("RS256");
                newActiveKey.Kty.Should().Be("RSA");
                newActiveKey.Use.Should().Be("sig");

                // NEXT key may or may not be present depending on Okta org configuration
                var nextKey = rotatedKeys.FirstOrDefault(k => k.Status == "NEXT");
                // Note: NEXT key presence depends on the org's key rotation policy

                // The previous ACTIVE key should now be EXPIRED
                var expiredKey = rotatedKeys.FirstOrDefault(k => k.Status == "EXPIRED");
                expiredKey.Should().NotBeNull("The previous ACTIVE key should now be EXPIRED");
                expiredKey.Kid.Should().Be(activeKeyIdBeforeRotation, 
                    "The previously ACTIVE key should now be EXPIRED");

                // Verify we can still retrieve the new ACTIVE key
                var verifyActiveKey = await _keysApi.GetAuthorizationServerKeyAsync(createdAuthServerId, newActiveKey.Kid);
                verifyActiveKey.Should().NotBeNull();
                verifyActiveKey.Status.Should().Be("ACTIVE");

                // Verify we can still retrieve the EXPIRED key (for token validation during grace period)
                var verifyExpiredKey = await _keysApi.GetAuthorizationServerKeyAsync(createdAuthServerId, expiredKey.Kid);
                verifyExpiredKey.Should().NotBeNull();
                verifyExpiredKey.Status.Should().Be("EXPIRED");

                #endregion

                // ========================================================================
                // SECTION 4: Verify Key States After Rotation
                // ========================================================================

                #region Verify Final Key States

                // List all keys again to verify the final state
                var finalKeysResponse = await _keysApi.ListAuthorizationServerKeysWithHttpInfoAsync(createdAuthServerId);
                var finalKeys = finalKeysResponse.Data;

                // Should have at least 2 keys (ACTIVE and EXPIRED after rotation)
                finalKeys.Count.Should().BeGreaterThanOrEqualTo(2, "Should have at least ACTIVE and EXPIRED keys");

                // Verify exactly one ACTIVE key
                finalKeys.Count(k => k.Status == "ACTIVE").Should().Be(1, "Should have exactly one ACTIVE key");

                // Verify at least one EXPIRED key (the previous ACTIVE key)
                finalKeys.Count(k => k.Status == "EXPIRED").Should().BeGreaterThanOrEqualTo(1, 
                    "Should have at least one EXPIRED key after rotation");

                // All keys should have valid RSA properties
                foreach (var key in finalKeys)
                {
                    key.Kid.Should().NotBeNullOrEmpty($"Key with status {key.Status} should have a Kid");
                    key.Alg.Should().Be("RS256", $"Key {key.Kid} should have RS256 algorithm");
                    key.Kty.Should().Be("RSA", $"Key {key.Kid} should have RSA key type");
                    key.Use.Should().Be("sig", $"Key {key.Kid} should have sig use");
                    key.E.Should().NotBeNullOrEmpty($"Key {key.Kid} should have public exponent");
                    key.N.Should().NotBeNullOrEmpty($"Key {key.Kid} should have modulus");
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
        /// Tests error handling when accessing non-existent keys.
        /// </summary>
        [Fact]
        public async Task GivenAuthorizationServerKeysApi_WhenAccessingNonExistentKey_ThenReturns404()
        {
            string createdAuthServerId = null;
            var testPrefix = $"dotnet-sdk-test-{Guid.NewGuid():N}".Substring(0, 30);

            try
            {
                // Setup: Create an Authorization Server
                var newAuthServer = new AuthorizationServer
                {
                    Name = $"{testPrefix}-authserver",
                    Description = "Test for non-existent key access",
                    Audiences = new List<string> { $"https://api.{testPrefix}.example.com" }
                };

                var createdAuthServer = await _authServerApi.CreateAuthorizationServerAsync(newAuthServer);
                createdAuthServerId = createdAuthServer.Id;

                // Try to get a non-existent key
                var nonExistentKeyId = "nonExistentKey123456789";

                var exception = await Assert.ThrowsAsync<ApiException>(
                    () => _keysApi.GetAuthorizationServerKeyAsync(createdAuthServerId, nonExistentKeyId));

                exception.ErrorCode.Should().Be(404, "Should return 404 for non-existent key");
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
        /// Tests multiple key rotations to verify the key lifecycle.
        /// </summary>
        [Fact]
        public async Task GivenAuthorizationServerKeysApi_WhenRotatingKeysTwice_ThenKeyLifecycleIsCorrect()
        {
            string createdAuthServerId = null;
            var testPrefix = $"dotnet-sdk-test-{Guid.NewGuid():N}".Substring(0, 30);

            try
            {
                // Setup: Create an Authorization Server
                var newAuthServer = new AuthorizationServer
                {
                    Name = $"{testPrefix}-authserver",
                    Description = "Test for multiple key rotations",
                    Audiences = new List<string> { $"https://api.{testPrefix}.example.com" }
                };

                var createdAuthServer = await _authServerApi.CreateAuthorizationServerAsync(newAuthServer);
                createdAuthServerId = createdAuthServer.Id;

                var jwkUse = new JwkUse { Use = JwkUseType.Sig };

                // Get initial keys - should have exactly one ACTIVE key
                var initialKeysResponse = await _keysApi.ListAuthorizationServerKeysWithHttpInfoAsync(createdAuthServerId);
                var initialActiveKey = initialKeysResponse.Data.First(k => k.Status == "ACTIVE");
                initialActiveKey.Should().NotBeNull("Initial auth server should have an ACTIVE key");

                // First rotation - current ACTIVE key becomes EXPIRED, a new ACTIVE key is created
                var firstRotationResponse = await _keysApi.RotateAuthorizationServerKeysWithHttpInfoAsync(createdAuthServerId, jwkUse);
                var firstActiveKey = firstRotationResponse.Data.First(k => k.Status == "ACTIVE");
                var firstExpiredKey = firstRotationResponse.Data.FirstOrDefault(k => k.Status == "EXPIRED");

                // After first rotation: initial ACTIVE should now be EXPIRED
                firstActiveKey.Kid.Should().NotBe(initialActiveKey.Kid, 
                    "After first rotation, the ACTIVE key should be different");
                firstExpiredKey.Should().NotBeNull("Previous ACTIVE key should be EXPIRED after rotation");
                firstExpiredKey.Kid.Should().Be(initialActiveKey.Kid, 
                    "The initial ACTIVE key should now be EXPIRED");

                // Second rotation - first ACTIVE key becomes EXPIRED, a new ACTIVE key is created
                var secondRotationResponse = await _keysApi.RotateAuthorizationServerKeysWithHttpInfoAsync(createdAuthServerId, jwkUse);
                var secondActiveKey = secondRotationResponse.Data.First(k => k.Status == "ACTIVE");
                var expiredKeys = secondRotationResponse.Data.Where(k => k.Status == "EXPIRED").ToList();

                // After second rotation:
                // - Should have a new ACTIVE key different from the first
                secondActiveKey.Kid.Should().NotBe(firstActiveKey.Kid, 
                    "After second rotation, the ACTIVE key should be different from the first rotation's ACTIVE key");

                // - Should have at least the previous ACTIVE key as EXPIRED
                expiredKeys.Should().NotBeEmpty("Should have at least one EXPIRED key after second rotation");
                expiredKeys.Should().Contain(k => k.Kid == firstActiveKey.Kid, 
                    "The first ACTIVE key should now be EXPIRED after second rotation");

                // Verify all keys have proper RSA structure
                foreach (var key in secondRotationResponse.Data)
                {
                    key.Alg.Should().Be("RS256");
                    key.Kty.Should().Be("RSA");
                    key.Use.Should().Be("sig");
                    key.Kid.Should().NotBeNullOrEmpty();
                }
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
    }
}
