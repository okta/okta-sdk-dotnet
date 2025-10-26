using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for ApplicationSSOFederatedClaimsApi - manages federated claims for SSO applications.
    /// Federated claims are included in tokens produced by federation protocols (OIDC id_tokens, SAML Assertions).
    /// </summary>
    [Collection(nameof(ApplicationSsoFederatedClaimsApiTests))]
    public class ApplicationSsoFederatedClaimsApiTests : IDisposable
    {
        private readonly ApplicationSSOFederatedClaimsApi _federatedClaimsApi = new();
        private readonly ApplicationApi _applicationApi = new();
        private readonly List<string> _createdAppIds = [];

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
                    await _applicationApi.DeactivateApplicationAsync(appId);
                    await _applicationApi.DeleteApplicationAsync(appId);
                }
                catch (ApiException) { }
            }
            _createdAppIds.Clear();
        }

        private async Task<string> CreateTestOidcApp()
        {
            var app = new OpenIdConnectApplication
            {
                Name = "oidc_client",
                Label = $"Test Federated Claims App {Guid.NewGuid()}",
                SignOnMode = "OPENID_CONNECT",
                Credentials = new OAuthApplicationCredentials
                {
                    OauthClient = new ApplicationCredentialsOAuthClient
                    {
                        ClientId = null,
                        AutoKeyRotation = true,
                        TokenEndpointAuthMethod = OAuthEndpointAuthenticationMethod.ClientSecretBasic
                    }
                },
                Settings = new OpenIdConnectApplicationSettings
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient
                    {
                        ClientUri = "https://example.com",
                        ResponseTypes = [OAuthResponseType.Code],
                        GrantTypes = [GrantType.AuthorizationCode],
                        ApplicationType = OpenIdConnectApplicationType.Web,
                        RedirectUris = ["https://example.com/callback"]
                    }
                }
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(app);
            _createdAppIds.Add(createdApp.Id);
            return createdApp.Id;
        }

        private string GenerateFakeClaimId() => "ofc" + Guid.NewGuid().ToString().Replace("-", "");

        [Fact]
        public async Task ApplicationSSOFederatedClaimsApi_CreateGetReplaceDelete_WorksCorrectly()
        {
            // Arrange
            var appId = await CreateTestOidcApp();
            appId.Should().NotBeNullOrEmpty();

            // ==================== CREATE OPERATIONS ====================
            var claimRequest = new FederatedClaimRequestBody
            {
                Name = "department",
                Expression = "user.profile.department"
            };

            var createdClaim = await _federatedClaimsApi.CreateFederatedClaimAsync(appId, claimRequest);
            createdClaim.Should().NotBeNull();
            createdClaim.Id.Should().NotBeNullOrEmpty().And.StartWith("ofc");
            createdClaim.Name.Should().Be("department");
            createdClaim.Expression.Should().Be("user.profile.department");
            createdClaim.Created.Should().NotBeNullOrEmpty();
            createdClaim.LastUpdated.Should().NotBeNullOrEmpty();

            var claimId = createdClaim.Id;

            // Test CreateWithHttpInfo - validates HTTP response
            var createRequest2 = new FederatedClaimRequestBody
            {
                Name = "userRole",
                Expression = "user.profile.title"
            };

            var createResponse = await _federatedClaimsApi.CreateFederatedClaimWithHttpInfoAsync(appId, createRequest2);
            createResponse.Should().NotBeNull();
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);
            createResponse.Data.Should().NotBeNull();
            createResponse.Data.Name.Should().Be("userRole");
            createResponse.Headers.Should().NotBeNull()
                .And.ContainKey("Content-Type");

            var claimId2 = createResponse.Data.Id;

            // ==================== GET OPERATIONS ====================
            var retrievedClaim = await _federatedClaimsApi.GetFederatedClaimAsync(appId, claimId);
            retrievedClaim.Should().NotBeNull();
            retrievedClaim.Name.Should().Be("department");
            retrievedClaim.Expression.Should().Be("user.profile.department");

            // Test GetWithHttpInfo
            var getResponse = await _federatedClaimsApi.GetFederatedClaimWithHttpInfoAsync(appId, claimId);
            getResponse.Should().NotBeNull();
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.Data.Should().NotBeNull();
            getResponse.Data.Name.Should().Be("department");
            getResponse.Headers.Should().NotBeNull()
                .And.ContainKey("Content-Type");

            // ==================== LIST OPERATIONS ====================
            var claimsCollection = _federatedClaimsApi.ListFederatedClaims(appId);
            claimsCollection.Should().NotBeNull();
            var claimsList = await claimsCollection.ToListAsync();
            claimsList.Should().NotBeNull()
                .And.HaveCountGreaterOrEqualTo(2);
            claimsList.Should().Contain(c => c.Name == "department");
            claimsList.Should().Contain(c => c.Name == "userRole");

            // Test ListWithHttpInfo
            var listResponse = await _federatedClaimsApi.ListFederatedClaimsWithHttpInfoAsync(appId);
            listResponse.Should().NotBeNull();
            listResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            listResponse.Data.Should().NotBeNull()
                .And.HaveCountGreaterOrEqualTo(2);
            listResponse.Headers.Should().NotBeNull()
                .And.ContainKey("Content-Type");

            // ==================== REPLACE OPERATIONS ====================
            var replaceClaim = new FederatedClaim
            {
                Name = "division",
                Expression = "user.profile.division"
            };

            var replacedClaim = await _federatedClaimsApi.ReplaceFederatedClaimAsync(appId, claimId, replaceClaim);
            replacedClaim.Should().NotBeNull();
            replacedClaim.Id.Should().Be(claimId, "ID should remain the same");
            replacedClaim.Name.Should().Be("division", "name was updated");
            replacedClaim.Expression.Should().Be("user.profile.division", "expression was updated");
            replacedClaim.LastUpdated.Should().NotBeNullOrEmpty();

            // Test ReplaceWithHttpInfo
            var replaceClaim2 = new FederatedClaim
            {
                Name = "manager",
                Expression = "user.profile.managerId"
            };

            var replaceResponse = await _federatedClaimsApi.ReplaceFederatedClaimWithHttpInfoAsync(appId, claimId2, replaceClaim2);
            replaceResponse.Should().NotBeNull();
            replaceResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            replaceResponse.Data.Should().NotBeNull();
            replaceResponse.Data.Name.Should().Be("manager");
            replaceResponse.Data.Id.Should().Be(claimId2, "ID should remain unchanged after replace");
            replaceResponse.Data.Created.Should().Be(createResponse.Data.Created, "created timestamp should not change");
            replaceResponse.Data.LastUpdated.Should().NotBe(createResponse.Data.LastUpdated, "lastUpdated should change after replace");
            replaceResponse.Headers.Should().NotBeNull()
                .And.ContainKey("Content-Type");
            replaceResponse.Headers["Content-Type"].Should().Contain("application/json");

            // ==================== DELETE OPERATIONS ====================
            await _federatedClaimsApi.DeleteFederatedClaimAsync(appId, claimId);

            // Verify deletion - should return 404
            var deleteVerifyException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.GetFederatedClaimAsync(appId, claimId));
            deleteVerifyException.ErrorCode.Should().Be(404);

            // Test DeleteWithHttpInfo
            var deleteResponse = await _federatedClaimsApi.DeleteFederatedClaimWithHttpInfoAsync(appId, claimId2);
            deleteResponse.Should().NotBeNull();
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Verify second deletion
            var deleteVerifyException2 = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.GetFederatedClaimAsync(appId, claimId2));
            deleteVerifyException2.ErrorCode.Should().Be(404);

            // The Final list should be empty
            var finalList = await _federatedClaimsApi.ListFederatedClaims(appId).ToListAsync();
            finalList.Should().BeEmpty("all claims were deleted");
        }

        [Fact]
        public async Task ApplicationSSOFederatedClaimsApi_ErrorHandling_ValidatesAllScenarios()
        {
            // ==================== SETUP ====================
            var validAppId = await CreateTestOidcApp();
            var fakeAppId = "0oa" + Guid.NewGuid().ToString().Replace("-", "");
            var fakeClaimId = GenerateFakeClaimId();
            var claimRequest = new FederatedClaimRequestBody
            {
                Name = "test",
                Expression = "user.profile.test"
            };
            var federatedClaim = new FederatedClaim
            {
                Name = "test",
                Expression = "user.profile.test"
            };

            // ==================== SCENARIO 1: Invalid App ID (404 errors) ====================
            
            // CREATE with invalid app ID
            var createException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.CreateFederatedClaimAsync(fakeAppId, claimRequest));
            createException.ErrorCode.Should().Be(404);
            createException.Message.Should().Contain("Not found");

            var createHttpException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.CreateFederatedClaimWithHttpInfoAsync(fakeAppId, claimRequest));
            createHttpException.ErrorCode.Should().Be(404);

            // LIST with invalid app ID (collection enumeration)
            var listCollection = _federatedClaimsApi.ListFederatedClaims(fakeAppId);
            var listCollectionException = await Assert.ThrowsAsync<ApiException>(
                async () => await listCollection.ToListAsync());
            listCollectionException.ErrorCode.Should().Be(404);

            // LIST with invalid app ID (WithHttpInfo variant)
            var listException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.ListFederatedClaimsWithHttpInfoAsync(fakeAppId));
            listException.ErrorCode.Should().Be(404);

            // GET with invalid app ID
            var getException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.GetFederatedClaimAsync(fakeAppId, fakeClaimId));
            getException.ErrorCode.Should().Be(404);

            var getHttpException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.GetFederatedClaimWithHttpInfoAsync(fakeAppId, fakeClaimId));
            getHttpException.ErrorCode.Should().Be(404);

            // REPLACE with invalid app ID
            var replaceException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.ReplaceFederatedClaimAsync(fakeAppId, fakeClaimId, federatedClaim));
            replaceException.ErrorCode.Should().Be(404);

            var replaceHttpException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.ReplaceFederatedClaimWithHttpInfoAsync(fakeAppId, fakeClaimId, federatedClaim));
            replaceHttpException.ErrorCode.Should().Be(404);

            // DELETE with invalid app ID
            var deleteException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.DeleteFederatedClaimAsync(fakeAppId, fakeClaimId));
            deleteException.ErrorCode.Should().Be(404);

            var deleteHttpException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.DeleteFederatedClaimWithHttpInfoAsync(fakeAppId, fakeClaimId));
            deleteHttpException.ErrorCode.Should().Be(404);

            // ==================== SCENARIO 2: Invalid Claim ID (404 errors) ====================
            
            // GET with invalid claim ID
            var getClaimException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.GetFederatedClaimAsync(validAppId, fakeClaimId));
            getClaimException.ErrorCode.Should().Be(404);
            getClaimException.Message.Should().Contain("Not found");

            var getClaimHttpException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.GetFederatedClaimWithHttpInfoAsync(validAppId, fakeClaimId));
            getClaimHttpException.ErrorCode.Should().Be(404);

            // REPLACE with invalid claim ID
            var replaceClaimException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.ReplaceFederatedClaimAsync(validAppId, fakeClaimId, federatedClaim));
            replaceClaimException.ErrorCode.Should().Be(404);

            var replaceClaimHttpException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.ReplaceFederatedClaimWithHttpInfoAsync(validAppId, fakeClaimId, federatedClaim));
            replaceClaimHttpException.ErrorCode.Should().Be(404);

            // DELETE with invalid claim ID
            var deleteClaimException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.DeleteFederatedClaimAsync(validAppId, fakeClaimId));
            deleteClaimException.ErrorCode.Should().Be(404);

            var deleteClaimHttpException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.DeleteFederatedClaimWithHttpInfoAsync(validAppId, fakeClaimId));
            deleteClaimHttpException.ErrorCode.Should().Be(404);

            // ==================== SCENARIO 3: Null Parameters ====================
            
            // CREATE with null app ID
            var createNullAppException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.CreateFederatedClaimAsync(null, claimRequest));
            createNullAppException.ErrorCode.Should().BeGreaterThan(0);

            // CREATE with null request body
            var createNullBodyException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.CreateFederatedClaimAsync(validAppId, null));
            createNullBodyException.ErrorCode.Should().BeGreaterThan(0);

            // GET with null app ID
            var getNullAppException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.GetFederatedClaimAsync(null, "claimId"));
            getNullAppException.ErrorCode.Should().BeGreaterThan(0);

            // GET with null claim ID
            var getNullClaimException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.GetFederatedClaimAsync(validAppId, null));
            getNullClaimException.ErrorCode.Should().BeGreaterThan(0);

            // REPLACE with null app ID
            var replaceNullAppException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.ReplaceFederatedClaimAsync(null, "claimId", federatedClaim));
            replaceNullAppException.ErrorCode.Should().BeGreaterThan(0);

            // REPLACE with null claim ID
            var replaceNullClaimException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.ReplaceFederatedClaimAsync(validAppId, null, federatedClaim));
            replaceNullClaimException.ErrorCode.Should().BeGreaterThan(0);

            // DELETE with null app ID
            var deleteNullAppException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.DeleteFederatedClaimAsync(null, "claimId"));
            deleteNullAppException.ErrorCode.Should().BeGreaterThan(0);

            // DELETE with null claim ID
            var deleteNullClaimException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.DeleteFederatedClaimAsync(validAppId, null));
            deleteNullClaimException.ErrorCode.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task ApplicationSSOFederatedClaimsApi_ListOperations_WorkCorrectly()
        {
            // Arrange
            var appId = await CreateTestOidcApp();

            // Verify an empty list initially
            var emptyList = await _federatedClaimsApi.ListFederatedClaims(appId).ToListAsync();
            emptyList.Should().BeEmpty();

            // Create multiple claims
            var claim1 = await _federatedClaimsApi.CreateFederatedClaimAsync(appId, new FederatedClaimRequestBody
            {
                Name = "location",
                Expression = "user.profile.city"
            });

            var claim2 = await _federatedClaimsApi.CreateFederatedClaimAsync(appId, new FederatedClaimRequestBody
            {
                Name = "country",
                Expression = "user.profile.countryCode"
            });

            var claim3 = await _federatedClaimsApi.CreateFederatedClaimAsync(appId, new FederatedClaimRequestBody
            {
                Name = "costCenter",
                Expression = "user.profile.costCenter"
            });

            // Act - List all claims using ToListAsync()
            var allClaims = await _federatedClaimsApi.ListFederatedClaims(appId).ToListAsync();

            // Assert
            allClaims.Should().NotBeNull()
                .And.HaveCount(3);
            allClaims.Should().Contain(c => c.Name == "location" && c.Expression == "user.profile.city");
            allClaims.Should().Contain(c => c.Name == "country" && c.Expression == "user.profile.countryCode");
            allClaims.Should().Contain(c => c.Name == "costCenter" && c.Expression == "user.profile.costCenter");

            // All claims should have required properties
            allClaims.Should().OnlyContain(c => 
                !string.IsNullOrEmpty(c.Id) && 
                c.Id.StartsWith("ofc") &&
                !string.IsNullOrEmpty(c.Name) &&
                !string.IsNullOrEmpty(c.Expression) &&
                !string.IsNullOrEmpty(c.Created) &&
                !string.IsNullOrEmpty(c.LastUpdated));

            // Test async enumeration pattern (await foreach)
            var enumeratedClaims = new List<FederatedClaim>();
            await foreach (var claim in _federatedClaimsApi.ListFederatedClaims(appId))
            {
                enumeratedClaims.Add(claim);
            }
            enumeratedClaims.Should().HaveCount(3, "await foreach should enumerate all claims");
            enumeratedClaims.Should().BeEquivalentTo(allClaims, "enumerated claims should match ToListAsync results");

            // Test ListWithHttpInfo validates response
            var listResponse = await _federatedClaimsApi.ListFederatedClaimsWithHttpInfoAsync(appId);
            listResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            listResponse.Data.Should().HaveCount(3);
            listResponse.Headers.Should().ContainKey("Content-Type")
                .And.ContainKey("Date");

            // Cleanup
            await _federatedClaimsApi.DeleteFederatedClaimAsync(appId, claim1.Id);
            await _federatedClaimsApi.DeleteFederatedClaimAsync(appId, claim2.Id);
            await _federatedClaimsApi.DeleteFederatedClaimAsync(appId, claim3.Id);

            // Verify all deleted
            var finalList = await _federatedClaimsApi.ListFederatedClaims(appId).ToListAsync();
            finalList.Should().BeEmpty();
        }

        [Fact]
        public async Task ApplicationSSOFederatedClaimsApi_WithDifferentExpressions_WorksCorrectly()
        {
            // Arrange
            var appId = await CreateTestOidcApp();

            // Test various valid Okta Expression Language expressions
            var expressions = new Dictionary<string, string>
            {
                { "user_email", "user.profile.email" },
                { "user_name", "user.profile.firstName" },
                { "user_login", "user.profile.login" },
                { "user_mobile", "user.profile.mobilePhone" },
                { "conditional", "user.profile.email != null ? user.profile.email : user.profile.login" }
            };

            var createdClaims = new List<FederatedClaim>();

            // Create claims with different expressions
            foreach (var kvp in expressions)
            {
                var claim = await _federatedClaimsApi.CreateFederatedClaimAsync(appId, new FederatedClaimRequestBody
                {
                    Name = kvp.Key,
                    Expression = kvp.Value
                });

                claim.Should().NotBeNull();
                claim.Name.Should().Be(kvp.Key);
                claim.Expression.Should().Be(kvp.Value);
                createdClaims.Add(claim);
            }

            // Verify all created
            var allClaims = await _federatedClaimsApi.ListFederatedClaims(appId).ToListAsync();
            allClaims.Should().HaveCount(expressions.Count);

            // Verify each expression is retrievable
            foreach (var createdClaim in createdClaims)
            {
                var retrieved = await _federatedClaimsApi.GetFederatedClaimAsync(appId, createdClaim.Id);
                retrieved.Name.Should().Be(createdClaim.Name);
                retrieved.Expression.Should().Be(createdClaim.Expression);
            }

            // Cleanup
            foreach (var claim in createdClaims)
            {
                await _federatedClaimsApi.DeleteFederatedClaimAsync(appId, claim.Id);
            }
        }

        [Fact]
        public async Task ApplicationSSOFederatedClaimsApi_WithInvalidData_ThrowsBadRequest()
        {
            // Arrange
            var appId = await CreateTestOidcApp();

            // Test 1: Invalid expression syntax - malformed EL
            var invalidExpressionRequest = new FederatedClaimRequestBody
            {
                Name = "invalid_expr",
                Expression = "user.profile."  // Invalid - incomplete expression
            };

            var invalidExprException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.CreateFederatedClaimAsync(appId, invalidExpressionRequest));
            invalidExprException.ErrorCode.Should().Be(400);
            invalidExprException.Message.Should().Contain("validation failed");

            // Test 2: Empty name
            var emptyNameRequest = new FederatedClaimRequestBody
            {
                Name = "",
                Expression = "user.profile.email"
            };

            var emptyNameException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.CreateFederatedClaimAsync(appId, emptyNameRequest));
            emptyNameException.ErrorCode.Should().Be(400);

            // Test 3: Empty expression
            var emptyExprRequest = new FederatedClaimRequestBody
            {
                Name = "test",
                Expression = ""
            };

            var emptyExprException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.CreateFederatedClaimAsync(appId, emptyExprRequest));
            emptyExprException.ErrorCode.Should().Be(400);

            // Test 4: Invalid property reference

            // Note: This might not throw 400 immediately as Okta may allow references to custom attributes
            // that don't exist yet. This is expected behavior.

            // Test 5: Reserved claim names that cannot be used
            var reservedNameRequest = new FederatedClaimRequestBody
            {
                Name = "sub",  // 'sub' is a reserved OIDC claim
                Expression = "user.profile.email"
            };

            var reservedException = await Assert.ThrowsAsync<ApiException>(
                () => _federatedClaimsApi.CreateFederatedClaimAsync(appId, reservedNameRequest));
            reservedException.ErrorCode.Should().Be(400);
            reservedException.Message.Should().Contain("reserved");
        }

        [Fact]
        public async Task ApplicationSSOFederatedClaimsApi_ReplaceOperation_ValidatesTimestamps()
        {
            // Arrange
            var appId = await CreateTestOidcApp();

            // Create initial claim
            var createRequest = new FederatedClaimRequestBody
            {
                Name = "originalName",
                Expression = "user.profile.email"
            };

            var createdClaim = await _federatedClaimsApi.CreateFederatedClaimAsync(appId, createRequest);
            var originalCreated = createdClaim.Created;
            var originalLastUpdated = createdClaim.LastUpdated;

            // Wait a moment to ensure timestamp difference
            await Task.Delay(1000);

            // Replace the claim
            var replaceRequest = new FederatedClaim
            {
                Name = "updatedName",
                Expression = "user.profile.login"
            };

            var replacedClaim = await _federatedClaimsApi.ReplaceFederatedClaimAsync(appId, createdClaim.Id, replaceRequest);

            // Assert: Verify timestamp behavior
            replacedClaim.Id.Should().Be(createdClaim.Id, "ID should not change");
            replacedClaim.Created.Should().Be(originalCreated, "created timestamp should never change");
            replacedClaim.LastUpdated.Should().NotBe(originalLastUpdated, "lastUpdated should change on replace");
            
            // Parse and compare timestamps
            var createdTime = DateTime.Parse(replacedClaim.Created);
            var lastUpdatedTime = DateTime.Parse(replacedClaim.LastUpdated);
            lastUpdatedTime.Should().BeAfter(createdTime, "lastUpdated should be after created");

            // Cleanup
            await _federatedClaimsApi.DeleteFederatedClaimAsync(appId, createdClaim.Id);
        }

        [Fact]
        public async Task ApplicationSSOFederatedClaimsApi_HttpInfoResponses_ValidateHeaders()
        {
            // Arrange
            var appId = await CreateTestOidcApp();

            var claimRequest = new FederatedClaimRequestBody
            {
                Name = "headerTest",
                Expression = "user.profile.email"
            };

            // Test CREATE response headers
            var createResponse = await _federatedClaimsApi.CreateFederatedClaimWithHttpInfoAsync(appId, claimRequest);
            createResponse.StatusCode.Should().Be(HttpStatusCode.Created);
            createResponse.Headers.Should().ContainKey("Content-Type");
            createResponse.Headers["Content-Type"].Should().Contain("application/json");
            createResponse.Headers.Should().ContainKey("Date");
            createResponse.Data.Should().NotBeNull();

            var claimId = createResponse.Data.Id;

            // Test GET response headers
            var getResponse = await _federatedClaimsApi.GetFederatedClaimWithHttpInfoAsync(appId, claimId);
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.Headers.Should().ContainKey("Content-Type");
            getResponse.Headers["Content-Type"].Should().Contain("application/json");
            getResponse.Data.Should().NotBeNull();

            // Test LIST response headers
            var listResponse = await _federatedClaimsApi.ListFederatedClaimsWithHttpInfoAsync(appId);
            listResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            listResponse.Headers.Should().ContainKey("Content-Type");
            listResponse.Headers["Content-Type"].Should().Contain("application/json");
            listResponse.Data.Should().NotBeNull().And.HaveCountGreaterThan(0);

            // Test REPLACE response headers
            var replaceRequest = new FederatedClaim
            {
                Name = "headerTestUpdated",
                Expression = "user.profile.login"
            };
            var replaceResponse = await _federatedClaimsApi.ReplaceFederatedClaimWithHttpInfoAsync(appId, claimId, replaceRequest);
            replaceResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            replaceResponse.Headers.Should().ContainKey("Content-Type");
            replaceResponse.Headers["Content-Type"].Should().Contain("application/json");
            replaceResponse.Data.Should().NotBeNull();

            // Test DELETE response headers
            var deleteResponse = await _federatedClaimsApi.DeleteFederatedClaimWithHttpInfoAsync(appId, claimId);
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
            deleteResponse.Headers.Should().ContainKey("Date");
        }
    }
}
