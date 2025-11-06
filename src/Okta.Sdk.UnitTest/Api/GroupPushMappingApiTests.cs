// <copyright file="GroupPushMappingApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
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
    /// Unit tests for GroupPushMappingApi.
    /// These tests verify the API client behavior without making actual HTTP calls.
    /// </summary>
    public class GroupPushMappingApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _appId = "0oa123456789undef";
        private readonly string _mappingId = "gPm987654321feedback";
        private readonly string _sourceGroupId = "00g111222333444555";
        private readonly string _targetGroupName = "TestTargetGroup";

        #region CreateGroupPushMapping Tests

        [Fact]
        public async Task CreateGroupPushMapping_WithValidData_ReturnsMapping()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _mappingId + @""",
                ""status"": ""ACTIVE"",
                ""sourceGroupId"": """ + _sourceGroupId + @""",
                ""targetGroupId"": ""target123"",
                ""targetGroupName"": """ + _targetGroupName + @""",
                ""created"": ""2025-10-26T12:00:00.000Z"",
                ""lastUpdated"": ""2025-10-26T12:00:00.000Z"",
                ""_links"": {
                    ""app"": {""href"": """ + BaseUrl + @"/api/v1/apps/" + _appId + @"""},
                    ""sourceGroup"": {""href"": """ + BaseUrl + @"/api/v1/groups/" + _sourceGroupId + @"""},
                    ""targetGroup"": {""href"": """ + BaseUrl + @"/api/v1/apps/" + _appId + @"/groups/target123""}
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new CreateGroupPushMappingRequest
            {
                SourceGroupId = _sourceGroupId,
                TargetGroupName = _targetGroupName
            };

            // Act
            var mapping = await api.CreateGroupPushMappingAsync(_appId, request);

            // Assert
            mapping.Should().NotBeNull();
            mapping.Id.Should().Be(_mappingId);
            mapping.Status.Should().Be(GroupPushMappingStatus.ACTIVE);
            mapping.SourceGroupId.Should().Be(_sourceGroupId);
            // Note: Response model uses TargetGroupId (read-only), request uses TargetGroupName
            mapping.TargetGroupId.Should().NotBeNullOrEmpty();

            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/group-push/mappings");
            mockClient.ReceivedBody.Should().Contain(_sourceGroupId);
            mockClient.ReceivedBody.Should().Contain(_targetGroupName);
        }

        [Fact]
        public async Task CreateGroupPushMappingWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _mappingId + @""",
                ""status"": ""ACTIVE"",
                ""sourceGroupId"": """ + _sourceGroupId + @""",
                ""targetGroupId"": ""target123"",
                ""targetGroupName"": """ + _targetGroupName + @""",
                ""created"": ""2025-10-26T12:00:00.000Z"",
                ""lastUpdated"": ""2025-10-26T12:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new CreateGroupPushMappingRequest
            {
                SourceGroupId = _sourceGroupId,
                TargetGroupName = _targetGroupName
            };

            // Act
            var response = await api.CreateGroupPushMappingWithHttpInfoAsync(_appId, request);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_mappingId);
            response.RawContent.Should().NotBeNullOrEmpty();

            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/group-push/mappings");
        }

        [Fact]
        public async Task CreateGroupPushMapping_WithMissingSourceGroupId_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed: sourceGroupId"",
                ""errorLink"": ""E0000001"",
                ""errorId"": ""oaeABC123"",
                ""errorCauses"": [{
                    ""errorSummary"": ""sourceGroupId: The field is required.""
                }]
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.BadRequest);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new CreateGroupPushMappingRequest
            {
                TargetGroupName = _targetGroupName
                // Missing sourceGroupId
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
                await api.CreateGroupPushMappingAsync(_appId, request));

            exception.ErrorCode.Should().Be(400);
        }

        #endregion

        #region GetGroupPushMapping Tests

        [Fact]
        public async Task GetGroupPushMapping_WithValidId_ReturnsMapping()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _mappingId + @""",
                ""status"": ""ACTIVE"",
                ""sourceGroupId"": """ + _sourceGroupId + @""",
                ""targetGroupId"": ""target123"",
                ""targetGroupName"": """ + _targetGroupName + @""",
                ""created"": ""2025-10-26T12:00:00.000Z"",
                ""lastUpdated"": ""2025-10-26T12:00:00.000Z"",
                ""_links"": {
                    ""app"": {""href"": """ + BaseUrl + @"/api/v1/apps/" + _appId + @"""},
                    ""sourceGroup"": {""href"": """ + BaseUrl + @"/api/v1/groups/" + _sourceGroupId + @"""}
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var mapping = await api.GetGroupPushMappingAsync(_appId, _mappingId);

            // Assert
            mapping.Should().NotBeNull();
            mapping.Id.Should().Be(_mappingId);
            mapping.Status.Should().Be(GroupPushMappingStatus.ACTIVE);
            mapping.SourceGroupId.Should().Be(_sourceGroupId);

            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/group-push/mappings/{mappingId}");
        }

        [Fact]
        public async Task GetGroupPushMappingWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _mappingId + @""",
                ""status"": ""ACTIVE"",
                ""sourceGroupId"": """ + _sourceGroupId + @""",
                ""targetGroupId"": ""target123""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetGroupPushMappingWithHttpInfoAsync(_appId, _mappingId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_mappingId);

            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/group-push/mappings/{mappingId}");
        }

        [Fact]
        public async Task GetGroupPushMapping_WithInvalidId_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: invalidId (GroupPushMapping)"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""oaeXYZ789""
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
                await api.GetGroupPushMappingAsync(_appId, "invalidId"));

            exception.ErrorCode.Should().Be(404);
        }

        #endregion

        #region ListGroupPushMappings Tests

        [Fact]
        public async Task ListGroupPushMappings_WithoutFilters_ReturnsMappings()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": """ + _mappingId + @""",
                    ""status"": ""ACTIVE"",
                    ""sourceGroupId"": """ + _sourceGroupId + @""",
                    ""targetGroupId"": ""00g777888999000111""
                },
                {
                    ""id"": ""gPm222333444555666"",
                    ""status"": ""INACTIVE"",
                    ""sourceGroupId"": ""00g999888777666555"",
                    ""targetGroupId"": ""00g666555444333222""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListGroupPushMappingsWithHttpInfoAsync(_appId);

            // Assert
            response.Should().NotBeNull();
            response.Data.Should().NotBeNull();
            response.Data.Should().HaveCount(2);
            response.Data[0].Id.Should().Be(_mappingId);
            response.Data[0].Status.Should().Be(GroupPushMappingStatus.ACTIVE);
            response.Data[1].Status.Should().Be(GroupPushMappingStatus.INACTIVE);

            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/group-push/mappings");
        }

        [Fact]
        public async Task ListGroupPushMappings_WithStatusFilter_IncludesStatusInQuery()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": """ + _mappingId + @""",
                    ""status"": ""ACTIVE"",
                    ""sourceGroupId"": """ + _sourceGroupId + @"""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListGroupPushMappingsWithHttpInfoAsync(
                _appId, 
                status: GroupPushMappingStatus.ACTIVE
            );

            // Assert
            response.Should().NotBeNull();
            response.Data.Should().NotBeNull();
            response.Data.Should().HaveCount(1);
            response.Data[0].Status.Should().Be(GroupPushMappingStatus.ACTIVE);

            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/group-push/mappings");
            // Verify query parameter was sent
            mockClient.ReceivedQueryParams.Should().ContainKey("status");
        }

        [Fact]
        public async Task ListGroupPushMappings_WithSourceGroupIdFilter_IncludesSourceGroupIdInQuery()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": """ + _mappingId + @""",
                    ""status"": ""ACTIVE"",
                    ""sourceGroupId"": """ + _sourceGroupId + @"""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListGroupPushMappingsWithHttpInfoAsync(
                _appId,
                sourceGroupId: _sourceGroupId
            );

            // Assert
            response.Should().NotBeNull();
            response.Data[0].SourceGroupId.Should().Be(_sourceGroupId);

            mockClient.ReceivedQueryParams.Should().ContainKey("sourceGroupId");
        }

        [Fact]
        public async Task ListGroupPushMappings_WithPagination_IncludesLimitInQuery()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": """ + _mappingId + @""",
                    ""status"": ""ACTIVE"",
                    ""sourceGroupId"": """ + _sourceGroupId + @"""
                }
            ]";

            var linkHeader = new Multimap<string, string>
            {
                { "link", @"<" + BaseUrl + @"/api/v1/apps/" + _appId + @"/group-push/mappings?after=gPm999&limit=20>; rel=""next""" }
            };

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, linkHeader);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListGroupPushMappingsWithHttpInfoAsync(_appId, limit: 20);

            // Assert
            response.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
        }

        [Fact]
        public async Task ListGroupPushMappingsWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": """ + _mappingId + @""",
                    ""status"": ""ACTIVE"",
                    ""sourceGroupId"": """ + _sourceGroupId + @"""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListGroupPushMappingsWithHttpInfoAsync(_appId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().HaveCount(1);

            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/group-push/mappings");
        }

        // Note: Error scenario tests for List operations are covered in integration tests
        // as MockAsyncClient cannot properly simulate error responses for collection endpoints

        #endregion

        #region UpdateGroupPushMapping Tests

        [Fact]
        public async Task UpdateGroupPushMapping_WithValidData_ReturnsUpdatedMapping()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _mappingId + @""",
                ""status"": ""ACTIVE"",
                ""sourceGroupId"": """ + _sourceGroupId + @""",
                ""targetGroupId"": ""00g999888777666555"",
                ""created"": ""2025-10-26T12:00:00.000Z"",
                ""lastUpdated"": ""2025-10-26T13:00:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updateRequest = new UpdateGroupPushMappingRequest
            {
                Status = GroupPushMappingStatusUpsert.ACTIVE
            };

            // Act
            var mapping = await api.UpdateGroupPushMappingAsync(_appId, _mappingId, updateRequest);

            // Assert
            mapping.Should().NotBeNull();
            mapping.Id.Should().Be(_mappingId);
            mapping.Status.Should().Be(GroupPushMappingStatus.ACTIVE);

            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/group-push/mappings/{mappingId}");
        }

        [Fact]
        public async Task UpdateGroupPushMapping_ChangeStatus_ReturnsUpdatedMapping()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _mappingId + @""",
                ""status"": ""INACTIVE"",
                ""sourceGroupId"": """ + _sourceGroupId + @""",
                ""targetGroupId"": ""target123"",
                ""targetGroupName"": """ + _targetGroupName + @"""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updateRequest = new UpdateGroupPushMappingRequest
            {
                Status = GroupPushMappingStatusUpsert.INACTIVE
            };

            // Act
            var mapping = await api.UpdateGroupPushMappingAsync(_appId, _mappingId, updateRequest);

            // Assert
            mapping.Should().NotBeNull();
            mapping.Status.Should().Be(GroupPushMappingStatus.INACTIVE);

            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/group-push/mappings/{mappingId}");
        }

        [Fact]
        public async Task UpdateGroupPushMappingWithHttpInfo_WithStatusChange_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _mappingId + @""",
                ""status"": ""INACTIVE"",
                ""sourceGroupId"": """ + _sourceGroupId + @""",
                ""targetGroupId"": ""00g999888777666555""
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updateRequest = new UpdateGroupPushMappingRequest
            {
                Status = GroupPushMappingStatusUpsert.INACTIVE
            };

            // Act
            var response = await api.UpdateGroupPushMappingWithHttpInfoAsync(_appId, _mappingId, updateRequest);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Status.Should().Be(GroupPushMappingStatus.INACTIVE);

            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/group-push/mappings/{mappingId}");
        }

        [Fact]
        public async Task UpdateGroupPushMapping_WithInvalidId_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: invalidId (GroupPushMapping)"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""oaeXYZ789""
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updateRequest = new UpdateGroupPushMappingRequest
            {
                Status = GroupPushMappingStatusUpsert.ACTIVE
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
                await api.UpdateGroupPushMappingAsync(_appId, "invalidId", updateRequest));

            exception.ErrorCode.Should().Be(404);
        }

        #endregion

        #region DeleteGroupPushMapping Tests

        [Fact]
        public async Task DeleteGroupPushMapping_WithValidId_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteGroupPushMappingAsync(_appId, _mappingId, deleteTargetGroup: false);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/group-push/mappings/{mappingId}");
        }

        [Fact]
        public async Task DeleteGroupPushMapping_WithDeleteTargetGroup_SendsCorrectParameter()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteGroupPushMappingAsync(_appId, _mappingId, deleteTargetGroup: true);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/group-push/mappings/{mappingId}");
            mockClient.ReceivedQueryParams.Should().ContainKey("deleteTargetGroup");
        }

        [Fact]
        public async Task DeleteGroupPushMappingWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.DeleteGroupPushMappingWithHttpInfoAsync(_appId, _mappingId, deleteTargetGroup: false);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            mockClient.ReceivedPath.Should().Be("/api/v1/apps/{appId}/group-push/mappings/{mappingId}");
        }

        [Fact]
        public async Task DeleteGroupPushMapping_WithInvalidId_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: invalidId (GroupPushMapping)"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""oaeABC123""
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
                await api.DeleteGroupPushMappingAsync(_appId, "invalidId", deleteTargetGroup: false));

            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task DeleteGroupPushMapping_WhenMappingIsActive_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed: Cannot delete ACTIVE mapping. Deactivate first."",
                ""errorLink"": ""E0000001"",
                ""errorId"": ""oaeXYZ789"",
                ""errorCauses"": [{
                    ""errorSummary"": ""Mapping must be INACTIVE before deletion.""
                }]
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.BadRequest);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
                await api.DeleteGroupPushMappingAsync(_appId, _mappingId, deleteTargetGroup: false));

            exception.ErrorCode.Should().Be(400);
        }

        #endregion

        #region Edge Cases and Validation Tests

        [Fact]
        public async Task CreateGroupPushMapping_WithNullRequest_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed"",
                ""errorLink"": ""E0000001"",
                ""errorId"": ""oaeABC123""
            }";
            
            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.BadRequest);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert - API throws ApiException for null/invalid requests
            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
                await api.CreateGroupPushMappingAsync(_appId, new CreateGroupPushMappingRequest()));
            
            exception.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task GetGroupPushMapping_WithInvalidAppId_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""oaeXYZ789""
            }";
            
            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
                await api.GetGroupPushMappingAsync("invalidAppId", _mappingId));
                
            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task GetGroupPushMapping_WithInvalidMappingId_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: invalidId (GroupPushMapping)"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""oaeXYZ789""
            }";
            
            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
                await api.GetGroupPushMappingAsync(_appId, "invalidId"));
                
            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task UpdateGroupPushMapping_WithInvalidData_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed"",
                ""errorLink"": ""E0000001"",
                ""errorId"": ""oaeABC123""
            }";
            
            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.BadRequest);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
                await api.UpdateGroupPushMappingAsync(_appId, _mappingId, new UpdateGroupPushMappingRequest()));
                
            exception.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task DeleteGroupPushMapping_WithInvalidAppId_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""oaeXYZ789""
            }";
            
            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
                await api.DeleteGroupPushMappingAsync("invalidAppId", _mappingId, false));
                
            exception.ErrorCode.Should().Be(404);
        }

        // Note: Error scenario tests for List operations are covered in integration tests
        // MockAsyncClient cannot deserialize error responses when expecting List<T>

        [Fact]
        public async Task CreateGroupPushMapping_WithDuplicateMapping_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed: A mapping for this source group already exists."",
                ""errorLink"": ""E0000001"",
                ""errorId"": ""oaeXYZ123"",
                ""errorCauses"": [{
                    ""errorSummary"": ""Duplicate mapping detected for sourceGroupId: " + _sourceGroupId + @"""
                }]
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.BadRequest);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new CreateGroupPushMappingRequest
            {
                SourceGroupId = _sourceGroupId,
                TargetGroupName = _targetGroupName
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(async () =>
                await api.CreateGroupPushMappingAsync(_appId, request));

            exception.ErrorCode.Should().Be(400);
        }

        #endregion

        #region Link and Metadata Tests

        [Fact]
        public async Task GetGroupPushMapping_VerifyLinksStructure()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _mappingId + @""",
                ""status"": ""ACTIVE"",
                ""sourceGroupId"": """ + _sourceGroupId + @""",
                ""targetGroupName"": """ + _targetGroupName + @""",
                ""_links"": {
                    ""self"": {""href"": """ + BaseUrl + @"/api/v1/apps/" + _appId + @"/group-push/mappings/" + _mappingId + @"""},
                    ""app"": {""href"": """ + BaseUrl + @"/api/v1/apps/" + _appId + @"""},
                    ""sourceGroup"": {""href"": """ + BaseUrl + @"/api/v1/groups/" + _sourceGroupId + @"""},
                    ""targetGroup"": {""href"": """ + BaseUrl + @"/api/v1/apps/" + _appId + @"/groups/target123""}
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var mapping = await api.GetGroupPushMappingAsync(_appId, _mappingId);

            // Assert
            mapping.Should().NotBeNull();
            mapping.Links.Should().NotBeNull();
            mapping.Links.App.Should().NotBeNull();
            mapping.Links.App.Href.Should().Contain($"/api/v1/apps/{_appId}");
            mapping.Links.SourceGroup.Should().NotBeNull();
            mapping.Links.SourceGroup.Href.Should().Contain($"/api/v1/groups/{_sourceGroupId}");
        }

        [Fact]
        public async Task CreateGroupPushMapping_VerifyTimestamps()
        {
            // Arrange
            var created = "2025-10-26T12:00:00.000Z";
            var lastUpdated = "2025-10-26T12:00:00.000Z";
            
            var responseJson = @"{
                ""id"": """ + _mappingId + @""",
                ""status"": ""ACTIVE"",
                ""sourceGroupId"": """ + _sourceGroupId + @""",
                ""targetGroupName"": """ + _targetGroupName + @""",
                ""created"": """ + created + @""",
                ""lastUpdated"": """ + lastUpdated + @"""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupPushMappingApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new CreateGroupPushMappingRequest
            {
                SourceGroupId = _sourceGroupId,
                TargetGroupName = _targetGroupName
            };

            // Act
            var mapping = await api.CreateGroupPushMappingAsync(_appId, request);

            // Assert
            mapping.Should().NotBeNull();
            // DateTimeOffset properties have default value checking
            mapping.Created.Should().BeAfter(DateTimeOffset.MinValue);
            mapping.LastUpdated.Should().BeAfter(DateTimeOffset.MinValue);
            mapping.Created.Should().Be(DateTimeOffset.Parse(created));
            mapping.LastUpdated.Should().Be(DateTimeOffset.Parse(lastUpdated));
        }

        #endregion
    }
}
