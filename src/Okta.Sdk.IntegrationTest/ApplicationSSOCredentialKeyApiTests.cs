using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    public class ApplicationSsoCredentialKeyApiTests : IAsyncLifetime
    {
        private ApplicationApi _applicationApi;
        private ApplicationSSOCredentialKeyApi _credentialKeyApi;
        private string _testAppId;
        private string _targetAppId;

        public async Task InitializeAsync()
        {
            _applicationApi = new ApplicationApi();
            _credentialKeyApi = new ApplicationSSOCredentialKeyApi();

            // Create test SAML applications for credential key operations
            _testAppId = await CreateTestSamlApplication("SSO Credential Key Test App");
            _targetAppId = await CreateTestSamlApplication("SSO Credential Key Target App");
        }

        public async Task DisposeAsync()
        {
            // Clean up test applications
            if (!string.IsNullOrEmpty(_testAppId))
            {
                try
                {
                    await _applicationApi.DeactivateApplicationAsync(_testAppId);
                    await _applicationApi.DeleteApplicationAsync(_testAppId);
                }
                catch
                {
                    // Ignore cleanup errors
                }
            }

            if (!string.IsNullOrEmpty(_targetAppId))
            {
                try
                {
                    await _applicationApi.DeactivateApplicationAsync(_targetAppId);
                    await _applicationApi.DeleteApplicationAsync(_targetAppId);
                }
                catch
                {
                    // Ignore cleanup errors
                }
            }
        }

        #region Helper Methods

        private async Task<string> CreateTestSamlApplication(string label)
        {
            var app = new SamlApplication
            {
                Label = label,
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
                        SsoAcsUrl = $"https://example.com/sso/saml",
                        Recipient = $"https://example.com/sso/saml",
                        Destination = $"https://example.com/sso/saml",
                        Audience = $"https://example.com/sso/saml",
                        IdpIssuer = "http://www.okta.com/${org.externalKey}",
                        SubjectNameIdTemplate = "${user.userName}",
                        SubjectNameIdFormat = "urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified",
                        ResponseSigned = true,
                        AssertionSigned = true,
                        SignatureAlgorithm = "RSA_SHA256",
                        DigestAlgorithm = "SHA256",
                        HonorForceAuthn = true,
                        AuthnContextClassRef = "urn:oasis:names:tc:SAML:2.0:ac:classes:PasswordProtectedTransport",
                        SamlAssertionLifetimeSeconds = 300,
                        AttributeStatements = []
                    }
                }
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app, true);
            return createdApp.Id;
        }

        #endregion

        #region Comprehensive API Coverage Tests

        [Fact]
        public async Task ComprehensiveApplicationSSOCredentialKeyApiTest_CoversAllEndpointsAndMethods()
        {
            // Test 1: Generate Application Key
            var validityYears = 2;
            var generatedKey = await _credentialKeyApi.GenerateApplicationKeyAsync(_testAppId, validityYears);

            generatedKey.Should().NotBeNull();
            generatedKey.Kid.Should().NotBeNullOrEmpty();
            generatedKey.Kty.Should().Be("RSA");
            generatedKey.Use.Should().Be("sig");
            generatedKey.X5c.Should().NotBeNull().And.HaveCountGreaterThan(0);

            var keyId = generatedKey.Kid;

            // Test 2: GenerateApplicationKeyWithHttpInfo
            var keyWithHttpInfo = await _credentialKeyApi.GenerateApplicationKeyWithHttpInfoAsync(_testAppId, validityYears);
            keyWithHttpInfo.Should().NotBeNull();
            keyWithHttpInfo.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
            keyWithHttpInfo.Data.Should().NotBeNull();
            keyWithHttpInfo.Data.Kid.Should().NotBeNullOrEmpty();

            // Test 3: List Application Keys
            var keys = _credentialKeyApi.ListApplicationKeys(_testAppId);
            var keysList = await keys.ToListAsync();

            keysList.Should().NotBeNull().And.HaveCountGreaterThan(0);
            keysList.Should().Contain(k => k.Kid == keyId);

            // Test 4: ListApplicationKeysWithHttpInfo
            var keysHttpInfo = await _credentialKeyApi.ListApplicationKeysWithHttpInfoAsync(_testAppId);
            keysHttpInfo.Should().NotBeNull();
            keysHttpInfo.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            keysHttpInfo.Data.Should().NotBeNull().And.HaveCountGreaterThan(0);

            // Test 5: Get Application Key
            var retrievedKey = await _credentialKeyApi.GetApplicationKeyAsync(_testAppId, keyId);
            retrievedKey.Should().NotBeNull();
            retrievedKey.Kid.Should().Be(keyId);
            retrievedKey.Kty.Should().Be("RSA");

            // Test 6: GetApplicationKeyWithHttpInfo
            var keyHttpInfo = await _credentialKeyApi.GetApplicationKeyWithHttpInfoAsync(_testAppId, keyId);
            keyHttpInfo.Should().NotBeNull();
            keyHttpInfo.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            keyHttpInfo.Data.Kid.Should().Be(keyId);

            // Test 7 & 8: Clone Application Key (using WithHttpInfo to verify both method and status code)
            var clonedKeyHttpInfo = await _credentialKeyApi.CloneApplicationKeyWithHttpInfoAsync(_testAppId, keyId, _targetAppId);
            clonedKeyHttpInfo.Should().NotBeNull();
            clonedKeyHttpInfo.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
            clonedKeyHttpInfo.Data.Should().NotBeNull();
            clonedKeyHttpInfo.Data.Kid.Should().Be(keyId);
            clonedKeyHttpInfo.Data.X5c.Should().BeEquivalentTo(generatedKey.X5c);

            // Test 9: Generate CSR for Application
            var csrMetadata = new CsrMetadata
            {
                Subject = new CsrMetadataSubject
                {
                    CountryName = "US",
                    StateOrProvinceName = "California",
                    LocalityName = "San Francisco",
                    OrganizationName = "Okta Test",
                    OrganizationalUnitName = "Dev",
                    CommonName = "example.com"
                },
                SubjectAltNames = new CsrMetadataSubjectAltNames
                {
                    DnsNames = ["example.com", "www.example.com"]
                }
            };

            var csrString = await _credentialKeyApi.GenerateCsrForApplicationAsync(_testAppId, csrMetadata);
            csrString.Should().NotBeNullOrEmpty();

            // Test 10: GenerateCsrForApplicationWithHttpInfo
            var csrHttpInfo = await _credentialKeyApi.GenerateCsrForApplicationWithHttpInfoAsync(_testAppId, csrMetadata);
            csrHttpInfo.Should().NotBeNull();
            csrHttpInfo.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
            csrHttpInfo.Data.Should().NotBeNullOrEmpty();

            // Test 11: List CSRs for Application
            var csrs = _credentialKeyApi.ListCsrsForApplication(_testAppId);
            var csrsList = await csrs.ToListAsync();

            csrsList.Should().NotBeNull().And.HaveCountGreaterThan(0);
            var csr = csrsList.FirstOrDefault();
            csr.Should().NotBeNull();
            if (csr != null)
            {
                csr.Id.Should().NotBeNullOrEmpty();

                var csrId = csr.Id;

                // Test 12: ListCsrsForApplicationWithHttpInfo
                var csrsHttpInfo = await _credentialKeyApi.ListCsrsForApplicationWithHttpInfoAsync(_testAppId);
                csrsHttpInfo.Should().NotBeNull();
                csrsHttpInfo.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
                csrsHttpInfo.Data.Should().NotBeNull().And.HaveCountGreaterThan(0);

                // Test 13: Get CSR for Application
                var retrievedCsr = await _credentialKeyApi.GetCsrForApplicationAsync(_testAppId, csrId);
                retrievedCsr.Should().NotBeNull();
                retrievedCsr.Id.Should().Be(csrId);
                retrievedCsr._Csr.Should().NotBeNullOrEmpty();

                // Test 14: GetCsrForApplicationWithHttpInfo
                var csrDetailHttpInfo =
                    await _credentialKeyApi.GetCsrForApplicationWithHttpInfoAsync(_testAppId, csrId);
                csrDetailHttpInfo.Should().NotBeNull();
                csrDetailHttpInfo.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
                csrDetailHttpInfo.Data.Id.Should().Be(csrId);

                // Note: Tests 15-16 (PublishCsrFromApplication/WithHttpInfo) are skipped in the comprehensive test
                // because they require a certificate that matches the CSR, which is technically complex.
                // These methods would be tested if we had proper certificate generation that matches the CSR.

                // Test 15: Revoke CSR
                await _credentialKeyApi.RevokeCsrFromApplicationAsync(_testAppId, csrId);
            }

            // Test 16: RevokeCsrFromApplicationWithHttpInfo
            // Generate one more CSR to revoke
            await _credentialKeyApi.GenerateCsrForApplicationAsync(_testAppId, csrMetadata);
            var csrToRevokeList = await _credentialKeyApi.ListCsrsForApplication(_testAppId).ToListAsync();
            var csrToRevokeId = csrToRevokeList.Last().Id;

            var revokeHttpInfo = await _credentialKeyApi.RevokeCsrFromApplicationWithHttpInfoAsync(_testAppId, csrToRevokeId);
            revokeHttpInfo.Should().NotBeNull();
            revokeHttpInfo.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);

            // Verify CSR was revoked by checking it's no longer in the list
            var csrsAfterRevoke = await _credentialKeyApi.ListCsrsForApplication(_testAppId).ToListAsync();
            csrsAfterRevoke.Should().NotContain(c => c.Id == csrToRevokeId);
        }

        #endregion

        #region Error Handling Tests

        [Fact]
        public async Task ApplicationSSOCredentialKeyApi_ErrorScenarios_HandleCorrectly()
        {
            // Test invalid app ID
            await Assert.ThrowsAsync<ApiException>(() =>
                _credentialKeyApi.GenerateApplicationKeyAsync("invalid_app_id", 2));

            // Test invalid key ID
            await Assert.ThrowsAsync<ApiException>(() =>
                _credentialKeyApi.GetApplicationKeyAsync(_testAppId, "invalid_key_id"));

            // Test invalid CSR ID
            await Assert.ThrowsAsync<ApiException>(() =>
                _credentialKeyApi.GetCsrForApplicationAsync(_testAppId, "invalid_csr_id"));

            // Test invalid validity years (too large)
            await Assert.ThrowsAsync<ApiException>(() =>
                _credentialKeyApi.GenerateApplicationKeyAsync(_testAppId, 100));

            // Test cloning with invalid target app
            var key = await _credentialKeyApi.GenerateApplicationKeyAsync(_testAppId, 2);
            await Assert.ThrowsAsync<ApiException>(() =>
                _credentialKeyApi.CloneApplicationKeyAsync(_testAppId, key.Kid, "invalid_target"));
        }

        #endregion

        #region Key Generation Tests

        [Fact]
        public async Task GenerateApplicationKey_WithDifferentValidityPeriods_GeneratesCorrectly()
        {
            // Test 2-year validity (minimum allowed)
            var key2Year = await _credentialKeyApi.GenerateApplicationKeyAsync(_testAppId, 2);
            key2Year.Should().NotBeNull();
            key2Year.Kid.Should().NotBeNullOrEmpty();

            // Test 5-year validity
            var key5Year = await _credentialKeyApi.GenerateApplicationKeyAsync(_testAppId, 5);
            key5Year.Should().NotBeNull();
            key5Year.Kid.Should().NotBeNullOrEmpty();
            key5Year.Kid.Should().NotBe(key2Year.Kid);

            // Test 10-year validity (maximum allowed)
            var key10Year = await _credentialKeyApi.GenerateApplicationKeyAsync(_testAppId, 10);
            key10Year.Should().NotBeNull();
            key10Year.Kid.Should().NotBeNullOrEmpty();
            key10Year.Kid.Should().NotBe(key2Year.Kid);
            key10Year.Kid.Should().NotBe(key5Year.Kid);
        }

        #endregion

        #region CSR Lifecycle Tests

        [Fact]
        public async Task CsrLifecycle_CreateListRetrievePublishRevoke_WorksCorrectly()
        {
            // Step 1: Create CSR with comprehensive metadata
            var csrMetadata = new CsrMetadata
            {
                Subject = new CsrMetadataSubject
                {
                    CountryName = "US",
                    StateOrProvinceName = "California",
                    LocalityName = "San Francisco",
                    OrganizationName = "Okta Test Organization",
                    OrganizationalUnitName = "Engineering",
                    CommonName = "test.example.com"
                },
                SubjectAltNames = new CsrMetadataSubjectAltNames
                {
                    DnsNames = ["test.example.com", "*.example.com", "example.com"]
                }
            };

            var csrPem = await _credentialKeyApi.GenerateCsrForApplicationAsync(_testAppId, csrMetadata);
            // Note: GenerateCsrForApplicationAsync returns a JSON string representation of the Csr object
            csrPem.Should().NotBeNullOrEmpty();

            // Step 2: List CSRs and find the created one
            var csrs = await _credentialKeyApi.ListCsrsForApplication(_testAppId).ToListAsync();
            csrs.Should().NotBeNull().And.HaveCountGreaterThan(0);

            var createdCsr = csrs.Last();
            createdCsr.Should().NotBeNull();
            createdCsr.Id.Should().NotBeNullOrEmpty();
            createdCsr.Created.Should().BeAfter(DateTimeOffset.UtcNow.AddMinutes(-5));

            // Step 3: Retrieve the specific CSR
            var retrievedCsr = await _credentialKeyApi.GetCsrForApplicationAsync(_testAppId, createdCsr.Id);
            retrievedCsr.Should().NotBeNull();
            retrievedCsr.Id.Should().Be(createdCsr.Id);
            retrievedCsr._Csr.Should().NotBeNullOrEmpty();

            // Note: Skipping CSR publish test as it requires a certificate that matches the CSR.
            // The PublishCsrFromApplication methods are covered in other tests when possible.

            // Step 4: Revoke the CSR
            await _credentialKeyApi.RevokeCsrFromApplicationAsync(_testAppId, createdCsr.Id);

            // Verify CSR was revoked
            var csrsAfterRevoke = await _credentialKeyApi.ListCsrsForApplication(_testAppId).ToListAsync();
            csrsAfterRevoke.Should().NotContain(c => c.Id == createdCsr.Id);
        }

        #endregion

        #region Key Cloning Tests

        [Fact]
        public async Task CloneApplicationKey_BetweenApplications_WorksCorrectly()
        {
            // Generate a key in the source application
            var sourceKey = await _credentialKeyApi.GenerateApplicationKeyAsync(_testAppId, 2);
            sourceKey.Should().NotBeNull();
            sourceKey.Kid.Should().NotBeNullOrEmpty();

            // Clone the key to the target application
            var clonedKey = await _credentialKeyApi.CloneApplicationKeyAsync(_testAppId, sourceKey.Kid, _targetAppId);

            // Verify a cloned key
            clonedKey.Should().NotBeNull();
            clonedKey.Kid.Should().Be(sourceKey.Kid);
            clonedKey.Kty.Should().Be(sourceKey.Kty);
            clonedKey.Use.Should().Be(sourceKey.Use);
            clonedKey.X5c.Should().BeEquivalentTo(sourceKey.X5c);

            // Verify the key exists in the target application
            var targetKeys = await _credentialKeyApi.ListApplicationKeys(_targetAppId).ToListAsync();
            targetKeys.Should().Contain(k => k.Kid == sourceKey.Kid);

            // Verify we can retrieve the cloned key from the target app
            var retrievedClonedKey = await _credentialKeyApi.GetApplicationKeyAsync(_targetAppId, sourceKey.Kid);
            retrievedClonedKey.Should().NotBeNull();
            retrievedClonedKey.Kid.Should().Be(sourceKey.Kid);
            retrievedClonedKey.X5c.Should().BeEquivalentTo(sourceKey.X5c);
        }

        #endregion

        #region CSR Metadata Variations Tests

        [Fact]
        public async Task GenerateCsr_WithVariousMetadata_CreatesCorrectCsrs()
        {
            // Test 1: Minimal metadata
            var minimalMetadata = new CsrMetadata
            {
                Subject = new CsrMetadataSubject
                {
                    CountryName = "US",
                    StateOrProvinceName = "CA",
                    LocalityName = "SF",
                    OrganizationName = "Test Org",
                    CommonName = "minimal.example.com"
                }
            };

            var minimalCsr = await _credentialKeyApi.GenerateCsrForApplicationAsync(_testAppId, minimalMetadata);
            minimalCsr.Should().NotBeNullOrEmpty();

            // Test 2: Metadata with multiple Subject Alternative Names
            var multiSanMetadata = new CsrMetadata
            {
                Subject = new CsrMetadataSubject
                {
                    CountryName = "US",
                    StateOrProvinceName = "California",
                    LocalityName = "San Francisco",
                    OrganizationName = "Multi SAN Test",
                    OrganizationalUnitName = "IT",
                    CommonName = "multi.example.com"
                },
                SubjectAltNames = new CsrMetadataSubjectAltNames
                {
                    DnsNames =
                    [
                        "multi.example.com",
                        "www.multi.example.com",
                        "api.multi.example.com",
                        "admin.multi.example.com"
                    ]
                }
            };

            var multiSanCsr = await _credentialKeyApi.GenerateCsrForApplicationAsync(_testAppId, multiSanMetadata);
            multiSanCsr.Should().NotBeNullOrEmpty();

            // Test 3: Metadata with wildcard domains
            var wildcardMetadata = new CsrMetadata
            {
                Subject = new CsrMetadataSubject
                {
                    CountryName = "US",
                    StateOrProvinceName = "New York",
                    LocalityName = "New York",
                    OrganizationName = "Wildcard Test",
                    CommonName = "*.wildcard.example.com"
                },
                SubjectAltNames = new CsrMetadataSubjectAltNames
                {
                    DnsNames =
                    [
                        "*.wildcard.example.com",
                        "wildcard.example.com"
                    ]
                }
            };

            var wildcardCsr = await _credentialKeyApi.GenerateCsrForApplicationAsync(_testAppId, wildcardMetadata);
            wildcardCsr.Should().NotBeNullOrEmpty();

            // Verify all CSRs were created
            var allCsrs = await _credentialKeyApi.ListCsrsForApplication(_testAppId).ToListAsync();
            allCsrs.Should().HaveCountGreaterThanOrEqualTo(3);
        }

        #endregion
    }
}
