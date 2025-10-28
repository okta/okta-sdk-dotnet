using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Xunit;

namespace Okta.Sdk.UnitTest.Api
{
    public class SchemaApiTests
    {
        private Mock<IAsynchronousClient> CreateMockAsyncClient()
        {
            return new Mock<IAsynchronousClient>();
        }

        private Configuration CreateTestConfiguration()
        {
            return new Configuration
            {
                OktaDomain = "https://test.okta.com"
            };
        }

        private SchemaApi CreateSchemaApi(Mock<IAsynchronousClient> mockClient = null)
        {
            var client = mockClient ?? CreateMockAsyncClient();
            var config = CreateTestConfiguration();
            return new SchemaApi(client.Object, config);
        }

        #region Constructor Tests

        [Fact]
        public void Constructor_WithNullClient_ThrowsArgumentNullException()
        {
            // Arrange
            var config = CreateTestConfiguration();

            // Act
            Action act = () => new SchemaApi(null, config);

            // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithParameterName("asyncClient");
        }

        [Fact]
        public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();

            // Act
            Action act = () => new SchemaApi(mockClient.Object, null);

            // Assert
            act.Should().Throw<ArgumentNullException>()
                .WithParameterName("configuration");
        }

        [Fact]
        public void Constructor_WithValidParameters_CreatesInstance()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var config = CreateTestConfiguration();

            // Act
            var api = new SchemaApi(mockClient.Object, config);

