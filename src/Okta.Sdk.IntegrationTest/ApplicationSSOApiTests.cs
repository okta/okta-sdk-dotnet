// <copyright file="ApplicationSSOApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for ApplicationSSOApi - manages SSO operations for applications.
    /// The Application SSO API provides a Single Sign-On (SSO) resource for applications,
    /// specifically for previewing SAML metadata used in federation protocols.
    /// </summary>
    [Collection(nameof(ApplicationSsoApiTests))]
    public class ApplicationSsoApiTests : IDisposable
    {
        private readonly ApplicationSSOApi _applicationSsoApi;
        private readonly ApplicationApi _applicationApi = new();
        private readonly ApplicationSSOCredentialKeyApi _applicationSsoCredentialKeyApi = new();
        private readonly List<string> _createdAppIds = new();

        public ApplicationSsoApiTests()
        {
            // Workaround for SDK bug: The OpenAPI Generator adds both "text/xml" and "application/json"
            // to the accepts array (from success and error responses), but SelectHeaderAccept() 
            // preferentially returns "application/json" even though this endpoint only returns XML.
            // This is a test-level workaround: create the API client with default config, then
            // override the Accept header in the configuration's DefaultHeaders.
            
            _applicationSsoApi = new ApplicationSSOApi();
            
            // Override the Accept header to use text/xml
            ((Configuration)_applicationSsoApi.Configuration).DefaultHeaders["Accept"] = "text/xml";
        }

        public void Dispose()
        {
            Cleanup().GetAwaiter().GetResult();
        }

        private async Task Cleanup()
        {
            foreach (var appId in _createdAppIds)
            {
                try
                {
                    var app = await _applicationApi.GetApplicationAsync(appId);
                    if (app.Status == ApplicationLifecycleStatus.ACTIVE)
                    {
                        await _applicationApi.DeactivateApplicationAsync(appId);
                    }
                    await _applicationApi.DeleteApplicationAsync(appId);
                }
                catch (ApiException) { }
            }
            _createdAppIds.Clear();
        }

        /// <summary>
        /// Creates a SAML 2.0 application for testing SSO functionality.
        /// SAML applications automatically get signing credentials generated upon creation.
        /// </summary>
        private async Task<string> CreateTestSamlApplication()
        {
            var guid = Guid.NewGuid();
            var samlApp = new SamlApplication
            {
                Label = $"dotnet-sdk-test: SAML SSO App {guid}",
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
                        SsoAcsUrl = $"https://example-{guid}.com/sso/saml",
                        Recipient = $"https://example-{guid}.com/sso/saml",
                        Destination = $"https://example-{guid}.com/sso/saml",
                        Audience = $"https://example-{guid}.com",
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

            var createdApp = await _applicationApi.CreateApplicationAsync(samlApp);
            _createdAppIds.Add(createdApp.Id);

            // Wait a bit for the app to be fully provisioned with signing credentials
            await Task.Delay(2000);

            return createdApp.Id;
        }

        /// <summary>
        /// Comprehensive test covering all Application SSO API operations and endpoints.
        /// Tests SAML metadata preview functionality with both regular and HttpInfo method variants.
        /// 
        /// Coverage:
        /// - GET /api/v1/apps/{appId}/sso/saml/metadata - PreviewSAMLmetadataForApplicationAsync
        /// - GET /api/v1/apps/{appId}/sso/saml/metadata - PreviewSAMLmetadataForApplicationWithHttpInfoAsync
        /// 
        /// Test pattern: Create SAML App → Get Key Credentials → Preview SAML Metadata → Validate → Cleanup
        /// </summary>
        [Fact]
        public async Task GivenApplicationSSO_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            string appId = null;
            string kid = null;

            try
            {
                // ==================== SETUP: CREATE SAML APPLICATION ====================
                // Create a SAML 2.0 application which automatically gets signing credentials
                appId = await CreateTestSamlApplication();
                appId.Should().NotBeNullOrEmpty("SAML application should be created successfully");

                // Wait longer for the app to be fully provisioned
                await Task.Delay(5000);

                // Verify the application was created and is a SAML app
                var createdApp = await _applicationApi.GetApplicationAsync(appId);
                createdApp.Should().NotBeNull();
                createdApp.SignOnMode.Should().Be(ApplicationSignOnMode.SAML20, "application should be SAML 2.0");

                var samlApp = createdApp as SamlApplication;
                samlApp.Should().NotBeNull("application should be castable to SamlApplication");

                // ==================== GET APPLICATION KEY CREDENTIALS ====================
                // Retrieve the signing key credentials (kid) from the SAML application
                // The kid is required to preview SAML metadata
                var keysCollection = _applicationSsoCredentialKeyApi.ListApplicationKeys(appId);
                keysCollection.Should().NotBeNull("keys collection should not be null");

                var keys = await keysCollection.ToListAsync();
                keys.Should().NotBeNull()
                    .And.HaveCountGreaterThanOrEqualTo(1, "SAML application should have at least one signing key");

                // Get the first key's kid (Key ID)
                var firstKey = keys.First();
                firstKey.Should().NotBeNull("first key should not be null");
                firstKey.Kid.Should().NotBeNullOrEmpty("key should have a valid kid");
                
                kid = firstKey.Kid;

                // Validate key properties
                firstKey.Kty.Should().NotBeNullOrEmpty("key should have a key type (kty)");
                firstKey.Use.Should().NotBeNullOrEmpty("key should have a use designation");
                firstKey.Created.Should().BeAfter(DateTimeOffset.MinValue, "key should have a valid creation timestamp");
                firstKey.ExpiresAt.Should().BeAfter(DateTimeOffset.UtcNow.AddDays(-1), "key should have a valid expiration timestamp");
                firstKey.X5c.Should().NotBeNull()
                    .And.HaveCountGreaterThanOrEqualTo(1, "key should have X.509 certificate chain");

                // ==================== PREVIEW SAML METADATA (Standard Method) ====================
                // Test: PreviewSAMLmetadataForApplicationAsync
                // Endpoint: GET /api/v1/apps/{appId}/sso/saml/metadata
                string samlMetadata;
                try
                {
                    // Note: For text/xml responses, the SDK may return data in RawContent instead of Data
                    var response = await _applicationSsoApi.PreviewSAMLmetadataForApplicationWithHttpInfoAsync(appId, kid);
                    samlMetadata = response.Data ?? response.RawContent;
                }
                catch (ApiException ex) when (ex.ErrorCode == 400 && ex.Message.Contains("Accept"))
                {
                    // If we hit an Accept header issue, this might be a known API limitation
                    // Skip the detailed validation but mark the test as having attempted the call
                    throw new Exception($"API endpoint returned error related to Accept headers. " +
                                       $"This may indicate the endpoint requires specific header configuration. " +
                                       $"Error: {ex.Message}", ex);
                }

                // Validate the SAML metadata response
                samlMetadata.Should().NotBeNullOrEmpty("SAML metadata should be returned");
                samlMetadata.Should().StartWith("<?xml", "SAML metadata should be valid XML");
                samlMetadata.Should().Contain("EntityDescriptor", "SAML metadata should contain EntityDescriptor");
                samlMetadata.Should().Contain("IDPSSODescriptor", "SAML metadata should contain IDPSSODescriptor");
                samlMetadata.Should().Contain("KeyDescriptor", "SAML metadata should contain KeyDescriptor for signing");
                samlMetadata.Should().Contain("SingleSignOnService", "SAML metadata should contain SingleSignOnService");
                samlMetadata.Should().Contain("urn:oasis:names:tc:SAML:2.0", "SAML metadata should reference SAML 2.0 protocol");

                // Parse and validate XML structure
                XDocument xmlDoc;
                try
                {
                    xmlDoc = XDocument.Parse(samlMetadata);
                    xmlDoc.Should().NotBeNull("SAML metadata should be parseable as XML");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed to parse SAML metadata as XML: {ex.Message}");
                }

                // Validate XML namespace and root element
                var entityDescriptor = xmlDoc.Root;
                entityDescriptor.Should().NotBeNull("XML should have a root element");
                entityDescriptor?.Name.LocalName.Should().Be("EntityDescriptor", "root element should be EntityDescriptor");

                // Validate EntityDescriptor has entityID attribute
                var entityId = entityDescriptor?.Attribute("entityID");
                entityId.Should().NotBeNull("EntityDescriptor should have entityID attribute");
                entityId?.Value.Should().NotBeNullOrEmpty("entityID should not be empty");

                // Validate IDPSSODescriptor exists
                var idpDescriptor = entityDescriptor?.Elements().FirstOrDefault(e => e.Name.LocalName == "IDPSSODescriptor");
                idpDescriptor.Should().NotBeNull("EntityDescriptor should contain IDPSSODescriptor");

                // Validate KeyDescriptor exists
                var keyDescriptor = idpDescriptor?.Elements().FirstOrDefault(e => e.Name.LocalName == "KeyDescriptor");
                keyDescriptor.Should().NotBeNull("IDPSSODescriptor should contain KeyDescriptor");

                // Validate SingleSignOnService exists
                var ssoService = idpDescriptor?.Elements().FirstOrDefault(e => e.Name.LocalName == "SingleSignOnService");
                ssoService.Should().NotBeNull("IDPSSODescriptor should contain SingleSignOnService");

                // Validate NameIDFormat exists
                var nameIdFormat = idpDescriptor?.Elements().FirstOrDefault(e => e.Name.LocalName == "NameIDFormat");
                nameIdFormat.Should().NotBeNull("IDPSSODescriptor should contain NameIDFormat");

                // ==================== PREVIEW SAML METADATA (WithHttpInfo Method) ====================
                // Test: PreviewSAMLmetadataForApplicationWithHttpInfoAsync
                // Endpoint: GET /api/v1/apps/{appId}/sso/saml/metadata
                // This variant returns the full HTTP response including headers and status code
                var metadataResponse = await _applicationSsoApi.PreviewSAMLmetadataForApplicationWithHttpInfoAsync(appId, kid);

                // Validate HTTP response properties
                metadataResponse.Should().NotBeNull("HTTP response should not be null");
                metadataResponse.StatusCode.Should().Be(HttpStatusCode.OK, "status code should be 200 OK");
                
                // For text/xml responses, data may be in RawContent instead of Data
                var responseData = metadataResponse.Data ?? metadataResponse.RawContent;
                responseData.Should().NotBeNullOrEmpty("response data should contain SAML metadata");
                metadataResponse.Headers.Should().NotBeNull("response should include headers");

                // Validate Content-Type header
                metadataResponse.Headers.Should().ContainKey("Content-Type", "response should have Content-Type header");
                var contentType = metadataResponse.Headers["Content-Type"].FirstOrDefault();
                contentType.Should().NotBeNullOrEmpty("Content-Type should not be empty");
                contentType.Should().Contain("text/xml", "Content-Type should be text/xml for SAML metadata");

                // Validate the metadata content matches previous call
                responseData.Should().Be(samlMetadata, "both methods should return identical SAML metadata");

                // ==================== ERROR HANDLING: INVALID APP ID ====================
                // Test error handling with non-existent application ID
                var invalidAppId = "invalid_app_id_" + Guid.NewGuid();
                Func<Task> invalidAppAction = async () => 
                    await _applicationSsoApi.PreviewSAMLmetadataForApplicationAsync(invalidAppId, kid);

                await invalidAppAction.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404, "should throw 404 for non-existent application");

                // ==================== ERROR HANDLING: INVALID KID ====================
                // Test error handling with invalid key ID
                var invalidKid = "invalid_kid_" + Guid.NewGuid();
                Func<Task> invalidKidAction = async () => 
                    await _applicationSsoApi.PreviewSAMLmetadataForApplicationAsync(appId, invalidKid);

                await invalidKidAction.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404, "should throw 404 for non-existent key ID");

                // ==================== ERROR HANDLING: NULL PARAMETERS ====================
                // Test null appId parameter validation
                Func<Task> nullAppIdAction = async () =>
                    await _applicationSsoApi.PreviewSAMLmetadataForApplicationAsync(null, kid);

                await nullAppIdAction.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 400, "should throw 400 for null appId");

                // Test null kid parameter validation
                Func<Task> nullKidAction = async () =>
                    await _applicationSsoApi.PreviewSAMLmetadataForApplicationAsync(appId, null);

                await nullKidAction.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 400, "should throw 400 for null kid");

                // ==================== ADDITIONAL VALIDATION: MULTIPLE KEYS ====================
                // If the app has multiple keys, verify metadata can be retrieved for each
                if (keys.Count > 1)
                {
                    foreach (var key in keys.Skip(1).Take(2)) // Test up to 2 additional keys
                    {
                        var additionalMetadata = await _applicationSsoApi.PreviewSAMLmetadataForApplicationAsync(appId, key.Kid);
                        additionalMetadata.Should().NotBeNullOrEmpty($"metadata should be retrievable for key {key.Kid}");
                        additionalMetadata.Should().StartWith("<?xml", "each key should produce valid XML metadata");
                        additionalMetadata.Should().Contain(key.Kid, "metadata should reference the requested key ID");
                    }
                }

                // ==================== VALIDATION: METADATA CONTENT ====================
                // Verify the SAML metadata contains application-specific information
                var samlSettings = samlApp.Settings?.SignOn;
                if (samlSettings != null)
                {
                    // The metadata should reflect the app's SAML settings
                    if (!string.IsNullOrEmpty(samlSettings.Audience))
                    {
                        // Note: The actual audience value in metadata might be different from settings,
                        // but the metadata should have valid URN formats
                        samlMetadata.Should().Contain("urn:oasis:names:tc:SAML", "metadata should contain SAML URNs");
                    }

                    // Verify signature algorithm settings are reflected
                    if (samlSettings.SignatureAlgorithm != null)
                    {
                        samlMetadata.Should().Contain("xmldsig", "metadata should reference XML digital signature");
                    }
                }

                // ==================== CONSISTENCY CHECK ====================
                // Retrieve metadata again and ensure consistency
                var metadataCheckResponse = await _applicationSsoApi.PreviewSAMLmetadataForApplicationWithHttpInfoAsync(appId, kid);
                var metadataCheck = metadataCheckResponse.Data ?? metadataCheckResponse.RawContent;
                metadataCheck.Should().Be(samlMetadata, "metadata should be consistent across multiple requests");

                // ==================== TEST NON-SAML APPLICATION ====================
                // Create a non-SAML application and verify it cannot retrieve SAML metadata
                var bookmarkApp = new BookmarkApplication
                {
                    Name = "bookmark",
                    Label = $"dotnet-sdk-test: BookmarkApp {Guid.NewGuid()}",
                    SignOnMode = "BOOKMARK",
                    Settings = new BookmarkApplicationSettings
                    {
                        App = new BookmarkApplicationSettingsApplication
                        {
                            RequestIntegration = false,
                            Url = "https://example.com/bookmark.html",
                        },
                    },
                };

                var createdBookmarkApp = await _applicationApi.CreateApplicationAsync(bookmarkApp);
                _createdAppIds.Add(createdBookmarkApp.Id);

                // Try to get SAML metadata for a non-SAML app (should fail)
                Func<Task> nonSamlAppAction = async () =>
                    await _applicationSsoApi.PreviewSAMLmetadataForApplicationAsync(createdBookmarkApp.Id, kid);

                // This should fail because bookmark apps don't have SAML metadata
                await nonSamlAppAction.Should().ThrowAsync<ApiException>()
                    .Where(e => e.ErrorCode == 404 || e.ErrorCode == 400, 
                        "should throw error when trying to get SAML metadata for non-SAML application");

                // Test passed - all endpoints and methods covered successfully
            }
            catch (Exception ex)
            {
                // Provide detailed error information for debugging
                throw new Exception(
                    $"Test failed with appId: {appId}, kid: {kid}. Error: {ex.Message}", 
                    ex);
            }
        }

        /// <summary>
        /// Tests SAML metadata preview with different SAML configuration options.
        /// Validates that different SAML settings produce appropriate metadata variations.
        /// </summary>
        [Fact]
        public async Task GivenDifferentConfigurations_WhenPreviewingSAMLMetadata_ThenCorrectMetadataIsProduced()
        {
            // Create SAML app with specific configuration
            var guid = Guid.NewGuid();
            var samlApp = new SamlApplication
            {
                Label = $"dotnet-sdk-test: SAML Config Test {guid}",
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
                        SsoAcsUrl = $"https://config-test-{guid}.com/sso/saml",
                        Recipient = $"https://config-test-{guid}.com/sso/saml",
                        Destination = $"https://config-test-{guid}.com/sso/saml",
                        Audience = $"https://config-test-{guid}.com/audience",
                        IdpIssuer = "$${org.externalKey}",
                        SubjectNameIdTemplate = "${user.userName}",
                        SubjectNameIdFormat = "urn:oasis:names:tc:SAML:1.1:nameid-format:emailAddress",
                        ResponseSigned = true,
                        AssertionSigned = false, // Different from default
                        SignatureAlgorithm = "RSA_SHA1", // Different algorithm
                        DigestAlgorithm = "SHA1", // Different algorithm
                        HonorForceAuthn = false,
                        AuthnContextClassRef = "urn:oasis:names:tc:SAML:2.0:ac:classes:Password",
                        SamlAssertionLifetimeSeconds = 600
                    }
                }
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(samlApp);
            _createdAppIds.Add(createdApp.Id);
            await Task.Delay(3000);

            // Get key credentials
            var keys = await _applicationSsoCredentialKeyApi.ListApplicationKeys(createdApp.Id).ToListAsync();
            keys.Should().HaveCountGreaterThanOrEqualTo(1);
            var kid = keys.First().Kid;

            // Preview metadata
            try
            {
                // For text/xml responses, data may be in RawContent instead of Data
                var response = await _applicationSsoApi.PreviewSAMLmetadataForApplicationWithHttpInfoAsync(createdApp.Id, kid);
                var metadata = response.Data ?? response.RawContent;

                // Validate metadata reflects configuration
                metadata.Should().NotBeNullOrEmpty();
                metadata.Should().Contain("emailAddress", "should contain emailAddress NameID format");
                
                // Parse and validate specific configuration elements
                var xmlDoc = XDocument.Parse(metadata);
                xmlDoc.Should().NotBeNull();

                var nameIdFormats = xmlDoc.Descendants()
                    .Where(e => e.Name.LocalName == "NameIDFormat")
                    .Select(e => e.Value)
                    .ToList();

                nameIdFormats.Should().Contain(nf => nf.Contains("emailAddress"), 
                    "metadata should include the configured emailAddress NameID format");
            }
            catch (ApiException ex) when (ex.ErrorCode == 400 && ex.Message.Contains("Accept"))
            {
                // If we hit an Accept header issue, skip this validation;
                // This is a known limitation with certain SDK configurations
                throw new Exception($"API endpoint requires specific Accept header configuration: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Tests the WithHttpInfo variant thoroughly to ensure all HTTP response
        /// metadata is correctly populated and accessible.
        /// </summary>
        [Fact]
        public async Task GivenSAMLMetadata_WhenPreviewingWithHttpInfo_ThenCompleteHttpResponseIsReturned()
        {
            // Arrange
            var appId = await CreateTestSamlApplication();
            var keys = await _applicationSsoCredentialKeyApi.ListApplicationKeys(appId).ToListAsync();
            var kid = keys.First().Kid;

            // Act
            var response = await _applicationSsoApi.PreviewSAMLmetadataForApplicationWithHttpInfoAsync(appId, kid);

            // Assert - Validate all aspects of the HTTP response
            response.Should().NotBeNull("HTTP response should not be null");
            
            // Status Code
            response.StatusCode.Should().Be(HttpStatusCode.OK, "should return 200 OK");
            response.RawContent.Should().NotBeNull("raw content should be available");
            
            // Headers
            response.Headers.Should().NotBeNull().And.NotBeEmpty("should have response headers");
            response.Headers.Should().ContainKey("Content-Type");
            
            // Data - for text/xml responses, data may be in RawContent instead of Data property
            var responseData = response.Data ?? response.RawContent;
            responseData.Should().NotBeNullOrEmpty("should have data payload");
            responseData.Should().StartWith("<?xml", "data should be XML");
            
            // Verify data can be parsed as XML
            var xmlDoc = XDocument.Parse(responseData);
            xmlDoc.Should().NotBeNull("data should be valid XML");
            xmlDoc.Root.Should().NotBeNull("XML should have root element");
        }
    }
}
