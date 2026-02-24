// <copyright file="IdentityProviderKeysApiTests.cs" company="Okta, Inc">
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
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for IdentityProviderKeysApi covering the entire lifecycle.
    /// 
    /// API Coverage:
    /// 1. POST /api/v1/idps/credentials/keys - CreateIdentityProviderKeyAsync, CreateIdentityProviderKeyWithHttpInfoAsync
    /// 2. GET /api/v1/idps/credentials/keys/{keyId} - GetIdentityProviderKeyAsync, GetIdentityProviderKeyWithHttpInfoAsync
    /// 3. GET /api/v1/idps/credentials/keys - ListIdentityProviderKeys, ListIdentityProviderKeysWithHttpInfoAsync
    /// 4. PUT /api/v1/idps/credentials/keys/{keyId} - ReplaceIdentityProviderKeyAsync, ReplaceIdentityProviderKeyWithHttpInfoAsync
    /// 5. DELETE /api/v1/idps/credentials/keys/{keyId} - DeleteIdentityProviderKeyAsync, DeleteIdentityProviderKeyWithHttpInfoAsync
    /// </summary>

    /// <summary>
    /// Integration tests for IdentityProviderKeysApi covering all endpoints and methods, including HttpInfo variants and error scenarios.
    /// </summary>
    public class IdentityProviderKeysApiTests
    {
        private readonly IdentityProviderKeysApi _keysApi = new();

        // Helper method to generate a 100% unique, valid X509 Certificate at runtime
        private string GenerateDynamicX509Certificate()
        {
            using var rsa = RSA.Create(2048);
            var req = new CertificateRequest(
                $"cn=okta-test-{Guid.NewGuid()}.com", 
                rsa, 
                HashAlgorithmName.SHA256, 
                RSASignaturePadding.Pkcs1);

            // Make it valid from yesterday to 10 years in the future
            var cert = req.CreateSelfSigned(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(10));
            
            // Export to a DER encoded byte array, then Base64 string (which Okta requires)
            return Convert.ToBase64String(cert.Export(X509ContentType.Cert));
        }

        [Fact]
        public async Task GivenIdentityProviderKeysApi_WhenPerformingLifecycleOperations_ThenAll5EndpointsAndMethodsWork()
        {
            string standardKeyId = null;
            string httpInfoKeyId = null;

            // Generate unique certificates for this specific test run
            var dynamicCert1 = GenerateDynamicX509Certificate();
            var dynamicCert2 = GenerateDynamicX509Certificate();

            try
            {
                // ========================================================================
                // 1. Create Identity Provider Key
                // ========================================================================
                
                // 1A. Test standard CreateIdentityProviderKeyAsync
                var standardKeyPayload = new IdPCertificateCredential
                {
                    X5c = [dynamicCert1]
                };
                
                var createdStandardKey = await _keysApi.CreateIdentityProviderKeyAsync(standardKeyPayload);
                standardKeyId = createdStandardKey.Kid;
                
                standardKeyId.Should().NotBeNullOrEmpty();
                createdStandardKey.Kty.Should().Be("RSA");

                // 1B. Test CreateIdentityProviderKeyWithHttpInfoAsync
                var httpInfoKeyPayload = new IdPCertificateCredential
                {
                    X5c = [dynamicCert2]
                };

                var createHttpInfoResponse = await _keysApi.CreateIdentityProviderKeyWithHttpInfoAsync(httpInfoKeyPayload);
                createHttpInfoResponse.Should().NotBeNull();
                createHttpInfoResponse.StatusCode.Should().Be(HttpStatusCode.OK); 
                
                httpInfoKeyId = createHttpInfoResponse.Data.Kid;
                httpInfoKeyId.Should().NotBeNullOrEmpty();

                // ========================================================================
                // 2. Retrieve Identity Provider Key
                // ========================================================================
                
                // 2A. Test GetIdentityProviderKeyAsync
                var fetchedStandardKey = await _keysApi.GetIdentityProviderKeyAsync(standardKeyId);
                fetchedStandardKey.Should().NotBeNull();
                fetchedStandardKey.Kid.Should().Be(standardKeyId);

                // 2B. Test GetIdentityProviderKeyWithHttpInfoAsync
                var fetchedHttpInfoKey = await _keysApi.GetIdentityProviderKeyWithHttpInfoAsync(httpInfoKeyId);
                fetchedHttpInfoKey.StatusCode.Should().Be(HttpStatusCode.OK);
                fetchedHttpInfoKey.Data.Kid.Should().Be(httpInfoKeyId);

                // ========================================================================
                // 3. List Identity Provider Keys
                // ========================================================================
                
                // 3A. Test ListIdentityProviderKeys
                var keysCollection = await _keysApi.ListIdentityProviderKeys(limit: 10).ToListAsync();
                keysCollection.Should().NotBeNull();
                keysCollection.Should().Contain(k => k.Kid == standardKeyId);

                // 3B. Test ListIdentityProviderKeysWithHttpInfoAsync
                var listHttpResponse = await _keysApi.ListIdentityProviderKeysWithHttpInfoAsync(limit: 10);
                listHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                listHttpResponse.Data.Should().Contain(k => k.Kid == httpInfoKeyId);

                // ========================================================================
                // 4. Replace Identity Provider Key
                // ========================================================================
                
                // 4A. Test ReplaceIdentityProviderKeyAsync
                var standardReplacePayload = new Dictionary<string, object>
                {
                    { "kid", standardKeyId },
                    { "kty", "RSA" },
                    { "use", "sig" },
                    { "x5c", new List<string> { dynamicCert1 } }
                };

                var replacedStandardKey = await _keysApi.ReplaceIdentityProviderKeyAsync(standardKeyId, standardReplacePayload);
                replacedStandardKey.Kid.Should().Be(standardKeyId);

                // 4B. Test ReplaceIdentityProviderKeyWithHttpInfoAsync
                var httpInfoReplacePayload = new Dictionary<string, object>
                {
                    { "kid", httpInfoKeyId },
                    { "kty", "RSA" },
                    { "use", "sig" },
                    { "x5c", new List<string> { dynamicCert2 } }
                };

                var replacedHttpInfoKey = await _keysApi.ReplaceIdentityProviderKeyWithHttpInfoAsync(httpInfoKeyId, httpInfoReplacePayload);
                replacedHttpInfoKey.StatusCode.Should().Be(HttpStatusCode.OK);
                replacedHttpInfoKey.Data.Kid.Should().Be(httpInfoKeyId);
            }
            finally
            {
                // ========================================================================
                // 5. Delete Identity Provider Keys
                // ========================================================================
                var keysToClean = new[] { standardKeyId, httpInfoKeyId };

                foreach (var kid in keysToClean.Where(id => !string.IsNullOrEmpty(id)))
                {
                    try
                    {
                        if (kid == standardKeyId)
                        {
                            await _keysApi.DeleteIdentityProviderKeyAsync(kid);
                        }
                        else
                        {
                            var deleteHttp = await _keysApi.DeleteIdentityProviderKeyWithHttpInfoAsync(kid);
                            deleteHttp.StatusCode.Should().BeOneOf(HttpStatusCode.OK, HttpStatusCode.NoContent); 
                        }
                    }
                    catch (ApiException) { /* Ignore deletion errors during cleanup */ }
                }
            }
        }

        [Fact]
        public async Task GivenIdentityProviderKeysApi_WhenTestingErrorScenarios_ThenExceptionsAreThrown()
        {
            const string fakeKid = "0oafakekeyid12345";

            var getEx = await Assert.ThrowsAsync<ApiException>(
                () => _keysApi.GetIdentityProviderKeyAsync(fakeKid));
            getEx.ErrorCode.Should().Be(404);

            var deleteEx = await Assert.ThrowsAsync<ApiException>(
                () => _keysApi.DeleteIdentityProviderKeyAsync(fakeKid));
            deleteEx.ErrorCode.Should().Be(404);

            var badKey = new IdPCertificateCredential { X5c = [] }; 
            var createEx = await Assert.ThrowsAsync<ApiException>(
                () => _keysApi.CreateIdentityProviderKeyAsync(badKey));
            createEx.ErrorCode.Should().Be(400);
        }
    }
}