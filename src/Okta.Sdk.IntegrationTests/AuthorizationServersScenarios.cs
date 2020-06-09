// <copyright file="AuthorizationServersScenarios.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    [Collection(nameof(AuthorizationServersScenarios))]
    public class AuthorizationServersScenarios
    {
        private const string SdkPrefix = "dotnet_sdk";

        [Fact(Skip = "OKTA-303121: Api validation failed: com.saasure.framework.exception.KeyStoreLimitExceededException (400, E0000001): Unable to create new authorization server. You cannot create authorization servers because signing keys could not be generated. To fix this issue, contact support.")]
        public async Task CreateAuthorizationServer()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";
            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);
            try
            {
                createdAuthorizationServer.Should().NotBeNull();
                createdAuthorizationServer.Name.Should().Be(testAuthorizationServerName);
                createdAuthorizationServer.Description.Should().Be("Test Authorization Server");
                createdAuthorizationServer.Audiences.Count.Should().Be(1);
                createdAuthorizationServer.Audiences[0].Should().Be("api://default");
            }
            finally
            {
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact]
        public async Task ListAuthorizationServers()
        {
            var testClient = TestClient.Create();
            // This test relies on the existence of the "default" authorization server
            var authorizationServers = await testClient.AuthorizationServers.ListAuthorizationServers().ToListAsync();
            authorizationServers.Should().NotBeNull();
            authorizationServers.Count.Should().BeGreaterThan(0);
        }

        [Fact(Skip = "OKTA-303121: Api validation failed: com.saasure.framework.exception.KeyStoreLimitExceededException (400, E0000001): Unable to create new authorization server. You cannot create authorization servers because signing keys could not be generated. To fix this issue, contact support.")]
        public async Task ListCreatedAuthorizationServer()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";
            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);
            try
            {
                var authorizationServerIds = await testClient.AuthorizationServers.ListAuthorizationServers().Select(server => server.Id).ToHashSetAsync();
                authorizationServerIds.Should().Contain(createdAuthorizationServer.Id);
            }
            finally
            {
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact]
        public async Task GetDefaultAuthorizationServer()
        {
            var testClient = TestClient.Create();
            var authorizationServers = await testClient.AuthorizationServers.ListAuthorizationServers().ToListAsync();
            authorizationServers.Should().NotBeNull();
            authorizationServers.Count.Should().BeGreaterThan(0);
            var existingAuthorizationServer = authorizationServers.FirstOrDefault(); // there should always be at least one default
            existingAuthorizationServer.Should().NotBeNull();

            var retrievedAuthorizationServer = await testClient.AuthorizationServers.GetAuthorizationServerAsync(existingAuthorizationServer.Id);

            retrievedAuthorizationServer.Should().NotBeNull();
            retrievedAuthorizationServer.Id.Should().Be(existingAuthorizationServer.Id);
            retrievedAuthorizationServer.Name.Should().Be(existingAuthorizationServer.Name);
            retrievedAuthorizationServer.Description.Should().Be(existingAuthorizationServer.Description);
        }

        [Fact(Skip = "OKTA-303121: Api validation failed: com.saasure.framework.exception.KeyStoreLimitExceededException (400, E0000001): Unable to create new authorization server. You cannot create authorization servers because signing keys could not be generated. To fix this issue, contact support.")]
        public async Task GetCreatedAuthorizationServer()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";
            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);
            try
            {
                var retrievedAuthorizationServer = await testClient.AuthorizationServers.GetAuthorizationServerAsync(createdAuthorizationServer.Id);

                retrievedAuthorizationServer.Should().NotBeNull();
                retrievedAuthorizationServer.Id.Should().Be(createdAuthorizationServer.Id);
                retrievedAuthorizationServer.Name.Should().Be(createdAuthorizationServer.Name);
                retrievedAuthorizationServer.Description.Should().Be(createdAuthorizationServer.Description);
            }
            finally
            {
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact(Skip = "OKTA-303121: Api validation failed: com.saasure.framework.exception.KeyStoreLimitExceededException (400, E0000001): Unable to create new authorization server. You cannot create authorization servers because signing keys could not be generated. To fix this issue, contact support.")]
        public async Task UpdateAuthorizationServer()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);
            try
            {
                createdAuthorizationServer.Should().NotBeNull();
                createdAuthorizationServer.Description = "Updated Test Authorization Server";
                var retrievedUpdatedAuthorizationServer = await testClient.AuthorizationServers.UpdateAuthorizationServerAsync(createdAuthorizationServer, createdAuthorizationServer.Id);

                retrievedUpdatedAuthorizationServer.Id.Should().Be(createdAuthorizationServer.Id);
                retrievedUpdatedAuthorizationServer.Description.Should().Be("Updated Test Authorization Server");
            }
            finally
            {
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact(Skip = "OKTA-303121: Api validation failed: com.saasure.framework.exception.KeyStoreLimitExceededException (400, E0000001): Unable to create new authorization server. You cannot create authorization servers because signing keys could not be generated. To fix this issue, contact support.")]
        public async Task DeleteAuthorizationServer()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);
            createdAuthorizationServer.Should().NotBeNull();
            var retrievedAuthorizationServer = await testClient.AuthorizationServers.GetAuthorizationServerAsync(createdAuthorizationServer.Id);
            retrievedAuthorizationServer.Should().NotBeNull();

            await createdAuthorizationServer.DeactivateAsync();
            await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);

            var ex = await Assert.ThrowsAsync<OktaApiException>(() => testClient.AuthorizationServers.GetAuthorizationServerAsync(createdAuthorizationServer.Id));
            ex.StatusCode.Should().Be(404);
        }

        [Fact(Skip = "OKTA-303121: Api validation failed: com.saasure.framework.exception.KeyStoreLimitExceededException (400, E0000001): Unable to create new authorization server. You cannot create authorization servers because signing keys could not be generated. To fix this issue, contact support.")]
        public async Task DeactivateAuthorizationServer()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);
            try
            {
                createdAuthorizationServer.Should().NotBeNull();
                createdAuthorizationServer.Status.Should().Be("ACTIVE");

                await testClient.AuthorizationServers.DeactivateAuthorizationServerAsync(createdAuthorizationServer.Id);

                var retrievedDeactivatedAuthorizationServer = await testClient.AuthorizationServers.GetAuthorizationServerAsync(createdAuthorizationServer.Id);
                retrievedDeactivatedAuthorizationServer.Status.Should().Be("INACTIVE");
            }
            finally
            {
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact(Skip = "OKTA-303121: Api validation failed: com.saasure.framework.exception.KeyStoreLimitExceededException (400, E0000001): Unable to create new authorization server. You cannot create authorization servers because signing keys could not be generated. To fix this issue, contact support.")]
        public async Task ActivateAuthorizationServer()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);
            try
            {
                createdAuthorizationServer.Should().NotBeNull();
                createdAuthorizationServer.Status.Should().Be("ACTIVE");

                await testClient.AuthorizationServers.DeactivateAuthorizationServerAsync(createdAuthorizationServer.Id);
                await testClient.AuthorizationServers.ActivateAuthorizationServerAsync(createdAuthorizationServer.Id);

                var retrievedDeactivatedAuthorizationServer = await testClient.AuthorizationServers.GetAuthorizationServerAsync(createdAuthorizationServer.Id);
                retrievedDeactivatedAuthorizationServer.Status.Should().Be("ACTIVE");
            }
            finally
            {
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact(Skip = "OKTA-303121: Api validation failed: com.saasure.framework.exception.KeyStoreLimitExceededException (400, E0000001): Unable to create new authorization server. You cannot create authorization servers because signing keys could not be generated. To fix this issue, contact support.")]
        public async Task ListAuthorizationServerPolicies()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };
            var testPolicy = new Policy
            {
                Type = PolicyType.OAuthAuthorizationPolicy,
                Status = "ACTIVE",
                Name = "Test Policy",
                Description = "Test policy",
                Priority = 1,
                Conditions = new PolicyRuleConditions
                {
                    Clients = new ClientPolicyCondition
                    {
                        Include = new List<string> { "ALL_CLIENTS" },
                    },
                },
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);
            var createdPolicy = await createdAuthorizationServer.CreatePolicyAsync(testPolicy);
            try
            {
                var policies = await createdAuthorizationServer.ListPolicies().ToListAsync();
                policies.Should().NotBeNull();
                policies.Count.Should().BeGreaterThan(0);
                policies.Select(p => p.Id).ToHashSet().Should().Contain(createdPolicy.Id);
            }
            finally
            {
                await createdAuthorizationServer.DeletePolicyAsync(createdPolicy.Id);
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact(Skip = "OKTA-303121: Api validation failed: com.saasure.framework.exception.KeyStoreLimitExceededException (400, E0000001): Unable to create new authorization server. You cannot create authorization servers because signing keys could not be generated. To fix this issue, contact support.")]
        public async Task GetAuthorizationServerPolicy()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };
            var testPolicy = new Policy
            {
                Type = PolicyType.OAuthAuthorizationPolicy,
                Status = "ACTIVE",
                Name = "Test Policy",
                Description = "Test policy",
                Priority = 1,
                Conditions = new PolicyRuleConditions
                {
                    Clients = new ClientPolicyCondition
                    {
                        Include = new List<string> { "ALL_CLIENTS" },
                    },
                },
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);
            var createdPolicy = await createdAuthorizationServer.CreatePolicyAsync(testPolicy);
            try
            {
                createdAuthorizationServer.Should().NotBeNull();
                createdPolicy.Should().NotBeNull();

                var retrievedPolicy = await createdAuthorizationServer.GetPolicyAsync(createdPolicy.Id);
                retrievedPolicy.Should().NotBeNull();
                retrievedPolicy.Id.Should().Be(createdPolicy.Id);
                retrievedPolicy.Name.Should().Be(createdPolicy.Name);
                retrievedPolicy.Description.Should().Be(createdPolicy.Description);
            }
            finally
            {
                await createdAuthorizationServer.DeletePolicyAsync(createdPolicy.Id);
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact(Skip = "OKTA-303121: Api validation failed: com.saasure.framework.exception.KeyStoreLimitExceededException (400, E0000001): Unable to create new authorization server. You cannot create authorization servers because signing keys could not be generated. To fix this issue, contact support.")]
        public async Task CreateAuthorizationServerPolicy()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };
            var testPolicy = new Policy
            {
                Type = PolicyType.OAuthAuthorizationPolicy,
                Status = "ACTIVE",
                Name = "Test Policy",
                Description = "Test policy",
                Priority = 1,
                Conditions = new PolicyRuleConditions
                {
                    Clients = new ClientPolicyCondition
                    {
                        Include = new List<string> { "ALL_CLIENTS" },
                    },
                },
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);
            var createdPolicy = await createdAuthorizationServer.CreatePolicyAsync(testPolicy);
            try
            {
                createdAuthorizationServer.Should().NotBeNull();
                createdPolicy.Should().NotBeNull();
                createdPolicy.Name.Should().Be(testPolicy.Name);
                createdPolicy.Description.Should().Be(testPolicy.Description);
            }
            finally
            {
                await createdAuthorizationServer.DeletePolicyAsync(createdPolicy.Id);
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact(Skip = "OKTA-303121: Api validation failed: com.saasure.framework.exception.KeyStoreLimitExceededException (400, E0000001): Unable to create new authorization server. You cannot create authorization servers because signing keys could not be generated. To fix this issue, contact support.")]
        public async Task UpdateAuthorizationServerPolicy()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };
            var testPolicy = new OAuthAuthorizationPolicy
            {
                Name = $"{SdkPrefix}:Test Policy",
                Type = PolicyType.OAuthAuthorizationPolicy,
                Status = "ACTIVE",
                Description = "Test policy",
                Priority = 1,
                Conditions = new PolicyRuleConditions
                {
                    Clients = new ClientPolicyCondition
                    {
                        Include = new List<string> { "ALL_CLIENTS" },
                    },
                },
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);

            var createdPolicy = await createdAuthorizationServer.CreatePolicyAsync(testPolicy);
            createdPolicy.Name = $"{SdkPrefix}:Test Policy Updated";
            createdPolicy.Description = "Test policy description updated";
            var updatedPolicy = await createdAuthorizationServer.UpdatePolicyAsync(createdPolicy, createdPolicy.Id);
            try
            {
                updatedPolicy.Should().NotBeNull();
                updatedPolicy.Name.Should().Be($"{SdkPrefix}:Test Policy Updated");
                updatedPolicy.Description.Should().Be("Test policy description updated");
            }
            finally
            {
                await createdAuthorizationServer.DeletePolicyAsync(createdPolicy.Id);
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact(Skip = "OKTA-303121: Api validation failed: com.saasure.framework.exception.KeyStoreLimitExceededException (400, E0000001): Unable to create new authorization server. You cannot create authorization servers because signing keys could not be generated. To fix this issue, contact support.")]
        public async Task DeleteAuthorizationServerPolicy()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };
            var testPolicy = new OAuthAuthorizationPolicy
            {
                Name = $"{SdkPrefix}:Test Policy",
                Type = PolicyType.OAuthAuthorizationPolicy,
                Status = "ACTIVE",
                Description = "Test policy",
                Priority = 1,
                Conditions = new PolicyRuleConditions
                {
                    Clients = new ClientPolicyCondition
                    {
                        Include = new List<string> { "ALL_CLIENTS" },
                    },
                },
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);
            var createdPolicy = await createdAuthorizationServer.CreatePolicyAsync(testPolicy);
            try
            {
                var retrievedAuthorizationPolicy = await testClient.AuthorizationServers.GetAuthorizationServerPolicyAsync(createdAuthorizationServer.Id, createdPolicy.Id);
                retrievedAuthorizationPolicy.Should().NotBeNull();

                await createdAuthorizationServer.DeletePolicyAsync(createdPolicy.Id);
                var ex = await Assert.ThrowsAsync<OktaApiException>(() => testClient.AuthorizationServers.GetAuthorizationServerPolicyAsync(createdAuthorizationServer.Id, createdPolicy.Id));
                ex.StatusCode.Should().Be(404);
            }
            finally
            {
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact(Skip = "OKTA-303121: Api validation failed: com.saasure.framework.exception.KeyStoreLimitExceededException (400, E0000001): Unable to create new authorization server. You cannot create authorization servers because signing keys could not be generated. To fix this issue, contact support.")]
        public async Task ListOAuth2Scopes()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };
            var testOAuthScope = new OAuth2Scope
            {
                Name = $"{SdkPrefix}:{nameof(ListOAuth2Scopes)}:TestOAuth2Scope({TestClient.RandomString(4)})",
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);
            var createdOAuthScope = await createdAuthorizationServer.CreateOAuth2ScopeAsync(testOAuthScope);
            try
            {
                var allAuthorizationServerScopes = await createdAuthorizationServer.ListOAuth2Scopes().ToListAsync();
                allAuthorizationServerScopes.Should().NotBeNull();
                allAuthorizationServerScopes.Count.Should().BeGreaterThan(0);
                allAuthorizationServerScopes.Select(scope => scope.Id).ToHashSet().Should().Contain(createdOAuthScope.Id);
            }
            finally
            {
                await createdAuthorizationServer.DeleteOAuth2ScopeAsync(createdOAuthScope.Id);
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact(Skip = "OKTA-303121: Api validation failed: com.saasure.framework.exception.KeyStoreLimitExceededException (400, E0000001): Unable to create new authorization server. You cannot create authorization servers because signing keys could not be generated. To fix this issue, contact support.")]
        public async Task GetOAuth2Scope()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };
            var testOAuthScope = new OAuth2Scope
            {
                Name = $"{SdkPrefix}:{nameof(GetOAuth2Scope)}:TestOAuth2Scope({TestClient.RandomString(4)})",
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);
            var createdOAuthScope = await createdAuthorizationServer.CreateOAuth2ScopeAsync(testOAuthScope);
            try
            {
                var retrievedOAuth2Scope = await createdAuthorizationServer.GetOAuth2ScopeAsync(createdOAuthScope.Id);
                retrievedOAuth2Scope.Should().NotBeNull();
                retrievedOAuth2Scope.Name.Should().Be(createdOAuthScope.Name);
            }
            finally
            {
                await createdAuthorizationServer.DeleteOAuth2ScopeAsync(createdOAuthScope.Id);
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact(Skip = "OKTA-303121: Api validation failed: com.saasure.framework.exception.KeyStoreLimitExceededException (400, E0000001): Unable to create new authorization server. You cannot create authorization servers because signing keys could not be generated. To fix this issue, contact support.")]
        public async Task CreateOAuth2Scope()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };
            var testOAuthScope = new OAuth2Scope
            {
                Name = $"{SdkPrefix}:{nameof(CreateOAuth2Scope)}:TestOAuth2Scope({TestClient.RandomString(4)})",
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);
            var createdOAuthScope = await createdAuthorizationServer.CreateOAuth2ScopeAsync(testOAuthScope); 
            try
            {
                createdOAuthScope.Should().NotBeNull();
                createdOAuthScope.Name.Should().Be(testOAuthScope.Name);
            }
            finally
            {
                await createdAuthorizationServer.DeleteOAuth2ScopeAsync(createdOAuthScope.Id);
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact(Skip = "OKTA-303121: Api validation failed: com.saasure.framework.exception.KeyStoreLimitExceededException (400, E0000001): Unable to create new authorization server. You cannot create authorization servers because signing keys could not be generated. To fix this issue, contact support.")]
        public async Task UpdateOAuth2Scope()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };
            var testOAuthScope = new OAuth2Scope
            {
                Name = $"{SdkPrefix}:{nameof(UpdateOAuth2Scope)}:TestOAuth2Scope({TestClient.RandomString(4)})",
                Consent = "REQUIRED",
                MetadataPublish = "ALL_CLIENTS",
            };
            var testUpdatedOAuthScope = new OAuth2Scope
            {
                Name = $"{SdkPrefix}:{nameof(UpdateOAuth2Scope)}:TestOAuth2Scope_Updated({TestClient.RandomString(4)})",
                Consent = "REQUIRED",
                MetadataPublish = "ALL_CLIENTS",
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);
            var createdOAuthScope = await createdAuthorizationServer.CreateOAuth2ScopeAsync(testOAuthScope);
            try
            {
                createdOAuthScope.Should().NotBeNull();
                createdOAuthScope.Name.Should().Be(testOAuthScope.Name);
                var updatedOAuthScope = await createdAuthorizationServer.UpdateOAuth2ScopeAsync(testUpdatedOAuthScope, createdOAuthScope.Id);
                updatedOAuthScope.Should().NotBeNull();
                updatedOAuthScope.Name.Should().Be(testUpdatedOAuthScope.Name);
            }
            finally
            {
                await createdAuthorizationServer.DeleteOAuth2ScopeAsync(createdOAuthScope.Id);
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact(Skip = "OKTA-303121: Api validation failed: com.saasure.framework.exception.KeyStoreLimitExceededException (400, E0000001): Unable to create new authorization server. You cannot create authorization servers because signing keys could not be generated. To fix this issue, contact support.")]
        public async Task DeleteOAuth2Scope()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };
            var testOAuthScope = new OAuth2Scope
            {
                Name = $"{SdkPrefix}:{nameof(DeleteOAuth2Scope)}:TestOAuth2Scope({TestClient.RandomString(4)})",
                Consent = "REQUIRED",
                MetadataPublish = "ALL_CLIENTS",
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);
            var createdOAuthScope = await createdAuthorizationServer.CreateOAuth2ScopeAsync(testOAuthScope);
            try
            {
                createdAuthorizationServer.Should().NotBeNull();
                createdOAuthScope.Should().NotBeNull();

                var retrievedOAuthScope = await testClient.AuthorizationServers.GetOAuth2ScopeAsync(createdAuthorizationServer.Id, createdOAuthScope.Id);
                retrievedOAuthScope.Should().NotBeNull();

                await testClient.AuthorizationServers.DeleteOAuth2ScopeAsync(createdAuthorizationServer.Id, createdOAuthScope.Id);
                var ex = await Assert.ThrowsAsync<OktaApiException>(() => testClient.AuthorizationServers.GetOAuth2ScopeAsync(createdAuthorizationServer.Id, createdOAuthScope.Id));
                ex.StatusCode.Should().Be(404);
            }
            finally
            {
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact(Skip = "OKTA-303121: Api validation failed: com.saasure.framework.exception.KeyStoreLimitExceededException (400, E0000001): Unable to create new authorization server. You cannot create authorization servers because signing keys could not be generated. To fix this issue, contact support.")]
        public async Task ListOAuth2Claims()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };
            var testOAuthClaim = new OAuth2Claim
            {
                Name = $"{SdkPrefix}_{nameof(ListOAuth2Claims)}_TestOAuth2Claim_{TestClient.RandomString(4)}",
                Status = "INACTIVE",
                ClaimType = "RESOURCE",
                ValueType = "EXPRESSION",
                Value = "\"driving!\"",
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);
            var createdOAuthClaim = await createdAuthorizationServer.CreateOAuth2ClaimAsync(testOAuthClaim);
            try
            {
                var allAuthorizationServerClaims = await testClient.AuthorizationServers.ListOAuth2Claims(createdAuthorizationServer.Id).ToListAsync();
                allAuthorizationServerClaims.Should().NotBeNull();
                allAuthorizationServerClaims.Count.Should().BeGreaterThan(0);
                allAuthorizationServerClaims.Select(claim => claim.Id).ToHashSet().Should().Contain(createdOAuthClaim.Id);
            }
            finally
            {
                await createdAuthorizationServer.DeleteOAuth2ClaimAsync(createdOAuthClaim.Id);
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact(Skip = "OKTA-303121: Api validation failed: com.saasure.framework.exception.KeyStoreLimitExceededException (400, E0000001): Unable to create new authorization server. You cannot create authorization servers because signing keys could not be generated. To fix this issue, contact support.")]
        public async Task GetOAuth2Claim()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };
            var testOAuthClaim = new OAuth2Claim
            {
                Name = $"{SdkPrefix}_{nameof(GetOAuth2Claim)}_TestOAuth2Claim_{TestClient.RandomString(4)}",
                Status = "INACTIVE",
                ClaimType = "RESOURCE",
                ValueType = "EXPRESSION",
                Value = "\"driving!\"",
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);
            var createdOAuthClaim = await createdAuthorizationServer.CreateOAuth2ClaimAsync(testOAuthClaim);
            try
            {
                var retrievedOAuth2Claim = await testClient.AuthorizationServers.GetOAuth2ClaimAsync(createdAuthorizationServer.Id, createdOAuthClaim.Id);
                retrievedOAuth2Claim.Should().NotBeNull();
                retrievedOAuth2Claim.Name.Should().Be(createdOAuthClaim.Name);
            }
            finally
            {
                await createdAuthorizationServer.DeleteOAuth2ClaimAsync(createdOAuthClaim.Id);
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact(Skip = "OKTA-303121: Api validation failed: com.saasure.framework.exception.KeyStoreLimitExceededException (400, E0000001): Unable to create new authorization server. You cannot create authorization servers because signing keys could not be generated. To fix this issue, contact support.")]
        public async Task CreateOAuth2Claim()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };
            var testOAuthClaim = new OAuth2Claim
            {
                Name = $"{SdkPrefix}_{nameof(CreateOAuth2Claim)}_TestOAuth2Claim_{TestClient.RandomString(4)}",
                Status = "INACTIVE",
                ClaimType = "RESOURCE",
                ValueType = "EXPRESSION",
                Value = "\"driving!\"",
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);
            var createdOAuthClaim = await createdAuthorizationServer.CreateOAuth2ClaimAsync(testOAuthClaim);
            try
            {
                createdOAuthClaim.Should().NotBeNull();
                createdOAuthClaim.Name.Should().Be(testOAuthClaim.Name);
            }
            finally
            {
                await createdAuthorizationServer.DeleteOAuth2ClaimAsync(createdOAuthClaim.Id);
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact(Skip = "OKTA-303121: Api validation failed: com.saasure.framework.exception.KeyStoreLimitExceededException (400, E0000001): Unable to create new authorization server. You cannot create authorization servers because signing keys could not be generated. To fix this issue, contact support.")]
        public async Task UpdateOAuth2Claim()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };
            var testOAuthClaim = new OAuth2Claim
            {
                Name = $"{SdkPrefix}_{nameof(UpdateOAuth2Claim)}_TestOAuth2Claim_{TestClient.RandomString(4)}",
                Status = "INACTIVE",
                ClaimType = "RESOURCE",
                ValueType = "EXPRESSION",
                Value = "\"driving!\"",
            };
            var testUpdatedOAuthClaim = new OAuth2Claim
            {
                Name = $"{SdkPrefix}_{nameof(UpdateOAuth2Claim)}_TestOAuth2Claim_Updated_{TestClient.RandomString(4)}",
                Status = "INACTIVE",
                ClaimType = "RESOURCE",
                ValueType = "EXPRESSION",
                Value = "\"driving!\"",
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);
            var createdOAuthClaim = await createdAuthorizationServer.CreateOAuth2ClaimAsync(testOAuthClaim);
            try
            {
                createdAuthorizationServer.Should().NotBeNull();
                createdOAuthClaim.Should().NotBeNull();
                createdOAuthClaim.Name.Should().Be(testOAuthClaim.Name);
                var updatedOAuthScope = await createdAuthorizationServer.UpdateOAuth2ClaimAsync(testUpdatedOAuthClaim, createdOAuthClaim.Id);
                updatedOAuthScope.Should().NotBeNull();
                updatedOAuthScope.Name.Should().Be(testUpdatedOAuthClaim.Name);
            }
            finally
            {
                await createdAuthorizationServer.DeleteOAuth2ClaimAsync(createdOAuthClaim.Id);
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact(Skip = "OKTA-303121: Api validation failed: com.saasure.framework.exception.KeyStoreLimitExceededException (400, E0000001): Unable to create new authorization server. You cannot create authorization servers because signing keys could not be generated. To fix this issue, contact support.")]
        public async Task DeleteOAuth2Claim()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };
            var testOAuthClaim = new OAuth2Claim
            {
                Name = $"{SdkPrefix}_{nameof(DeleteOAuth2Claim)}_TestOAuth2Claim{TestClient.RandomString(4)}",
                Status = "INACTIVE",
                ClaimType = "RESOURCE",
                ValueType = "EXPRESSION",
                Value = "\"driving!\"",
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);
            var createdOAuthClaim = await createdAuthorizationServer.CreateOAuth2ClaimAsync(testOAuthClaim);
            try
            {
                createdAuthorizationServer.Should().NotBeNull();
                createdOAuthClaim.Should().NotBeNull();

                var retrievedOAuthScope = await createdAuthorizationServer.GetOAuth2ClaimAsync(createdOAuthClaim.Id);
                retrievedOAuthScope.Should().NotBeNull();

                await createdAuthorizationServer.DeleteOAuth2ClaimAsync(createdOAuthClaim.Id);
                var ex = await Assert.ThrowsAsync<OktaApiException>(() => testClient.AuthorizationServers.GetOAuth2ClaimAsync(createdAuthorizationServer.Id, createdOAuthClaim.Id));
                ex.StatusCode.Should().Be(404);
            }
            finally
            {
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact(Skip = "OKTA-303121: Api validation failed: com.saasure.framework.exception.KeyStoreLimitExceededException (400, E0000001): Unable to create new authorization server. You cannot create authorization servers because signing keys could not be generated. To fix this issue, contact support.")]
        public async Task ListAuthorizationServerKeys()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);
            try
            {
                var authorizationServerKeys = await createdAuthorizationServer.ListKeys().ToListAsync();
                authorizationServerKeys.Should().NotBeNull();
                authorizationServerKeys.Count.Should().BeGreaterThan(0);
            }
            finally
            {
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact(Skip = "ICollectionClient doesn't support POST - OKTA-302822")]
        public async Task RotateAuthorizationServerKeys()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);

            try
            {
                var keys = await createdAuthorizationServer.RotateKeys(new JwkUse()).ToListAsync();
                keys.Should().NotBeNull();
                keys.Count.Should().BeGreaterThan(0);
            }
            finally
            {
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }
    }
}
