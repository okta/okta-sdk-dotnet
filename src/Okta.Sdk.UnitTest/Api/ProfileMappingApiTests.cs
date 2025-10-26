using System.Collections.Generic;
using System.Linq;
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
    ///  Class for testing ProfileMappingApi
    /// </summary>
    public class ProfileMappingApiTests
    {
        #region GetProfileMapping Tests

        [Fact]
        public async Task GetProfileMapping_WithValidMappingId_CallsCorrectEndpoint()
        {
            // Arrange
            var mappingId = "test-mapping-123";
            var responseJson = @"{
                ""id"": """ + mappingId + @""",
                ""source"": {
                    ""id"": ""source-123"",
                    ""name"": ""Source App"",
                    ""type"": ""application""
                },
                ""target"": {
                    ""id"": ""target-456"",
                    ""name"": ""Target App"",
                    ""type"": ""user""
                },
                ""properties"": {
                    ""firstName"": {
                        ""expression"": ""appuser.firstName"",
                        ""pushStatus"": ""DONT_PUSH""
                    },
                    ""lastName"": {
                        ""expression"": ""appuser.lastName"",
                        ""pushStatus"": ""DONT_PUSH""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            // Act
            var result = await profileMappingApi.GetProfileMappingAsync(mappingId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(mappingId);
            result.Source.Should().NotBeNull();
            result.Target.Should().NotBeNull();
            result.Properties.Should().NotBeNull();

            mockClient.ReceivedPath.Should().Be("/api/v1/mappings/{mappingId}");
            mockClient.ReceivedPathParams.Should().ContainKey("mappingId");
            mockClient.ReceivedPathParams["mappingId"].Should().Contain(mappingId);
        }

        [Fact]
        public async Task GetProfileMapping_WithHttpInfo_ReturnsCorrectResponse()
        {
            // Arrange
            var mappingId = "test-mapping-http-123";
            var responseJson = @"{
                ""id"": """ + mappingId + @""",
                ""source"": {
                    ""id"": ""source-http-123"",
                    ""name"": ""HTTP Source App"",
                    ""type"": ""application""
                },
                ""target"": {
                    ""id"": ""target-http-456"",
                    ""name"": ""HTTP Target App"",
                    ""type"": ""user""
                },
                ""properties"": {}
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            // Act
            var response = await profileMappingApi.GetProfileMappingWithHttpInfoAsync(mappingId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(mappingId);
            response.Data.Source.Name.Should().Be("HTTP Source App");
            response.Data.Target.Name.Should().Be("HTTP Target App");

            mockClient.ReceivedPath.Should().Be("/api/v1/mappings/{mappingId}");
            mockClient.ReceivedPathParams.Should().ContainKey("mappingId");
            mockClient.ReceivedPathParams["mappingId"].Should().Contain(mappingId);
        }

        [Fact]
        public async Task GetProfileMapping_ValidatesRequiredMappingId()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.BadRequest);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(
                () => profileMappingApi.GetProfileMappingAsync(null));
        }

        [Fact]
        public async Task GetProfileMapping_WithComplexMappingId_CallsCorrectEndpoint()
        {
            // Arrange
            var mappingId = "mapping-complex_123-test.mapping";
            var responseJson = @"{
                ""id"": """ + mappingId + @""",
                ""source"": {
                    ""id"": ""complex-source"",
                    ""name"": ""Complex Source"",
                    ""type"": ""application""
                },
                ""target"": {
                    ""id"": ""complex-target"",
                    ""name"": ""Complex Target"",
                    ""type"": ""user""
                },
                ""properties"": {}
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            // Act
            var result = await profileMappingApi.GetProfileMappingAsync(mappingId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(mappingId);

            mockClient.ReceivedPath.Should().Be("/api/v1/mappings/{mappingId}");
            mockClient.ReceivedPathParams.Should().ContainKey("mappingId");
            mockClient.ReceivedPathParams["mappingId"].Should().Contain(mappingId);
        }

        #endregion

        #region ListProfileMappings Tests

        [Fact]
        public async Task ListProfileMappings_WithoutParameters_CallsCorrectEndpoint()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""mapping-list-1"",
                    ""source"": {
                        ""id"": ""source-1"",
                        ""name"": ""Source 1"",
                        ""type"": ""application""
                    },
                    ""target"": {
                        ""id"": ""target-1"",
                        ""name"": ""Target 1"",
                        ""type"": ""user""
                    }
                },
                {
                    ""id"": ""mapping-list-2"",
                    ""source"": {
                        ""id"": ""source-2"",
                        ""name"": ""Source 2"",
                        ""type"": ""application""
                    },
                    ""target"": {
                        ""id"": ""target-2"",
                        ""name"": ""Target 2"",
                        ""type"": ""user""
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            // Act
            var response = await profileMappingApi.ListProfileMappingsWithHttpInfoAsync();

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().HaveCount(2);

            mockClient.ReceivedPath.Should().Be("/api/v1/mappings");
        }

        [Fact]
        public async Task ListProfileMappings_WithSourceId_CallsCorrectEndpoint()
        {
            // Arrange
            var sourceId = "source-filter-123";
            var responseJson = @"[
                {
                    ""id"": ""mapping-source-1"",
                    ""source"": {
                        ""id"": """ + sourceId + @""",
                        ""name"": ""Filtered Source"",
                        ""type"": ""application""
                    },
                    ""target"": {
                        ""id"": ""target-source-1"",
                        ""name"": ""Target 1"",
                        ""type"": ""user""
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            // Act
            var response = await profileMappingApi.ListProfileMappingsWithHttpInfoAsync(sourceId: sourceId);

            // Assert
            response.Should().NotBeNull();
            response.Data.Should().HaveCount(1);
            response.Data[0].Source.Id.Should().Be(sourceId);

            mockClient.ReceivedPath.Should().Be("/api/v1/mappings");
            mockClient.ReceivedQueryParams.Should().ContainKey("sourceId");
            mockClient.ReceivedQueryParams["sourceId"].Should().Contain(sourceId);
        }

        [Fact]
        public async Task ListProfileMappings_WithTargetId_CallsCorrectEndpoint()
        {
            // Arrange
            var targetId = "target-filter-456";
            var responseJson = @"[
                {
                    ""id"": ""mapping-target-1"",
                    ""source"": {
                        ""id"": ""source-target-1"",
                        ""name"": ""Source 1"",
                        ""type"": ""application""
                    },
                    ""target"": {
                        ""id"": """ + targetId + @""",
                        ""name"": ""Filtered Target"",
                        ""type"": ""user""
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            // Act
            var response = await profileMappingApi.ListProfileMappingsWithHttpInfoAsync(targetId: targetId);

            // Assert
            response.Should().NotBeNull();
            response.Data.Should().HaveCount(1);
            response.Data[0].Target.Id.Should().Be(targetId);

            mockClient.ReceivedPath.Should().Be("/api/v1/mappings");
            mockClient.ReceivedQueryParams.Should().ContainKey("targetId");
            mockClient.ReceivedQueryParams["targetId"].Should().Contain(targetId);
        }

        [Fact]
        public async Task ListProfileMappings_WithLimitParameter_CallsCorrectEndpoint()
        {
            // Arrange
            var limit = 5;
            var responseJson = @"[
                {
                    ""id"": ""mapping-limit-1"",
                    ""source"": {
                        ""id"": ""source-limit-1"",
                        ""name"": ""Source 1"",
                        ""type"": ""application""
                    },
                    ""target"": {
                        ""id"": ""target-limit-1"",
                        ""name"": ""Target 1"",
                        ""type"": ""user""
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            // Act
            var response = await profileMappingApi.ListProfileMappingsWithHttpInfoAsync(limit: limit);

            // Assert
            response.Should().NotBeNull();
            response.Data.Should().HaveCount(1);

            mockClient.ReceivedPath.Should().Be("/api/v1/mappings");
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain("5");
        }

        [Fact]
        public async Task ListProfileMappings_WithAfterParameter_CallsCorrectEndpoint()
        {
            // Arrange
            var after = "mapping-after-123";
            var responseJson = @"[
                {
                    ""id"": ""mapping-after-1"",
                    ""source"": {
                        ""id"": ""source-after-1"",
                        ""name"": ""Source After"",
                        ""type"": ""application""
                    },
                    ""target"": {
                        ""id"": ""target-after-1"",
                        ""name"": ""Target After"",
                        ""type"": ""user""
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            // Act
            var response = await profileMappingApi.ListProfileMappingsWithHttpInfoAsync(after: after);

            // Assert
            response.Should().NotBeNull();
            response.Data.Should().HaveCount(1);

            mockClient.ReceivedPath.Should().Be("/api/v1/mappings");
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain(after);
        }

        [Fact]
        public async Task ListProfileMappings_WithAllParameters_CallsCorrectEndpoint()
        {
            // Arrange
            var after = "mapping-all-123";
            var limit = 10;
            var sourceId = "source-all-456";
            var targetId = "target-all-789";
            var responseJson = @"[
                {
                    ""id"": ""mapping-all-1"",
                    ""source"": {
                        ""id"": """ + sourceId + @""",
                        ""name"": ""All Source"",
                        ""type"": ""application""
                    },
                    ""target"": {
                        ""id"": """ + targetId + @""",
                        ""name"": ""All Target"",
                        ""type"": ""user""
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            // Act
            var response = await profileMappingApi.ListProfileMappingsWithHttpInfoAsync(after, limit, sourceId, targetId);

            // Assert
            response.Should().NotBeNull();
            response.Data.Should().HaveCount(1);
            response.Data[0].Source.Id.Should().Be(sourceId);
            response.Data[0].Target.Id.Should().Be(targetId);

            mockClient.ReceivedPath.Should().Be("/api/v1/mappings");
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain(after);
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain("10");
            mockClient.ReceivedQueryParams.Should().ContainKey("sourceId");
            mockClient.ReceivedQueryParams["sourceId"].Should().Contain(sourceId);
            mockClient.ReceivedQueryParams.Should().ContainKey("targetId");
            mockClient.ReceivedQueryParams["targetId"].Should().Contain(targetId);
        }

        [Fact]
        public async Task ListProfileMappings_ReturnsEmptyList_WhenNoMappings()
        {
            // Arrange
            var responseJson = @"[]";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            // Act
            var response = await profileMappingApi.ListProfileMappingsWithHttpInfoAsync();

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().BeEmpty();

            mockClient.ReceivedPath.Should().Be("/api/v1/mappings");
        }

        [Fact]
        public void ListProfileMappings_SynchronousCollection_CallsCorrectEndpoint()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""mapping-sync-1"",
                    ""source"": {
                        ""id"": ""source-sync-1"",
                        ""name"": ""Sync Source"",
                        ""type"": ""application""
                    },
                    ""target"": {
                        ""id"": ""target-sync-1"",
                        ""name"": ""Sync Target"",
                        ""type"": ""user""
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            // Act
            var result = profileMappingApi.ListProfileMappings();

            // Assert
            result.Should().NotBeNull();
        }

        #endregion

        #region UpdateProfileMapping Tests

        [Fact]
        public async Task UpdateProfileMapping_WithValidRequest_CallsCorrectEndpoint()
        {
            // Arrange
            var mappingId = "test-mapping-update-123";
            var responseJson = @"{
                ""id"": """ + mappingId + @""",
                ""source"": {
                    ""id"": ""source-update-123"",
                    ""name"": ""Updated Source"",
                    ""type"": ""application""
                },
                ""target"": {
                    ""id"": ""target-update-456"",
                    ""name"": ""Updated Target"",
                    ""type"": ""user""
                },
                ""properties"": {
                    ""firstName"": {
                        ""expression"": ""appuser.firstName"",
                        ""pushStatus"": ""PUSH""
                    },
                    ""lastName"": {
                        ""expression"": ""appuser.lastName"",
                        ""pushStatus"": ""PUSH""
                    },
                    ""email"": {
                        ""expression"": ""appuser.email"",
                        ""pushStatus"": ""DONT_PUSH""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            var updateRequest = new ProfileMappingRequest();

            // Act
            var result = await profileMappingApi.UpdateProfileMappingAsync(mappingId, updateRequest);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(mappingId);
            result.Source.Name.Should().Be("Updated Source");
            result.Target.Name.Should().Be("Updated Target");
            result.Properties.Should().NotBeNull();

            mockClient.ReceivedPath.Should().Be("/api/v1/mappings/{mappingId}");
            mockClient.ReceivedPathParams.Should().ContainKey("mappingId");
            mockClient.ReceivedPathParams["mappingId"].Should().Contain(mappingId);
            mockClient.ReceivedBody.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task UpdateProfileMapping_WithHttpInfo_ReturnsCorrectResponse()
        {
            // Arrange
            var mappingId = "test-mapping-update-http-123";
            var responseJson = @"{
                ""id"": """ + mappingId + @""",
                ""source"": {
                    ""id"": ""source-http-update-123"",
                    ""name"": ""HTTP Updated Source"",
                    ""type"": ""application""
                },
                ""target"": {
                    ""id"": ""target-http-update-456"",
                    ""name"": ""HTTP Updated Target"",
                    ""type"": ""user""
                },
                ""properties"": {}
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            var updateRequest = new ProfileMappingRequest();

            // Act
            var response = await profileMappingApi.UpdateProfileMappingWithHttpInfoAsync(mappingId, updateRequest);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(mappingId);
            response.Data.Source.Name.Should().Be("HTTP Updated Source");
            response.Data.Target.Name.Should().Be("HTTP Updated Target");

            mockClient.ReceivedPath.Should().Be("/api/v1/mappings/{mappingId}");
            mockClient.ReceivedPathParams.Should().ContainKey("mappingId");
            mockClient.ReceivedPathParams["mappingId"].Should().Contain(mappingId);
            mockClient.ReceivedBody.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task UpdateProfileMapping_ValidatesRequiredMappingId()
        {
            // Arrange
            var updateRequest = new ProfileMappingRequest();
            var mockClient = new MockAsyncClient("", HttpStatusCode.BadRequest);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(
                () => profileMappingApi.UpdateProfileMappingAsync(null, updateRequest));
        }

        [Fact]
        public async Task UpdateProfileMapping_ValidatesRequiredProfileMappingRequest()
        {
            // Arrange
            var mappingId = "test-mapping-no-request-123";
            var mockClient = new MockAsyncClient("", HttpStatusCode.BadRequest);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(
                () => profileMappingApi.UpdateProfileMappingAsync(mappingId, null));
        }

        [Fact]
        public async Task UpdateProfileMapping_WithComplexMappingId_CallsCorrectEndpoint()
        {
            // Arrange
            var mappingId = "mapping-complex-update_123-test.mapping";
            var responseJson = @"{
                ""id"": """ + mappingId + @""",
                ""source"": {
                    ""id"": ""complex-update-source"",
                    ""name"": ""Complex Update Source"",
                    ""type"": ""application""
                },
                ""target"": {
                    ""id"": ""complex-update-target"",
                    ""name"": ""Complex Update Target"",
                    ""type"": ""user""
                },
                ""properties"": {}
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            var updateRequest = new ProfileMappingRequest();

            // Act
            var result = await profileMappingApi.UpdateProfileMappingAsync(mappingId, updateRequest);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(mappingId);

            mockClient.ReceivedPath.Should().Be("/api/v1/mappings/{mappingId}");
            mockClient.ReceivedPathParams.Should().ContainKey("mappingId");
            mockClient.ReceivedPathParams["mappingId"].Should().Contain(mappingId);
        }

        #endregion

        #region Edge Case Tests

        [Fact]
        public async Task GetProfileMapping_WithSpecialCharactersInMappingId_CallsCorrectEndpoint()
        {
            // Arrange
            var mappingId = "mapping-with-special.chars_123@domain.com";
            var responseJson = @"{
                ""id"": """ + mappingId + @""",
                ""source"": {
                    ""id"": ""special-source"",
                    ""name"": ""Special Source"",
                    ""type"": ""application""
                },
                ""target"": {
                    ""id"": ""special-target"",
                    ""name"": ""Special Target"",
                    ""type"": ""user""
                },
                ""properties"": {}
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            // Act
            var result = await profileMappingApi.GetProfileMappingAsync(mappingId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(mappingId);

            mockClient.ReceivedPath.Should().Be("/api/v1/mappings/{mappingId}");
            mockClient.ReceivedPathParams.Should().ContainKey("mappingId");
            mockClient.ReceivedPathParams["mappingId"].Should().Contain(mappingId);
        }

        [Fact]
        public async Task ListProfileMappings_WithSpecialCharactersInSourceId_CallsCorrectEndpoint()
        {
            // Arrange
            var sourceId = "source@special-chars.domain_123";
            var responseJson = @"[
                {
                    ""id"": ""mapping-special-source-1"",
                    ""source"": {
                        ""id"": """ + sourceId + @""",
                        ""name"": ""Special Chars Source"",
                        ""type"": ""application""
                    },
                    ""target"": {
                        ""id"": ""target-special-1"",
                        ""name"": ""Target 1"",
                        ""type"": ""user""
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            // Act
            var response = await profileMappingApi.ListProfileMappingsWithHttpInfoAsync(sourceId: sourceId);

            // Assert
            response.Should().NotBeNull();
            response.Data.Should().HaveCount(1);
            response.Data[0].Source.Id.Should().Be(sourceId);

            mockClient.ReceivedPath.Should().Be("/api/v1/mappings");
            mockClient.ReceivedQueryParams.Should().ContainKey("sourceId");
            mockClient.ReceivedQueryParams["sourceId"].Should().Contain(sourceId);
        }

        #endregion

        #region HTTP Status Code Tests

        [Fact]
        public async Task GetProfileMapping_WithNotFoundStatus_ThrowsApiException()
        {
            // Arrange
            var mappingId = "non-existent-mapping";
            var mockClient = new MockAsyncClient("", HttpStatusCode.NotFound);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => profileMappingApi.GetProfileMappingWithHttpInfoAsync(mappingId));

            // Verify the call was made to the correct endpoint
            mockClient.ReceivedPath.Should().Be("/api/v1/mappings/{mappingId}");
            exception.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateProfileMapping_WithBadRequestStatus_ThrowsApiException()
        {
            // Arrange
            var mappingId = "test-mapping-bad-request";
            var updateRequest = new ProfileMappingRequest();
            var mockClient = new MockAsyncClient("", HttpStatusCode.BadRequest);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => profileMappingApi.UpdateProfileMappingWithHttpInfoAsync(mappingId, updateRequest));

            // Verify the call was made to the correct endpoint
            mockClient.ReceivedPath.Should().Be("/api/v1/mappings/{mappingId}");
            exception.Should().NotBeNull();
        }

        [Fact]
        public async Task ListProfileMappings_WithOkStatus_ReturnsCorrectResponse()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""mapping-ok-1"",
                    ""source"": {
                        ""id"": ""source-ok-1"",
                        ""name"": ""OK Source"",
                        ""type"": ""application""
                    },
                    ""target"": {
                        ""id"": ""target-ok-1"",
                        ""name"": ""OK Target"",
                        ""type"": ""user""
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            // Act
            var response = await profileMappingApi.ListProfileMappingsWithHttpInfoAsync();

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().HaveCount(1);
        }

        #endregion

        #region Properties Dictionary Tests

        [Fact]
        public async Task GetProfileMapping_DeserializesPropertiesAsDictionary()
        {
            // Arrange
            var mappingId = "test-mapping-dictionary-123";
            var responseJson = @"{
                ""id"": """ + mappingId + @""",
                ""source"": {
                    ""id"": ""source-dict-123"",
                    ""name"": ""Dictionary Source"",
                    ""type"": ""application""
                },
                ""target"": {
                    ""id"": ""target-dict-456"",
                    ""name"": ""Dictionary Target"",
                    ""type"": ""user""
                },
                ""properties"": {
                    ""firstName"": {
                        ""expression"": ""appuser.firstName"",
                        ""pushStatus"": ""PUSH""
                    },
                    ""lastName"": {
                        ""expression"": ""appuser.lastName"",
                        ""pushStatus"": ""DONT_PUSH""
                    },
                    ""email"": {
                        ""expression"": ""appuser.email"",
                        ""pushStatus"": ""PUSH""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            // Act
            var result = await profileMappingApi.GetProfileMappingAsync(mappingId);

            // Assert
            result.Should().NotBeNull();
            result.Properties.Should().NotBeNull();
            result.Properties.Should().BeOfType<Dictionary<string, ProfileMappingProperty>>();
            result.Properties.Should().HaveCount(3);
            
            // Verify dictionary keys
            result.Properties.Should().ContainKey("firstName");
            result.Properties.Should().ContainKey("lastName");
            result.Properties.Should().ContainKey("email");
            
            // Verify dictionary values
            result.Properties["firstName"].Expression.Should().Be("appuser.firstName");
            result.Properties["firstName"].PushStatus.Should().Be(ProfileMappingPropertyPushStatus.PUSH);
            
            result.Properties["lastName"].Expression.Should().Be("appuser.lastName");
            result.Properties["lastName"].PushStatus.Should().Be(ProfileMappingPropertyPushStatus.DONTPUSH);
            
            result.Properties["email"].Expression.Should().Be("appuser.email");
            result.Properties["email"].PushStatus.Should().Be(ProfileMappingPropertyPushStatus.PUSH);
        }

        [Fact]
        public async Task GetProfileMapping_HandlesEmptyPropertiesDictionary()
        {
            // Arrange
            var mappingId = "test-mapping-empty-dict";
            var responseJson = @"{
                ""id"": """ + mappingId + @""",
                ""source"": {
                    ""id"": ""source-empty"",
                    ""name"": ""Empty Source"",
                    ""type"": ""application""
                },
                ""target"": {
                    ""id"": ""target-empty"",
                    ""name"": ""Empty Target"",
                    ""type"": ""user""
                },
                ""properties"": {}
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            // Act
            var result = await profileMappingApi.GetProfileMappingAsync(mappingId);

            // Assert
            result.Should().NotBeNull();
            result.Properties.Should().NotBeNull();
            result.Properties.Should().BeOfType<Dictionary<string, ProfileMappingProperty>>();
            result.Properties.Should().BeEmpty();
        }

        [Fact]
        public async Task UpdateProfileMapping_SerializesPropertiesDictionaryCorrectly()
        {
            // Arrange
            var mappingId = "test-mapping-serialize-dict";
            var responseJson = @"{
                ""id"": """ + mappingId + @""",
                ""source"": {
                    ""id"": ""source-serialize"",
                    ""name"": ""Serialize Source"",
                    ""type"": ""application""
                },
                ""target"": {
                    ""id"": ""target-serialize"",
                    ""name"": ""Serialize Target"",
                    ""type"": ""user""
                },
                ""properties"": {
                    ""customField1"": {
                        ""expression"": ""appuser.custom1"",
                        ""pushStatus"": ""PUSH""
                    },
                    ""customField2"": {
                        ""expression"": ""appuser.custom2"",
                        ""pushStatus"": ""DONT_PUSH""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            var updateRequest = new ProfileMappingRequest
            {
                Properties = new Dictionary<string, ProfileMappingProperty>
                {
                    ["customField1"] = new ProfileMappingProperty
                    {
                        Expression = "appuser.custom1",
                        PushStatus = ProfileMappingPropertyPushStatus.PUSH
                    },
                    ["customField2"] = new ProfileMappingProperty
                    {
                        Expression = "appuser.custom2",
                        PushStatus = ProfileMappingPropertyPushStatus.DONTPUSH
                    }
                }
            };

            // Act
            var result = await profileMappingApi.UpdateProfileMappingAsync(mappingId, updateRequest);

            // Assert
            result.Should().NotBeNull();
            result.Properties.Should().NotBeNull();
            result.Properties.Should().HaveCount(2);
            result.Properties.Should().ContainKey("customField1");
            result.Properties.Should().ContainKey("customField2");
            
            mockClient.ReceivedBody.Should().NotBeNullOrEmpty();
            mockClient.ReceivedBody.Should().Contain("customField1");
            mockClient.ReceivedBody.Should().Contain("customField2");
            mockClient.ReceivedBody.Should().Contain("appuser.custom1");
            mockClient.ReceivedBody.Should().Contain("appuser.custom2");
        }

        [Fact]
        public async Task UpdateProfileMapping_WithEmptyPropertiesDictionary_SerializesCorrectly()
        {
            // Arrange
            var mappingId = "test-mapping-empty-update";
            var responseJson = @"{
                ""id"": """ + mappingId + @""",
                ""source"": {
                    ""id"": ""source-empty-update"",
                    ""name"": ""Empty Update Source"",
                    ""type"": ""application""
                },
                ""target"": {
                    ""id"": ""target-empty-update"",
                    ""name"": ""Empty Update Target"",
                    ""type"": ""user""
                },
                ""properties"": {}
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            var updateRequest = new ProfileMappingRequest
            {
                Properties = new Dictionary<string, ProfileMappingProperty>()
            };

            // Act
            var result = await profileMappingApi.UpdateProfileMappingAsync(mappingId, updateRequest);

            // Assert
            result.Should().NotBeNull();
            result.Properties.Should().NotBeNull();
            result.Properties.Should().BeEmpty();
            
            mockClient.ReceivedBody.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task UpdateProfileMapping_WithMultipleProperties_MaintainsAllProperties()
        {
            // Arrange
            var mappingId = "test-mapping-multiple-props";
            var responseJson = @"{
                ""id"": """ + mappingId + @""",
                ""source"": {
                    ""id"": ""source-multi"",
                    ""name"": ""Multi Source"",
                    ""type"": ""application""
                },
                ""target"": {
                    ""id"": ""target-multi"",
                    ""name"": ""Multi Target"",
                    ""type"": ""user""
                },
                ""properties"": {
                    ""field1"": {
                        ""expression"": ""expr1"",
                        ""pushStatus"": ""PUSH""
                    },
                    ""field2"": {
                        ""expression"": ""expr2"",
                        ""pushStatus"": ""DONT_PUSH""
                    },
                    ""field3"": {
                        ""expression"": ""expr3"",
                        ""pushStatus"": ""PUSH""
                    },
                    ""field4"": {
                        ""expression"": ""expr4"",
                        ""pushStatus"": ""DONT_PUSH""
                    },
                    ""field5"": {
                        ""expression"": ""expr5"",
                        ""pushStatus"": ""PUSH""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            var updateRequest = new ProfileMappingRequest
            {
                Properties = new Dictionary<string, ProfileMappingProperty>
                {
                    ["field1"] = new ProfileMappingProperty { Expression = "expr1", PushStatus = ProfileMappingPropertyPushStatus.PUSH },
                    ["field2"] = new ProfileMappingProperty { Expression = "expr2", PushStatus = ProfileMappingPropertyPushStatus.DONTPUSH },
                    ["field3"] = new ProfileMappingProperty { Expression = "expr3", PushStatus = ProfileMappingPropertyPushStatus.PUSH },
                    ["field4"] = new ProfileMappingProperty { Expression = "expr4", PushStatus = ProfileMappingPropertyPushStatus.DONTPUSH },
                    ["field5"] = new ProfileMappingProperty { Expression = "expr5", PushStatus = ProfileMappingPropertyPushStatus.PUSH }
                }
            };

            // Act
            var result = await profileMappingApi.UpdateProfileMappingAsync(mappingId, updateRequest);

            // Assert
            result.Should().NotBeNull();
            result.Properties.Should().HaveCount(5);
            result.Properties.Keys.Should().Contain(new[] { "field1", "field2", "field3", "field4", "field5" });
            
            // Verify all properties are correctly deserialized
            for (int i = 1; i <= 5; i++)
            {
                var key = $"field{i}";
                result.Properties.Should().ContainKey(key);
                result.Properties[key].Expression.Should().Be($"expr{i}");
            }
        }

        [Fact]
        public async Task GetProfileMapping_WithComplexExpressions_DeserializesCorrectly()
        {
            // Arrange
            var mappingId = "test-mapping-complex-expr";
            var responseJson = @"{
                ""id"": """ + mappingId + @""",
                ""source"": {
                    ""id"": ""source-complex"",
                    ""name"": ""Complex Source"",
                    ""type"": ""application""
                },
                ""target"": {
                    ""id"": ""target-complex"",
                    ""name"": ""Complex Target"",
                    ""type"": ""user""
                },
                ""properties"": {
                    ""fullName"": {
                        ""expression"": ""appuser.firstName + ' ' + appuser.lastName"",
                        ""pushStatus"": ""PUSH""
                    },
                    ""email"": {
                        ""expression"": ""String.toLowerCase(appuser.email)"",
                        ""pushStatus"": ""PUSH""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            // Act
            var result = await profileMappingApi.GetProfileMappingAsync(mappingId);

            // Assert
            result.Should().NotBeNull();
            result.Properties.Should().HaveCount(2);
            result.Properties["fullName"].Expression.Should().Contain("appuser.firstName");
            result.Properties["email"].Expression.Should().Contain("String.toLowerCase");
        }

        [Fact]
        public async Task UpdateProfileMapping_CanModifyExistingPropertiesDictionary()
        {
            // Arrange
            var mappingId = "test-mapping-modify-dict";
            var responseJson = @"{
                ""id"": """ + mappingId + @""",
                ""source"": {
                    ""id"": ""source-modify"",
                    ""name"": ""Modify Source"",
                    ""type"": ""application""
                },
                ""target"": {
                    ""id"": ""target-modify"",
                    ""name"": ""Modify Target"",
                    ""type"": ""user""
                },
                ""properties"": {
                    ""firstName"": {
                        ""expression"": ""appuser.givenName"",
                        ""pushStatus"": ""PUSH""
                    },
                    ""lastName"": {
                        ""expression"": ""appuser.familyName"",
                        ""pushStatus"": ""PUSH""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var profileMappingApi = new ProfileMappingApi(mockClient, new Configuration { BasePath = "https://test.okta.com" });

            // Create initial dictionary
            var properties = new Dictionary<string, ProfileMappingProperty>
            {
                ["firstName"] = new ProfileMappingProperty { Expression = "appuser.firstName", PushStatus = ProfileMappingPropertyPushStatus.PUSH }
            };

            // Modify dictionary - add property
            properties["lastName"] = new ProfileMappingProperty { Expression = "appuser.lastName", PushStatus = ProfileMappingPropertyPushStatus.PUSH };

            // Modify dictionary - update property
            properties["firstName"] = new ProfileMappingProperty { Expression = "appuser.givenName", PushStatus = ProfileMappingPropertyPushStatus.PUSH };

            var updateRequest = new ProfileMappingRequest
            {
                Properties = properties
            };

            // Act
            var result = await profileMappingApi.UpdateProfileMappingAsync(mappingId, updateRequest);

            // Assert
            result.Should().NotBeNull();
            result.Properties.Should().HaveCount(2);
            result.Properties["firstName"].Expression.Should().Be("appuser.givenName");
            result.Properties["lastName"].Expression.Should().Be("appuser.familyName");
        }

        #endregion
    }
}
