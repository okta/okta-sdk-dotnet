// <copyright file="IdentityProviderApiTests.cs" company="Okta, Inc">
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
    /// Integration tests for IdentityProviderApi covering the entire lifecycle.
    /// 
    /// API Coverage:
    /// 1. POST /api/v1/idps - CreateIdentityProviderAsync, CreateIdentityProviderWithHttpInfoAsync
    /// 2. GET /api/v1/idps/{idpId} - GetIdentityProviderAsync, GetIdentityProviderWithHttpInfoAsync
    /// 3. GET /api/v1/idps - ListIdentityProviders, ListIdentityProvidersWithHttpInfoAsync
    /// 4. PUT /api/v1/idps/{idpId} - ReplaceIdentityProviderAsync, ReplaceIdentityProviderWithHttpInfoAsync
    /// 5. POST /api/v1/idps/{idpId}/lifecycle/deactivate - DeactivateIdentityProviderAsync, DeactivateIdentityProviderWithHttpInfoAsync
    /// 6. POST /api/v1/idps/{idpId}/lifecycle/activate - ActivateIdentityProviderAsync, ActivateIdentityProviderWithHttpInfoAsync
    /// 7. DELETE /api/v1/idps/{idpId} - DeleteIdentityProviderAsync, DeleteIdentityProviderWithHttpInfoAsync
    /// </summary>

    /// <summary>
    /// Integration tests for IdentityProviderApi covering all endpoints and methods, including HttpInfo variants and error scenarios.
    /// </summary>
    public class IdentityProviderApiTests
    {
        private readonly IdentityProviderApi _idpApi = new();

        [Fact]
        public async Task GivenIdentityProviderApi_WhenPerformingAllLifecycleOperations_ThenAllEndpointsAndMethodsWork()
        {
            string standardIdpId = null;
            string httpInfoIdpId = null;

            try
            {
                // ========================================================================
                // SECTION 1: Create Identity Provider
                // ========================================================================
                
                // 1A. Test standard CreateIdentityProviderAsync
                var standardIdpTemplate = CreateTestIdpTemplate("Automated OIDC IdP - Standard");
                var createdStandardIdp = await _idpApi.CreateIdentityProviderAsync(standardIdpTemplate);
                
                standardIdpId = createdStandardIdp.Id;
                standardIdpId.Should().NotBeNullOrEmpty();
                createdStandardIdp.Name.Should().Be("Automated OIDC IdP - Standard");
                createdStandardIdp.Status.Should().Be(LifecycleStatus.ACTIVE);

                // 1B. Test CreateIdentityProviderWithHttpInfoAsync
                var httpInfoIdpTemplate = CreateTestIdpTemplate("Automated OIDC IdP - HttpInfo");
                var createHttpInfoResponse = await _idpApi.CreateIdentityProviderWithHttpInfoAsync(httpInfoIdpTemplate);
                
                createHttpInfoResponse.Should().NotBeNull();
                createHttpInfoResponse.StatusCode.Should().Be(HttpStatusCode.OK); // Or 201 depending on exact Okta response
                
                httpInfoIdpId = createHttpInfoResponse.Data.Id;
                httpInfoIdpId.Should().NotBeNullOrEmpty();

                // ========================================================================
                // SECTION 2: Retrieve Identity Provider
                // ========================================================================
                
                // 2A. Test GetIdentityProviderAsync
                var fetchedStandardIdp = await _idpApi.GetIdentityProviderAsync(standardIdpId);
                fetchedStandardIdp.Should().NotBeNull();
                fetchedStandardIdp.Id.Should().Be(standardIdpId);

                // 2B. Test GetIdentityProviderWithHttpInfoAsync
                var fetchedHttpInfoIdp = await _idpApi.GetIdentityProviderWithHttpInfoAsync(httpInfoIdpId);
                fetchedHttpInfoIdp.StatusCode.Should().Be(HttpStatusCode.OK);
                fetchedHttpInfoIdp.Data.Id.Should().Be(httpInfoIdpId);

                // ========================================================================
                // SECTION 3: List Identity Providers
                // ========================================================================
                
                // 3A. Test ListIdentityProviders
                var idpsCollection = await _idpApi.ListIdentityProviders(q: "Automated OIDC IdP - Standard", limit: 5).ToListAsync();
                idpsCollection.Should().NotBeNull();
                idpsCollection.Should().Contain(idp => idp.Id == standardIdpId);

                // 3B. Test ListIdentityProvidersWithHttpInfoAsync
                var listHttpResponse = await _idpApi.ListIdentityProvidersWithHttpInfoAsync(q: "Automated OIDC IdP - HttpInfo", limit: 5);
                listHttpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                listHttpResponse.Data.Should().Contain(idp => idp.Id == httpInfoIdpId);

                // ========================================================================
                // SECTION 4: Replace (Update) Identity Provider
                // ========================================================================
                
                // 4A. Test ReplaceIdentityProviderAsync
                fetchedStandardIdp.Name = "Automated OIDC IdP - Standard Updated";
                fetchedStandardIdp.IssuerMode = IdentityProviderIssuerMode.DYNAMIC;
                
                var updatedStandardIdp = await _idpApi.ReplaceIdentityProviderAsync(standardIdpId, fetchedStandardIdp);
                updatedStandardIdp.Name.Should().Be("Automated OIDC IdP - Standard Updated");

                // 4B. Test ReplaceIdentityProviderWithHttpInfoAsync
                var idpToUpdateHttp = fetchedHttpInfoIdp.Data;
                idpToUpdateHttp.Name = "Automated OIDC IdP - HttpInfo Updated";
                idpToUpdateHttp.IssuerMode = IdentityProviderIssuerMode.DYNAMIC;
                
                var updatedHttpInfoIdp = await _idpApi.ReplaceIdentityProviderWithHttpInfoAsync(httpInfoIdpId, idpToUpdateHttp);
                updatedHttpInfoIdp.StatusCode.Should().Be(HttpStatusCode.OK);
                updatedHttpInfoIdp.Data.Name.Should().Be("Automated OIDC IdP - HttpInfo Updated");

                // ========================================================================
                // SECTION 5: Lifecycle Operations (Deactivate / Activate)
                // ========================================================================
                
                // 5A. Test Deactivate
                var deactivatedStandard = await _idpApi.DeactivateIdentityProviderAsync(standardIdpId);
                deactivatedStandard.Status.Should().Be(LifecycleStatus.INACTIVE);

                var deactivatedHttp = await _idpApi.DeactivateIdentityProviderWithHttpInfoAsync(httpInfoIdpId);
                deactivatedHttp.Data.Status.Should().Be(LifecycleStatus.INACTIVE);

                await Task.Delay(2000); // Allow eventual consistency

                // 5B. Test Activate
                var reactivatedStandard = await _idpApi.ActivateIdentityProviderAsync(standardIdpId);
                reactivatedStandard.Status.Should().Be(LifecycleStatus.ACTIVE);

                var reactivatedHttp = await _idpApi.ActivateIdentityProviderWithHttpInfoAsync(httpInfoIdpId);
                reactivatedHttp.Data.Status.Should().Be(LifecycleStatus.ACTIVE);
            }
            finally
            {
                // ========================================================================
                // CLEANUP: Deactivate and Delete both created Identity Providers
                // ========================================================================
                var idpsToClean = new[] { standardIdpId, httpInfoIdpId };

                foreach (var idpId in idpsToClean.Where(id => !string.IsNullOrEmpty(id)))
                {
                    try
                    {
                        var currentIdp = await _idpApi.GetIdentityProviderAsync(idpId);
                        if (currentIdp.Status == LifecycleStatus.ACTIVE)
                        {
                            await _idpApi.DeactivateIdentityProviderAsync(idpId);
                            await Task.Delay(2000); 
                        }
                    }
                    catch (ApiException) { }

                    try
                    {
                        // Use standard delete for the first one, HttpInfo delete for the second
                        if (idpId == standardIdpId)
                        {
                            await _idpApi.DeleteIdentityProviderAsync(idpId);
                        }
                        else
                        {
                            var deleteHttp = await _idpApi.DeleteIdentityProviderWithHttpInfoAsync(idpId);
                            deleteHttp.StatusCode.Should().BeOneOf(HttpStatusCode.OK, HttpStatusCode.NoContent); 
                        }
                    }
                    catch (ApiException) { }
                }
            }
        }

        [Fact]
        public async Task GivenIdentityProviderApi_WhenTestingErrorScenarios_ThenExceptionsAreThrown()
        {
            var fakeIdpId = "0oafake1invalid9idp0";

            // 1. Get Non-Existent IdP
            var getEx = await Assert.ThrowsAsync<ApiException>(
                () => _idpApi.GetIdentityProviderAsync(fakeIdpId));
            getEx.ErrorCode.Should().Be(404);

            // 2. Deactivate Non-Existent IdP
            var deactivateEx = await Assert.ThrowsAsync<ApiException>(
                () => _idpApi.DeactivateIdentityProviderAsync(fakeIdpId));
            deactivateEx.ErrorCode.Should().Be(404);

            // 3. Delete Non-Existent IdP
            var deleteEx = await Assert.ThrowsAsync<ApiException>(
                () => _idpApi.DeleteIdentityProviderAsync(fakeIdpId));
            deleteEx.ErrorCode.Should().Be(404);

            // 4. Create IdP with missing required fields (Trigger 400 Bad Request)
            var badIdp = new IdentityProvider { Type = IdentityProviderType.OIDC }; 
            var createEx = await Assert.ThrowsAsync<ApiException>(
                () => _idpApi.CreateIdentityProviderAsync(badIdp));
            createEx.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task ReplaceIdentityProviderAsync_WithOidcProtocolFetchedFromApi_DoesNotThrow500()
        {
            // Regression test for https://github.com/okta/okta-sdk-dotnet/issues/872.
            // Calling ReplaceIdentityProviderAsync with an IdentityProvider object returned by
            // GetIdentityProviderAsync previously caused HTTP 500 because null fields in the
            // oneOf IdentityProviderProtocol wrapper were incorrectly serialized as explicit nulls
            // instead of being omitted.
            string idpId = null;
            try
            {
                // Arrange — create an OIDC IdP
                var template = CreateTestIdpTemplate("Automated OIDC IdP - NullFieldsRegressionTest");
                var created = await _idpApi.CreateIdentityProviderAsync(template);
                idpId = created.Id;
                idpId.Should().NotBeNullOrEmpty();

                // Act — fetch the IdP and immediately replace it (this was the failing scenario)
                var fetched = await _idpApi.GetIdentityProviderAsync(idpId);
                fetched.Name = "Automated OIDC IdP - NullFieldsRegressionTest (updated)";

                // Assert — should succeed without throwing ApiException (HTTP 500)
                var replaced = await _idpApi.ReplaceIdentityProviderAsync(idpId, fetched);
                replaced.Should().NotBeNull();
                replaced.Id.Should().Be(idpId);
                replaced.Name.Should().Be("Automated OIDC IdP - NullFieldsRegressionTest (updated)");
            }
            finally
            {
                if (!string.IsNullOrEmpty(idpId))
                {
                    try
                    {
                        var current = await _idpApi.GetIdentityProviderAsync(idpId);
                        if (current.Status == LifecycleStatus.ACTIVE)
                            await _idpApi.DeactivateIdentityProviderAsync(idpId);
                    }
                    catch (ApiException) { }

                    try { await _idpApi.DeleteIdentityProviderAsync(idpId); }
                    catch (ApiException) { }
                }
            }
        }

        [Fact]
        public async Task CreateSamlIdp_WithoutHonorPersistentNameId_OmitsFieldSoApiDefaultApplies()
        {
            // Regression test for https://github.com/okta/okta-sdk-dotnet/issues/896.
            // honorPersistentNameId is an optional SAML setting whose API default is `true`. It was
            // generated as a non-nullable `bool`, so the SDK always sent it (defaulting to false),
            // overriding the API default. Now that it is `bool?`, leaving it unset omits it from the
            // request and the API applies its own default (true).
            var keysApi = new IdentityProviderKeysApi();
            string idpId = null;
            string kid = null;
            try
            {
                // Arrange — upload a self-signed cert as an IdP key (required for SAML trust).
                using var rsa = RSA.Create(2048);
                var req = new CertificateRequest("CN=okta-sdk-dotnet-issue896", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                using var cert = req.CreateSelfSigned(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(5));
                var x5c = Convert.ToBase64String(cert.Export(X509ContentType.Cert));
                var key = await keysApi.CreateIdentityProviderKeyAsync(new IdPCertificateCredential { X5c = new List<string> { x5c } });
                kid = key.Kid;

                // Act — create a SAML IdP WITHOUT setting HonorPersistentNameId.
                var created = await _idpApi.CreateIdentityProviderAsync(CreateTestSamlIdpTemplate("Automated SAML IdP - issue896", kid));
                idpId = created.Id;
                idpId.Should().NotBeNullOrEmpty();

                // Assert — the API applies its default (true) because the field was omitted.
                var fetched = await _idpApi.GetIdentityProviderAsync(idpId);
                var samlProtocol = fetched.Protocol.ActualInstance as ProtocolSaml;
                samlProtocol.Should().NotBeNull();
                samlProtocol.Settings.HonorPersistentNameId.Should().Be(true);
            }
            finally
            {
                if (!string.IsNullOrEmpty(idpId))
                {
                    try
                    {
                        var current = await _idpApi.GetIdentityProviderAsync(idpId);
                        if (current.Status == LifecycleStatus.ACTIVE)
                            await _idpApi.DeactivateIdentityProviderAsync(idpId);
                    }
                    catch (ApiException) { }
                    try { await _idpApi.DeleteIdentityProviderAsync(idpId); }
                    catch (ApiException) { }
                }
                if (!string.IsNullOrEmpty(kid))
                {
                    try { await keysApi.DeleteIdentityProviderKeyAsync(kid); }
                    catch (ApiException) { }
                }
            }
        }

        /// <summary>
        /// Helper method to generate a valid SAML 2.0 IdentityProvider payload for testing.
        /// </summary>
        private IdentityProvider CreateTestSamlIdpTemplate(string name, string kid)
        {
            return new IdentityProvider
            {
                Type = IdentityProviderType.SAML2,
                Name = name,
                Protocol = new IdentityProviderProtocol(new ProtocolSaml
                {
                    Type = ProtocolSaml.TypeEnum.SAML2,
                    Algorithms = new SamlAlgorithms
                    {
                        Request = new SamlRequestAlgorithm
                        {
                            Signature = new SamlRequestSignatureAlgorithm { Algorithm = SamlSigningAlgorithm._256, Scope = ProtocolAlgorithmRequestScope.REQUEST }
                        },
                        Response = new SamlResponseAlgorithm
                        {
                            Signature = new SamlResponseSignatureAlgorithm { Algorithm = SamlSigningAlgorithm._256, Scope = ProtocolAlgorithmResponseScope.ANY }
                        }
                    },
                    Endpoints = new SamlEndpoints
                    {
                        Sso = new SamlSsoEndpoint
                        {
                            Url = "https://idp.example.com/saml2/sso",
                            Binding = ProtocolEndpointBinding.REDIRECT,
                            Destination = "https://idp.example.com/saml2/sso"
                        },
                        Acs = new SamlAcsEndpoint { Binding = ProtocolEndpointBinding.POST, Type = SamlEndpointType.INSTANCE }
                    },
                    Credentials = new SamlCredentials
                    {
                        Trust = new SamlTrustCredentials
                        {
                            Issuer = "https://idp.example.com/issuer",
                            Audience = "https://www.okta.com/saml2/service-provider/issue896",
                            Kid = kid
                        }
                    },
                    // NOTE: deliberately leave Settings.HonorPersistentNameId unset (null).
                    Settings = new SamlSettings { NameFormat = SamlNameIdFormat._20nameidFormatpersistent }
                }),
                Policy = new IdentityProviderPolicy
                {
                    Provisioning = new Provisioning
                    {
                        Action = "AUTO",
                        ProfileMaster = false,
                        Groups = new() { Action = "NONE" },
                        Conditions = new() { Deprovisioned = new() { Action = "NONE" }, Suspended = new() { Action = "NONE" } }
                    },
                    AccountLink = new PolicyAccountLink { Action = "AUTO" },
                    Subject = new PolicySubject
                    {
                        MatchType = "USERNAME",
                        UserNameTemplate = new PolicyUserNameTemplate { Template = "idpuser.subjectNameId" }
                    },
                    MaxClockSkew = 0
                }
            };
        }

        /// <summary>
        /// Helper method to generate a valid IdentityProvider payload for testing
        /// </summary>
        private IdentityProvider CreateTestIdpTemplate(string name)
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
                        Authorization = new() { Url = "https://automated-idp.example.com/authorize", Binding = "HTTP-REDIRECT" },
                        Token = new() { Url = "https://automated-idp.example.com/token", Binding = "HTTP-POST" },
                        UserInfo = new() { Url = "https://automated-idp.example.com/userinfo", Binding = "HTTP-REDIRECT" },
                        Jwks = new() { Url = "https://automated-idp.example.com/jwks", Binding = "HTTP-REDIRECT" }
                    },
                    Scopes = ["openid", "profile", "email"],
                    Issuer = new ProtocolEndpointOidcIssuer { Url = "https://automated-idp.example.com" },
                    Credentials = new OAuthCredentials 
                    {
                        _Client = new() { ClientId = "auto-created-client-id", ClientSecret = "auto-created-client-secret" }
                    }
                }),
                Policy = new IdentityProviderPolicy 
                {
                    Provisioning = new Provisioning 
                    { 
                        Action = "AUTO", 
                        ProfileMaster = false,
                        Groups = new() { Action = "NONE" },
                        Conditions = new() 
                        {
                            Deprovisioned = new() { Action = "NONE" },
                            Suspended = new() { Action = "NONE" }
                        }
                    },
                    AccountLink = new PolicyAccountLink { Action = "AUTO" },
                    Subject = new PolicySubject 
                    { 
                        MatchType = "USERNAME", 
                        UserNameTemplate = new PolicyUserNameTemplate { Template = "idpuser.email" }
                    },
                    MaxClockSkew = 0
                }
            };
        }
    }
}