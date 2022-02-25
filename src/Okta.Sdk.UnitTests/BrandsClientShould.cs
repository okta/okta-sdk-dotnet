// <copyright file="BrandsClientShould.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class BrandsClientShould
    {
        [Fact]
        public async Task UploadThemeLogo()
        {
            var rawResponse = @"{ ""url"": ""foo"" }";
            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Assets/org_logo.png");
            var file = File.OpenRead(filePath);
            var response = await client.Brands.UploadBrandThemeLogoAsync(file, "brandId", "themeId");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/brands/brandId/themes/themeId/logo");
            mockRequestExecutor.ReceivedBody.Should().NotBeNullOrEmpty();
            response.Url.Should().Be("foo");
        }

        [Fact]
        public async Task UploadThemeFavicon()
        {
            var rawResponse = @"{ ""url"": ""foo"" }";
            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Assets/org_logo.png");
            var file = File.OpenRead(filePath);
            var response = await client.Brands.UploadBrandThemeFaviconAsync(file, "brandId", "themeId");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/brands/brandId/themes/themeId/favicon");
            mockRequestExecutor.ReceivedBody.Should().NotBeNullOrEmpty();
            response.Url.Should().Be("foo");
        }

        [Fact]
        public async Task UploadThemeBackgroundImage()
        {
            var rawResponse = @"{ ""url"": ""foo"" }";
            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Assets/org_logo.png");
            var file = File.OpenRead(filePath);
            var response = await client.Brands.UploadBrandThemeBackgroundImageAsync(file, "brandId", "themeId");

            mockRequestExecutor.ReceivedHref.Should().Be("/api/v1/brands/brandId/themes/themeId/background-image");
            mockRequestExecutor.ReceivedBody.Should().NotBeNullOrEmpty();
            response.Url.Should().Be("foo");
        }

        [Fact]
        public async Task SendTestEmail()
        {
            var testBrandId = Guid.NewGuid().ToString();
            var testCustomizationId = Guid.NewGuid().ToString();
            var testTemplateName = $"test-template-name-{Guid.NewGuid()}";
            var testResponse = @"{ ""body"": ""test body"", ""fromAddress"": ""test fromAddress"", ""fromName"": ""test fromName"", ""subject"": ""test subject"" }";
            var mockRequestExecutor = new MockedStringRequestExecutor(testResponse);
            var client = new TestableOktaClient(mockRequestExecutor);
            var emailTemplateTestRequest = new EmailTemplateTestRequest
            {
                CustomizationId = testCustomizationId,
            };

            var response = await client.Brands.SendTestEmailAsync(emailTemplateTestRequest, testBrandId, testTemplateName);

            mockRequestExecutor.ReceivedBody.Should().NotBeNullOrEmpty();
            mockRequestExecutor.ReceivedHttpVerbs.Count.Should().Be(1);
            mockRequestExecutor.ReceivedHttpVerbs[0].Should().Be(HttpVerb.Post);
            mockRequestExecutor.ReceivedHref.Should().Be($"/api/v1/brands/{testBrandId}/templates/email/{testTemplateName}/test");
            response.Should().NotBeNull();
            response.Body.Should().Be("test body");
            response.FromAddress.Should().Be("test fromAddress");
            response.FromName.Should().Be("test fromName");
            response.Subject.Should().Be("test subject");
        }


        [Fact]
        public async Task DeleteEmailTemplateCustomizations()
        {
            var testBrandId = Guid.NewGuid().ToString();
            var testTemplateName = $"test-template-name-{Guid.NewGuid()}";
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);

            await client.Brands.DeleteEmailTemplateCustomizationsAsync(testBrandId, testTemplateName);

            mockRequestExecutor.ReceivedHref.Should().Be($"/api/v1/brands/{testBrandId}/templates/email/{testTemplateName}/customizations");
            mockRequestExecutor.ReceivedHttpVerbs.Count.Should().Be(1);
            mockRequestExecutor.ReceivedHttpVerbs[0].Should().Be(HttpVerb.Delete);
        }
    }
}
