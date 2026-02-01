// <copyright file="AuthorizationServerRulesApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Okta.Sdk.UnitTest.Internal;
using Xunit;

namespace Okta.Sdk.UnitTest.Api
{
    /// <summary>
    /// Unit tests for AuthorizationServerRulesApi covering all 7 endpoints.
    /// 
    /// API Coverage:
    /// 1. GET /api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules - ListAuthorizationServerPolicyRules
    /// 2. POST /api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules - CreateAuthorizationServerPolicyRuleAsync
    /// 3. GET /api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId} - GetAuthorizationServerPolicyRuleAsync
    /// 4. PUT /api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId} - ReplaceAuthorizationServerPolicyRuleAsync
    /// 5. DELETE /api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId} - DeleteAuthorizationServerPolicyRuleAsync
    /// 6. POST /api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId}/lifecycle/activate - ActivateAuthorizationServerPolicyRuleAsync
    /// 7. POST /api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId}/lifecycle/deactivate - DeactivateAuthorizationServerPolicyRuleAsync
    /// 
    /// Each method is tested with:
    /// - Regular async method
    /// - WithHttpInfo variant for response metadata
    /// - Proper request path and parameters validation
    /// - Response data validation
    /// </summary>
    public class AuthorizationServerRulesApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _authServerId = "aus1234567890abcdef";
        private readonly string _policyId = "00p1234567890abcdef";
        private readonly string _ruleId = "rul1234567890abcdef";

        #region ListAuthorizationServerPolicyRules Tests

