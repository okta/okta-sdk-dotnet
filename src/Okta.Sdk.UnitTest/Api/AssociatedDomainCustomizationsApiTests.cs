// <copyright file="AssociatedDomainCustomizationsApiTests.cs" company="Okta, Inc">
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
    /// Unit tests for AssociatedDomainCustomizationsApi.
    /// Covers all 14 methods (7 operations × 2 variants):
    ///   GetAllWellKnownURIs, GetAppleAppSiteAssociationWellKnownURI,
    ///   GetAssetLinksWellKnownURI, GetBrandWellKnownURI,
    ///   GetRootBrandWellKnownURI, GetWebAuthnWellKnownURI,
    ///   ReplaceBrandWellKnownURI.
    ///
    /// Endpoint mapping
    /// ─────────────────────────────────────────────────────────────────────────
    /// GetAllWellKnownURIs                     GET /api/v1/brands/{brandId}/well-known-uris
    /// GetAppleAppSiteAssociationWellKnownURI  GET /.well-known/apple-app-site-association
    /// GetAssetLinksWellKnownURI               GET /.well-known/assetlinks.json
    /// GetBrandWellKnownURI                    GET /api/v1/brands/{brandId}/well-known-uris/{path}/customized
    /// GetRootBrandWellKnownURI                GET /api/v1/brands/{brandId}/well-known-uris/{path}
    /// GetWebAuthnWellKnownURI                 GET /.well-known/webauthn
    /// ReplaceBrandWellKnownURI                PUT /api/v1/brands/{brandId}/well-known-uris/{path}/customized
    ///
    /// WellKnownUriPath enum values
    /// ─────────────────────────────────────────────────────────────────────────
    ///   AppleAppSiteAssociation → "apple-app-site-association"
    ///   AssetlinksJson          → "assetlinks.json"
    ///   Webauthn                → "webauthn"
    /// </summary>
    public class AssociatedDomainCustomizationsApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private const string BrandId = "bnd1ab2c3d4e5f6g7h8i";

        // ─────────────────────────────────────────────────────────────────────
        #region GetAllWellKnownURIs

        [Fact]
        public async Task GetAllWellKnownURIs_WithValidBrandId_ReturnsWellKnownURIsRoot()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIsRootJson());
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAllWellKnownURIsAsync(BrandId);

            // Assert
            result.Should().NotBeNull();
            result.Links.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/well-known-uris");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
        }

        [Fact]
        public async Task GetAllWellKnownURIs_WithExpandAll_SendsExpandQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIsRootJson());
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetAllWellKnownURIsAsync(BrandId, expand: new List<string> { "all" });

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams["expand"].Should().Contain("all");
        }

        [Fact]
        public async Task GetAllWellKnownURIs_WithExpandApple_SendsExpandQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIsRootJson());
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetAllWellKnownURIsAsync(BrandId, expand: new List<string> { "apple-app-site-association" });

            // Assert
            mockClient.ReceivedQueryParams["expand"].Should().Contain("apple-app-site-association");
        }

        [Fact]
        public async Task GetAllWellKnownURIs_WithExpandAssetlinks_SendsExpandQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIsRootJson());
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetAllWellKnownURIsAsync(BrandId, expand: new List<string> { "assetlinks.json" });

            // Assert
            mockClient.ReceivedQueryParams["expand"].Should().Contain("assetlinks.json");
        }

        [Fact]
        public async Task GetAllWellKnownURIs_WithExpandWebauthn_SendsExpandQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIsRootJson());
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetAllWellKnownURIsAsync(BrandId, expand: new List<string> { "webauthn" });

            // Assert
            mockClient.ReceivedQueryParams["expand"].Should().Contain("webauthn");
        }

        [Fact]
        public async Task GetAllWellKnownURIs_WithMultipleExpand_SendsAllExpandValues()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIsRootJson());
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetAllWellKnownURIsAsync(BrandId,
                expand: new List<string> { "apple-app-site-association", "assetlinks.json", "webauthn" });

            // Assert
            var expandValues = string.Join(",", mockClient.ReceivedQueryParams["expand"]);
            expandValues.Should().Contain("apple-app-site-association");
            expandValues.Should().Contain("assetlinks.json");
            expandValues.Should().Contain("webauthn");
        }

        [Fact]
        public async Task GetAllWellKnownURIs_WithNoExpand_DoesNotSendExpandQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIsRootJson());
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetAllWellKnownURIsAsync(BrandId);

            // Assert
            mockClient.ReceivedQueryParams.Should().NotContainKey("expand");
        }

        [Fact]
        public async Task GetAllWellKnownURIs_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetAllWellKnownURIsAsync(null));
        }

        [Fact]
        public async Task GetAllWellKnownURIsWithHttpInfo_ReturnsStatusCode200AndWellKnownURIsRoot()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIsRootJson(), HttpStatusCode.OK);
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetAllWellKnownURIsWithHttpInfoAsync(BrandId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Links.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/well-known-uris");
        }

        [Fact]
        public async Task GetAllWellKnownURIsWithHttpInfo_WithExpandAll_SendsExpandQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIsRootJson());
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetAllWellKnownURIsWithHttpInfoAsync(BrandId, expand: new List<string> { "all" });

            // Assert
            mockClient.ReceivedQueryParams["expand"].Should().Contain("all");
        }

        [Fact]
        public async Task GetAllWellKnownURIsWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetAllWellKnownURIsWithHttpInfoAsync(null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetAppleAppSiteAssociationWellKnownURI

        [Fact]
        public async Task GetAppleAppSiteAssociationWellKnownURI_ReturnsObject()
        {
            // Arrange
            var mockClient = new MockAsyncClient(@"{""applinks"":{""apps"":[],""details"":[]}}");
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAppleAppSiteAssociationWellKnownURIAsync();

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Be("/.well-known/apple-app-site-association");
        }

        [Fact]
        public async Task GetAppleAppSiteAssociationWellKnownURI_WithEmptyResponse_ReturnsEmptyObject()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAppleAppSiteAssociationWellKnownURIAsync();

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAppleAppSiteAssociationWellKnownURIWithHttpInfo_ReturnsStatusCode200AndObject()
        {
            // Arrange
            var mockClient = new MockAsyncClient(@"{""applinks"":{""apps"":[]}}", HttpStatusCode.OK);
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetAppleAppSiteAssociationWellKnownURIWithHttpInfoAsync();

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Be("/.well-known/apple-app-site-association");
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetAssetLinksWellKnownURI

        [Fact]
        public async Task GetAssetLinksWellKnownURI_ReturnsObject()
        {
            // Arrange
            var mockClient = new MockAsyncClient(@"[{""relation"":[""delegate_permission/common.handle_all_urls""],""target"":{""namespace"":""android_app""}}]");
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAssetLinksWellKnownURIAsync();

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Be("/.well-known/assetlinks.json");
        }

        [Fact]
        public async Task GetAssetLinksWellKnownURI_WithEmptyResponse_ReturnsEmptyObject()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAssetLinksWellKnownURIAsync();

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAssetLinksWellKnownURIWithHttpInfo_ReturnsStatusCode200AndObject()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.OK);
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetAssetLinksWellKnownURIWithHttpInfoAsync();

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Be("/.well-known/assetlinks.json");
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetBrandWellKnownURI

        [Fact]
        public async Task GetBrandWellKnownURI_WithApplePath_ReturnsWellKnownURIObjectResponse()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIObjectResponseJson());
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetBrandWellKnownURIAsync(BrandId, WellKnownUriPath.AppleAppSiteAssociation);

            // Assert
            result.Should().NotBeNull();
            result.Links.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/well-known-uris/{path}/customized");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["path"].Should().Be("apple-app-site-association");
        }

        [Fact]
        public async Task GetBrandWellKnownURI_WithAssetlinksPath_SendsAssetlinksJsonPathParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIObjectResponseJson());
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetBrandWellKnownURIAsync(BrandId, WellKnownUriPath.AssetlinksJson);

            // Assert
            mockClient.ReceivedPathParams["path"].Should().Be("assetlinks.json");
        }

        [Fact]
        public async Task GetBrandWellKnownURI_WithWebauthnPath_SendsWebauthnPathParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIObjectResponseJson());
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetBrandWellKnownURIAsync(BrandId, WellKnownUriPath.Webauthn);

            // Assert
            mockClient.ReceivedPathParams["path"].Should().Be("webauthn");
        }

        [Fact]
        public async Task GetBrandWellKnownURI_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.GetBrandWellKnownURIAsync(null, WellKnownUriPath.Webauthn));
        }

        [Fact]
        public async Task GetBrandWellKnownURIWithHttpInfo_WithApplePath_ReturnsStatusCode200AndResponse()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIObjectResponseJson(), HttpStatusCode.OK);
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetBrandWellKnownURIWithHttpInfoAsync(BrandId, WellKnownUriPath.AppleAppSiteAssociation);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            mockClient.ReceivedPathParams["path"].Should().Be("apple-app-site-association");
        }

        [Fact]
        public async Task GetBrandWellKnownURIWithHttpInfo_WithAssetlinksPath_ReturnsStatusCode200()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIObjectResponseJson(), HttpStatusCode.OK);
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetBrandWellKnownURIWithHttpInfoAsync(BrandId, WellKnownUriPath.AssetlinksJson);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            mockClient.ReceivedPathParams["path"].Should().Be("assetlinks.json");
        }

        [Fact]
        public async Task GetBrandWellKnownURIWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.GetBrandWellKnownURIWithHttpInfoAsync(null, WellKnownUriPath.Webauthn));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetRootBrandWellKnownURI

        [Fact]
        public async Task GetRootBrandWellKnownURI_WithApplePath_ReturnsWellKnownURIObjectResponse()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIObjectResponseJson());
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetRootBrandWellKnownURIAsync(BrandId, WellKnownUriPath.AppleAppSiteAssociation);

            // Assert
            result.Should().NotBeNull();
            result.Links.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/well-known-uris/{path}");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["path"].Should().Be("apple-app-site-association");
        }

        [Fact]
        public async Task GetRootBrandWellKnownURI_WithAssetlinksPath_SendsAssetlinksPathParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIObjectResponseJson());
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetRootBrandWellKnownURIAsync(BrandId, WellKnownUriPath.AssetlinksJson);

            // Assert
            mockClient.ReceivedPathParams["path"].Should().Be("assetlinks.json");
        }

        [Fact]
        public async Task GetRootBrandWellKnownURI_WithWebauthnPath_SendsWebauthnPathParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIObjectResponseJson());
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetRootBrandWellKnownURIAsync(BrandId, WellKnownUriPath.Webauthn);

            // Assert
            mockClient.ReceivedPathParams["path"].Should().Be("webauthn");
        }

        [Fact]
        public async Task GetRootBrandWellKnownURI_WithExpandCustomized_SendsExpandQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIObjectResponseJson());
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetRootBrandWellKnownURIAsync(BrandId, WellKnownUriPath.Webauthn,
                expand: new List<string> { "customized" });

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams["expand"].Should().Contain("customized");
        }

        [Fact]
        public async Task GetRootBrandWellKnownURI_WithNoExpand_DoesNotSendExpandQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIObjectResponseJson());
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetRootBrandWellKnownURIAsync(BrandId, WellKnownUriPath.Webauthn);

            // Assert
            mockClient.ReceivedQueryParams.Should().NotContainKey("expand");
        }

        [Fact]
        public async Task GetRootBrandWellKnownURI_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.GetRootBrandWellKnownURIAsync(null, WellKnownUriPath.Webauthn));
        }

        [Fact]
        public async Task GetRootBrandWellKnownURIWithHttpInfo_WithApplePath_ReturnsStatusCode200AndResponse()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIObjectResponseJson(), HttpStatusCode.OK);
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetRootBrandWellKnownURIWithHttpInfoAsync(BrandId, WellKnownUriPath.AppleAppSiteAssociation);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            mockClient.ReceivedPathParams["path"].Should().Be("apple-app-site-association");
        }

        [Fact]
        public async Task GetRootBrandWellKnownURIWithHttpInfo_WithExpandCustomized_SendsExpandQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIObjectResponseJson());
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetRootBrandWellKnownURIWithHttpInfoAsync(BrandId, WellKnownUriPath.AssetlinksJson,
                expand: new List<string> { "customized" });

            // Assert
            mockClient.ReceivedQueryParams["expand"].Should().Contain("customized");
        }

        [Fact]
        public async Task GetRootBrandWellKnownURIWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.GetRootBrandWellKnownURIWithHttpInfoAsync(null, WellKnownUriPath.Webauthn));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetWebAuthnWellKnownURI

        [Fact]
        public async Task GetWebAuthnWellKnownURI_ReturnsObject()
        {
            // Arrange
            var mockClient = new MockAsyncClient(@"{""keys"":[]}");
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetWebAuthnWellKnownURIAsync();

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Be("/.well-known/webauthn");
        }

        [Fact]
        public async Task GetWebAuthnWellKnownURI_WithEmptyResponse_ReturnsEmptyObject()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetWebAuthnWellKnownURIAsync();

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetWebAuthnWellKnownURIWithHttpInfo_ReturnsStatusCode200AndObject()
        {
            // Arrange
            var mockClient = new MockAsyncClient(@"{""keys"":[]}", HttpStatusCode.OK);
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetWebAuthnWellKnownURIWithHttpInfoAsync();

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Be("/.well-known/webauthn");
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region ReplaceBrandWellKnownURI

        [Fact]
        public async Task ReplaceBrandWellKnownURI_WithApplePath_ReturnsUpdatedResponse()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIObjectResponseJson());
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new WellKnownURIRequest { Representation = new { applinks = new { apps = new string[] { } } } };

            // Act
            var result = await api.ReplaceBrandWellKnownURIAsync(BrandId, WellKnownUriPath.AppleAppSiteAssociation, request);

            // Assert
            result.Should().NotBeNull();
            result.Links.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/well-known-uris/{path}/customized");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["path"].Should().Be("apple-app-site-association");
        }

        [Fact]
        public async Task ReplaceBrandWellKnownURI_WithAssetlinksPath_SendsAssetlinksPathParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIObjectResponseJson());
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ReplaceBrandWellKnownURIAsync(BrandId, WellKnownUriPath.AssetlinksJson);

            // Assert
            mockClient.ReceivedPathParams["path"].Should().Be("assetlinks.json");
        }

        [Fact]
        public async Task ReplaceBrandWellKnownURI_WithWebauthnPath_SendsWebauthnPathParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIObjectResponseJson());
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ReplaceBrandWellKnownURIAsync(BrandId, WellKnownUriPath.Webauthn);

            // Assert
            mockClient.ReceivedPathParams["path"].Should().Be("webauthn");
        }

        [Fact]
        public async Task ReplaceBrandWellKnownURI_WithNullRequest_DoesNotThrow()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIObjectResponseJson());
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var act = async () => await api.ReplaceBrandWellKnownURIAsync(BrandId, WellKnownUriPath.Webauthn, null);

            // Assert
            await act.Should().NotThrowAsync();
        }

        [Fact]
        public async Task ReplaceBrandWellKnownURI_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceBrandWellKnownURIAsync(null, WellKnownUriPath.Webauthn));
        }

        [Fact]
        public async Task ReplaceBrandWellKnownURIWithHttpInfo_WithApplePath_ReturnsStatusCode200AndResponse()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIObjectResponseJson(), HttpStatusCode.OK);
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ReplaceBrandWellKnownURIWithHttpInfoAsync(BrandId, WellKnownUriPath.AppleAppSiteAssociation);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            mockClient.ReceivedPathParams["path"].Should().Be("apple-app-site-association");
        }

        [Fact]
        public async Task ReplaceBrandWellKnownURIWithHttpInfo_WithAssetlinksPath_ReturnsStatusCode200()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIObjectResponseJson(), HttpStatusCode.OK);
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ReplaceBrandWellKnownURIWithHttpInfoAsync(BrandId, WellKnownUriPath.AssetlinksJson);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            mockClient.ReceivedPathParams["path"].Should().Be("assetlinks.json");
        }

        [Fact]
        public async Task ReplaceBrandWellKnownURIWithHttpInfo_WithWebauthnPath_ReturnsStatusCode200()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildWellKnownURIObjectResponseJson(), HttpStatusCode.OK);
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ReplaceBrandWellKnownURIWithHttpInfoAsync(BrandId, WellKnownUriPath.Webauthn);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            mockClient.ReceivedPathParams["path"].Should().Be("webauthn");
        }

        [Fact]
        public async Task ReplaceBrandWellKnownURIWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new AssociatedDomainCustomizationsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceBrandWellKnownURIWithHttpInfoAsync(null, WellKnownUriPath.Webauthn));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region Helpers

        private static string BuildWellKnownURIsRootJson() =>
            @"{""_links"":{""self"":{""href"":""https://test.okta.com""},""apple-app-site-association"":{""href"":""https://test.okta.com/.well-known/apple-app-site-association""},""assetlinks.json"":{""href"":""https://test.okta.com/.well-known/assetlinks.json""},""webauthn"":{""href"":""https://test.okta.com/.well-known/webauthn""}}}";

        private static string BuildWellKnownURIObjectResponseJson() =>
            @"{""_links"":{""self"":{""href"":""https://test.okta.com""}}}";

        #endregion
    }
}
