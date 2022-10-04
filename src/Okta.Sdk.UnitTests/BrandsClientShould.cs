// <copyright file="BrandsClientShould.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            await client.Brands.SendTestEmailAsync(emailTemplateTestRequest, testBrandId, testTemplateName);

            mockRequestExecutor.ReceivedBody.Should().NotBeNullOrEmpty();
            mockRequestExecutor.ReceivedHttpVerbs.Count.Should().Be(1);
            mockRequestExecutor.ReceivedHttpVerbs[0].Should().Be(HttpVerb.Post);
            mockRequestExecutor.ReceivedHref.Should().Be($"/api/v1/brands/{testBrandId}/templates/email/{testTemplateName}/test");            
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

        [Fact]
        public async Task GetEmailCustomizationPreview()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);

            var emailTemplateCustomization = await client.Brands.GetEmailTemplateCustomizationPreviewAsync( "foo", "bar", "baz");

            mockRequestExecutor.ReceivedHref.Should().Be($"/api/v1/brands/foo/templates/email/bar/customizations/baz/preview");
            mockRequestExecutor.ReceivedHttpVerbs.Count.Should().Be(1);
            mockRequestExecutor.ReceivedHttpVerbs[0].Should().Be(HttpVerb.Get);
        }

        [Fact]
        public async Task CreateEmailTemplateCustomization()
        {
            var rawResponse = @"{
                ""body"": ""<!DOCTYPE html><html>...${activationLink}...</html>"",
                ""subject"": ""Test Subject"",
                ""language"": ""fr""}";
            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);

            var client = new TestableOktaClient(mockRequestExecutor);

            var emailTemplateCustomizationRequest = new EmailTemplateCustomizationRequest()
            {
                Body = "<!DOCTYPE html><html>...${activationLink}...</html>",
                Subject = "Test Subject",
                Language = "fr",
                IsDefault = false,
            };

            var emailTemplateCustomization = await client.Brands.CreateEmailTemplateCustomizationAsync(emailTemplateCustomizationRequest, "foo", "bar");

            mockRequestExecutor.ReceivedHref.Should().Be($"/api/v1/brands/foo/templates/email/bar/customizations");
            mockRequestExecutor.ReceivedHttpVerbs.Count.Should().Be(1);
            mockRequestExecutor.ReceivedHttpVerbs[0].Should().Be(HttpVerb.Post);

            emailTemplateCustomization.Should().NotBeNull();
            emailTemplateCustomization.Body.Should().Be(emailTemplateCustomizationRequest.Body);
            emailTemplateCustomization.Subject.Should().Be(emailTemplateCustomizationRequest.Subject);
            emailTemplateCustomization.Language.Should().Be(emailTemplateCustomizationRequest.Language);
        }

        [Fact]
        public async Task DeleteEmailTemplateCustomization()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty);
            var client = new TestableOktaClient(mockRequestExecutor);

            await client.Brands.DeleteEmailTemplateCustomizationAsync("foo", "bar", "baz");

            mockRequestExecutor.ReceivedHref.Should().Be($"/api/v1/brands/foo/templates/email/bar/customizations/baz");
            mockRequestExecutor.ReceivedHttpVerbs.Count.Should().Be(1);
            mockRequestExecutor.ReceivedHttpVerbs[0].Should().Be(HttpVerb.Delete);
        }

        [Fact]
        public async Task GetEmailTemplateCustomization()
        {
            var rawResponse = @"{
                ""body"": ""<!DOCTYPE html><html>...${activationLink}...</html>"",
                ""subject"": ""Test Subject"",
                ""language"": ""fr""}";
            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);

            var client = new TestableOktaClient(mockRequestExecutor);

            var retrievedEmailTemplateCustomization = await client.Brands.GetEmailTemplateCustomizationAsync("foo", "bar", "baz");

            mockRequestExecutor.ReceivedHref.Should().Be($"/api/v1/brands/foo/templates/email/bar/customizations/baz");
            mockRequestExecutor.ReceivedHttpVerbs.Count.Should().Be(1);
            mockRequestExecutor.ReceivedHttpVerbs[0].Should().Be(HttpVerb.Get);

            retrievedEmailTemplateCustomization.Should().NotBeNull();
            retrievedEmailTemplateCustomization.Body.Should().Be("<!DOCTYPE html><html>...${activationLink}...</html>");
            retrievedEmailTemplateCustomization.Subject.Should().Be("Test Subject");
            retrievedEmailTemplateCustomization.Language.Should().Be("fr");
        }

        [Fact]
        public async Task UpdateEmailTemplateCustomization()
        {
            var rawResponse = @"{
                ""body"": ""Updated Body"",
                ""subject"": ""Updated Subject"",
                ""language"": ""fr""}";

            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);

            var client = new TestableOktaClient(mockRequestExecutor);
            var emailTemplateCustomizationUpdateRequest = new EmailTemplateCustomizationRequest()
            {
                Body = "Updated Body",
                Subject = "Updated Subject",
                Language = "fr",
                IsDefault = false,
            };

            var updatedEmailTemplateCustomization = await client.Brands.UpdateEmailTemplateCustomizationAsync(emailTemplateCustomizationUpdateRequest, "foo", "bar", "baz");

            mockRequestExecutor.ReceivedHref.Should().Be($"/api/v1/brands/foo/templates/email/bar/customizations/baz");
            mockRequestExecutor.ReceivedHttpVerbs.Count.Should().Be(1);
            mockRequestExecutor.ReceivedHttpVerbs[0].Should().Be(HttpVerb.Put);

            updatedEmailTemplateCustomization.Should().NotBeNull();
            updatedEmailTemplateCustomization.Body.Should().Be(emailTemplateCustomizationUpdateRequest.Body);
            updatedEmailTemplateCustomization.Subject.Should().Be(emailTemplateCustomizationUpdateRequest.Subject);
            updatedEmailTemplateCustomization.Language.Should().Be(emailTemplateCustomizationUpdateRequest.Language);
        }
    }
}
