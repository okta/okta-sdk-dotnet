// <copyright file="RoleCResourceSetResourceApiTests.cs" company="Okta, Inc">
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
    public class RoleCResourceSetResourceApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _resourceSetId = "iamoJDFKaJxGIr0oamd9g";
        private readonly string _resourceId = "ire106sIndex83Ol0g5";

        private string ResourceJson => @"{
            ""id"": """ + _resourceId + @""",
            ""orn"": ""orn:okta:directory:00o67vu6id9W0TE3Q5d7:groups"",
            ""created"": ""2021-06-04T22:23:52.000Z"",
            ""lastUpdated"": ""2021-06-04T22:23:52.000Z"",
            ""_links"": {}
        }";

        #region Constructor Tests

        [Fact]
        public void Constructor_WithValidParameters_CreatesInstance()
        {
            var api = new RoleCResourceSetResourceApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            api.Should().NotBeNull();
        }

        [Fact]
        public void Constructor_WithNullClient_ThrowsArgumentNullException()
        {
            var act = () => new RoleCResourceSetResourceApi(null, new Configuration { BasePath = BaseUrl });
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
        {
            var act = () => new RoleCResourceSetResourceApi(new MockAsyncClient("{}"), null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Api_ImplementsIRoleCResourceSetResourceApi()
        {
            var api = new RoleCResourceSetResourceApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            api.Should().BeAssignableTo<IRoleCResourceSetResourceApi>();
        }

        #endregion

        #region AddResourceSetResourceAsync Tests

        [Fact]
        public async Task AddResourceSetResourceAsync_WithValidRequest_ReturnsResourceSetResource()
        {
            // Arrange
            var mockClient = new MockAsyncClient(ResourceJson);
            var api = new RoleCResourceSetResourceApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new ResourceSetResourcePostRequest
            {
                ResourceOrnOrUrl = "https://test.okta.com/api/v1/groups/00guaxWZ0AOa5rnZS0g3"
            };

            // Act
            var result = await api.AddResourceSetResourceAsync(_resourceSetId, request);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(_resourceId);
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/resource-sets/{resourceSetIdOrLabel}/resources");
            mockClient.ReceivedPathParams["resourceSetIdOrLabel"].Should().Contain(_resourceSetId);
        }

        [Fact]
        public async Task AddResourceSetResourceAsync_WithNullResourceSetId_ThrowsApiException()
        {
            var api = new RoleCResourceSetResourceApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AddResourceSetResourceAsync(null, new ResourceSetResourcePostRequest());

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*resourceSetIdOrLabel*");
        }

        [Fact]
        public async Task AddResourceSetResourceAsync_WithNullBody_ThrowsApiException()
        {
            var api = new RoleCResourceSetResourceApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AddResourceSetResourceAsync(_resourceSetId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*instance*");
        }

        [Fact]
        public async Task AddResourceSetResourceWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient(ResourceJson);
            var api = new RoleCResourceSetResourceApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new ResourceSetResourcePostRequest { ResourceOrnOrUrl = "https://test.okta.com/api/v1/groups" };

            var response = await api.AddResourceSetResourceWithHttpInfoAsync(_resourceSetId, request);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_resourceId);
        }

        #endregion

        #region AddResourceSetResourcesAsync Tests

        [Fact]
        public async Task AddResourceSetResourcesAsync_WithValidRequest_ReturnsResourceSet()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _resourceSetId + @""",
                ""label"": ""my-resource-set"",
                ""created"": ""2021-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2021-06-04T22:23:52.000Z"",
                ""_links"": {}
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleCResourceSetResourceApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new ResourceSetResourcePatchRequest
            {
                Additions = new List<string> { "https://test.okta.com/api/v1/groups/00guaxWZ0AOa5rnZS0g3" }
            };

            // Act
            var result = await api.AddResourceSetResourcesAsync(_resourceSetId, request);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(_resourceSetId);
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/resource-sets/{resourceSetIdOrLabel}/resources");
            mockClient.ReceivedPathParams["resourceSetIdOrLabel"].Should().Contain(_resourceSetId);
        }

        [Fact]
        public async Task AddResourceSetResourcesAsync_WithNullResourceSetId_ThrowsApiException()
        {
            var api = new RoleCResourceSetResourceApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AddResourceSetResourcesAsync(null, new ResourceSetResourcePatchRequest());

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*resourceSetIdOrLabel*");
        }

        [Fact]
        public async Task AddResourceSetResourcesAsync_WithNullBody_ThrowsApiException()
        {
            var api = new RoleCResourceSetResourceApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.AddResourceSetResourcesAsync(_resourceSetId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*instance*");
        }

        [Fact]
        public async Task AddResourceSetResourcesWithHttpInfoAsync_ReturnsApiResponse()
        {
            var responseJson = @"{
                ""id"": """ + _resourceSetId + @""",
                ""label"": ""my-resource-set"",
                ""created"": ""2021-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2021-06-04T22:23:52.000Z"",
                ""_links"": {}
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleCResourceSetResourceApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.AddResourceSetResourcesWithHttpInfoAsync(
                _resourceSetId, new ResourceSetResourcePatchRequest { Additions = new List<string>() });

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        #region DeleteResourceSetResourceAsync Tests

        [Fact]
        public async Task DeleteResourceSetResourceAsync_WithValidParams_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleCResourceSetResourceApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteResourceSetResourceAsync(_resourceSetId, _resourceId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/resource-sets/{resourceSetIdOrLabel}/resources/{resourceId}");
            mockClient.ReceivedPathParams["resourceSetIdOrLabel"].Should().Contain(_resourceSetId);
            mockClient.ReceivedPathParams["resourceId"].Should().Contain(_resourceId);
        }

        [Fact]
        public async Task DeleteResourceSetResourceAsync_WithNullResourceSetId_ThrowsApiException()
        {
            var api = new RoleCResourceSetResourceApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.DeleteResourceSetResourceAsync(null, _resourceId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*resourceSetIdOrLabel*");
        }

        [Fact]
        public async Task DeleteResourceSetResourceAsync_WithNullResourceId_ThrowsApiException()
        {
            var api = new RoleCResourceSetResourceApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.DeleteResourceSetResourceAsync(_resourceSetId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*resourceId*");
        }

        [Fact]
        public async Task DeleteResourceSetResourceWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleCResourceSetResourceApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.DeleteResourceSetResourceWithHttpInfoAsync(_resourceSetId, _resourceId);

            response.Should().NotBeNull();
        }

        #endregion

        #region GetResourceSetResourceAsync Tests

        [Fact]
        public async Task GetResourceSetResourceAsync_WithValidParams_ReturnsResourceSetResource()
        {
            // Arrange
            var mockClient = new MockAsyncClient(ResourceJson);
            var api = new RoleCResourceSetResourceApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetResourceSetResourceAsync(_resourceSetId, _resourceId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(_resourceId);
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/resource-sets/{resourceSetIdOrLabel}/resources/{resourceId}");
            mockClient.ReceivedPathParams["resourceSetIdOrLabel"].Should().Contain(_resourceSetId);
            mockClient.ReceivedPathParams["resourceId"].Should().Contain(_resourceId);
        }

        [Fact]
        public async Task GetResourceSetResourceAsync_WithNullResourceSetId_ThrowsApiException()
        {
            var api = new RoleCResourceSetResourceApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.GetResourceSetResourceAsync(null, _resourceId);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*resourceSetIdOrLabel*");
        }

        [Fact]
        public async Task GetResourceSetResourceAsync_WithNullResourceId_ThrowsApiException()
        {
            var api = new RoleCResourceSetResourceApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.GetResourceSetResourceAsync(_resourceSetId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*resourceId*");
        }

        [Fact]
        public async Task GetResourceSetResourceWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient(ResourceJson);
            var api = new RoleCResourceSetResourceApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GetResourceSetResourceWithHttpInfoAsync(_resourceSetId, _resourceId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_resourceId);
        }

        #endregion

        #region ListResourceSetResourcesAsync Tests

        [Fact]
        public async Task ListResourceSetResourcesAsync_WithValidId_ReturnsResourceSetResources()
        {
            // Arrange
            var responseJson = @"{
                ""resources"": [
                    {
                        ""id"": """ + _resourceId + @""",
                        ""orn"": ""orn:okta:directory:00o67vu6id9W0TE3Q5d7:groups"",
                        ""created"": ""2021-06-04T22:23:52.000Z"",
                        ""lastUpdated"": ""2021-06-04T22:23:52.000Z"",
                        ""_links"": {}
                    }
                ],
                ""_links"": {}
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleCResourceSetResourceApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListResourceSetResourcesAsync(_resourceSetId);

            // Assert
            result.Should().NotBeNull();
            result.Resources.Should().HaveCount(1);
            result.Resources[0].Id.Should().Be(_resourceId);
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/resource-sets/{resourceSetIdOrLabel}/resources");
            mockClient.ReceivedPathParams["resourceSetIdOrLabel"].Should().Contain(_resourceSetId);
        }

        [Fact]
        public async Task ListResourceSetResourcesAsync_WithNullResourceSetId_ThrowsApiException()
        {
            var api = new RoleCResourceSetResourceApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.ListResourceSetResourcesAsync(null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*resourceSetIdOrLabel*");
        }

        [Fact]
        public async Task ListResourceSetResourcesWithHttpInfoAsync_ReturnsApiResponse()
        {
            var responseJson = @"{ ""resources"": [], ""_links"": {} }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleCResourceSetResourceApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListResourceSetResourcesWithHttpInfoAsync(_resourceSetId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        #region ReplaceResourceSetResourceAsync Tests

        [Fact]
        public async Task ReplaceResourceSetResourceAsync_WithValidParams_ReturnsUpdatedResource()
        {
            // Arrange
            var mockClient = new MockAsyncClient(ResourceJson);
            var api = new RoleCResourceSetResourceApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new ResourceSetResourcePutRequest();

            // Act
            var result = await api.ReplaceResourceSetResourceAsync(_resourceSetId, _resourceId, request);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(_resourceId);
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/resource-sets/{resourceSetIdOrLabel}/resources/{resourceId}");
            mockClient.ReceivedPathParams["resourceSetIdOrLabel"].Should().Contain(_resourceSetId);
            mockClient.ReceivedPathParams["resourceId"].Should().Contain(_resourceId);
        }

        [Fact]
        public async Task ReplaceResourceSetResourceAsync_WithNullResourceSetId_ThrowsApiException()
        {
            var api = new RoleCResourceSetResourceApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.ReplaceResourceSetResourceAsync(null, _resourceId, new ResourceSetResourcePutRequest());

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*resourceSetIdOrLabel*");
        }

        [Fact]
        public async Task ReplaceResourceSetResourceAsync_WithNullResourceId_ThrowsApiException()
        {
            var api = new RoleCResourceSetResourceApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.ReplaceResourceSetResourceAsync(_resourceSetId, null, new ResourceSetResourcePutRequest());

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*resourceId*");
        }

        [Fact]
        public async Task ReplaceResourceSetResourceAsync_WithNullBody_ThrowsApiException()
        {
            var api = new RoleCResourceSetResourceApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.ReplaceResourceSetResourceAsync(_resourceSetId, _resourceId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*resourceSetResourcePutRequest*");
        }

        [Fact]
        public async Task ReplaceResourceSetResourceWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient(ResourceJson);
            var api = new RoleCResourceSetResourceApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ReplaceResourceSetResourceWithHttpInfoAsync(_resourceSetId, _resourceId, new ResourceSetResourcePutRequest());

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_resourceId);
        }

        #endregion
    }
}
