// <copyright file="BrandsApiTests.cs" company="Okta, Inc">
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
    /// Unit tests for BrandsApi.
    /// Covers all 12 methods: CreateBrand, DeleteBrand, GetBrand,
    /// ListBrandDomains, ListBrands, ReplaceBrand and their WithHttpInfo variants.
    /// </summary>
    public class BrandsApiTests
    {
        private const string BaseUrl  = "https://test.okta.com";
        private const string BrandId  = "bnd1ab2c3d4e5f6g7h8i";
        private const string BrandId2 = "bnd2xxxxxxxxxxxxxxxxx";
        private const string DomainId = "OcDz6iRyjkaCTX7Wfb4h";

        // ─────────────────────────────────────────────────────────────────────
        #region CreateBrand

        [Fact]
        public async Task CreateBrand_WithValidRequest_ReturnsBrand()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildBrandJson(BrandId, "Test Brand"));
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.CreateBrandAsync(new CreateBrandRequest { Name = "Test Brand" });

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(BrandId);
            result.Name.Should().Be("Test Brand");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands");
            mockClient.ReceivedBody.Should().Contain("Test Brand");
        }

        [Fact]
        public async Task CreateBrand_WithNullRequest_SendsEmptyBody()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildBrandJson(BrandId, "Default Brand"));
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.CreateBrandAsync();

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Be("/api/v1/brands");
        }

        [Fact]
        public async Task CreateBrand_ResponseMapsAllFields()
        {
            // Arrange
            var json = $@"{{
                ""id"":""{BrandId}"",
                ""name"":""My Brand"",
                ""locale"":""en"",
                ""removePoweredByOkta"":true,
                ""agreeToCustomPrivacyPolicy"":false,
                ""customPrivacyPolicyUrl"":""https://example.com/privacy""
            }}";
            var mockClient = new MockAsyncClient(json);
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.CreateBrandAsync(new CreateBrandRequest { Name = "My Brand" });

            // Assert
            result.Id.Should().Be(BrandId);
            result.Name.Should().Be("My Brand");
            result.Locale.Should().Be("en");
            result.RemovePoweredByOkta.Should().BeTrue();
            result.CustomPrivacyPolicyUrl.Should().Be("https://example.com/privacy");
        }

        [Fact]
        public async Task CreateBrandWithHttpInfo_ReturnsStatusCode200AndBrand()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildBrandJson(BrandId, "Test Brand"), HttpStatusCode.OK);
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.CreateBrandWithHttpInfoAsync(new CreateBrandRequest { Name = "Test Brand" });

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(BrandId);
            response.Data.Name.Should().Be("Test Brand");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands");
        }

        [Fact]
        public async Task CreateBrandWithHttpInfo_WithNullRequest_ReturnsResponse()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildBrandJson(BrandId, "Brand"), HttpStatusCode.OK);
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.CreateBrandWithHttpInfoAsync(null);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region DeleteBrand

        [Fact]
        public async Task DeleteBrand_WithValidId_CompletesWithoutThrowing()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var act = async () => await api.DeleteBrandAsync(BrandId);

            // Assert
            await act.Should().NotThrowAsync();
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}");
            mockClient.ReceivedPathParams.Should().ContainKey("brandId");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
        }

        [Fact]
        public async Task DeleteBrand_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeleteBrandAsync(null));
        }

        [Fact]
        public async Task DeleteBrandWithHttpInfo_ReturnsNoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.DeleteBrandWithHttpInfoAsync(BrandId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
        }

        [Fact]
        public async Task DeleteBrandWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeleteBrandWithHttpInfoAsync(null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetBrand

        [Fact]
        public async Task GetBrand_WithValidId_ReturnsBrandWithEmbedded()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildBrandWithEmbeddedJson(BrandId, "Test Brand"));
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetBrandAsync(BrandId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(BrandId);
            result.Name.Should().Be("Test Brand");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
        }

        [Fact]
        public async Task GetBrand_WithExpandTheme_SendsExpandQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildBrandWithEmbeddedJson(BrandId, "Test Brand"));
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetBrandAsync(BrandId, expand: new List<string> { "theme" });

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams["expand"].Should().Contain("theme");
        }

        [Fact]
        public async Task GetBrand_WithMultipleExpands_SendsAllExpandValues()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildBrandWithEmbeddedJson(BrandId, "Test Brand"));
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetBrandAsync(BrandId, expand: new List<string> { "theme", "emailDomain" });

            // Assert — the API joins multiple expand values into one comma-separated entry
            var expandValues = string.Join(",", mockClient.ReceivedQueryParams["expand"]);
            expandValues.Should().Contain("theme");
            expandValues.Should().Contain("emailDomain");
        }

        [Fact]
        public async Task GetBrand_WithNoExpand_DoesNotSendExpandQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildBrandWithEmbeddedJson(BrandId, "Test Brand"));
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetBrandAsync(BrandId);

            // Assert
            mockClient.ReceivedQueryParams.Should().NotContainKey("expand");
        }

        [Fact]
        public async Task GetBrand_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetBrandAsync(null));
        }

        [Fact]
        public async Task GetBrandWithHttpInfo_ReturnsBrandAndStatusCode200()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildBrandWithEmbeddedJson(BrandId, "Test Brand"), HttpStatusCode.OK);
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetBrandWithHttpInfoAsync(BrandId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(BrandId);
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
        }

        [Fact]
        public async Task GetBrandWithHttpInfo_WithExpand_SendsExpandQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildBrandWithEmbeddedJson(BrandId, "Test Brand"));
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetBrandWithHttpInfoAsync(BrandId, expand: new List<string> { "theme" });

            // Assert
            response.Data.Id.Should().Be(BrandId);
            mockClient.ReceivedQueryParams["expand"].Should().Contain("theme");
        }

        [Fact]
        public async Task GetBrandWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetBrandWithHttpInfoAsync(null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region ListBrandDomains

        [Fact]
        public async Task ListBrandDomainsWithHttpInfo_ReturnsDomainsForBrand()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildBrandDomainsListJson(DomainId, BrandId));
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListBrandDomainsWithHttpInfoAsync(BrandId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull().And.HaveCount(1);
            response.Data[0].Id.Should().Be(DomainId);
            response.Data[0].BrandId.Should().Be(BrandId);
            response.Data[0].Domain.Should().Be("login.example.com");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/domains");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
        }

        [Fact]
        public async Task ListBrandDomainsWithHttpInfo_WithEmptyList_ReturnsEmptyCollection()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListBrandDomainsWithHttpInfoAsync(BrandId);

            // Assert
            response.Data.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task ListBrandDomainsWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ListBrandDomainsWithHttpInfoAsync(null));
        }

        [Fact]
        public async Task ListBrandDomainsWithHttpInfo_MultipleDomains_ReturnsAll()
        {
            // Arrange
            var json = $@"[
                {{""id"":""{DomainId}"",""domain"":""login.example.com"",""brandId"":""{BrandId}""}},
                {{""id"":""dom2xxxxxxxx"",""domain"":""portal.example.com"",""brandId"":""{BrandId}""}}
            ]";
            var mockClient = new MockAsyncClient(json);
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListBrandDomainsWithHttpInfoAsync(BrandId);

            // Assert
            response.Data.Should().HaveCount(2);
            response.Data[1].Domain.Should().Be("portal.example.com");
        }

        [Fact]
        public async Task ListBrandDomains_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert — non-async collection method validates eagerly
            Assert.Throws<ApiException>(() => api.ListBrandDomains(null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region ListBrands

        [Fact]
        public async Task ListBrandsWithHttpInfo_ReturnsAllBrands()
        {
            // Arrange
            var json = $@"[
                {BuildBrandWithEmbeddedJson(BrandId,  "Brand One")},
                {BuildBrandWithEmbeddedJson(BrandId2, "Brand Two")}
            ]";
            var mockClient = new MockAsyncClient(json);
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListBrandsWithHttpInfoAsync();

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().HaveCount(2);
            response.Data[0].Id.Should().Be(BrandId);
            response.Data[0].Name.Should().Be("Brand One");
            response.Data[1].Name.Should().Be("Brand Two");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands");
        }

        [Fact]
        public async Task ListBrandsWithHttpInfo_WithLimit_SendsLimitQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ListBrandsWithHttpInfoAsync(limit: 5);

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain("5");
        }

        [Fact]
        public async Task ListBrandsWithHttpInfo_WithAfterCursor_SendsAfterQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ListBrandsWithHttpInfoAsync(after: "cursor_abc123");

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain("cursor_abc123");
        }

        [Fact]
        public async Task ListBrandsWithHttpInfo_WithSearchQuery_SendsQQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ListBrandsWithHttpInfoAsync(q: "MyBrand");

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("q");
            mockClient.ReceivedQueryParams["q"].Should().Contain("MyBrand");
        }

        [Fact]
        public async Task ListBrandsWithHttpInfo_WithExpand_SendsExpandQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ListBrandsWithHttpInfoAsync(expand: new List<string> { "theme" });

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams["expand"].Should().Contain("theme");
        }

        [Fact]
        public async Task ListBrandsWithHttpInfo_WithAllParams_SendsAllQueryParams()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ListBrandsWithHttpInfoAsync(
                expand: new List<string> { "theme" },
                after: "cursor_xyz",
                limit: 10,
                q: "TestBrand");

            // Assert
            mockClient.ReceivedQueryParams["expand"].Should().Contain("theme");
            mockClient.ReceivedQueryParams["after"].Should().Contain("cursor_xyz");
            mockClient.ReceivedQueryParams["limit"].Should().Contain("10");
            mockClient.ReceivedQueryParams["q"].Should().Contain("TestBrand");
        }

        [Fact]
        public async Task ListBrandsWithHttpInfo_WithNoParams_SendsNoQueryParams()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ListBrandsWithHttpInfoAsync();

            // Assert
            mockClient.ReceivedQueryParams.Should().NotContainKey("limit");
            mockClient.ReceivedQueryParams.Should().NotContainKey("after");
            mockClient.ReceivedQueryParams.Should().NotContainKey("q");
            mockClient.ReceivedQueryParams.Should().NotContainKey("expand");
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region ReplaceBrand

        [Fact]
        public async Task ReplaceBrand_WithValidData_ReturnsBrand()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildBrandJson(BrandId, "Updated Brand"));
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });
            var brandRequest = new BrandRequest { Name = "Updated Brand", Locale = "fr", RemovePoweredByOkta = true };

            // Act
            var result = await api.ReplaceBrandAsync(BrandId, brandRequest);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(BrandId);
            result.Name.Should().Be("Updated Brand");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedBody.Should().Contain("Updated Brand");
        }

        [Fact]
        public async Task ReplaceBrand_SendsLocaleInBody()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildBrandJson(BrandId, "Brand"));
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ReplaceBrandAsync(BrandId, new BrandRequest { Name = "Brand", Locale = "de" });

            // Assert
            mockClient.ReceivedBody.Should().Contain("de");
        }

        [Fact]
        public async Task ReplaceBrand_SendsRemovePoweredByOktaInBody()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildBrandJson(BrandId, "Brand"));
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ReplaceBrandAsync(BrandId, new BrandRequest { Name = "Brand", RemovePoweredByOkta = true });

            // Assert
            mockClient.ReceivedBody.Should().Contain("removePoweredByOkta");
        }

        [Fact]
        public async Task ReplaceBrand_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ReplaceBrandAsync(null, new BrandRequest()));
        }

        [Fact]
        public async Task ReplaceBrand_WithNullBrandRequest_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ReplaceBrandAsync(BrandId, null));
        }

        [Fact]
        public async Task ReplaceBrandWithHttpInfo_ReturnsBrandAndStatusCode200()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildBrandJson(BrandId, "Updated Brand"), HttpStatusCode.OK);
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ReplaceBrandWithHttpInfoAsync(BrandId, new BrandRequest { Name = "Updated Brand" });

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Id.Should().Be(BrandId);
            response.Data.Name.Should().Be("Updated Brand");
        }

        [Fact]
        public async Task ReplaceBrandWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ReplaceBrandWithHttpInfoAsync(null, new BrandRequest()));
        }

        [Fact]
        public async Task ReplaceBrandWithHttpInfo_WithNullBrandRequest_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new BrandsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ReplaceBrandWithHttpInfoAsync(BrandId, null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region Helpers

        private static string BuildBrandJson(string id, string name) =>
            $@"{{
                ""id"":""{id}"",
                ""name"":""{name}"",
                ""locale"":""en"",
                ""removePoweredByOkta"":false,
                ""agreeToCustomPrivacyPolicy"":false,
                ""isDefault"":false
            }}";

        private static string BuildBrandWithEmbeddedJson(string id, string name) =>
            $@"{{
                ""id"":""{id}"",
                ""name"":""{name}"",
                ""locale"":""en"",
                ""removePoweredByOkta"":false,
                ""agreeToCustomPrivacyPolicy"":false,
                ""isDefault"":false
            }}";

        private static string BuildBrandDomainsListJson(string domainId, string brandId) =>
            $@"[{{
                ""id"":""{domainId}"",
                ""domain"":""login.example.com"",
                ""brandId"":""{brandId}"",
                ""validationStatus"":""NOT_STARTED""
            }}]";

        #endregion
    }
}
