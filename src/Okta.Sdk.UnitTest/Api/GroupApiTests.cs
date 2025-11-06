// <copyright file="GroupApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

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
    public class GroupApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _groupId = "00g123456789abcdef";
        private readonly string _userId = "00u987654321fedcba";

        #region AddGroup Tests

        [Fact]
        public async Task AddGroup_WithValidData_ReturnsGroup()
        {
            // Arrange
            const string groupName = "Test Group";
            const string groupDescription = "Test group description";

            var responseJson = @"{
                ""id"": """ + _groupId + @""",
                ""created"": ""2025-10-05T12:00:00.000Z"",
                ""lastUpdated"": ""2025-10-05T12:00:00.000Z"",
                ""lastMembershipUpdated"": ""2025-10-05T12:00:00.000Z"",
                ""objectClass"": [""okta:user_group""],
                ""type"": ""OKTA_GROUP"",
                ""profile"": {
                    ""name"": """ + groupName + @""",
                    ""description"": """ + groupDescription + @"""
                },
                ""_links"": {
                    ""logo"": [{""name"": ""medium"", ""href"": ""https://test.okta.com/img/logos/groups/okta-medium.png""}],
                    ""users"": {""href"": ""https://test.okta.com/api/v1/groups/" + _groupId + @"/users""},
                    ""apps"": {""href"": ""https://test.okta.com/api/v1/groups/" + _groupId + @"/apps""}
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = groupName,
                    Description = groupDescription
                }
            };

            // Act
            var group = await groupApi.AddGroupAsync(request);

            // Assert
            group.Should().NotBeNull();
            group.Id.Should().Be(_groupId);
            group.Type.Should().Be(GroupType.OKTAGROUP);

            mockClient.ReceivedPath.Should().Be("/api/v1/groups");
            mockClient.ReceivedBody.Should().Contain(groupName);
            mockClient.ReceivedBody.Should().Contain(groupDescription);
        }

        [Fact]
        public async Task AddGroupWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var groupName = "Test Group HttpInfo";

            var responseJson = @"{
                ""id"": """ + _groupId + @""",
                ""created"": ""2025-10-05T12:00:00.000Z"",
                ""lastUpdated"": ""2025-10-05T12:00:00.000Z"",
                ""lastMembershipUpdated"": ""2025-10-05T12:00:00.000Z"",
                ""objectClass"": [""okta:user_group""],
                ""type"": ""OKTA_GROUP"",
                ""profile"": {
                    ""name"": """ + groupName + @"""
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile { Name = groupName }
            };

            // Act
            var response = await groupApi.AddGroupWithHttpInfoAsync(request);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_groupId);

            mockClient.ReceivedPath.Should().Be("/api/v1/groups");
        }

        #endregion

        #region GetGroup Tests

        [Fact]
        public async Task GetGroup_WithValidId_ReturnsGroup()
        {
            // Arrange
            var groupName = "Existing Group";

            var responseJson = @"{
                ""id"": """ + _groupId + @""",
                ""created"": ""2025-10-05T12:00:00.000Z"",
                ""lastUpdated"": ""2025-10-05T12:00:00.000Z"",
                ""lastMembershipUpdated"": ""2025-10-05T12:00:00.000Z"",
                ""objectClass"": [""okta:user_group""],
                ""type"": ""OKTA_GROUP"",
                ""profile"": {
                    ""name"": """ + groupName + @"""
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var group = await groupApi.GetGroupAsync(_groupId);

            // Assert
            group.Should().NotBeNull();
            group.Id.Should().Be(_groupId);
            group.Type.Should().Be(GroupType.OKTAGROUP);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/groups/{groupId}");
            mockClient.ReceivedPathParams.Should().ContainKey("groupId");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
        }

        [Fact]
        public async Task GetGroupWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _groupId + @""",
                ""created"": ""2025-10-05T12:00:00.000Z"",
                ""lastUpdated"": ""2025-10-05T12:00:00.000Z"",
                ""lastMembershipUpdated"": ""2025-10-05T12:00:00.000Z"",
                ""objectClass"": [""okta:user_group""],
                ""type"": ""OKTA_GROUP"",
                ""profile"": {
                    ""name"": ""Test Group""
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await groupApi.GetGroupWithHttpInfoAsync(_groupId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_groupId);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/groups/{groupId}");
            mockClient.ReceivedPathParams.Should().ContainKey("groupId");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
        }

        #endregion

        #region ListGroups Tests

        [Fact]
        public async Task ListGroups_WithoutParameters_ReturnsGroups()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""00g1111111111111111"",
                    ""created"": ""2025-10-05T12:00:00.000Z"",
                    ""lastUpdated"": ""2025-10-05T12:00:00.000Z"",
                    ""lastMembershipUpdated"": ""2025-10-05T12:00:00.000Z"",
                    ""objectClass"": [""okta:user_group""],
                    ""type"": ""OKTA_GROUP"",
                    ""profile"": {
                        ""name"": ""Group 1""
                    }
                },
                {
                    ""id"": ""00g2222222222222222"",
                    ""created"": ""2025-10-05T12:00:00.000Z"",
                    ""lastUpdated"": ""2025-10-05T12:00:00.000Z"",
                    ""lastMembershipUpdated"": ""2025-10-05T12:00:00.000Z"",
                    ""objectClass"": [""okta:user_group""],
                    ""type"": ""OKTA_GROUP"",
                    ""profile"": {
                        ""name"": ""Group 2""
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var groups = await groupApi.ListGroupsWithHttpInfoAsync();

            // Assert
            groups.Should().NotBeNull();
            groups.Data.Should().HaveCount(2);
            groups.Data[0].Id.Should().Be("00g1111111111111111");
            groups.Data[1].Id.Should().Be("00g2222222222222222");

            mockClient.ReceivedPath.Should().Be("/api/v1/groups");
        }

        [Fact]
        public async Task ListGroups_WithSearchParameter_IncludesSearchInQuery()
        {
            // Arrange
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var searchQuery = "profile.name eq \"Test Group\"";

            // Act
            await groupApi.ListGroupsWithHttpInfoAsync(search: searchQuery);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/groups");
            mockClient.ReceivedQueryParams.Should().ContainKey("search");
            mockClient.ReceivedQueryParams["search"].Should().Contain(searchQuery);
        }

        [Fact]
        public async Task ListGroups_WithFilterParameter_IncludesFilterInQuery()
        {
            // Arrange
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var filterQuery = "type eq \"OKTA_GROUP\"";

            // Act
            await groupApi.ListGroupsWithHttpInfoAsync(filter: filterQuery);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/groups");
            mockClient.ReceivedQueryParams.Should().ContainKey("filter");
            mockClient.ReceivedQueryParams["filter"].Should().Contain(filterQuery);
        }

        [Fact]
        public async Task ListGroups_WithQueryParameter_IncludesQInQuery()
        {
            // Arrange
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var queryString = "TestGroup";

            // Act
            await groupApi.ListGroupsWithHttpInfoAsync(q: queryString);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/groups");
            mockClient.ReceivedQueryParams.Should().ContainKey("q");
            mockClient.ReceivedQueryParams["q"].Should().Contain(queryString);
        }

        [Fact]
        public async Task ListGroups_WithSortByAndOrder_IncludesSortParametersInQuery()
        {
            // Arrange
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await groupApi.ListGroupsWithHttpInfoAsync(sortBy: "profile.name", sortOrder: "asc");

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/groups");
            mockClient.ReceivedQueryParams.Should().ContainKey("sortBy");
            mockClient.ReceivedQueryParams["sortBy"].Should().Contain("profile.name");
            mockClient.ReceivedQueryParams.Should().ContainKey("sortOrder");
            mockClient.ReceivedQueryParams["sortOrder"].Should().Contain("asc");
        }

        [Fact]
        public async Task ListGroups_WithExpandStats_IncludesExpandInQuery()
        {
            // Arrange
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await groupApi.ListGroupsWithHttpInfoAsync(expand: "stats");

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/groups");
            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams["expand"].Should().Contain("stats");
        }

        [Fact]
        public async Task ListGroups_WithPaginationParameters_IncludesAfterAndLimitInQuery()
        {
            // Arrange
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var afterCursor = "cursor123";
            var limit = 50;

            // Act
            await groupApi.ListGroupsWithHttpInfoAsync(after: afterCursor, limit: limit);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/groups");
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain(afterCursor);
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain(limit.ToString());
        }

        [Fact]
        public async Task ListGroupsWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await groupApi.ListGroupsWithHttpInfoAsync(limit: 10);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();

            mockClient.ReceivedPath.Should().Be("/api/v1/groups");
        }

        #endregion

        #region ReplaceGroup Tests

        [Fact]
        public async Task ReplaceGroup_WithValidData_ReturnsUpdatedGroup()
        {
            // Arrange
            var updatedName = "Updated Group Name";
            var updatedDescription = "Updated description";

            var responseJson = @"{
                ""id"": """ + _groupId + @""",
                ""created"": ""2025-10-05T12:00:00.000Z"",
                ""lastUpdated"": ""2025-10-05T13:00:00.000Z"",
                ""lastMembershipUpdated"": ""2025-10-05T12:00:00.000Z"",
                ""objectClass"": [""okta:user_group""],
                ""type"": ""OKTA_GROUP"",
                ""profile"": {
                    ""name"": """ + updatedName + @""",
                    ""description"": """ + updatedDescription + @"""
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = updatedName,
                    Description = updatedDescription
                }
            };

            // Act
            var group = await groupApi.ReplaceGroupAsync(_groupId, request);

            // Assert
            group.Should().NotBeNull();
            group.Id.Should().Be(_groupId);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/groups/{groupId}");
            mockClient.ReceivedPathParams.Should().ContainKey("groupId");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
            mockClient.ReceivedBody.Should().Contain(updatedName);
            mockClient.ReceivedBody.Should().Contain(updatedDescription);
        }

        [Fact]
        public async Task ReplaceGroupWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _groupId + @""",
                ""created"": ""2025-10-05T12:00:00.000Z"",
                ""lastUpdated"": ""2025-10-05T13:00:00.000Z"",
                ""lastMembershipUpdated"": ""2025-10-05T12:00:00.000Z"",
                ""objectClass"": [""okta:user_group""],
                ""type"": ""OKTA_GROUP"",
                ""profile"": {
                    ""name"": ""Updated Name""
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var request = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile { Name = "Updated Name" }
            };

            // Act
            var response = await groupApi.ReplaceGroupWithHttpInfoAsync(_groupId, request);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_groupId);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/groups/{groupId}");
            mockClient.ReceivedPathParams.Should().ContainKey("groupId");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
        }

        #endregion

        #region DeleteGroup Tests

        [Fact]
        public async Task DeleteGroup_WithValidId_Succeeds()
        {
            // Arrange
            var responseJson = "null";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await groupApi.DeleteGroupAsync(_groupId);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/groups/{groupId}");
            mockClient.ReceivedPathParams.Should().ContainKey("groupId");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
        }

        [Fact]
        public async Task DeleteGroupWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = "null";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await groupApi.DeleteGroupWithHttpInfoAsync(_groupId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/groups/{groupId}");
            mockClient.ReceivedPathParams.Should().ContainKey("groupId");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
        }

        #endregion

        #region AssignUserToGroup Tests

        [Fact]
        public async Task AssignUserToGroup_WithValidIds_Succeeds()
        {
            // Arrange
            var responseJson = "null";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await groupApi.AssignUserToGroupAsync(_groupId, _userId);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/groups/{groupId}/users/{userId}");
            mockClient.ReceivedPathParams.Should().ContainKey("groupId");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
            mockClient.ReceivedPathParams.Should().ContainKey("userId");
            mockClient.ReceivedPathParams["userId"].Should().Contain(_userId);
        }

        [Fact]
        public async Task AssignUserToGroupWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = "null";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await groupApi.AssignUserToGroupWithHttpInfoAsync(_groupId, _userId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/groups/{groupId}/users/{userId}");
            mockClient.ReceivedPathParams.Should().ContainKey("groupId");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
            mockClient.ReceivedPathParams.Should().ContainKey("userId");
            mockClient.ReceivedPathParams["userId"].Should().Contain(_userId);
        }

        #endregion

        #region UnassignUserFromGroup Tests

        [Fact]
        public async Task UnassignUserFromGroup_WithValidIds_Succeeds()
        {
            // Arrange
            var responseJson = "null";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await groupApi.UnassignUserFromGroupAsync(_groupId, _userId);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/groups/{groupId}/users/{userId}");
            mockClient.ReceivedPathParams.Should().ContainKey("groupId");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
            mockClient.ReceivedPathParams.Should().ContainKey("userId");
            mockClient.ReceivedPathParams["userId"].Should().Contain(_userId);
        }

        [Fact]
        public async Task UnassignUserFromGroupWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = "null";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await groupApi.UnassignUserFromGroupWithHttpInfoAsync(_groupId, _userId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/groups/{groupId}/users/{userId}");
            mockClient.ReceivedPathParams.Should().ContainKey("groupId");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
            mockClient.ReceivedPathParams.Should().ContainKey("userId");
            mockClient.ReceivedPathParams["userId"].Should().Contain(_userId);
        }

        #endregion

        #region ListGroupUsers Tests

        [Fact]
        public async Task ListGroupUsers_WithoutParameters_ReturnsUsers()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""00u1111111111111111"",
                    ""status"": ""ACTIVE"",
                    ""created"": ""2025-10-05T12:00:00.000Z"",
                    ""activated"": ""2025-10-05T12:00:00.000Z"",
                    ""statusChanged"": ""2025-10-05T12:00:00.000Z"",
                    ""lastLogin"": ""2025-10-05T12:00:00.000Z"",
                    ""lastUpdated"": ""2025-10-05T12:00:00.000Z"",
                    ""profile"": {
                        ""firstName"": ""John"",
                        ""lastName"": ""Doe"",
                        ""email"": ""john.doe@example.com"",
                        ""login"": ""john.doe@example.com""
                    }
                },
                {
                    ""id"": ""00u2222222222222222"",
                    ""status"": ""ACTIVE"",
                    ""created"": ""2025-10-05T12:00:00.000Z"",
                    ""activated"": ""2025-10-05T12:00:00.000Z"",
                    ""statusChanged"": ""2025-10-05T12:00:00.000Z"",
                    ""lastLogin"": ""2025-10-05T12:00:00.000Z"",
                    ""lastUpdated"": ""2025-10-05T12:00:00.000Z"",
                    ""profile"": {
                        ""firstName"": ""Jane"",
                        ""lastName"": ""Smith"",
                        ""email"": ""jane.smith@example.com"",
                        ""login"": ""jane.smith@example.com""
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var users = await groupApi.ListGroupUsersWithHttpInfoAsync(_groupId);

            // Assert
            users.Should().NotBeNull();
            users.Data.Should().HaveCount(2);
            users.Data[0].Id.Should().Be("00u1111111111111111");
            users.Data[1].Id.Should().Be("00u2222222222222222");

            mockClient.ReceivedPath.Should().StartWith("/api/v1/groups/{groupId}/users");
            mockClient.ReceivedPathParams.Should().ContainKey("groupId");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
        }

        [Fact]
        public async Task ListGroupUsers_WithPaginationParameters_IncludesAfterAndLimitInQuery()
        {
            // Arrange
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var afterCursor = "cursor456";
            var limit = 25;

            // Act
            await groupApi.ListGroupUsersWithHttpInfoAsync(_groupId, after: afterCursor, limit: limit);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/groups/{groupId}/users");
            mockClient.ReceivedPathParams.Should().ContainKey("groupId");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain(afterCursor);
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain(limit.ToString());
        }

        [Fact]
        public async Task ListGroupUsersWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await groupApi.ListGroupUsersWithHttpInfoAsync(_groupId, limit: 10);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();

            mockClient.ReceivedPath.Should().StartWith("/api/v1/groups/{groupId}/users");
            mockClient.ReceivedPathParams.Should().ContainKey("groupId");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
        }

        #endregion

        #region ListAssignedApplicationsForGroup Tests

        [Fact]
        public async Task ListAssignedApplicationsForGroup_WithoutParameters_ReturnsApplications()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""0oa1111111111111111"",
                    ""name"": ""bookmark"",
                    ""label"": ""Test Bookmark App"",
                    ""status"": ""ACTIVE"",
                    ""created"": ""2025-10-05T12:00:00.000Z"",
                    ""lastUpdated"": ""2025-10-05T12:00:00.000Z"",
                    ""signOnMode"": ""BOOKMARK""
                },
                {
                    ""id"": ""0oa2222222222222222"",
                    ""name"": ""bookmark"",
                    ""label"": ""Another App"",
                    ""status"": ""ACTIVE"",
                    ""created"": ""2025-10-05T12:00:00.000Z"",
                    ""lastUpdated"": ""2025-10-05T12:00:00.000Z"",
                    ""signOnMode"": ""BOOKMARK""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var apps = await groupApi.ListAssignedApplicationsForGroupWithHttpInfoAsync(_groupId);

            // Assert
            apps.Should().NotBeNull();
            apps.Data.Should().HaveCount(2);
            apps.Data[0].Id.Should().Be("0oa1111111111111111");
            apps.Data[1].Id.Should().Be("0oa2222222222222222");

            mockClient.ReceivedPath.Should().StartWith("/api/v1/groups/{groupId}/apps");
            mockClient.ReceivedPathParams.Should().ContainKey("groupId");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
        }

        [Fact]
        public async Task ListAssignedApplicationsForGroup_WithPaginationParameters_IncludesAfterAndLimitInQuery()
        {
            // Arrange
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            var afterCursor = "cursor789";
            var limit = 15;

            // Act
            await groupApi.ListAssignedApplicationsForGroupWithHttpInfoAsync(_groupId, after: afterCursor, limit: limit);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/groups/{groupId}/apps");
            mockClient.ReceivedPathParams.Should().ContainKey("groupId");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain(afterCursor);
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain(limit.ToString());
        }

        [Fact]
        public async Task ListAssignedApplicationsForGroupWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await groupApi.ListAssignedApplicationsForGroupWithHttpInfoAsync(_groupId, limit: 10);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();

            mockClient.ReceivedPath.Should().StartWith("/api/v1/groups/{groupId}/apps");
            mockClient.ReceivedPathParams.Should().ContainKey("groupId");
            mockClient.ReceivedPathParams["groupId"].Should().Contain(_groupId);
        }

        #endregion

        #region Path Parameter Validation Tests

        [Fact]
        public async Task GetGroup_WithGroupId_UsesCorrectPathParameter()
        {
            // Arrange
            var groupId = "00gCustomId123";
            var responseJson = @"{
                ""id"": """ + groupId + @""",
                ""created"": ""2025-10-05T12:00:00.000Z"",
                ""lastUpdated"": ""2025-10-05T12:00:00.000Z"",
                ""lastMembershipUpdated"": ""2025-10-05T12:00:00.000Z"",
                ""objectClass"": [""okta:user_group""],
                ""type"": ""OKTA_GROUP"",
                ""profile"": { ""name"": ""Test"" }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await groupApi.GetGroupAsync(groupId);

            // Assert
            mockClient.ReceivedPathParams.Should().ContainKey("groupId");
            mockClient.ReceivedPathParams["groupId"].Should().Be(groupId);
        }

        [Fact]
        public async Task AssignUserToGroup_WithGroupIdAndUserId_UsesCorrectPathParameters()
        {
            // Arrange
            var groupId = "00gCustomGroup";
            var userId = "00uCustomUser";
            var responseJson = "null";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await groupApi.AssignUserToGroupAsync(groupId, userId);

            // Assert
            mockClient.ReceivedPathParams.Should().ContainKey("groupId");
            mockClient.ReceivedPathParams["groupId"].Should().Be(groupId);
            mockClient.ReceivedPathParams.Should().ContainKey("userId");
            mockClient.ReceivedPathParams["userId"].Should().Be(userId);
        }

        #endregion

        #region Multiple Query Parameters Tests

        [Fact]
        public async Task ListGroups_WithAllQueryParameters_IncludesAllParametersInQuery()
        {
            // Arrange
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var groupApi = new GroupApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await groupApi.ListGroupsWithHttpInfoAsync(
                q: "test",
                filter: "type eq \"OKTA_GROUP\"",
                search: "profile.name eq \"Test\"",
                sortBy: "profile.name",
                sortOrder: "asc",
                after: "cursor",
                limit: 20,
                expand: "stats"
            );

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/groups");
            mockClient.ReceivedQueryParams.Should().ContainKey("q");
            mockClient.ReceivedQueryParams.Should().ContainKey("filter");
            mockClient.ReceivedQueryParams.Should().ContainKey("search");
            mockClient.ReceivedQueryParams.Should().ContainKey("sortBy");
            mockClient.ReceivedQueryParams.Should().ContainKey("sortOrder");
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
        }

        #endregion
    }
}
