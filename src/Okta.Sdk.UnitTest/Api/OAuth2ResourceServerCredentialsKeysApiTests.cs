// <copyright file="OAuth2ResourceServerCredentialsKeysApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Newtonsoft.Json;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Okta.Sdk.UnitTest.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.UnitTest.Api
{
    /// <summary>
    /// Unit tests for OAuth2ResourceServerCredentialsKeysApi covering all 6 available endpoints.
    /// 
    /// API Coverage:
    /// 1. GET /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys - ListOAuth2ResourceServerJsonWebKeys
    /// 2. POST /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys - AddOAuth2ResourceServerJsonWebKey
    /// 3. GET /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId} - GetOAuth2ResourceServerJsonWebKey
    /// 4. DELETE /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId} - DeleteOAuth2ResourceServerJsonWebKey
    /// 5. POST /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId}/lifecycle/activate - ActivateOAuth2ResourceServerJsonWebKey
    /// 6. POST /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId}/lifecycle/deactivate - DeactivateOAuth2ResourceServerJsonWebKey
    /// 
    /// Each method also has a WithHttpInfo variant for returning detailed response information.
    /// </summary>
    public class OAuth2ResourceServerCredentialsKeysApiTests
    {
        #region ListOAuth2ResourceServerJsonWebKeys Tests

        /// <summary>
        /// Tests that ListOAuth2ResourceServerJsonWebKeys returns a list of keys with proper deserialization.
        /// Verifies: GET /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys
        /// </summary>
        [Fact]
        public async Task ListOAuth2ResourceServerJsonWebKeys_ReturnsKeysList()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var responseJson = @"[
                {
                    ""status"": ""ACTIVE"",
                    ""id"": ""apk40n33xfjbPaf6D0g5"",
                    ""e"": ""AQAB"",
                    ""n"": ""g0MirhrysJMPm_wK45jvMbbyanfhl-jmTBv0o69GeifPaISaXGv"",
                    ""kid"": ""RQ8DuhdxCczyMvy7GNJb4Ka3lQ99vrSo3oFBUiZjzzc"",
                    ""kty"": ""RSA"",
                    ""use"": ""enc"",
                    ""created"": ""2023-04-06T21:32:33.000Z"",
                    ""lastUpdated"": ""2023-04-06T21:32:33.000Z""
                },
                {
                    ""status"": ""INACTIVE"",
                    ""id"": ""apk33a45xfjbDfg6D0g5"",
                    ""e"": ""AQAB"",
                    ""n"": ""l1hZ_g2sgBE3oHvu34T-5XP18FYJWgtul_nRNg-5xra5ySkaXEO"",
                    ""kid"": ""Y3vBOdYT-l-I0j-gRQ26XjutSX00TeWiSguuDhW3ngo"",
                    ""kty"": ""RSA"",
                    ""use"": ""enc"",
                    ""created"": ""2023-04-06T21:32:33.000Z"",
                    ""lastUpdated"": ""2023-04-06T21:32:33.000Z""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act
            var response = await api.ListOAuth2ResourceServerJsonWebKeysWithHttpInfoAsync(authServerId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(authServerId);

            response.Data.Should().NotBeNull();
            response.Data.Should().HaveCount(2);

            var activeKey = response.Data.First(k => k.Status == OAuth2ResourceServerJsonWebKey.StatusEnum.ACTIVE);
            activeKey.Id.Should().Be("apk40n33xfjbPaf6D0g5");
            activeKey.Kid.Should().Be("RQ8DuhdxCczyMvy7GNJb4Ka3lQ99vrSo3oFBUiZjzzc");
            activeKey.Kty.Should().Be("RSA");
            activeKey.Use.Should().Be("enc");
            activeKey.E.Should().Be("AQAB");

            var inactiveKey = response.Data.First(k => k.Status == OAuth2ResourceServerJsonWebKey.StatusEnum.INACTIVE);
            inactiveKey.Id.Should().Be("apk33a45xfjbDfg6D0g5");
        }

        /// <summary>
        /// Tests that ListOAuth2ResourceServerJsonWebKeys validates all key properties.
        /// </summary>
        [Fact]
        public async Task ListOAuth2ResourceServerJsonWebKeys_ValidatesAllKeyProperties()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var responseJson = @"[
                {
                    ""status"": ""ACTIVE"",
                    ""id"": ""apk40n33xfjbPaf6D0g5"",
                    ""e"": ""AQAB"",
                    ""n"": ""g0MirhrysJMPm_wK45jvMbbyanfhl-jmTBv0o69GeifPaISaXGv8LKn3"",
                    ""kid"": ""RQ8DuhdxCczyMvy7GNJb4Ka3lQ99vrSo3oFBUiZjzzc"",
                    ""kty"": ""RSA"",
                    ""use"": ""enc"",
                    ""created"": ""2023-04-06T21:32:33.000Z"",
                    ""lastUpdated"": ""2023-04-07T10:15:00.000Z"",
                    ""_links"": {
                        ""self"": {
                            ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890/resourceservercredentials/keys/apk40n33xfjbPaf6D0g5""
                        }
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act
            var response = await api.ListOAuth2ResourceServerJsonWebKeysWithHttpInfoAsync(authServerId);

            // Assert
            var key = response.Data.First();
            key.Status.Should().Be(OAuth2ResourceServerJsonWebKey.StatusEnum.ACTIVE);
            key.Id.Should().Be("apk40n33xfjbPaf6D0g5");
            key.E.Should().Be("AQAB");
            key.N.Should().Be("g0MirhrysJMPm_wK45jvMbbyanfhl-jmTBv0o69GeifPaISaXGv8LKn3");
            key.Kid.Should().Be("RQ8DuhdxCczyMvy7GNJb4Ka3lQ99vrSo3oFBUiZjzzc");
            key.Kty.Should().Be("RSA");
            key.Use.Should().Be("enc");
            key.Created.Should().Be("2023-04-06T21:32:33.000Z");
            key.LastUpdated.Should().Be("2023-04-07T10:15:00.000Z");
            key.Links.Should().NotBeNull();
        }

        /// <summary>
        /// Tests that ListOAuth2ResourceServerJsonWebKeys collection method returns a valid collection.
        /// </summary>
        [Fact]
        public void ListOAuth2ResourceServerJsonWebKeys_CollectionMethod_ReturnsCollection()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var responseJson = @"[
                {
                    ""status"": ""ACTIVE"",
                    ""id"": ""apk40n33xfjbPaf6D0g5"",
                    ""e"": ""AQAB"",
                    ""n"": ""modulus"",
                    ""kid"": ""kid123"",
                    ""kty"": ""RSA"",
                    ""use"": ""enc""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act
            var collection = api.ListOAuth2ResourceServerJsonWebKeys(authServerId);

            // Assert
            collection.Should().NotBeNull();
            collection.Should().BeAssignableTo<IOktaCollectionClient<OAuth2ResourceServerJsonWebKey>>();
        }

        /// <summary>
        /// Tests that ListOAuth2ResourceServerJsonWebKeys handles empty list response.
        /// </summary>
        [Fact]
        public async Task ListOAuth2ResourceServerJsonWebKeys_EmptyList_ReturnsEmptyCollection()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var responseJson = "[]";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act
            var response = await api.ListOAuth2ResourceServerJsonWebKeysWithHttpInfoAsync(authServerId);

            // Assert
            response.Data.Should().NotBeNull();
            response.Data.Should().BeEmpty();
        }

        #endregion

        #region GetOAuth2ResourceServerJsonWebKey Tests

        /// <summary>
        /// Tests that GetOAuth2ResourceServerJsonWebKey returns a single key.
        /// Verifies: GET /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId}
        /// </summary>
        [Fact]
        public async Task GetOAuth2ResourceServerJsonWebKey_ReturnsKey()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var keyId = "apk2f4zrZbs8nUa7p0g4";
            var responseJson = @"{
                ""id"": ""apk2f4zrZbs8nUa7p0g4"",
                ""kid"": ""ASHJHGasa782333-Sla3x3POBiIxDreBCdZuFs5B"",
                ""kty"": ""RSA"",
                ""use"": ""enc"",
                ""e"": ""AQAB"",
                ""n"": ""AJncrzOrouIUCSMlRL0HU"",
                ""status"": ""INACTIVE"",
                ""created"": ""2023-04-06T21:32:33.000Z"",
                ""lastUpdated"": ""2023-04-06T21:32:33.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act
            var key = await api.GetOAuth2ResourceServerJsonWebKeyAsync(authServerId, keyId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId}");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(authServerId);
            mockClient.ReceivedPathParams.Should().ContainKey("keyId");
            mockClient.ReceivedPathParams["keyId"].Should().Be(keyId);

            key.Should().NotBeNull();
            key.Id.Should().Be("apk2f4zrZbs8nUa7p0g4");
            key.Kid.Should().Be("ASHJHGasa782333-Sla3x3POBiIxDreBCdZuFs5B");
            key.Kty.Should().Be("RSA");
            key.Use.Should().Be("enc");
            key.E.Should().Be("AQAB");
            key.Status.Should().Be(OAuth2ResourceServerJsonWebKey.StatusEnum.INACTIVE);
        }

        /// <summary>
        /// Tests that GetOAuth2ResourceServerJsonWebKey WithHttpInfo returns proper response.
        /// </summary>
        [Fact]
        public async Task GetOAuth2ResourceServerJsonWebKey_WithHttpInfo_ReturnsResponse()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var keyId = "apk2f4zrZbs8nUa7p0g4";
            var responseJson = @"{
                ""id"": ""apk2f4zrZbs8nUa7p0g4"",
                ""kid"": ""test-kid"",
                ""kty"": ""RSA"",
                ""use"": ""enc"",
                ""e"": ""AQAB"",
                ""n"": ""modulus"",
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act
            var response = await api.GetOAuth2ResourceServerJsonWebKeyWithHttpInfoAsync(authServerId, keyId);

            // Assert
            response.Should().NotBeNull();
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be("apk2f4zrZbs8nUa7p0g4");
            response.Data.Status.Should().Be(OAuth2ResourceServerJsonWebKey.StatusEnum.ACTIVE);
        }

        /// <summary>
        /// Tests that GetOAuth2ResourceServerJsonWebKey returns 404 for non-existent key.
        /// </summary>
        [Fact]
        public async Task GetOAuth2ResourceServerJsonWebKey_WhenKeyNotFound_ThrowsApiException()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var keyId = "nonExistentKeyId";
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: nonExistentKeyId (JsonWebKey)"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""sampleErrorId"",
                ""errorCauses"": []
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.GetOAuth2ResourceServerJsonWebKeyAsync(authServerId, keyId));

            exception.ErrorCode.Should().Be(404);
        }

        /// <summary>
        /// Tests that GetOAuth2ResourceServerJsonWebKey returns 403 when forbidden.
        /// </summary>
        [Fact]
        public async Task GetOAuth2ResourceServerJsonWebKey_WhenForbidden_ThrowsApiException()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var keyId = "apk2f4zrZbs8nUa7p0g4";
            var errorJson = @"{
                ""errorCode"": ""E0000006"",
                ""errorSummary"": ""You do not have permission to perform the requested action"",
                ""errorLink"": ""E0000006"",
                ""errorId"": ""sampleErrorId"",
                ""errorCauses"": []
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.Forbidden);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.GetOAuth2ResourceServerJsonWebKeyAsync(authServerId, keyId));

            exception.ErrorCode.Should().Be(403);
        }

        /// <summary>
        /// Tests that GetOAuth2ResourceServerJsonWebKey returns 429 when rate limited.
        /// </summary>
        [Fact]
        public async Task GetOAuth2ResourceServerJsonWebKey_WhenRateLimited_ThrowsApiException()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var keyId = "apk2f4zrZbs8nUa7p0g4";
            var errorJson = @"{
                ""errorCode"": ""E0000047"",
                ""errorSummary"": ""API call exceeded rate limit due to too many requests"",
                ""errorLink"": ""E0000047"",
                ""errorId"": ""sampleErrorId"",
                ""errorCauses"": []
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.TooManyRequests);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.GetOAuth2ResourceServerJsonWebKeyAsync(authServerId, keyId));

            exception.ErrorCode.Should().Be(429);
        }

        #endregion

        #region AddOAuth2ResourceServerJsonWebKey Tests

        /// <summary>
        /// Tests that AddOAuth2ResourceServerJsonWebKey creates a new key.
        /// Verifies: POST /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys
        /// </summary>
        [Fact]
        public async Task AddOAuth2ResourceServerJsonWebKey_CreatesKey()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var responseJson = @"{
                ""id"": ""apk2f4zrZbs8nUa7p0g4"",
                ""kid"": ""ASHJHGasa782333-Sla3x3POBiIxDreBCdZuFs5B"",
                ""kty"": ""RSA"",
                ""use"": ""enc"",
                ""e"": ""AQAB"",
                ""n"": ""AJncrzOrouIUCSMlRL0HU"",
                ""status"": ""INACTIVE"",
                ""created"": ""2023-04-06T21:32:33.000Z"",
                ""lastUpdated"": ""2023-04-06T21:32:33.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            var requestBody = new OAuth2ResourceServerJsonWebKeyRequestBody
            {
                Kid = "ASHJHGasa782333-Sla3x3POBiIxDreBCdZuFs5B",
                Kty = "RSA",
                Use = "enc",
                E = "AQAB",
                N = "AJncrzOrouIUCSMlRL0HU",
                Status = OAuth2ResourceServerJsonWebKeyRequestBody.StatusEnum.INACTIVE
            };

            // Act
            var key = await api.AddOAuth2ResourceServerJsonWebKeyAsync(authServerId, requestBody);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(authServerId);

            key.Should().NotBeNull();
            key.Id.Should().Be("apk2f4zrZbs8nUa7p0g4");
            key.Kid.Should().Be("ASHJHGasa782333-Sla3x3POBiIxDreBCdZuFs5B");
            key.Status.Should().Be(OAuth2ResourceServerJsonWebKey.StatusEnum.INACTIVE);
        }

        /// <summary>
        /// Tests that AddOAuth2ResourceServerJsonWebKey sends correct request body.
        /// </summary>
        [Fact]
        public async Task AddOAuth2ResourceServerJsonWebKey_SendsCorrectRequestBody()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var responseJson = @"{
                ""id"": ""apk2f4zrZbs8nUa7p0g4"",
                ""kid"": ""test-kid"",
                ""kty"": ""RSA"",
                ""use"": ""enc"",
                ""e"": ""AQAB"",
                ""n"": ""test-modulus"",
                ""status"": ""INACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            var requestBody = new OAuth2ResourceServerJsonWebKeyRequestBody
            {
                Kid = "test-kid",
                Kty = "RSA",
                Use = "enc",
                E = "AQAB",
                N = "test-modulus",
                Status = OAuth2ResourceServerJsonWebKeyRequestBody.StatusEnum.INACTIVE
            };

            // Act
            await api.AddOAuth2ResourceServerJsonWebKeyAsync(authServerId, requestBody);

            // Assert
            mockClient.ReceivedBody.Should().NotBeNullOrEmpty();
            var sentBody = JsonConvert.DeserializeObject<Dictionary<string, object>>(mockClient.ReceivedBody);
            sentBody["kid"].ToString().Should().Be("test-kid");
            sentBody["kty"].ToString().Should().Be("RSA");
            sentBody["use"].ToString().Should().Be("enc");
            sentBody["e"].ToString().Should().Be("AQAB");
            sentBody["n"].ToString().Should().Be("test-modulus");
            sentBody["status"].ToString().Should().Be("INACTIVE");
        }

        /// <summary>
        /// Tests that AddOAuth2ResourceServerJsonWebKey returns 400 for invalid request.
        /// </summary>
        [Fact]
        public async Task AddOAuth2ResourceServerJsonWebKey_WhenInvalidRequest_ThrowsApiException()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var errorJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed: JsonWebKey"",
                ""errorLink"": ""E0000001"",
                ""errorId"": ""sampleErrorId"",
                ""errorCauses"": [
                    {
                        ""errorSummary"": ""You cannot add a key with an ACTIVE status. Add an INACTIVE key first, then activate.""
                    }
                ]
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.BadRequest);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            var requestBody = new OAuth2ResourceServerJsonWebKeyRequestBody
            {
                Kid = "test-kid",
                Kty = "RSA",
                Use = "enc",
                E = "AQAB",
                N = "test-modulus",
                Status = OAuth2ResourceServerJsonWebKeyRequestBody.StatusEnum.ACTIVE // Not allowed
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.AddOAuth2ResourceServerJsonWebKeyAsync(authServerId, requestBody));

            exception.ErrorCode.Should().Be(400);
        }

        /// <summary>
        /// Tests that AddOAuth2ResourceServerJsonWebKey WithHttpInfo returns proper response.
        /// </summary>
        [Fact]
        public async Task AddOAuth2ResourceServerJsonWebKey_WithHttpInfo_ReturnsResponse()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var responseJson = @"{
                ""id"": ""apk2f4zrZbs8nUa7p0g4"",
                ""kid"": ""test-kid"",
                ""kty"": ""RSA"",
                ""use"": ""enc"",
                ""e"": ""AQAB"",
                ""n"": ""modulus"",
                ""status"": ""INACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            var requestBody = new OAuth2ResourceServerJsonWebKeyRequestBody
            {
                Kid = "test-kid",
                Kty = "RSA",
                Use = "enc",
                E = "AQAB",
                N = "modulus",
                Status = OAuth2ResourceServerJsonWebKeyRequestBody.StatusEnum.INACTIVE
            };

            // Act
            var response = await api.AddOAuth2ResourceServerJsonWebKeyWithHttpInfoAsync(authServerId, requestBody);

            // Assert
            response.Should().NotBeNull();
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be("apk2f4zrZbs8nUa7p0g4");
        }

        #endregion

        #region DeleteOAuth2ResourceServerJsonWebKey Tests

        /// <summary>
        /// Tests that DeleteOAuth2ResourceServerJsonWebKey deletes a key.
        /// Verifies: DELETE /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId}
        /// </summary>
        [Fact]
        public async Task DeleteOAuth2ResourceServerJsonWebKey_DeletesKey()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var keyId = "apk2f4zrZbs8nUa7p0g4";

            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act
            await api.DeleteOAuth2ResourceServerJsonWebKeyAsync(authServerId, keyId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId}");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(authServerId);
            mockClient.ReceivedPathParams.Should().ContainKey("keyId");
            mockClient.ReceivedPathParams["keyId"].Should().Be(keyId);
        }

        /// <summary>
        /// Tests that DeleteOAuth2ResourceServerJsonWebKey returns 400 when trying to delete active key.
        /// </summary>
        [Fact]
        public async Task DeleteOAuth2ResourceServerJsonWebKey_WhenDeletingActiveKey_ThrowsApiException()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var keyId = "apk2f4zrZbs8nUa7p0g4";
            var errorJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed: JsonWebKey"",
                ""errorLink"": ""E0000001"",
                ""errorId"": ""sampleQPivGUj_ND5v78vbYWW"",
                ""errorCauses"": [
                    {
                        ""errorSummary"": ""'ACTIVE' keys cannot be deleted. Activate another key before deleting this one.""
                    }
                ]
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.BadRequest);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.DeleteOAuth2ResourceServerJsonWebKeyAsync(authServerId, keyId));

            exception.ErrorCode.Should().Be(400);
        }

        /// <summary>
        /// Tests that DeleteOAuth2ResourceServerJsonWebKey returns 404 for non-existent key.
        /// </summary>
        [Fact]
        public async Task DeleteOAuth2ResourceServerJsonWebKey_WhenKeyNotFound_ThrowsApiException()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var keyId = "nonExistentKeyId";
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: nonExistentKeyId (JsonWebKey)"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""sampleErrorId"",
                ""errorCauses"": []
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.DeleteOAuth2ResourceServerJsonWebKeyAsync(authServerId, keyId));

            exception.ErrorCode.Should().Be(404);
        }

        /// <summary>
        /// Tests that DeleteOAuth2ResourceServerJsonWebKey WithHttpInfo returns proper response.
        /// </summary>
        [Fact]
        public async Task DeleteOAuth2ResourceServerJsonWebKey_WithHttpInfo_ReturnsResponse()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var keyId = "apk2f4zrZbs8nUa7p0g4";

            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act
            var response = await api.DeleteOAuth2ResourceServerJsonWebKeyWithHttpInfoAsync(authServerId, keyId);

            // Assert
            response.Should().NotBeNull();
        }

        #endregion

        #region ActivateOAuth2ResourceServerJsonWebKey Tests

        /// <summary>
        /// Tests that ActivateOAuth2ResourceServerJsonWebKey activates a key.
        /// Verifies: POST /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId}/lifecycle/activate
        /// </summary>
        [Fact]
        public async Task ActivateOAuth2ResourceServerJsonWebKey_ActivatesKey()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var keyId = "apk2f4zrZbs8nUa7p0g4";
            var responseJson = @"{
                ""id"": ""apk2f4zrZbs8nUa7p0g4"",
                ""kid"": ""ASHJHGasa782333-Sla3x3POBiIxDreBCdZuFs5B"",
                ""kty"": ""RSA"",
                ""use"": ""enc"",
                ""e"": ""AQAB"",
                ""n"": ""AJncrzOrouIUCSMlRL0HU"",
                ""status"": ""ACTIVE"",
                ""created"": ""2023-04-06T21:32:33.000Z"",
                ""lastUpdated"": ""2023-04-07T10:15:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act
            var key = await api.ActivateOAuth2ResourceServerJsonWebKeyAsync(authServerId, keyId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId}/lifecycle/activate");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(authServerId);
            mockClient.ReceivedPathParams.Should().ContainKey("keyId");
            mockClient.ReceivedPathParams["keyId"].Should().Be(keyId);

            key.Should().NotBeNull();
            key.Id.Should().Be("apk2f4zrZbs8nUa7p0g4");
            key.Status.Should().Be(OAuth2ResourceServerJsonWebKey.StatusEnum.ACTIVE);
        }

        /// <summary>
        /// Tests that ActivateOAuth2ResourceServerJsonWebKey validates path parameters.
        /// </summary>
        [Fact]
        public async Task ActivateOAuth2ResourceServerJsonWebKey_ValidatesPathParameters()
        {
            // Arrange
            var authServerId = "aus-test-server";
            var keyId = "apk-test-key-123";
            var responseJson = @"{
                ""id"": ""apk-test-key-123"",
                ""kid"": ""test-kid"",
                ""kty"": ""RSA"",
                ""use"": ""enc"",
                ""e"": ""AQAB"",
                ""n"": ""modulus"",
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act
            await api.ActivateOAuth2ResourceServerJsonWebKeyAsync(authServerId, keyId);

            // Assert
            mockClient.ReceivedPathParams["authServerId"].Should().Be("aus-test-server");
            mockClient.ReceivedPathParams["keyId"].Should().Be("apk-test-key-123");
        }

        /// <summary>
        /// Tests that ActivateOAuth2ResourceServerJsonWebKey returns 404 for non-existent key.
        /// </summary>
        [Fact]
        public async Task ActivateOAuth2ResourceServerJsonWebKey_WhenKeyNotFound_ThrowsApiException()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var keyId = "nonExistentKeyId";
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: nonExistentKeyId (JsonWebKey)"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""sampleErrorId"",
                ""errorCauses"": []
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.ActivateOAuth2ResourceServerJsonWebKeyAsync(authServerId, keyId));

            exception.ErrorCode.Should().Be(404);
        }

        /// <summary>
        /// Tests that ActivateOAuth2ResourceServerJsonWebKey WithHttpInfo returns proper response.
        /// </summary>
        [Fact]
        public async Task ActivateOAuth2ResourceServerJsonWebKey_WithHttpInfo_ReturnsResponse()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var keyId = "apk2f4zrZbs8nUa7p0g4";
            var responseJson = @"{
                ""id"": ""apk2f4zrZbs8nUa7p0g4"",
                ""kid"": ""test-kid"",
                ""kty"": ""RSA"",
                ""use"": ""enc"",
                ""e"": ""AQAB"",
                ""n"": ""modulus"",
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act
            var response = await api.ActivateOAuth2ResourceServerJsonWebKeyWithHttpInfoAsync(authServerId, keyId);

            // Assert
            response.Should().NotBeNull();
            response.Data.Should().NotBeNull();
            response.Data.Status.Should().Be(OAuth2ResourceServerJsonWebKey.StatusEnum.ACTIVE);
        }

        /// <summary>
        /// Tests that activating a key deactivates the previously active key.
        /// Note: This tests the response structure, actual deactivation would be verified in integration tests.
        /// </summary>
        [Fact]
        public async Task ActivateOAuth2ResourceServerJsonWebKey_ReturnsActivatedKey()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var keyId = "apkNewKey123";
            var responseJson = @"{
                ""id"": ""apkNewKey123"",
                ""kid"": ""new-active-kid"",
                ""kty"": ""RSA"",
                ""use"": ""enc"",
                ""e"": ""AQAB"",
                ""n"": ""newModulus"",
                ""status"": ""ACTIVE"",
                ""created"": ""2023-04-06T21:32:33.000Z"",
                ""lastUpdated"": ""2023-04-07T12:00:00.000Z"",
                ""_links"": {
                    ""deactivate"": {
                        ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890/resourceservercredentials/keys/apkNewKey123/lifecycle/deactivate""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act
            var key = await api.ActivateOAuth2ResourceServerJsonWebKeyAsync(authServerId, keyId);

            // Assert
            key.Status.Should().Be(OAuth2ResourceServerJsonWebKey.StatusEnum.ACTIVE);
            key.Id.Should().Be("apkNewKey123");
            key.Kid.Should().Be("new-active-kid");
            key.Links.Should().NotBeNull();
        }

        #endregion

        #region DeactivateOAuth2ResourceServerJsonWebKey Tests

        /// <summary>
        /// Tests that DeactivateOAuth2ResourceServerJsonWebKey deactivates a key.
        /// Verifies: POST /api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId}/lifecycle/deactivate
        /// </summary>
        [Fact]
        public async Task DeactivateOAuth2ResourceServerJsonWebKey_DeactivatesKey()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var keyId = "apk2f4zrZbs8nUa7p0g4";
            var responseJson = @"{
                ""id"": ""apk2f4zrZbs8nUa7p0g4"",
                ""kid"": ""ASHJHGasa782333-Sla3x3POBiIxDreBCdZuFs5B"",
                ""kty"": ""RSA"",
                ""use"": ""enc"",
                ""e"": ""AQAB"",
                ""n"": ""AJncrzOrouIUCSMlRL0HU"",
                ""status"": ""INACTIVE"",
                ""created"": ""2023-04-06T21:32:33.000Z"",
                ""lastUpdated"": ""2023-04-07T10:15:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act
            var key = await api.DeactivateOAuth2ResourceServerJsonWebKeyAsync(authServerId, keyId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/resourceservercredentials/keys/{keyId}/lifecycle/deactivate");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(authServerId);
            mockClient.ReceivedPathParams.Should().ContainKey("keyId");
            mockClient.ReceivedPathParams["keyId"].Should().Be(keyId);

            key.Should().NotBeNull();
            key.Id.Should().Be("apk2f4zrZbs8nUa7p0g4");
            key.Status.Should().Be(OAuth2ResourceServerJsonWebKey.StatusEnum.INACTIVE);
        }

        /// <summary>
        /// Tests that DeactivateOAuth2ResourceServerJsonWebKey validates path parameters.
        /// </summary>
        [Fact]
        public async Task DeactivateOAuth2ResourceServerJsonWebKey_ValidatesPathParameters()
        {
            // Arrange
            var authServerId = "aus-deactivate-test";
            var keyId = "apk-deactivate-key";
            var responseJson = @"{
                ""id"": ""apk-deactivate-key"",
                ""kid"": ""deactivate-kid"",
                ""kty"": ""RSA"",
                ""use"": ""enc"",
                ""e"": ""AQAB"",
                ""n"": ""modulus"",
                ""status"": ""INACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act
            await api.DeactivateOAuth2ResourceServerJsonWebKeyAsync(authServerId, keyId);

            // Assert
            mockClient.ReceivedPathParams["authServerId"].Should().Be("aus-deactivate-test");
            mockClient.ReceivedPathParams["keyId"].Should().Be("apk-deactivate-key");
        }

        /// <summary>
        /// Tests that DeactivateOAuth2ResourceServerJsonWebKey returns 400 when encryption is enabled.
        /// </summary>
        [Fact]
        public async Task DeactivateOAuth2ResourceServerJsonWebKey_WhenEncryptionEnabled_ThrowsApiException()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var keyId = "apk2f4zrZbs8nUa7p0g4";
            var errorJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed: JsonWebKey"",
                ""errorLink"": ""E0000001"",
                ""errorId"": ""sampleErrorId"",
                ""errorCauses"": [
                    {
                        ""errorSummary"": ""Deactivating the active key isn't allowed if the authorization server has access token encryption enabled.""
                    }
                ]
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.BadRequest);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.DeactivateOAuth2ResourceServerJsonWebKeyAsync(authServerId, keyId));

            exception.ErrorCode.Should().Be(400);
        }

        /// <summary>
        /// Tests that DeactivateOAuth2ResourceServerJsonWebKey returns 404 for non-existent key.
        /// </summary>
        [Fact]
        public async Task DeactivateOAuth2ResourceServerJsonWebKey_WhenKeyNotFound_ThrowsApiException()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var keyId = "nonExistentKeyId";
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: nonExistentKeyId (JsonWebKey)"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""sampleErrorId"",
                ""errorCauses"": []
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.DeactivateOAuth2ResourceServerJsonWebKeyAsync(authServerId, keyId));

            exception.ErrorCode.Should().Be(404);
        }

        /// <summary>
        /// Tests that DeactivateOAuth2ResourceServerJsonWebKey WithHttpInfo returns proper response.
        /// </summary>
        [Fact]
        public async Task DeactivateOAuth2ResourceServerJsonWebKey_WithHttpInfo_ReturnsResponse()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var keyId = "apk2f4zrZbs8nUa7p0g4";
            var responseJson = @"{
                ""id"": ""apk2f4zrZbs8nUa7p0g4"",
                ""kid"": ""test-kid"",
                ""kty"": ""RSA"",
                ""use"": ""enc"",
                ""e"": ""AQAB"",
                ""n"": ""modulus"",
                ""status"": ""INACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act
            var response = await api.DeactivateOAuth2ResourceServerJsonWebKeyWithHttpInfoAsync(authServerId, keyId);

            // Assert
            response.Should().NotBeNull();
            response.Data.Should().NotBeNull();
            response.Data.Status.Should().Be(OAuth2ResourceServerJsonWebKey.StatusEnum.INACTIVE);
        }

        /// <summary>
        /// Tests that DeactivateOAuth2ResourceServerJsonWebKey returns key with delete link.
        /// </summary>
        [Fact]
        public async Task DeactivateOAuth2ResourceServerJsonWebKey_ReturnsKeyWithDeleteLink()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var keyId = "apk2f4zrZbs8nUa7p0g4";
            var responseJson = @"{
                ""id"": ""apk2f4zrZbs8nUa7p0g4"",
                ""kid"": ""deactivated-kid"",
                ""kty"": ""RSA"",
                ""use"": ""enc"",
                ""e"": ""AQAB"",
                ""n"": ""modulus"",
                ""status"": ""INACTIVE"",
                ""_links"": {
                    ""delete"": {
                        ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890/resourceservercredentials/keys/apk2f4zrZbs8nUa7p0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act
            var key = await api.DeactivateOAuth2ResourceServerJsonWebKeyAsync(authServerId, keyId);

            // Assert
            key.Status.Should().Be(OAuth2ResourceServerJsonWebKey.StatusEnum.INACTIVE);
            key.Links.Should().NotBeNull();
        }

        #endregion

        #region Status Enum Tests

        /// <summary>
        /// Tests that StatusEnum correctly handles ACTIVE value.
        /// </summary>
        [Fact]
        public async Task StatusEnum_ActiveValue_ParsesCorrectly()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var keyId = "apk123";
            var responseJson = @"{
                ""id"": ""apk123"",
                ""kid"": ""kid123"",
                ""kty"": ""RSA"",
                ""use"": ""enc"",
                ""e"": ""AQAB"",
                ""n"": ""modulus"",
                ""status"": ""ACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act
            var key = await api.GetOAuth2ResourceServerJsonWebKeyAsync(authServerId, keyId);

            // Assert
            key.Status.Should().Be(OAuth2ResourceServerJsonWebKey.StatusEnum.ACTIVE);
            key.Status.Value.Should().Be("ACTIVE");
        }

        /// <summary>
        /// Tests that StatusEnum correctly handles INACTIVE value.
        /// </summary>
        [Fact]
        public async Task StatusEnum_InactiveValue_ParsesCorrectly()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var keyId = "apk123";
            var responseJson = @"{
                ""id"": ""apk123"",
                ""kid"": ""kid123"",
                ""kty"": ""RSA"",
                ""use"": ""enc"",
                ""e"": ""AQAB"",
                ""n"": ""modulus"",
                ""status"": ""INACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act
            var key = await api.GetOAuth2ResourceServerJsonWebKeyAsync(authServerId, keyId);

            // Assert
            key.Status.Should().Be(OAuth2ResourceServerJsonWebKey.StatusEnum.INACTIVE);
            key.Status.Value.Should().Be("INACTIVE");
        }

        #endregion

        #region Key Properties Tests

        /// <summary>
        /// Tests that encryption key (use=enc) properties are parsed correctly.
        /// </summary>
        [Fact]
        public async Task OAuth2ResourceServerJsonWebKey_EncryptionKeyProperties_ParsedCorrectly()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var keyId = "apk123";
            var responseJson = @"{
                ""id"": ""apk123"",
                ""kid"": ""encryption-key-id"",
                ""kty"": ""RSA"",
                ""use"": ""enc"",
                ""e"": ""AQAB"",
                ""n"": ""veryLongModulusValue1234567890abcdefghijklmnopqrstuvwxyz"",
                ""status"": ""ACTIVE"",
                ""created"": ""2023-04-06T21:32:33.000Z"",
                ""lastUpdated"": ""2023-04-07T10:15:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            // Act
            var key = await api.GetOAuth2ResourceServerJsonWebKeyAsync(authServerId, keyId);

            // Assert
            key.Use.Should().Be("enc");
            key.Kty.Should().Be("RSA");
            key.E.Should().Be("AQAB");
            key.N.Should().Be("veryLongModulusValue1234567890abcdefghijklmnopqrstuvwxyz");
        }

        /// <summary>
        /// Tests that read-only properties (Created, LastUpdated, Id) are parsed but not serialized.
        /// </summary>
        [Fact]
        public async Task OAuth2ResourceServerJsonWebKey_ReadOnlyProperties_AreNotSerialized()
        {
            // Arrange
            var authServerId = "aus1234567890";
            var responseJson = @"{
                ""id"": ""apk2f4zrZbs8nUa7p0g4"",
                ""kid"": ""test-kid"",
                ""kty"": ""RSA"",
                ""use"": ""enc"",
                ""e"": ""AQAB"",
                ""n"": ""modulus"",
                ""status"": ""INACTIVE""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new OAuth2ResourceServerCredentialsKeysApi(mockClient, new Configuration());

            var requestBody = new OAuth2ResourceServerJsonWebKeyRequestBody
            {
                Kid = "test-kid",
                Kty = "RSA",
                Use = "enc",
                E = "AQAB",
                N = "modulus",
                Status = OAuth2ResourceServerJsonWebKeyRequestBody.StatusEnum.INACTIVE
            };

            // Act
            await api.AddOAuth2ResourceServerJsonWebKeyAsync(authServerId, requestBody);

            // Assert - Request body should not contain read-only fields like id, created, lastUpdated
            var sentBody = JsonConvert.DeserializeObject<Dictionary<string, object>>(mockClient.ReceivedBody);
            sentBody.Should().NotContainKey("id");
            sentBody.Should().NotContainKey("created");
            sentBody.Should().NotContainKey("lastUpdated");
        }

        #endregion
    }
}
