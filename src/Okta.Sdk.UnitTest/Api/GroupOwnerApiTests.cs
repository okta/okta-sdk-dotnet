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
    public class GroupOwnerApiTests
    {
        private const string TestGroupId = "00g1ab2c3D4E5F6G7H8I";
        private const string TestOwnerId = "00u1ab2c3D4E5F6G7H8I";
        private const string TestBasePath = "https://test.okta.com";

        #region AssignGroupOwner Tests

        [Fact]
        public async Task AssignGroupOwnerAsync_WithUserOwner_ReturnsGroupOwner()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""00u1ab2c3D4E5F6G7H8I"",
                ""displayName"": ""John Doe"",
                ""type"": ""USER"",
                ""originType"": ""OKTA_DIRECTORY"",
                ""resolved"": true,
                ""lastUpdated"": ""2023-01-15T10:30:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new GroupOwnerApi(mockClient, new Configuration { BasePath = TestBasePath });

            var ownerRequest = new AssignGroupOwnerRequestBody
            {
                Id = TestOwnerId,
                Type = GroupOwnerType.USER
            };

            // Act
            var result = await api.AssignGroupOwnerAsync(TestGroupId, ownerRequest);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(TestOwnerId);
            result.Type.Should().Be(GroupOwnerType.USER);
            result.DisplayName.Should().Be("John Doe");

            mockClient.ReceivedBody.Should().Contain(TestOwnerId);
            mockClient.ReceivedBody.Should().Contain("USER");
        }

        [Fact]
        public async Task AssignGroupOwnerAsync_WithGroupOwner_ReturnsGroupOwner()
        {
            // Arrange
            var groupOwnerId = "00g9ab8c7D6E5F4G3H2I";
            var responseJson = $@"{{
                ""id"": ""{groupOwnerId}"",
                ""displayName"": ""Engineering Team"",
                ""type"": ""GROUP"",
                ""originType"": ""OKTA_DIRECTORY"",
                ""resolved"": true,
                ""lastUpdated"": ""2023-02-10T14:20:00.000Z""
            }}";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new GroupOwnerApi(mockClient, new Configuration { BasePath = TestBasePath });

            var ownerRequest = new AssignGroupOwnerRequestBody
            {
                Id = groupOwnerId,
                Type = GroupOwnerType.GROUP
            };

            // Act
            var result = await api.AssignGroupOwnerAsync(TestGroupId, ownerRequest);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(groupOwnerId);
            result.Type.Should().Be(GroupOwnerType.GROUP);

            mockClient.ReceivedBody.Should().Contain(groupOwnerId);
            mockClient.ReceivedBody.Should().Contain("GROUP");
        }

        [Fact]
        public async Task AssignGroupOwnerWithHttpInfoAsync_ReturnsHttpInfo()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""00u1ab2c3D4E5F6G7H8I"",
                ""displayName"": ""Test User"",
                ""type"": ""USER"",
                ""originType"": ""OKTA_DIRECTORY"",
                ""resolved"": true
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new GroupOwnerApi(mockClient, new Configuration { BasePath = TestBasePath });

            var ownerRequest = new AssignGroupOwnerRequestBody
            {
                Id = TestOwnerId,
                Type = GroupOwnerType.USER
            };

            // Act
            var response = await api.AssignGroupOwnerWithHttpInfoAsync(TestGroupId, ownerRequest);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(TestOwnerId);
        }

        #endregion

        #region ListGroupOwners Tests

        [Fact]
        public async Task ListGroupOwnersWithHttpInfoAsync_WithNoParameters_ReturnsOwnersList()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""00u1ab2c3D4E5F6G7H8I"",
                    ""displayName"": ""Owner One"",
                    ""type"": ""USER"",
                    ""originType"": ""OKTA_DIRECTORY"",
                    ""resolved"": true
                },
                {
                    ""id"": ""00u2cd3e4F5G6H7I8J9K"",
                    ""displayName"": ""Owner Two"",
                    ""type"": ""USER"",
                    ""originType"": ""OKTA_DIRECTORY"",
                    ""resolved"": true
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupOwnerApi(mockClient, new Configuration { BasePath = TestBasePath });

            // Act
            var response = await api.ListGroupOwnersWithHttpInfoAsync(TestGroupId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().HaveCount(2);
            response.Data[0].Id.Should().Be("00u1ab2c3D4E5F6G7H8I");
            response.Data[1].Id.Should().Be("00u2cd3e4F5G6H7I8J9K");
        }

        [Fact]
        public async Task ListGroupOwnersWithHttpInfoAsync_WithSearchFilter_IncludesFilter()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""00u1ab2c3D4E5F6G7H8I"",
                    ""displayName"": ""John Doe"",
                    ""type"": ""USER"",
                    ""originType"": ""OKTA_DIRECTORY"",
                    ""resolved"": true
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupOwnerApi(mockClient, new Configuration { BasePath = TestBasePath });

            var search = "type eq \"USER\"";

            // Act
            var response = await api.ListGroupOwnersWithHttpInfoAsync(TestGroupId, search: search);

            // Assert
            response.Data.Should().HaveCount(1);
            mockClient.ReceivedQueryParams.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().ContainKey("search");
        }

        [Fact]
        public async Task ListGroupOwnersWithHttpInfoAsync_WithPagination_IncludesParameters()
        {
            // Arrange
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupOwnerApi(mockClient, new Configuration { BasePath = TestBasePath });

            var after = "cursor123";
            var limit = 50;

            // Act
            await api.ListGroupOwnersWithHttpInfoAsync(TestGroupId, after: after, limit: limit);

            // Assert
            mockClient.ReceivedQueryParams.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
        }

        [Fact]
        public async Task ListGroupOwnersWithHttpInfoAsync_EmptyResult_ReturnsEmptyList()
        {
            // Arrange
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupOwnerApi(mockClient, new Configuration { BasePath = TestBasePath });

            // Act
            var response = await api.ListGroupOwnersWithHttpInfoAsync(TestGroupId);

            // Assert
            response.Data.Should().NotBeNull();
            response.Data.Should().BeEmpty();
        }

        #endregion

        #region DeleteGroupOwner Tests

        [Fact]
        public async Task DeleteGroupOwnerAsync_WithValidIds_CompletesSuccessfully()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new GroupOwnerApi(mockClient, new Configuration { BasePath = TestBasePath });

            // Act & Assert - Should complete without throwing
            await api.DeleteGroupOwnerAsync(TestGroupId, TestOwnerId);
        }

        [Fact]
        public async Task DeleteGroupOwnerWithHttpInfoAsync_ReturnsHttpInfo()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new GroupOwnerApi(mockClient, new Configuration { BasePath = TestBasePath });

            // Act
            var response = await api.DeleteGroupOwnerWithHttpInfoAsync(TestGroupId, TestOwnerId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        #endregion

        #region Error Handling Tests

        [Fact]
        public async Task AssignGroupOwnerAsync_WithInvalidGroupId_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: 00invalid (Group)""
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new GroupOwnerApi(mockClient, new Configuration { BasePath = TestBasePath });

            var ownerRequest = new AssignGroupOwnerRequestBody
            {
                Id = TestOwnerId,
                Type = GroupOwnerType.USER
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                async () => await api.AssignGroupOwnerAsync("00invalid", ownerRequest));

            exception.ErrorCode.Should().Be((int)HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task AssignGroupOwnerAsync_WithDuplicateOwner_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed: Owner already exists""
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.BadRequest);
            var api = new GroupOwnerApi(mockClient, new Configuration { BasePath = TestBasePath });

            var ownerRequest = new AssignGroupOwnerRequestBody
            {
                Id = TestOwnerId,
                Type = GroupOwnerType.USER
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                async () => await api.AssignGroupOwnerAsync(TestGroupId, ownerRequest));

            exception.ErrorCode.Should().Be((int)HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task DeleteGroupOwnerAsync_WithInvalidOwner_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: 00u-nonexist (GroupOwner)""
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new GroupOwnerApi(mockClient, new Configuration { BasePath = TestBasePath });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                async () => await api.DeleteGroupOwnerAsync(TestGroupId, "00u-nonexist"));

            exception.ErrorCode.Should().Be((int)HttpStatusCode.NotFound);
        }

        #endregion
    }
}
