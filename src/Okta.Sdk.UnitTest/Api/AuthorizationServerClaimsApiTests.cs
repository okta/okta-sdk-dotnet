// <copyright file="AuthorizationServerClaimsApiTests.cs" company="Okta, Inc">
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
    /// Unit tests for AuthorizationServerClaimsApi covering all 5 endpoints.
    /// 
    /// API Coverage:
    /// 1. GET /api/v1/authorizationServers/{authServerId}/claims - ListOAuth2Claims
    /// 2. POST /api/v1/authorizationServers/{authServerId}/claims - CreateOAuth2ClaimAsync
    /// 3. GET /api/v1/authorizationServers/{authServerId}/claims/{claimId} - GetOAuth2ClaimAsync
    /// 4. PUT /api/v1/authorizationServers/{authServerId}/claims/{claimId} - ReplaceOAuth2ClaimAsync
    /// 5. DELETE /api/v1/authorizationServers/{authServerId}/claims/{claimId} - DeleteOAuth2ClaimAsync
    /// 
    /// Each method is tested with:
    /// - Regular async method
    /// - WithHttpInfo variant for response metadata
    /// - Proper request path and parameters validation
    /// - Response data validation
    /// </summary>
    public class AuthorizationServerClaimsApiTests
    {
        private const string BaseUrl = "https://test.okta.com";
        private readonly string _authServerId = "aus1234567890abcdef";
        private readonly string _claimId = "ocl1234567890abcdef";

        #region ListOAuth2Claims Tests

        [Fact]
        public async Task ListOAuth2Claims_ReturnsClaimsList()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""ocl1111111111111111"",
                    ""name"": ""sub"",
                    ""status"": ""ACTIVE"",
                    ""claimType"": ""RESOURCE"",
                    ""valueType"": ""SYSTEM"",
                    ""value"": ""(appuser != null) ? appuser.userName : app.clientId"",
                    ""alwaysIncludeInToken"": true,
                    ""system"": true,
                    ""_links"": {
                        ""self"": {
                            ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/claims/ocl1111111111111111""
                        }
                    }
                },
                {
                    ""id"": ""ocl2222222222222222"",
                    ""name"": ""custom_email"",
                    ""status"": ""ACTIVE"",
                    ""claimType"": ""RESOURCE"",
                    ""valueType"": ""EXPRESSION"",
                    ""value"": ""user.email"",
                    ""alwaysIncludeInToken"": true,
                    ""system"": false,
                    ""conditions"": {
                        ""scopes"": [""openid"", ""profile""]
                    }
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListOAuth2ClaimsWithHttpInfoAsync(_authServerId);

            // Assert
            result.Data.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
            
            // Verify system claim
            result.Data[0].Id.Should().Be("ocl1111111111111111");
            result.Data[0].Name.Should().Be("sub");
            result.Data[0].Status.Should().Be(LifecycleStatus.ACTIVE);
            result.Data[0].ClaimType.Should().Be(OAuth2ClaimType.RESOURCE);
            result.Data[0].ValueType.Should().Be(OAuth2ClaimValueType.SYSTEM);
            result.Data[0].System.Should().BeTrue();
            result.Data[0].AlwaysIncludeInToken.Should().BeTrue();

            // Verify custom claim
            result.Data[1].Id.Should().Be("ocl2222222222222222");
            result.Data[1].Name.Should().Be("custom_email");
            result.Data[1].ClaimType.Should().Be(OAuth2ClaimType.RESOURCE);
            result.Data[1].ValueType.Should().Be(OAuth2ClaimValueType.EXPRESSION);
            result.Data[1].Value.Should().Be("user.email");
            result.Data[1].System.Should().BeFalse();
            result.Data[1].Conditions.Should().NotBeNull();
            result.Data[1].Conditions.Scopes.Should().Contain("openid");
            result.Data[1].Conditions.Scopes.Should().Contain("profile");

            // Verify request path
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/claims");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(_authServerId);
        }

        [Fact]
        public async Task ListOAuth2Claims_WithIdentityClaims_ReturnsIdentityClaimType()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""oclIdentity123"",
                    ""name"": ""preferred_username"",
                    ""status"": ""ACTIVE"",
                    ""claimType"": ""IDENTITY"",
                    ""valueType"": ""EXPRESSION"",
                    ""value"": ""user.login"",
                    ""alwaysIncludeInToken"": false,
                    ""system"": false
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListOAuth2ClaimsWithHttpInfoAsync(_authServerId);

            // Assert
            result.Data.Should().HaveCount(1);
            result.Data[0].ClaimType.Should().Be(OAuth2ClaimType.IDENTITY);
            result.Data[0].AlwaysIncludeInToken.Should().BeFalse();
        }

        [Fact]
        public async Task ListOAuth2Claims_WithGroupsClaim_ReturnsGroupsValueTypeAndFilter()
        {
            // Arrange
            var responseJson = @"[
                {
                    ""id"": ""oclGroups123"",
                    ""name"": ""groups"",
                    ""status"": ""ACTIVE"",
                    ""claimType"": ""RESOURCE"",
                    ""valueType"": ""GROUPS"",
                    ""value"": "".*"",
                    ""group_filter_type"": ""REGEX"",
                    ""alwaysIncludeInToken"": true,
                    ""system"": false
                }
            ]";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListOAuth2ClaimsWithHttpInfoAsync(_authServerId);

            // Assert
            result.Data.Should().HaveCount(1);
            result.Data[0].ValueType.Should().Be(OAuth2ClaimValueType.GROUPS);
            result.Data[0].Value.Should().Be(".*");
            result.Data[0].GroupFilterType.Should().Be(OAuth2ClaimGroupFilterType.REGEX);
        }

        [Fact]
        public async Task ListOAuth2Claims_WhenEmpty_ReturnsEmptyList()
        {
            // Arrange
            var responseJson = "[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.ListOAuth2ClaimsWithHttpInfoAsync(_authServerId);

            // Assert
            result.Data.Should().NotBeNull();
            result.Data.Should().BeEmpty();
        }

        [Fact]
        public async Task ListOAuth2ClaimsWithHttpInfo_ReturnsCorrectStatusCode()
        {
            // Arrange
            var responseJson = "[]";
            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.ListOAuth2ClaimsWithHttpInfoAsync(_authServerId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        #region CreateOAuth2Claim Tests

        [Fact]
        public async Task CreateOAuth2ClaimAsync_WithResourceClaim_CreatesClaimAndReturnsData()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""oclNewClaim123"",
                ""name"": ""custom_email"",
                ""status"": ""ACTIVE"",
                ""claimType"": ""RESOURCE"",
                ""valueType"": ""EXPRESSION"",
                ""value"": ""user.email"",
                ""alwaysIncludeInToken"": true,
                ""system"": false,
                ""conditions"": {
                    ""scopes"": []
                },
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/claims/oclNewClaim123""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var newClaim = new OAuth2Claim
            {
                Name = "custom_email",
                ClaimType = OAuth2ClaimType.RESOURCE,
                ValueType = OAuth2ClaimValueType.EXPRESSION,
                Value = "user.email",
                AlwaysIncludeInToken = true
            };

            // Act
            var result = await api.CreateOAuth2ClaimAsync(_authServerId, newClaim);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be("oclNewClaim123");
            result.Name.Should().Be("custom_email");
            result.ClaimType.Should().Be(OAuth2ClaimType.RESOURCE);
            result.ValueType.Should().Be(OAuth2ClaimValueType.EXPRESSION);
            result.Value.Should().Be("user.email");
            result.AlwaysIncludeInToken.Should().BeTrue();
            result.System.Should().BeFalse();
            result.Status.Should().Be(LifecycleStatus.ACTIVE);

            // Verify request path
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/claims");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(_authServerId);
        }

        [Fact]
        public async Task CreateOAuth2ClaimAsync_WithIdentityClaim_CreatesClaimForIdToken()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""oclIdentityClaim"",
                ""name"": ""preferred_username"",
                ""status"": ""ACTIVE"",
                ""claimType"": ""IDENTITY"",
                ""valueType"": ""EXPRESSION"",
                ""value"": ""user.login"",
                ""alwaysIncludeInToken"": false,
                ""system"": false
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var newClaim = new OAuth2Claim
            {
                Name = "preferred_username",
                ClaimType = OAuth2ClaimType.IDENTITY,
                ValueType = OAuth2ClaimValueType.EXPRESSION,
                Value = "user.login",
                AlwaysIncludeInToken = false
            };

            // Act
            var result = await api.CreateOAuth2ClaimAsync(_authServerId, newClaim);

            // Assert
            result.ClaimType.Should().Be(OAuth2ClaimType.IDENTITY);
            result.AlwaysIncludeInToken.Should().BeFalse();
        }

        [Fact]
        public async Task CreateOAuth2ClaimAsync_WithGroupsClaim_CreatesClaimWithGroupFilter()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""oclGroupsClaim"",
                ""name"": ""groups"",
                ""status"": ""ACTIVE"",
                ""claimType"": ""RESOURCE"",
                ""valueType"": ""GROUPS"",
                ""value"": "".*"",
                ""group_filter_type"": ""REGEX"",
                ""alwaysIncludeInToken"": true,
                ""system"": false
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var newClaim = new OAuth2Claim
            {
                Name = "groups",
                ClaimType = OAuth2ClaimType.RESOURCE,
                ValueType = OAuth2ClaimValueType.GROUPS,
                Value = ".*",
                GroupFilterType = OAuth2ClaimGroupFilterType.REGEX,
                AlwaysIncludeInToken = true
            };

            // Act
            var result = await api.CreateOAuth2ClaimAsync(_authServerId, newClaim);

            // Assert
            result.ValueType.Should().Be(OAuth2ClaimValueType.GROUPS);
            result.GroupFilterType.Should().Be(OAuth2ClaimGroupFilterType.REGEX);
            result.Value.Should().Be(".*");
        }

        [Fact]
        public async Task CreateOAuth2ClaimAsync_WithScopeConditions_IncludesConditionsInResponse()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""oclWithScopes"",
                ""name"": ""scoped_claim"",
                ""status"": ""ACTIVE"",
                ""claimType"": ""RESOURCE"",
                ""valueType"": ""EXPRESSION"",
                ""value"": ""user.department"",
                ""alwaysIncludeInToken"": true,
                ""system"": false,
                ""conditions"": {
                    ""scopes"": [""openid"", ""profile"", ""custom_scope""]
                }
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var newClaim = new OAuth2Claim
            {
                Name = "scoped_claim",
                ClaimType = OAuth2ClaimType.RESOURCE,
                ValueType = OAuth2ClaimValueType.EXPRESSION,
                Value = "user.department",
                AlwaysIncludeInToken = true,
                Conditions = new OAuth2ClaimConditions
                {
                    Scopes = new List<string> { "openid", "profile", "custom_scope" }
                }
            };

            // Act
            var result = await api.CreateOAuth2ClaimAsync(_authServerId, newClaim);

            // Assert
            result.Conditions.Should().NotBeNull();
            result.Conditions.Scopes.Should().NotBeNull();
            result.Conditions.Scopes.Should().HaveCount(3);
            result.Conditions.Scopes.Should().Contain("openid");
            result.Conditions.Scopes.Should().Contain("profile");
            result.Conditions.Scopes.Should().Contain("custom_scope");
        }

        [Fact]
        public async Task CreateOAuth2ClaimWithHttpInfoAsync_ReturnsCreatedStatusCode()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""oclHttpInfo"",
                ""name"": ""test_claim"",
                ""status"": ""ACTIVE"",
                ""claimType"": ""RESOURCE"",
                ""valueType"": ""EXPRESSION"",
                ""value"": ""user.email"",
                ""alwaysIncludeInToken"": true,
                ""system"": false
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var newClaim = new OAuth2Claim
            {
                Name = "test_claim",
                ClaimType = OAuth2ClaimType.RESOURCE,
                ValueType = OAuth2ClaimValueType.EXPRESSION,
                Value = "user.email",
                AlwaysIncludeInToken = true
            };

            // Act
            var response = await api.CreateOAuth2ClaimWithHttpInfoAsync(_authServerId, newClaim);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be("oclHttpInfo");
        }

        [Fact]
        public async Task CreateOAuth2ClaimAsync_SendsCorrectRequestBody()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""oclReqBody"",
                ""name"": ""my_claim"",
                ""status"": ""ACTIVE"",
                ""claimType"": ""RESOURCE"",
                ""valueType"": ""EXPRESSION"",
                ""value"": ""user.firstName"",
                ""alwaysIncludeInToken"": false,
                ""system"": false
            }";

            var mockClient = new MockAsyncClient(responseJson, HttpStatusCode.Created);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var newClaim = new OAuth2Claim
            {
                Name = "my_claim",
                ClaimType = OAuth2ClaimType.RESOURCE,
                ValueType = OAuth2ClaimValueType.EXPRESSION,
                Value = "user.firstName",
                AlwaysIncludeInToken = false
            };

            // Act
            await api.CreateOAuth2ClaimAsync(_authServerId, newClaim);

            // Assert - Verify request body was sent
            mockClient.ReceivedBody.Should().NotBeNull();
            mockClient.ReceivedBody.Should().Contain("my_claim");
            mockClient.ReceivedBody.Should().Contain("user.firstName");
            mockClient.ReceivedBody.Should().Contain("\"alwaysIncludeInToken\":false");
        }

        #endregion

        #region GetOAuth2Claim Tests

        [Fact]
        public async Task GetOAuth2ClaimAsync_ReturnsClaimDetails()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""ocl1234567890abcdef"",
                ""name"": ""custom_email"",
                ""status"": ""ACTIVE"",
                ""claimType"": ""RESOURCE"",
                ""valueType"": ""EXPRESSION"",
                ""value"": ""user.email"",
                ""alwaysIncludeInToken"": true,
                ""system"": false,
                ""conditions"": {
                    ""scopes"": [""openid""]
                },
                ""_links"": {
                    ""self"": {
                        ""href"": ""https://test.okta.com/api/v1/authorizationServers/aus1234567890abcdef/claims/ocl1234567890abcdef""
                    }
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetOAuth2ClaimAsync(_authServerId, _claimId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be("ocl1234567890abcdef");
            result.Name.Should().Be("custom_email");
            result.Status.Should().Be(LifecycleStatus.ACTIVE);
            result.ClaimType.Should().Be(OAuth2ClaimType.RESOURCE);
            result.ValueType.Should().Be(OAuth2ClaimValueType.EXPRESSION);
            result.Value.Should().Be("user.email");
            result.AlwaysIncludeInToken.Should().BeTrue();
            result.System.Should().BeFalse();
            result.Conditions.Should().NotBeNull();
            result.Conditions.Scopes.Should().Contain("openid");
            result.Links.Should().NotBeNull();

            // Verify request path
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/claims/{claimId}");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(_authServerId);
            mockClient.ReceivedPathParams.Should().ContainKey("claimId");
            mockClient.ReceivedPathParams["claimId"].Should().Contain(_claimId);
        }

        [Fact]
        public async Task GetOAuth2ClaimAsync_WithSystemClaim_ReturnsSystemTrue()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""oclSystem"",
                ""name"": ""sub"",
                ""status"": ""ACTIVE"",
                ""claimType"": ""RESOURCE"",
                ""valueType"": ""SYSTEM"",
                ""value"": ""(appuser != null) ? appuser.userName : app.clientId"",
                ""alwaysIncludeInToken"": true,
                ""system"": true
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetOAuth2ClaimAsync(_authServerId, "oclSystem");

            // Assert
            result.System.Should().BeTrue();
            result.ValueType.Should().Be(OAuth2ClaimValueType.SYSTEM);
            result.Name.Should().Be("sub");
        }

        [Fact]
        public async Task GetOAuth2ClaimAsync_WithIdentityClaim_ReturnsIdentityType()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""oclIdentity"",
                ""name"": ""email"",
                ""status"": ""ACTIVE"",
                ""claimType"": ""IDENTITY"",
                ""valueType"": ""EXPRESSION"",
                ""value"": ""user.email"",
                ""alwaysIncludeInToken"": false,
                ""system"": false
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var result = await api.GetOAuth2ClaimAsync(_authServerId, "oclIdentity");

            // Assert
            result.ClaimType.Should().Be(OAuth2ClaimType.IDENTITY);
            result.AlwaysIncludeInToken.Should().BeFalse();
        }

        [Fact]
        public async Task GetOAuth2ClaimWithHttpInfoAsync_ReturnsOkStatusCode()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""oclHttpInfo"",
                ""name"": ""test"",
                ""status"": ""ACTIVE"",
                ""claimType"": ""RESOURCE"",
                ""valueType"": ""EXPRESSION"",
                ""value"": ""user.email"",
                ""alwaysIncludeInToken"": true,
                ""system"": false
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.GetOAuth2ClaimWithHttpInfoAsync(_authServerId, _claimId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be("oclHttpInfo");
        }

        [Fact]
        public async Task GetOAuth2ClaimAsync_WithDifferentAuthServerId_UsesCorrectPath()
        {
            // Arrange
            var customAuthServerId = "ausCustomServer99999";
            var customClaimId = "oclCustomClaim77777";
            var responseJson = @"{
                ""id"": ""oclCustomClaim77777"",
                ""name"": ""custom"",
                ""status"": ""ACTIVE"",
                ""claimType"": ""RESOURCE"",
                ""valueType"": ""EXPRESSION"",
                ""value"": ""user.email"",
                ""alwaysIncludeInToken"": true,
                ""system"": false
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.GetOAuth2ClaimAsync(customAuthServerId, customClaimId);

            // Assert
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(customAuthServerId);
            mockClient.ReceivedPathParams["claimId"].Should().Contain(customClaimId);
        }

        #endregion

        #region ReplaceOAuth2Claim Tests

        [Fact]
        public async Task ReplaceOAuth2ClaimAsync_UpdatesClaimAndReturnsUpdatedData()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""ocl1234567890abcdef"",
                ""name"": ""updated_claim"",
                ""status"": ""ACTIVE"",
                ""claimType"": ""RESOURCE"",
                ""valueType"": ""EXPRESSION"",
                ""value"": ""user.displayName"",
                ""alwaysIncludeInToken"": false,
                ""system"": false,
                ""conditions"": {
                    ""scopes"": [""openid"", ""profile""]
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updatedClaim = new OAuth2Claim
            {
                Name = "updated_claim",
                ClaimType = OAuth2ClaimType.RESOURCE,
                ValueType = OAuth2ClaimValueType.EXPRESSION,
                Value = "user.displayName",
                AlwaysIncludeInToken = false,
                Conditions = new OAuth2ClaimConditions
                {
                    Scopes = new List<string> { "openid", "profile" }
                }
            };

            // Act
            var result = await api.ReplaceOAuth2ClaimAsync(_authServerId, _claimId, updatedClaim);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be("ocl1234567890abcdef");
            result.Name.Should().Be("updated_claim");
            result.Value.Should().Be("user.displayName");
            result.AlwaysIncludeInToken.Should().BeFalse();
            result.Conditions.Should().NotBeNull();
            result.Conditions.Scopes.Should().Contain("openid");
            result.Conditions.Scopes.Should().Contain("profile");

            // Verify request path
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/claims/{claimId}");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(_authServerId);
            mockClient.ReceivedPathParams.Should().ContainKey("claimId");
            mockClient.ReceivedPathParams["claimId"].Should().Contain(_claimId);
        }

        [Fact]
        public async Task ReplaceOAuth2ClaimAsync_ChangeClaimType_ReturnsUpdatedType()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""oclTypeChange"",
                ""name"": ""email_claim"",
                ""status"": ""ACTIVE"",
                ""claimType"": ""IDENTITY"",
                ""valueType"": ""EXPRESSION"",
                ""value"": ""user.email"",
                ""alwaysIncludeInToken"": false,
                ""system"": false
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updatedClaim = new OAuth2Claim
            {
                Name = "email_claim",
                ClaimType = OAuth2ClaimType.IDENTITY,  // Changed from RESOURCE
                ValueType = OAuth2ClaimValueType.EXPRESSION,
                Value = "user.email",
                AlwaysIncludeInToken = false
            };

            // Act
            var result = await api.ReplaceOAuth2ClaimAsync(_authServerId, _claimId, updatedClaim);

            // Assert
            result.ClaimType.Should().Be(OAuth2ClaimType.IDENTITY);
        }

        [Fact]
        public async Task ReplaceOAuth2ClaimAsync_UpdateValueType_ReturnsUpdatedValueType()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""oclValueTypeChange"",
                ""name"": ""groups"",
                ""status"": ""ACTIVE"",
                ""claimType"": ""RESOURCE"",
                ""valueType"": ""GROUPS"",
                ""value"": ""Everyone"",
                ""group_filter_type"": ""STARTS_WITH"",
                ""alwaysIncludeInToken"": true,
                ""system"": false
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updatedClaim = new OAuth2Claim
            {
                Name = "groups",
                ClaimType = OAuth2ClaimType.RESOURCE,
                ValueType = OAuth2ClaimValueType.GROUPS,
                Value = "Everyone",
                GroupFilterType = OAuth2ClaimGroupFilterType.STARTSWITH,
                AlwaysIncludeInToken = true
            };

            // Act
            var result = await api.ReplaceOAuth2ClaimAsync(_authServerId, _claimId, updatedClaim);

            // Assert
            result.ValueType.Should().Be(OAuth2ClaimValueType.GROUPS);
            result.GroupFilterType.Should().Be(OAuth2ClaimGroupFilterType.STARTSWITH);
            result.Value.Should().Be("Everyone");
        }

        [Fact]
        public async Task ReplaceOAuth2ClaimAsync_ClearConditions_ReturnsNoConditions()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""oclClearConditions"",
                ""name"": ""all_scopes_claim"",
                ""status"": ""ACTIVE"",
                ""claimType"": ""RESOURCE"",
                ""valueType"": ""EXPRESSION"",
                ""value"": ""user.email"",
                ""alwaysIncludeInToken"": true,
                ""system"": false,
                ""conditions"": {
                    ""scopes"": []
                }
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updatedClaim = new OAuth2Claim
            {
                Name = "all_scopes_claim",
                ClaimType = OAuth2ClaimType.RESOURCE,
                ValueType = OAuth2ClaimValueType.EXPRESSION,
                Value = "user.email",
                AlwaysIncludeInToken = true,
                Conditions = new OAuth2ClaimConditions
                {
                    Scopes = new List<string>()  // Empty means all scopes
                }
            };

            // Act
            var result = await api.ReplaceOAuth2ClaimAsync(_authServerId, _claimId, updatedClaim);

            // Assert
            result.Conditions.Should().NotBeNull();
            result.Conditions.Scopes.Should().BeEmpty();
        }

        [Fact]
        public async Task ReplaceOAuth2ClaimWithHttpInfoAsync_ReturnsOkStatusCode()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""oclHttpInfo"",
                ""name"": ""test"",
                ""status"": ""ACTIVE"",
                ""claimType"": ""RESOURCE"",
                ""valueType"": ""EXPRESSION"",
                ""value"": ""user.email"",
                ""alwaysIncludeInToken"": true,
                ""system"": false
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updatedClaim = new OAuth2Claim
            {
                Name = "test",
                ClaimType = OAuth2ClaimType.RESOURCE,
                ValueType = OAuth2ClaimValueType.EXPRESSION,
                Value = "user.email",
                AlwaysIncludeInToken = true
            };

            // Act
            var response = await api.ReplaceOAuth2ClaimWithHttpInfoAsync(_authServerId, _claimId, updatedClaim);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
        }

        [Fact]
        public async Task ReplaceOAuth2ClaimAsync_SendsCorrectRequestBody()
        {
            // Arrange
            var responseJson = @"{
                ""id"": ""oclBody"",
                ""name"": ""body_test"",
                ""status"": ""ACTIVE"",
                ""claimType"": ""RESOURCE"",
                ""valueType"": ""EXPRESSION"",
                ""value"": ""user.lastName"",
                ""alwaysIncludeInToken"": false,
                ""system"": false
            }";

            var mockClient = new MockAsyncClient(responseJson);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var updatedClaim = new OAuth2Claim
            {
                Name = "body_test",
                ClaimType = OAuth2ClaimType.RESOURCE,
                ValueType = OAuth2ClaimValueType.EXPRESSION,
                Value = "user.lastName",
                AlwaysIncludeInToken = false
            };

            // Act
            await api.ReplaceOAuth2ClaimAsync(_authServerId, _claimId, updatedClaim);

            // Assert - Verify request body was sent
            mockClient.ReceivedBody.Should().NotBeNull();
            mockClient.ReceivedBody.Should().Contain("body_test");
            mockClient.ReceivedBody.Should().Contain("user.lastName");
            mockClient.ReceivedBody.Should().Contain("\"alwaysIncludeInToken\":false");
        }

        #endregion

        #region DeleteOAuth2Claim Tests

        [Fact]
        public async Task DeleteOAuth2ClaimAsync_DeletesClaim()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteOAuth2ClaimAsync(_authServerId, _claimId);

            // Assert - Verify correct path was called
            mockClient.ReceivedPath.Should().Be("/api/v1/authorizationServers/{authServerId}/claims/{claimId}");
            mockClient.ReceivedPathParams.Should().ContainKey("authServerId");
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(_authServerId);
            mockClient.ReceivedPathParams.Should().ContainKey("claimId");
            mockClient.ReceivedPathParams["claimId"].Should().Contain(_claimId);
        }

        [Fact]
        public async Task DeleteOAuth2ClaimWithHttpInfoAsync_ReturnsNoContentStatusCode()
        {
            // Arrange
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            var response = await api.DeleteOAuth2ClaimWithHttpInfoAsync(_authServerId, _claimId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task DeleteOAuth2ClaimAsync_WithDifferentIds_UsesCorrectPath()
        {
            // Arrange
            var customAuthServerId = "ausDeleteServer88888";
            var customClaimId = "oclDeleteClaim66666";
            var mockClient = new MockAsyncClient("", HttpStatusCode.NoContent);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act
            await api.DeleteOAuth2ClaimAsync(customAuthServerId, customClaimId);

            // Assert
            mockClient.ReceivedPathParams["authServerId"].Should().Contain(customAuthServerId);
            mockClient.ReceivedPathParams["claimId"].Should().Contain(customClaimId);
        }

        #endregion

        #region Error Handling Tests

        [Fact]
        public async Task GetOAuth2ClaimAsync_WhenClaimNotFound_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: nonExistentClaimId (OAuth2Claim)"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""oae123456789"",
                ""errorCauses"": []
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.GetOAuth2ClaimAsync(_authServerId, "nonExistentClaimId"));

            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task CreateOAuth2ClaimAsync_WhenInvalidData_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000001"",
                ""errorSummary"": ""Api validation failed: name"",
                ""errorLink"": ""E0000001"",
                ""errorId"": ""oae123456789"",
                ""errorCauses"": [
                    {
                        ""errorSummary"": ""name: The field name is required.""
                    }
                ]
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.BadRequest);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var invalidClaim = new OAuth2Claim();  // Missing required fields

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.CreateOAuth2ClaimAsync(_authServerId, invalidClaim));

            exception.ErrorCode.Should().Be(400);
        }

        [Fact]
        public async Task ReplaceOAuth2ClaimAsync_WhenClaimNotFound_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: nonExistentClaimId (OAuth2Claim)"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""oae123456789"",
                ""errorCauses"": []
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            var claim = new OAuth2Claim
            {
                Name = "test",
                ClaimType = OAuth2ClaimType.RESOURCE,
                ValueType = OAuth2ClaimValueType.EXPRESSION,
                Value = "user.email"
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.ReplaceOAuth2ClaimAsync(_authServerId, "nonExistentClaimId", claim));

            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task DeleteOAuth2ClaimAsync_WhenClaimNotFound_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000007"",
                ""errorSummary"": ""Not found: Resource not found: nonExistentClaimId (OAuth2Claim)"",
                ""errorLink"": ""E0000007"",
                ""errorId"": ""oae123456789"",
                ""errorCauses"": []
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.NotFound);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.DeleteOAuth2ClaimAsync(_authServerId, "nonExistentClaimId"));

            exception.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task DeleteOAuth2ClaimAsync_WhenSystemClaim_ThrowsApiException()
        {
            // Arrange
            var errorJson = @"{
                ""errorCode"": ""E0000064"",
                ""errorSummary"": ""You cannot delete a system claim."",
                ""errorLink"": ""E0000064"",
                ""errorId"": ""oae123456789"",
                ""errorCauses"": []
            }";

            var mockClient = new MockAsyncClient(errorJson, HttpStatusCode.Forbidden);
            var api = new AuthorizationServerClaimsApi(mockClient, new Configuration { BasePath = BaseUrl });

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ApiException>(
                () => api.DeleteOAuth2ClaimAsync(_authServerId, "systemClaimId"));

            exception.ErrorCode.Should().Be(403);
        }

        #endregion
    }
}
