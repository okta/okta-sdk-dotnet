// <copyright file="ApplicationGroupsApiTests.cs" company="Okta, Inc">
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
    public class ApplicationGroupsApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private const string TestAppId = "0oa1gjh63g214q0Hq0g4";
        private const string TestGroupId = "00g1gjh63g214q0Hq0g5";

        #region AssignGroupToApplication Tests

        [Fact]
        public async Task AssignGroupToApplication_WithValidRequest_ReturnsAssignment()
        {
            var responseJson = @"{
                ""id"": ""00g1gjh63g214q0Hq0g5"",
                ""lastUpdated"": ""2023-01-15T12:00:00.000Z"",
                ""priority"": 0,
                ""profile"": {},
                ""_links"": {
                    ""app"": {
                        ""href"": ""https://test.okta.com/api/v1/apps/0oa1gjh63g214q0Hq0g4""
                    },
                    ""group"": {
                        ""href"": ""https://test.okta.com/api/v1/groups/00g1gjh63g214q0Hq0g5""
                    },
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/apps/0oa1gjh63g214q0Hq0g4/groups/00g1gjh63g214q0Hq0g5""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationGroupsApi(mockClient, new Configuration { BasePath = BaseUrl });
            var assignment = new ApplicationGroupAssignment { Priority = 0 };

            var result = await api.AssignGroupToApplicationAsync(TestAppId, TestGroupId, assignment);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestGroupId);
            result.Priority.Should().Be(0);
            result.Links.Should().NotBeNull();
            result.Links.App.Should().NotBeNull();
            result.Links.Group.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("groups");
            mockClient.ReceivedBody.Should().Contain("priority");
        }

        [Fact]
        public async Task AssignGroupToApplication_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationGroupsApi(mockClient, new Configuration { BasePath = BaseUrl });
            var assignment = new ApplicationGroupAssignment { Priority = 0 };

            await Assert.ThrowsAsync<ApiException>(() => api.AssignGroupToApplicationAsync(null, TestGroupId, assignment));
        }

        [Fact]
        public async Task AssignGroupToApplication_WithNullGroupId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationGroupsApi(mockClient, new Configuration { BasePath = BaseUrl });
            var assignment = new ApplicationGroupAssignment { Priority = 0 };

            await Assert.ThrowsAsync<ApiException>(() => api.AssignGroupToApplicationAsync(TestAppId, null, assignment));
        }

        [Fact]
        public async Task AssignGroupToApplicationWithHttpInfo_ReturnsHttpResponse()
        {
            var responseJson = @"{
                ""id"": ""00g1gjh63g214q0Hq0g5"",
                ""priority"": 0
            }";

            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" }
            };

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new ApplicationGroupsApi(mockClient, new Configuration { BasePath = BaseUrl });
            var assignment = new ApplicationGroupAssignment { Priority = 0 };

            var response = await api.AssignGroupToApplicationWithHttpInfoAsync(TestAppId, TestGroupId, assignment);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(TestGroupId);
            response.Headers.Should().ContainKey("Content-Type");
        }

        #endregion

        #region GetApplicationGroupAssignment Tests

        [Fact]
        public async Task GetApplicationGroupAssignment_WithValidIds_ReturnsAssignment()
        {
            var responseJson = @"{
                ""id"": ""00g1gjh63g214q0Hq0g5"",
                ""lastUpdated"": ""2023-01-15T12:00:00.000Z"",
                ""priority"": 0,
                ""profile"": {},
                ""_links"": {
                    ""app"": {
                        ""href"": ""https://test.okta.com/api/v1/apps/0oa1gjh63g214q0Hq0g4""
                    },
                    ""group"": {
                        ""href"": ""https://test.okta.com/api/v1/groups/00g1gjh63g214q0Hq0g5""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationGroupsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetApplicationGroupAssignmentAsync(TestAppId, TestGroupId);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestGroupId);
            result.Priority.Should().Be(0);
            result.Links.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("groups");
        }

        [Fact]
        public async Task GetApplicationGroupAssignment_WithExpandParameter_IncludesExpandInQuery()
        {
            var responseJson = @"{
                ""id"": ""00g1gjh63g214q0Hq0g5"",
                ""_embedded"": {
                    ""group"": {
                        ""id"": ""00g1gjh63g214q0Hq0g5"",
                        ""profile"": {
                            ""name"": ""Test Group""
                        }
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationGroupsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetApplicationGroupAssignmentAsync(TestAppId, TestGroupId, expand: "group");

            result.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams["expand"].Should().Contain("group");
        }

        [Fact]
        public async Task GetApplicationGroupAssignment_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationGroupsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.GetApplicationGroupAssignmentAsync(null, TestGroupId));
        }

        [Fact]
        public async Task GetApplicationGroupAssignment_WithNullGroupId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationGroupsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.GetApplicationGroupAssignmentAsync(TestAppId, null));
        }

        [Fact]
        public async Task GetApplicationGroupAssignmentWithHttpInfo_ReturnsHttpResponse()
        {
            var responseJson = @"{
                ""id"": ""00g1gjh63g214q0Hq0g5"",
                ""priority"": 0
            }";

            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" }
            };

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new ApplicationGroupsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GetApplicationGroupAssignmentWithHttpInfoAsync(TestAppId, TestGroupId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(TestGroupId);
        }

        #endregion

        #region ListApplicationGroupAssignments Tests

        [Fact]
        public async Task ListApplicationGroupAssignmentsWithHttpInfo_ReturnsAssignmentList()
        {
            var responseJson = @"[
                {
                    ""id"": ""00g1gjh63g214q0Hq0g5"",
                    ""priority"": 0
                },
                {
                    ""id"": ""00g2gjh63g214q0Hq0g6"",
                    ""priority"": 1
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationGroupsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListApplicationGroupAssignmentsWithHttpInfoAsync(TestAppId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().HaveCount(2);
            response.Data[0].Id.Should().Be("00g1gjh63g214q0Hq0g5");
            response.Data[1].Id.Should().Be("00g2gjh63g214q0Hq0g6");
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("groups");
        }

        [Fact]
        public async Task ListApplicationGroupAssignmentsWithHttpInfo_WithQueryParameter_IncludesQueryInUrl()
        {
            var responseJson = @"[{""id"": ""00g1gjh63g214q0Hq0g5""}]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationGroupsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.ListApplicationGroupAssignmentsWithHttpInfoAsync(TestAppId, q: "Engineering");

            mockClient.ReceivedQueryParams.Should().ContainKey("q");
            mockClient.ReceivedQueryParams["q"].Should().Contain("Engineering");
        }

        [Fact]
        public async Task ListApplicationGroupAssignmentsWithHttpInfo_WithPaginationParameters_IncludesPaginationInQuery()
        {
            var responseJson = @"[{""id"": ""00g1gjh63g214q0Hq0g5""}]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationGroupsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.ListApplicationGroupAssignmentsWithHttpInfoAsync(TestAppId, after: "cursor123", limit: 50);

            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain("cursor123");
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
        }

        [Fact]
        public async Task ListApplicationGroupAssignmentsWithHttpInfo_WithExpandParameter_IncludesExpandInQuery()
        {
            var responseJson = @"[{""id"": ""00g1gjh63g214q0Hq0g5""}]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationGroupsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.ListApplicationGroupAssignmentsWithHttpInfoAsync(TestAppId, expand: "group");

            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams["expand"].Should().Contain("group");
        }

        [Fact]
        public async Task ListApplicationGroupAssignmentsWithHttpInfo_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("[]");
            var api = new ApplicationGroupsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.ListApplicationGroupAssignmentsWithHttpInfoAsync(null));
        }

        #endregion

        #region UpdateGroupAssignmentToApplication Tests

        [Fact]
        public async Task UpdateGroupAssignmentToApplication_WithValidPatch_ReturnsUpdatedAssignment()
        {
            var responseJson = @"{
                ""id"": ""00g1gjh63g214q0Hq0g5"",
                ""priority"": 5,
                ""_links"": {
                    ""app"": {
                        ""href"": ""https://test.okta.com/api/v1/apps/0oa1gjh63g214q0Hq0g4""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new ApplicationGroupsApi(mockClient, new Configuration { BasePath = BaseUrl });
            var patchOperations = new List<JsonPatchOperation>
            {
                new JsonPatchOperation
                {
                    Op = "replace",
                    Path = "/priority",
                    Value = 5
                }
            };

            var result = await api.UpdateGroupAssignmentToApplicationAsync(TestAppId, TestGroupId, patchOperations);

            result.Should().NotBeNull();
            result.Id.Should().Be(TestGroupId);
            result.Priority.Should().Be(5);
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("groups");
            mockClient.ReceivedBody.Should().Contain("replace");
            mockClient.ReceivedBody.Should().Contain("priority");
        }

        [Fact]
        public async Task UpdateGroupAssignmentToApplication_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationGroupsApi(mockClient, new Configuration { BasePath = BaseUrl });
            var patchOperations = new List<JsonPatchOperation>();

            await Assert.ThrowsAsync<ApiException>(() => 
                api.UpdateGroupAssignmentToApplicationAsync(null, TestGroupId, patchOperations));
        }

        [Fact]
        public async Task UpdateGroupAssignmentToApplication_WithNullGroupId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ApplicationGroupsApi(mockClient, new Configuration { BasePath = BaseUrl });
            var patchOperations = new List<JsonPatchOperation>();

            await Assert.ThrowsAsync<ApiException>(() => 
                api.UpdateGroupAssignmentToApplicationAsync(TestAppId, null, patchOperations));
        }

        [Fact]
        public async Task UpdateGroupAssignmentToApplicationWithHttpInfo_ReturnsHttpResponse()
        {
            var responseJson = @"{
                ""id"": ""00g1gjh63g214q0Hq0g5"",
                ""priority"": 3
            }";

            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" }
            };

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new ApplicationGroupsApi(mockClient, new Configuration { BasePath = BaseUrl });
            var patchOperations = new List<JsonPatchOperation>
            {
                new JsonPatchOperation { Op = "replace", Path = "/priority", Value = 3 }
            };

            var response = await api.UpdateGroupAssignmentToApplicationWithHttpInfoAsync(TestAppId, TestGroupId, patchOperations);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Priority.Should().Be(3);
        }

        #endregion

        #region UnassignApplicationFromGroup Tests

        [Fact]
        public async Task UnassignApplicationFromGroup_WithValidIds_CompletesSuccessfully()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new ApplicationGroupsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await api.UnassignApplicationFromGroupAsync(TestAppId, TestGroupId);

            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("groups");
        }

        [Fact]
        public async Task UnassignApplicationFromGroup_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("");
            var api = new ApplicationGroupsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.UnassignApplicationFromGroupAsync(null, TestGroupId));
        }

        [Fact]
        public async Task UnassignApplicationFromGroup_WithNullGroupId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("");
            var api = new ApplicationGroupsApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.UnassignApplicationFromGroupAsync(TestAppId, null));
        }

        [Fact]
        public async Task UnassignApplicationFromGroupWithHttpInfo_ReturnsNoContentResponse()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new ApplicationGroupsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.UnassignApplicationFromGroupWithHttpInfoAsync(TestAppId, TestGroupId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("groups");
        }

        #endregion
    }
}
