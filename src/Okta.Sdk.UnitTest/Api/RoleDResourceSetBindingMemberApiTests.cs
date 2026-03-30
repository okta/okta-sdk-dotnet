// <copyright file="RoleDResourceSetBindingMemberApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
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
    public class RoleDResourceSetBindingMemberApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _resourceSetId = "iamoJDFKaJxGIr0oamd9g";
        private readonly string _roleId = "cr0Yq6IJxGIr0ouum0g3";
        private readonly string _memberId = "irb1qe6PGuMc7Oh8N0g4";

        private string MemberJson => @"{
            ""id"": """ + _memberId + @""",
            ""created"": ""2021-02-06T16:20:57.000Z"",
            ""lastUpdated"": ""2021-02-06T16:20:57.000Z"",
            ""_links"": {
                ""self"": { ""href"": ""https://test.okta.com/api/v1/users/00u67vu6id9W0TE3Q5d7"" }
            }
        }";

        #region Constructor Tests

        [Fact]
        public void Constructor_WithValidParameters_CreatesInstance()
        {
            var api = new RoleDResourceSetBindingMemberApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            api.Should().NotBeNull();
        }

        [Fact]
        public void Constructor_WithNullClient_ThrowsArgumentNullException()
        {
            var act = () => new RoleDResourceSetBindingMemberApi(null, new Configuration { BasePath = BaseUrl });
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
        {
            var act = () => new RoleDResourceSetBindingMemberApi(new MockAsyncClient("{}"), null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Api_ImplementsIRoleDResourceSetBindingMemberApi()
        {
            var api = new RoleDResourceSetBindingMemberApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            api.Should().BeAssignableTo<IRoleDResourceSetBindingMemberApi>();
        }

        #endregion

        #region AddMembersToBindingAsync Tests

        [Fact]
        public async Task AddMembersToBindingAsync_WithValidRequest_ReturnsEditResponse()
        {
            // Arrange
            var responseJson = @"{ ""_links"": {} }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleDResourceSetBindingMemberApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new ResourceSetBindingAddMembersRequest
            {
                Additions = new List<string> { "https://test.okta.com/api/v1/users/00u67vu6id9W0TE3Q5d7" }
            };

            // Act
            var result = await api.AddMembersToBindingAsync(_resourceSetId, _roleId, request);

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/resource-sets/{resourceSetIdOrLabel}/bindings/{roleIdOrLabel}/members");
            mockClient.ReceivedPathParams["resourceSetIdOrLabel"].Should().Contain(_resourceSetId);
            mockClient.ReceivedPathParams["roleIdOrLabel"].Should().Contain(_roleId);
        }

        [Fact]
        public async Task AddMembersToBindingAsync_WithNullResourceSetId_ThrowsApiException()
        {
            var api = new RoleDResourceSetBindingMemberApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AddMembersToBindingAsync(null, _roleId, new ResourceSetBindingAddMembersRequest());

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*resourceSetIdOrLabel*");
        }

        [Fact]
        public async Task AddMembersToBindingAsync_WithNullRoleId_ThrowsApiException()
        {
            var api = new RoleDResourceSetBindingMemberApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AddMembersToBindingAsync(_resourceSetId, null, new ResourceSetBindingAddMembersRequest());

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*roleIdOrLabel*");
        }

        [Fact]
        public async Task AddMembersToBindingAsync_WithNullBody_ThrowsApiException()
        {
            var api = new RoleDResourceSetBindingMemberApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AddMembersToBindingAsync(_resourceSetId, _roleId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*instance*");
        }

        [Fact]
        public async Task AddMembersToBindingWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient(@"{ ""_links"": {} }");
            var api = new RoleDResourceSetBindingMemberApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new ResourceSetBindingAddMembersRequest { Additions = new List<string>() };

            var response = await api.AddMembersToBindingWithHttpInfoAsync(_resourceSetId, _roleId, request);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        #endregion

        #region GetMemberOfBindingAsync Tests

        [Fact]
        public async Task GetMemberOfBindingAsync_WithValidParams_ReturnsMember()
        {
            // Arrange
            var mockClient = new MockAsyncClient(MemberJson);
            var api = new RoleDResourceSetBindingMemberApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetMemberOfBindingAsync(_resourceSetId, _roleId, _memberId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(_memberId);
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/resource-sets/{resourceSetIdOrLabel}/bindings/{roleIdOrLabel}/members/{memberId}");
            mockClient.ReceivedPathParams["resourceSetIdOrLabel"].Should().Contain(_resourceSetId);
            mockClient.ReceivedPathParams["roleIdOrLabel"].Should().Contain(_roleId);
            mockClient.ReceivedPathParams["memberId"].Should().Contain(_memberId);
        }

        [Fact]
        public async Task GetMemberOfBindingAsync_WithNullResourceSetId_ThrowsApiException()
        {
            var api = new RoleDResourceSetBindingMemberApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.GetMemberOfBindingAsync(null, _roleId, _memberId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*resourceSetIdOrLabel*");
        }

        [Fact]
        public async Task GetMemberOfBindingAsync_WithNullRoleId_ThrowsApiException()
        {
            var api = new RoleDResourceSetBindingMemberApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.GetMemberOfBindingAsync(_resourceSetId, null, _memberId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*roleIdOrLabel*");
        }

        [Fact]
        public async Task GetMemberOfBindingAsync_WithNullMemberId_ThrowsApiException()
        {
            var api = new RoleDResourceSetBindingMemberApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.GetMemberOfBindingAsync(_resourceSetId, _roleId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*memberId*");
        }

        [Fact]
        public async Task GetMemberOfBindingWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient(MemberJson);
            var api = new RoleDResourceSetBindingMemberApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GetMemberOfBindingWithHttpInfoAsync(_resourceSetId, _roleId, _memberId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_memberId);
        }

        #endregion

        #region ListMembersOfBindingAsync Tests

        [Fact]
        public async Task ListMembersOfBindingAsync_WithValidParams_ReturnsMembers()
        {
            // Arrange
            var responseJson = @"{
                ""members"": [
                    {
                        ""id"": """ + _memberId + @""",
                        ""created"": ""2021-02-06T16:20:57.000Z"",
                        ""lastUpdated"": ""2021-02-06T16:20:57.000Z"",
                        ""_links"": { ""self"": { ""href"": ""https://test.okta.com/api/v1/users/00u67vu6id9W0TE3Q5d7"" } }
                    }
                ],
                ""_links"": {}
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleDResourceSetBindingMemberApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListMembersOfBindingAsync(_resourceSetId, _roleId);

            // Assert
            result.Should().NotBeNull();
            result.Members.Should().HaveCount(1);
            result.Members[0].Id.Should().Be(_memberId);
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/resource-sets/{resourceSetIdOrLabel}/bindings/{roleIdOrLabel}/members");
            mockClient.ReceivedPathParams["resourceSetIdOrLabel"].Should().Contain(_resourceSetId);
            mockClient.ReceivedPathParams["roleIdOrLabel"].Should().Contain(_roleId);
        }

        [Fact]
        public async Task ListMembersOfBindingAsync_WithAfterParam_SetsQueryParam()
        {
            // Arrange
            var responseJson = @"{ ""members"": [], ""_links"": {} }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleDResourceSetBindingMemberApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ListMembersOfBindingAsync(_resourceSetId, _roleId, after: "cursor123");

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain("cursor123");
        }

        [Fact]
        public async Task ListMembersOfBindingAsync_WithNullResourceSetId_ThrowsApiException()
        {
            var api = new RoleDResourceSetBindingMemberApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.ListMembersOfBindingAsync(null, _roleId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*resourceSetIdOrLabel*");
        }

        [Fact]
        public async Task ListMembersOfBindingAsync_WithNullRoleId_ThrowsApiException()
        {
            var api = new RoleDResourceSetBindingMemberApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.ListMembersOfBindingAsync(_resourceSetId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*roleIdOrLabel*");
        }

        [Fact]
        public async Task ListMembersOfBindingWithHttpInfoAsync_ReturnsApiResponse()
        {
            var responseJson = @"{ ""members"": [], ""_links"": {} }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleDResourceSetBindingMemberApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListMembersOfBindingWithHttpInfoAsync(_resourceSetId, _roleId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        #region UnassignMemberFromBindingAsync Tests

        [Fact]
        public async Task UnassignMemberFromBindingAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleDResourceSetBindingMemberApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.UnassignMemberFromBindingAsync(_resourceSetId, _roleId, _memberId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/resource-sets/{resourceSetIdOrLabel}/bindings/{roleIdOrLabel}/members/{memberId}");
            mockClient.ReceivedPathParams["resourceSetIdOrLabel"].Should().Contain(_resourceSetId);
            mockClient.ReceivedPathParams["roleIdOrLabel"].Should().Contain(_roleId);
            mockClient.ReceivedPathParams["memberId"].Should().Contain(_memberId);
        }

        [Fact]
        public async Task UnassignMemberFromBindingAsync_WithNullResourceSetId_ThrowsApiException()
        {
            var api = new RoleDResourceSetBindingMemberApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.UnassignMemberFromBindingAsync(null, _roleId, _memberId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*resourceSetIdOrLabel*");
        }

        [Fact]
        public async Task UnassignMemberFromBindingAsync_WithNullRoleId_ThrowsApiException()
        {
            var api = new RoleDResourceSetBindingMemberApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.UnassignMemberFromBindingAsync(_resourceSetId, null, _memberId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*roleIdOrLabel*");
        }

        [Fact]
        public async Task UnassignMemberFromBindingAsync_WithNullMemberId_ThrowsApiException()
        {
            var api = new RoleDResourceSetBindingMemberApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.UnassignMemberFromBindingAsync(_resourceSetId, _roleId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*memberId*");
        }

        [Fact]
        public async Task UnassignMemberFromBindingWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleDResourceSetBindingMemberApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.UnassignMemberFromBindingWithHttpInfoAsync(_resourceSetId, _roleId, _memberId);

            response.Should().NotBeNull();
        }

        #endregion
    }
}
