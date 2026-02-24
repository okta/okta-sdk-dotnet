// <copyright file="IdentityProviderSigningKeysApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for IdentityProviderSigningKeysApi covering the entire key and CSR lifecycle.
    /// 
    /// API Coverage:
    /// 1. POST /api/v1/idps/{idpId}/credentials/keys/generate - GenerateIdentityProviderSigningKeyAsync, GenerateIdentityProviderSigningKeyWithHttpInfoAsync
    /// 2. GET /api/v1/idps/{idpId}/credentials/keys/{kid} - GetIdentityProviderSigningKeyAsync, GetIdentityProviderSigningKeyWithHttpInfoAsync
    /// 3. GET /api/v1/idps/{idpId}/credentials/keys - ListIdentityProviderSigningKeys, ListIdentityProviderSigningKeysWithHttpInfoAsync
    /// 4. GET /api/v1/idps/{idpId}/credentials/keys/active - ListActiveIdentityProviderSigningKey, ListActiveIdentityProviderSigningKeyWithHttpInfoAsync
    /// 5. POST /api/v1/idps/{idpId}/credentials/keys/{kid}/clone - CloneIdentityProviderKeyAsync, CloneIdentityProviderKeyWithHttpInfoAsync
    /// 6. POST /api/v1/idps/{idpId}/credentials/csrs - GenerateCsrForIdentityProviderAsync, GenerateCsrForIdentityProviderWithHttpInfoAsync
    /// 7. GET /api/v1/idps/{idpId}/credentials/csrs/{idpCsrId} - GetCsrForIdentityProviderAsync, GetCsrForIdentityProviderWithHttpInfoAsync
    /// 8. GET /api/v1/idps/{idpId}/credentials/csrs - ListCsrsForIdentityProvider, ListCsrsForIdentityProviderWithHttpInfoAsync
    /// 9. DELETE /api/v1/idps/{idpId}/credentials/csrs/{idpCsrId} - RevokeCsrForIdentityProviderAsync, RevokeCsrForIdentityProviderWithHttpInfoAsync
    /// 10. POST /api/v1/idps/{idpId}/credentials/csrs/{idpCsrId}/lifecycle/publish - PublishCsrForIdentityProviderAsync, PublishCsrForIdentityProviderWithHttpInfoAsync
    /// </summary>
    public class IdentityProviderSigningKeysApiTests
    {
        private readonly IdentityProviderSigningKeysApi _signingKeysApi = new();
        private readonly IdentityProviderApi _idpApi = new();

        [Fact]
        public async Task GivenIdentityProviderSigningKeysApi_WhenPerformingLifecycleOperations_ThenAll20MethodsWork()
        {
            string sourceIdpId = null;
            string targetIdpId = null;

            try
            {
                // ========================================================================
                // SETUP: Create two temporary Identity Providers for testing
                // ========================================================================
                var sourceIdp = await _idpApi.CreateIdentityProviderAsync(CreateDummyIdpTemplate("Source IdP - Signing Keys Test"));
                sourceIdpId = sourceIdp.Id;

                var targetIdp = await _idpApi.CreateIdentityProviderAsync(CreateDummyIdpTemplate("Target IdP - Signing Keys Test"));
                targetIdpId = targetIdp.Id;

                // ========================================================================
                // 1. Generate Key
                // ========================================================================
                var generatedKey = await _signingKeysApi.GenerateIdentityProviderSigningKeyAsync(sourceIdpId, 2);
                generatedKey.Kid.Should().NotBeNullOrEmpty();

                var generatedKeyHttp = await _signingKeysApi.GenerateIdentityProviderSigningKeyWithHttpInfoAsync(sourceIdpId, 2);
                generatedKeyHttp.StatusCode.Should().Be(HttpStatusCode.Created); 
                var httpKid = generatedKeyHttp.Data.Kid;

                // ========================================================================
                // 2. Get Key
                // ========================================================================
                var fetchedKey = await _signingKeysApi.GetIdentityProviderSigningKeyAsync(sourceIdpId, generatedKey.Kid);
                fetchedKey.Kid.Should().Be(generatedKey.Kid);

                var fetchedKeyHttp = await _signingKeysApi.GetIdentityProviderSigningKeyWithHttpInfoAsync(sourceIdpId, httpKid);
                fetchedKeyHttp.StatusCode.Should().Be(HttpStatusCode.OK);

                // ========================================================================
                // 3. List All Keys
                // ========================================================================
                var allKeys = await _signingKeysApi.ListIdentityProviderSigningKeys(sourceIdpId).ToListAsync();
                allKeys.Should().Contain(k => k.Kid == generatedKey.Kid);

                var allKeysHttp = await _signingKeysApi.ListIdentityProviderSigningKeysWithHttpInfoAsync(sourceIdpId);
                allKeysHttp.StatusCode.Should().Be(HttpStatusCode.OK);

                // ========================================================================
                // 4. List Active Key
                // ========================================================================
                var activeKeys = await _signingKeysApi.ListActiveIdentityProviderSigningKey(sourceIdpId).ToListAsync();
                activeKeys.Should().NotBeNull(); // Expected to be empty list initially

                var activeKeysHttp = await _signingKeysApi.ListActiveIdentityProviderSigningKeyWithHttpInfoAsync(sourceIdpId);
                activeKeysHttp.StatusCode.Should().Be(HttpStatusCode.OK);

                // ========================================================================
                // 5. Clone Key to Target IdP
                // ========================================================================
                var clonedKey = await _signingKeysApi.CloneIdentityProviderKeyAsync(sourceIdpId, generatedKey.Kid, targetIdpId);
                clonedKey.Kid.Should().Be(generatedKey.Kid);

                var clonedKeyHttp = await _signingKeysApi.CloneIdentityProviderKeyWithHttpInfoAsync(sourceIdpId, httpKid, targetIdpId);
                // FIX: Okta returns 201 Created for the clone endpoint
                clonedKeyHttp.StatusCode.Should().Be(HttpStatusCode.Created);

                // ========================================================================
                // 6. Generate CSR
                // ========================================================================
                var csrPayload = new CsrMetadata
                {
                    Subject = new CsrMetadataSubject
                    {
                        CommonName = "okta.test.com",
                        OrganizationName = "Okta Tests",
                        LocalityName = "San Francisco",
                        StateOrProvinceName = "California",
                        CountryName = "US"
                    },
                    SubjectAltNames = new CsrMetadataSubjectAltNames
                    {
                        DnsNames = ["okta.test.com"]
                    }
                };

                var generatedCsr = await _signingKeysApi.GenerateCsrForIdentityProviderAsync(sourceIdpId, csrPayload);
                generatedCsr.Id.Should().NotBeNullOrEmpty();
                generatedCsr.Csr.Should().NotBeNullOrEmpty();

                var generatedCsrHttp = await _signingKeysApi.GenerateCsrForIdentityProviderWithHttpInfoAsync(sourceIdpId, csrPayload);
                generatedCsrHttp.StatusCode.Should().BeOneOf(HttpStatusCode.OK, HttpStatusCode.Created);
                var httpCsrId = generatedCsrHttp.Data.Id;

                // ========================================================================
                // 7. Get CSR
                // ========================================================================
                var fetchedCsr = await _signingKeysApi.GetCsrForIdentityProviderAsync(sourceIdpId, generatedCsr.Id);
                fetchedCsr.Id.Should().Be(generatedCsr.Id);

                var fetchedCsrHttp = await _signingKeysApi.GetCsrForIdentityProviderWithHttpInfoAsync(sourceIdpId, httpCsrId);
                fetchedCsrHttp.StatusCode.Should().Be(HttpStatusCode.OK);

                // ========================================================================
                // 8. List CSRs
                // ========================================================================
                var allCsrs = await _signingKeysApi.ListCsrsForIdentityProvider(sourceIdpId).ToListAsync();
                allCsrs.Should().Contain(c => c.Id == generatedCsr.Id);

                var allCsrsHttp = await _signingKeysApi.ListCsrsForIdentityProviderWithHttpInfoAsync(sourceIdpId);
                allCsrsHttp.StatusCode.Should().Be(HttpStatusCode.OK);

                // ========================================================================
                // 9. Publish CSR (Error Scenario test)
                // ========================================================================
                using var dummyDerStream1 = new MemoryStream(Encoding.UTF8.GetBytes("invalid-der-data"));
                var publishEx = await Assert.ThrowsAsync<ApiException>(
                    () => _signingKeysApi.PublishCsrForIdentityProviderAsync(sourceIdpId, generatedCsr.Id, dummyDerStream1));
                publishEx.ErrorCode.Should().Be(400); 

                using var dummyDerStream2 = new MemoryStream(Encoding.UTF8.GetBytes("invalid-der-data"));
                var publishHttpEx = await Assert.ThrowsAsync<ApiException>(
                    () => _signingKeysApi.PublishCsrForIdentityProviderWithHttpInfoAsync(sourceIdpId, httpCsrId, dummyDerStream2));
                publishHttpEx.ErrorCode.Should().Be(400);

                // ========================================================================
                // 10. Revoke (Delete) CSR
                // ========================================================================
                await _signingKeysApi.RevokeCsrForIdentityProviderAsync(sourceIdpId, generatedCsr.Id);
                
                var revokeHttp = await _signingKeysApi.RevokeCsrForIdentityProviderWithHttpInfoAsync(sourceIdpId, httpCsrId);
                revokeHttp.StatusCode.Should().BeOneOf(HttpStatusCode.OK, HttpStatusCode.NoContent);
            }
            finally
            {
                // ========================================================================
                // CLEANUP: Delete temporary Identity Providers
                // ========================================================================
                var idpsToClean = new[] { sourceIdpId, targetIdpId };
                foreach (var id in idpsToClean.Where(i => !string.IsNullOrEmpty(i)))
                {
                    try
                    {
                        var currentIdp = await _idpApi.GetIdentityProviderAsync(id);
                        if (currentIdp.Status == LifecycleStatus.ACTIVE)
                        {
                            await _idpApi.DeactivateIdentityProviderAsync(id);
                            await Task.Delay(2000); 
                        }
                        await _idpApi.DeleteIdentityProviderAsync(id);
                    }
                    catch (ApiException) { /* Ignore cleanup errors */ }
                }
            }
        }

        [Fact]
        public async Task GivenIdentityProviderSigningKeysApi_WhenTestingErrorScenarios_ThenExceptionsAreThrown()
        {
            var fakeIdpId = "0oafake1idp9invalid0";
            var fakeKid = "fake-kid-123";

            // 1. Get Non-Existent Key
            var getEx = await Assert.ThrowsAsync<ApiException>(
                () => _signingKeysApi.GetIdentityProviderSigningKeyAsync(fakeIdpId, fakeKid));
            getEx.ErrorCode.Should().Be(404);

            // 2. Clone Key with invalid IDs
            var cloneEx = await Assert.ThrowsAsync<ApiException>(
                () => _signingKeysApi.CloneIdentityProviderKeyAsync(fakeIdpId, fakeKid, "another-fake-id"));
            cloneEx.ErrorCode.Should().Be(404);
        }

        /// <summary>
        /// Helper to create a minimal valid Identity Provider to attach keys to.
        /// </summary>
        private IdentityProvider CreateDummyIdpTemplate(string name)
        {
            return new IdentityProvider
            {
                Type = IdentityProviderType.OIDC,
                Name = name,
                Protocol = new IdentityProviderProtocol(new ProtocolOidc
                {
                    Type = ProtocolOidc.TypeEnum.OIDC,
                    Endpoints = new OAuthEndpoints 
                    {
                        Authorization = new OAuthAuthorizationEndpoint { Url = "https://test.example.com/authorize", Binding = "HTTP-REDIRECT" },
                        Token = new OAuthTokenEndpoint { Url = "https://test.example.com/token", Binding = "HTTP-POST" },
                        UserInfo = new OidcUserInfoEndpoint { Url = "https://test.example.com/userinfo", Binding = "HTTP-REDIRECT" },
                        Jwks = new OidcJwksEndpoint { Url = "https://test.example.com/jwks", Binding = "HTTP-REDIRECT" }
                    },
                    Scopes = ["openid"],
                    Issuer = new ProtocolEndpointOidcIssuer { Url = "https://test.example.com" },
                    Credentials = new OAuthCredentials 
                    {
                        _Client = new OAuthCredentialsClient { ClientId = "test-client", ClientSecret = "test-secret" }
                    }
                }),
                Policy = new IdentityProviderPolicy 
                {
                    Provisioning = new Provisioning 
                    { 
                        Action = "AUTO", 
                        ProfileMaster = false,
                        Groups = new ProvisioningGroups { Action = "NONE" },
                        Conditions = new ProvisioningConditions { Deprovisioned = new ProvisioningDeprovisionedCondition { Action = "NONE" }, Suspended = new ProvisioningSuspendedCondition { Action = "NONE" } }
                    },
                    AccountLink = new PolicyAccountLink { Action = "AUTO" },
                    Subject = new PolicySubject 
                    { 
                        MatchType = "USERNAME", 
                        UserNameTemplate = new PolicyUserNameTemplate { Template = "idpuser.email" }
                    }
                }
            };
        }
    }
}