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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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
            var testPolicy = new AuthorizationServerPolicy
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

        [Fact]
        public async Task ListAuthorizationServerPolicyRules()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };
            var testPolicy = new AuthorizationServerPolicy
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
                var policy = await createdAuthorizationServer.GetPolicyAsync(createdPolicy.Id);
                policy.Should().NotBeNull();

                var policyRule = new AuthorizationServerPolicyRule
                {
                    Name = $"{SdkPrefix}:{nameof(ListAuthorizationServerPolicyRules)}",
                    Type = "RESOURCE_ACCESS",
                    Priority = 1,
                    Conditions = new AuthorizationServerPolicyRuleConditions
                    {
                        People = new PolicyPeopleCondition
                        {
                            Groups = new GroupCondition
                            {
                                Include = new List<string>() { "EVERYONE" },
                            },
                        },
                        GrantTypes = new GrantTypePolicyRuleCondition
                        {
                            Include = new List<string>() { "implicit", "client_credentials", "authorization_code", "password" },
                        },
                        Scopes = new OAuth2ScopesMediationPolicyRuleCondition
                        {
                            Include = new List<string>() { "openid", "email", "address" },
                        },
                    },
                    Actions = new AuthorizationServerPolicyRuleActions
                    {
                        Token = new TokenAuthorizationServerPolicyRuleAction
                        {
                            AccessTokenLifetimeMinutes = 60,
                            RefreshTokenLifetimeMinutes = 0,
                            RefreshTokenWindowMinutes = 10080,
                        },
                    },
                };

                var createdPolicyRule = await testClient.AuthorizationServers.CreateAuthorizationServerPolicyRuleAsync(policyRule, createdPolicy.Id, createdAuthorizationServer.Id);

                var rules = await testClient.AuthorizationServers.ListAuthorizationServerPolicyRules(createdPolicy.Id, createdAuthorizationServer.Id).ToListAsync();

                rules.Should().NotBeNull();
                rules.FirstOrDefault(x => x.Name == policyRule.Name).Should().NotBeNull();
            }
            finally
            {
                await createdAuthorizationServer.DeletePolicyAsync(createdPolicy.Id);
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact]
        public async Task CreateAuthorizationServerPolicyRule()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };
            var testPolicy = new AuthorizationServerPolicy
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
                var policy = await createdAuthorizationServer.GetPolicyAsync(createdPolicy.Id);
                policy.Should().NotBeNull();

                var policyRule = new AuthorizationServerPolicyRule
                {
                    Name = $"{SdkPrefix}:{nameof(CreateAuthorizationServerPolicyRule)}",
                    Type = "RESOURCE_ACCESS",
                    Priority = 1,
                    Conditions = new AuthorizationServerPolicyRuleConditions
                    {
                        People = new PolicyPeopleCondition
                        {
                            Groups = new GroupCondition
                            {
                                Include = new List<string>() { "EVERYONE" },
                            },
                        },
                        GrantTypes = new GrantTypePolicyRuleCondition
                        {
                            Include = new List<string>() { "implicit", "client_credentials", "authorization_code", "password" },
                        },
                        Scopes = new OAuth2ScopesMediationPolicyRuleCondition
                        {
                            Include = new List<string>() { "openid", "email", "address" },
                        },
                    },
                    Actions = new AuthorizationServerPolicyRuleActions
                    {
                        Token = new TokenAuthorizationServerPolicyRuleAction
                        {
                            AccessTokenLifetimeMinutes = 60,
                            RefreshTokenLifetimeMinutes = 0,
                            RefreshTokenWindowMinutes = 10080,
                        },
                    },
                };

                var createdPolicyRule = await testClient.AuthorizationServers.CreateAuthorizationServerPolicyRuleAsync(policyRule, createdPolicy.Id, createdAuthorizationServer.Id);
                createdPolicyRule.Should().NotBeNull();
                createdPolicyRule.Name.Should().Be(policyRule.Name);
                createdPolicyRule.Type.Should().Be("RESOURCE_ACCESS");
                createdPolicyRule.Priority.Should().Be(1);
                createdPolicyRule.Conditions.People.Groups.Include.Should().Contain("EVERYONE");
                createdPolicyRule.Conditions.GrantTypes.Include.Should().Contain(new List<string>() { "implicit", "client_credentials", "authorization_code", "password" });
                createdPolicyRule.Conditions.Scopes.Include.Should().Contain(new List<string>() { "openid", "email", "address" });
                createdPolicyRule.Actions.Token.AccessTokenLifetimeMinutes.Should().Be(60);
                createdPolicyRule.Actions.Token.RefreshTokenLifetimeMinutes.Should().Be(0);
                createdPolicyRule.Actions.Token.RefreshTokenWindowMinutes.Should().Be(10080);
            }
            finally
            {
                await createdAuthorizationServer.DeletePolicyAsync(createdPolicy.Id);
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact]
        public async Task GetAuthorizationServerPolicyRule()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };
            var testPolicy = new AuthorizationServerPolicy
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
                var policy = await createdAuthorizationServer.GetPolicyAsync(createdPolicy.Id);
                policy.Should().NotBeNull();

                var policyRule = new AuthorizationServerPolicyRule
                {
                    Name = $"{SdkPrefix}:{nameof(GetAuthorizationServerPolicyRule)}",
                    Type = "RESOURCE_ACCESS",
                    Priority = 1,
                    Conditions = new AuthorizationServerPolicyRuleConditions
                    {
                        People = new PolicyPeopleCondition
                        {
                            Groups = new GroupCondition
                            {
                                Include = new List<string>() { "EVERYONE" },
                            },
                        },
                        GrantTypes = new GrantTypePolicyRuleCondition
                        {
                            Include = new List<string>() { "implicit", "client_credentials", "authorization_code", "password" },
                        },
                        Scopes = new OAuth2ScopesMediationPolicyRuleCondition
                        {
                            Include = new List<string>() { "openid", "email", "address" },
                        },
                    },
                    Actions = new AuthorizationServerPolicyRuleActions
                    {
                        Token = new TokenAuthorizationServerPolicyRuleAction
                        {
                            AccessTokenLifetimeMinutes = 60,
                            RefreshTokenLifetimeMinutes = 0,
                            RefreshTokenWindowMinutes = 10080,
                        },
                    },
                };

                var createdPolicyRule = await createdPolicy.CreatePolicyRuleAsync(policyRule, createdAuthorizationServer.Id);
                var retrievedPolicyRule = await createdPolicy.GetPolicyRuleAsync(createdAuthorizationServer.Id, createdPolicyRule.Id);

                retrievedPolicyRule.Should().NotBeNull();
                retrievedPolicyRule.Id.Should().Be(createdPolicyRule.Id);
                retrievedPolicyRule.Name.Should().Be(policyRule.Name);
                retrievedPolicyRule.Type.Should().Be("RESOURCE_ACCESS");
                retrievedPolicyRule.Priority.Should().Be(1);
                retrievedPolicyRule.Conditions.People.Groups.Include.Should().Contain("EVERYONE");
                retrievedPolicyRule.Conditions.GrantTypes.Include.Should().Contain(new List<string>() { "implicit", "client_credentials", "authorization_code", "password" });
                retrievedPolicyRule.Conditions.Scopes.Include.Should().Contain(new List<string>() { "openid", "email", "address" });
                retrievedPolicyRule.Actions.Token.AccessTokenLifetimeMinutes.Should().Be(60);
                retrievedPolicyRule.Actions.Token.RefreshTokenLifetimeMinutes.Should().Be(0);
                retrievedPolicyRule.Actions.Token.RefreshTokenWindowMinutes.Should().Be(10080);
            }
            finally
            {
                await createdAuthorizationServer.DeletePolicyAsync(createdPolicy.Id);
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact]
        public async Task UpdateAuthorizationServerPolicyRule()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };
            var testPolicy = new AuthorizationServerPolicy
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
                var policy = await createdAuthorizationServer.GetPolicyAsync(createdPolicy.Id);
                policy.Should().NotBeNull();

                var policyRule = new AuthorizationServerPolicyRule
                {
                    Name = $"{SdkPrefix}:{nameof(UpdateAuthorizationServerPolicyRule)}",
                    Type = "RESOURCE_ACCESS",
                    Priority = 1,
                    Conditions = new AuthorizationServerPolicyRuleConditions
                    {
                        People = new PolicyPeopleCondition
                        {
                            Groups = new GroupCondition
                            {
                                Include = new List<string>() { "EVERYONE" },
                            },
                        },
                        GrantTypes = new GrantTypePolicyRuleCondition
                        {
                            Include = new List<string>() { "implicit", "client_credentials", "authorization_code", "password" },
                        },
                        Scopes = new OAuth2ScopesMediationPolicyRuleCondition
                        {
                            Include = new List<string>() { "openid", "email", "address" },
                        },
                    },
                    Actions = new AuthorizationServerPolicyRuleActions
                    {
                        Token = new TokenAuthorizationServerPolicyRuleAction
                        {
                            AccessTokenLifetimeMinutes = 60,
                            RefreshTokenLifetimeMinutes = 0,
                            RefreshTokenWindowMinutes = 10080,
                        },
                    },
                };

                var createdPolicyRule = await createdPolicy.CreatePolicyRuleAsync(policyRule, createdAuthorizationServer.Id);
                var retrievedPolicyRule = await createdPolicy.GetPolicyRuleAsync(createdAuthorizationServer.Id, createdPolicyRule.Id);

                retrievedPolicyRule.Should().NotBeNull();
                retrievedPolicyRule.Id.Should().Be(createdPolicyRule.Id);
                retrievedPolicyRule.Name.Should().Be(policyRule.Name);
                retrievedPolicyRule.Type.Should().Be("RESOURCE_ACCESS");
                retrievedPolicyRule.Priority.Should().Be(1);
                retrievedPolicyRule.Conditions.People.Groups.Include.Should().Contain("EVERYONE");
                retrievedPolicyRule.Conditions.GrantTypes.Include.Should().Contain(new List<string>() { "implicit", "client_credentials", "authorization_code", "password" });
                retrievedPolicyRule.Conditions.Scopes.Include.Should().Contain(new List<string>() { "openid", "email", "address" });
                retrievedPolicyRule.Actions.Token.AccessTokenLifetimeMinutes.Should().Be(60);
                retrievedPolicyRule.Actions.Token.RefreshTokenLifetimeMinutes.Should().Be(0);
                retrievedPolicyRule.Actions.Token.RefreshTokenWindowMinutes.Should().Be(10080);

                createdPolicyRule.Name = $"{SdkPrefix}: Name Updated";
                createdPolicyRule.Priority = 2;
                createdPolicyRule.Actions.Token.AccessTokenLifetimeMinutes = 65;
                createdPolicyRule.Actions.Token.RefreshTokenLifetimeMinutes = 65;
                createdPolicyRule.Actions.Token.RefreshTokenWindowMinutes = 65;

                var updatedPolicyRule = await testClient.AuthorizationServers.UpdateAuthorizationServerPolicyRuleAsync(createdPolicyRule, createdPolicy.Id, createdAuthorizationServer.Id, createdPolicyRule.Id);

                updatedPolicyRule.Name.Should().Be(createdPolicyRule.Name);
                updatedPolicyRule.Priority = 2;
                updatedPolicyRule.Actions.Token.AccessTokenLifetimeMinutes = 65;
                updatedPolicyRule.Actions.Token.RefreshTokenLifetimeMinutes = 65;
                updatedPolicyRule.Actions.Token.RefreshTokenWindowMinutes = 65;
            }
            finally
            {
                await createdAuthorizationServer.DeletePolicyAsync(createdPolicy.Id);
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact]
        public async Task DeleteAuthorizationServerPolicyRule()
        {
            var testClient = TestClient.Create();
            var testAuthorizationServerName = $"{SdkPrefix}:Test AuthZ Server ({TestClient.RandomString(4)})";

            var testAuthorizationServer = new AuthorizationServer
            {
                Name = testAuthorizationServerName,
                Description = "Test Authorization Server",
                Audiences = new string[] { "api://default" },
            };
            var testPolicy = new AuthorizationServerPolicy
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
                var policy = await createdAuthorizationServer.GetPolicyAsync(createdPolicy.Id);
                policy.Should().NotBeNull();

                var policyRule = new AuthorizationServerPolicyRule
                {
                    Name = $"{SdkPrefix}:{nameof(DeleteAuthorizationServerPolicyRule)}",
                    Type = "RESOURCE_ACCESS",
                    Priority = 1,
                    Conditions = new AuthorizationServerPolicyRuleConditions
                    {
                        People = new PolicyPeopleCondition
                        {
                            Groups = new GroupCondition
                            {
                                Include = new List<string>() { "EVERYONE" },
                            },
                        },
                        GrantTypes = new GrantTypePolicyRuleCondition
                        {
                            Include = new List<string>() { "implicit", "client_credentials", "authorization_code", "password" },
                        },
                        Scopes = new OAuth2ScopesMediationPolicyRuleCondition
                        {
                            Include = new List<string>() { "openid", "email", "address" },
                        },
                    },
                    Actions = new AuthorizationServerPolicyRuleActions
                    {
                        Token = new TokenAuthorizationServerPolicyRuleAction
                        {
                            AccessTokenLifetimeMinutes = 60,
                            RefreshTokenLifetimeMinutes = 0,
                            RefreshTokenWindowMinutes = 10080,
                        },
                    },
                };

                var createdPolicyRule = await createdPolicy.CreatePolicyRuleAsync(policyRule, createdAuthorizationServer.Id);

                var rules = await testClient.AuthorizationServers.ListAuthorizationServerPolicyRules(createdPolicy.Id, createdAuthorizationServer.Id).ToListAsync();

                rules.Should().NotBeNull();
                rules.FirstOrDefault(x => x.Name == policyRule.Name).Should().NotBeNull();

                await createdPolicy.DeletePolicyRuleAsync(createdAuthorizationServer.Id, createdPolicyRule.Id); //testClient.AuthorizationServers.DeleteAuthorizationServerPolicyRuleAsync(createdPolicy.Id, createdAuthorizationServer.Id, createdPolicyRule.Id);
                rules = await createdPolicy.ListPolicyRules(createdAuthorizationServer.Id).ToListAsync();
                rules.FirstOrDefault(x => x.Name == policyRule.Name).Should().BeNull();
            }
            finally
            {
                await createdAuthorizationServer.DeletePolicyAsync(createdPolicy.Id);
                await createdAuthorizationServer.DeactivateAsync();
                await testClient.AuthorizationServers.DeleteAuthorizationServerAsync(createdAuthorizationServer.Id);
            }
        }

        [Fact]
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
            var testPolicy = new AuthorizationServerPolicy
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

        [Fact]
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
            var testPolicy = new AuthorizationServerPolicy
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

        [Fact]
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
            var testPolicy = new AuthorizationServerPolicy
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

        [Fact]
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
            var testPolicy = new AuthorizationServerPolicy
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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
            var key = new JwkUse
            {
                Use = "sig",
            };

            var createdAuthorizationServer = await testClient.AuthorizationServers.CreateAuthorizationServerAsync(testAuthorizationServer);

            try
            {
                var keys = await createdAuthorizationServer.RotateKeys(key).ToListAsync();
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
