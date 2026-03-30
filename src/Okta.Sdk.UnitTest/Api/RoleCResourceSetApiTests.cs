// <copyright file="RoleCResourceSetApiTests.cs" company="Okta, Inc">
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
    public class RoleCResourceSetApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _resourceSetId = "iamoJDFKaJxGIr0oamd9g";
        private readonly string _resourceSetLabel = "my-resource-set";

        #region Constructor Tests

        [Fact]
        public void Constructor_WithValidParameters_CreatesInstance()
        {
            var api = new RoleCResourceSetApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            api.Should().NotBeNull();
        }

        [Fact]
        public void Constructor_WithNullClient_ThrowsArgumentNullException()
        {
            var act = () => new RoleCResourceSetApi(null, new Configuration { BasePath = BaseUrl });
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
        {
            var act = () => new RoleCResourceSetApi(new MockAsyncClient("{}"), null);
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Api_ImplementsIRoleCResourceSetApi()
        {
            var api = new RoleCResourceSetApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });
            api.Should().BeAssignableTo<IRoleCResourceSetApi>();
        }

        #endregion

        #region CreateResourceSetAsync Tests

        [Fact]
        public async Task CreateResourceSetAsync_WithValidRequest_ReturnsResourceSet()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _resourceSetId + @""",
                ""label"": ""my-resource-set"",
                ""description"": ""A test resource set"",
                ""created"": ""2021-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2021-02-06T16:20:57.000Z"",
                ""_links"": {}
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleCResourceSetApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new CreateResourceSetRequest
            {
                Label = "my-resource-set",
                Description = "A test resource set",
                Resources = new List<string> { "https://test.okta.com/api/v1/groups" }
            };

            // Act
            var result = await api.CreateResourceSetAsync(request);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(_resourceSetId);
            result.Label.Should().Be("my-resource-set");
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/resource-sets");
            mockClient.ReceivedBody.Should().Contain("my-resource-set");
        }

        [Fact]
        public async Task CreateResourceSetAsync_WithNullRequest_ThrowsApiException()
        {
            var api = new RoleCResourceSetApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.CreateResourceSetAsync(null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*instance*");
        }

        [Fact]
        public async Task CreateResourceSetWithHttpInfoAsync_ReturnsApiResponse()
        {
            var responseJson = @"{
                ""id"": """ + _resourceSetId + @""",
                ""label"": ""my-resource-set"",
                ""created"": ""2021-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2021-02-06T16:20:57.000Z"",
                ""_links"": {}
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleCResourceSetApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new CreateResourceSetRequest { Label = "my-resource-set" };

            var response = await api.CreateResourceSetWithHttpInfoAsync(request);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_resourceSetId);
        }

        #endregion

        #region DeleteResourceSetAsync Tests

        [Fact]
        public async Task DeleteResourceSetAsync_WithId_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleCResourceSetApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteResourceSetAsync(_resourceSetId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/resource-sets/{resourceSetIdOrLabel}");
            mockClient.ReceivedPathParams["resourceSetIdOrLabel"].Should().Contain(_resourceSetId);
        }

        [Fact]
        public async Task DeleteResourceSetAsync_WithLabel_Succeeds()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleCResourceSetApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteResourceSetAsync(_resourceSetLabel);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/resource-sets/{resourceSetIdOrLabel}");
            mockClient.ReceivedPathParams["resourceSetIdOrLabel"].Should().Contain(_resourceSetLabel);
        }

        [Fact]
        public async Task DeleteResourceSetAsync_WithNullId_ThrowsApiException()
        {
            var api = new RoleCResourceSetApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.DeleteResourceSetAsync(null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*resourceSetIdOrLabel*");
        }

        [Fact]
        public async Task DeleteResourceSetWithHttpInfoAsync_ReturnsApiResponse()
        {
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new RoleCResourceSetApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.DeleteResourceSetWithHttpInfoAsync(_resourceSetId);

            response.Should().NotBeNull();
        }

        #endregion

        #region GetResourceSetAsync Tests

        [Fact]
        public async Task GetResourceSetAsync_WithId_ReturnsResourceSet()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _resourceSetId + @""",
                ""label"": ""my-resource-set"",
                ""description"": ""A test resource set"",
                ""created"": ""2021-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2021-02-06T16:20:57.000Z"",
                ""_links"": {}
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleCResourceSetApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetResourceSetAsync(_resourceSetId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(_resourceSetId);
            result.Label.Should().Be("my-resource-set");
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/resource-sets/{resourceSetIdOrLabel}");
            mockClient.ReceivedPathParams["resourceSetIdOrLabel"].Should().Contain(_resourceSetId);
        }

        [Fact]
        public async Task GetResourceSetAsync_WithLabel_ReturnsResourceSet()
        {
            // Arrange
            var responseJson = @"{
                ""id"": """ + _resourceSetId + @""",
                ""label"": """ + _resourceSetLabel + @""",
                ""created"": ""2021-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2021-02-06T16:20:57.000Z"",
                ""_links"": {}
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleCResourceSetApi(mockClient, new Configuration { BasePath = BaseUrl });

            var result = await api.GetResourceSetAsync(_resourceSetLabel);

            result.Should().NotBeNull();
            result.Label.Should().Be(_resourceSetLabel);
            mockClient.ReceivedPathParams["resourceSetIdOrLabel"].Should().Contain(_resourceSetLabel);
        }

        [Fact]
        public async Task GetResourceSetAsync_WithNullId_ThrowsApiException()
        {
            var api = new RoleCResourceSetApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.GetResourceSetAsync(null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*resourceSetIdOrLabel*");
        }

        [Fact]
        public async Task GetResourceSetWithHttpInfoAsync_ReturnsApiResponse()
        {
            var responseJson = @"{
                ""id"": """ + _resourceSetId + @""",
                ""label"": ""my-resource-set"",
                ""created"": ""2021-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2021-02-06T16:20:57.000Z"",
                ""_links"": {}
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleCResourceSetApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.GetResourceSetWithHttpInfoAsync(_resourceSetId);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Id.Should().Be(_resourceSetId);
        }

        #endregion

        #region ListResourceSetsAsync Tests

        [Fact]
        public async Task ListResourceSetsAsync_ReturnsResourceSets()
        {
            // Arrange
            var responseJson = @"{
                ""resource-sets"": [
                    {
                        ""id"": """ + _resourceSetId + @""",
                        ""label"": ""my-resource-set"",
                        ""created"": ""2021-02-06T16:20:57.000Z"",
                        ""lastUpdated"": ""2021-02-06T16:20:57.000Z"",
                        ""_links"": {}
                    }
                ],
                ""_links"": {}
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleCResourceSetApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListResourceSetsAsync();

            // Assert
            result.Should().NotBeNull();
            result._ResourceSets.Should().HaveCount(1);
            result._ResourceSets[0].Id.Should().Be(_resourceSetId);
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/resource-sets");
        }

        [Fact]
        public async Task ListResourceSetsAsync_WithAfterParam_SetsQueryParam()
        {
            // Arrange
            var responseJson = @"{ ""resource-sets"": [], ""_links"": {} }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleCResourceSetApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ListResourceSetsAsync(after: "cursor123");

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain("cursor123");
        }

        [Fact]
        public async Task ListResourceSetsWithHttpInfoAsync_ReturnsApiResponse()
        {
            var responseJson = @"{ ""resource-sets"": [] }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleCResourceSetApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ListResourceSetsWithHttpInfoAsync();

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        #region ReplaceResourceSetAsync Tests

        [Fact]
        public async Task ReplaceResourceSetAsync_WithValidRequest_ReturnsUpdatedResourceSet()
        {
            // Arrange
            var updatedLabel = "updated-resource-set";
            var responseJson = @"{
                ""id"": """ + _resourceSetId + @""",
                ""label"": """ + updatedLabel + @""",
                ""description"": ""Updated description"",
                ""created"": ""2021-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2022-01-01T00:00:00.000Z"",
                ""_links"": {}
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleCResourceSetApi(mockClient, new Configuration { BasePath = BaseUrl });
            var resourceSet = new ResourceSet();

            // Act
            var result = await api.ReplaceResourceSetAsync(_resourceSetId, resourceSet);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(_resourceSetId);
            result.Label.Should().Be(updatedLabel);
            mockClient.ReceivedPath.Should().Be("/api/v1/iam/resource-sets/{resourceSetIdOrLabel}");
            mockClient.ReceivedPathParams["resourceSetIdOrLabel"].Should().Contain(_resourceSetId);
        }

        [Fact]
        public async Task ReplaceResourceSetAsync_WithNullId_ThrowsApiException()
        {
            var api = new RoleCResourceSetApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.ReplaceResourceSetAsync(null, new ResourceSet());

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*resourceSetIdOrLabel*");
        }

        [Fact]
        public async Task ReplaceResourceSetAsync_WithNullBody_ThrowsApiException()
        {
            var api = new RoleCResourceSetApi(new MockAsyncClient("{}"), new Configuration { BasePath = BaseUrl });

            Func<Task> act = async () => await api.ReplaceResourceSetAsync(_resourceSetId, null);

            await act.Should().ThrowAsync<ApiException>().WithMessage("*Missing required parameter*instance*");
        }

        [Fact]
        public async Task ReplaceResourceSetWithHttpInfoAsync_ReturnsApiResponse()
        {
            var responseJson = @"{
                ""id"": """ + _resourceSetId + @""",
                ""label"": ""updated-set"",
                ""created"": ""2021-02-06T16:20:57.000Z"",
                ""lastUpdated"": ""2022-01-01T00:00:00.000Z"",
                ""_links"": {}
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new RoleCResourceSetApi(mockClient, new Configuration { BasePath = BaseUrl });

            var response = await api.ReplaceResourceSetWithHttpInfoAsync(_resourceSetId, new ResourceSet());

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        #endregion
    }
}
