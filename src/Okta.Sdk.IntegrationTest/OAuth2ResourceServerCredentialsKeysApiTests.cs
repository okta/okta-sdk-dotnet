// <copyright file="OAuth2ResourceServerCredentialsKeysApiTests.cs" company="Okta, Inc">
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
using System.Security.Cryptography;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for OAuth2ResourceServerCredentialsKeysApi covering all 6 available endpoints.
    /// 
    /// API Coverage:
    /// 1. GET /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys - ListOAuth2ResourceServerJsonWebKeys
    /// 2. POST /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys - AddOAuth2ResourceServerJsonWebKey
    /// 3. GET /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId} - GetOAuth2ResourceServerJsonWebKey
    /// 4. DELETE /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId} - DeleteOAuth2ResourceServerJsonWebKey
    /// 5. POST /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId}/lifecycle/activate - ActivateOAuth2ResourceServerJsonWebKey
    /// 6. POST /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId}/lifecycle/deactivate - DeactivateOAuth2ResourceServerJsonWebKey
    /// 
    /// Note: These are resource server credential keys used for encrypting tokens,
    /// different from the signing keys tested in AuthorizationServerKeysApiTests.
    /// </summary>
    public class OAuth2ResourceServerCredentialsKeysApiTests
    {
        private readonly OAuth2ResourceServerCredentialsKeysApi _keysApi = new();
        private readonly AuthorizationServerApi _authServerApi = new();

        /// <summary>
        /// Generates a valid 2048-bit RSA public key in JWK format.
        /// Returns the modulus (N) and exponent (E) as Base64Url encoded strings.
        /// </summary>
        private static (string N, string E) GenerateRsaKeyComponents()
        {
            using var rsa = RSA.Create(2048);
            var parameters = rsa.ExportParameters(false); // Only public key
            
            // Convert to Base64Url encoding
            var n = Base64UrlEncode(parameters.Modulus);
            var e = Base64UrlEncode(parameters.Exponent);
            
            return (n, e);
        }

        private static string Base64UrlEncode(byte[] data)
        {
            var base64 = Convert.ToBase64String(data);
            // Replace + with -, / with _, and remove padding
            return base64.Replace('+', '-').Replace('/', '_').TrimEnd('=');
        }

        /// <summary>
        /// Comprehensive test covering all OAuth2ResourceServerCredentialsKeysApi operations.
        /// This single test covers the complete key lifecycle:
        /// - Listing all resource server credential keys
        /// - Adding a new key (must be INACTIVE)
        /// - Getting an individual key by ID
        /// - Activating the key
        /// - Deactivating the key
        /// - Deleting the key (must be INACTIVE)
        /// </summary>
        [Fact]
        public async Task GivenOAuth2ResourceServerCredentialsKeysApi_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            string createdAuthServerId = null;
            string createdKeyId = null;
            var testPrefix = $"dotnet-sdk-test-{Guid.NewGuid():N}".Substring(0, 30);

            try
            {
                // ========================================================================
                // SETUP: Create an Authorization Server for testing
                // ========================================================================

                var newAuthServer = new AuthorizationServer
                {
                    Name = $"{testPrefix}-authserver",
                    Description = "Test authorization server for resource server keys API tests",
                    Audiences = new List<string> { $"https://api.{testPrefix}.example.com" }
                };

                var createdAuthServer = await _authServerApi.CreateAuthorizationServerAsync(newAuthServer);
                createdAuthServerId = createdAuthServer.Id;
                createdAuthServerId.Should().NotBeNullOrEmpty();

                // ========================================================================
                // SECTION 1: List All Resource Server Credential Keys (Initial State)
                // ========================================================================

                #region ListOAuth2ResourceServerJsonWebKeys - GET /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys

                // Test using the synchronous collection method
                var keysCollection = _keysApi.ListOAuth2ResourceServerJsonWebKeys(createdAuthServerId);
                keysCollection.Should().NotBeNull("Collection method should return a valid collection");

                // Enumerate the collection to get actual results
                var initialKeys = new List<OAuth2ResourceServerJsonWebKey>();
                await foreach (var key in keysCollection)
                {
                    initialKeys.Add(key);
                }

                // A new auth server may not have any resource server credential keys initially
                initialKeys.Should().NotBeNull("Keys list should not be null");

                // Test using the WithHttpInfo variant
                var keysWithHttpInfo = await _keysApi.ListOAuth2ResourceServerJsonWebKeysWithHttpInfoAsync(createdAuthServerId);
                keysWithHttpInfo.Should().NotBeNull("WithHttpInfo should return a valid response");
                // Note: Data may be null or empty for a new auth server with no resource server credential keys

                #endregion

                // ========================================================================
                // SECTION 2: Add a New Resource Server Credential Key
                // ========================================================================

                #region AddOAuth2ResourceServerJsonWebKey - POST /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys

                // Generate a unique kid for this test
                var testKid = $"test-enc-key-{Guid.NewGuid():N}".Substring(0, 40);

                // Generate a valid 2048-bit RSA key
                var (rsaModulus, rsaExponent) = GenerateRsaKeyComponents();

                var requestBody = new OAuth2ResourceServerJsonWebKeyRequestBody
                {
                    Kid = testKid,
                    Kty = "RSA",
                    Use = "enc",
                    E = rsaExponent,
                    N = rsaModulus,
                    // Must add as INACTIVE first, then activate
                    Status = OAuth2ResourceServerJsonWebKeyRequestBody.StatusEnum.INACTIVE
                };

                var addedKey = await _keysApi.AddOAuth2ResourceServerJsonWebKeyAsync(createdAuthServerId, requestBody);

                addedKey.Should().NotBeNull("Added key should not be null");
                addedKey.Id.Should().NotBeNullOrEmpty("Added key should have an ID");
                addedKey.Kid.Should().Be(testKid, "Kid should match the request");
                addedKey.Kty.Should().Be("RSA", "Key type should be RSA");
                addedKey.Use.Should().Be("enc", "Key use should be enc (encryption)");
                addedKey.Status.Should().Be(OAuth2ResourceServerJsonWebKey.StatusEnum.INACTIVE, 
                    "Newly added key should be INACTIVE");
                addedKey.E.Should().Be(rsaExponent, "Public exponent should match");
                addedKey.Created.Should().NotBeNullOrEmpty("Created timestamp should be set");

                createdKeyId = addedKey.Id;

                // Generate another valid RSA key for the second test key
                var (rsaModulus2, rsaExponent2) = GenerateRsaKeyComponents();

                // Test AddOAuth2ResourceServerJsonWebKey WithHttpInfo variant
                var addRequestBody2 = new OAuth2ResourceServerJsonWebKeyRequestBody
                {
                    Kid = $"test-enc-key-2-{Guid.NewGuid():N}".Substring(0, 40),
                    Kty = "RSA",
                    Use = "enc",
                    E = rsaExponent2,
                    N = rsaModulus2,
                    Status = OAuth2ResourceServerJsonWebKeyRequestBody.StatusEnum.INACTIVE
                };

                var addWithHttpInfo = await _keysApi.AddOAuth2ResourceServerJsonWebKeyWithHttpInfoAsync(createdAuthServerId, addRequestBody2);
                addWithHttpInfo.Should().NotBeNull();
                addWithHttpInfo.Data.Should().NotBeNull();
                var secondKeyId = addWithHttpInfo.Data.Id;

                #endregion

                // ========================================================================
                // SECTION 3: Get Individual Key
                // ========================================================================

                #region GetOAuth2ResourceServerJsonWebKey - GET /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId}

                // Test GetOAuth2ResourceServerJsonWebKeyAsync
                var retrievedKey = await _keysApi.GetOAuth2ResourceServerJsonWebKeyAsync(createdAuthServerId, createdKeyId);

                retrievedKey.Should().NotBeNull("Retrieved key should not be null");
                retrievedKey.Id.Should().Be(createdKeyId, "Key ID should match");
                retrievedKey.Kid.Should().Be(testKid, "Kid should match");
                retrievedKey.Status.Should().Be(OAuth2ResourceServerJsonWebKey.StatusEnum.INACTIVE);
                retrievedKey.Kty.Should().Be("RSA");
                retrievedKey.Use.Should().Be("enc");

                // Test GetOAuth2ResourceServerJsonWebKeyWithHttpInfoAsync
                var keyWithHttpInfo = await _keysApi.GetOAuth2ResourceServerJsonWebKeyWithHttpInfoAsync(createdAuthServerId, createdKeyId);
                keyWithHttpInfo.Should().NotBeNull();
                keyWithHttpInfo.Data.Should().NotBeNull();
                keyWithHttpInfo.Data.Id.Should().Be(createdKeyId);

                #endregion

                // ========================================================================
                // SECTION 4: Activate Key
                // ========================================================================

                #region ActivateOAuth2ResourceServerJsonWebKey - POST /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId}/lifecycle/activate

                // Activate the first key
                var activatedKey = await _keysApi.ActivateOAuth2ResourceServerJsonWebKeyAsync(createdAuthServerId, createdKeyId);

                activatedKey.Should().NotBeNull("Activated key should not be null");
                activatedKey.Id.Should().Be(createdKeyId, "Key ID should match");
                activatedKey.Status.Should().Be(OAuth2ResourceServerJsonWebKey.StatusEnum.ACTIVE, 
                    "Key should now be ACTIVE");
                activatedKey.LastUpdated.Should().NotBeNullOrEmpty("LastUpdated should be set after activation");

                // Verify the key is now active
                var verifyActiveKey = await _keysApi.GetOAuth2ResourceServerJsonWebKeyAsync(createdAuthServerId, createdKeyId);
                verifyActiveKey.Status.Should().Be(OAuth2ResourceServerJsonWebKey.StatusEnum.ACTIVE);

                // Test ActivateOAuth2ResourceServerJsonWebKeyWithHttpInfoAsync - activate the second key
                // Note: Activating a second key should automatically deactivate the first one
                var activateWithHttpInfo = await _keysApi.ActivateOAuth2ResourceServerJsonWebKeyWithHttpInfoAsync(createdAuthServerId, secondKeyId);
                activateWithHttpInfo.Should().NotBeNull();
                activateWithHttpInfo.Data.Should().NotBeNull();
                activateWithHttpInfo.Data.Status.Should().Be(OAuth2ResourceServerJsonWebKey.StatusEnum.ACTIVE);

                // Verify the first key is now INACTIVE (only one active key allowed)
                var firstKeyAfterSecondActivation = await _keysApi.GetOAuth2ResourceServerJsonWebKeyAsync(createdAuthServerId, createdKeyId);
                firstKeyAfterSecondActivation.Status.Should().Be(OAuth2ResourceServerJsonWebKey.StatusEnum.INACTIVE, 
                    "First key should be INACTIVE after activating second key");

                #endregion

                // ========================================================================
                // SECTION 5: Deactivate Key
                // ========================================================================

                #region DeactivateOAuth2ResourceServerJsonWebKey - POST /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId}/lifecycle/deactivate

                // First, activate the first key again so we can test deactivating it
                await _keysApi.ActivateOAuth2ResourceServerJsonWebKeyAsync(createdAuthServerId, createdKeyId);

                // Now deactivate it
                var deactivatedKey = await _keysApi.DeactivateOAuth2ResourceServerJsonWebKeyAsync(createdAuthServerId, createdKeyId);

                deactivatedKey.Should().NotBeNull("Deactivated key should not be null");
                deactivatedKey.Id.Should().Be(createdKeyId, "Key ID should match");
                deactivatedKey.Status.Should().Be(OAuth2ResourceServerJsonWebKey.StatusEnum.INACTIVE, 
                    "Key should now be INACTIVE");

                // Verify the key is now inactive
                var verifyInactiveKey = await _keysApi.GetOAuth2ResourceServerJsonWebKeyAsync(createdAuthServerId, createdKeyId);
                verifyInactiveKey.Status.Should().Be(OAuth2ResourceServerJsonWebKey.StatusEnum.INACTIVE);

                // Test DeactivateOAuth2ResourceServerJsonWebKeyWithHttpInfoAsync
                // First activate the second key
                await _keysApi.ActivateOAuth2ResourceServerJsonWebKeyAsync(createdAuthServerId, secondKeyId);
                var deactivateWithHttpInfo = await _keysApi.DeactivateOAuth2ResourceServerJsonWebKeyWithHttpInfoAsync(createdAuthServerId, secondKeyId);
                deactivateWithHttpInfo.Should().NotBeNull();
                deactivateWithHttpInfo.Data.Should().NotBeNull();
                deactivateWithHttpInfo.Data.Status.Should().Be(OAuth2ResourceServerJsonWebKey.StatusEnum.INACTIVE);

                #endregion

                // ========================================================================
                // SECTION 6: Delete Key
                // ========================================================================

                #region DeleteOAuth2ResourceServerJsonWebKey - DELETE /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId}

                // Note: Can only delete INACTIVE keys
                // The first key should be INACTIVE now, so we can delete it

                // Test DeleteOAuth2ResourceServerJsonWebKeyAsync
                await _keysApi.DeleteOAuth2ResourceServerJsonWebKeyAsync(createdAuthServerId, createdKeyId);

                // Verify the key is deleted (should throw 404)
                var deleteException = await Assert.ThrowsAsync<ApiException>(
                    () => _keysApi.GetOAuth2ResourceServerJsonWebKeyAsync(createdAuthServerId, createdKeyId));
                deleteException.ErrorCode.Should().Be(404, "Deleted key should return 404");

                createdKeyId = null; // Mark as deleted for cleanup

                // Test DeleteOAuth2ResourceServerJsonWebKeyWithHttpInfoAsync
                var deleteWithHttpInfo = await _keysApi.DeleteOAuth2ResourceServerJsonWebKeyWithHttpInfoAsync(createdAuthServerId, secondKeyId);
                deleteWithHttpInfo.Should().NotBeNull();

                #endregion

                // ========================================================================
                // SECTION 7: Verify Final State
                // ========================================================================

                #region Verify Final Key State

                // List all keys again to verify the final state
                var finalKeysResponse = await _keysApi.ListOAuth2ResourceServerJsonWebKeysWithHttpInfoAsync(createdAuthServerId);
                var finalKeys = finalKeysResponse.Data;

                // Both keys should be deleted - finalKeys will be null or empty when all keys are deleted
                if (finalKeys != null)
                {
                    finalKeys.Should().NotContain(k => k.Id == createdKeyId || k.Id == secondKeyId);
                }

                #endregion
            }
            finally
            {
                // ========================================================================
                // CLEANUP
                // ========================================================================

                // Delete any remaining test key
                if (!string.IsNullOrEmpty(createdKeyId) && !string.IsNullOrEmpty(createdAuthServerId))
                {
                    try
                    {
                        // First try to deactivate, then delete
                        try
                        {
                            await _keysApi.DeactivateOAuth2ResourceServerJsonWebKeyAsync(createdAuthServerId, createdKeyId);
                        }
                        catch (ApiException)
                        {
                            // May already be inactive
                        }
                        await _keysApi.DeleteOAuth2ResourceServerJsonWebKeyAsync(createdAuthServerId, createdKeyId);
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
        /// Tests error handling when accessing non-existent key.
        /// </summary>
        [Fact]
        public async Task GivenOAuth2ResourceServerCredentialsKeysApi_WhenAccessingNonExistentKey_ThenReturns404()
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
                    () => _keysApi.GetOAuth2ResourceServerJsonWebKeyAsync(createdAuthServerId, nonExistentKeyId));

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
        /// Tests error handling when trying to delete an active key.
        /// </summary>
        [Fact]
        public async Task GivenOAuth2ResourceServerCredentialsKeysApi_WhenDeletingActiveKey_ThenReturns400()
        {
            string createdAuthServerId = null;
            string createdKeyId = null;
            var testPrefix = $"dotnet-sdk-test-{Guid.NewGuid():N}".Substring(0, 30);

            try
            {
                // Setup: Create an Authorization Server
                var newAuthServer = new AuthorizationServer
                {
                    Name = $"{testPrefix}-authserver",
                    Description = "Test for deleting active key",
                    Audiences = new List<string> { $"https://api.{testPrefix}.example.com" }
                };

                var createdAuthServer = await _authServerApi.CreateAuthorizationServerAsync(newAuthServer);
                createdAuthServerId = createdAuthServer.Id;

                // Generate a valid 2048-bit RSA key
                var (rsaModulus, rsaExponent) = GenerateRsaKeyComponents();

                // Add a new key (INACTIVE)
                var requestBody = new OAuth2ResourceServerJsonWebKeyRequestBody
                {
                    Kid = $"test-delete-active-{Guid.NewGuid():N}".Substring(0, 40),
                    Kty = "RSA",
                    Use = "enc",
                    E = rsaExponent,
                    N = rsaModulus,
                    Status = OAuth2ResourceServerJsonWebKeyRequestBody.StatusEnum.INACTIVE
                };

                var addedKey = await _keysApi.AddOAuth2ResourceServerJsonWebKeyAsync(createdAuthServerId, requestBody);
                createdKeyId = addedKey.Id;

                // Activate the key
                await _keysApi.ActivateOAuth2ResourceServerJsonWebKeyAsync(createdAuthServerId, createdKeyId);

                // Try to delete the active key - should fail with 400
                var exception = await Assert.ThrowsAsync<ApiException>(
                    () => _keysApi.DeleteOAuth2ResourceServerJsonWebKeyAsync(createdAuthServerId, createdKeyId));

                exception.ErrorCode.Should().Be(400, "Should return 400 when trying to delete an active key");
            }
            finally
            {
                // Cleanup
                if (!string.IsNullOrEmpty(createdKeyId) && !string.IsNullOrEmpty(createdAuthServerId))
                {
                    try
                    {
                        await _keysApi.DeactivateOAuth2ResourceServerJsonWebKeyAsync(createdAuthServerId, createdKeyId);
                        await _keysApi.DeleteOAuth2ResourceServerJsonWebKeyAsync(createdAuthServerId, createdKeyId);
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
