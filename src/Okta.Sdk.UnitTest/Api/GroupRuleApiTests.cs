// <copyright file="GroupRuleApiTests.cs" company="Okta, Inc">
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
    public class GroupRuleApiTests
    {
        private const string TestGroupRuleId = "0pr1ab2c3D4E5F6G7H8I";
        private const string TestGroupId = "00g1ab2c3D4E5F6G7H8I";
        private const string TestBasePath = "https://test.okta.com";

        #region CreateGroupRule Tests

        [Fact]
        public async Task CreateGroupRuleAsync_WithValidRequest_ReturnsGroupRule()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""0pr1ab2c3D4E5F6G7H8I"",
                ""type"": ""group_rule"",
                ""status"": ""INACTIVE"",
                ""name"": ""Engineering Rule"",
                ""created"": ""2023-01-15T10:30:00.000Z"",
                ""lastUpdated"": ""2023-01-15T10:30:00.000Z"",
                ""conditions"": {
                    ""expression"": {
                        ""type"": ""urn:okta:expression:1.0"",
                        ""value"": ""user.department==\""Engineering\""""
                    }
                },
                ""actions"": {
                    ""assignUserToGroups"": {
                        ""groupIds"": [""00g1ab2c3D4E5F6G7H8I""]
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            var createRequest = new CreateGroupRuleRequest
            {
                Type = CreateGroupRuleRequest.TypeEnum.GroupRule,
                Name = "Engineering Rule",
                Conditions = new GroupRuleConditions
                {
                    Expression = new GroupRuleExpression
                    {
                        Type = "urn:okta:expression:1.0",
                        Value = "user.department==\"Engineering\""
                    }
                },
                Actions = new GroupRuleAction
                {
                    AssignUserToGroups = new GroupRuleGroupAssignment
                    {
                        GroupIds = [TestGroupId]
                    }
                }
            };

            // Act
            var result = await api.CreateGroupRuleAsync(createRequest);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(TestGroupRuleId);
            result.Name.Should().Be("Engineering Rule");
            result.Status.Should().Be(GroupRuleStatus.INACTIVE);
            result.Type.Should().Be("group_rule");
            result.Conditions.Expression.Value.Should().Contain("Engineering");
            result.Actions.AssignUserToGroups.GroupIds.Should().Contain(TestGroupId);

            mockClient.ReceivedBody.Should().Contain("Engineering Rule");
            mockClient.ReceivedBody.Should().Contain("group_rule");
            mockClient.ReceivedPath.Should().Be("/api/v1/groups/rules");
        }

        [Fact]
        public async Task CreateGroupRuleAsync_WithBadRequest_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed: name"",
                ""errorCauses"": [{""errorSummary"": ""name: The field is required""}]
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.BadRequest);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            var invalidRequest = new CreateGroupRuleRequest
            {
                Type = CreateGroupRuleRequest.TypeEnum.GroupRule
                // Missing required fields
            };

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.CreateGroupRuleAsync(invalidRequest));
        }

        #endregion

        #region ListGroupRules Tests

        [Fact]
        public async Task ListGroupRulesAsync_WithoutParameters_ReturnsAllRules()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""0pr1ab2c3D4E5F6G7H8I"",
                    ""type"": ""group_rule"",
                    ""status"": ""ACTIVE"",
                    ""name"": ""Engineering Rule"",
                    ""created"": ""2023-01-15T10:30:00.000Z"",
                    ""lastUpdated"": ""2023-01-15T10:30:00.000Z"",
                    ""conditions"": {
                        ""expression"": {
                            ""type"": ""urn:okta:expression:1.0"",
                            ""value"": ""user.department==\""Engineering\""""
                        }
                    },
                    ""actions"": {
                        ""assignUserToGroups"": {
                            ""groupIds"": [""00g1ab2c3D4E5F6G7H8I""]
                        }
                    }
                },
                {
                    ""id"": ""0pr9zy8x7W6V5U4T3S2R"",
                    ""type"": ""group_rule"",
                    ""status"": ""INACTIVE"",
                    ""name"": ""Marketing Rule"",
                    ""created"": ""2023-02-10T14:20:00.000Z"",
                    ""lastUpdated"": ""2023-02-10T14:20:00.000Z"",
                    ""conditions"": {
                        ""expression"": {
                            ""type"": ""urn:okta:expression:1.0"",
                            ""value"": ""user.department==\""Marketing\""""
                        }
                    },
                    ""actions"": {
                        ""assignUserToGroups"": {
                            ""groupIds"": [""00g2cd3e4F5G6H7I8J9K""]
                        }
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            // Act
            var result = await api.ListGroupRulesWithHttpInfoAsync();

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
            result.Data[0].Name.Should().Be("Engineering Rule");
            result.Data[0].Status.Should().Be(GroupRuleStatus.ACTIVE);
            result.Data[1].Name.Should().Be("Marketing Rule");
            result.Data[1].Status.Should().Be(GroupRuleStatus.INACTIVE);

            mockClient.ReceivedPath.Should().Be("/api/v1/groups/rules");
        }

        [Fact]
        public async Task ListGroupRulesAsync_WithLimitParameter_IncludesLimitInRequest()
        {
            // Arrange
            var responseJson = @"[{
                ""id"": ""0pr1ab2c3D4E5F6G7H8I"",
                ""type"": ""group_rule"",
                ""status"": ""ACTIVE"",
                ""name"": ""Test Rule"",
                ""created"": ""2023-01-15T10:30:00.000Z"",
                ""lastUpdated"": ""2023-01-15T10:30:00.000Z"",
                ""conditions"": {
                    ""expression"": {
                        ""type"": ""urn:okta:expression:1.0"",
                        ""value"": ""user.department==\""Test\""""
                    }
                },
                ""actions"": {
                    ""assignUserToGroups"": {
                        ""groupIds"": [""00g1ab2c3D4E5F6G7H8I""]
                    }
                }
            }]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            // Act
            var result = await api.ListGroupRulesWithHttpInfoAsync(limit: 10);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain("10");
        }

        [Fact]
        public async Task ListGroupRulesAsync_WithSearchParameter_IncludesSearchInRequest()
        {
            // Arrange
            var responseJson = @"[{
                ""id"": ""0pr1ab2c3D4E5F6G7H8I"",
                ""type"": ""group_rule"",
                ""status"": ""ACTIVE"",
                ""name"": ""Engineering Rule"",
                ""created"": ""2023-01-15T10:30:00.000Z"",
                ""lastUpdated"": ""2023-01-15T10:30:00.000Z"",
                ""conditions"": {
                    ""expression"": {
                        ""type"": ""urn:okta:expression:1.0"",
                        ""value"": ""user.department==\""Engineering\""""
                    }
                },
                ""actions"": {
                    ""assignUserToGroups"": {
                        ""groupIds"": [""00g1ab2c3D4E5F6G7H8I""]
                    }
                }
            }]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            // Act
            var result = await api.ListGroupRulesWithHttpInfoAsync(search: "Engineering");

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().HaveCount(1);
            mockClient.ReceivedQueryParams.Should().ContainKey("search");
            mockClient.ReceivedQueryParams["search"].Should().Contain("Engineering");
        }

        [Fact]
        public async Task ListGroupRulesAsync_WithExpandParameter_IncludesExpandInRequest()
        {
            // Arrange
            var responseJson = @"[{
                ""id"": ""0pr1ab2c3D4E5F6G7H8I"",
                ""type"": ""group_rule"",
                ""status"": ""ACTIVE"",
                ""name"": ""Test Rule"",
                ""created"": ""2023-01-15T10:30:00.000Z"",
                ""lastUpdated"": ""2023-01-15T10:30:00.000Z"",
                ""conditions"": {
                    ""expression"": {
                        ""type"": ""urn:okta:expression:1.0"",
                        ""value"": ""user.department==\""Test\""""
                    }
                },
                ""actions"": {
                    ""assignUserToGroups"": {
                        ""groupIds"": [""00g1ab2c3D4E5F6G7H8I""]
                    }
                }
            }]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            // Act
            var result = await api.ListGroupRulesWithHttpInfoAsync(expand: "groupIdToGroupNameMap");

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams["expand"].Should().Contain("groupIdToGroupNameMap");
        }

        #endregion

        #region GetGroupRule Tests

        [Fact]
        public async Task GetGroupRuleAsync_WithValidId_ReturnsGroupRule()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""0pr1ab2c3D4E5F6G7H8I"",
                ""type"": ""group_rule"",
                ""status"": ""ACTIVE"",
                ""name"": ""Engineering Rule"",
                ""created"": ""2023-01-15T10:30:00.000Z"",
                ""lastUpdated"": ""2023-01-15T10:30:00.000Z"",
                ""conditions"": {
                    ""expression"": {
                        ""type"": ""urn:okta:expression:1.0"",
                        ""value"": ""user.department==\""Engineering\""""
                    }
                },
                ""actions"": {
                    ""assignUserToGroups"": {
                        ""groupIds"": [""00g1ab2c3D4E5F6G7H8I""]
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            // Act
            var result = await api.GetGroupRuleAsync(TestGroupRuleId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(TestGroupRuleId);
            result.Name.Should().Be("Engineering Rule");
            result.Status.Should().Be(GroupRuleStatus.ACTIVE);

            mockClient.ReceivedPath.Should().Be("/api/v1/groups/rules/{groupRuleId}");
            mockClient.ReceivedPathParams.Should().ContainKey("groupRuleId");
            mockClient.ReceivedPathParams["groupRuleId"].Should().Be(TestGroupRuleId);
        }

        [Fact]
        public async Task GetGroupRuleAsync_WithExpandParameter_IncludesExpandInRequest()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""0pr1ab2c3D4E5F6G7H8I"",
                ""type"": ""group_rule"",
                ""status"": ""ACTIVE"",
                ""name"": ""Test Rule"",
                ""created"": ""2023-01-15T10:30:00.000Z"",
                ""lastUpdated"": ""2023-01-15T10:30:00.000Z"",
                ""conditions"": {
                    ""expression"": {
                        ""type"": ""urn:okta:expression:1.0"",
                        ""value"": ""user.department==\""Test\""""
                    }
                },
                ""actions"": {
                    ""assignUserToGroups"": {
                        ""groupIds"": [""00g1ab2c3D4E5F6G7H8I""]
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            // Act
            var result = await api.GetGroupRuleAsync(TestGroupRuleId, expand: "groupIdToGroupNameMap");

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams["expand"].Should().Contain("groupIdToGroupNameMap");
        }

        [Fact]
        public async Task GetGroupRuleAsync_WithInvalidId_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: invalid-id (GroupRule)""
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetGroupRuleAsync("invalid-id"));
        }

        #endregion

        #region ReplaceGroupRule Tests

        [Fact]
        public async Task ReplaceGroupRuleAsync_WithValidRule_ReturnsUpdatedRule()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""0pr1ab2c3D4E5F6G7H8I"",
                ""type"": ""group_rule"",
                ""status"": ""INACTIVE"",
                ""name"": ""Updated Engineering Rule"",
                ""created"": ""2023-01-15T10:30:00.000Z"",
                ""lastUpdated"": ""2023-03-20T15:45:00.000Z"",
                ""conditions"": {
                    ""expression"": {
                        ""type"": ""urn:okta:expression:1.0"",
                        ""value"": ""user.department==\""Engineering\"" and user.title==\""Manager\""""
                    }
                },
                ""actions"": {
                    ""assignUserToGroups"": {
                        ""groupIds"": [""00g1ab2c3D4E5F6G7H8I""]
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            var updatedRule = new GroupRule
            {
                Type = "group_rule",
                Name = "Updated Engineering Rule",
                Status = GroupRuleStatus.INACTIVE,
                Conditions = new GroupRuleConditions
                {
                    Expression = new GroupRuleExpression
                    {
                        Type = "urn:okta:expression:1.0",
                        Value = "user.department==\"Engineering\" and user.title==\"Manager\""
                    }
                },
                Actions = new GroupRuleAction
                {
                    AssignUserToGroups = new GroupRuleGroupAssignment
                    {
                        GroupIds = [TestGroupId]
                    }
                }
            };

            // Act
            var result = await api.ReplaceGroupRuleAsync(TestGroupRuleId, updatedRule);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(TestGroupRuleId);
            result.Name.Should().Be("Updated Engineering Rule");
            result.Conditions.Expression.Value.Should().Contain("Manager");

            mockClient.ReceivedPath.Should().Be("/api/v1/groups/rules/{groupRuleId}");
            mockClient.ReceivedPathParams.Should().ContainKey("groupRuleId");
            mockClient.ReceivedPathParams["groupRuleId"].Should().Be(TestGroupRuleId);
            mockClient.ReceivedBody.Should().Contain("Updated Engineering Rule");
        }

        [Fact]
        public async Task ReplaceGroupRuleAsync_WithActiveRule_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed: status"",
                ""errorCauses"": [{""errorSummary"": ""Cannot update an active rule""}]
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.BadRequest);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            var activeRule = new GroupRule
            {
                Type = "group_rule",
                Name = "Test Rule",
                Status = GroupRuleStatus.ACTIVE,
                Conditions = new GroupRuleConditions
                {
                    Expression = new GroupRuleExpression
                    {
                        Type = "urn:okta:expression:1.0",
                        Value = "user.department==\"Test\""
                    }
                },
                Actions = new GroupRuleAction
                {
                    AssignUserToGroups = new GroupRuleGroupAssignment
                    {
                        GroupIds = [TestGroupId]
                    }
                }
            };

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ReplaceGroupRuleAsync(TestGroupRuleId, activeRule));
        }

        #endregion

        #region DeleteGroupRule Tests

        [Fact]
        public async Task DeleteGroupRuleAsync_WithValidId_SuccessfullyDeletes()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.Accepted);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            // Act
            await api.DeleteGroupRuleAsync(TestGroupRuleId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/groups/rules/{groupRuleId}");
            mockClient.ReceivedPathParams.Should().ContainKey("groupRuleId");
            mockClient.ReceivedPathParams["groupRuleId"].Should().Be(TestGroupRuleId);
        }

        [Fact]
        public async Task DeleteGroupRuleAsync_WithRemoveUsersTrue_IncludesParameterInRequest()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.Accepted);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            // Act
            await api.DeleteGroupRuleAsync(TestGroupRuleId, removeUsers: true);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/groups/rules/{groupRuleId}");
            mockClient.ReceivedPathParams.Should().ContainKey("groupRuleId");
            mockClient.ReceivedPathParams["groupRuleId"].Should().Be(TestGroupRuleId);
            mockClient.ReceivedQueryParams.Should().ContainKey("removeUsers");
            mockClient.ReceivedQueryParams["removeUsers"].Should().Contain("true");
        }

        [Fact]
        public async Task DeleteGroupRuleAsync_WithRemoveUsersFalse_IncludesParameterInRequest()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.Accepted);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            // Act
            await api.DeleteGroupRuleAsync(TestGroupRuleId, removeUsers: false);

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("removeUsers");
            mockClient.ReceivedQueryParams["removeUsers"].Should().Contain("false");
        }

        [Fact]
        public async Task DeleteGroupRuleAsync_WithActiveRule_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed"",
                ""errorCauses"": [{""errorSummary"": ""Cannot delete an active rule""}]
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.BadRequest);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeleteGroupRuleAsync(TestGroupRuleId));
        }

        #endregion

        #region ActivateGroupRule Tests

        [Fact]
        public async Task ActivateGroupRuleAsync_WithValidId_SuccessfullyActivates()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            // Act
            await api.ActivateGroupRuleAsync(TestGroupRuleId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/groups/rules/{groupRuleId}/lifecycle/activate");
            mockClient.ReceivedPathParams.Should().ContainKey("groupRuleId");
            mockClient.ReceivedPathParams["groupRuleId"].Should().Be(TestGroupRuleId);
        }

        [Fact]
        public async Task ActivateGroupRuleAsync_WithInvalidId_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: invalid-id (GroupRule)""
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ActivateGroupRuleAsync("invalid-id"));
        }

        [Fact]
        public async Task ActivateGroupRuleAsync_WithAlreadyActiveRule_Succeeds()
        {
            // Arrange - Okta API is idempotent for activating
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            // Act
            await api.ActivateGroupRuleAsync(TestGroupRuleId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/groups/rules/{groupRuleId}/lifecycle/activate");
            mockClient.ReceivedPathParams.Should().ContainKey("groupRuleId");
            mockClient.ReceivedPathParams["groupRuleId"].Should().Be(TestGroupRuleId);
        }

        #endregion

        #region DeactivateGroupRule Tests

        [Fact]
        public async Task DeactivateGroupRuleAsync_WithValidId_SuccessfullyDeactivates()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            // Act
            await api.DeactivateGroupRuleAsync(TestGroupRuleId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/groups/rules/{groupRuleId}/lifecycle/deactivate");
            mockClient.ReceivedPathParams.Should().ContainKey("groupRuleId");
            mockClient.ReceivedPathParams["groupRuleId"].Should().Be(TestGroupRuleId);
        }

        [Fact]
        public async Task DeactivateGroupRuleAsync_WithInvalidId_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: invalid-id (GroupRule)""
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeactivateGroupRuleAsync("invalid-id"));
        }

        [Fact]
        public async Task DeactivateGroupRuleAsync_WithAlreadyInactiveRule_Succeeds()
        {
            // Arrange - Okta API is idempotent for deactivate
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            // Act
            await api.DeactivateGroupRuleAsync(TestGroupRuleId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/groups/rules/{groupRuleId}/lifecycle/deactivate");
            mockClient.ReceivedPathParams.Should().ContainKey("groupRuleId");
            mockClient.ReceivedPathParams["groupRuleId"].Should().Be(TestGroupRuleId);
        }

        #endregion

        #region HTTP Status Code Tests

        [Theory]
        [InlineData(HttpStatusCode.Forbidden)]
        [InlineData(HttpStatusCode.TooManyRequests)]
        [InlineData(HttpStatusCode.InternalServerError)]
        public async Task CreateGroupRuleAsync_WithErrorStatusCodes_ThrowsApiException(HttpStatusCode statusCode)
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Test error""
            }";

            var mockClient = new MockAsyncClient(errorJson, statusCode);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            var request = new CreateGroupRuleRequest
            {
                Type = CreateGroupRuleRequest.TypeEnum.GroupRule,
                Name = "Test"
            };

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.CreateGroupRuleAsync(request));
        }

        [Theory]
        [InlineData(HttpStatusCode.Forbidden)]
        [InlineData(HttpStatusCode.NotFound)]
        [InlineData(HttpStatusCode.TooManyRequests)]
        public async Task GetGroupRuleAsync_WithErrorStatusCodes_ThrowsApiException(HttpStatusCode statusCode)
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Test error""
            }";

            var mockClient = new MockAsyncClient(errorJson, statusCode);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetGroupRuleAsync(TestGroupRuleId));
        }

        #endregion

        #region Complex Expressions Tests

        [Fact]
        public async Task CreateGroupRuleAsync_WithComplexExpression_CreatesSuccessfully()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""0pr1ab2c3D4E5F6G7H8I"",
                ""type"": ""group_rule"",
                ""status"": ""INACTIVE"",
                ""name"": ""Complex Rule"",
                ""created"": ""2023-01-15T10:30:00.000Z"",
                ""lastUpdated"": ""2023-01-15T10:30:00.000Z"",
                ""conditions"": {
                    ""expression"": {
                        ""type"": ""urn:okta:expression:1.0"",
                        ""value"": ""user.department==\""Engineering\"" and user.status==\""ACTIVE\"" or user.title==\""Manager\""""
                    }
                },
                ""actions"": {
                    ""assignUserToGroups"": {
                        ""groupIds"": [""00g1ab2c3D4E5F6G7H8I""]
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            var createRequest = new CreateGroupRuleRequest
            {
                Type = CreateGroupRuleRequest.TypeEnum.GroupRule,
                Name = "Complex Rule",
                Conditions = new GroupRuleConditions
                {
                    Expression = new GroupRuleExpression
                    {
                        Type = "urn:okta:expression:1.0",
                        Value = "user.department==\"Engineering\" and user.status==\"ACTIVE\" or user.title==\"Manager\""
                    }
                },
                Actions = new GroupRuleAction
                {
                    AssignUserToGroups = new GroupRuleGroupAssignment
                    {
                        GroupIds = [TestGroupId]
                    }
                }
            };

            // Act
            var result = await api.CreateGroupRuleAsync(createRequest);

            // Assert
            result.Should().NotBeNull();
            result.Conditions.Expression.Value.Should().Contain("and");
            result.Conditions.Expression.Value.Should().Contain("or");
        }

        [Fact]
        public async Task CreateGroupRuleAsync_WithMultipleGroupIds_CreatesSuccessfully()
        {
            // Arrange
            var group2Id = "00g2cd3e4F5G6H7I8J9K";
            var group3Id = "00g3de4f5G6H7I8J9K0L";

            var responseJson = $@"{{
                ""id"": ""0pr1ab2c3D4E5F6G7H8I"",
                ""type"": ""group_rule"",
                ""status"": ""INACTIVE"",
                ""name"": ""Multi-Group Rule"",
                ""created"": ""2023-01-15T10:30:00.000Z"",
                ""lastUpdated"": ""2023-01-15T10:30:00.000Z"",
                ""conditions"": {{
                    ""expression"": {{
                        ""type"": ""urn:okta:expression:1.0"",
                        ""value"": ""user.department==\""Engineering\""""
                    }}
                }},
                ""actions"": {{
                    ""assignUserToGroups"": {{
                        ""groupIds"": [""{TestGroupId}"", ""{group2Id}"", ""{group3Id}""]
                    }}
                }}
            }}";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new GroupRuleApi(mockClient, new Configuration { BasePath = TestBasePath });

            var createRequest = new CreateGroupRuleRequest
            {
                Type = CreateGroupRuleRequest.TypeEnum.GroupRule,
                Name = "Multi-Group Rule",
                Conditions = new GroupRuleConditions
                {
                    Expression = new GroupRuleExpression
                    {
                        Type = "urn:okta:expression:1.0",
                        Value = "user.department==\"Engineering\""
                    }
                },
                Actions = new GroupRuleAction
                {
                    AssignUserToGroups = new GroupRuleGroupAssignment
                    {
                        GroupIds = [TestGroupId, group2Id, group3Id]
                    }
                }
            };

            // Act
            var result = await api.CreateGroupRuleAsync(createRequest);

            // Assert
            result.Should().NotBeNull();
            result.Actions.AssignUserToGroups.GroupIds.Should().HaveCount(3);
            result.Actions.AssignUserToGroups.GroupIds.Should().Contain(TestGroupId);
            result.Actions.AssignUserToGroups.GroupIds.Should().Contain(group2Id);
            result.Actions.AssignUserToGroups.GroupIds.Should().Contain(group3Id);
        }

        #endregion
    }
}
