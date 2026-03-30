// <copyright file="RoleDResourceSetBindingApiTests.cs" company="Okta, Inc">
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
    public class RoleDResourceSetBindingApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _resourceSetId = "iamoJDFKaJxGIr0oamd9g";
        private readonly string _roleId = "cr0Yq6IJxGIr0ouum0g3";
        private readonly string _roleLabel = "UserAdmin";

        private string BindingResponseJson => @"{
            ""id"": """ + _roleId + @""",
            ""_links"": {
                ""self"": { ""href"": ""https://test.okta.com/api/v1/iam/resource-sets/" + _resourceSetId + @"/bindings/" + _roleId + @""" },
                ""bindings"": { ""href"": ""https://test.okta.com/api/v1/iam/resource-sets/" + _resourceSetId + @"/bindings"" },
                ""resource-set"": { ""href"": ""https://test.okta.com/api/v1/iam/resource-sets/" + _resourceSetId + @""" }
            }
        }";

        #region Constructor Tests

        [Fact]
        public void Constructor_WithValidParameters_CreatesInstance()
        {
            var api = new RoleDResourceSetBindingApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            api.Should().NotBeNull();
        }

        [Fact]
        public void Constructor_WithNullClient_ThrowsArgumentNullException()
        {
            var act = () => new RoleDResourceSetBindingApi(null, new Configuration { BasePath = BaseUrl });
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
        {
            var act = () => new RoleDResourceSetBindingApi(new MockAsyncClient("{}"), null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Api_ImplementsIRoleDResourceSetBindingApi()
        {
            var api = new RoleDResourceSetBindingApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            api.Should().BeAssignableTo<IRoleDResourceSetBindingApi>();
        }

        #endregion

        #region CreateResourceSetBindingAsync Tests

        [Fact]
        public async Task CreateResourceSetBindingAsync_WithValidRequest_ReturnsEditResponse()
        {
            // Arrange
            var responseJson = @"{ ""_links"": {} }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleDResourceSetBindingApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new ResourceSetBindingCreateRequest
            {
                Role = _roleId,
                Members = new List<string> { "https://test.okta.com/api/v1/users/00u67vu6id9W0TE3Q5d7" }
            };

            // Act
            var result = await api.CreateResourceSetBindingAsync(_resourceSetId, request);

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/resource-sets/{resourceSetIdOrLabel}/bindings");
            mockClient.ReceivedPathParams["resourceSetIdOrLabel"].Should().Contain(_resourceSetId);
            mockClient.ReceivedBody.Should().Contain(_roleId);
        }

        [Fact]
        public async Task CreateResourceSetBindingAsync_WithNullResourceSetId_ThrowsApiException()
        {
            var api = new RoleDResourceSetBindingApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.CreateResourceSetBindingAsync(null, new ResourceSetBindingCreateRequest());

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*resourceSetIdOrLabel*");
        }

        [Fact]
        public async Task CreateResourceSetBindingAsync_WithNullBody_ThrowsApiException()
        {
            var api = new RoleDResourceSetBindingApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.CreateResourceSetBindingAsync(_resourceSetId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*instance*");
        }

        [Fact]
        public async Task CreateResourceSetBindingWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient(@"{ ""_links"": {} }");
            var api = new RoleDResourceSetBindingApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new ResourceSetBindingCreateRequest { Role = _roleId };

            var response = await api.CreateResourceSetBindingWithHttpInfoAsync(_resourceSetId, request);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        #endregion

        #region DeleteBindingAsync Tests

        [Fact]
        public async Task DeleteBindingAsync_WithId_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleDResourceSetBindingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteBindingAsync(_resourceSetId, _roleId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/resource-sets/{resourceSetIdOrLabel}/bindings/{roleIdOrLabel}");
            mockClient.ReceivedPathParams["resourceSetIdOrLabel"].Should().Contain(_resourceSetId);
            mockClient.ReceivedPathParams["roleIdOrLabel"].Should().Contain(_roleId);
        }

        [Fact]
        public async Task DeleteBindingAsync_WithLabel_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleDResourceSetBindingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteBindingAsync(_resourceSetId, _roleLabel);

            // Assert
            mockClient.ReceivedPathParams["roleIdOrLabel"].Should().Contain(_roleLabel);
        }

        [Fact]
        public async Task DeleteBindingAsync_WithNullResourceSetId_ThrowsApiException()
        {
            var api = new RoleDResourceSetBindingApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.DeleteBindingAsync(null, _roleId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*resourceSetIdOrLabel*");
        }

        [Fact]
        public async Task DeleteBindingAsync_WithNullRoleId_ThrowsApiException()
        {
            var api = new RoleDResourceSetBindingApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.DeleteBindingAsync(_resourceSetId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*roleIdOrLabel*");
        }

        [Fact]
        public async Task DeleteBindingWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleDResourceSetBindingApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.DeleteBindingWithHttpInfoAsync(_resourceSetId, _roleId);

            response.Should().NotBeNull();
        }

        #endregion

        #region GetBindingAsync Tests

        [Fact]
        public async Task GetBindingAsync_WithId_ReturnsBindingResponse()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BindingResponseJson);
            var api = new RoleDResourceSetBindingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetBindingAsync(_resourceSetId, _roleId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(_roleId);
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/resource-sets/{resourceSetIdOrLabel}/bindings/{roleIdOrLabel}");
            mockClient.ReceivedPathParams["resourceSetIdOrLabel"].Should().Contain(_resourceSetId);
            mockClient.ReceivedPathParams["roleIdOrLabel"].Should().Contain(_roleId);
        }

        [Fact]
        public async Task GetBindingAsync_WithLabel_ReturnsBindingResponse()
        {
            // Arrange
            var responseJson = @"{ ""id"": """ + _roleId + @""", ""_links"": {} }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleDResourceSetBindingApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetBindingAsync(_resourceSetId, _roleLabel);

            result.Should().NotBeNull();
            mockClient.ReceivedPathParams["roleIdOrLabel"].Should().Contain(_roleLabel);
        }

        [Fact]
        public async Task GetBindingAsync_WithNullResourceSetId_ThrowsApiException()
        {
            var api = new RoleDResourceSetBindingApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.GetBindingAsync(null, _roleId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*resourceSetIdOrLabel*");
        }

        [Fact]
        public async Task GetBindingAsync_WithNullRoleId_ThrowsApiException()
        {
            var api = new RoleDResourceSetBindingApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.GetBindingAsync(_resourceSetId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*roleIdOrLabel*");
        }

        [Fact]
        public async Task GetBindingWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient(BindingResponseJson);
            var api = new RoleDResourceSetBindingApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GetBindingWithHttpInfoAsync(_resourceSetId, _roleId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_roleId);
        }

        #endregion

        #region ListBindingsAsync Tests

        [Fact]
        public async Task ListBindingsAsync_WithResourceSetId_ReturnsBindings()
        {
            // Arrange
            var responseJson = @"{
                ""roles"": [
                    {
                        ""id"": """ + _roleId + @""",
                        ""_links"": {}
                    }
                ],
                ""_links"": {}
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleDResourceSetBindingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListBindingsAsync(_resourceSetId);

            // Assert
            result.Should().NotBeNull();
            result.Roles.Should().HaveCount(1);
            result.Roles[0].Id.Should().Be(_roleId);
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/resource-sets/{resourceSetIdOrLabel}/bindings");
            mockClient.ReceivedPathParams["resourceSetIdOrLabel"].Should().Contain(_resourceSetId);
        }

        [Fact]
        public async Task ListBindingsAsync_WithAfterParam_SetsQueryParam()
        {
            // Arrange
            var responseJson = @"{ ""roles"": [], ""_links"": {} }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleDResourceSetBindingApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ListBindingsAsync(_resourceSetId, after: "cursor123");

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain("cursor123");
        }

        [Fact]
        public async Task ListBindingsAsync_WithNullResourceSetId_ThrowsApiException()
        {
            var api = new RoleDResourceSetBindingApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.ListBindingsAsync(null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*resourceSetIdOrLabel*");
        }

        [Fact]
        public async Task ListBindingsWithHttpInfoAsync_ReturnsApiResponse()
        {
            var responseJson = @"{ ""roles"": [], ""_links"": {} }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleDResourceSetBindingApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListBindingsWithHttpInfoAsync(_resourceSetId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion
    }
}
