using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for ApplicationGrantsApi
    /// Tests OAuth 2.0 scope consent grant operations for applications
    /// </summary>
    public class ApplicationGrantsApiTests : IAsyncLifetime
    {
        private ApplicationApi _applicationApi;
        private ApplicationGrantsApi _applicationGrantsApi;
        private string _testAppId;
        private string _testGrantId;

        public async Task InitializeAsync()
        {
            _applicationApi = new ApplicationApi();
            _applicationGrantsApi = new ApplicationGrantsApi();

            // Create a test OAuth application
            var guid = Guid.NewGuid();
            var testApp = new OpenIdConnectApplication
            {
                Name = "oidc_client",
                Label = $"Test App for Grants {guid}",
                SignOnMode = "OPENID_CONNECT",
                Credentials = new OAuthApplicationCredentials
                {
                    OauthClient = new ApplicationCredentialsOAuthClient
                    {
                        ClientId = $"test-grants-client-{guid}",
                        TokenEndpointAuthMethod = OAuthEndpointAuthenticationMethod.ClientSecretBasic,
                        AutoKeyRotation = true
                    }
                },
                Settings = new OpenIdConnectApplicationSettings
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient
                    {
                        ClientUri = "https://example.com",
                        LogoUri = "https://example.com/logo.png",
                        RedirectUris = new System.Collections.Generic.List<string> { "https://example.com/oauth/callback" },
                        PostLogoutRedirectUris = new System.Collections.Generic.List<string> { "https://example.com/postlogout" },
                        ResponseTypes = new System.Collections.Generic.List<OAuthResponseType> { OAuthResponseType.Code },
                        GrantTypes = new System.Collections.Generic.List<GrantType> { GrantType.AuthorizationCode },
                        ApplicationType = OpenIdConnectApplicationType.Web
                    }
                }
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(testApp);
            _testAppId = createdApp.Id;

            // Give the app time to be fully created
            await Task.Delay(2000);
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

        [Fact]
        public async Task Should_GrantConsentToScope_And_RetrieveGrant()
        {
            // Arrange & Act
            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;
            var issuer = oktaDomain.EndsWith("/") ? oktaDomain.Substring(0, oktaDomain.Length - 1) : oktaDomain;
            
            var grantRequest = new OAuth2ScopeConsentGrant
            {
                ScopeId = "okta.users.read",
                Issuer = issuer,
            };

            var createdGrant = await _applicationGrantsApi.GrantConsentToScopeAsync(_testAppId, grantRequest);
            _testGrantId = createdGrant.Id;

            // Assert - Validate all critical fields in created grant
            createdGrant.Should().NotBeNull();
            createdGrant.Id.Should().NotBeNullOrEmpty();
            createdGrant.ScopeId.Should().Be("okta.users.read");
            createdGrant.Issuer.Should().Be(issuer);
            createdGrant.Status.Should().Be(GrantOrTokenStatus.ACTIVE);
            createdGrant.Source.Should().Be(OAuth2ScopeConsentGrantSource.ADMIN, "grants created via API have ADMIN source");
            createdGrant.Created.Should().NotBe(default(DateTimeOffset));
            createdGrant.CreatedBy.Should().NotBeNull();
            createdGrant.LastUpdated.Should().NotBe(default(DateTimeOffset));
            createdGrant.Links.Should().NotBeNull();

            await Task.Delay(1000);

            // Act - Retrieve the specific grant
            var retrievedGrant = await _applicationGrantsApi.GetScopeConsentGrantAsync(_testAppId, _testGrantId);

            // Assert - Verify retrieved grant matches created grant exactly
            retrievedGrant.Should().NotBeNull();
            retrievedGrant.Id.Should().Be(_testGrantId);
            retrievedGrant.ScopeId.Should().Be("okta.users.read");
            retrievedGrant.Issuer.Should().Be(issuer);
            retrievedGrant.Status.Should().Be(GrantOrTokenStatus.ACTIVE);
            retrievedGrant.Source.Should().Be(createdGrant.Source);
        }

        [Fact]
        public async Task Should_ListScopeConsentGrants()
        {
            // Arrange - Create a grant
            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;
            var issuer = oktaDomain.EndsWith("/") ? oktaDomain.Substring(0, oktaDomain.Length - 1) : oktaDomain;
            
            var grantRequest = new OAuth2ScopeConsentGrant
            {
                Issuer = issuer,
                ScopeId = "okta.users.read",
                Status = GrantOrTokenStatus.ACTIVE
            };

            var createdGrant = await _applicationGrantsApi.GrantConsentToScopeAsync(_testAppId, grantRequest);
            _testGrantId = createdGrant.Id;

            await Task.Delay(1000); // Wait for consistency

            // Act - List all grants for the app
            var grants = await _applicationGrantsApi.ListScopeConsentGrantsWithHttpInfoAsync(_testAppId);

            // Assert - Validate response structure and data
            grants.Should().NotBeNull();
            grants.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            grants.Data.Should().NotBeNull();
            grants.Data.Should().HaveCountGreaterThanOrEqualTo(1);
            
            var matchingGrant = grants.Data.FirstOrDefault(g => g.Id == _testGrantId);
            matchingGrant.Should().NotBeNull();
            matchingGrant.ScopeId.Should().Be("okta.users.read");
            matchingGrant.Issuer.Should().Be(issuer);
            matchingGrant.Status.Should().Be(GrantOrTokenStatus.ACTIVE);
        }

        [Fact]
        public async Task Should_ListScopeConsentGrants_WithExpandParameter()
        {
            // Arrange - Create a grant
            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;
            var issuer = oktaDomain.EndsWith("/") ? oktaDomain.Substring(0, oktaDomain.Length - 1) : oktaDomain;
            
            var grantRequest = new OAuth2ScopeConsentGrant
            {
                Issuer = issuer,
                ScopeId = "okta.users.read",
                Status = GrantOrTokenStatus.ACTIVE
            };

            var createdGrant = await _applicationGrantsApi.GrantConsentToScopeAsync(_testAppId, grantRequest);
            _testGrantId = createdGrant.Id;

            await Task.Delay(1000);

            // Act - List grants with expand parameter
            var grants = await _applicationGrantsApi.ListScopeConsentGrantsWithHttpInfoAsync(_testAppId, expand: "scope");

            // Assert
            grants.Should().NotBeNull();
            grants.Data.Should().NotBeNull();
            grants.Data.Should().HaveCountGreaterThanOrEqualTo(1);
        }

        [Fact]
        public async Task Should_GetScopeConsentGrant_WithExpandParameter()
        {
            // Arrange - Create a grant
            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;
            var issuer = oktaDomain.EndsWith("/") ? oktaDomain.Substring(0, oktaDomain.Length - 1) : oktaDomain;
            
            var grantRequest = new OAuth2ScopeConsentGrant
            {
                Issuer = issuer,
                ScopeId = "okta.users.read",
                Status = GrantOrTokenStatus.ACTIVE
            };

            var createdGrant = await _applicationGrantsApi.GrantConsentToScopeAsync(_testAppId, grantRequest);
            _testGrantId = createdGrant.Id;

            await Task.Delay(1000);

            // Act - Get grant with expand parameter
            var grant = await _applicationGrantsApi.GetScopeConsentGrantAsync(_testAppId, _testGrantId, expand: "scope");

            // Assert
            grant.Should().NotBeNull();
            grant.Id.Should().Be(_testGrantId);
            grant.ScopeId.Should().Be("okta.users.read");
        }

        [Fact]
        public async Task Should_RevokeScopeConsentGrant()
        {
            // Arrange - Create a grant
            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;
            var issuer = oktaDomain.EndsWith("/") ? oktaDomain.Substring(0, oktaDomain.Length - 1) : oktaDomain;
            
            var grantRequest = new OAuth2ScopeConsentGrant
            {
                Issuer = issuer,
                ScopeId = "okta.users.read",
                Status = GrantOrTokenStatus.ACTIVE
            };

            var createdGrant = await _applicationGrantsApi.GrantConsentToScopeAsync(_testAppId, grantRequest);
            _testGrantId = createdGrant.Id;

            await Task.Delay(1000);

            // Act - Revoke the grant
            await _applicationGrantsApi.RevokeScopeConsentGrantAsync(_testAppId, _testGrantId);

            await Task.Delay(1000);

            // Assert - Verify grant is revoked (should throw 404)
            Func<Task> act = async () => await _applicationGrantsApi.GetScopeConsentGrantAsync(_testAppId, _testGrantId);
            await act.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404);
        }

        [Fact]
        public async Task Should_GrantConsentToScope_WithHttpInfo()
        {
            // Arrange
            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;
            var issuer = oktaDomain.EndsWith("/") ? oktaDomain.Substring(0, oktaDomain.Length - 1) : oktaDomain;
            
            var grantRequest = new OAuth2ScopeConsentGrant
            {
                Issuer = issuer,
                ScopeId = "okta.users.read",
                Status = GrantOrTokenStatus.ACTIVE
            };

            // Act
            var response = await _applicationGrantsApi.GrantConsentToScopeWithHttpInfoAsync(_testAppId, grantRequest);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().NotBeNullOrEmpty();
            response.Data.ScopeId.Should().Be("okta.users.read");

            _testGrantId = response.Data.Id;
        }

        [Fact]
        public async Task Should_GetScopeConsentGrant_WithHttpInfo()
        {
            // Arrange - Create a grant
            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;
            var issuer = oktaDomain.EndsWith("/") ? oktaDomain.Substring(0, oktaDomain.Length - 1) : oktaDomain;
            
            var grantRequest = new OAuth2ScopeConsentGrant
            {
                Issuer = issuer,
                ScopeId = "okta.users.read",
                Status = GrantOrTokenStatus.ACTIVE
            };

            var createdGrant = await _applicationGrantsApi.GrantConsentToScopeAsync(_testAppId, grantRequest);
            _testGrantId = createdGrant.Id;

            await Task.Delay(1000);

            // Act
            var response = await _applicationGrantsApi.GetScopeConsentGrantWithHttpInfoAsync(_testAppId, _testGrantId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_testGrantId);
        }

        [Fact]
        public async Task Should_RevokeScopeConsentGrant_WithHttpInfo()
        {
            // Arrange - Create a grant
            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;
            var issuer = oktaDomain.EndsWith("/") ? oktaDomain.Substring(0, oktaDomain.Length - 1) : oktaDomain;
            
            var grantRequest = new OAuth2ScopeConsentGrant
            {
                Issuer = issuer,
                ScopeId = "okta.users.read",
                Status = GrantOrTokenStatus.ACTIVE
            };

            var createdGrant = await _applicationGrantsApi.GrantConsentToScopeAsync(_testAppId, grantRequest);
            _testGrantId = createdGrant.Id;

            await Task.Delay(1000);

            // Act
            var response = await _applicationGrantsApi.RevokeScopeConsentGrantWithHttpInfoAsync(_testAppId, _testGrantId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }
    }
}
