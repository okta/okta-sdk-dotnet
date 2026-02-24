// <copyright file="IdentityProviderApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System.Linq;
using System.Net;
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