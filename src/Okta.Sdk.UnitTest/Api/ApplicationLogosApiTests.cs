// <copyright file="ApplicationLogosApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.IO;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.UnitTest.Internal;
using Xunit;

namespace Okta.Sdk.UnitTest.Api
{
    public class ApplicationLogosApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private const string TestAppId = "0oa1gjh63g214q0Hq0g4";

        #region UploadApplicationLogo Tests

        [Fact]
        public async Task UploadApplicationLogo_WithValidFile_CompletesSuccessfully()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.Created);
            var api = new ApplicationLogosApi(mockClient, new Configuration { BasePath = BaseUrl });
            var fileStream = new MemoryStream([0x89, 0x50, 0x4E, 0x47]); // PNG signature

            await api.UploadApplicationLogoAsync(TestAppId, fileStream);

            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("logo");
        }

        [Fact]
        public async Task UploadApplicationLogo_WithNullAppId_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("");
            var api = new ApplicationLogosApi(mockClient, new Configuration { BasePath = BaseUrl });
            var fileStream = new MemoryStream([0x89, 0x50, 0x4E, 0x47]);

            await Assert.ThrowsAsync<ApiException>(() => api.UploadApplicationLogoAsync(null, fileStream));
        }

        [Fact]
        public async Task UploadApplicationLogo_WithNullFile_ThrowsApiException()
        {
            var mockClient = new MockAsyncClient("");
            var api = new ApplicationLogosApi(mockClient, new Configuration { BasePath = BaseUrl });

            await Assert.ThrowsAsync<ApiException>(() => api.UploadApplicationLogoAsync(TestAppId, null));
        }

        [Fact]
        public async Task UploadApplicationLogoWithHttpInfo_ReturnsCreatedResponse()
        {
            var headers = new Multimap<string, string>
            {
                { "Content-Type", "application/json" },
                { "Location", $"{BaseUrl}/api/v1/apps/{TestAppId}" }
            };

            var mockClient = new MockAsyncClient("", HttpStatusCode.Created, headers);
            var api = new ApplicationLogosApi(mockClient, new Configuration { BasePath = BaseUrl });
            var fileStream = new MemoryStream([0x89, 0x50, 0x4E, 0x47]);

            var response = await api.UploadApplicationLogoWithHttpInfoAsync(TestAppId, fileStream);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            response.Headers.Should().ContainKey("Location");
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("logo");
        }

        [Fact]
        public async Task UploadApplicationLogoWithHttpInfo_WithPngFile_UploadsCorrectly()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.Created);
            var api = new ApplicationLogosApi(mockClient, new Configuration { BasePath = BaseUrl });
            
            // Create a minimal PNG file signature
            var pngSignature = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
            var fileStream = new MemoryStream(pngSignature);

            var response = await api.UploadApplicationLogoWithHttpInfoAsync(TestAppId, fileStream);

            response.StatusCode.Should().Be(HttpStatusCode.Created);
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("logo");
        }

        [Fact]
        public async Task UploadApplicationLogoWithHttpInfo_WithSvgFile_UploadsCorrectly()
        {
            var mockClient = new MockAsyncClient("", HttpStatusCode.Created);
            var api = new ApplicationLogosApi(mockClient, new Configuration { BasePath = BaseUrl });
            
            // Create a minimal SVG content
            var svgContent = System.Text.Encoding.UTF8.GetBytes("<svg xmlns=\"http://www.w3.org/2000/svg\"></svg>");
            var fileStream = new MemoryStream(svgContent);

            var response = await api.UploadApplicationLogoWithHttpInfoAsync(TestAppId, fileStream);

            response.StatusCode.Should().Be(HttpStatusCode.Created);
            mockClient.ReceivedPath.Should().Contain("apps");
            mockClient.ReceivedPath.Should().Contain("logo");
        }

        [Fact]
        public async Task UploadApplicationLogoWithHttpInfo_ReplacesExistingLogo()
        {
            // First upload
            var mockClient1 = new MockAsyncClient("", HttpStatusCode.Created);
            var api1 = new ApplicationLogosApi(mockClient1, new Configuration { BasePath = BaseUrl });
            var firstFile = new MemoryStream([0x89, 0x50, 0x4E, 0x47]);

            await api1.UploadApplicationLogoWithHttpInfoAsync(TestAppId, firstFile);

            // Second upload (replacement)
            var mockClient2 = new MockAsyncClient("", HttpStatusCode.Created);
            var api2 = new ApplicationLogosApi(mockClient2, new Configuration { BasePath = BaseUrl });
            var secondFile = new MemoryStream([0x89, 0x50, 0x4E, 0x47]);

            var response = await api2.UploadApplicationLogoWithHttpInfoAsync(TestAppId, secondFile);

            response.StatusCode.Should().Be(HttpStatusCode.Created);
            mockClient2.ReceivedPath.Should().Contain("apps");
            mockClient2.ReceivedPath.Should().Contain("logo");
        }

        #endregion
    }
}
