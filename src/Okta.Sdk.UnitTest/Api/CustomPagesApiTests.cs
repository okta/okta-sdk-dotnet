// <copyright file="CustomPagesApiTests.cs" company="Okta, Inc">
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
    /// Unit tests for CustomPagesApi.
    /// Covers all methods (operations × 2 variants):
    ///   DeleteCustomizedErrorPage, DeleteCustomizedSignInPage,
    ///   DeletePreviewErrorPage, DeletePreviewSignInPage,
    ///   GetCustomizedErrorPage, GetCustomizedSignInPage,
    ///   GetDefaultErrorPage, GetDefaultSignInPage,
    ///   GetErrorPage, GetPreviewErrorPage, GetPreviewSignInPage,
    ///   GetSignInPage, GetSignOutPageSettings,
    ///   ListAllSignInWidgetVersions,
    ///   ReplaceCustomizedErrorPage, ReplaceCustomizedSignInPage,
    ///   ReplacePreviewErrorPage, ReplacePreviewSignInPage,
    ///   ReplaceSignOutPageSettings.
    ///
    /// Endpoint mapping
    /// ─────────────────────────────────────────────────────────────────────────
    /// DeleteCustomizedErrorPage   DELETE /api/v1/brands/{brandId}/pages/error/customized
    /// DeleteCustomizedSignInPage  DELETE /api/v1/brands/{brandId}/pages/sign-in/customized
    /// DeletePreviewErrorPage      DELETE /api/v1/brands/{brandId}/pages/error/preview
    /// DeletePreviewSignInPage     DELETE /api/v1/brands/{brandId}/pages/sign-in/preview
    /// GetCustomizedErrorPage      GET    /api/v1/brands/{brandId}/pages/error/customized
    /// GetCustomizedSignInPage     GET    /api/v1/brands/{brandId}/pages/sign-in/customized
    /// GetDefaultErrorPage         GET    /api/v1/brands/{brandId}/pages/error/default
    /// GetDefaultSignInPage        GET    /api/v1/brands/{brandId}/pages/sign-in/default
    /// GetErrorPage                GET    /api/v1/brands/{brandId}/pages/error
    /// GetPreviewErrorPage         GET    /api/v1/brands/{brandId}/pages/error/preview
    /// GetPreviewSignInPage        GET    /api/v1/brands/{brandId}/pages/sign-in/preview
    /// GetSignInPage               GET    /api/v1/brands/{brandId}/pages/sign-in
    /// GetSignOutPageSettings      GET    /api/v1/brands/{brandId}/pages/sign-out/customized
    /// ListAllSignInWidgetVersions GET    /api/v1/brands/{brandId}/pages/sign-in/widget-versions
    /// ReplaceCustomizedErrorPage  PUT    /api/v1/brands/{brandId}/pages/error/customized
    /// ReplaceCustomizedSignInPage PUT    /api/v1/brands/{brandId}/pages/sign-in/customized
    /// ReplacePreviewErrorPage     PUT    /api/v1/brands/{brandId}/pages/error/preview
    /// ReplacePreviewSignInPage    PUT    /api/v1/brands/{brandId}/pages/sign-in/preview
    /// ReplaceSignOutPageSettings  PUT    /api/v1/brands/{brandId}/pages/sign-out/customized
    /// </summary>
    public class CustomPagesApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private const string BrandId = "bnd1ab2c3d4e5f6g7h8i";

        // ─────────────────────────────────────────────────────────────────────
        #region DeleteCustomizedErrorPage

        [Fact]
        public async Task DeleteCustomizedErrorPage_WithValidBrandId_CompletesWithoutThrowing()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var act = async () => await api.DeleteCustomizedErrorPageAsync(BrandId);

            // Assert
            await act.Should().NotThrowAsync();
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/pages/error/customized");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
        }

        [Fact]
        public async Task DeleteCustomizedErrorPage_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeleteCustomizedErrorPageAsync(null));
        }

        [Fact]
        public async Task DeleteCustomizedErrorPageWithHttpInfo_ReturnsNoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.DeleteCustomizedErrorPageWithHttpInfoAsync(BrandId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
        }

        [Fact]
        public async Task DeleteCustomizedErrorPageWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeleteCustomizedErrorPageWithHttpInfoAsync(null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region DeleteCustomizedSignInPage

        [Fact]
        public async Task DeleteCustomizedSignInPage_WithValidBrandId_CompletesWithoutThrowing()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var act = async () => await api.DeleteCustomizedSignInPageAsync(BrandId);

            // Assert
            await act.Should().NotThrowAsync();
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/pages/sign-in/customized");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
        }

        [Fact]
        public async Task DeleteCustomizedSignInPage_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeleteCustomizedSignInPageAsync(null));
        }

        [Fact]
        public async Task DeleteCustomizedSignInPageWithHttpInfo_ReturnsNoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.DeleteCustomizedSignInPageWithHttpInfoAsync(BrandId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeleteCustomizedSignInPageWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeleteCustomizedSignInPageWithHttpInfoAsync(null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region DeletePreviewErrorPage

        [Fact]
        public async Task DeletePreviewErrorPage_WithValidBrandId_CompletesWithoutThrowing()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var act = async () => await api.DeletePreviewErrorPageAsync(BrandId);

            // Assert
            await act.Should().NotThrowAsync();
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/pages/error/preview");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
        }

        [Fact]
        public async Task DeletePreviewErrorPage_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeletePreviewErrorPageAsync(null));
        }

        [Fact]
        public async Task DeletePreviewErrorPageWithHttpInfo_ReturnsNoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.DeletePreviewErrorPageWithHttpInfoAsync(BrandId);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeletePreviewErrorPageWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeletePreviewErrorPageWithHttpInfoAsync(null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region DeletePreviewSignInPage

        [Fact]
        public async Task DeletePreviewSignInPage_WithValidBrandId_CompletesWithoutThrowing()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var act = async () => await api.DeletePreviewSignInPageAsync(BrandId);

            // Assert
            await act.Should().NotThrowAsync();
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/pages/sign-in/preview");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
        }

        [Fact]
        public async Task DeletePreviewSignInPage_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeletePreviewSignInPageAsync(null));
        }

        [Fact]
        public async Task DeletePreviewSignInPageWithHttpInfo_ReturnsNoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.DeletePreviewSignInPageWithHttpInfoAsync(BrandId);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeletePreviewSignInPageWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeletePreviewSignInPageWithHttpInfoAsync(null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetCustomizedErrorPage

        [Fact]
        public async Task GetCustomizedErrorPage_WithValidBrandId_ReturnsErrorPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildErrorPageJson("<html>Error</html>"));
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetCustomizedErrorPageAsync(BrandId);

            // Assert
            result.Should().NotBeNull();
            result.PageContent.Should().Be("<html>Error</html>");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/pages/error/customized");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
        }

        [Fact]
        public async Task GetCustomizedErrorPage_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetCustomizedErrorPageAsync(null));
        }

        [Fact]
        public async Task GetCustomizedErrorPageWithHttpInfo_ReturnsStatusCode200AndErrorPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildErrorPageJson("<html>Error</html>"), HttpStatusCode.OK);
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetCustomizedErrorPageWithHttpInfoAsync(BrandId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.PageContent.Should().Be("<html>Error</html>");
        }

        [Fact]
        public async Task GetCustomizedErrorPageWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetCustomizedErrorPageWithHttpInfoAsync(null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetCustomizedSignInPage

        [Fact]
        public async Task GetCustomizedSignInPage_WithValidBrandId_ReturnsSignInPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildSignInPageJson("<html>SignIn</html>", "3.0"));
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetCustomizedSignInPageAsync(BrandId);

            // Assert
            result.Should().NotBeNull();
            result.PageContent.Should().Be("<html>SignIn</html>");
            result.WidgetVersion.Should().Be("3.0");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/pages/sign-in/customized");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
        }

        [Fact]
        public async Task GetCustomizedSignInPage_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetCustomizedSignInPageAsync(null));
        }

        [Fact]
        public async Task GetCustomizedSignInPageWithHttpInfo_ReturnsStatusCode200AndSignInPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildSignInPageJson("<html>SignIn</html>", "3.0"), HttpStatusCode.OK);
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetCustomizedSignInPageWithHttpInfoAsync(BrandId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.WidgetVersion.Should().Be("3.0");
        }

        [Fact]
        public async Task GetCustomizedSignInPageWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetCustomizedSignInPageWithHttpInfoAsync(null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetDefaultErrorPage

        [Fact]
        public async Task GetDefaultErrorPage_WithValidBrandId_ReturnsErrorPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildErrorPageJson("<html>Default Error</html>"));
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetDefaultErrorPageAsync(BrandId);

            // Assert
            result.Should().NotBeNull();
            result.PageContent.Should().Be("<html>Default Error</html>");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/pages/error/default");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
        }

        [Fact]
        public async Task GetDefaultErrorPage_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetDefaultErrorPageAsync(null));
        }

        [Fact]
        public async Task GetDefaultErrorPageWithHttpInfo_ReturnsStatusCode200AndErrorPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildErrorPageJson("<html>Default Error</html>"), HttpStatusCode.OK);
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetDefaultErrorPageWithHttpInfoAsync(BrandId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.PageContent.Should().Be("<html>Default Error</html>");
        }

        [Fact]
        public async Task GetDefaultErrorPageWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetDefaultErrorPageWithHttpInfoAsync(null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetDefaultSignInPage

        [Fact]
        public async Task GetDefaultSignInPage_WithValidBrandId_ReturnsSignInPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildSignInPageJson("<html>Default SignIn</html>", "3.0"));
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetDefaultSignInPageAsync(BrandId);

            // Assert
            result.Should().NotBeNull();
            result.PageContent.Should().Be("<html>Default SignIn</html>");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/pages/sign-in/default");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
        }

        [Fact]
        public async Task GetDefaultSignInPage_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetDefaultSignInPageAsync(null));
        }

        [Fact]
        public async Task GetDefaultSignInPageWithHttpInfo_ReturnsStatusCode200AndSignInPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildSignInPageJson("<html>Default SignIn</html>", "3.0"), HttpStatusCode.OK);
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetDefaultSignInPageWithHttpInfoAsync(BrandId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task GetDefaultSignInPageWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetDefaultSignInPageWithHttpInfoAsync(null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetErrorPage (returns PageRoot)

        [Fact]
        public async Task GetErrorPage_WithValidBrandId_ReturnsPageRoot()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildPageRootJson());
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetErrorPageAsync(BrandId);

            // Assert
            result.Should().NotBeNull();
            result.Links.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/pages/error");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
        }

        [Fact]
        public async Task GetErrorPage_WithExpandParam_SendsExpandQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildPageRootJson());
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetErrorPageAsync(BrandId, expand: new List<string> { "default" });

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams["expand"].Should().Contain("default");
        }

        [Fact]
        public async Task GetErrorPage_WithMultipleExpandValues_SendsAllExpandValues()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildPageRootJson());
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetErrorPageAsync(BrandId, expand: new List<string> { "default", "customized" });

            // Assert
            var expandValues = string.Join(",", mockClient.ReceivedQueryParams["expand"]);
            expandValues.Should().Contain("default");
            expandValues.Should().Contain("customized");
        }

        [Fact]
        public async Task GetErrorPage_WithNoExpand_DoesNotSendExpandQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildPageRootJson());
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetErrorPageAsync(BrandId);

            // Assert
            mockClient.ReceivedQueryParams.Should().NotContainKey("expand");
        }

        [Fact]
        public async Task GetErrorPage_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetErrorPageAsync(null));
        }

        [Fact]
        public async Task GetErrorPageWithHttpInfo_ReturnsStatusCode200AndPageRoot()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildPageRootJson(), HttpStatusCode.OK);
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetErrorPageWithHttpInfoAsync(BrandId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task GetErrorPageWithHttpInfo_WithExpandParam_SendsExpandQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildPageRootJson());
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetErrorPageWithHttpInfoAsync(BrandId, expand: new List<string> { "customized" });

            // Assert
            mockClient.ReceivedQueryParams["expand"].Should().Contain("customized");
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetPreviewErrorPage

        [Fact]
        public async Task GetPreviewErrorPage_WithValidBrandId_ReturnsErrorPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildErrorPageJson("<html>Preview Error</html>"));
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetPreviewErrorPageAsync(BrandId);

            // Assert
            result.Should().NotBeNull();
            result.PageContent.Should().Be("<html>Preview Error</html>");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/pages/error/preview");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
        }

        [Fact]
        public async Task GetPreviewErrorPage_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetPreviewErrorPageAsync(null));
        }

        [Fact]
        public async Task GetPreviewErrorPageWithHttpInfo_ReturnsStatusCode200AndErrorPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildErrorPageJson("<html>Preview Error</html>"), HttpStatusCode.OK);
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetPreviewErrorPageWithHttpInfoAsync(BrandId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.PageContent.Should().Be("<html>Preview Error</html>");
        }

        [Fact]
        public async Task GetPreviewErrorPageWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetPreviewErrorPageWithHttpInfoAsync(null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetPreviewSignInPage

        [Fact]
        public async Task GetPreviewSignInPage_WithValidBrandId_ReturnsSignInPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildSignInPageJson("<html>Preview SignIn</html>", "3.0"));
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetPreviewSignInPageAsync(BrandId);

            // Assert
            result.Should().NotBeNull();
            result.PageContent.Should().Be("<html>Preview SignIn</html>");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/pages/sign-in/preview");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
        }

        [Fact]
        public async Task GetPreviewSignInPage_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetPreviewSignInPageAsync(null));
        }

        [Fact]
        public async Task GetPreviewSignInPageWithHttpInfo_ReturnsStatusCode200AndSignInPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildSignInPageJson("<html>Preview SignIn</html>", "3.0"), HttpStatusCode.OK);
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetPreviewSignInPageWithHttpInfoAsync(BrandId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.PageContent.Should().Be("<html>Preview SignIn</html>");
        }

        [Fact]
        public async Task GetPreviewSignInPageWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetPreviewSignInPageWithHttpInfoAsync(null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetSignInPage (returns PageRoot)

        [Fact]
        public async Task GetSignInPage_WithValidBrandId_ReturnsPageRoot()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildPageRootJson());
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetSignInPageAsync(BrandId);

            // Assert
            result.Should().NotBeNull();
            result.Links.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/pages/sign-in");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
        }

        [Fact]
        public async Task GetSignInPage_WithExpandCustomized_SendsExpandQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildPageRootJson());
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetSignInPageAsync(BrandId, expand: new List<string> { "customized" });

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams["expand"].Should().Contain("customized");
        }

        [Fact]
        public async Task GetSignInPage_WithNoExpand_DoesNotSendExpandQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildPageRootJson());
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetSignInPageAsync(BrandId);

            // Assert
            mockClient.ReceivedQueryParams.Should().NotContainKey("expand");
        }

        [Fact]
        public async Task GetSignInPage_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetSignInPageAsync(null));
        }

        [Fact]
        public async Task GetSignInPageWithHttpInfo_ReturnsStatusCode200AndPageRoot()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildPageRootJson(), HttpStatusCode.OK);
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetSignInPageWithHttpInfoAsync(BrandId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task GetSignInPageWithHttpInfo_WithExpandParam_SendsExpandQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildPageRootJson());
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetSignInPageWithHttpInfoAsync(BrandId, expand: new List<string> { "preview" });

            // Assert
            mockClient.ReceivedQueryParams["expand"].Should().Contain("preview");
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetSignOutPageSettings

        [Fact]
        public async Task GetSignOutPageSettings_WithExternallyHosted_ReturnsHostedPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildHostedPageJson("EXTERNALLY_HOSTED", "https://custom.example.com/signout"));
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetSignOutPageSettingsAsync(BrandId);

            // Assert
            result.Should().NotBeNull();
            result.Type.Value.Should().Be("EXTERNALLY_HOSTED");
            result.Url.Should().Be("https://custom.example.com/signout");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/pages/sign-out/customized");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
        }

        [Fact]
        public async Task GetSignOutPageSettings_WithOktaDefault_ReturnsOktaDefaultType()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildHostedPageJson("OKTA_DEFAULT", null));
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetSignOutPageSettingsAsync(BrandId);

            // Assert
            result.Type.Value.Should().Be("OKTA_DEFAULT");
        }

        [Fact]
        public async Task GetSignOutPageSettings_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetSignOutPageSettingsAsync(null));
        }

        [Fact]
        public async Task GetSignOutPageSettingsWithHttpInfo_ReturnsStatusCode200AndHostedPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildHostedPageJson("EXTERNALLY_HOSTED", "https://logout.example.com"), HttpStatusCode.OK);
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetSignOutPageSettingsWithHttpInfoAsync(BrandId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Url.Should().Be("https://logout.example.com");
        }

        [Fact]
        public async Task GetSignOutPageSettingsWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetSignOutPageSettingsWithHttpInfoAsync(null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region ListAllSignInWidgetVersions

        [Fact]
        public async Task ListAllSignInWidgetVersionsWithHttpInfo_ReturnsVersionList()
        {
            // Arrange
            var mockClient = new MockAsyncClient(@"[""3.9.0"",""3.8.0"",""2.0.0""]");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListAllSignInWidgetVersionsWithHttpInfoAsync(BrandId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().HaveCount(3);
            response.Data.Should().Contain("3.9.0");
            response.Data.Should().Contain("3.8.0");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/pages/sign-in/widget-versions");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
        }

        [Fact]
        public async Task ListAllSignInWidgetVersionsWithHttpInfo_WithEmptyList_ReturnsEmptyCollection()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListAllSignInWidgetVersionsWithHttpInfoAsync(BrandId);

            // Assert
            response.Data.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task ListAllSignInWidgetVersionsWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ListAllSignInWidgetVersionsWithHttpInfoAsync(null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region ReplaceCustomizedErrorPage

        [Fact]
        public async Task ReplaceCustomizedErrorPage_WithValidData_ReturnsUpdatedErrorPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildErrorPageJson("<html>New Error</html>"));
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });
            var errorPage = new ErrorPage { PageContent = "<html>New Error</html>" };

            // Act
            var result = await api.ReplaceCustomizedErrorPageAsync(BrandId, errorPage);

            // Assert
            result.Should().NotBeNull();
            result.PageContent.Should().Be("<html>New Error</html>");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/pages/error/customized");
            mockClient.ReceivedBody.Should().Contain("New Error");
        }

        [Fact]
        public async Task ReplaceCustomizedErrorPage_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceCustomizedErrorPageAsync(null, new ErrorPage()));
        }

        [Fact]
        public async Task ReplaceCustomizedErrorPage_WithNullBody_ThrowsApiException()
        {
            // Arrange: errorPage is a required parameter; the generated SDK enforces this
            // by throwing ApiException(400) before making any HTTP call.
            var mockClient = new MockAsyncClient(BuildErrorPageJson("<html>Error</html>"));
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceCustomizedErrorPageAsync(BrandId, null));
        }

        [Fact]
        public async Task ReplaceCustomizedErrorPageWithHttpInfo_ReturnsStatusCode200AndErrorPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildErrorPageJson("<html>New Error</html>"), HttpStatusCode.OK);
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ReplaceCustomizedErrorPageWithHttpInfoAsync(BrandId, new ErrorPage { PageContent = "<html>New Error</html>" });

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.PageContent.Should().Be("<html>New Error</html>");
        }

        [Fact]
        public async Task ReplaceCustomizedErrorPageWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ReplaceCustomizedErrorPageWithHttpInfoAsync(null, null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region ReplaceCustomizedSignInPage

        [Fact]
        public async Task ReplaceCustomizedSignInPage_WithValidData_ReturnsUpdatedSignInPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildSignInPageJson("<html>New SignIn</html>", "3.9.0"));
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });
            var signInPage = new SignInPage { PageContent = "<html>New SignIn</html>", WidgetVersion = "3.9.0" };

            // Act
            var result = await api.ReplaceCustomizedSignInPageAsync(BrandId, signInPage);

            // Assert
            result.Should().NotBeNull();
            result.PageContent.Should().Be("<html>New SignIn</html>");
            result.WidgetVersion.Should().Be("3.9.0");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/pages/sign-in/customized");
            mockClient.ReceivedBody.Should().Contain("3.9.0");
        }

        [Fact]
        public async Task ReplaceCustomizedSignInPage_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceCustomizedSignInPageAsync(null, new SignInPage()));
        }

        [Fact]
        public async Task ReplaceCustomizedSignInPageWithHttpInfo_ReturnsStatusCode200AndSignInPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildSignInPageJson("<html>New SignIn</html>", "3.9.0"), HttpStatusCode.OK);
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ReplaceCustomizedSignInPageWithHttpInfoAsync(BrandId,
                new SignInPage { PageContent = "<html>New SignIn</html>", WidgetVersion = "3.9.0" });

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.WidgetVersion.Should().Be("3.9.0");
        }

        [Fact]
        public async Task ReplaceCustomizedSignInPageWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ReplaceCustomizedSignInPageWithHttpInfoAsync(null, null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region ReplacePreviewErrorPage

        [Fact]
        public async Task ReplacePreviewErrorPage_WithValidData_ReturnsUpdatedErrorPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildErrorPageJson("<html>Preview Error Updated</html>"));
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ReplacePreviewErrorPageAsync(BrandId, new ErrorPage { PageContent = "<html>Preview Error Updated</html>" });

            // Assert
            result.Should().NotBeNull();
            result.PageContent.Should().Be("<html>Preview Error Updated</html>");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/pages/error/preview");
        }

        [Fact]
        public async Task ReplacePreviewErrorPage_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplacePreviewErrorPageAsync(null, new ErrorPage()));
        }

        [Fact]
        public async Task ReplacePreviewErrorPageWithHttpInfo_ReturnsStatusCode200AndErrorPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildErrorPageJson("<html>Preview Updated</html>"), HttpStatusCode.OK);
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ReplacePreviewErrorPageWithHttpInfoAsync(BrandId,
                new ErrorPage { PageContent = "<html>Preview Updated</html>" });

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.PageContent.Should().Be("<html>Preview Updated</html>");
        }

        [Fact]
        public async Task ReplacePreviewErrorPageWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ReplacePreviewErrorPageWithHttpInfoAsync(null, null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region ReplacePreviewSignInPage

        [Fact]
        public async Task ReplacePreviewSignInPage_WithValidData_ReturnsUpdatedSignInPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildSignInPageJson("<html>Preview SignIn Updated</html>", "3.9.0"));
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ReplacePreviewSignInPageAsync(BrandId,
                new SignInPage { PageContent = "<html>Preview SignIn Updated</html>", WidgetVersion = "3.9.0" });

            // Assert
            result.Should().NotBeNull();
            result.PageContent.Should().Be("<html>Preview SignIn Updated</html>");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/pages/sign-in/preview");
        }

        [Fact]
        public async Task ReplacePreviewSignInPage_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplacePreviewSignInPageAsync(null, new SignInPage()));
        }

        [Fact]
        public async Task ReplacePreviewSignInPageWithHttpInfo_ReturnsStatusCode200AndSignInPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildSignInPageJson("<html>Preview SignIn Updated</html>", "3.9.0"), HttpStatusCode.OK);
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ReplacePreviewSignInPageWithHttpInfoAsync(BrandId,
                new SignInPage { PageContent = "<html>Preview SignIn Updated</html>", WidgetVersion = "3.9.0" });

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.WidgetVersion.Should().Be("3.9.0");
        }

        [Fact]
        public async Task ReplacePreviewSignInPageWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ReplacePreviewSignInPageWithHttpInfoAsync(null, null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region ReplaceSignOutPageSettings

        [Fact]
        public async Task ReplaceSignOutPageSettings_WithExternallyHostedUrl_ReturnsUpdatedHostedPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildHostedPageJson("EXTERNALLY_HOSTED", "https://external.example.com/signout"));
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });
            var hostedPage = new HostedPage
            {
                Type = "EXTERNALLY_HOSTED",
                Url = "https://external.example.com/signout"
            };

            // Act
            var result = await api.ReplaceSignOutPageSettingsAsync(BrandId, hostedPage);

            // Assert
            result.Should().NotBeNull();
            result.Type.Value.Should().Be("EXTERNALLY_HOSTED");
            result.Url.Should().Be("https://external.example.com/signout");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/pages/sign-out/customized");
            mockClient.ReceivedBody.Should().Contain("EXTERNALLY_HOSTED");
        }

        [Fact]
        public async Task ReplaceSignOutPageSettings_WithOktaDefault_ReturnsOktaDefault()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildHostedPageJson("OKTA_DEFAULT", null));
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ReplaceSignOutPageSettingsAsync(BrandId,
                new HostedPage { Type = "OKTA_DEFAULT" });

            // Assert
            result.Type.Value.Should().Be("OKTA_DEFAULT");
        }

        [Fact]
        public async Task ReplaceSignOutPageSettings_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceSignOutPageSettingsAsync(null, new HostedPage()));
        }

        [Fact]
        public async Task ReplaceSignOutPageSettingsWithHttpInfo_ReturnsStatusCode200AndHostedPage()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildHostedPageJson("EXTERNALLY_HOSTED", "https://signout.example.com"), HttpStatusCode.OK);
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ReplaceSignOutPageSettingsWithHttpInfoAsync(BrandId,
                new HostedPage { Type = "EXTERNALLY_HOSTED", Url = "https://signout.example.com" });

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Url.Should().Be("https://signout.example.com");
        }

        [Fact]
        public async Task ReplaceSignOutPageSettingsWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomPagesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ReplaceSignOutPageSettingsWithHttpInfoAsync(null, null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region Helpers

        private static string BuildErrorPageJson(string pageContent) =>
            $@"{{""pageContent"":""{pageContent}""}}";

        private static string BuildSignInPageJson(string pageContent, string widgetVersion) =>
            $@"{{""pageContent"":""{pageContent}"",""widgetVersion"":""{widgetVersion}""}}";

        private static string BuildPageRootJson() =>
            @"{""_links"":{""self"":{""href"":""https://test.okta.com""},""default"":{""href"":""https://test.okta.com""},""customized"":{""href"":""https://test.okta.com""},""preview"":{""href"":""https://test.okta.com""}}}";

        private static string BuildHostedPageJson(string type, string url)
        {
            if (url == null)
                return $@"{{""type"":""{type}""}}";
            return $@"{{""type"":""{type}"",""url"":""{url}""}}";
        }

        #endregion
    }
}
