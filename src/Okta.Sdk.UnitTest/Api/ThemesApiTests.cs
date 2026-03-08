// <copyright file="ThemesApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.IO;
using System.Net;
using System.Text;
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
    /// Unit tests for ThemesApi.
    /// Covers all 18 methods across 9 operations (each with a plain and WithHttpInfo variant):
    ///   DeleteBrandThemeBackgroundImage, DeleteBrandThemeFavicon, DeleteBrandThemeLogo,
    ///   GetBrandTheme, ListBrandThemes, ReplaceBrandTheme,
    ///   UploadBrandThemeBackgroundImage, UploadBrandThemeFavicon, UploadBrandThemeLogo.
    /// </summary>
    public class ThemesApiTests
    {
        private const string BaseUrl  = "https://test.okta.com";
        private const string BrandId  = "bnd1ab2c3d4e5f6g7h8i";
        private const string ThemeId  = "thm2ab3cd4ef5gh6ij7k";
        private const string ImageUrl = "https://example.okta.com/assets/img/bg.png";

        // ─────────────────────────────────────────────────────────────────────
        #region DeleteBrandThemeBackgroundImage

        [Fact]
        public async Task DeleteBrandThemeBackgroundImage_WithValidIds_CompletesWithoutThrowing()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var act = async () => await api.DeleteBrandThemeBackgroundImageAsync(BrandId, ThemeId);

            // Assert
            await act.Should().NotThrowAsync();
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/themes/{themeId}/background-image");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["themeId"].Should().Be(ThemeId);
        }

        [Fact]
        public async Task DeleteBrandThemeBackgroundImage_WithNullBrandId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.DeleteBrandThemeBackgroundImageAsync(null, ThemeId));
        }

        [Fact]
        public async Task DeleteBrandThemeBackgroundImage_WithNullThemeId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.DeleteBrandThemeBackgroundImageAsync(BrandId, null));
        }

        [Fact]
        public async Task DeleteBrandThemeBackgroundImageWithHttpInfo_ReturnsNoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.DeleteBrandThemeBackgroundImageWithHttpInfoAsync(BrandId, ThemeId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/themes/{themeId}/background-image");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["themeId"].Should().Be(ThemeId);
        }

        [Fact]
        public async Task DeleteBrandThemeBackgroundImageWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.DeleteBrandThemeBackgroundImageWithHttpInfoAsync(null, ThemeId));
        }

        [Fact]
        public async Task DeleteBrandThemeBackgroundImageWithHttpInfo_WithNullThemeId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.DeleteBrandThemeBackgroundImageWithHttpInfoAsync(BrandId, null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region DeleteBrandThemeFavicon

        [Fact]
        public async Task DeleteBrandThemeFavicon_WithValidIds_CompletesWithoutThrowing()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var act = async () => await api.DeleteBrandThemeFaviconAsync(BrandId, ThemeId);

            // Assert
            await act.Should().NotThrowAsync();
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/themes/{themeId}/favicon");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["themeId"].Should().Be(ThemeId);
        }

        [Fact]
        public async Task DeleteBrandThemeFavicon_WithNullBrandId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.DeleteBrandThemeFaviconAsync(null, ThemeId));
        }

        [Fact]
        public async Task DeleteBrandThemeFavicon_WithNullThemeId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.DeleteBrandThemeFaviconAsync(BrandId, null));
        }

        [Fact]
        public async Task DeleteBrandThemeFaviconWithHttpInfo_ReturnsNoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.DeleteBrandThemeFaviconWithHttpInfoAsync(BrandId, ThemeId);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/themes/{themeId}/favicon");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["themeId"].Should().Be(ThemeId);
        }

        [Fact]
        public async Task DeleteBrandThemeFaviconWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.DeleteBrandThemeFaviconWithHttpInfoAsync(null, ThemeId));
        }

        [Fact]
        public async Task DeleteBrandThemeFaviconWithHttpInfo_WithNullThemeId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.DeleteBrandThemeFaviconWithHttpInfoAsync(BrandId, null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region DeleteBrandThemeLogo

        [Fact]
        public async Task DeleteBrandThemeLogo_WithValidIds_CompletesWithoutThrowing()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var act = async () => await api.DeleteBrandThemeLogoAsync(BrandId, ThemeId);

            // Assert
            await act.Should().NotThrowAsync();
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/themes/{themeId}/logo");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["themeId"].Should().Be(ThemeId);
        }

        [Fact]
        public async Task DeleteBrandThemeLogo_WithNullBrandId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.DeleteBrandThemeLogoAsync(null, ThemeId));
        }

        [Fact]
        public async Task DeleteBrandThemeLogo_WithNullThemeId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.DeleteBrandThemeLogoAsync(BrandId, null));
        }

        [Fact]
        public async Task DeleteBrandThemeLogoWithHttpInfo_ReturnsNoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.DeleteBrandThemeLogoWithHttpInfoAsync(BrandId, ThemeId);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/themes/{themeId}/logo");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["themeId"].Should().Be(ThemeId);
        }

        [Fact]
        public async Task DeleteBrandThemeLogoWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.DeleteBrandThemeLogoWithHttpInfoAsync(null, ThemeId));
        }

        [Fact]
        public async Task DeleteBrandThemeLogoWithHttpInfo_WithNullThemeId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.DeleteBrandThemeLogoWithHttpInfoAsync(BrandId, null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetBrandTheme

        [Fact]
        public async Task GetBrandTheme_WithValidIds_ReturnsThemeResponse()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildThemeJson(ThemeId));
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetBrandThemeAsync(BrandId, ThemeId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(ThemeId);
            result.PrimaryColorHex.Should().Be("#1662dd");
            result.SignInPageTouchPointVariant.Should().Be(SignInPageTouchPointVariant.OKTADEFAULT);
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/themes/{themeId}");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["themeId"].Should().Be(ThemeId);
        }

        [Fact]
        public async Task GetBrandTheme_MapsAllThemeVariantFields()
        {
            // Arrange
            var json = $@"{{
                ""id"":""{ThemeId}"",
                ""primaryColorHex"":""#112233"",
                ""secondaryColorHex"":""#aabbcc"",
                ""primaryColorContrastHex"":""#ffffff"",
                ""secondaryColorContrastHex"":""#000000"",
                ""signInPageTouchPointVariant"":""OKTA_DEFAULT"",
                ""endUserDashboardTouchPointVariant"":""FULL_THEME"",
                ""errorPageTouchPointVariant"":""OKTA_DEFAULT"",
                ""loadingPageTouchPointVariant"":""NONE"",
                ""emailTemplateTouchPointVariant"":""FULL_THEME""
            }}";
            var mockClient = new MockAsyncClient(json);
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetBrandThemeAsync(BrandId, ThemeId);

            // Assert
            result.PrimaryColorHex.Should().Be("#112233");
            result.SecondaryColorHex.Should().Be("#aabbcc");
            result.PrimaryColorContrastHex.Should().Be("#ffffff");
            result.SecondaryColorContrastHex.Should().Be("#000000");
            result.SignInPageTouchPointVariant.Should().Be(SignInPageTouchPointVariant.OKTADEFAULT);
            result.EndUserDashboardTouchPointVariant.Should().Be(EndUserDashboardTouchPointVariant.FULLTHEME);
            result.EmailTemplateTouchPointVariant.Should().Be(EmailTemplateTouchPointVariant.FULLTHEME);
        }

        [Fact]
        public async Task GetBrandTheme_WithNullBrandId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.GetBrandThemeAsync(null, ThemeId));
        }

        [Fact]
        public async Task GetBrandTheme_WithNullThemeId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.GetBrandThemeAsync(BrandId, null));
        }

        [Fact]
        public async Task GetBrandThemeWithHttpInfo_ReturnsThemeAndStatusCode200()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildThemeJson(ThemeId), HttpStatusCode.OK);
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetBrandThemeWithHttpInfoAsync(BrandId, ThemeId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(ThemeId);
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["themeId"].Should().Be(ThemeId);
        }

        [Fact]
        public async Task GetBrandThemeWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.GetBrandThemeWithHttpInfoAsync(null, ThemeId));
        }

        [Fact]
        public async Task GetBrandThemeWithHttpInfo_WithNullThemeId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.GetBrandThemeWithHttpInfoAsync(BrandId, null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region ListBrandThemes

        [Fact]
        public async Task ListBrandThemesWithHttpInfo_ReturnsThemeList()
        {
            // Arrange
            var json = $"[{BuildThemeJson(ThemeId)}]";
            var mockClient = new MockAsyncClient(json);
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListBrandThemesWithHttpInfoAsync(BrandId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull().And.HaveCount(1);
            response.Data[0].Id.Should().Be(ThemeId);
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/themes");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
        }

        [Fact]
        public async Task ListBrandThemesWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.ListBrandThemesWithHttpInfoAsync(null));
        }

        [Fact]
        public async Task ListBrandThemesWithHttpInfo_EmptyList_ReturnsEmptyCollection()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListBrandThemesWithHttpInfoAsync(BrandId);

            // Assert
            response.Data.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void ListBrandThemes_WithNullBrandId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            Assert.Throws<ApiException>(() => api.ListBrandThemes(null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region ReplaceBrandTheme

        [Fact]
        public async Task ReplaceBrandTheme_WithValidRequest_ReturnsUpdatedTheme()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildThemeJson(ThemeId));
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = BuildUpdateThemeRequest();

            // Act
            var result = await api.ReplaceBrandThemeAsync(BrandId, ThemeId, request);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(ThemeId);
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/themes/{themeId}");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["themeId"].Should().Be(ThemeId);
            mockClient.ReceivedBody.Should().Contain("primaryColorHex");
        }

        [Fact]
        public async Task ReplaceBrandTheme_SendsAllVariantsInBody()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildThemeJson(ThemeId));
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });
            var request = new UpdateThemeRequest
            {
                SignInPageTouchPointVariant         = SignInPageTouchPointVariant.BACKGROUNDIMAGE,
                EndUserDashboardTouchPointVariant   = EndUserDashboardTouchPointVariant.FULLTHEME,
                ErrorPageTouchPointVariant          = ErrorPageTouchPointVariant.OKTADEFAULT,
                EmailTemplateTouchPointVariant      = EmailTemplateTouchPointVariant.FULLTHEME,
                PrimaryColorHex                    = "#ff0000",
                SecondaryColorHex                  = "#00ff00",
            };

            // Act
            await api.ReplaceBrandThemeAsync(BrandId, ThemeId, request);

            // Assert
            mockClient.ReceivedBody.Should().Contain("BACKGROUND_IMAGE");
            mockClient.ReceivedBody.Should().Contain("FULL_THEME");
            mockClient.ReceivedBody.Should().Contain("#ff0000");
            mockClient.ReceivedBody.Should().Contain("#00ff00");
        }

        [Fact]
        public async Task ReplaceBrandTheme_WithNullBrandId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceBrandThemeAsync(null, ThemeId, BuildUpdateThemeRequest()));
        }

        [Fact]
        public async Task ReplaceBrandTheme_WithNullThemeId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceBrandThemeAsync(BrandId, null, BuildUpdateThemeRequest()));
        }

        [Fact]
        public async Task ReplaceBrandTheme_WithNullThemeRequest_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceBrandThemeAsync(BrandId, ThemeId, null));
        }

        [Fact]
        public async Task ReplaceBrandThemeWithHttpInfo_ReturnsThemeAndStatusCode200()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildThemeJson(ThemeId), HttpStatusCode.OK);
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ReplaceBrandThemeWithHttpInfoAsync(BrandId, ThemeId, BuildUpdateThemeRequest());

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Id.Should().Be(ThemeId);
        }

        [Fact]
        public async Task ReplaceBrandThemeWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceBrandThemeWithHttpInfoAsync(null, ThemeId, BuildUpdateThemeRequest()));
        }

        [Fact]
        public async Task ReplaceBrandThemeWithHttpInfo_WithNullThemeId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceBrandThemeWithHttpInfoAsync(BrandId, null, BuildUpdateThemeRequest()));
        }

        [Fact]
        public async Task ReplaceBrandThemeWithHttpInfo_WithNullThemeRequest_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceBrandThemeWithHttpInfoAsync(BrandId, ThemeId, null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region UploadBrandThemeBackgroundImage

        [Fact]
        public async Task UploadBrandThemeBackgroundImage_WithValidStream_ReturnsImageUploadResponse()
        {
            // Arrange
            var responseJson = $@"{{""url"":""{ImageUrl}""}}";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("fake-image-data"));

            // Act
            var result = await api.UploadBrandThemeBackgroundImageAsync(BrandId, ThemeId, stream);

            // Assert
            result.Should().NotBeNull();
            result.Url.Should().Be(ImageUrl);
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/themes/{themeId}/background-image");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["themeId"].Should().Be(ThemeId);
        }

        [Fact]
        public async Task UploadBrandThemeBackgroundImage_WithNullBrandId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            using var stream = new MemoryStream();
            await Assert.ThrowsAsync<ApiException>(() =>
                api.UploadBrandThemeBackgroundImageAsync(null, ThemeId, stream));
        }

        [Fact]
        public async Task UploadBrandThemeBackgroundImage_WithNullThemeId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            using var stream = new MemoryStream();
            await Assert.ThrowsAsync<ApiException>(() =>
                api.UploadBrandThemeBackgroundImageAsync(BrandId, null, stream));
        }

        [Fact]
        public async Task UploadBrandThemeBackgroundImageWithHttpInfo_ReturnsImageUrlAndStatusCode200()
        {
            // Arrange
            var responseJson = $@"{{""url"":""{ImageUrl}""}}";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("fake-image-data"));

            // Act
            var response = await api.UploadBrandThemeBackgroundImageWithHttpInfoAsync(BrandId, ThemeId, stream);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Url.Should().Be(ImageUrl);
        }

        [Fact]
        public async Task UploadBrandThemeBackgroundImageWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            using var stream = new MemoryStream();
            await Assert.ThrowsAsync<ApiException>(() =>
                api.UploadBrandThemeBackgroundImageWithHttpInfoAsync(null, ThemeId, stream));
        }

        [Fact]
        public async Task UploadBrandThemeBackgroundImageWithHttpInfo_WithNullThemeId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            using var stream = new MemoryStream();
            await Assert.ThrowsAsync<ApiException>(() =>
                api.UploadBrandThemeBackgroundImageWithHttpInfoAsync(BrandId, null, stream));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region UploadBrandThemeFavicon

        [Fact]
        public async Task UploadBrandThemeFavicon_WithValidStream_ReturnsImageUploadResponse()
        {
            // Arrange
            var responseJson = $@"{{""url"":""{ImageUrl}""}}";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("fake-favicon-data"));

            // Act
            var result = await api.UploadBrandThemeFaviconAsync(BrandId, ThemeId, stream);

            // Assert
            result.Should().NotBeNull();
            result.Url.Should().Be(ImageUrl);
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/themes/{themeId}/favicon");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["themeId"].Should().Be(ThemeId);
        }

        [Fact]
        public async Task UploadBrandThemeFavicon_WithNullBrandId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            using var stream = new MemoryStream();
            await Assert.ThrowsAsync<ApiException>(() =>
                api.UploadBrandThemeFaviconAsync(null, ThemeId, stream));
        }

        [Fact]
        public async Task UploadBrandThemeFavicon_WithNullThemeId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            using var stream = new MemoryStream();
            await Assert.ThrowsAsync<ApiException>(() =>
                api.UploadBrandThemeFaviconAsync(BrandId, null, stream));
        }

        [Fact]
        public async Task UploadBrandThemeFaviconWithHttpInfo_ReturnsImageUrlAndStatusCode200()
        {
            // Arrange
            var responseJson = $@"{{""url"":""{ImageUrl}""}}";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("fake-favicon-data"));

            // Act
            var response = await api.UploadBrandThemeFaviconWithHttpInfoAsync(BrandId, ThemeId, stream);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Url.Should().Be(ImageUrl);
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/themes/{themeId}/favicon");
        }

        [Fact]
        public async Task UploadBrandThemeFaviconWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            using var stream = new MemoryStream();
            await Assert.ThrowsAsync<ApiException>(() =>
                api.UploadBrandThemeFaviconWithHttpInfoAsync(null, ThemeId, stream));
        }

        [Fact]
        public async Task UploadBrandThemeFaviconWithHttpInfo_WithNullThemeId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            using var stream = new MemoryStream();
            await Assert.ThrowsAsync<ApiException>(() =>
                api.UploadBrandThemeFaviconWithHttpInfoAsync(BrandId, null, stream));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region UploadBrandThemeLogo

        [Fact]
        public async Task UploadBrandThemeLogo_WithValidStream_ReturnsImageUploadResponse()
        {
            // Arrange
            var responseJson = $@"{{""url"":""{ImageUrl}""}}";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("fake-logo-data"));

            // Act
            var result = await api.UploadBrandThemeLogoAsync(BrandId, ThemeId, stream);

            // Assert
            result.Should().NotBeNull();
            result.Url.Should().Be(ImageUrl);
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/themes/{themeId}/logo");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["themeId"].Should().Be(ThemeId);
        }

        [Fact]
        public async Task UploadBrandThemeLogo_WithNullBrandId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            using var stream = new MemoryStream();
            await Assert.ThrowsAsync<ApiException>(() =>
                api.UploadBrandThemeLogoAsync(null, ThemeId, stream));
        }

        [Fact]
        public async Task UploadBrandThemeLogo_WithNullThemeId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            using var stream = new MemoryStream();
            await Assert.ThrowsAsync<ApiException>(() =>
                api.UploadBrandThemeLogoAsync(BrandId, null, stream));
        }

        [Fact]
        public async Task UploadBrandThemeLogoWithHttpInfo_ReturnsImageUrlAndStatusCode200()
        {
            // Arrange
            var responseJson = $@"{{""url"":""{ImageUrl}""}}";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("fake-logo-data"));

            // Act
            var response = await api.UploadBrandThemeLogoWithHttpInfoAsync(BrandId, ThemeId, stream);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Url.Should().Be(ImageUrl);
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/themes/{themeId}/logo");
        }

        [Fact]
        public async Task UploadBrandThemeLogoWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            using var stream = new MemoryStream();
            await Assert.ThrowsAsync<ApiException>(() =>
                api.UploadBrandThemeLogoWithHttpInfoAsync(null, ThemeId, stream));
        }

        [Fact]
        public async Task UploadBrandThemeLogoWithHttpInfo_WithNullThemeId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new ThemesApi(mockClient, new Configuration { BasePath = BaseUrl });

            using var stream = new MemoryStream();
            await Assert.ThrowsAsync<ApiException>(() =>
                api.UploadBrandThemeLogoWithHttpInfoAsync(BrandId, null, stream));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region Helpers

        private static string BuildThemeJson(string id) =>
            $@"{{
                ""id"":""{id}"",
                ""primaryColorHex"":""#1662dd"",
                ""primaryColorContrastHex"":""#ffffff"",
                ""secondaryColorHex"":""#ebebed"",
                ""secondaryColorContrastHex"":""#000000"",
                ""signInPageTouchPointVariant"":""OKTA_DEFAULT"",
                ""endUserDashboardTouchPointVariant"":""OKTA_DEFAULT"",
                ""errorPageTouchPointVariant"":""OKTA_DEFAULT"",
                ""loadingPageTouchPointVariant"":""NONE"",
                ""emailTemplateTouchPointVariant"":""OKTA_DEFAULT""
            }}";

        private static UpdateThemeRequest BuildUpdateThemeRequest() =>
            new UpdateThemeRequest
            {
                PrimaryColorHex                  = "#1662dd",
                PrimaryColorContrastHex          = "#ffffff",
                SecondaryColorHex                = "#ebebed",
                SecondaryColorContrastHex        = "#000000",
                SignInPageTouchPointVariant       = SignInPageTouchPointVariant.OKTADEFAULT,
                EndUserDashboardTouchPointVariant = EndUserDashboardTouchPointVariant.OKTADEFAULT,
                ErrorPageTouchPointVariant        = ErrorPageTouchPointVariant.OKTADEFAULT,
                EmailTemplateTouchPointVariant    = EmailTemplateTouchPointVariant.OKTADEFAULT,
            };

        #endregion
    }
}