        [Fact]
        public async Task ListAuthorizationServerPolicyRules_ReturnsRulesList()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""type"": ""RESOURCE_ACCESS"",
                    ""id"": ""rul1111111111111111"",
                    ""status"": ""ACTIVE"",
                    ""name"": ""Default Rule"",
                    ""priority"": 1,
                    ""system"": false,
                    ""conditions"": {
                        ""people"": {
                            ""users"": { ""include"": [], ""exclude"": [] },
                            ""groups"": { ""include"": [""EVERYONE""], ""exclude"": [] }
                        },
                        ""grantTypes"": {
                            ""include"": [""authorization_code"", ""implicit"", ""password""]
                        },
                        ""scopes"": {
                            ""include"": [""*""]
                        }
                    },
                    ""actions"": {
                        ""token"": {
                            ""accessTokenLifetimeMinutes"": 60,
                            ""refreshTokenLifetimeMinutes"": 0,
                            ""refreshTokenWindowMinutes"": 10080
                        }
                    },
                    ""created"": ""2024-01-15T10:30:00.000Z"",
                    ""lastUpdated"": ""2024-01-15T10:30:00.000Z"",
                    ""_links"": {
                        ""self"": {
                            ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/policies/00p1234567890abcdef/rules/rul1111111111111111""
                        }
                    }
                },
                {
                    ""type"": ""RESOURCE_ACCESS"",
                    ""id"": ""rul2222222222222222"",
                    ""status"": ""INACTIVE"",
                    ""name"": ""Custom Rule"",
                    ""priority"": 2,
                    ""system"": false,
                    ""conditions"": {
                        ""people"": {
                            ""groups"": { ""include"": [""00g1234567890abcdef""] }
                        },
                        ""grantTypes"": {
                            ""include"": [""client_credentials""]
                        },
                        ""scopes"": {
                            ""include"": [""api:read"", ""api:write""]
                        }
                    },
                    ""actions"": {
                        ""token"": {
                            ""accessTokenLifetimeMinutes"": 30,
                            ""refreshTokenLifetimeMinutes"": 0,
                            ""refreshTokenWindowMinutes"": 5040
                        }
                    },
                    ""created"": ""2024-02-01T14:00:00.000Z"",
                    ""lastUpdated"": ""2024-02-10T09:15:00.000Z""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListAuthorizationServerPolicyRulesWithHttpInfoAsync(_authServerId, _policyId);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();
            result.Data.Should().HaveCount(2);

            // Verify first rule
            result.Data[0].Id.Should().Be("rul1111111111111111");
            result.Data[0].Name.Should().Be("Default Rule");
            result.Data[0].Type.Should().Be(AuthorizationServerPolicyRule.TypeEnum.RESOURCEACCESS);
            result.Data[0].Status.Should().Be(AuthorizationServerPolicyRule.StatusEnum.ACTIVE);
            result.Data[0].Priority.Should().Be(1);
            result.Data[0].Actions.Should().NotBeNull();
            result.Data[0].Actions.Token.Should().NotBeNull();
            result.Data[0].Actions.Token.AccessTokenLifetimeMinutes.Should().Be(60);
            result.Data[0].Actions.Token.RefreshTokenWindowMinutes.Should().Be(10080);

            // Verify second rule
            result.Data[1].Id.Should().Be("rul2222222222222222");
            result.Data[1].Name.Should().Be("Custom Rule");
            result.Data[1].Status.Should().Be(AuthorizationServerPolicyRule.StatusEnum.INACTIVE);
            result.Data[1].Priority.Should().Be(2);
            result.Data[1].Actions.Token.AccessTokenLifetimeMinutes.Should().Be(30);
        }

        [Fact]
        public void ListAuthorizationServerPolicyRules_CollectionMethod_ReturnsOktaCollectionClient()
        {
            // Arrange
            var responseJson = @"[{""id"": ""rul1"", ""name"": ""Test Rule"", ""type"": ""RESOURCE_ACCESS"", ""status"": ""ACTIVE""}]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var collection = api.ListAuthorizationServerPolicyRules(_authServerId, _policyId);

            // Assert
            collection.Should().NotBeNull();
            collection.Should().BeAssignableTo<IOktaCollectionClient<AuthorizationServerPolicyRule>>();
        }

        [Fact]
        public async Task ListAuthorizationServerPolicyRulesWithHttpInfoAsync_ReturnsCorrectPathParams()
        {
            // Arrange
            var responseJson = "[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ListAuthorizationServerPolicyRulesWithHttpInfoAsync(_authServerId, _policyId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(_authServerId);
            mockClient.ReceivedPathParams["policyId"].Should().Be(_policyId);
        }

        [Fact]
        public async Task ListAuthorizationServerPolicyRules_HandlesEmptyList()
        {
            // Arrange
            var responseJson = "[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListAuthorizationServerPolicyRulesWithHttpInfoAsync(_authServerId, _policyId);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();
            result.Data.Should().BeEmpty();
        }

        #endregion

        #region CreateAuthorizationServerPolicyRule Tests

        [Fact]
        public async Task CreateAuthorizationServerPolicyRuleAsync_CreatesRule()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""RESOURCE_ACCESS"",
                ""id"": ""rul1234567890newrule"",
                ""status"": ""ACTIVE"",
                ""name"": ""New Policy Rule"",
                ""priority"": 1,
                ""system"": false,
                ""conditions"": {
                    ""people"": {
                        ""groups"": { ""include"": [""EVERYONE""] }
                    },
                    ""grantTypes"": {
                        ""include"": [""authorization_code"", ""implicit""]
                    },
                    ""scopes"": {
                        ""include"": [""openid"", ""profile"", ""email""]
                    }
                },
                ""actions"": {
                    ""token"": {
                        ""accessTokenLifetimeMinutes"": 60,
                        ""refreshTokenLifetimeMinutes"": 0,
                        ""refreshTokenWindowMinutes"": 10080
                    }
                },
                ""created"": ""2024-03-01T10:00:00.000Z"",
                ""lastUpdated"": ""2024-03-01T10:00:00.000Z"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/policies/00p1234567890abcdef/rules/rul1234567890newrule""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var newRule = new AuthorizationServerPolicyRuleRequest
            {
                Name = "New Policy Rule",
                Priority = 1,
                Type = AuthorizationServerPolicyRuleRequest.TypeEnum.RESOURCEACCESS,
                Conditions = new AuthorizationServerPolicyRuleConditions
                {
                    GrantTypes = new GrantTypePolicyRuleCondition
                    {
                        Include = new List<string> { "authorization_code", "implicit" }
                    },
                    Scopes = new OAuth2ScopesMediationPolicyRuleCondition
                    {
                        Include = new List<string> { "openid", "profile", "email" }
                    }
                },
                Actions = new AuthorizationServerPolicyRuleActions
                {
                    Token = new TokenAuthorizationServerPolicyRuleAction
                    {
                        AccessTokenLifetimeMinutes = 60,
                        RefreshTokenLifetimeMinutes = 0,
                        RefreshTokenWindowMinutes = 10080
                    }
                }
            };

            // Act
            var result = await api.CreateAuthorizationServerPolicyRuleAsync(_authServerId, _policyId, newRule);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be("rul1234567890newrule");
            result.Name.Should().Be("New Policy Rule");
            result.Type.Should().Be(AuthorizationServerPolicyRule.TypeEnum.RESOURCEACCESS);
            result.Status.Should().Be(AuthorizationServerPolicyRule.StatusEnum.ACTIVE);
            result.Priority.Should().Be(1);
            result.Actions.Should().NotBeNull();
            result.Actions.Token.AccessTokenLifetimeMinutes.Should().Be(60);
            result.Actions.Token.RefreshTokenWindowMinutes.Should().Be(10080);
        }

        [Fact]
        public async Task CreateAuthorizationServerPolicyRuleWithHttpInfoAsync_BuildsCorrectPath()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""RESOURCE_ACCESS"",
                ""id"": ""rul1234567890newrule"",
                ""status"": ""ACTIVE"",
                ""name"": ""Test Rule"",
                ""priority"": 1
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var newRule = new AuthorizationServerPolicyRuleRequest
            {
                Name = "Test Rule",
                Type = AuthorizationServerPolicyRuleRequest.TypeEnum.RESOURCEACCESS,
                Priority = 1,
                Conditions = new AuthorizationServerPolicyRuleConditions
                {
                    GrantTypes = new GrantTypePolicyRuleCondition
                    {
                        Include = new List<string> { "authorization_code" }
                    }
                }
            };

            // Act
            var result = await api.CreateAuthorizationServerPolicyRuleWithHttpInfoAsync(_authServerId, _policyId, newRule);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(_authServerId);
            mockClient.ReceivedPathParams["policyId"].Should().Be(_policyId);
            result.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task CreateAuthorizationServerPolicyRuleAsync_SendsCorrectRequestBody()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""RESOURCE_ACCESS"",
                ""id"": ""rul1234567890test"",
                ""status"": ""ACTIVE"",
                ""name"": ""Test Rule"",
                ""priority"": 1
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var newRule = new AuthorizationServerPolicyRuleRequest
            {
                Name = "Test Rule",
                Type = AuthorizationServerPolicyRuleRequest.TypeEnum.RESOURCEACCESS,
                Priority = 1,
                Conditions = new AuthorizationServerPolicyRuleConditions
                {
                    GrantTypes = new GrantTypePolicyRuleCondition
                    {
                        Include = new List<string> { "authorization_code" }
                    }
                },
                Actions = new AuthorizationServerPolicyRuleActions
                {
                    Token = new TokenAuthorizationServerPolicyRuleAction
                    {
                        AccessTokenLifetimeMinutes = 60
                    }
                }
            };

            // Act
            await api.CreateAuthorizationServerPolicyRuleAsync(_authServerId, _policyId, newRule);

            // Assert
            mockClient.ReceivedBody.Should().NotBeNullOrEmpty();
            mockClient.ReceivedBody.Should().Contain("\"name\":\"Test Rule\"");
            mockClient.ReceivedBody.Should().Contain("\"type\":\"RESOURCE_ACCESS\"");
            mockClient.ReceivedBody.Should().Contain("\"priority\":1");
            mockClient.ReceivedBody.Should().Contain("\"authorization_code\"");
            mockClient.ReceivedBody.Should().Contain("\"accessTokenLifetimeMinutes\":60");
        }

        [Fact]
        public async Task CreateAuthorizationServerPolicyRuleWithHttpInfoAsync_ReturnsResponse()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""RESOURCE_ACCESS"",
                ""id"": ""rul9999999999999999"",
                ""status"": ""ACTIVE"",
                ""name"": ""HttpInfo Test Rule"",
                ""priority"": 3
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var newRule = new AuthorizationServerPolicyRuleRequest
            {
                Name = "HttpInfo Test Rule",
                Type = AuthorizationServerPolicyRuleRequest.TypeEnum.RESOURCEACCESS,
                Priority = 3,
                Conditions = new AuthorizationServerPolicyRuleConditions()
            };

            // Act
            var result = await api.CreateAuthorizationServerPolicyRuleWithHttpInfoAsync(_authServerId, _policyId, newRule);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be("rul9999999999999999");
            result.Data.Name.Should().Be("HttpInfo Test Rule");
            result.Data.Priority.Should().Be(3);
        }

        #endregion

        #region GetAuthorizationServerPolicyRule Tests

        [Fact]
        public async Task GetAuthorizationServerPolicyRuleAsync_ReturnsRule()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""RESOURCE_ACCESS"",
                ""id"": ""rul1234567890abcdef"",
                ""status"": ""ACTIVE"",
                ""name"": ""Default Policy Rule"",
                ""priority"": 1,
                ""system"": false,
                ""conditions"": {
                    ""people"": {
                        ""groups"": { ""include"": [""EVERYONE""] }
                    },
                    ""grantTypes"": {
                        ""include"": [""authorization_code"", ""implicit"", ""password""]
                    },
                    ""scopes"": {
                        ""include"": [""*""]
                    }
                },
                ""actions"": {
                    ""token"": {
                        ""accessTokenLifetimeMinutes"": 60,
                        ""refreshTokenLifetimeMinutes"": 0,
                        ""refreshTokenWindowMinutes"": 10080
                    }
                },
                ""created"": ""2024-01-15T10:30:00.000Z"",
                ""lastUpdated"": ""2024-01-20T15:45:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAuthorizationServerPolicyRuleAsync(_authServerId, _policyId, _ruleId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be("rul1234567890abcdef");
            result.Name.Should().Be("Default Policy Rule");
            result.Type.Should().Be(AuthorizationServerPolicyRule.TypeEnum.RESOURCEACCESS);
            result.Status.Should().Be(AuthorizationServerPolicyRule.StatusEnum.ACTIVE);
            result.Priority.Should().Be(1);
            result.System.Should().BeFalse();
            result.Conditions.Should().NotBeNull();
            result.Actions.Should().NotBeNull();
            result.Actions.Token.AccessTokenLifetimeMinutes.Should().Be(60);
        }

        [Fact]
        public async Task GetAuthorizationServerPolicyRuleWithHttpInfoAsync_BuildsCorrectPath()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""RESOURCE_ACCESS"",
                ""id"": ""rul1234567890abcdef"",
                ""status"": ""ACTIVE"",
                ""name"": ""Test Rule"",
                ""priority"": 1
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetAuthorizationServerPolicyRuleWithHttpInfoAsync(_authServerId, _policyId, _ruleId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId}");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(_authServerId);
            mockClient.ReceivedPathParams["policyId"].Should().Be(_policyId);
            mockClient.ReceivedPathParams["ruleId"].Should().Be(_ruleId);
        }

        [Fact]
        public async Task GetAuthorizationServerPolicyRuleAsync_ExtractsAllPathParams()
        {
            // Arrange
            var customAuthServerId = "aus_custom_server_123";
            var customPolicyId = "00p_custom_policy_456";
            var customRuleId = "rul_custom_rule_789";
            var responseJson = @"{
                ""type"": ""RESOURCE_ACCESS"",
                ""id"": ""rul_custom_rule_789"",
                ""status"": ""INACTIVE"",
                ""name"": ""Custom Rule"",
                ""priority"": 2
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAuthorizationServerPolicyRuleAsync(customAuthServerId, customPolicyId, customRuleId);

            // Assert
            mockClient.ReceivedPathParams["authServerId"].Should().Be(customAuthServerId);
            mockClient.ReceivedPathParams["policyId"].Should().Be(customPolicyId);
            mockClient.ReceivedPathParams["ruleId"].Should().Be(customRuleId);
            result.Id.Should().Be("rul_custom_rule_789");
            result.Status.Should().Be(AuthorizationServerPolicyRule.StatusEnum.INACTIVE);
        }

        [Fact]
        public async Task GetAuthorizationServerPolicyRuleWithHttpInfoAsync_ReturnsResponse()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""RESOURCE_ACCESS"",
                ""id"": ""rul0987654321fedcba"",
                ""status"": ""ACTIVE"",
                ""name"": ""HttpInfo Rule"",
                ""priority"": 5,
                ""conditions"": {
                    ""grantTypes"": {
                        ""include"": [""client_credentials""]
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAuthorizationServerPolicyRuleWithHttpInfoAsync(_authServerId, _policyId, _ruleId);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be("rul0987654321fedcba");
            result.Data.Name.Should().Be("HttpInfo Rule");
            result.Data.Priority.Should().Be(5);
        }

        #endregion

        #region ReplaceAuthorizationServerPolicyRule Tests

        [Fact]
        public async Task ReplaceAuthorizationServerPolicyRuleAsync_UpdatesRule()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""RESOURCE_ACCESS"",
                ""id"": ""rul1234567890abcdef"",
                ""status"": ""ACTIVE"",
                ""name"": ""Updated Policy Rule"",
                ""priority"": 2,
                ""system"": false,
                ""conditions"": {
                    ""people"": {
                        ""groups"": { ""include"": [""00g1234567890abcdef""] }
                    },
                    ""grantTypes"": {
                        ""include"": [""authorization_code""]
                    },
                    ""scopes"": {
                        ""include"": [""openid"", ""profile""]
                    }
                },
                ""actions"": {
                    ""token"": {
                        ""accessTokenLifetimeMinutes"": 120,
                        ""refreshTokenLifetimeMinutes"": 0,
                        ""refreshTokenWindowMinutes"": 20160
                    }
                },
                ""created"": ""2024-01-15T10:30:00.000Z"",
                ""lastUpdated"": ""2024-03-15T16:20:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updatedRule = new AuthorizationServerPolicyRuleRequest
            {
                Name = "Updated Policy Rule",
                Type = AuthorizationServerPolicyRuleRequest.TypeEnum.RESOURCEACCESS,
                Priority = 2,
                Status = AuthorizationServerPolicyRuleRequest.StatusEnum.ACTIVE,
                Conditions = new AuthorizationServerPolicyRuleConditions
                {
                    GrantTypes = new GrantTypePolicyRuleCondition
                    {
                        Include = new List<string> { "authorization_code" }
                    },
                    Scopes = new OAuth2ScopesMediationPolicyRuleCondition
                    {
                        Include = new List<string> { "openid", "profile" }
                    }
                },
                Actions = new AuthorizationServerPolicyRuleActions
                {
                    Token = new TokenAuthorizationServerPolicyRuleAction
                    {
                        AccessTokenLifetimeMinutes = 120,
                        RefreshTokenLifetimeMinutes = 0,
                        RefreshTokenWindowMinutes = 20160
                    }
                }
            };

            // Act
            var result = await api.ReplaceAuthorizationServerPolicyRuleAsync(_authServerId, _policyId, _ruleId, updatedRule);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be("rul1234567890abcdef");
            result.Name.Should().Be("Updated Policy Rule");
            result.Priority.Should().Be(2);
            result.Actions.Token.AccessTokenLifetimeMinutes.Should().Be(120);
            result.Actions.Token.RefreshTokenWindowMinutes.Should().Be(20160);
        }

        [Fact]
        public async Task ReplaceAuthorizationServerPolicyRuleWithHttpInfoAsync_BuildsCorrectPath()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""RESOURCE_ACCESS"",
                ""id"": ""rul1234567890abcdef"",
                ""status"": ""ACTIVE"",
                ""name"": ""Test Rule"",
                ""priority"": 1
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updatedRule = new AuthorizationServerPolicyRuleRequest
            {
                Name = "Test Rule",
                Type = AuthorizationServerPolicyRuleRequest.TypeEnum.RESOURCEACCESS,
                Priority = 1,
                Conditions = new AuthorizationServerPolicyRuleConditions()
            };

            // Act
            await api.ReplaceAuthorizationServerPolicyRuleWithHttpInfoAsync(_authServerId, _policyId, _ruleId, updatedRule);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId}");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(_authServerId);
            mockClient.ReceivedPathParams["policyId"].Should().Be(_policyId);
            mockClient.ReceivedPathParams["ruleId"].Should().Be(_ruleId);
        }

        [Fact]
        public async Task ReplaceAuthorizationServerPolicyRuleAsync_SendsCorrectRequestBody()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""RESOURCE_ACCESS"",
                ""id"": ""rul1234567890abcdef"",
                ""status"": ""INACTIVE"",
                ""name"": ""Modified Rule"",
                ""priority"": 5
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updatedRule = new AuthorizationServerPolicyRuleRequest
            {
                Name = "Modified Rule",
                Type = AuthorizationServerPolicyRuleRequest.TypeEnum.RESOURCEACCESS,
                Priority = 5,
                Status = AuthorizationServerPolicyRuleRequest.StatusEnum.INACTIVE,
                Conditions = new AuthorizationServerPolicyRuleConditions
                {
                    GrantTypes = new GrantTypePolicyRuleCondition
                    {
                        Include = new List<string> { "client_credentials" }
                    }
                },
                Actions = new AuthorizationServerPolicyRuleActions
                {
                    Token = new TokenAuthorizationServerPolicyRuleAction
                    {
                        AccessTokenLifetimeMinutes = 30
                    }
                }
            };

            // Act
            await api.ReplaceAuthorizationServerPolicyRuleAsync(_authServerId, _policyId, _ruleId, updatedRule);

            // Assert
            mockClient.ReceivedBody.Should().NotBeNullOrEmpty();
            mockClient.ReceivedBody.Should().Contain("\"name\":\"Modified Rule\"");
            mockClient.ReceivedBody.Should().Contain("\"priority\":5");
            mockClient.ReceivedBody.Should().Contain("\"status\":\"INACTIVE\"");
            mockClient.ReceivedBody.Should().Contain("\"client_credentials\"");
            mockClient.ReceivedBody.Should().Contain("\"accessTokenLifetimeMinutes\":30");
        }

        [Fact]
        public async Task ReplaceAuthorizationServerPolicyRuleWithHttpInfoAsync_ReturnsResponse()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""RESOURCE_ACCESS"",
                ""id"": ""rul5555555555555555"",
                ""status"": ""ACTIVE"",
                ""name"": ""HttpInfo Updated Rule"",
                ""priority"": 10
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updatedRule = new AuthorizationServerPolicyRuleRequest
            {
                Name = "HttpInfo Updated Rule",
                Type = AuthorizationServerPolicyRuleRequest.TypeEnum.RESOURCEACCESS,
                Priority = 10,
                Conditions = new AuthorizationServerPolicyRuleConditions()
            };

            // Act
            var result = await api.ReplaceAuthorizationServerPolicyRuleWithHttpInfoAsync(_authServerId, _policyId, _ruleId, updatedRule);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be("rul5555555555555555");
            result.Data.Name.Should().Be("HttpInfo Updated Rule");
            result.Data.Priority.Should().Be(10);
        }

        #endregion

        #region DeleteAuthorizationServerPolicyRule Tests

        [Fact]
        public async Task DeleteAuthorizationServerPolicyRuleAsync_DeletesRule()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert (should not throw)
            await api.DeleteAuthorizationServerPolicyRuleAsync(_authServerId, _policyId, _ruleId);
        }

        [Fact]
        public async Task DeleteAuthorizationServerPolicyRuleWithHttpInfoAsync_BuildsCorrectPath()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteAuthorizationServerPolicyRuleWithHttpInfoAsync(_authServerId, _policyId, _ruleId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId}");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(_authServerId);
            mockClient.ReceivedPathParams["policyId"].Should().Be(_policyId);
            mockClient.ReceivedPathParams["ruleId"].Should().Be(_ruleId);
        }

        [Fact]
        public async Task DeleteAuthorizationServerPolicyRuleAsync_UsesCorrectPathParams()
        {
            // Arrange
            var customAuthServerId = "aus_for_delete_test";
            var customPolicyId = "00p_delete_policy";
            var customRuleId = "rul_delete_rule";
            var mockClient = new MockAsyncClient(string.Empty);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteAuthorizationServerPolicyRuleAsync(customAuthServerId, customPolicyId, customRuleId);

            // Assert
            mockClient.ReceivedPathParams["authServerId"].Should().Be(customAuthServerId);
            mockClient.ReceivedPathParams["policyId"].Should().Be(customPolicyId);
            mockClient.ReceivedPathParams["ruleId"].Should().Be(customRuleId);
        }

        [Fact]
        public async Task DeleteAuthorizationServerPolicyRuleWithHttpInfoAsync_ReturnsResponse()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.DeleteAuthorizationServerPolicyRuleWithHttpInfoAsync(_authServerId, _policyId, _ruleId);

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Contain("/rules/{ruleId}");
        }

        #endregion

        #region ActivateAuthorizationServerPolicyRule Tests

        [Fact]
        public async Task ActivateAuthorizationServerPolicyRuleAsync_ActivatesRule()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert (should not throw)
            await api.ActivateAuthorizationServerPolicyRuleAsync(_authServerId, _policyId, _ruleId);
        }

        [Fact]
        public async Task ActivateAuthorizationServerPolicyRuleWithHttpInfoAsync_BuildsCorrectPath()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ActivateAuthorizationServerPolicyRuleWithHttpInfoAsync(_authServerId, _policyId, _ruleId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId}/lifecycle/activate");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(_authServerId);
            mockClient.ReceivedPathParams["policyId"].Should().Be(_policyId);
            mockClient.ReceivedPathParams["ruleId"].Should().Be(_ruleId);
        }

        [Fact]
        public async Task ActivateAuthorizationServerPolicyRuleAsync_UsesCorrectPathParams()
        {
            // Arrange
            var customAuthServerId = "aus_activate_server";
            var customPolicyId = "00p_activate_policy";
            var customRuleId = "rul_to_activate";
            var mockClient = new MockAsyncClient(string.Empty);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ActivateAuthorizationServerPolicyRuleAsync(customAuthServerId, customPolicyId, customRuleId);

            // Assert
            mockClient.ReceivedPathParams["authServerId"].Should().Be(customAuthServerId);
            mockClient.ReceivedPathParams["policyId"].Should().Be(customPolicyId);
            mockClient.ReceivedPathParams["ruleId"].Should().Be(customRuleId);
        }

        [Fact]
        public async Task ActivateAuthorizationServerPolicyRuleWithHttpInfoAsync_ReturnsResponse()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ActivateAuthorizationServerPolicyRuleWithHttpInfoAsync(_authServerId, _policyId, _ruleId);

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Contain("/lifecycle/activate");
        }

        #endregion

        #region DeactivateAuthorizationServerPolicyRule Tests

        [Fact]
        public async Task DeactivateAuthorizationServerPolicyRuleAsync_DeactivatesRule()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert (should not throw)
            await api.DeactivateAuthorizationServerPolicyRuleAsync(_authServerId, _policyId, _ruleId);
        }

        [Fact]
        public async Task DeactivateAuthorizationServerPolicyRuleWithHttpInfoAsync_BuildsCorrectPath()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeactivateAuthorizationServerPolicyRuleWithHttpInfoAsync(_authServerId, _policyId, _ruleId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/policies/{policyId}/rules/{ruleId}/lifecycle/deactivate");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(_authServerId);
            mockClient.ReceivedPathParams["policyId"].Should().Be(_policyId);
            mockClient.ReceivedPathParams["ruleId"].Should().Be(_ruleId);
        }

        [Fact]
        public async Task DeactivateAuthorizationServerPolicyRuleAsync_UsesCorrectPathParams()
        {
            // Arrange
            var customAuthServerId = "aus_deactivate_server";
            var customPolicyId = "00p_deactivate_policy";
            var customRuleId = "rul_to_deactivate";
            var mockClient = new MockAsyncClient(string.Empty);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeactivateAuthorizationServerPolicyRuleAsync(customAuthServerId, customPolicyId, customRuleId);

            // Assert
            mockClient.ReceivedPathParams["authServerId"].Should().Be(customAuthServerId);
            mockClient.ReceivedPathParams["policyId"].Should().Be(customPolicyId);
            mockClient.ReceivedPathParams["ruleId"].Should().Be(customRuleId);
        }

        [Fact]
        public async Task DeactivateAuthorizationServerPolicyRuleWithHttpInfoAsync_ReturnsResponse()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.DeactivateAuthorizationServerPolicyRuleWithHttpInfoAsync(_authServerId, _policyId, _ruleId);

            // Assert
            result.Should().NotBeNull();
            mockClient.ReceivedPath.Should().Contain("/lifecycle/deactivate");
        }

        #endregion

        #region Response Data Validation Tests

        [Fact]
        public async Task GetAuthorizationServerPolicyRuleAsync_ParsesTokenActionsCorrectly()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""RESOURCE_ACCESS"",
                ""id"": ""rul1234567890abcdef"",
                ""status"": ""ACTIVE"",
                ""name"": ""Token Action Test Rule"",
                ""priority"": 1,
                ""actions"": {
                    ""token"": {
                        ""accessTokenLifetimeMinutes"": 45,
                        ""refreshTokenLifetimeMinutes"": 1440,
                        ""refreshTokenWindowMinutes"": 20160
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAuthorizationServerPolicyRuleAsync(_authServerId, _policyId, _ruleId);

            // Assert
            result.Actions.Should().NotBeNull();
            result.Actions.Token.Should().NotBeNull();
            result.Actions.Token.AccessTokenLifetimeMinutes.Should().Be(45);
            result.Actions.Token.RefreshTokenLifetimeMinutes.Should().Be(1440);
            result.Actions.Token.RefreshTokenWindowMinutes.Should().Be(20160);
        }

        [Fact]
        public async Task GetAuthorizationServerPolicyRuleAsync_ParsesConditionsCorrectly()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""RESOURCE_ACCESS"",
                ""id"": ""rul1234567890abcdef"",
                ""status"": ""ACTIVE"",
                ""name"": ""Conditions Test Rule"",
                ""priority"": 1,
                ""conditions"": {
                    ""people"": {
                        ""groups"": { ""include"": [""00g111111111111111"", ""00g222222222222222""] },
                        ""users"": { ""include"": [""00u333333333333333""] }
                    },
                    ""grantTypes"": {
                        ""include"": [""authorization_code"", ""implicit"", ""refresh_token""]
                    },
                    ""scopes"": {
                        ""include"": [""openid"", ""profile"", ""email"", ""offline_access""]
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAuthorizationServerPolicyRuleAsync(_authServerId, _policyId, _ruleId);

            // Assert
            result.Conditions.Should().NotBeNull();
            result.Conditions.GrantTypes.Should().NotBeNull();
            result.Conditions.GrantTypes.Include.Should().HaveCount(3);
            result.Conditions.GrantTypes.Include.Should().Contain("authorization_code");
            result.Conditions.GrantTypes.Include.Should().Contain("implicit");
            result.Conditions.GrantTypes.Include.Should().Contain("refresh_token");
            result.Conditions.Scopes.Should().NotBeNull();
            result.Conditions.Scopes.Include.Should().HaveCount(4);
            result.Conditions.People.Should().NotBeNull();
            result.Conditions.People.Groups.Include.Should().HaveCount(2);
        }

        [Fact]
        public async Task CreateAuthorizationServerPolicyRuleAsync_WithAllGrantTypes_SendsCorrectData()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""RESOURCE_ACCESS"",
                ""id"": ""rul_all_grants"",
                ""status"": ""ACTIVE"",
                ""name"": ""All Grant Types Rule"",
                ""priority"": 1
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var newRule = new AuthorizationServerPolicyRuleRequest
            {
                Name = "All Grant Types Rule",
                Type = AuthorizationServerPolicyRuleRequest.TypeEnum.RESOURCEACCESS,
                Priority = 1,
                Conditions = new AuthorizationServerPolicyRuleConditions
                {
                    GrantTypes = new GrantTypePolicyRuleCondition
                    {
                        Include = new List<string>
                        {
                            "authorization_code",
                            "implicit",
                            "password",
                            "client_credentials",
                            "refresh_token",
                            "urn:ietf:params:oauth:grant-type:device_code"
                        }
                    },
                    Scopes = new OAuth2ScopesMediationPolicyRuleCondition
                    {
                        Include = new List<string> { "*" }
                    }
                },
                Actions = new AuthorizationServerPolicyRuleActions
                {
                    Token = new TokenAuthorizationServerPolicyRuleAction
                    {
                        AccessTokenLifetimeMinutes = 60,
                        RefreshTokenLifetimeMinutes = 0,
                        RefreshTokenWindowMinutes = 10080
                    }
                }
            };

            // Act
            await api.CreateAuthorizationServerPolicyRuleAsync(_authServerId, _policyId, newRule);

            // Assert
            mockClient.ReceivedBody.Should().NotBeNullOrEmpty();
            mockClient.ReceivedBody.Should().Contain("\"authorization_code\"");
            mockClient.ReceivedBody.Should().Contain("\"implicit\"");
            mockClient.ReceivedBody.Should().Contain("\"password\"");
            mockClient.ReceivedBody.Should().Contain("\"client_credentials\"");
            mockClient.ReceivedBody.Should().Contain("\"refresh_token\"");
            mockClient.ReceivedBody.Should().Contain("urn:ietf:params:oauth:grant-type:device_code");
        }

        [Fact]
        public async Task ListAuthorizationServerPolicyRules_ParsesLinksCorrectly()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""type"": ""RESOURCE_ACCESS"",
                    ""id"": ""rul1111111111111111"",
                    ""status"": ""ACTIVE"",
                    ""name"": ""Rule with Links"",
                    ""priority"": 1,
                    ""_links"": {
                        ""self"": {
                            ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/policies/00p1234567890abcdef/rules/rul1111111111111111"",
                            ""hints"": {
                                ""allow"": [""GET"", ""PUT"", ""DELETE""]
                            }
                        },
                        ""deactivate"": {
                            ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/policies/00p1234567890abcdef/rules/rul1111111111111111/lifecycle/deactivate"",
                            ""hints"": {
                                ""allow"": [""POST""]
                            }
                        }
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerRulesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListAuthorizationServerPolicyRulesWithHttpInfoAsync(_authServerId, _policyId);

            // Assert
            result.Data.Should().HaveCount(1);
            result.Data[0].Links.Should().NotBeNull();
        }

        #endregion
    }
}
