// <copyright file="PolicyApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
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
    /// Comprehensive unit tests for PolicyApi covering all 19 public methods.
    /// These tests use mocked HTTP responses to verify request/response handling
    /// without making actual API calls.
    /// </summary>
    public class PolicyApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _policyId = "00p1234567890undef";
        private readonly string _ruleId = "0pr9876543210feedback";
        private readonly string _mappingId = "00m1122334455667788";
        private readonly string _groupId = "00g1122334455667788";

        #region CreatePolicy Tests

        [Fact]
        public async Task CreatePolicy_WithValidData_ReturnsPolicy()
        {
            // Arrange
            const string policyName = "Test Policy";
            const string policyDescription = "Test policy description";

            var responseJson = $@"{{
                ""id"": ""{_policyId}"",
                ""type"": ""OKTA_SIGN_ON"",
                ""status"": ""ACTIVE"",
                ""name"": ""{policyName}"",
                ""description"": ""{policyDescription}"",
                ""priority"": 1,
                ""system"": false,
                ""created"": ""2025-10-26T12:00:00.000Z"",
                ""lastUpdated"": ""2025-10-26T12:00:00.000Z"",
                ""_links"": {{
                    ""self"": {{""href"": ""{BaseUrl}/api/v1/policies/{_policyId}""}},
                    ""rules"": {{""href"": ""{BaseUrl}/api/v1/policies/{_policyId}/rules""}}
                }}
            }}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var policy = new CreateOrUpdatePolicy
            {
                Name = policyName,
                Type = PolicyType.OKTASIGNON,
                Status = LifecycleStatus.ACTIVE,
                Description = policyDescription
            };

            // Act
            var result = await policyApi.CreatePolicyAsync(policy, activate: true);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(_policyId);
            result.Name.Should().Be(policyName);
            result.Type.Should().Be(PolicyType.OKTASIGNON);
            result.Status.Should().Be(LifecycleStatus.ACTIVE);

            mockClient.ReceivedPath.Should().Be("/api/v1/policies");
            mockClient.ReceivedBody.Should().Contain(policyName);
            mockClient.ReceivedBody.Should().Contain(policyDescription);
        }

        [Fact]
        public async Task CreatePolicyWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = $@"{{
                ""id"": ""{_policyId}"",
                ""type"": ""PASSWORD"",
                ""status"": ""ACTIVE"",
                ""name"": ""Password Policy"",
                ""created"": ""2025-10-26T12:00:00.000Z"",
                ""lastUpdated"": ""2025-10-26T12:00:00.000Z""
            }}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var policy = new CreateOrUpdatePolicy
            {
                Name = "Password Policy",
                Type = PolicyType.PASSWORD
            };

            // Act
            var response = await policyApi.CreatePolicyWithHttpInfoAsync(policy);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_policyId);
            response.Data.Type.Should().Be(PolicyType.PASSWORD);
        }

        #endregion

        #region GetPolicy Tests

        [Fact]
        public async Task GetPolicy_WithValidId_ReturnsPolicy()
        {
            // Arrange
            var responseJson = $@"{{
                ""id"": ""{_policyId}"",
                ""type"": ""OKTA_SIGN_ON"",
                ""status"": ""ACTIVE"",
                ""name"": ""Default Policy"",
                ""description"": ""Default sign-on policy"",
                ""priority"": 1,
                ""system"": false,
                ""created"": ""2025-10-26T12:00:00.000Z"",
                ""lastUpdated"": ""2025-10-26T12:00:00.000Z""
            }}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await policyApi.GetPolicyAsync(_policyId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(_policyId);
            result.Type.Should().Be(PolicyType.OKTASIGNON);
            result.Status.Should().Be(LifecycleStatus.ACTIVE);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/policies/{policyId}");
            mockClient.ReceivedPathParams.Should().ContainKey("policyId");
            mockClient.ReceivedPathParams["policyId"].Should().Contain(_policyId);
        }

        [Fact]
        public async Task GetPolicyWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = $@"{{
                ""id"": ""{_policyId}"",
                ""type"": ""PASSWORD"",
                ""status"": ""INACTIVE"",
                ""name"": ""Test Password Policy""
            }}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await policyApi.GetPolicyWithHttpInfoAsync(_policyId, expand: "rules");

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_policyId);

            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
        }

        #endregion

        #region ListPolicies Tests

        [Fact]
        public async Task ListPolicies_WithTypeFilter_ReturnsPolicyList()
        {
            // Arrange
            var responseJson = $@"[
                {{
                    ""id"": ""{_policyId}"",
                    ""type"": ""OKTA_SIGN_ON"",
                    ""status"": ""ACTIVE"",
                    ""name"": ""Policy 1"",
                    ""created"": ""2025-10-26T12:00:00.000Z"",
                    ""lastUpdated"": ""2025-10-26T12:00:00.000Z""
                }},
                {{
                    ""id"": ""00p2234567890undef"",
                    ""type"": ""OKTA_SIGN_ON"",
                    ""status"": ""ACTIVE"",
                    ""name"": ""Policy 2"",
                    ""created"": ""2025-10-26T13:00:00.000Z"",
                    ""lastUpdated"": ""2025-10-26T13:00:00.000Z""
                }}
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await policyApi.ListPoliciesWithHttpInfoAsync(PolicyTypeParameter.OKTASIGNON, status: "ACTIVE");

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
            result.Data[0].Id.Should().Be(_policyId);
            result.Data[0].Type.Should().Be(PolicyType.OKTASIGNON);

            mockClient.ReceivedPath.Should().Be("/api/v1/policies");
            mockClient.ReceivedQueryParams.Should().ContainKey("type");
            mockClient.ReceivedQueryParams["type"].Should().Contain("OKTA_SIGN_ON");
            mockClient.ReceivedQueryParams.Should().ContainKey("status");
        }

        [Fact]
        public async Task ListPoliciesWithHttpInfo_WithQueryParameters_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"[]";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await policyApi.ListPoliciesWithHttpInfoAsync(
                PolicyTypeParameter.PASSWORD,
                status: "INACTIVE",
                q: "test",
                expand: "rules",
                limit: "20");

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();

            mockClient.ReceivedQueryParams.Should().ContainKey("type");
            mockClient.ReceivedQueryParams.Should().ContainKey("status");
            mockClient.ReceivedQueryParams.Should().ContainKey("q");
            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
        }

        #endregion

        #region ReplacePolicy Tests

        [Fact]
        public async Task ReplacePolicy_WithValidData_ReturnsUpdatedPolicy()
        {
            // Arrange
            const string updatedName = "Updated Policy Name";

            var responseJson = $@"{{
                ""id"": ""{_policyId}"",
                ""type"": ""OKTA_SIGN_ON"",
                ""status"": ""ACTIVE"",
                ""name"": ""{updatedName}"",
                ""description"": ""Updated description"",
                ""created"": ""2025-10-26T12:00:00.000Z"",
                ""lastUpdated"": ""2025-10-26T14:00:00.000Z""
            }}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var policy = new CreateOrUpdatePolicy
            {
                Name = updatedName,
                Type = PolicyType.OKTASIGNON,
                Description = "Updated description"
            };

            // Act
            var result = await policyApi.ReplacePolicyAsync(_policyId, policy);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(_policyId);
            result.Name.Should().Be(updatedName);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/policies/{policyId}");
            mockClient.ReceivedPathParams["policyId"].Should().Contain(_policyId);
            mockClient.ReceivedBody.Should().Contain(updatedName);
        }

        [Fact]
        public async Task ReplacePolicyWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = $@"{{
                ""id"": ""{_policyId}"",
                ""type"": ""PASSWORD"",
                ""status"": ""ACTIVE"",
                ""name"": ""Replaced Policy""
            }}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var policy = new CreateOrUpdatePolicy { Name = "Replaced Policy", Type = PolicyType.PASSWORD };

            // Act
            var response = await policyApi.ReplacePolicyWithHttpInfoAsync(_policyId, policy);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Name.Should().Be("Replaced Policy");
        }

        #endregion

        #region DeletePolicy Tests

        [Fact]
        public async Task DeletePolicy_WithValidId_Succeeds()
        {
            // Arrange
            var responseJson = "{}";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await policyApi.DeletePolicyAsync(_policyId);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/policies/{policyId}");
            mockClient.ReceivedPathParams["policyId"].Should().Contain(_policyId);
        }

        [Fact]
        public async Task DeletePolicyWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = "{}";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await policyApi.DeletePolicyWithHttpInfoAsync(_policyId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        #endregion

        #region ActivatePolicy Tests

        [Fact]
        public async Task ActivatePolicy_WithValidId_Succeeds()
        {
            // Arrange
            var responseJson = "{}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await policyApi.ActivatePolicyAsync(_policyId);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/policies/{policyId}/lifecycle/activate");
            mockClient.ReceivedPathParams["policyId"].Should().Contain(_policyId);
        }

        [Fact]
        public async Task ActivatePolicyWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = "{}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await policyApi.ActivatePolicyWithHttpInfoAsync(_policyId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        #region DeactivatePolicy Tests

        [Fact]
        public async Task DeactivatePolicy_WithValidId_Succeeds()
        {
            // Arrange
            var responseJson = "{}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await policyApi.DeactivatePolicyAsync(_policyId);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/policies/{policyId}/lifecycle/deactivate");
            mockClient.ReceivedPathParams["policyId"].Should().Contain(_policyId);
        }

        [Fact]
        public async Task DeactivatePolicyWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = "{}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await policyApi.DeactivatePolicyWithHttpInfoAsync(_policyId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        #region ClonePolicy Tests

        [Fact]
        public async Task ClonePolicy_WithValidId_ReturnsClonedPolicy()
        {
            // Arrange
            var responseJson = $@"{{
                ""id"": ""00p9999888877776666"",
                ""type"": ""OKTA_SIGN_ON"",
                ""status"": ""ACTIVE"",
                ""name"": ""Copy of Original Policy"",
                ""description"": ""Cloned policy"",
                ""created"": ""2025-10-26T15:00:00.000Z"",
                ""lastUpdated"": ""2025-10-26T15:00:00.000Z""
            }}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await policyApi.ClonePolicyAsync(_policyId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().NotBe(_policyId); // Cloned policy has different ID
            result.Name.Should().Contain("Copy of");

            mockClient.ReceivedPath.Should().StartWith("/api/v1/policies/{policyId}/clone");
            mockClient.ReceivedPathParams["policyId"].Should().Contain(_policyId);
        }

        [Fact]
        public async Task ClonePolicyWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = $@"{{
                ""id"": ""00p9999888877776666"",
                ""type"": ""PASSWORD"",
                ""status"": ""ACTIVE"",
                ""name"": ""Cloned Password Policy""
            }}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await policyApi.ClonePolicyWithHttpInfoAsync(_policyId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Name.Should().Contain("Cloned");
        }

        #endregion

        #region CreatePolicyRule Tests

        [Fact]
        public async Task CreatePolicyRule_WithValidData_ReturnsPolicyRule()
        {
            // Arrange
            const string ruleName = "Test Rule";

            var responseJson = $@"{{
                ""type"": ""SIGN_ON"",
                ""id"": ""{_ruleId}"",
                ""status"": ""ACTIVE"",
                ""name"": ""{ruleName}"",
                ""priority"": 1,
                ""created"": ""2025-10-26T12:00:00.000Z"",
                ""lastUpdated"": ""2025-10-26T12:00:00.000Z"",
                ""system"": false,
                ""conditions"": {{}},
                ""actions"": {{}}
            }}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var policyRule = new OktaSignOnPolicyRule
            {
                Name = ruleName,
                Type = PolicyRuleType.SIGNON,
                Actions = new OktaSignOnPolicyRuleActions
                {
                    Signon = new OktaSignOnPolicyRuleSignonActions
                    {
                        Access = OktaSignOnPolicyRuleSignonActions.AccessEnum.ALLOW,
                        RequireFactor = false
                    }
                }
            };

            // Act
            var result = await policyApi.CreatePolicyRuleAsync(_policyId, policyRule);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(_ruleId);
            result.Name.Should().Be(ruleName);
            result.Status.Should().Be(LifecycleStatus.ACTIVE);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/policies/{policyId}/rules");
            mockClient.ReceivedPathParams["policyId"].Should().Contain(_policyId);
            mockClient.ReceivedBody.Should().Contain(ruleName);
        }

        [Fact]
        public async Task CreatePolicyRuleWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = $@"{{
                ""type"": ""PASSWORD"",
                ""id"": ""{_ruleId}"",
                ""status"": ""ACTIVE"",
                ""name"": ""Password Rule""
            }}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var policyRule = new PasswordPolicyRule
            {
                Name = "Password Rule",
                Type = PolicyRuleType.PASSWORD
            };

            // Act
            var response = await policyApi.CreatePolicyRuleWithHttpInfoAsync(
                _policyId,
                policyRule,
                limit: "10",
                activate: true);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_ruleId);

            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams.Should().ContainKey("activate");
        }

        #endregion

        #region GetPolicyRule Tests

        [Fact]
        public async Task GetPolicyRule_WithValidIds_ReturnsPolicyRule()
        {
            // Arrange
            var responseJson = $@"{{
                ""type"": ""SIGN_ON"",
                ""id"": ""{_ruleId}"",
                ""status"": ""ACTIVE"",
                ""name"": ""Default Rule"",
                ""priority"": 1,
                ""created"": ""2025-10-26T12:00:00.000Z"",
                ""lastUpdated"": ""2025-10-26T12:00:00.000Z""
            }}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await policyApi.GetPolicyRuleAsync(_policyId, _ruleId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(_ruleId);
            result.Status.Should().Be(LifecycleStatus.ACTIVE);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/policies/{policyId}/rules/{ruleId}");
            mockClient.ReceivedPathParams["policyId"].Should().Contain(_policyId);
            mockClient.ReceivedPathParams["ruleId"].Should().Contain(_ruleId);
        }

        [Fact]
        public async Task GetPolicyRuleWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = $@"{{
                ""type"": ""PASSWORD"",
                ""id"": ""{_ruleId}"",
                ""status"": ""INACTIVE"",
                ""name"": ""Test Password Rule""
            }}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await policyApi.GetPolicyRuleWithHttpInfoAsync(_policyId, _ruleId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_ruleId);
        }

        #endregion

        #region ListPolicyRules Tests

        [Fact]
        public async Task ListPolicyRules_WithPolicyId_ReturnsRulesList()
        {
            // Arrange
            var responseJson = $@"[
                {{
                    ""type"": ""SIGN_ON"",
                    ""id"": ""{_ruleId}"",
                    ""status"": ""ACTIVE"",
                    ""name"": ""Rule 1"",
                    ""priority"": 1
                }},
                {{
                    ""type"": ""SIGN_ON"",
                    ""id"": ""0pr1111222233334444"",
                    ""status"": ""ACTIVE"",
                    ""name"": ""Rule 2"",
                    ""priority"": 2
                }}
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await policyApi.ListPolicyRulesWithHttpInfoAsync(_policyId);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
            result.Data[0].Id.Should().Be(_ruleId);
            result.Data[0].Priority.Should().Be(1);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/policies/{policyId}/rules");
            mockClient.ReceivedPathParams["policyId"].Should().Contain(_policyId);
        }

        [Fact]
        public async Task ListPolicyRulesWithHttpInfo_WithLimit_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"[]";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await policyApi.ListPolicyRulesWithHttpInfoAsync(_policyId, limit: "50");

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();

            mockClient.ReceivedQueryParams.Should().ContainKey("limit");
            mockClient.ReceivedQueryParams["limit"].Should().Contain("50");
        }

        #endregion

        #region ReplacePolicyRule Tests

        [Fact]
        public async Task ReplacePolicyRule_WithValidData_ReturnsUpdatedRule()
        {
            // Arrange
            const string updatedRuleName = "Updated Rule Name";

            var responseJson = $@"{{
                ""type"": ""SIGN_ON"",
                ""id"": ""{_ruleId}"",
                ""status"": ""ACTIVE"",
                ""name"": ""{updatedRuleName}"",
                ""priority"": 1,
                ""created"": ""2025-10-26T12:00:00.000Z"",
                ""lastUpdated"": ""2025-10-26T16:00:00.000Z""
            }}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var policyRule = new OktaSignOnPolicyRule
            {
                Name = updatedRuleName,
                Type = PolicyRuleType.SIGNON
            };

            // Act
            var result = await policyApi.ReplacePolicyRuleAsync(_policyId, _ruleId, policyRule);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(_ruleId);
            result.Name.Should().Be(updatedRuleName);

            mockClient.ReceivedPath.Should().StartWith("/api/v1/policies/{policyId}/rules/{ruleId}");
            mockClient.ReceivedPathParams["policyId"].Should().Contain(_policyId);
            mockClient.ReceivedPathParams["ruleId"].Should().Contain(_ruleId);
            mockClient.ReceivedBody.Should().Contain(updatedRuleName);
        }

        [Fact]
        public async Task ReplacePolicyRuleWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = $@"{{
                ""type"": ""PASSWORD"",
                ""id"": ""{_ruleId}"",
                ""status"": ""ACTIVE"",
                ""name"": ""Replaced Rule""
            }}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var policyRule = new PasswordPolicyRule
            {
                Name = "Replaced Rule",
                Type = PolicyRuleType.PASSWORD
            };

            // Act
            var response = await policyApi.ReplacePolicyRuleWithHttpInfoAsync(_policyId, _ruleId, policyRule);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Name.Should().Be("Replaced Rule");
        }

        #endregion

        #region DeletePolicyRule Tests

        [Fact]
        public async Task DeletePolicyRule_WithValidIds_Succeeds()
        {
            // Arrange
            var responseJson = "{}";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await policyApi.DeletePolicyRuleAsync(_policyId, _ruleId);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/policies/{policyId}/rules/{ruleId}");
            mockClient.ReceivedPathParams["policyId"].Should().Contain(_policyId);
            mockClient.ReceivedPathParams["ruleId"].Should().Contain(_ruleId);
        }

        [Fact]
        public async Task DeletePolicyRuleWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = "{}";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await policyApi.DeletePolicyRuleWithHttpInfoAsync(_policyId, _ruleId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        #endregion

        #region ActivatePolicyRule Tests

        [Fact]
        public async Task ActivatePolicyRule_WithValidIds_Succeeds()
        {
            // Arrange
            var responseJson = "{}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await policyApi.ActivatePolicyRuleAsync(_policyId, _ruleId);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/policies/{policyId}/rules/{ruleId}/lifecycle/activate");
            mockClient.ReceivedPathParams["policyId"].Should().Contain(_policyId);
            mockClient.ReceivedPathParams["ruleId"].Should().Contain(_ruleId);
        }

        [Fact]
        public async Task ActivatePolicyRuleWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = "{}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await policyApi.ActivatePolicyRuleWithHttpInfoAsync(_policyId, _ruleId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        #region DeactivatePolicyRule Tests

        [Fact]
        public async Task DeactivatePolicyRule_WithValidIds_Succeeds()
        {
            // Arrange
            var responseJson = "{}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await policyApi.DeactivatePolicyRuleAsync(_policyId, _ruleId);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/policies/{policyId}/rules/{ruleId}/lifecycle/deactivate");
            mockClient.ReceivedPathParams["policyId"].Should().Contain(_policyId);
            mockClient.ReceivedPathParams["ruleId"].Should().Contain(_ruleId);
        }

        [Fact]
        public async Task DeactivatePolicyRuleWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = "{}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await policyApi.DeactivatePolicyRuleWithHttpInfoAsync(_policyId, _ruleId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        #region MapResourceToPolicy Tests

        [Fact]
        public async Task MapResourceToPolicy_WithValidData_ReturnsPolicyMapping()
        {
            // Arrange
            var responseJson = $@"{{
                ""id"": ""{_mappingId}"",
                ""resourceId"": ""{_groupId}"",
                ""_links"": {{
                    ""self"": {{""href"": ""{BaseUrl}/api/v1/policies/{_policyId}/mappings/{_mappingId}""}}
                }}
            }}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var mappingRequest = new PolicyMappingRequest
            {
                ResourceId = _groupId
            };

            // Act
            var result = await policyApi.MapResourceToPolicyAsync(_policyId, mappingRequest);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(_mappingId);
            // Note: PolicyMapping only has ID and _links properties

            mockClient.ReceivedPath.Should().StartWith("/api/v1/policies/{policyId}/mappings");
            mockClient.ReceivedPathParams["policyId"].Should().Contain(_policyId);
            mockClient.ReceivedBody.Should().Contain(_groupId);
        }

        [Fact]
        public async Task MapResourceToPolicyWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = $@"{{
                ""id"": ""{_mappingId}"",
                ""resourceId"": ""{_groupId}""
            }}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var mappingRequest = new PolicyMappingRequest { ResourceId = _groupId };

            // Act
            var response = await policyApi.MapResourceToPolicyWithHttpInfoAsync(_policyId, mappingRequest);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_mappingId);
        }

        #endregion

        #region ListPolicyMappings Tests

        [Fact]
        public async Task ListPolicyMappings_WithPolicyId_ReturnsMappingsList()
        {
            // Arrange
            var responseJson = $@"[
                {{
                    ""id"": ""{_mappingId}"",
                    ""resourceId"": ""{_groupId}""
                }},
                {{
                    ""id"": ""00m2233445566778899"",
                    ""resourceId"": ""00g9988776655443322""
                }}
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await policyApi.ListPolicyMappingsWithHttpInfoAsync(_policyId);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
            result.Data[0].Id.Should().Be(_mappingId);
            // Note: PolicyMapping only has ID and _links properties

            mockClient.ReceivedPath.Should().StartWith("/api/v1/policies/{policyId}/mappings");
            mockClient.ReceivedPathParams["policyId"].Should().Contain(_policyId);
        }

        [Fact]
        public async Task ListPolicyMappingsWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"[]";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await policyApi.ListPolicyMappingsWithHttpInfoAsync(_policyId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        #endregion

        #region GetPolicyMapping Tests

        [Fact]
        public async Task GetPolicyMapping_WithValidIds_ReturnsPolicyMapping()
        {
            // Arrange
            var responseJson = $@"{{
                ""id"": ""{_mappingId}"",
                ""resourceId"": ""{_groupId}"",
                ""_links"": {{
                    ""self"": {{""href"": ""{BaseUrl}/api/v1/policies/{_policyId}/mappings/{_mappingId}""}}
                }}
            }}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await policyApi.GetPolicyMappingAsync(_policyId, _mappingId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(_mappingId);
            // Note: PolicyMapping only has ID and _links properties

            mockClient.ReceivedPath.Should().StartWith("/api/v1/policies/{policyId}/mappings/{mappingId}");
            mockClient.ReceivedPathParams["policyId"].Should().Contain(_policyId);
            mockClient.ReceivedPathParams["mappingId"].Should().Contain(_mappingId);
        }

        [Fact]
        public async Task GetPolicyMappingWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = $@"{{
                ""id"": ""{_mappingId}"",
                ""resourceId"": ""{_groupId}""
            }}";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await policyApi.GetPolicyMappingWithHttpInfoAsync(_policyId, _mappingId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_mappingId);
        }

        #endregion

        #region DeletePolicyResourceMapping Tests

        [Fact]
        public async Task DeletePolicyResourceMapping_WithValidIds_Succeeds()
        {
            // Arrange
            var responseJson = "{}";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await policyApi.DeletePolicyResourceMappingAsync(_policyId, _mappingId);

            // Assert
            mockClient.ReceivedPath.Should().StartWith("/api/v1/policies/{policyId}/mappings/{mappingId}");
            mockClient.ReceivedPathParams["policyId"].Should().Contain(_policyId);
            mockClient.ReceivedPathParams["mappingId"].Should().Contain(_mappingId);
        }

        [Fact]
        public async Task DeletePolicyResourceMappingWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = "{}";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.NoContent);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await policyApi.DeletePolicyResourceMappingWithHttpInfoAsync(_policyId, _mappingId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        #endregion

        #region ListPolicyApps Tests

        [Fact]
        [Obsolete("Obsolete")]
        public async Task ListPolicyApps_WithPolicyId_ReturnsApplicationsList()
        {
            // Arrange
            var appId = "0oa1234567890undef";

            var responseJson = $@"[
                {{
                    ""id"": ""{appId}"",
                    ""name"": ""test-app"",
                    ""label"": ""Test Application"",
                    ""status"": ""ACTIVE"",
                    ""created"": ""2025-10-26T12:00:00.000Z"",
                    ""lastUpdated"": ""2025-10-26T12:00:00.000Z""
                }}
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await policyApi.ListPolicyAppsWithHttpInfoAsync(_policyId);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();
            result.Data.Should().HaveCount(1);
            result.Data[0].Id.Should().Be(appId);
            result.Data[0].Label.Should().Be("Test Application");

            mockClient.ReceivedPath.Should().StartWith("/api/v1/policies/{policyId}/app");
            mockClient.ReceivedPathParams["policyId"].Should().Contain(_policyId);
        }

        [Fact]
        [Obsolete("Obsolete")]
        public async Task ListPolicyAppsWithHttpInfo_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"[]";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await policyApi.ListPolicyAppsWithHttpInfoAsync(_policyId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        #endregion

        #region CreatePolicySimulation Tests

        [Fact]
        public async Task CreatePolicySimulationWithHttpInfo_WithValidData_ReturnsSimulationResults()
        {
            // Arrange
            var responseJson = $@"[
                {{
                    ""status"": ""SUCCESS"",
                    ""policyType"": [""OKTA_SIGN_ON""],
                    ""result"": {{
                        ""policies"": []
                    }}
                }}
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var simulatePolicy = new List<SimulatePolicyBody>
            {
                new()
                {
                    PolicyTypes = [PolicyTypeSimulation.OKTASIGNON],
                    AppInstance = "test-app"
                }
            };

            // Act
            var result = await policyApi.CreatePolicySimulationWithHttpInfoAsync(simulatePolicy);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();
            result.Data.Should().HaveCount(1);

            mockClient.ReceivedPath.Should().Be("/api/v1/policies/simulate");
            mockClient.ReceivedBody.Should().Contain("OKTA_SIGN_ON");
        }

        [Fact]
        public async Task CreatePolicySimulationWithHttpInfo_WithExpand_ReturnsApiResponse()
        {
            // Arrange
            var responseJson = @"[]";

            var mockClient = new MockAsyncClient(responseJson);
            var policyApi = new PolicyApi(mockClient, new Configuration { BasePath = BaseUrl });

            var simulatePolicy = new List<SimulatePolicyBody>
            {
                new()
                {
                    PolicyTypes = [PolicyTypeSimulation.ACCESSPOLICY],
                    AppInstance = "app123"
                }
            };

            // Act
            var response = await policyApi.CreatePolicySimulationWithHttpInfoAsync(
                simulatePolicy,
                expand: "EVALUATED");

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();

            mockClient.ReceivedQueryParams.Should().ContainKey("expand");
            mockClient.ReceivedQueryParams["expand"].Should().Contain("EVALUATED");
        }

        #endregion
    }
}
