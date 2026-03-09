// <copyright file="TemplateApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
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
    /// Unit tests for TemplateApi.
    /// Covers all 12 methods: CreateSmsTemplate, DeleteSmsTemplate, GetSmsTemplate,
    /// ListSmsTemplates, ReplaceSmsTemplate, UpdateSmsTemplate and their WithHttpInfo variants.
    /// </summary>
    public class TemplateApiTests
    {
        private const string BaseUrl    = "https://test.okta.com";
        private const string TemplateId = "cstb1ab2c3d4e5f6g7h8";

        // ─────────────────────────────────────────────────────────────────────
        #region CreateSmsTemplate

        [Fact]
        public async Task CreateSmsTemplate_WithValidTemplate_ReturnsSmsTemplate()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildSmsTemplateJson(TemplateId, "My Template"));
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });
            var template = BuildTemplate("My Template");

            // Act
            var result = await api.CreateSmsTemplateAsync(template);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(TemplateId);
            result.Name.Should().Be("My Template");
            result.Type.Should().Be(SmsTemplateType.SMSVERIFYCODE);
            result.Template.Should().Contain("${code}");
            mockClient.ReceivedPath.Should().Be("/api/v1/templates/sms");
            mockClient.ReceivedBody.Should().Contain("My Template");
            mockClient.ReceivedBody.Should().Contain("${code}");
        }

        [Fact]
        public async Task CreateSmsTemplate_ResponseMapsAllFields()
        {
            // Arrange
            var json = $@"{{
                ""id"":""{TemplateId}"",
                ""name"":""Full Template"",
                ""type"":""SMS_VERIFY_CODE"",
                ""template"":""Your code is ${{code}}"",
                ""created"":""2024-01-01T00:00:00.000Z"",
                ""lastUpdated"":""2024-06-15T12:00:00.000Z"",
                ""translations"":{{""es"":""Su código es ${{code}}"",""fr"":""Votre code est ${{code}}""}}
            }}";
            var mockClient = new MockAsyncClient(json);
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.CreateSmsTemplateAsync(BuildTemplate("Full Template"));

            // Assert
            result.Id.Should().Be(TemplateId);
            result.Name.Should().Be("Full Template");
            result.Type.Should().Be(SmsTemplateType.SMSVERIFYCODE);
            result.Template.Should().Be("Your code is ${code}");
            result.Created.Should().Be(DateTimeOffset.Parse("2024-01-01T00:00:00.000Z"));
            result.LastUpdated.Should().Be(DateTimeOffset.Parse("2024-06-15T12:00:00.000Z"));
            result.Translations.Should().NotBeNull();
        }

        [Fact]
        public async Task CreateSmsTemplate_WithTranslations_SendsTranslationsInBody()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildSmsTemplateJson(TemplateId, "Translated Template"));
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });
            var template = BuildTemplate("Translated Template");
            template.Translations = new { es = "Su código ${code}", fr = "Votre code ${code}" };

            // Act
            await api.CreateSmsTemplateAsync(template);

            // Assert
            mockClient.ReceivedBody.Should().Contain("es");
            mockClient.ReceivedBody.Should().Contain("fr");
        }

        [Fact]
        public async Task CreateSmsTemplateWithHttpInfo_ReturnsStatusCode200AndTemplate()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildSmsTemplateJson(TemplateId, "My Template"), HttpStatusCode.OK);
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.CreateSmsTemplateWithHttpInfoAsync(BuildTemplate("My Template"));

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(TemplateId);
            response.Data.Name.Should().Be("My Template");
            mockClient.ReceivedPath.Should().Be("/api/v1/templates/sms");
        }

        [Fact]
        public async Task CreateSmsTemplateWithHttpInfo_WithNullTemplate_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.CreateSmsTemplateWithHttpInfoAsync(null));
        }

        [Fact]
        public async Task CreateSmsTemplate_WithNullTemplate_ThrowsApiException()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}");
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            await Assert.ThrowsAsync<ApiException>(() => api.CreateSmsTemplateAsync(null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region DeleteSmsTemplate

        [Fact]
        public async Task DeleteSmsTemplate_WithValidId_CompletesWithoutThrowing()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var act = async () => await api.DeleteSmsTemplateAsync(TemplateId);

            // Assert
            await act.Should().NotThrowAsync();
            mockClient.ReceivedPath.Should().Be("/api/v1/templates/sms/{templateId}");
            mockClient.ReceivedPathParams["templateId"].Should().Be(TemplateId);
        }

        [Fact]
        public async Task DeleteSmsTemplate_WithNullTemplateId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.DeleteSmsTemplateAsync(null));
        }

        [Fact]
        public async Task DeleteSmsTemplateWithHttpInfo_ReturnsNoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.DeleteSmsTemplateWithHttpInfoAsync(TemplateId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            mockClient.ReceivedPath.Should().Be("/api/v1/templates/sms/{templateId}");
            mockClient.ReceivedPathParams["templateId"].Should().Be(TemplateId);
        }

        [Fact]
        public async Task DeleteSmsTemplateWithHttpInfo_WithNullTemplateId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.DeleteSmsTemplateWithHttpInfoAsync(null));
        }

        /// <summary>
        /// DELETE is idempotent — a non-existent ID returns 204, not 404.
        /// The API unconditionally returns NoContent regardless of whether the resource existed.
        /// </summary>
        [Fact]
        public async Task DeleteSmsTemplateWithHttpInfo_WithNonExistentId_ReturnsNoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient("{}", HttpStatusCode.NoContent);
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.DeleteSmsTemplateWithHttpInfoAsync("non-existent-id-99999");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region GetSmsTemplate

        [Fact]
        public async Task GetSmsTemplate_WithValidId_ReturnsSmsTemplate()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildSmsTemplateJson(TemplateId, "My Template"));
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetSmsTemplateAsync(TemplateId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(TemplateId);
            result.Name.Should().Be("My Template");
            result.Type.Should().Be(SmsTemplateType.SMSVERIFYCODE);
            mockClient.ReceivedPath.Should().Be("/api/v1/templates/sms/{templateId}");
            mockClient.ReceivedPathParams["templateId"].Should().Be(TemplateId);
        }

        [Fact]
        public async Task GetSmsTemplate_WithDefaultId_ReturnsBuiltInDefaultTemplate()
        {
            // Arrange — "default" is a well-known ID that always resolves to the built-in template.
            var json = @"{""id"":""default"",""name"":""Default"",""type"":""SMS_VERIFY_CODE"",""template"":""Your verification code is ${code}.""}";
            var mockClient = new MockAsyncClient(json);
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetSmsTemplateAsync("default");

            // Assert
            result.Id.Should().Be("default");
            result.Template.Should().Contain("${code}");
            mockClient.ReceivedPathParams["templateId"].Should().Be("default");
        }

        [Fact]
        public async Task GetSmsTemplate_WithNullTemplateId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.GetSmsTemplateAsync(null));
        }

        [Fact]
        public async Task GetSmsTemplateWithHttpInfo_ReturnsSmsTemplateAndStatusCode200()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildSmsTemplateJson(TemplateId, "My Template"), HttpStatusCode.OK);
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetSmsTemplateWithHttpInfoAsync(TemplateId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(TemplateId);
            mockClient.ReceivedPathParams["templateId"].Should().Be(TemplateId);
        }

        [Fact]
        public async Task GetSmsTemplateWithHttpInfo_WithNullTemplateId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.GetSmsTemplateWithHttpInfoAsync(null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region ListSmsTemplates

        [Fact]
        public async Task ListSmsTemplatesWithHttpInfo_WithNoFilter_ReturnsAllTemplates()
        {
            // Arrange
            var templateOne     = BuildSmsTemplateJson(TemplateId, "Template One");
            var templateDefault = BuildSmsTemplateJson("default",  "Default");
            var json = $"[{templateOne},{templateDefault}]";
            var mockClient = new MockAsyncClient(json);
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListSmsTemplatesWithHttpInfoAsync();

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().HaveCount(2);
            response.Data[0].Id.Should().Be(TemplateId);
            response.Data[1].Id.Should().Be("default");
            mockClient.ReceivedPath.Should().Be("/api/v1/templates/sms");
        }

        [Fact]
        public async Task ListSmsTemplatesWithHttpInfo_WithTypeFilter_SendsTemplateTypeQueryParam()
        {
            // Arrange
            var json = $"[{BuildSmsTemplateJson(TemplateId, "My Template")}]";
            var mockClient = new MockAsyncClient(json);
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListSmsTemplatesWithHttpInfoAsync(templateType: SmsTemplateType.SMSVERIFYCODE);

            // Assert
            response.Data.Should().HaveCount(1);
            response.Data[0].Type.Should().Be(SmsTemplateType.SMSVERIFYCODE);
            mockClient.ReceivedQueryParams.Should().ContainKey("templateType");
            mockClient.ReceivedQueryParams["templateType"].Should().Contain("SMS_VERIFY_CODE");
        }

        [Fact]
        public async Task ListSmsTemplatesWithHttpInfo_WithNoFilter_DoesNotSendTemplateTypeQueryParam()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ListSmsTemplatesWithHttpInfoAsync();

            // Assert
            mockClient.ReceivedQueryParams.Should().NotContainKey("templateType");
        }

        [Fact]
        public async Task ListSmsTemplatesWithHttpInfo_EmptyResult_ReturnsEmptyCollection()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListSmsTemplatesWithHttpInfoAsync();

            // Assert
            response.Data.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void ListSmsTemplates_WithNullType_ReturnsCollectionClient()
        {
            // Arrange
            var mockClient = new MockAsyncClient("[]");
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var client = api.ListSmsTemplates();

            // Assert — verify the collection client is created (not null)
            client.Should().NotBeNull();
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region ReplaceSmsTemplate

        [Fact]
        public async Task ReplaceSmsTemplate_WithValidData_ReturnsSmsTemplate()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildSmsTemplateJson(TemplateId, "Replaced Template"));
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });
            var template = BuildTemplate("Replaced Template", "Replaced: your code is ${code}");

            // Act
            var result = await api.ReplaceSmsTemplateAsync(TemplateId, template);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(TemplateId);
            result.Name.Should().Be("Replaced Template");
            mockClient.ReceivedPath.Should().Be("/api/v1/templates/sms/{templateId}");
            mockClient.ReceivedPathParams["templateId"].Should().Be(TemplateId);
            mockClient.ReceivedBody.Should().Contain("Replaced Template");
        }

        [Fact]
        public async Task ReplaceSmsTemplate_WithNullTemplateId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceSmsTemplateAsync(null, BuildTemplate("T")));
        }

        [Fact]
        public async Task ReplaceSmsTemplate_WithNullSmsTemplate_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceSmsTemplateAsync(TemplateId, null));
        }

        [Fact]
        public async Task ReplaceSmsTemplate_SendsFullTemplateBody()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildSmsTemplateJson(TemplateId, "T"));
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });
            var template = BuildTemplate("T", "Code: ${code}");
            template.Type = SmsTemplateType.SMSVERIFYCODE;

            // Act
            await api.ReplaceSmsTemplateAsync(TemplateId, template);

            // Assert
            mockClient.ReceivedBody.Should().Contain("SMS_VERIFY_CODE");
            mockClient.ReceivedBody.Should().Contain("Code: ${code}");
        }

        [Fact]
        public async Task ReplaceSmsTemplateWithHttpInfo_ReturnsSmsTemplateAndStatusCode200()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildSmsTemplateJson(TemplateId, "Replaced"), HttpStatusCode.OK);
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ReplaceSmsTemplateWithHttpInfoAsync(TemplateId, BuildTemplate("Replaced"));

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Id.Should().Be(TemplateId);
            response.Data.Name.Should().Be("Replaced");
        }

        [Fact]
        public async Task ReplaceSmsTemplateWithHttpInfo_WithNullTemplateId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceSmsTemplateWithHttpInfoAsync(null, BuildTemplate("T")));
        }

        [Fact]
        public async Task ReplaceSmsTemplateWithHttpInfo_WithNullSmsTemplate_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.ReplaceSmsTemplateWithHttpInfoAsync(TemplateId, null));
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region UpdateSmsTemplate (partial merge via POST)

        [Fact]
        public async Task UpdateSmsTemplate_WithValidData_ReturnsMergedTemplate()
        {
            // Arrange
            var responseJson = BuildSmsTemplateJsonWithTranslations(TemplateId, "My Template");
            var mockClient = new MockAsyncClient(responseJson);
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });
            var patch = new SmsTemplate { Translations = new { es = "Su código ${code}" } };

            // Act
            var result = await api.UpdateSmsTemplateAsync(TemplateId, patch);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(TemplateId);
            result.Translations.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Be("/api/v1/templates/sms/{templateId}");
            mockClient.ReceivedPathParams["templateId"].Should().Be(TemplateId);
        }

        [Fact]
        public async Task UpdateSmsTemplate_SendsPatchBodyToEndpoint()
        {
            // Arrange
            var mockClient = new MockAsyncClient(BuildSmsTemplateJson(TemplateId, "T"));
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });
            var patch = new SmsTemplate { Translations = new { de = "Ihr Code: ${code}" } };

            // Act
            await api.UpdateSmsTemplateAsync(TemplateId, patch);

            // Assert
            mockClient.ReceivedBody.Should().Contain("de");
        }

        [Fact]
        public async Task UpdateSmsTemplate_WithNullTemplateId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.UpdateSmsTemplateAsync(null, new SmsTemplate()));
        }

        [Fact]
        public async Task UpdateSmsTemplate_WithNullSmsTemplate_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.UpdateSmsTemplateAsync(TemplateId, null));
        }

        [Fact]
        public async Task UpdateSmsTemplateWithHttpInfo_ReturnsUpdatedTemplateAndStatusCode200()
        {
            // Arrange
            var responseJson = BuildSmsTemplateJsonWithTranslations(TemplateId, "My Template");
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });
            var patch = new SmsTemplate { Translations = new { fr = "Votre code ${code}" } };

            // Act
            var response = await api.UpdateSmsTemplateWithHttpInfoAsync(TemplateId, patch);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(TemplateId);
            response.Data.Translations.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Be("/api/v1/templates/sms/{templateId}");
        }

        [Fact]
        public async Task UpdateSmsTemplateWithHttpInfo_WithNullTemplateId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.UpdateSmsTemplateWithHttpInfoAsync(null, new SmsTemplate()));
        }

        [Fact]
        public async Task UpdateSmsTemplateWithHttpInfo_WithNullSmsTemplate_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("{}");
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() =>
                api.UpdateSmsTemplateWithHttpInfoAsync(TemplateId, null));
        }

        [Fact]
        public async Task UpdateSmsTemplate_CanAddNewLanguageTranslation()
        {
            // Arrange — response simulates server merging old + new translations
            var responseJson = BuildSmsTemplateJsonWithTranslations(TemplateId, "T");
            var mockClient = new MockAsyncClient(responseJson);
            var api = new TemplateApi(mockClient, new Configuration { BasePath = BaseUrl });

            // patch only adds 'es', existing 'fr' would be kept by the server
            var patch = new SmsTemplate { Translations = new { es = "Su código ${code}" } };

            // Act
            var result = await api.UpdateSmsTemplateAsync(TemplateId, patch);

            // Assert — merged result (from server) includes translations
            result.Translations.Should().NotBeNull();
        }

        #endregion

        // ─────────────────────────────────────────────────────────────────────
        #region Helpers

        private static SmsTemplate BuildTemplate(string name, string templateText = null) =>
            new SmsTemplate
            {
                Name     = name,
                Type     = SmsTemplateType.SMSVERIFYCODE,
                Template = templateText ?? $"Your verification code for {name} is ${{code}}",
            };

        private static string BuildSmsTemplateJson(string id, string name) =>
            $@"{{
                ""id"":""{id}"",
                ""name"":""{name}"",
                ""type"":""SMS_VERIFY_CODE"",
                ""template"":""Your code is ${{code}}"",
                ""created"":""2024-01-01T00:00:00.000Z"",
                ""lastUpdated"":""2024-06-15T12:00:00.000Z""
            }}";

        private static string BuildSmsTemplateJsonWithTranslations(string id, string name) =>
            $@"{{
                ""id"":""{id}"",
                ""name"":""{name}"",
                ""type"":""SMS_VERIFY_CODE"",
                ""template"":""Your code is ${{code}}"",
                ""created"":""2024-01-01T00:00:00.000Z"",
                ""lastUpdated"":""2024-06-15T12:00:00.000Z"",
                ""translations"":{{""es"":""Su código ${{code}}"",""fr"":""Votre code ${{code}}""}}
            }}";

        #endregion
    }
}
