// <copyright file="IdentityProviderApiTests.cs" company="Okta, Inc">
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
    /// <summary>
    /// Comprehensive unit tests for <see cref="IdentityProviderApi"/>.
    /// </summary>
    public class IdentityProviderApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private const string TestIdpId = "0oa1k5d68qR2954hb0g4";

        private static string BuildIdpJson(string id = TestIdpId, string name = "Test IdP", string status = "ACTIVE", string type = "GOOGLE") =>
            $@"{{
                ""id"": ""{id}"",
                ""name"": ""{name}"",
                ""status"": ""{status}"",
                ""type"": ""{type}"",
                ""created"": ""2024-01-01T00:00:00.000Z"",
                ""lastUpdated"": ""2024-01-01T00:00:00.000Z""
            }}";

        #region ActivateIdentityProvider Tests

        [Fact]
        public async Task ActivateIdentityProvider_WithValidId_ReturnsActivatedIdp()
        {
            // Arrange
            var responseJson = BuildIdpJson(status: "ACTIVE");
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ActivateIdentityProviderAsync(TestIdpId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(TestIdpId);
            result.Status.Should().Be(LifecycleStatus.ACTIVE);
            mockClient.ReceivedPath.Should().StartWith("/api/v1/idps/{idpId}/lifecycle/activate");
            mockClient.ReceivedPathParams.Should().ContainKey("idpId");
            mockClient.ReceivedPathParams["idpId"].Should().Contain(TestIdpId);
        }

        [Fact]
        public async Task ActivateIdentityProvider_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ActivateIdentityProviderAsync(null));
        }

        [Fact]
        public async Task ActivateIdentityProviderWithHttpInfo_WithValidId_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = BuildIdpJson(status: "ACTIVE");
            var headers = new Multimap<string, string> { { "Content-Type", "application/json" } };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ActivateIdentityProviderWithHttpInfoAsync(TestIdpId);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be(TestIdpId);
            result.Headers.Should().ContainKey("Content-Type");
        }

        [Fact]
        public async Task ActivateIdentityProviderWithHttpInfo_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ActivateIdentityProviderWithHttpInfoAsync(null));
        }

        #endregion

        #region CreateIdentityProvider Tests

        [Fact]
        public async Task CreateIdentityProvider_WithValidBody_ReturnsCreatedIdp()
        {
            // Arrange
            var responseJson = BuildIdpJson(type: "GOOGLE");
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            var newIdp = new IdentityProvider
            {
                Name = "Test IdP",
                Type = "GOOGLE"
            };

            // Act
            var result = await api.CreateIdentityProviderAsync(newIdp);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(TestIdpId);
            mockClient.ReceivedPath.Should().Be("/api/v1/idps");
            mockClient.ReceivedBody.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task CreateIdentityProvider_WithNullBody_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.CreateIdentityProviderAsync(null));
        }

        [Fact]
        public async Task CreateIdentityProviderWithHttpInfo_WithValidBody_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = BuildIdpJson();
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            var newIdp = new IdentityProvider { Name = "Test IdP", Type = "GOOGLE" };

            // Act
            var result = await api.CreateIdentityProviderWithHttpInfoAsync(newIdp);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be(TestIdpId);
            mockClient.ReceivedPath.Should().Be("/api/v1/idps");
        }

        [Fact]
        public async Task CreateIdentityProviderWithHttpInfo_WithNullBody_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.CreateIdentityProviderWithHttpInfoAsync(null));
        }

        #endregion

        #region DeactivateIdentityProvider Tests

        [Fact]
        public async Task DeactivateIdentityProvider_WithValidId_ReturnsDeactivatedIdp()
        {
            // Arrange
            var responseJson = BuildIdpJson(status: "INACTIVE");
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.DeactivateIdentityProviderAsync(TestIdpId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(TestIdpId);
            result.Status.Should().Be(LifecycleStatus.INACTIVE);
            mockClient.ReceivedPath.Should().StartWith("/api/v1/idps/{idpId}/lifecycle/deactivate");
            mockClient.ReceivedPathParams["idpId"].Should().Contain(TestIdpId);
        }

        [Fact]
        public async Task DeactivateIdentityProvider_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeactivateIdentityProviderAsync(null));
        }

        [Fact]
        public async Task DeactivateIdentityProviderWithHttpInfo_WithValidId_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = BuildIdpJson(status: "INACTIVE");
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.DeactivateIdentityProviderWithHttpInfoAsync(TestIdpId);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Status.Should().Be(LifecycleStatus.INACTIVE);
        }

        [Fact]
        public async Task DeactivateIdentityProviderWithHttpInfo_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeactivateIdentityProviderWithHttpInfoAsync(null));
        }

        #endregion

        #region DeleteIdentityProvider Tests

        [Fact]
        public async Task DeleteIdentityProvider_WithValidId_CompletesSuccessfully()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteIdentityProviderAsync(TestIdpId);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/idps/{idpId}");
            mockClient.ReceivedPathParams.Should().ContainKey("idpId");
            mockClient.ReceivedPathParams["idpId"].Should().Contain(TestIdpId);
        }

        [Fact]
        public async Task DeleteIdentityProvider_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeleteIdentityProviderAsync(null));
        }

        [Fact]
        public async Task DeleteIdentityProviderWithHttpInfo_WithValidId_ReturnsApiResponse()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.DeleteIdentityProviderWithHttpInfoAsync(TestIdpId);

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedPath.Should().StartWith("/api/v1/idps/{idpId}");
        }

        [Fact]
        public async Task DeleteIdentityProviderWithHttpInfo_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeleteIdentityProviderWithHttpInfoAsync(null));
        }

        #endregion

        #region GetIdentityProvider Tests

        [Fact]
        public async Task GetIdentityProvider_WithValidId_ReturnsIdp()
        {
            // Arrange
            var responseJson = BuildIdpJson();
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetIdentityProviderAsync(TestIdpId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(TestIdpId);
            result.Name.Should().Be("Test IdP");
            mockClient.ReceivedPath.Should().StartWith("/api/v1/idps/{idpId}");
            mockClient.ReceivedPathParams.Should().ContainKey("idpId");
            mockClient.ReceivedPathParams["idpId"].Should().Contain(TestIdpId);
        }

        [Fact]
        public async Task GetIdentityProvider_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetIdentityProviderAsync(null));
        }

        [Fact]
        public async Task GetIdentityProviderWithHttpInfo_WithValidId_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = BuildIdpJson();
            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" },
                { "X-Rate-Limit-Remaining", "99" }
            };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetIdentityProviderWithHttpInfoAsync(TestIdpId);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be(TestIdpId);
            result.Headers.Should().ContainKey("Content-Type");
            result.Headers.Should().ContainKey("X-Rate-Limit-Remaining");
        }

        [Fact]
        public async Task GetIdentityProviderWithHttpInfo_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetIdentityProviderWithHttpInfoAsync(null));
        }

        #endregion

        #region ListIdentityProviders Tests

        [Fact]
        public async Task ListIdentityProviders_WithNoParams_ReturnsCollection()
        {
            // Arrange
            var responseJson = $"[{BuildIdpJson()}, {BuildIdpJson("0oa2k5d68qR2954hb0g5", "Second IdP")}]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListIdentityProvidersWithHttpInfoAsync();

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
            result.Data[0].Id.Should().Be(TestIdpId);
            result.Data[1].Id.Should().Be("0oa2k5d68qR2954hb0g5");
            mockClient.ReceivedPath.Should().Be("/api/v1/idps");
        }

        [Fact]
        public async Task ListIdentityProviders_WithQueryParam_SendsCorrectQueryParam()
        {
            // Arrange
            var responseJson = $"[{BuildIdpJson()}]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListIdentityProvidersWithHttpInfoAsync(q: "Test", limit: 25);

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().ContainKey("q");
            mockClient.ReceivedQueryParams["q"].Should().Contain("Test");
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain("25");
        }

        [Fact]
        public async Task ListIdentityProviders_WithTypeFilter_SendsTypeParam()
        {
            // Arrange
            var responseJson = $"[{BuildIdpJson(type: "SAML2")}]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListIdentityProvidersWithHttpInfoAsync(type: "SAML2");

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().ContainKey("type");
            mockClient.ReceivedQueryParams["type"].Should().Contain("SAML2");
        }

        [Fact]
        public async Task ListIdentityProviders_WithAfterCursor_SendsAfterParam()
        {
            // Arrange
            var afterCursor = "cursor-abc123";
            var responseJson = $"[{BuildIdpJson()}]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListIdentityProvidersWithHttpInfoAsync(after: afterCursor);

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain(afterCursor);
        }

        [Fact]
        public async Task ListIdentityProvidersWithHttpInfo_WithValidParams_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = $"[{BuildIdpJson()}, {BuildIdpJson("0oa2k5d68qR2954hb0g5", "Another IdP")}]";
            var headers = new Multimap<string, string> { { "Link", "<https://test.okta.com/api/v1/idps?after=next>; rel=\"next\"" } };
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK, headers);
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListIdentityProvidersWithHttpInfoAsync();

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().HaveCount(2);
            result.Headers.Should().ContainKey("Link");
        }

        [Fact]
        public async Task ListIdentityProvidersWithHttpInfo_WithQueryParams_SendsCorrectParams()
        {
            // Arrange
            var responseJson = $"[{BuildIdpJson()}]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListIdentityProvidersWithHttpInfoAsync(q: "SAML", limit: 10, type: "SAML2");

            // Assert
            result.Data.Should().HaveCount(1);
            mockClient.ReceivedQueryParams.Should().ContainKey("q");
            mockClient.ReceivedQueryParams["q"].Should().Contain("SAML");
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain("10");
            mockClient.ReceivedQueryParams.Should().ContainKey("type");
            mockClient.ReceivedQueryParams["type"].Should().Contain("SAML2");
        }

        #endregion

        #region ReplaceIdentityProvider Tests

        [Fact]
        public async Task ReplaceIdentityProvider_WithValidIdAndBody_ReturnsUpdatedIdp()
        {
            // Arrange
            var updatedName = "Updated IdP";
            var responseJson = BuildIdpJson(name: updatedName);
            var mockClient = new MockAsyncClient(responseJson);
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updatedIdp = new IdentityProvider
            {
                Name = updatedName,
                Type = "GOOGLE"
            };

            // Act
            var result = await api.ReplaceIdentityProviderAsync(TestIdpId, updatedIdp);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(TestIdpId);
            result.Name.Should().Be(updatedName);
            mockClient.ReceivedPath.Should().StartWith("/api/v1/idps/{idpId}");
            mockClient.ReceivedPathParams.Should().ContainKey("idpId");
            mockClient.ReceivedPathParams["idpId"].Should().Contain(TestIdpId);
            mockClient.ReceivedBody.Should().Contain(updatedName);
        }

        [Fact]
        public async Task ReplaceIdentityProvider_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceIdentityProviderAsync(null, new IdentityProvider()));
        }

        [Fact]
        public async Task ReplaceIdentityProvider_WithNullBody_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceIdentityProviderAsync(TestIdpId, null));
        }

        [Fact]
        public async Task ReplaceIdentityProviderWithHttpInfo_WithValidParams_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = BuildIdpJson();
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updatedIdp = new IdentityProvider { Name = "Test IdP", Type = "GOOGLE" };

            // Act
            var result = await api.ReplaceIdentityProviderWithHttpInfoAsync(TestIdpId, updatedIdp);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be(TestIdpId);
        }

        [Fact]
        public async Task ReplaceIdentityProviderWithHttpInfo_WithNullIdpId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceIdentityProviderWithHttpInfoAsync(null, new IdentityProvider()));
        }

        [Fact]
        public async Task ReplaceIdentityProviderWithHttpInfo_WithNullBody_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new IdentityProviderApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceIdentityProviderWithHttpInfoAsync(TestIdpId, null));
        }

        #endregion
    }
}
