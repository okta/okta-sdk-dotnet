using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for ApplicationLogosApi
    /// Tests logo upload operations for applications
    /// </summary>
    public class ApplicationLogosApiTests : IAsyncLifetime
    {
        private ApplicationApi _applicationApi;
        private ApplicationLogosApi _applicationLogosApi;
        private string _testAppId;

        public async Task InitializeAsync()
        {
            _applicationApi = new ApplicationApi();
            _applicationLogosApi = new ApplicationLogosApi();

            // Create a test application (Bookmark App)
            var testApp = new BookmarkApplication
            {
                Name = "bookmark",
                Label = $"Test App for Logos {Guid.NewGuid()}",
                Settings = new BookmarkApplicationSettings
                {
                    App = new BookmarkApplicationSettingsApplication
                    {
                        Url = "https://example.com",
                        RequestIntegration = false
                    }
                }
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(testApp);
            _testAppId = createdApp.Id;

            await Task.Delay(2000); // Wait for the app to be ready
        }

        public async Task DisposeAsync()
        {
            if (!string.IsNullOrEmpty(_testAppId))
            {
                try
                {
                    await _applicationApi.DeactivateApplicationAsync(_testAppId);
                    await _applicationApi.DeleteApplicationAsync(_testAppId);
                }
                catch
                {
                    // Best effort cleanup
                }
            }
        }

        /// <summary>
        /// Creates a simple 1x1 PNG image in memory for testing
        /// </summary>
        private Stream CreateTestPngImage()
        {
            // Minimal valid PNG file (1x1 pixel, transparent)
            var pngBytes = new byte[]
            {
                0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, // PNG signature
                0x00, 0x00, 0x00, 0x0D, 0x49, 0x48, 0x44, 0x52, // IHDR chunk
                0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, // Width: 1, Height: 1
                0x08, 0x06, 0x00, 0x00, 0x00, 0x1F, 0x15, 0xC4, // Color type: RGBA
                0x89, 0x00, 0x00, 0x00, 0x0A, 0x49, 0x44, 0x41, // IDAT chunk
                0x54, 0x78, 0x9C, 0x63, 0x00, 0x01, 0x00, 0x00, // Image data
                0x05, 0x00, 0x01, 0x0D, 0x0A, 0x2D, 0xB4, 0x00, // CRC
                0x00, 0x00, 0x00, 0x49, 0x45, 0x4E, 0x44, 0xAE, // IEND chunk
                0x42, 0x60, 0x82
            };

            // Create a temporary file with .png extension
            var tempFile = Path.Combine(Path.GetTempPath(), $"test_logo_{Guid.NewGuid()}.png");
            File.WriteAllBytes(tempFile, pngBytes);
            return File.OpenRead(tempFile);
        }

        /// <summary>
        /// Creates a simple SVG image for testing
        /// </summary>
        private Stream CreateTestSvgImage()
        {
            var svgContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg width=""100"" height=""100"" xmlns=""http://www.w3.org/2000/svg"">
  <circle cx=""50"" cy=""50"" r=""40"" fill=""#4CAF50""/>
</svg>";

            // Create a temporary file with .svg extension
            var tempFile = Path.Combine(Path.GetTempPath(), $"test_logo_{Guid.NewGuid()}.svg");
            File.WriteAllText(tempFile, svgContent);
            return File.OpenRead(tempFile);
        }

        [Fact]
        public async Task Should_UploadApplicationLogo_WithPngFile()
        {
            // Arrange
            await using var logoStream = CreateTestPngImage();

            // Act
            await _applicationLogosApi.UploadApplicationLogoAsync(_testAppId, logoStream);

            await Task.Delay(1000);

            // Assert - Verify app still exists and a logo link is present
            var app = await _applicationApi.GetApplicationAsync(_testAppId);
            app.Should().NotBeNull();
            app.Id.Should().Be(_testAppId);
            app.Links.Should().NotBeNull();
            
            // Logo link should be present after successful upload
            app.Links.Logo.Should().NotBeNull("logo should be uploaded and link available");
            app.Links.Logo.Should().HaveCountGreaterThanOrEqualTo(1, "at least one logo link should exist");
        }

        [Fact]
        public async Task Should_UploadApplicationLogo_WithSvgFile()
        {
            // Arrange
            await using var logoStream = CreateTestSvgImage();

            // Act
            await _applicationLogosApi.UploadApplicationLogoAsync(_testAppId, logoStream);

            await Task.Delay(1000);

            // Assert - Verify app still exists and the logo was uploaded
            var app = await _applicationApi.GetApplicationAsync(_testAppId);
            app.Should().NotBeNull();
            app.Id.Should().Be(_testAppId);
            app.Links.Should().NotBeNull();
            app.Links.Logo.Should().NotBeNull("SVG logo should be uploaded successfully");
        }

        [Fact]
        public async Task Should_ReplaceExistingLogo_WhenUploadingNewLogo()
        {
            // Arrange - Upload first logo
            await using (var firstLogo = CreateTestPngImage())
            {
                await _applicationLogosApi.UploadApplicationLogoAsync(_testAppId, firstLogo);
            }

            await Task.Delay(1000);

            // Verify the first logo exists
            var appAfterFirstUpload = await _applicationApi.GetApplicationAsync(_testAppId);
            appAfterFirstUpload.Links.Logo.Should().NotBeNull("first logo should be uploaded");

            // Act - Upload second logo (should replace first)
            await using (var secondLogo = CreateTestSvgImage())
            {
                await _applicationLogosApi.UploadApplicationLogoAsync(_testAppId, secondLogo);
            }

            await Task.Delay(1000);

            // Assert - Verify app is still accessible, and the logo exists
            var app = await _applicationApi.GetApplicationAsync(_testAppId);
            app.Should().NotBeNull();
            app.Id.Should().Be(_testAppId);
            app.Links.Logo.Should().NotBeNull("second logo should replace first logo");
            
            // Logo should still exist (replaced, not removed)
            app.Links.Logo.Should().HaveCountGreaterThanOrEqualTo(1, "logo should exist after replacement");
        }

        [Fact]
        public async Task Should_UploadApplicationLogo_WithHttpInfo()
        {
            // Arrange
            await using var logoStream = CreateTestPngImage();

            // Act
            var response = await _applicationLogosApi.UploadApplicationLogoWithHttpInfoAsync(_testAppId, logoStream);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        }

        [Fact]
        public async Task Should_ThrowException_ForNonExistentApp()
        {
            // Arrange
            var nonExistentAppId = "nonexistent123";
            await using var logoStream = CreateTestPngImage();

            // Act & Assert
            var act = async () => await _applicationLogosApi.UploadApplicationLogoAsync(nonExistentAppId, logoStream);
            
            await act.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404);
        }

        [Fact]
        public async Task Should_HandleMultipleSequentialUploads()
        {
            // Act - Upload multiple logos in sequence
            for (var i = 0; i < 3; i++)
            {
                await using var logoStream = i % 2 == 0 ? CreateTestPngImage() : CreateTestSvgImage();
                await _applicationLogosApi.UploadApplicationLogoAsync(_testAppId, logoStream);
                await Task.Delay(500); // Small delay between uploads
            }

            // Assert - Verify app is still accessible after multiple uploads
            var app = await _applicationApi.GetApplicationAsync(_testAppId);
            app.Should().NotBeNull();
            app.Id.Should().Be(_testAppId);
        }

        [Fact]
        public async Task Should_UploadLogo_ForDifferentApplicationTypes()
        {
            // Arrange - Create a different type of app (SAML)
            var samlApp = new SamlApplication
            {
                Label = $"Test SAML App for Logo {Guid.NewGuid()}",
                SignOnMode = "SAML_2_0",
                Visibility = new ApplicationVisibility
                {
                    AutoSubmitToolbar = false,
                    Hide = new ApplicationVisibilityHide
                    {
                        IOS = false,
                        Web = false
                    }
                },
                Settings = new SamlApplicationSettings
                {
                    SignOn = new SamlApplicationSettingsSignOn
                    {
                        DefaultRelayState = "",
                        SsoAcsUrl = "https://example.com/sso/saml",
                        Recipient = "https://example.com/sso/saml",
                        Destination = "https://example.com/sso/saml",
                        Audience = "https://example.com",
                        IdpIssuer = "$${org.externalKey}",
                        SubjectNameIdTemplate = "${user.userName}",
                        SubjectNameIdFormat = "urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified",
                        ResponseSigned = true,
                        AssertionSigned = true,
                        SignatureAlgorithm = "RSA_SHA256",
                        DigestAlgorithm = "SHA256",
                        HonorForceAuthn = true,
                        AuthnContextClassRef = "urn:oasis:names:tc:SAML:2.0:ac:classes:PasswordProtectedTransport",
                        SamlAssertionLifetimeSeconds = 300
                    }
                }
            };

            var createdSamlApp = await _applicationApi.CreateApplicationAsync(samlApp);
            var samlAppId = createdSamlApp.Id;

            try
            {
                await Task.Delay(2000);

                // Act - Upload logo to SAML app
                await using var logoStream = CreateTestPngImage();
                await _applicationLogosApi.UploadApplicationLogoAsync(samlAppId, logoStream);

                // Assert
                var app = await _applicationApi.GetApplicationAsync(samlAppId);
                app.Should().NotBeNull();
                app.Id.Should().Be(samlAppId);
            }
            finally
            {
                // Cleanup
                try
                {
                    await _applicationApi.DeactivateApplicationAsync(samlAppId);
                    await _applicationApi.DeleteApplicationAsync(samlAppId);
                }
                catch
                {
                    // Best effort cleanup
                }
            }
        }
    }
}
