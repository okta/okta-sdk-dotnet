// <copyright file="AuthorizationServerKeysApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Okta.Sdk.UnitTest.Internal;
using Xunit;

namespace Okta.Sdk.UnitTest.Api
{
    /// <summary>
    /// Unit tests for AuthorizationServerKeysApi covering all 3 endpoints.
    /// 
    /// API Coverage:
    /// 1. GET /api/v1/authorizationServers/{authServerId}/credentials/keys - ListAuthorizationServerKeys
    /// 2. GET /api/v1/authorizationServers/{authServerId}/credentials/keys/{keyId} - GetAuthorizationServerKey
    /// 3. POST /api/v1/authorizationServers/{authServerId}/credentials/lifecycle/keyRotate - RotateAuthorizationServerKeys
    /// 
    /// Each method is tested with:
    /// - Regular async method
    /// - WithHttpInfo variant for response metadata
    /// - Proper request path and parameters validation
    /// - Response data validation
    /// </summary>
    public class AuthorizationServerKeysApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _authServerId = "aus1234567890abcdef";
        private readonly string _keyId = "RQ8DuhdxCczyMvy7GNJb4Ka3lQ99vrSo3oFBUiZjzzc";

        #region ListAuthorizationServerKeys Tests

        [Fact]
        public async Task ListAuthorizationServerKeys_ReturnsKeysList()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""status"": ""ACTIVE"",
                    ""alg"": ""RS256"",
                    ""e"": ""AQAB"",
                    ""n"": ""g0MirhrysJMPm_wK45jvMbbyanfhl-jmTBv0o69GeifPaISaXGv8LKn3-CyJvUJcjjeHE17KtumJWVxUDRzFqtIMZ1ctCZyIAuWO0n"",
                    ""kid"": ""RQ8DuhdxCczyMvy7GNJb4Ka3lQ99vrSo3oFBUiZjzzc"",
                    ""kty"": ""RSA"",
                    ""use"": ""sig"",
                    ""_links"": {
                        ""self"": {
                            ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/credentials/keys/RQ8DuhdxCczyMvy7GNJb4Ka3lQ99vrSo3oFBUiZjzzc""
                        }
                    }
                },
                {
                    ""status"": ""NEXT"",
                    ""alg"": ""RS256"",
                    ""e"": ""AQAB"",
                    ""n"": ""l1hZ_g2sgBE3oHvu34T-5XP18FYJWgtul_nRNg-5xra5ySkaXEOJUDRERUG0HrR42uqf9jYrUTwg9fp-SqqNIdHRaN8EwRSDRsKAwK"",
                    ""kid"": ""Y3vBOdYT-l-I0j-gRQ26XjutSX00TeWiSguuDhW3ngo"",
                    ""kty"": ""RSA"",
                    ""use"": ""sig"",
                    ""_links"": {
                        ""self"": {
                            ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/credentials/keys/Y3vBOdYT-l-I0j-gRQ26XjutSX00TeWiSguuDhW3ngo""
                        }
                    }
                },
                {
                    ""status"": ""EXPIRED"",
                    ""alg"": ""RS256"",
                    ""e"": ""AQAB"",
                    ""n"": ""lC4ehVB6W0OCtNPnz8udYH9Ao83B6EKnHA5eTcMOap_lQZ-nKtS1lZwBj4wXRVc1XmS0d2OQFA1VMQ-dHLDE3CiGfsGqWbaiZFdW7U"",
                    ""kid"": ""h5Sr3LXcpQiQlAUVPdhrdLFoIvkhRTAVs_h39bQnxlU"",
                    ""kty"": ""RSA"",
                    ""use"": ""sig"",
                    ""_links"": {
                        ""self"": {
                            ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/credentials/keys/h5Sr3LXcpQiQlAUVPdhrdLFoIvkhRTAVs_h39bQnxlU""
                        }
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListAuthorizationServerKeysWithHttpInfoAsync(_authServerId);

            // Assert
            result.Data.Should().NotBeNull();
            result.Data.Should().HaveCount(3);
            
            // Verify ACTIVE key
            result.Data[0].Status.Should().Be("ACTIVE");
            result.Data[0].Alg.Should().Be("RS256");
            result.Data[0].E.Should().Be("AQAB");
            result.Data[0].Kid.Should().Be("RQ8DuhdxCczyMvy7GNJb4Ka3lQ99vrSo3oFBUiZjzzc");
            result.Data[0].Kty.Should().Be("RSA");
            result.Data[0].Use.Should().Be("sig");
            result.Data[0].N.Should().NotBeNullOrEmpty();
            result.Data[0].Links.Should().NotBeNull();

            // Verify NEXT key
            result.Data[1].Status.Should().Be("NEXT");
            result.Data[1].Alg.Should().Be("RS256");
            result.Data[1].Kid.Should().Be("Y3vBOdYT-l-I0j-gRQ26XjutSX00TeWiSguuDhW3ngo");

            // Verify EXPIRED key
            result.Data[2].Status.Should().Be("EXPIRED");
            result.Data[2].Kid.Should().Be("h5Sr3LXcpQiQlAUVPdhrdLFoIvkhRTAVs_h39bQnxlU");

            // Verify request path
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/credentials/keys");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(_authServerId);
        }

        [Fact]
        public async Task ListAuthorizationServerKeys_WithOnlyActiveKey_ReturnsSingleKey()
        {
            // Arrange - New auth server might only have an ACTIVE key
            var responseJson = @"[
                {
                    ""status"": ""ACTIVE"",
                    ""alg"": ""RS256"",
                    ""e"": ""AQAB"",
                    ""n"": ""g0MirhrysJMPm_wK45jvMbbyanfhl-jmTBv0o69GeifPaISaXGv8LKn3"",
                    ""kid"": ""activeKey123"",
                    ""kty"": ""RSA"",
                    ""use"": ""sig""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListAuthorizationServerKeysWithHttpInfoAsync(_authServerId);

            // Assert
            result.Data.Should().HaveCount(1);
            result.Data[0].Status.Should().Be("ACTIVE");
        }

        [Fact]
        public async Task ListAuthorizationServerKeys_CollectionMethod_ReturnsCollection()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""status"": ""ACTIVE"",
                    ""alg"": ""RS256"",
                    ""kid"": ""testKey123"",
                    ""kty"": ""RSA"",
                    ""use"": ""sig""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var collection = api.ListAuthorizationServerKeys(_authServerId);

            // Assert
            collection.Should().NotBeNull();
        }

        [Fact]
        public async Task ListAuthorizationServerKeys_ValidatesAllKeyProperties()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""status"": ""ACTIVE"",
                    ""alg"": ""RS256"",
                    ""e"": ""AQAB"",
                    ""n"": ""modulus_value_here"",
                    ""kid"": ""unique-key-id-123"",
                    ""kty"": ""RSA"",
                    ""use"": ""sig"",
                    ""_links"": {
                        ""self"": {
                            ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus123/credentials/keys/unique-key-id-123"",
                            ""hints"": {
                                ""allow"": [""GET""]
                            }
                        }
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListAuthorizationServerKeysWithHttpInfoAsync(_authServerId);

            // Assert
            var key = result.Data[0];
            key.Status.Should().Be("ACTIVE");
            key.Alg.Should().Be("RS256");
            key.E.Should().Be("AQAB");
            key.N.Should().Be("modulus_value_here");
            key.Kid.Should().Be("unique-key-id-123");
            key.Kty.Should().Be("RSA");
            key.Use.Should().Be("sig");
            key.Links.Should().NotBeNull();
        }

        #endregion

        #region GetAuthorizationServerKey Tests

        [Fact]
        public async Task GetAuthorizationServerKey_ReturnsKey()
        {
            // Arrange
            var responseJson = @"{
                ""status"": ""ACTIVE"",
                ""alg"": ""RS256"",
                ""e"": ""AQAB"",
                ""n"": ""g0MirhrysJMPm_wK45jvMbbyanfhl-jmTBv0o69GeifPaISaXGv8LKn3-CyJvUJcjjeHE17KtumJWVxUDRzFqtIMZ1ctCZyIAuWO0nLKilg7_EIDXJrS8k14biqkPO1lXGFwtjo3zLHeFSLw6sWf-CEN9zv6Ff3IAXb-RMYpfh-bVrxIgWsWCxjLW-UKI3la-gs0nWHH2PJr5HLJuIJIOL"",
                ""kid"": ""RQ8DuhdxCczyMvy7GNJb4Ka3lQ99vrSo3oFBUiZjzzc"",
                ""kty"": ""RSA"",
                ""use"": ""sig"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/credentials/keys/RQ8DuhdxCczyMvy7GNJb4Ka3lQ99vrSo3oFBUiZjzzc"",
                        ""hints"": {
                            ""allow"": [""GET""]
                        }
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAuthorizationServerKeyAsync(_authServerId, _keyId);

            // Assert
            result.Should().NotBeNull();
            result.Status.Should().Be("ACTIVE");
            result.Alg.Should().Be("RS256");
            result.E.Should().Be("AQAB");
            result.Kid.Should().Be("RQ8DuhdxCczyMvy7GNJb4Ka3lQ99vrSo3oFBUiZjzzc");
            result.Kty.Should().Be("RSA");
            result.Use.Should().Be("sig");
            result.N.Should().NotBeNullOrEmpty();
            result.Links.Should().NotBeNull();

            // Verify request path and parameters
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/credentials/keys/{keyId}");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(_authServerId);
            mockClient.ReceivedPathParams.Should().ContainKey("keyId");
            mockClient.ReceivedPathParams["keyId"].Should().Contain(_keyId);
        }

        [Fact]
        public async Task GetAuthorizationServerKey_WithHttpInfo_ReturnsResponse()
        {
            // Arrange
            var responseJson = @"{
                ""status"": ""NEXT"",
                ""alg"": ""RS256"",
                ""e"": ""AQAB"",
                ""n"": ""next_key_modulus"",
                ""kid"": ""nextKey123"",
                ""kty"": ""RSA"",
                ""use"": ""sig""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAuthorizationServerKeyWithHttpInfoAsync(_authServerId, "nextKey123");

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();
            result.Data.Status.Should().Be("NEXT");
            result.Data.Kid.Should().Be("nextKey123");
        }

        [Fact]
        public async Task GetAuthorizationServerKey_WithExpiredKey_ReturnsExpiredStatus()
        {
            // Arrange
            var responseJson = @"{
                ""status"": ""EXPIRED"",
                ""alg"": ""RS256"",
                ""e"": ""AQAB"",
                ""n"": ""expired_key_modulus"",
                ""kid"": ""expiredKey456"",
                ""kty"": ""RSA"",
                ""use"": ""sig""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAuthorizationServerKeyAsync(_authServerId, "expiredKey456");

            // Assert
            result.Should().NotBeNull();
            result.Status.Should().Be("EXPIRED");
            result.Kid.Should().Be("expiredKey456");
        }

        [Fact]
        public async Task GetAuthorizationServerKey_ValidatesPathParameters()
        {
            // Arrange
            var testAuthServerId = "ausTestServer789";
            var testKeyId = "keyTestId012";
            
            var responseJson = @"{
                ""status"": ""ACTIVE"",
                ""alg"": ""RS256"",
                ""kid"": ""keyTestId012"",
                ""kty"": ""RSA"",
                ""use"": ""sig""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetAuthorizationServerKeyAsync(testAuthServerId, testKeyId);

            // Assert
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(testAuthServerId);
            mockClient.ReceivedPathParams["keyId"].Should().Contain(testKeyId);
        }

        #endregion

        #region RotateAuthorizationServerKeys Tests

        [Fact]
        public async Task RotateAuthorizationServerKeys_ReturnsRotatedKeys()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""status"": ""ACTIVE"",
                    ""alg"": ""RS256"",
                    ""e"": ""AQAB"",
                    ""n"": ""new_active_key_modulus"",
                    ""kid"": ""newActiveKey123"",
                    ""kty"": ""RSA"",
                    ""use"": ""sig""
                },
                {
                    ""status"": ""NEXT"",
                    ""alg"": ""RS256"",
                    ""e"": ""AQAB"",
                    ""n"": ""new_next_key_modulus"",
                    ""kid"": ""newNextKey456"",
                    ""kty"": ""RSA"",
                    ""use"": ""sig""
                },
                {
                    ""status"": ""EXPIRED"",
                    ""alg"": ""RS256"",
                    ""e"": ""AQAB"",
                    ""n"": ""old_active_now_expired_modulus"",
                    ""kid"": ""previousActiveKey789"",
                    ""kty"": ""RSA"",
                    ""use"": ""sig""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            var jwkUse = new JwkUse { Use = JwkUseType.Sig };

            // Act
            var result = await api.RotateAuthorizationServerKeysWithHttpInfoAsync(_authServerId, jwkUse);

            // Assert
            result.Data.Should().NotBeNull();
            result.Data.Should().HaveCount(3);
            
            // After rotation: previous NEXT becomes ACTIVE, new NEXT is generated, previous ACTIVE becomes EXPIRED
            result.Data[0].Status.Should().Be("ACTIVE");
            result.Data[0].Kid.Should().Be("newActiveKey123");
            
            result.Data[1].Status.Should().Be("NEXT");
            result.Data[1].Kid.Should().Be("newNextKey456");
            
            result.Data[2].Status.Should().Be("EXPIRED");
            result.Data[2].Kid.Should().Be("previousActiveKey789");

            // Verify request path
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/credentials/lifecycle/keyRotate");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(_authServerId);
        }

        [Fact]
        public async Task RotateAuthorizationServerKeys_SendsCorrectRequestBody()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""status"": ""ACTIVE"",
                    ""alg"": ""RS256"",
                    ""kid"": ""rotatedKey"",
                    ""kty"": ""RSA"",
                    ""use"": ""sig""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            var jwkUse = new JwkUse { Use = JwkUseType.Sig };

            // Act
            await api.RotateAuthorizationServerKeysWithHttpInfoAsync(_authServerId, jwkUse);

            // Assert
            mockClient.ReceivedBody.Should().Contain("sig");
        }

        [Fact]
        public async Task RotateAuthorizationServerKeys_CollectionMethod_ReturnsCollection()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""status"": ""ACTIVE"",
                    ""alg"": ""RS256"",
                    ""kid"": ""collectionKey"",
                    ""kty"": ""RSA"",
                    ""use"": ""sig""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            var jwkUse = new JwkUse { Use = JwkUseType.Sig };

            // Act
            var collection = api.RotateAuthorizationServerKeys(_authServerId, jwkUse);

            // Assert
            collection.Should().NotBeNull();
        }

        [Fact]
        public async Task RotateAuthorizationServerKeys_FirstRotation_ReturnsTwoKeys()
        {
            // Arrange - First rotation only generates ACTIVE and NEXT (no EXPIRED yet)
            var responseJson = @"[
                {
                    ""status"": ""ACTIVE"",
                    ""alg"": ""RS256"",
                    ""e"": ""AQAB"",
                    ""n"": ""active_modulus"",
                    ""kid"": ""firstActiveKey"",
                    ""kty"": ""RSA"",
                    ""use"": ""sig""
                },
                {
                    ""status"": ""NEXT"",
                    ""alg"": ""RS256"",
                    ""e"": ""AQAB"",
                    ""n"": ""next_modulus"",
                    ""kid"": ""firstNextKey"",
                    ""kty"": ""RSA"",
                    ""use"": ""sig""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            var jwkUse = new JwkUse { Use = JwkUseType.Sig };

            // Act
            var result = await api.RotateAuthorizationServerKeysWithHttpInfoAsync(_authServerId, jwkUse);

            // Assert
            result.Data.Should().HaveCount(2);
            result.Data.Should().Contain(k => k.Status == "ACTIVE");
            result.Data.Should().Contain(k => k.Status == "NEXT");
        }

        #endregion

        #region Error Handling Tests

        [Fact]
        public async Task GetAuthorizationServerKey_WhenKeyNotFound_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: nonExistentKeyId (JsonWebKey)"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""oaeNotFound123"",
                ""errorCauses"": []
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new AuthorizationServerKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.GetAuthorizationServerKeyAsync(_authServerId, "nonExistentKeyId"));

            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task GetAuthorizationServerKey_WhenAuthServerNotFound_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: aus_nonexistent (AuthorizationServer)"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""oaeNotFound456"",
                ""errorCauses"": []
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new AuthorizationServerKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.GetAuthorizationServerKeyAsync("aus_nonexistent", _keyId));

            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task GetAuthorizationServerKey_WhenForbidden_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000006"",
                ""errorSummary"": ""You do not have permission to perform the requested action"",
                ""errorLink"": ""E0000006"",
                ""errorId"": ""oaeForbidden123"",
                ""errorCauses"": []
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.Forbidden);
            var api = new AuthorizationServerKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.GetAuthorizationServerKeyAsync(_authServerId, _keyId));

            exception.ErrorCode.Should().Be(403);
        }

        [Fact]
        public async Task GetAuthorizationServerKey_WhenRateLimited_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000047"",
                ""errorSummary"": ""API call exceeded rate limit due to too many requests."",
                ""errorLink"": ""E0000047"",
                ""errorId"": ""oaeRateLimit123"",
                ""errorCauses"": []
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.TooManyRequests);
            var api = new AuthorizationServerKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.GetAuthorizationServerKeyAsync(_authServerId, _keyId));

            exception.ErrorCode.Should().Be(429);
        }

        #endregion

        #region Edge Cases Tests

        [Fact]
        public async Task GetAuthorizationServerKey_WithMinimalData_ParsesCorrectly()
        {
            // Arrange - Key with minimal required fields
            var responseJson = @"{
                ""status"": ""ACTIVE"",
                ""alg"": ""RS256"",
                ""kid"": ""minimalKey"",
                ""kty"": ""RSA"",
                ""use"": ""sig""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAuthorizationServerKeyAsync(_authServerId, "minimalKey");

            // Assert
            result.Should().NotBeNull();
            result.Status.Should().Be("ACTIVE");
            result.Kid.Should().Be("minimalKey");
            result.E.Should().BeNull();
            result.N.Should().BeNull();
            result.Links.Should().BeNull();
        }

        [Fact]
        public async Task ListAuthorizationServerKeys_WithLongModulusValues_ParsesCorrectly()
        {
            // Arrange - RSA modulus values are typically very long
            var longModulus = new string('A', 500);
            var responseJson = $@"[
                {{
                    ""status"": ""ACTIVE"",
                    ""alg"": ""RS256"",
                    ""e"": ""AQAB"",
                    ""n"": ""{longModulus}"",
                    ""kid"": ""longModulusKey"",
                    ""kty"": ""RSA"",
                    ""use"": ""sig""
                }}
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListAuthorizationServerKeysWithHttpInfoAsync(_authServerId);

            // Assert
            result.Data.Should().HaveCount(1);
            result.Data[0].N.Should().HaveLength(500);
        }

        [Fact]
        public async Task RotateAuthorizationServerKeys_ValidatesJwkUseType()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""status"": ""ACTIVE"",
                    ""alg"": ""RS256"",
                    ""kid"": ""validUseKey"",
                    ""kty"": ""RSA"",
                    ""use"": ""sig""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerKeysApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act - Use the JwkUseType.Sig constant
            var jwkUse = new JwkUse { Use = JwkUseType.Sig };
            await api.RotateAuthorizationServerKeysWithHttpInfoAsync(_authServerId, jwkUse);

            // Assert - The request body should contain "sig"
            mockClient.ReceivedBody.Should().Contain("sig");
        }

        #endregion
    }
}
