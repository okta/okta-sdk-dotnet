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
    }
}