            // Assert
            api.Should().NotBeNull();
            api.Should().BeAssignableTo<ISchemaApiAsync>();
        }

        #endregion

        #region GetUserSchemaAsync Tests

        [Fact]
        public async Task GetUserSchemaAsync_WithValidSchemaId_ReturnsUserSchema()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var expectedSchema = new UserSchema
            {
                Definitions = new UserSchemaDefinitions
                {
                    Base = new UserSchemaBase()
                }
            };

            mockClient.Setup(x => x.GetAsync<UserSchema>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<UserSchema>(HttpStatusCode.OK, null, expectedSchema));

            var api = CreateSchemaApi(mockClient);

            // Act
            var result = await api.GetUserSchemaAsync("default");

            // Assert
            result.Should().NotBeNull();
            result.Definitions.Should().NotBeNull();
            mockClient.Verify(x => x.GetAsync<UserSchema>(
                It.Is<string>(s => s.Contains("/user/")),
                It.IsAny<RequestOptions>(),
                It.IsAny<IReadableConfiguration>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetUserSchemaAsync_WithNullSchemaId_ThrowsApiException()
        {
            // Arrange
            var api = CreateSchemaApi();

            // Act
            Func<Task> act = async () => await api.GetUserSchemaAsync(null);

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*Missing required parameter*schemaId*");
        }

        #endregion

        #region UpdateUserProfileAsync Tests

        [Fact]
        public async Task UpdateUserProfileAsync_WithValidSchema_ReturnsUpdatedSchema()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var inputSchema = new UserSchema
            {
                Definitions = new UserSchemaDefinitions
                {
                    Custom = new UserSchemaPublic
                    {
                        Properties = new Dictionary<string, UserSchemaAttribute>
                        {
                            ["customAttribute"] = new UserSchemaAttribute
                            {
                                Title = "Custom Attribute",
                                Type = UserSchemaAttributeType.String
                            }
                        }
                    }
                }
            };

            mockClient.Setup(x => x.PostAsync<UserSchema>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<UserSchema>(HttpStatusCode.OK, null, inputSchema));

            var api = CreateSchemaApi(mockClient);

            // Act
            var result = await api.UpdateUserProfileAsync("default", inputSchema);

            // Assert
            result.Should().NotBeNull();
            result.Definitions.Custom.Properties.Should().ContainKey("customAttribute");
            mockClient.Verify(x => x.PostAsync<UserSchema>(
                It.Is<string>(s => s.Contains("/user/")),
                It.IsAny<RequestOptions>(),
                It.IsAny<IReadableConfiguration>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateUserProfileAsync_WithArrayAttribute_IncludesItemsProperty()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var inputSchema = new UserSchema
            {
                Definitions = new UserSchemaDefinitions
                {
                    Custom = new UserSchemaPublic
                    {
                        Properties = new Dictionary<string, UserSchemaAttribute>
                        {
                            ["arrayAttribute"] = new UserSchemaAttribute
                            {
                                Title = "Array Attribute",
                                Type = UserSchemaAttributeType.Array,
                                Items = new UserSchemaAttributeItems
                                {
                                    Type = "string"
                                }
                            }
                        }
                    }
                }
            };

            mockClient.Setup(x => x.PostAsync<UserSchema>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<UserSchema>(HttpStatusCode.OK, null, inputSchema));

            var api = CreateSchemaApi(mockClient);

            // Act
            var result = await api.UpdateUserProfileAsync("default", inputSchema);

            // Assert
            result.Should().NotBeNull();
            result.Definitions.Custom.Properties["arrayAttribute"].Items.Should().NotBeNull();
            result.Definitions.Custom.Properties["arrayAttribute"].Items.Type.Should().Be("string");
        }

        [Fact]
        public async Task UpdateUserProfileAsync_WithNullSchemaId_ThrowsApiException()
        {
            // Arrange
            var api = CreateSchemaApi();
            var schema = new UserSchema();

            // Act
            Func<Task> act = async () => await api.UpdateUserProfileAsync(null, schema);

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*Missing required parameter*schemaId*");
        }

        #endregion

        #region GetGroupSchemaAsync Tests

        [Fact]
        public async Task GetGroupSchemaAsync_ReturnsGroupSchema()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var expectedSchema = new GroupSchema
            {
                Definitions = new GroupSchemaDefinitions
                {
                    Base = new GroupSchemaBase()
                }
            };

            mockClient.Setup(x => x.GetAsync<GroupSchema>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<GroupSchema>(HttpStatusCode.OK, null, expectedSchema));

            var api = CreateSchemaApi(mockClient);

            // Act
            var result = await api.GetGroupSchemaAsync();

            // Assert
            result.Should().NotBeNull();
            result.Definitions.Should().NotBeNull();
            mockClient.Verify(x => x.GetAsync<GroupSchema>(
                It.Is<string>(s => s.Contains("/group/")),
                It.IsAny<RequestOptions>(),
                It.IsAny<IReadableConfiguration>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        #endregion

        #region UpdateGroupSchemaAsync Tests

        [Fact]
        public async Task UpdateGroupSchemaAsync_WithValidSchema_ReturnsUpdatedSchema()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var inputSchema = new GroupSchema
            {
                Definitions = new GroupSchemaDefinitions
                {
                    Custom = new GroupSchemaCustom
                    {
                        Properties = new Dictionary<string, GroupSchemaAttribute>
                        {
                            ["groupCustomAttribute"] = new GroupSchemaAttribute
                            {
                                Title = "Group Custom Attribute",
                                Type = UserSchemaAttributeType.String
                            }
                        }
                    }
                }
            };

            mockClient.Setup(x => x.PostAsync<GroupSchema>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<GroupSchema>(HttpStatusCode.OK, null, inputSchema));

            var api = CreateSchemaApi(mockClient);

            // Act
            var result = await api.UpdateGroupSchemaAsync(inputSchema);

            // Assert
            result.Should().NotBeNull();
            result.Definitions.Custom.Properties.Should().ContainKey("groupCustomAttribute");
            mockClient.Verify(x => x.PostAsync<GroupSchema>(
                It.Is<string>(s => s.Contains("/group/")),
                It.IsAny<RequestOptions>(),
                It.IsAny<IReadableConfiguration>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        #endregion

        #region GetApplicationUserSchemaAsync Tests

        [Fact]
        public async Task GetApplicationUserSchemaAsync_WithValidAppId_ReturnsUserSchema()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var appId = "0oa123456789abcdef";
            var expectedSchema = new UserSchema
            {
                Definitions = new UserSchemaDefinitions
                {
                    Base = new UserSchemaBase()
                }
            };

            mockClient.Setup(x => x.GetAsync<UserSchema>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<UserSchema>(HttpStatusCode.OK, null, expectedSchema));

            var api = CreateSchemaApi(mockClient);

            // Act
            var result = await api.GetApplicationUserSchemaAsync(appId);

            // Assert
            result.Should().NotBeNull();
            result.Definitions.Should().NotBeNull();
            mockClient.Verify(x => x.GetAsync<UserSchema>(
                It.Is<string>(s => s.Contains("/apps/")),
                It.IsAny<RequestOptions>(),
                It.IsAny<IReadableConfiguration>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetApplicationUserSchemaAsync_WithNullAppId_ThrowsApiException()
        {
            // Arrange
            var api = CreateSchemaApi();

            // Act
            Func<Task> act = async () => await api.GetApplicationUserSchemaAsync(null);

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*Missing required parameter*appId*");
        }

        #endregion

        #region UpdateApplicationUserProfileAsync Tests

        [Fact]
        public async Task UpdateApplicationUserProfileAsync_WithValidParameters_ReturnsUpdatedSchema()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var appId = "0oa123456789abcdef";
            var inputSchema = new UserSchema
            {
                Definitions = new UserSchemaDefinitions
                {
                    Custom = new UserSchemaPublic
                    {
                        Properties = new Dictionary<string, UserSchemaAttribute>
                        {
                            ["appCustomAttribute"] = new UserSchemaAttribute
                            {
                                Title = "App Custom Attribute",
                                Type = UserSchemaAttributeType.String
                            }
                        }
                    }
                }
            };

            mockClient.Setup(x => x.PostAsync<UserSchema>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<UserSchema>(HttpStatusCode.OK, null, inputSchema));

            var api = CreateSchemaApi(mockClient);

            // Act
            var result = await api.UpdateApplicationUserProfileAsync(appId, inputSchema);

            // Assert
            result.Should().NotBeNull();
            result.Definitions.Custom.Properties.Should().ContainKey("appCustomAttribute");
            mockClient.Verify(x => x.PostAsync<UserSchema>(
                It.Is<string>(s => s.Contains("/apps/")),
                It.IsAny<RequestOptions>(),
                It.IsAny<IReadableConfiguration>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateApplicationUserProfileAsync_WithNullAppId_ThrowsApiException()
        {
            // Arrange
            var api = CreateSchemaApi();
            var schema = new UserSchema();

            // Act
            Func<Task> act = async () => await api.UpdateApplicationUserProfileAsync(null, schema);

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .WithMessage("*Missing required parameter*appId*");
        }

        #endregion

        #region ListLogStreamSchemas Tests

        [Fact]
        public void ListLogStreamSchemas_ReturnsCollectionClient()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var api = CreateSchemaApi(mockClient);

            // Act
            var result = api.ListLogStreamSchemas();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IOktaCollectionClient<LogStreamSchema>>();
        }

        #endregion

        #region GetLogStreamSchemaAsync Tests

        [Fact]
        public async Task GetLogStreamSchemaAsync_WithAwsEventbridge_ReturnsLogStreamSchema()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var expectedSchema = new LogStreamSchema
            {
                Title = "AWS EventBridge"
            };

            mockClient.Setup(x => x.GetAsync<LogStreamSchema>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<LogStreamSchema>(HttpStatusCode.OK, null, expectedSchema));

            var api = CreateSchemaApi(mockClient);

            // Act
            var result = await api.GetLogStreamSchemaAsync(LogStreamType.AwsEventbridge);

            // Assert
            result.Should().NotBeNull();
            result.Title.Should().Be("AWS EventBridge");
            mockClient.Verify(x => x.GetAsync<LogStreamSchema>(
                It.Is<string>(s => s.Contains("/logStream/")),
                It.IsAny<RequestOptions>(),
                It.IsAny<IReadableConfiguration>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task GetLogStreamSchemaAsync_WithSplunkCloud_ReturnsLogStreamSchema()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var expectedSchema = new LogStreamSchema
            {
                Title = "Splunk Cloud"
            };

            mockClient.Setup(x => x.GetAsync<LogStreamSchema>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ApiResponse<LogStreamSchema>(HttpStatusCode.OK, null, expectedSchema));

            var api = CreateSchemaApi(mockClient);

            // Act
            var result = await api.GetLogStreamSchemaAsync(LogStreamType.SplunkCloudLogstreaming);

            // Assert
            result.Should().NotBeNull();
            result.Title.Should().Be("Splunk Cloud");
            mockClient.Verify(x => x.GetAsync<LogStreamSchema>(
                It.Is<string>(s => s.Contains("/logStream/")),
                It.IsAny<RequestOptions>(),
                It.IsAny<IReadableConfiguration>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        #endregion

        #region Error Handling Tests

        [Fact]
        public async Task GetUserSchemaAsync_WhenApiReturns404_ThrowsApiException()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            mockClient.Setup(x => x.GetAsync<UserSchema>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new ApiException(404, "Not Found"));

            var api = CreateSchemaApi(mockClient);

            // Act
            Func<Task> act = async () => await api.GetUserSchemaAsync("invalid");

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404);
        }

        [Fact]
        public async Task UpdateUserProfileAsync_WhenApiReturns400_ThrowsApiException()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            mockClient.Setup(x => x.PostAsync<UserSchema>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new ApiException(400, "Bad Request"));

            var api = CreateSchemaApi(mockClient);
            var schema = new UserSchema();

            // Act
            Func<Task> act = async () => await api.UpdateUserProfileAsync("default", schema);

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 400);
        }

        [Fact]
        public async Task GetApplicationUserSchemaAsync_WhenApiReturns403_ThrowsApiException()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            mockClient.Setup(x => x.GetAsync<UserSchema>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new ApiException(403, "Forbidden"));

            var api = CreateSchemaApi(mockClient);

            // Act
            Func<Task> act = async () => await api.GetApplicationUserSchemaAsync("app123");

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 403);
        }

        #endregion

        #region Cancellation Tests

        [Fact]
        public async Task GetUserSchemaAsync_WhenCancellationRequested_ThrowsOperationCanceledException()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var cancellationToken = new CancellationToken(true);
            
            mockClient.Setup(x => x.GetAsync<UserSchema>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.Is<CancellationToken>(ct => ct.IsCancellationRequested)))
                .ThrowsAsync(new OperationCanceledException());

            var api = CreateSchemaApi(mockClient);

            // Act
            Func<Task> act = async () => await api.GetUserSchemaAsync("default", cancellationToken);

            // Assert
            await act.Should().ThrowAsync<OperationCanceledException>();
        }

        [Fact]
        public async Task UpdateUserProfileAsync_WhenCancellationRequested_ThrowsOperationCanceledException()
        {
            // Arrange
            var mockClient = CreateMockAsyncClient();
            var cancellationToken = new CancellationToken(true);
            
            mockClient.Setup(x => x.PostAsync<UserSchema>(
                    It.IsAny<string>(),
                    It.IsAny<RequestOptions>(),
                    It.IsAny<IReadableConfiguration>(),
                    It.Is<CancellationToken>(ct => ct.IsCancellationRequested)))
                .ThrowsAsync(new OperationCanceledException());

            var api = CreateSchemaApi(mockClient);
            var schema = new UserSchema();

            // Act
            Func<Task> act = async () => await api.UpdateUserProfileAsync("default", schema, cancellationToken);

            // Assert
            await act.Should().ThrowAsync<OperationCanceledException>();
        }

        #endregion
    }
}
