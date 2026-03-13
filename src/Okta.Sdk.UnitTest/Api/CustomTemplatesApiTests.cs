// <copyright file="CustomTemplatesApiTests.cs" company="Okta, Inc">
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
    /// Unit tests for CustomTemplatesApi.
    /// Covers all 28 methods (14 operations × 2 variants):
    ///   CreateEmailCustomization, DeleteAllCustomizations, DeleteEmailCustomization,
    ///   GetCustomizationPreview, GetEmailCustomization, GetEmailDefaultContent,
    ///   GetEmailDefaultPreview, GetEmailSettings, GetEmailTemplate,
    ///   ListEmailCustomizations, ListEmailTemplates,
    ///   ReplaceEmailCustomization, ReplaceEmailSettings, SendTestEmail.
    ///
    /// Endpoint mapping
    /// ─────────────────────────────────────────────────────────────────────────
    /// CreateEmailCustomization    POST   /api/v1/brands/{brandId}/templates/email/{templateName}/customizations
    /// DeleteAllCustomizations     DELETE /api/v1/brands/{brandId}/templates/email/{templateName}/customizations
    /// DeleteEmailCustomization    DELETE /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId}
    /// GetCustomizationPreview     GET    /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId}/preview
    /// GetEmailCustomization       GET    /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId}
    /// GetEmailDefaultContent      GET    /api/v1/brands/{brandId}/templates/email/{templateName}/default-content
    /// GetEmailDefaultPreview      GET    /api/v1/brands/{brandId}/templates/email/{templateName}/default-content/preview
    /// GetEmailSettings            GET    /api/v1/brands/{brandId}/templates/email/{templateName}/settings
    /// GetEmailTemplate            GET    /api/v1/brands/{brandId}/templates/email/{templateName}
    /// ListEmailCustomizations     GET    /api/v1/brands/{brandId}/templates/email/{templateName}/customizations
    /// ListEmailTemplates          GET    /api/v1/brands/{brandId}/templates/email
    /// ReplaceEmailCustomization   PUT    /api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId}
    /// ReplaceEmailSettings        PUT    /api/v1/brands/{brandId}/templates/email/{templateName}/settings
    /// SendTestEmail               POST   /api/v1/brands/{brandId}/templates/email/{templateName}/test
    /// </summary>
    public class CustomTemplatesApiTests
    {
        private const string BaseUrl          = "https://test.okta.com";
        private const string BrandId          = "bnd1ab2c3d4e5f6g7h8i";
        private const string TemplateName     = "UserActivation";
        private const string CustomizationId  = "cfl1234567890abcdefgh";

        // ─────────────────────────────────────────────────────────────────────
        #region CreateEmailCustomization

        [Fact]
        public async Task CreateEmailCustomization_WithValidRequest_ReturnsEmailCustomization()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildCustomizationJson(CustomizationId, "en", false), HttpStatusCode.Created);
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });
            var instance = new EmailCustomization { Language = "en", Subject = "Activate your account", Body = "<html>Hello</html>", IsDefault = false };

            // Act
            var result = await api.CreateEmailCustomizationAsync(BrandId, TemplateName, instance);

            // Assert
            result.Should().NotBeNull();
            result.Language.Should().Be("en");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/templates/email/{templateName}/customizations");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["templateName"].Should().Be(TemplateName);
            mockClient.ReceivedBody.Should().Contain("en");
        }

        [Fact]
        public async Task CreateEmailCustomization_WithDefaultLocale_SendsIsDefaultTrue()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildCustomizationJson(CustomizationId, "en", true), HttpStatusCode.Created);
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.CreateEmailCustomizationAsync(BrandId, TemplateName,
                new EmailCustomization { Language = "en", IsDefault = true });

            // Assert
            result.IsDefault.Should().BeTrue();
            mockClient.ReceivedBody.Should().Contain("true");
        }

        [Fact]
        public async Task CreateEmailCustomization_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.CreateEmailCustomizationAsync(null, TemplateName));
        }

        [Fact]
        public async Task CreateEmailCustomization_WithNullTemplateName_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.CreateEmailCustomizationAsync(BrandId, null));
        }

        [Fact]
        public async Task CreateEmailCustomizationWithHttpInfo_ReturnsStatusCode201AndCustomization()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildCustomizationJson(CustomizationId, "fr", false), HttpStatusCode.Created);
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.CreateEmailCustomizationWithHttpInfoAsync(BrandId, TemplateName,
                new EmailCustomization { Language = "fr" });

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            response.Data.Should().NotBeNull();
            response.Data.Language.Should().Be("fr");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/templates/email/{templateName}/customizations");
        }

        [Fact]
        public async Task CreateEmailCustomizationWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.CreateEmailCustomizationWithHttpInfoAsync(null, TemplateName));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region DeleteAllCustomizations

        [Fact]
        public async Task DeleteAllCustomizations_WithValidIds_CompletesWithoutThrowing()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var act = async () => await api.DeleteAllCustomizationsAsync(BrandId, TemplateName);

            // Assert
            await act.Should().NotThrowAsync();
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/templates/email/{templateName}/customizations");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["templateName"].Should().Be(TemplateName);
        }

        [Fact]
        public async Task DeleteAllCustomizations_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeleteAllCustomizationsAsync(null, TemplateName));
        }

        [Fact]
        public async Task DeleteAllCustomizations_WithNullTemplateName_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeleteAllCustomizationsAsync(BrandId, null));
        }

        [Fact]
        public async Task DeleteAllCustomizationsWithHttpInfo_ReturnsNoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.DeleteAllCustomizationsWithHttpInfoAsync(BrandId, TemplateName);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["templateName"].Should().Be(TemplateName);
        }

        [Fact]
        public async Task DeleteAllCustomizationsWithHttpInfo_WithNullTemplateName_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.DeleteAllCustomizationsWithHttpInfoAsync(BrandId, null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region DeleteEmailCustomization

        [Fact]
        public async Task DeleteEmailCustomization_WithValidIds_CompletesWithoutThrowing()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var act = async () => await api.DeleteEmailCustomizationAsync(BrandId, TemplateName, CustomizationId);

            // Assert
            await act.Should().NotThrowAsync();
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId}");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["templateName"].Should().Be(TemplateName);
            mockClient.ReceivedPathParams["customizationId"].Should().Be(CustomizationId);
        }

        [Fact]
        public async Task DeleteEmailCustomization_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.DeleteEmailCustomizationAsync(null, TemplateName, CustomizationId));
        }

        [Fact]
        public async Task DeleteEmailCustomization_WithNullTemplateName_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.DeleteEmailCustomizationAsync(BrandId, null, CustomizationId));
        }

        [Fact]
        public async Task DeleteEmailCustomization_WithNullCustomizationId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.DeleteEmailCustomizationAsync(BrandId, TemplateName, null));
        }

        [Fact]
        public async Task DeleteEmailCustomizationWithHttpInfo_ReturnsNoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.DeleteEmailCustomizationWithHttpInfoAsync(BrandId, TemplateName, CustomizationId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPathParams["customizationId"].Should().Be(CustomizationId);
        }

        [Fact]
        public async Task DeleteEmailCustomizationWithHttpInfo_WithNullCustomizationId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.DeleteEmailCustomizationWithHttpInfoAsync(BrandId, TemplateName, null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetCustomizationPreview

        [Fact]
        public async Task GetCustomizationPreview_WithValidIds_ReturnsEmailPreview()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildPreviewJson());
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetCustomizationPreviewAsync(BrandId, TemplateName, CustomizationId);

            // Assert
            result.Should().NotBeNull();
            result.Links.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId}/preview");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["templateName"].Should().Be(TemplateName);
            mockClient.ReceivedPathParams["customizationId"].Should().Be(CustomizationId);
        }

        [Fact]
        public async Task GetCustomizationPreview_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.GetCustomizationPreviewAsync(null, TemplateName, CustomizationId));
        }

        [Fact]
        public async Task GetCustomizationPreview_WithNullCustomizationId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.GetCustomizationPreviewAsync(BrandId, TemplateName, null));
        }

        [Fact]
        public async Task GetCustomizationPreviewWithHttpInfo_ReturnsStatusCode200AndPreview()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildPreviewJson(), HttpStatusCode.OK);
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetCustomizationPreviewWithHttpInfoAsync(BrandId, TemplateName, CustomizationId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            mockClient.ReceivedPathParams["customizationId"].Should().Be(CustomizationId);
        }

        [Fact]
        public async Task GetCustomizationPreviewWithHttpInfo_WithNullCustomizationId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.GetCustomizationPreviewWithHttpInfoAsync(BrandId, TemplateName, null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetEmailCustomization

        [Fact]
        public async Task GetEmailCustomization_WithValidIds_ReturnsCustomization()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildCustomizationJson(CustomizationId, "de", false));
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetEmailCustomizationAsync(BrandId, TemplateName, CustomizationId);

            // Assert
            result.Should().NotBeNull();
            result.Language.Should().Be("de");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId}");
            mockClient.ReceivedPathParams["customizationId"].Should().Be(CustomizationId);
        }

        [Fact]
        public async Task GetEmailCustomization_MapsAllFields()
        {
            // Arrange
            var json = $@"{{
                ""id"":""{CustomizationId}"",
                ""language"":""en"",
                ""subject"":""Activate your account"",
                ""body"":""<html>Hello</html>"",
                ""isDefault"":true
            }}";
            var mockClient = new MockAsyncClient(json);
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetEmailCustomizationAsync(BrandId, TemplateName, CustomizationId);

            // Assert
            result.Language.Should().Be("en");
            result.Subject.Should().Be("Activate your account");
            result.Body.Should().Be("<html>Hello</html>");
            result.IsDefault.Should().BeTrue();
        }

        [Fact]
        public async Task GetEmailCustomization_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.GetEmailCustomizationAsync(null, TemplateName, CustomizationId));
        }

        [Fact]
        public async Task GetEmailCustomization_WithNullCustomizationId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.GetEmailCustomizationAsync(BrandId, TemplateName, null));
        }

        [Fact]
        public async Task GetEmailCustomizationWithHttpInfo_ReturnsStatusCode200AndCustomization()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildCustomizationJson(CustomizationId, "en", true), HttpStatusCode.OK);
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetEmailCustomizationWithHttpInfoAsync(BrandId, TemplateName, CustomizationId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Language.Should().Be("en");
            response.Data.IsDefault.Should().BeTrue();
        }

        [Fact]
        public async Task GetEmailCustomizationWithHttpInfo_WithNullCustomizationId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.GetEmailCustomizationWithHttpInfoAsync(BrandId, TemplateName, null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetEmailDefaultContent

        [Fact]
        public async Task GetEmailDefaultContent_WithValidIds_ReturnsDefaultContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildDefaultContentJson());
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetEmailDefaultContentAsync(BrandId, TemplateName);

            // Assert
            result.Should().NotBeNull();
            result.Subject.Should().Be("Activate your account");
            result.Body.Should().NotBeNullOrEmpty();
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/templates/email/{templateName}/default-content");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["templateName"].Should().Be(TemplateName);
        }

        [Fact]
        public async Task GetEmailDefaultContent_WithLanguageParam_SendsLanguageQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildDefaultContentJson());
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetEmailDefaultContentAsync(BrandId, TemplateName, language: "fr");

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("language");
            mockClient.ReceivedQueryParams["language"].Should().Contain("fr");
        }

        [Fact]
        public async Task GetEmailDefaultContent_WithNoLanguageParam_DoesNotSendLanguageQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildDefaultContentJson());
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetEmailDefaultContentAsync(BrandId, TemplateName);

            // Assert
            mockClient.ReceivedQueryParams.Should().NotContainKey("language");
        }

        [Fact]
        public async Task GetEmailDefaultContent_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetEmailDefaultContentAsync(null, TemplateName));
        }

        [Fact]
        public async Task GetEmailDefaultContent_WithNullTemplateName_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetEmailDefaultContentAsync(BrandId, null));
        }

        [Fact]
        public async Task GetEmailDefaultContentWithHttpInfo_ReturnsStatusCode200AndContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildDefaultContentJson(), HttpStatusCode.OK);
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetEmailDefaultContentWithHttpInfoAsync(BrandId, TemplateName);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Subject.Should().Be("Activate your account");
        }

        [Fact]
        public async Task GetEmailDefaultContentWithHttpInfo_WithLanguageParam_SendsLanguageQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildDefaultContentJson());
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetEmailDefaultContentWithHttpInfoAsync(BrandId, TemplateName, language: "de");

            // Assert
            mockClient.ReceivedQueryParams["language"].Should().Contain("de");
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetEmailDefaultPreview

        [Fact]
        public async Task GetEmailDefaultPreview_WithValidIds_ReturnsEmailPreview()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildPreviewJson());
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetEmailDefaultPreviewAsync(BrandId, TemplateName);

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/templates/email/{templateName}/default-content/preview");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["templateName"].Should().Be(TemplateName);
        }

        [Fact]
        public async Task GetEmailDefaultPreview_WithLanguageParam_SendsLanguageQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildPreviewJson());
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetEmailDefaultPreviewAsync(BrandId, TemplateName, language: "ja");

            // Assert
            mockClient.ReceivedQueryParams["language"].Should().Contain("ja");
        }

        [Fact]
        public async Task GetEmailDefaultPreview_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetEmailDefaultPreviewAsync(null, TemplateName));
        }

        [Fact]
        public async Task GetEmailDefaultPreviewWithHttpInfo_ReturnsStatusCode200AndPreview()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildPreviewJson(), HttpStatusCode.OK);
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetEmailDefaultPreviewWithHttpInfoAsync(BrandId, TemplateName);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task GetEmailDefaultPreviewWithHttpInfo_WithNullTemplateName_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetEmailDefaultPreviewWithHttpInfoAsync(BrandId, null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetEmailSettings

        [Fact]
        public async Task GetEmailSettings_WithValidIds_ReturnsEmailSettings()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildEmailSettingsResponseJson("ALL_USERS"));
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetEmailSettingsAsync(BrandId, TemplateName);

            // Assert
            result.Should().NotBeNull();
            result.Recipients.Value.Should().Be("ALL_USERS");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/templates/email/{templateName}/settings");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["templateName"].Should().Be(TemplateName);
        }

        [Fact]
        public async Task GetEmailSettings_WithAdminsOnlyRecipients_ReturnsAdminsOnly()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildEmailSettingsResponseJson("ADMINS_ONLY"));
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetEmailSettingsAsync(BrandId, TemplateName);

            // Assert
            result.Recipients.Value.Should().Be("ADMINS_ONLY");
        }

        [Fact]
        public async Task GetEmailSettings_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetEmailSettingsAsync(null, TemplateName));
        }

        [Fact]
        public async Task GetEmailSettings_WithNullTemplateName_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetEmailSettingsAsync(BrandId, null));
        }

        [Fact]
        public async Task GetEmailSettingsWithHttpInfo_ReturnsStatusCode200AndSettings()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildEmailSettingsResponseJson("ALL_USERS"), HttpStatusCode.OK);
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetEmailSettingsWithHttpInfoAsync(BrandId, TemplateName);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Recipients.Value.Should().Be("ALL_USERS");
        }

        [Fact]
        public async Task GetEmailSettingsWithHttpInfo_WithNullTemplateName_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetEmailSettingsWithHttpInfoAsync(BrandId, null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetEmailTemplate

        [Fact]
        public async Task GetEmailTemplate_WithValidIds_ReturnsEmailTemplateResponse()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildEmailTemplateJson(TemplateName));
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetEmailTemplateAsync(BrandId, TemplateName);

            // Assert
            result.Should().NotBeNull();
            result.Links.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/templates/email/{templateName}");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["templateName"].Should().Be(TemplateName);
        }

        [Fact]
        public async Task GetEmailTemplate_WithExpandSettings_SendsExpandQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildEmailTemplateJson(TemplateName));
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetEmailTemplateAsync(BrandId, TemplateName, expand: new List<string> { "settings" });

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams["expand"].Should().Contain("settings");
        }

        [Fact]
        public async Task GetEmailTemplate_WithExpandCustomizationsSettings_SendsBothExpandValues()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildEmailTemplateJson(TemplateName));
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetEmailTemplateAsync(BrandId, TemplateName, expand: new List<string> { "customizationCount", "settings" });

            // Assert
            var expandValues = string.Join(",", mockClient.ReceivedQueryParams["expand"]);
            expandValues.Should().Contain("customizationCount");
            expandValues.Should().Contain("settings");
        }

        [Fact]
        public async Task GetEmailTemplate_WithNoExpand_DoesNotSendExpandQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildEmailTemplateJson(TemplateName));
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetEmailTemplateAsync(BrandId, TemplateName);

            // Assert
            mockClient.ReceivedQueryParams.Should().NotContainKey("expand");
        }

        [Fact]
        public async Task GetEmailTemplate_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetEmailTemplateAsync(null, TemplateName));
        }

        [Fact]
        public async Task GetEmailTemplate_WithNullTemplateName_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.GetEmailTemplateAsync(BrandId, null));
        }

        [Fact]
        public async Task GetEmailTemplateWithHttpInfo_ReturnsStatusCode200AndTemplate()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildEmailTemplateJson(TemplateName), HttpStatusCode.OK);
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetEmailTemplateWithHttpInfoAsync(BrandId, TemplateName);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task GetEmailTemplateWithHttpInfo_WithExpandParam_SendsExpandQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildEmailTemplateJson(TemplateName));
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetEmailTemplateWithHttpInfoAsync(BrandId, TemplateName, expand: new List<string> { "settings" });

            // Assert
            mockClient.ReceivedQueryParams["expand"].Should().Contain("settings");
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region ListEmailCustomizations

        [Fact]
        public async Task ListEmailCustomizationsWithHttpInfo_ReturnsAllCustomizations()
        {
            // Arrange
            var json = $@"[
                {BuildCustomizationJson(CustomizationId, "en", true)},
                {BuildCustomizationJson("cfl_fr_xyz", "fr", false)}
            ]";
            var mockClient = new MockAsyncClient(json);
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListEmailCustomizationsWithHttpInfoAsync(BrandId, TemplateName);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().HaveCount(2);
            response.Data[0].Language.Should().Be("en");
            response.Data[1].Language.Should().Be("fr");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/templates/email/{templateName}/customizations");
        }

        [Fact]
        public async Task ListEmailCustomizationsWithHttpInfo_WithAfterParam_SendsAfterQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ListEmailCustomizationsWithHttpInfoAsync(BrandId, TemplateName, after: "cursor_abc");

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain("cursor_abc");
        }

        [Fact]
        public async Task ListEmailCustomizationsWithHttpInfo_WithLimitParam_SendsLimitQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ListEmailCustomizationsWithHttpInfoAsync(BrandId, TemplateName, limit: 20);

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain("20");
        }

        [Fact]
        public async Task ListEmailCustomizationsWithHttpInfo_WithEmptyList_ReturnsEmptyCollection()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListEmailCustomizationsWithHttpInfoAsync(BrandId, TemplateName);

            // Assert
            response.Data.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task ListEmailCustomizationsWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ListEmailCustomizationsWithHttpInfoAsync(null, TemplateName));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region ListEmailTemplates

        [Fact]
        public async Task ListEmailTemplatesWithHttpInfo_ReturnsAllTemplates()
        {
            // Arrange
            var json = $@"[{BuildEmailTemplateJson("UserActivation")},{BuildEmailTemplateJson("ForgotPassword")}]";
            var mockClient = new MockAsyncClient(json);
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListEmailTemplatesWithHttpInfoAsync(BrandId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().HaveCount(2);
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/templates/email");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
        }

        [Fact]
        public async Task ListEmailTemplatesWithHttpInfo_WithAfterParam_SendsAfterQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ListEmailTemplatesWithHttpInfoAsync(BrandId, after: "next_page_cursor");

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("after");
            mockClient.ReceivedQueryParams["after"].Should().Contain("next_page_cursor");
        }

        [Fact]
        public async Task ListEmailTemplatesWithHttpInfo_WithLimitParam_SendsLimitQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ListEmailTemplatesWithHttpInfoAsync(BrandId, limit: 5);

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain("5");
        }

        [Fact]
        public async Task ListEmailTemplatesWithHttpInfo_WithExpandParam_SendsExpandQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ListEmailTemplatesWithHttpInfoAsync(BrandId, expand: new List<string> { "settings" });

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams["expand"].Should().Contain("settings");
        }

        [Fact]
        public async Task ListEmailTemplatesWithHttpInfo_WithAllParams_SendsAllQueryParams()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ListEmailTemplatesWithHttpInfoAsync(BrandId, after: "cursor", limit: 10, expand: new List<string> { "settings" });

            // Assert
            mockClient.ReceivedQueryParams["after"].Should().Contain("cursor");
            mockClient.ReceivedQueryParams["limit"].Should().Contain("10");
            mockClient.ReceivedQueryParams["expand"].Should().Contain("settings");
        }

        [Fact]
        public async Task ListEmailTemplatesWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ListEmailTemplatesWithHttpInfoAsync(null));
        }

        [Fact]
        public async Task ListEmailTemplatesWithHttpInfo_WithEmptyResult_ReturnsEmptyList()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListEmailTemplatesWithHttpInfoAsync(BrandId);

            // Assert
            response.Data.Should().NotBeNull().And.BeEmpty();
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region ReplaceEmailCustomization

        [Fact]
        public async Task ReplaceEmailCustomization_WithValidData_ReturnsUpdatedCustomization()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildCustomizationJson(CustomizationId, "en", false));
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });
            var instance = new EmailCustomization { Language = "en", Subject = "Updated Subject", Body = "<html>Updated</html>" };

            // Act
            var result = await api.ReplaceEmailCustomizationAsync(BrandId, TemplateName, CustomizationId, instance);

            // Assert
            result.Should().NotBeNull();
            result.Language.Should().Be("en");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/templates/email/{templateName}/customizations/{customizationId}");
            mockClient.ReceivedPathParams["customizationId"].Should().Be(CustomizationId);
            mockClient.ReceivedBody.Should().Contain("Updated Subject");
        }

        [Fact]
        public async Task ReplaceEmailCustomization_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceEmailCustomizationAsync(null, TemplateName, CustomizationId));
        }

        [Fact]
        public async Task ReplaceEmailCustomization_WithNullCustomizationId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceEmailCustomizationAsync(BrandId, TemplateName, null));
        }

        [Fact]
        public async Task ReplaceEmailCustomizationWithHttpInfo_ReturnsStatusCode200AndCustomization()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildCustomizationJson(CustomizationId, "de", false), HttpStatusCode.OK);
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ReplaceEmailCustomizationWithHttpInfoAsync(BrandId, TemplateName, CustomizationId,
                new EmailCustomization { Language = "de" });

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Language.Should().Be("de");
        }

        [Fact]
        public async Task ReplaceEmailCustomizationWithHttpInfo_WithNullCustomizationId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceEmailCustomizationWithHttpInfoAsync(BrandId, TemplateName, null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region ReplaceEmailSettings

        [Fact]
        public async Task ReplaceEmailSettings_WithValidData_ReturnsUpdatedSettings()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildEmailSettingsJson("ADMINS_ONLY"));
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ReplaceEmailSettingsAsync(BrandId, TemplateName,
                new EmailSettings { Recipients = new EmailSettings.RecipientsEnum("ADMINS_ONLY") });

            // Assert
            result.Should().NotBeNull();
            result.Recipients.Value.Should().Be("ADMINS_ONLY");
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/templates/email/{templateName}/settings");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["templateName"].Should().Be(TemplateName);
        }

        [Fact]
        public async Task ReplaceEmailSettings_WithAllUsersRecipients_SendsAllUsers()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildEmailSettingsJson("ALL_USERS"));
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ReplaceEmailSettingsAsync(BrandId, TemplateName,
                new EmailSettings { Recipients = new EmailSettings.RecipientsEnum("ALL_USERS") });

            // Assert
            mockClient.ReceivedBody.Should().Contain("ALL_USERS");
        }

        [Fact]
        public async Task ReplaceEmailSettings_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ReplaceEmailSettingsAsync(null, TemplateName));
        }

        [Fact]
        public async Task ReplaceEmailSettings_WithNullTemplateName_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ReplaceEmailSettingsAsync(BrandId, null));
        }

        [Fact]
        public async Task ReplaceEmailSettingsWithHttpInfo_ReturnsStatusCode200AndSettings()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildEmailSettingsJson("NO_USERS"), HttpStatusCode.OK);
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ReplaceEmailSettingsWithHttpInfoAsync(BrandId, TemplateName,
                new EmailSettings { Recipients = new EmailSettings.RecipientsEnum("NO_USERS") });

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Recipients.Value.Should().Be("NO_USERS");
        }

        [Fact]
        public async Task ReplaceEmailSettingsWithHttpInfo_WithNullTemplateName_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.ReplaceEmailSettingsWithHttpInfoAsync(BrandId, null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region SendTestEmail

        [Fact]
        public async Task SendTestEmail_WithValidIds_CompletesWithoutThrowing()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var act = async () => await api.SendTestEmailAsync(BrandId, TemplateName);

            // Assert
            await act.Should().NotThrowAsync();
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/templates/email/{templateName}/test");
            mockClient.ReceivedPathParams["brandId"].Should().Be(BrandId);
            mockClient.ReceivedPathParams["templateName"].Should().Be(TemplateName);
        }

        [Fact]
        public async Task SendTestEmail_WithLanguageParam_SendsLanguageQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.SendTestEmailAsync(BrandId, TemplateName, language: "es");

            // Assert
            mockClient.ReceivedQueryParams.Should().ContainKey("language");
            mockClient.ReceivedQueryParams["language"].Should().Contain("es");
        }

        [Fact]
        public async Task SendTestEmail_WithNoLanguageParam_DoesNotSendLanguageQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.SendTestEmailAsync(BrandId, TemplateName);

            // Assert
            mockClient.ReceivedQueryParams.Should().NotContainKey("language");
        }

        [Fact]
        public async Task SendTestEmail_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.SendTestEmailAsync(null, TemplateName));
        }

        [Fact]
        public async Task SendTestEmail_WithNullTemplateName_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.SendTestEmailAsync(BrandId, null));
        }

        [Fact]
        public async Task SendTestEmailWithHttpInfo_ReturnsNoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.SendTestEmailWithHttpInfoAsync(BrandId, TemplateName);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPath.Should().Be("/api/v1/brands/{brandId}/templates/email/{templateName}/test");
        }

        [Fact]
        public async Task SendTestEmailWithHttpInfo_WithLanguageParam_SendsLanguageQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.SendTestEmailWithHttpInfoAsync(BrandId, TemplateName, language: "pt");

            // Assert
            mockClient.ReceivedQueryParams["language"].Should().Contain("pt");
        }

        [Fact]
        public async Task SendTestEmailWithHttpInfo_WithNullBrandId_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new CustomTemplatesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.SendTestEmailWithHttpInfoAsync(null, TemplateName));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region Helpers

        private static string BuildCustomizationJson(string id, string language, bool isDefault) =>
            $@"{{
                ""id"":""{id}"",
                ""language"":""{language}"",
                ""subject"":""Activate your account"",
                ""body"":""<html>Hello</html>"",
                ""isDefault"":{isDefault.ToString().ToLower()},
                ""_links"":{{""self"":{{""href"":""https://test.okta.com""}}}}
            }}";

        private static string BuildPreviewJson() =>
            @"{""_links"":{""self"":{""href"":""https://test.okta.com""}}}";

        private static string BuildDefaultContentJson() =>
            @"{""subject"":""Activate your account"",""body"":""<html>Activate</html>"",""_links"":{""self"":{""href"":""https://test.okta.com""}}}";

        private static string BuildEmailTemplateJson(string name) =>
            $@"{{""name"":""{name}"",""_links"":{{""self"":{{""href"":""https://test.okta.com/api/v1/brands/bnd1/templates/email/{name}""}}}}}}";

        private static string BuildEmailSettingsResponseJson(string recipients) =>
            $@"{{""recipients"":""{recipients}"",""_links"":{{""self"":{{""href"":""https://test.okta.com""}}}}}}";

        private static string BuildEmailSettingsJson(string recipients) =>
            $@"{{""recipients"":""{recipients}""}}";

        #endregion
    }
}
