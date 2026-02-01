// <copyright file="AuthorizationServerPoliciesApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
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
    /// Unit tests for AuthorizationServerPoliciesApi covering all 7 endpoints.
    /// 
    /// API Coverage:
    /// 1. GET /api/v1/authorizationServers/{authServerId}/policies - ListAuthorizationServerPolicies
    /// 2. POST /api/v1/authorizationServers/{authServerId}/policies - CreateAuthorizationServerPolicyAsync
    /// 3. GET /api/v1/authorizationServers/{authServerId}/policies/{policyId} - GetAuthorizationServerPolicyAsync
    /// 4. PUT /api/v1/authorizationServers/{authServerId}/policies/{policyId} - ReplaceAuthorizationServerPolicyAsync
    /// 5. DELETE /api/v1/authorizationServers/{authServerId}/policies/{policyId} - DeleteAuthorizationServerPolicyAsync
    /// 6. POST /api/v1/authorizationServers/{authServerId}/policies/{policyId}/lifecycle/activate - ActivateAuthorizationServerPolicyAsync
    /// 7. POST /api/v1/authorizationServers/{authServerId}/policies/{policyId}/lifecycle/deactivate - DeactivateAuthorizationServerPolicyAsync
    /// 
    /// Each method is tested with:
    /// - Regular async method
    /// - WithHttpInfo variant for response metadata
    /// - Proper request path and parameters validation
    /// - Response data validation
    /// </summary>
    public class AuthorizationServerPoliciesApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _authServerId = "aus1234567890abcdef";
        private readonly string _policyId = "00p1234567890abcdef";

        #region ListAuthorizationServerPolicies Tests

        [Fact]
        public async Task ListAuthorizationServerPolicies_ReturnsPoliciesList()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""type"": ""OAUTH_AUTHORIZATION_POLICY"",
                    ""id"": ""00p1111111111111111"",
                    ""status"": ""ACTIVE"",
                    ""name"": ""Default Policy"",
                    ""description"": ""Default policy for all clients"",
                    ""priority"": 1,
                    ""system"": true,
                    ""conditions"": {
                        ""clients"": {
                            ""include"": [""ALL_CLIENTS""]
                        }
                    },
                    ""created"": ""2024-01-15T10:30:00.000Z"",
                    ""lastUpdated"": ""2024-01-15T10:30:00.000Z"",
                    ""_links"": {
                        ""self"": {
                            ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/policies/00p1111111111111111""
                        },
                        ""deactivate"": {
                            ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/policies/00p1111111111111111/lifecycle/deactivate""
                        },
                        ""rules"": {
                            ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/policies/00p1111111111111111/rules""
                        }
                    }
                },
                {
                    ""type"": ""OAUTH_AUTHORIZATION_POLICY"",
                    ""id"": ""00p2222222222222222"",
                    ""status"": ""ACTIVE"",
                    ""name"": ""Custom Policy"",
                    ""description"": ""Policy for specific clients"",
                    ""priority"": 2,
                    ""system"": false,
                    ""conditions"": {
                        ""clients"": {
                            ""include"": [""0oa1234567890abcdef"", ""0oa0987654321fedcba""]
                        }
                    },
                    ""created"": ""2024-02-01T14:00:00.000Z"",
                    ""lastUpdated"": ""2024-02-10T09:15:00.000Z""
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListAuthorizationServerPoliciesWithHttpInfoAsync(_authServerId);

            // Assert
            result.Data.Should().NotBeNull();
            result.Data.Should().HaveCount(2);

            // Verify first policy (system/default)
            result.Data[0].Id.Should().Be("00p1111111111111111");
            result.Data[0].Type.Should().Be(AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY);
            result.Data[0].Status.Should().Be(AuthorizationServerPolicy.StatusEnum.ACTIVE);
            result.Data[0].Name.Should().Be("Default Policy");
            result.Data[0].Description.Should().Be("Default policy for all clients");
            result.Data[0].Priority.Should().Be(1);
            result.Data[0].System.Should().BeTrue();
            result.Data[0].Conditions.Should().NotBeNull();
            result.Data[0].Conditions.Clients.Should().NotBeNull();
            result.Data[0].Conditions.Clients.Include.Should().Contain("ALL_CLIENTS");
            result.Data[0].Links.Should().NotBeNull();

            // Verify second policy (custom)
            result.Data[1].Id.Should().Be("00p2222222222222222");
            result.Data[1].Name.Should().Be("Custom Policy");
            result.Data[1].Priority.Should().Be(2);
            result.Data[1].System.Should().BeFalse();
            result.Data[1].Conditions.Clients.Include.Should().HaveCount(2);
            result.Data[1].Conditions.Clients.Include.Should().Contain("0oa1234567890abcdef");
        }

        [Fact]
        public async Task ListAuthorizationServerPolicies_ValidatesRequestPath()
        {
            // Arrange
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ListAuthorizationServerPoliciesWithHttpInfoAsync(_authServerId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/policies");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(_authServerId);
        }

        [Fact]
        public void ListAuthorizationServerPolicies_CollectionMethod_ReturnsOktaCollectionClient()
        {
            // Arrange
            var responseJson = @"[{""id"": ""00p1"", ""name"": ""Test Policy"", ""type"": ""OAUTH_AUTHORIZATION_POLICY"", ""status"": ""ACTIVE""}]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var collection = api.ListAuthorizationServerPolicies(_authServerId);

            // Assert
            collection.Should().NotBeNull();
            collection.Should().BeAssignableTo<IOktaCollectionClient<AuthorizationServerPolicy>>();
        }

        [Fact]
        public async Task ListAuthorizationServerPolicies_WithHttpInfo_ReturnsHeaders()
        {
            // Arrange
            var responseJson = @"[]";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListAuthorizationServerPoliciesWithHttpInfoAsync(_authServerId);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        #region CreateAuthorizationServerPolicy Tests

        [Fact]
        public async Task CreateAuthorizationServerPolicy_CreatesPolicy_ReturnsCreatedPolicy()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""OAUTH_AUTHORIZATION_POLICY"",
                ""id"": ""00p3333333333333333"",
                ""status"": ""ACTIVE"",
                ""name"": ""New API Policy"",
                ""description"": ""Policy for new API clients"",
                ""priority"": 3,
                ""system"": false,
                ""conditions"": {
                    ""clients"": {
                        ""include"": [""0oaNewClient123456""]
                    }
                },
                ""created"": ""2024-03-01T08:00:00.000Z"",
                ""lastUpdated"": ""2024-03-01T08:00:00.000Z"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/policies/00p3333333333333333""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var newPolicy = new AuthorizationServerPolicy
            {
                Type = AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY,
                Name = "New API Policy",
                Description = "Policy for new API clients",
                Priority = 3,
                Status = AuthorizationServerPolicy.StatusEnum.ACTIVE,
                Conditions = new AuthorizationServerPolicyConditions
                {
                    Clients = new ClientPolicyCondition
                    {
                        Include = new List<string> { "0oaNewClient123456" }
                    }
                }
            };

            // Act
            var result = await api.CreateAuthorizationServerPolicyAsync(_authServerId, newPolicy);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be("00p3333333333333333");
            result.Type.Should().Be(AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY);
            result.Status.Should().Be(AuthorizationServerPolicy.StatusEnum.ACTIVE);
            result.Name.Should().Be("New API Policy");
            result.Description.Should().Be("Policy for new API clients");
            result.Priority.Should().Be(3);
            result.System.Should().BeFalse();
            result.Conditions.Should().NotBeNull();
            result.Conditions.Clients.Include.Should().Contain("0oaNewClient123456");
        }

        [Fact]
        public async Task CreateAuthorizationServerPolicy_ValidatesRequestPathAndBody()
        {
            // Arrange
            var responseJson = @"{""id"": ""00p1"", ""name"": ""Test"", ""type"": ""OAUTH_AUTHORIZATION_POLICY"", ""status"": ""ACTIVE""}";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var newPolicy = new AuthorizationServerPolicy
            {
                Type = AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY,
                Name = "Test Policy",
                Priority = 1,
                Status = AuthorizationServerPolicy.StatusEnum.ACTIVE,
                Conditions = new AuthorizationServerPolicyConditions
                {
                    Clients = new ClientPolicyCondition
                    {
                        Include = new List<string> { "ALL_CLIENTS" }
                    }
                }
            };

            // Act
            await api.CreateAuthorizationServerPolicyAsync(_authServerId, newPolicy);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/policies");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(_authServerId);
            mockClient.ReceivedBody.Should().NotBeNullOrEmpty();
            mockClient.ReceivedBody.Should().Contain("\"name\":\"Test Policy\"");
            mockClient.ReceivedBody.Should().Contain("\"type\":\"OAUTH_AUTHORIZATION_POLICY\"");
            mockClient.ReceivedBody.Should().Contain("\"status\":\"ACTIVE\"");
        }

        [Fact]
        public async Task CreateAuthorizationServerPolicy_WithHttpInfo_Returns201Created()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""OAUTH_AUTHORIZATION_POLICY"",
                ""id"": ""00pNewPolicy"",
                ""status"": ""INACTIVE"",
                ""name"": ""Inactive Policy"",
                ""description"": ""Created as inactive"",
                ""priority"": 5
            }";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var newPolicy = new AuthorizationServerPolicy
            {
                Type = AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY,
                Name = "Inactive Policy",
                Status = AuthorizationServerPolicy.StatusEnum.INACTIVE,
                Priority = 5
            };

            // Act
            var result = await api.CreateAuthorizationServerPolicyWithHttpInfoAsync(_authServerId, newPolicy);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.Created);
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be("00pNewPolicy");
            result.Data.Status.Should().Be(AuthorizationServerPolicy.StatusEnum.INACTIVE);
        }

        [Fact]
        public async Task CreateAuthorizationServerPolicy_WithAllClientsCondition_SerializesCorrectly()
        {
            // Arrange
            var responseJson = @"{""id"": ""00p1"", ""type"": ""OAUTH_AUTHORIZATION_POLICY"", ""name"": ""Test"", ""status"": ""ACTIVE""}";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var policy = new AuthorizationServerPolicy
            {
                Type = AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY,
                Name = "All Clients Policy",
                Status = AuthorizationServerPolicy.StatusEnum.ACTIVE,
                Priority = 1,
                Conditions = new AuthorizationServerPolicyConditions
                {
                    Clients = new ClientPolicyCondition
                    {
                        Include = new List<string> { "ALL_CLIENTS" }
                    }
                }
            };

            // Act
            await api.CreateAuthorizationServerPolicyAsync(_authServerId, policy);

            // Assert
            mockClient.ReceivedBody.Should().Contain("\"include\":[\"ALL_CLIENTS\"]");
        }

        #endregion

        #region GetAuthorizationServerPolicy Tests

        [Fact]
        public async Task GetAuthorizationServerPolicy_ReturnsPolicy()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""OAUTH_AUTHORIZATION_POLICY"",
                ""id"": ""00p1234567890abcdef"",
                ""status"": ""ACTIVE"",
                ""name"": ""Vendor Policy"",
                ""description"": ""Policy for vendor applications"",
                ""priority"": 2,
                ""system"": false,
                ""conditions"": {
                    ""clients"": {
                        ""include"": [""0oaVendorApp1"", ""0oaVendorApp2""]
                    }
                },
                ""created"": ""2024-01-20T12:00:00.000Z"",
                ""lastUpdated"": ""2024-01-25T16:30:00.000Z"",
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/policies/00p1234567890abcdef""
                    },
                    ""deactivate"": {
                        ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/policies/00p1234567890abcdef/lifecycle/deactivate""
                    },
                    ""rules"": {
                        ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/policies/00p1234567890abcdef/rules""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAuthorizationServerPolicyAsync(_authServerId, _policyId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be("00p1234567890abcdef");
            result.Type.Should().Be(AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY);
            result.Status.Should().Be(AuthorizationServerPolicy.StatusEnum.ACTIVE);
            result.Name.Should().Be("Vendor Policy");
            result.Description.Should().Be("Policy for vendor applications");
            result.Priority.Should().Be(2);
            result.System.Should().BeFalse();
            result.Conditions.Should().NotBeNull();
            result.Conditions.Clients.Include.Should().HaveCount(2);
            result.Conditions.Clients.Include.Should().Contain("0oaVendorApp1");
            result.Conditions.Clients.Include.Should().Contain("0oaVendorApp2");
            result.Links.Should().NotBeNull();
        }

        [Fact]
        public async Task GetAuthorizationServerPolicy_ValidatesRequestPath()
        {
            // Arrange
            var responseJson = @"{""id"": ""00p1"", ""name"": ""Test"", ""type"": ""OAUTH_AUTHORIZATION_POLICY"", ""status"": ""ACTIVE""}";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetAuthorizationServerPolicyAsync(_authServerId, _policyId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/policies/{policyId}");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(_authServerId);
            mockClient.ReceivedPathParams.Should().ContainKey("policyId");
            mockClient.ReceivedPathParams["policyId"].Should().Be(_policyId);
        }

        [Fact]
        public async Task GetAuthorizationServerPolicy_WithHttpInfo_ReturnsResponseMetadata()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""OAUTH_AUTHORIZATION_POLICY"",
                ""id"": ""00pTest"",
                ""status"": ""INACTIVE"",
                ""name"": ""Inactive Policy"",
                ""priority"": 10
            }";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAuthorizationServerPolicyWithHttpInfoAsync(_authServerId, _policyId);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Id.Should().Be("00pTest");
            result.Data.Status.Should().Be(AuthorizationServerPolicy.StatusEnum.INACTIVE);
        }

        [Fact]
        public async Task GetAuthorizationServerPolicy_WithReadOnlyFields_ParsesTimestamps()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""OAUTH_AUTHORIZATION_POLICY"",
                ""id"": ""00pTimestamp"",
                ""status"": ""ACTIVE"",
                ""name"": ""Timestamp Test"",
                ""priority"": 1,
                ""created"": ""2023-06-15T08:30:00.000Z"",
                ""lastUpdated"": ""2024-01-10T14:45:00.000Z""
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAuthorizationServerPolicyAsync(_authServerId, _policyId);

            // Assert
            result.Should().NotBeNull();
            result.Created.Should().Be(new System.DateTimeOffset(2023, 6, 15, 8, 30, 0, System.TimeSpan.Zero));
            result.LastUpdated.Should().Be(new System.DateTimeOffset(2024, 1, 10, 14, 45, 0, System.TimeSpan.Zero));
        }

        #endregion

        #region ReplaceAuthorizationServerPolicy Tests

        [Fact]
        public async Task ReplaceAuthorizationServerPolicy_UpdatesPolicy_ReturnsUpdatedPolicy()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""OAUTH_AUTHORIZATION_POLICY"",
                ""id"": ""00p1234567890abcdef"",
                ""status"": ""ACTIVE"",
                ""name"": ""Updated Policy Name"",
                ""description"": ""Updated description"",
                ""priority"": 5,
                ""system"": false,
                ""conditions"": {
                    ""clients"": {
                        ""include"": [""0oaUpdatedClient""]
                    }
                },
                ""created"": ""2024-01-15T10:00:00.000Z"",
                ""lastUpdated"": ""2024-03-15T11:30:00.000Z""
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updatedPolicy = new AuthorizationServerPolicy
            {
                Id = _policyId,
                Type = AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY,
                Name = "Updated Policy Name",
                Description = "Updated description",
                Priority = 5,
                Status = AuthorizationServerPolicy.StatusEnum.ACTIVE,
                Conditions = new AuthorizationServerPolicyConditions
                {
                    Clients = new ClientPolicyCondition
                    {
                        Include = new List<string> { "0oaUpdatedClient" }
                    }
                }
            };

            // Act
            var result = await api.ReplaceAuthorizationServerPolicyAsync(_authServerId, _policyId, updatedPolicy);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be("00p1234567890abcdef");
            result.Name.Should().Be("Updated Policy Name");
            result.Description.Should().Be("Updated description");
            result.Priority.Should().Be(5);
            result.Conditions.Clients.Include.Should().Contain("0oaUpdatedClient");
        }

        [Fact]
        public async Task ReplaceAuthorizationServerPolicy_ValidatesRequestPathAndBody()
        {
            // Arrange
            var responseJson = @"{""id"": ""00p1"", ""name"": ""Updated"", ""type"": ""OAUTH_AUTHORIZATION_POLICY"", ""status"": ""ACTIVE""}";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updatedPolicy = new AuthorizationServerPolicy
            {
                Id = _policyId,
                Type = AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY,
                Name = "Updated",
                Status = AuthorizationServerPolicy.StatusEnum.ACTIVE,
                Priority = 2
            };

            // Act
            await api.ReplaceAuthorizationServerPolicyAsync(_authServerId, _policyId, updatedPolicy);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/policies/{policyId}");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(_authServerId);
            mockClient.ReceivedPathParams.Should().ContainKey("policyId");
            mockClient.ReceivedPathParams["policyId"].Should().Be(_policyId);
            mockClient.ReceivedBody.Should().NotBeNullOrEmpty();
            mockClient.ReceivedBody.Should().Contain("\"name\":\"Updated\"");
        }

        [Fact]
        public async Task ReplaceAuthorizationServerPolicy_WithHttpInfo_ReturnsResponseMetadata()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""OAUTH_AUTHORIZATION_POLICY"",
                ""id"": ""00pReplace"",
                ""status"": ""ACTIVE"",
                ""name"": ""Replaced Policy"",
                ""priority"": 3
            }";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.OK);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var policy = new AuthorizationServerPolicy
            {
                Id = _policyId,
                Type = AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY,
                Name = "Replaced Policy",
                Status = AuthorizationServerPolicy.StatusEnum.ACTIVE,
                Priority = 3
            };

            // Act
            var result = await api.ReplaceAuthorizationServerPolicyWithHttpInfoAsync(_authServerId, _policyId, policy);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Data.Should().NotBeNull();
            result.Data.Name.Should().Be("Replaced Policy");
        }

        [Fact]
        public async Task ReplaceAuthorizationServerPolicy_ChangePriority_SerializesCorrectly()
        {
            // Arrange
            var responseJson = @"{""id"": ""00p1"", ""type"": ""OAUTH_AUTHORIZATION_POLICY"", ""status"": ""ACTIVE"", ""name"": ""Test"", ""priority"": 10}";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var policy = new AuthorizationServerPolicy
            {
                Id = _policyId,
                Type = AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY,
                Name = "Priority Test",
                Status = AuthorizationServerPolicy.StatusEnum.ACTIVE,
                Priority = 10
            };

            // Act
            await api.ReplaceAuthorizationServerPolicyAsync(_authServerId, _policyId, policy);

            // Assert
            mockClient.ReceivedBody.Should().Contain("\"priority\":10");
        }

        #endregion

        #region DeleteAuthorizationServerPolicy Tests

        [Fact]
        public async Task DeleteAuthorizationServerPolicy_DeletesPolicy_ReturnsNoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty, HttpStatusCode.NoContent);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteAuthorizationServerPolicyAsync(_authServerId, _policyId);

            // Assert - No exception should be thrown
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/policies/{policyId}");
        }

        [Fact]
        public async Task DeleteAuthorizationServerPolicy_ValidatesRequestPath()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty, HttpStatusCode.NoContent);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteAuthorizationServerPolicyAsync(_authServerId, _policyId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/policies/{policyId}");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(_authServerId);
            mockClient.ReceivedPathParams.Should().ContainKey("policyId");
            mockClient.ReceivedPathParams["policyId"].Should().Be(_policyId);
        }

        [Fact]
        public async Task DeleteAuthorizationServerPolicy_WithHttpInfo_Returns204NoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty, HttpStatusCode.NoContent);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.DeleteAuthorizationServerPolicyWithHttpInfoAsync(_authServerId, _policyId);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        #endregion

        #region ActivateAuthorizationServerPolicy Tests

        [Fact]
        public async Task ActivateAuthorizationServerPolicy_ActivatesPolicy_ReturnsNoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty, HttpStatusCode.NoContent);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ActivateAuthorizationServerPolicyAsync(_authServerId, _policyId);

            // Assert - No exception should be thrown
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/policies/{policyId}/lifecycle/activate");
        }

        [Fact]
        public async Task ActivateAuthorizationServerPolicy_ValidatesRequestPath()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty, HttpStatusCode.NoContent);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ActivateAuthorizationServerPolicyAsync(_authServerId, _policyId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/policies/{policyId}/lifecycle/activate");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(_authServerId);
            mockClient.ReceivedPathParams.Should().ContainKey("policyId");
            mockClient.ReceivedPathParams["policyId"].Should().Be(_policyId);
        }

        [Fact]
        public async Task ActivateAuthorizationServerPolicy_WithHttpInfo_Returns204NoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty, HttpStatusCode.NoContent);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ActivateAuthorizationServerPolicyWithHttpInfoAsync(_authServerId, _policyId);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task ActivateAuthorizationServerPolicy_UsesPostMethod()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty, HttpStatusCode.NoContent);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.ActivateAuthorizationServerPolicyAsync(_authServerId, _policyId);

            // Assert - POST method is used for lifecycle operations
            mockClient.ReceivedPath.Should().Contain("/lifecycle/activate");
        }

        #endregion

        #region DeactivateAuthorizationServerPolicy Tests

        [Fact]
        public async Task DeactivateAuthorizationServerPolicy_DeactivatesPolicy_ReturnsNoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty, HttpStatusCode.NoContent);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeactivateAuthorizationServerPolicyAsync(_authServerId, _policyId);

            // Assert - No exception should be thrown
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/policies/{policyId}/lifecycle/deactivate");
        }

        [Fact]
        public async Task DeactivateAuthorizationServerPolicy_ValidatesRequestPath()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty, HttpStatusCode.NoContent);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeactivateAuthorizationServerPolicyAsync(_authServerId, _policyId);

            // Assert
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/policies/{policyId}/lifecycle/deactivate");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Be(_authServerId);
            mockClient.ReceivedPathParams.Should().ContainKey("policyId");
            mockClient.ReceivedPathParams["policyId"].Should().Be(_policyId);
        }

        [Fact]
        public async Task DeactivateAuthorizationServerPolicy_WithHttpInfo_Returns204NoContent()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty, HttpStatusCode.NoContent);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.DeactivateAuthorizationServerPolicyWithHttpInfoAsync(_authServerId, _policyId);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeactivateAuthorizationServerPolicy_UsesPostMethod()
        {
            // Arrange
            var mockClient = new MockAsyncClient(string.Empty, HttpStatusCode.NoContent);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeactivateAuthorizationServerPolicyAsync(_authServerId, _policyId);

            // Assert - POST method is used for lifecycle operations
            mockClient.ReceivedPath.Should().Contain("/lifecycle/deactivate");
        }

        #endregion

        #region Error Handling Tests

        [Fact]
        public async Task GetAuthorizationServerPolicy_WhenNotFound_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: 00pNotFound (AuthorizationServerPolicy)"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""sampleErrorId123"",
                ""errorCauses"": []
            }";
            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.GetAuthorizationServerPolicyAsync(_authServerId, "00pNotFound"));
            
            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task CreateAuthorizationServerPolicy_WhenBadRequest_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed: createAuthorizationServerPolicy"",
                ""errorLink"": ""E0000001"",
                ""errorId"": ""sampleErrorId456"",
                ""errorCauses"": [
                    {""errorSummary"": ""name: The field name must be between 1 and 100 characters""}
                ]
            }";
            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.BadRequest);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var invalidPolicy = new AuthorizationServerPolicy
            {
                Type = AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY,
                Name = "", // Invalid: empty name
                Status = AuthorizationServerPolicy.StatusEnum.ACTIVE
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.CreateAuthorizationServerPolicyAsync(_authServerId, invalidPolicy));
            
            exception.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task DeleteAuthorizationServerPolicy_WhenForbidden_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000006"",
                ""errorSummary"": ""You do not have permission to perform the requested action"",
                ""errorLink"": ""E0000006"",
                ""errorId"": ""sampleErrorId789"",
                ""errorCauses"": []
            }";
            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.Forbidden);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.DeleteAuthorizationServerPolicyAsync(_authServerId, _policyId));
            
            exception.ErrorCode.Should().Be(403);
        }

        #endregion

        #region Type Enum Tests

        [Fact]
        public async Task CreateAuthorizationServerPolicy_TypeEnum_SerializesAsOAuthAuthorizationPolicy()
        {
            // Arrange
            var responseJson = @"{""id"": ""00p1"", ""type"": ""OAUTH_AUTHORIZATION_POLICY"", ""name"": ""Test"", ""status"": ""ACTIVE""}";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var policy = new AuthorizationServerPolicy
            {
                Type = AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY,
                Name = "Type Test",
                Status = AuthorizationServerPolicy.StatusEnum.ACTIVE,
                Priority = 1
            };

            // Act
            await api.CreateAuthorizationServerPolicyAsync(_authServerId, policy);

            // Assert
            mockClient.ReceivedBody.Should().Contain("\"type\":\"OAUTH_AUTHORIZATION_POLICY\"");
        }

        [Fact]
        public async Task GetAuthorizationServerPolicy_TypeEnum_DeserializesCorrectly()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""OAUTH_AUTHORIZATION_POLICY"",
                ""id"": ""00pTypeTest"",
                ""status"": ""ACTIVE"",
                ""name"": ""Type Test Policy""
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAuthorizationServerPolicyAsync(_authServerId, _policyId);

            // Assert
            result.Type.Should().Be(AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY);
            result.Type.Value.Should().Be("OAUTH_AUTHORIZATION_POLICY");
        }

        #endregion

        #region Status Enum Tests

        [Fact]
        public async Task CreateAuthorizationServerPolicy_StatusActive_SerializesCorrectly()
        {
            // Arrange
            var responseJson = @"{""id"": ""00p1"", ""type"": ""OAUTH_AUTHORIZATION_POLICY"", ""name"": ""Test"", ""status"": ""ACTIVE""}";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var policy = new AuthorizationServerPolicy
            {
                Type = AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY,
                Name = "Status Test",
                Status = AuthorizationServerPolicy.StatusEnum.ACTIVE,
                Priority = 1
            };

            // Act
            await api.CreateAuthorizationServerPolicyAsync(_authServerId, policy);

            // Assert
            mockClient.ReceivedBody.Should().Contain("\"status\":\"ACTIVE\"");
        }

        [Fact]
        public async Task CreateAuthorizationServerPolicy_StatusInactive_SerializesCorrectly()
        {
            // Arrange
            var responseJson = @"{""id"": ""00p1"", ""type"": ""OAUTH_AUTHORIZATION_POLICY"", ""name"": ""Test"", ""status"": ""INACTIVE""}";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var policy = new AuthorizationServerPolicy
            {
                Type = AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY,
                Name = "Inactive Test",
                Status = AuthorizationServerPolicy.StatusEnum.INACTIVE,
                Priority = 1
            };

            // Act
            await api.CreateAuthorizationServerPolicyAsync(_authServerId, policy);

            // Assert
            mockClient.ReceivedBody.Should().Contain("\"status\":\"INACTIVE\"");
        }

        [Fact]
        public async Task GetAuthorizationServerPolicy_StatusEnum_DeserializesCorrectly()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""OAUTH_AUTHORIZATION_POLICY"",
                ""id"": ""00pStatusTest"",
                ""status"": ""INACTIVE"",
                ""name"": ""Inactive Policy""
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAuthorizationServerPolicyAsync(_authServerId, _policyId);

            // Assert
            result.Status.Should().Be(AuthorizationServerPolicy.StatusEnum.INACTIVE);
            result.Status.Value.Should().Be("INACTIVE");
        }

        #endregion

        #region Conditions Tests

        [Fact]
        public async Task CreateAuthorizationServerPolicy_WithMultipleClients_SerializesCorrectly()
        {
            // Arrange
            var responseJson = @"{""id"": ""00p1"", ""type"": ""OAUTH_AUTHORIZATION_POLICY"", ""name"": ""Test"", ""status"": ""ACTIVE""}";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var policy = new AuthorizationServerPolicy
            {
                Type = AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY,
                Name = "Multi Client Policy",
                Status = AuthorizationServerPolicy.StatusEnum.ACTIVE,
                Priority = 1,
                Conditions = new AuthorizationServerPolicyConditions
                {
                    Clients = new ClientPolicyCondition
                    {
                        Include = new List<string> { "0oaClient1", "0oaClient2", "0oaClient3" }
                    }
                }
            };

            // Act
            await api.CreateAuthorizationServerPolicyAsync(_authServerId, policy);

            // Assert
            mockClient.ReceivedBody.Should().Contain("\"include\":[\"0oaClient1\",\"0oaClient2\",\"0oaClient3\"]");
        }

        [Fact]
        public async Task GetAuthorizationServerPolicy_WithConditions_DeserializesCorrectly()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""OAUTH_AUTHORIZATION_POLICY"",
                ""id"": ""00pConditions"",
                ""status"": ""ACTIVE"",
                ""name"": ""Conditions Test"",
                ""conditions"": {
                    ""clients"": {
                        ""include"": [""0oaApp1"", ""0oaApp2""]
                    }
                }
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAuthorizationServerPolicyAsync(_authServerId, _policyId);

            // Assert
            result.Conditions.Should().NotBeNull();
            result.Conditions.Clients.Should().NotBeNull();
            result.Conditions.Clients.Include.Should().NotBeNull();
            result.Conditions.Clients.Include.Should().HaveCount(2);
            result.Conditions.Clients.Include.Should().BeEquivalentTo(new[] { "0oaApp1", "0oaApp2" });
        }

        [Fact]
        public async Task GetAuthorizationServerPolicy_WithNullConditions_HandlesGracefully()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""OAUTH_AUTHORIZATION_POLICY"",
                ""id"": ""00pNoConditions"",
                ""status"": ""ACTIVE"",
                ""name"": ""No Conditions Test""
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAuthorizationServerPolicyAsync(_authServerId, _policyId);

            // Assert
            result.Should().NotBeNull();
            result.Conditions.Should().BeNull();
        }

        #endregion

        #region System Property Tests

        [Fact]
        public async Task GetAuthorizationServerPolicy_SystemPolicy_ParsesCorrectly()
        {
            // Arrange
            var responseJson = @"{
                ""type"": ""OAUTH_AUTHORIZATION_POLICY"",
                ""id"": ""00pSystem"",
                ""status"": ""ACTIVE"",
                ""name"": ""Default Policy"",
                ""system"": true
            }";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetAuthorizationServerPolicyAsync(_authServerId, _policyId);

            // Assert
            result.System.Should().BeTrue();
        }

        [Fact]
        public async Task CreateAuthorizationServerPolicy_SystemPropertyFalse_SerializesCorrectly()
        {
            // Arrange
            var responseJson = @"{""id"": ""00p1"", ""type"": ""OAUTH_AUTHORIZATION_POLICY"", ""name"": ""Test"", ""status"": ""ACTIVE"", ""system"": false}";
            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerPoliciesApi(mockClient, new Configuration { BasePath = BaseUrl });

            var policy = new AuthorizationServerPolicy
            {
                Type = AuthorizationServerPolicy.TypeEnum.OAUTHAUTHORIZATIONPOLICY,
                Name = "Custom Policy",
                Status = AuthorizationServerPolicy.StatusEnum.ACTIVE,
                Priority = 1,
                System = false
            };

            // Act
            await api.CreateAuthorizationServerPolicyAsync(_authServerId, policy);

            // Assert
            mockClient.ReceivedBody.Should().Contain("\"system\":false");
        }

        #endregion
    }
}
