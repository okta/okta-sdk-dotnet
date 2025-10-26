using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for ApplicationPoliciesApi
    /// Tests authentication policy assignment to applications
    /// </summary>
    public class ApplicationPoliciesApiTests : IAsyncLifetime
    {
        private ApplicationApi _applicationApi;
        private ApplicationPoliciesApi _applicationPoliciesApi;
        private PolicyApi _policyApi;
        private string _testAppId;
        private string _testPolicyId;

        public async Task InitializeAsync()
        {
            _applicationApi = new ApplicationApi();
            _applicationPoliciesApi = new ApplicationPoliciesApi();
            _policyApi = new PolicyApi();

            // Create a test application (OIDC Web App)
            var guid = Guid.NewGuid();
            var testApp = new OpenIdConnectApplication
            {
                Name = "oidc_client",
                Label = $"Test App for Policy {guid}",
                SignOnMode = "OPENID_CONNECT",
                Credentials = new OAuthApplicationCredentials
                {
                    OauthClient = new ApplicationCredentialsOAuthClient
                    {
                        ClientId = $"test-policy-app-{guid}",
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
                        PostLogoutRedirectUris = ["https://example.com/postlogout"],
                        ResponseTypes = [OAuthResponseType.Code],
                        GrantTypes = [GrantType.AuthorizationCode],
                        ApplicationType = OpenIdConnectApplicationType.Web,
                        RedirectUris = ["https://example.com/oauth/callback"]
                    }
                }
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(testApp);
            _testAppId = createdApp.Id;

            // Create a test authentication policy
            var testPolicy = new CreateOrUpdatePolicy
            {
                Type = PolicyType.ACCESSPOLICY,
                Status = LifecycleStatus.ACTIVE,
                Name = $"Test Auth Policy {Guid.NewGuid()}",
                Description = "Test policy for ApplicationPoliciesApi integration tests"
            };

            var createdPolicy = await _policyApi.CreatePolicyAsync(testPolicy, activate: true);
            _testPolicyId = createdPolicy.Id;

            await Task.Delay(3000); // Wait for resources to be ready
        }

        public async Task DisposeAsync()
        {
            // Cleanup application
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

            // Cleanup policy
            if (!string.IsNullOrEmpty(_testPolicyId))
            {
                try
                {
                    await _policyApi.DeactivatePolicyAsync(_testPolicyId);
                    await _policyApi.DeletePolicyAsync(_testPolicyId);
                }
                catch
                {
                    // Best effort cleanup
                }
            }
        }

        [Fact]
        public async Task Should_AssignApplicationPolicy()
        {
            // Act
            await _applicationPoliciesApi.AssignApplicationPolicyAsync(_testAppId, _testPolicyId);

            await Task.Delay(1000);

            // Assert - Verify the assignment by checking the application's access policy link
            var app = await _applicationApi.GetApplicationAsync(_testAppId);
            app.Should().NotBeNull();
            app.Id.Should().Be(_testAppId);
            app.Links.Should().NotBeNull();
            
            // Verify that the access policy link is present after assignment
            app.Links.AccessPolicy.Should().NotBeNull("application should have access policy link after assignment");
            app.Links.AccessPolicy.Href.Should().NotBeNullOrEmpty("access policy link should have href");
            app.Links.AccessPolicy.Href.Should().Contain(_testPolicyId, "access policy link should reference the assigned policy");
        }

        [Fact]
        public async Task Should_AssignApplicationPolicy_WithHttpInfo()
        {
            // Act
            var response = await _applicationPoliciesApi.AssignApplicationPolicyWithHttpInfoAsync(_testAppId, _testPolicyId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task Should_ReplaceExistingPolicy_WhenAssigningNewPolicy()
        {
            // Arrange - Create second policy
            var secondPolicy = new CreateOrUpdatePolicy
            {
                Type = PolicyType.ACCESSPOLICY,
                Status = LifecycleStatus.ACTIVE,
                Name = $"Test Auth Policy 2 {Guid.NewGuid()}",
                Description = "Second test policy"
            };

            var createdSecondPolicy = await _policyApi.CreatePolicyAsync(secondPolicy, activate: true);
            var secondPolicyId = createdSecondPolicy.Id;

            try
            {
                await Task.Delay(2000);

                // Assign first policy
                await _applicationPoliciesApi.AssignApplicationPolicyAsync(_testAppId, _testPolicyId);
                await Task.Delay(1000);

                // Verify the first policy is assigned
                var appAfterFirstAssignment = await _applicationApi.GetApplicationAsync(_testAppId);
                appAfterFirstAssignment.Links.AccessPolicy.Should().NotBeNull();
                appAfterFirstAssignment.Links.AccessPolicy.Href.Should().Contain(_testPolicyId, "first policy should be assigned");

                // Act - Assign second policy (should replace first)
                await _applicationPoliciesApi.AssignApplicationPolicyAsync(_testAppId, secondPolicyId);
                await Task.Delay(1000);

                // Assert - Verify second policy replaced the first
                var app = await _applicationApi.GetApplicationAsync(_testAppId);
                app.Should().NotBeNull();
                app.Id.Should().Be(_testAppId);
                app.Links.AccessPolicy.Should().NotBeNull("application should have access policy link");
                app.Links.AccessPolicy.Href.Should().Contain(secondPolicyId, "second policy should replace first policy");
                app.Links.AccessPolicy.Href.Should().NotContain(_testPolicyId, "first policy should no longer be assigned");
            }
            finally
            {
                // Cleanup second policy
                try
                {
                    await _policyApi.DeactivatePolicyAsync(secondPolicyId);
                    await _policyApi.DeletePolicyAsync(secondPolicyId);
                }
                catch
                {
                    // Best effort cleanup
                }
            }
        }

        [Fact]
        public async Task Should_ThrowException_ForNonExistentApp()
        {
            // Arrange
            var nonExistentAppId = "nonexistent123";

            // Act & Assert
            Func<Task> act = async () => await _applicationPoliciesApi.AssignApplicationPolicyAsync(nonExistentAppId, _testPolicyId);
            
            await act.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404);
        }

        [Fact]
        public async Task Should_ThrowException_ForNonExistentPolicy()
        {
            // Arrange
            var nonExistentPolicyId = "nonexistent456";

            // Act & Assert
            Func<Task> act = async () => await _applicationPoliciesApi.AssignApplicationPolicyAsync(_testAppId, nonExistentPolicyId);
            
            await act.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404);
        }

        [Fact]
        public async Task Should_HandleMultiplePolicyAssignments()
        {
            // Act - Assign policy multiple times (should be idempotent)
            await _applicationPoliciesApi.AssignApplicationPolicyAsync(_testAppId, _testPolicyId);
            await Task.Delay(500);
            
            await _applicationPoliciesApi.AssignApplicationPolicyAsync(_testAppId, _testPolicyId);
            await Task.Delay(500);
            
            await _applicationPoliciesApi.AssignApplicationPolicyAsync(_testAppId, _testPolicyId);
            await Task.Delay(500);

            // Assert - Verify app is still accessible and policy is assigned
            var app = await _applicationApi.GetApplicationAsync(_testAppId);
            app.Should().NotBeNull();
            app.Id.Should().Be(_testAppId);
            
            // Verify the policy is still correctly assigned after multiple operations
            app.Links.AccessPolicy.Should().NotBeNull("policy should remain assigned after multiple assignment calls");
            app.Links.AccessPolicy.Href.Should().Contain(_testPolicyId, "same policy should still be assigned");
        }

        [Fact]
        public async Task Should_AssignPolicy_ToDifferentApplicationTypes()
        {
            // Arrange - Create a SAML application
            var samlApp = new SamlApplication
            {
                Label = $"Test SAML App for Policy {Guid.NewGuid()}",
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

                // Act - Assign policy to SAML app
                await _applicationPoliciesApi.AssignApplicationPolicyAsync(samlAppId, _testPolicyId);
                await Task.Delay(1000);

                // Assert - Verify policy is assigned to SAML application
                var app = await _applicationApi.GetApplicationAsync(samlAppId);
                app.Should().NotBeNull();
                app.Id.Should().Be(samlAppId);
                app.Links.AccessPolicy.Should().NotBeNull("SAML app should have access policy link after assignment");
                app.Links.AccessPolicy.Href.Should().Contain(_testPolicyId, "policy should be assigned to SAML app");
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

        [Fact]
        public async Task Should_AssignPolicy_ToMultipleApplications()
        {
            // Arrange - Create second application
            var guid = Guid.NewGuid();
            var secondApp = new OpenIdConnectApplication
            {
                Name = "oidc_client",
                Label = $"Test App 2 for Policy {guid}",
                SignOnMode = "OPENID_CONNECT",
                Credentials = new OAuthApplicationCredentials
                {
                    OauthClient = new ApplicationCredentialsOAuthClient
                    {
                        ClientId = $"test-policy-app2-{guid}",
                        TokenEndpointAuthMethod = OAuthEndpointAuthenticationMethod.ClientSecretBasic,
                        AutoKeyRotation = true
                    }
                },
                Settings = new OpenIdConnectApplicationSettings
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient
                    {
                        ClientUri = "https://example2.com",
                        LogoUri = "https://example2.com/logo.png",
                        PostLogoutRedirectUris = ["https://example2.com/postlogout"],
                        ResponseTypes = [OAuthResponseType.Code],
                        GrantTypes = [GrantType.AuthorizationCode],
                        ApplicationType = OpenIdConnectApplicationType.Web,
                        RedirectUris = ["https://example2.com/oauth/callback"]
                    }
                }
            };

            var createdSecondApp = await _applicationApi.CreateApplicationAsync(secondApp);
            var secondAppId = createdSecondApp.Id;

            try
            {
                await Task.Delay(2000);

                // Act - Assign same policy to both applications
                await _applicationPoliciesApi.AssignApplicationPolicyAsync(_testAppId, _testPolicyId);
                await Task.Delay(500);
                await _applicationPoliciesApi.AssignApplicationPolicyAsync(secondAppId, _testPolicyId);
                await Task.Delay(1000);

                // Assert - Verify both apps have the policy assigned
                var app1 = await _applicationApi.GetApplicationAsync(_testAppId);
                var app2 = await _applicationApi.GetApplicationAsync(secondAppId);

                app1.Should().NotBeNull();
                app1.Id.Should().Be(_testAppId);
                app1.Links.AccessPolicy.Should().NotBeNull("first app should have access policy link");
                app1.Links.AccessPolicy.Href.Should().Contain(_testPolicyId, "first app should have policy assigned");

                app2.Should().NotBeNull();
                app2.Id.Should().Be(secondAppId);
                app2.Links.AccessPolicy.Should().NotBeNull("second app should have access policy link");
                app2.Links.AccessPolicy.Href.Should().Contain(_testPolicyId, "second app should have policy assigned");
            }
            finally
            {
                // Cleanup
                try
                {
                    await _applicationApi.DeactivateApplicationAsync(secondAppId);
                    await _applicationApi.DeleteApplicationAsync(secondAppId);
                }
                catch
                {
                    // Best effort cleanup
                }
            }
        }
    }
}
