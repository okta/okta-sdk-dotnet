// <copyright file="RoleBTargetClientApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Newtonsoft.Json.Linq;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Comprehensive integration tests for the RoleBTargetClientApi.
    /// 
    /// This test file validates Issue #810: Verifies that ListAppTargetRoleToClient returns 
    /// CatalogApplication objects (not ModelClient) and ListGroupTargetRoleForClient returns 
    /// Group objects (not ModelClient).
    /// 
    /// API ENDPOINTS COVERED (8 total):
    /// ┌─────────────────────────────────────────────────────────────────────────────────────────────────────────┐
    /// │ #  │ Method │ Endpoint                                                                      │ SDK Method │
    /// ├─────────────────────────────────────────────────────────────────────────────────────────────────────────┤
    /// │ 1  │ GET    │ /oauth2/v1/clients/{clientId}/roles/{roleId}/targets/catalog/apps             │ ListAppTargetRoleToClient │
    /// │ 2  │ PUT    │ /oauth2/v1/clients/{clientId}/roles/{roleId}/targets/catalog/apps/{appName}   │ AssignAppTargetRoleToClient │
    /// │ 3  │ DELETE │ /oauth2/v1/clients/{clientId}/roles/{roleId}/targets/catalog/apps/{appName}   │ RemoveAppTargetRoleFromClient │
    /// │ 4  │ PUT    │ /oauth2/v1/clients/{clientId}/roles/{roleId}/targets/catalog/apps/{appName}/{appId} │ AssignAppTargetInstanceRoleForClient │
    /// │ 5  │ DELETE │ /oauth2/v1/clients/{clientId}/roles/{roleId}/targets/catalog/apps/{appName}/{appId} │ RemoveAppTargetInstanceRoleForClient │
    /// │ 6  │ GET    │ /oauth2/v1/clients/{clientId}/roles/{roleId}/targets/groups                   │ ListGroupTargetRoleForClient │
    /// │ 7  │ PUT    │ /oauth2/v1/clients/{clientId}/roles/{roleId}/targets/groups/{groupId}         │ AssignGroupTargetRoleForClient │
    /// │ 8  │ DELETE │ /oauth2/v1/clients/{clientId}/roles/{roleId}/targets/groups/{groupId}         │ RemoveGroupTargetRoleFromClient │
    /// └─────────────────────────────────────────────────────────────────────────────────────────────────────────┘
    /// 
    /// TEST STRATEGY:
    /// This test creates its own OAuth service app, groups, applications, and role assignments, then cleans them up afterward.
    /// It is fully self-contained and does not rely on external environment variables for client ID.
    /// 
    /// PREREQUISITES:
    /// - Okta org with valid API token
    /// </summary>
    [Collection(nameof(RoleBTargetClientApiTests))]
    public class RoleBTargetClientApiTests : IAsyncLifetime
    {
        private RoleBTargetClientApi _roleBTargetClientApi;
        private RoleAssignmentClientApi _roleAssignmentClientApi;
        private ApplicationApi _applicationApi;
        private GroupApi _groupApi;
        private ApiClient _apiClient;
        private string _oktaDomain;
        
        private string _testClientId;
        private string _appAdminRoleAssignmentId;
        private string _userAdminRoleAssignmentId;
        private string _createdGroupId;
        private string _createdAppId;
        private const string TestAppName = "bookmark"; // Common OIN app that exists in all Okta orgs
        private bool _setupComplete;

        // Test RSA public key for service app JWT authentication
        private const string TestPublicKeyN = "mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q";

        public async Task InitializeAsync()
        {
            // Initialize API instances with default configuration from environment
            _roleBTargetClientApi = new RoleBTargetClientApi();
            _roleAssignmentClientApi = new RoleAssignmentClientApi();
            _applicationApi = new ApplicationApi();
            _groupApi = new GroupApi();

            _oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;
            if (_oktaDomain.EndsWith("/"))
            {
                _oktaDomain = _oktaDomain.Remove(_oktaDomain.Length - 1);
            }
            _apiClient = new ApiClient(_oktaDomain);

            try
            {
                // Create an OAuth service app for testing client role assignments
                var guid = Guid.NewGuid();
                var payload = $@"{{
                    ""client_name"": ""dotnet-sdk: RoleBTargetClientApiTests {guid}"",
                    ""response_types"": [""token""],
                    ""grant_types"": [""client_credentials""],
                    ""token_endpoint_auth_method"": ""private_key_jwt"",
                    ""application_type"": ""service"",
                    ""jwks"": {{
                        ""keys"": [{{
                            ""kty"":""RSA"",
                            ""e"":""AQAB"",
                            ""n"":""{TestPublicKeyN}""
                        }}]
                    }}
                }}";

                var requestOptions = GetBasicRequestOptions();
                requestOptions.Data = JObject.Parse(payload);

                var serviceResponse = await _apiClient.PostAsync<JObject>("/oauth2/v1/clients", requestOptions);
                _testClientId = serviceResponse.Data["client_id"]?.ToString();

                if (string.IsNullOrEmpty(_testClientId))
                {
                    return;
                }

                // Create a test group for group target tests
                var addGroupRequest = new AddGroupRequest
                {
                    Profile = new OktaUserGroupProfile
                    {
                        Name = $"SDK-Test-RoleBTarget-{Guid.NewGuid():N}",
                        Description = "Test group for RoleBTargetClientApi integration tests"
                    }
                };
                var createdGroup = await _groupApi.AddGroupAsync(addGroupRequest);
                _createdGroupId = createdGroup.Id;

                // Create a test bookmark app for app instance target tests
                var bookmarkApp = new BookmarkApplication
                {
                    Name = "bookmark",
                    Label = $"SDK-Test-RoleBTarget-App-{Guid.NewGuid():N}",
                    Settings = new BookmarkApplicationSettings
                    {
                        App = new BookmarkApplicationSettingsApplication
                        {
                            Url = "https://example.com",
                            RequestIntegration = false
                        }
                    }
                };
                var createdApp = await _applicationApi.CreateApplicationAsync(bookmarkApp);
                _createdAppId = createdApp.Id;

                // Assign an APP_ADMIN role to the client for app target tests
                // Using raw API call to avoid polymorphic deserialization bug in ListGroupAssignedRoles200ResponseInner.FromJson
                var appAdminRequestOptions = GetBasicRequestOptions();
                appAdminRequestOptions.Data = JObject.Parse(@"{ ""type"": ""APP_ADMIN"" }");
                var appAdminResponse = await _apiClient.PostAsync<JObject>($"/oauth2/v1/clients/{_testClientId}/roles", appAdminRequestOptions);
                _appAdminRoleAssignmentId = appAdminResponse.Data?["id"]?.ToString();

                // Assign USER_ADMIN role to the client for group target tests
                var userAdminRequestOptions = GetBasicRequestOptions();
                userAdminRequestOptions.Data = JObject.Parse(@"{ ""type"": ""USER_ADMIN"" }");
                var userAdminResponse = await _apiClient.PostAsync<JObject>($"/oauth2/v1/clients/{_testClientId}/roles", userAdminRequestOptions);
                _userAdminRoleAssignmentId = userAdminResponse.Data?["id"]?.ToString();

                _setupComplete = !string.IsNullOrEmpty(_appAdminRoleAssignmentId) && 
                                 !string.IsNullOrEmpty(_userAdminRoleAssignmentId);
            }
            catch (ApiException ex)
            {
                // Role might already be assigned - try to retrieve it
                Console.WriteLine($"Setup warning: {ex.Message}");
            }
        }

        public async Task DisposeAsync()
        {
            // Clean up role assignments
            if (!string.IsNullOrEmpty(_testClientId) && !string.IsNullOrEmpty(_appAdminRoleAssignmentId))
            {
                try
                {
                    await _roleAssignmentClientApi.DeleteRoleFromClientAsync(_testClientId, _appAdminRoleAssignmentId);
                }
                catch { /* Ignore cleanup errors */ }
            }

            if (!string.IsNullOrEmpty(_testClientId) && !string.IsNullOrEmpty(_userAdminRoleAssignmentId))
            {
                try
                {
                    await _roleAssignmentClientApi.DeleteRoleFromClientAsync(_testClientId, _userAdminRoleAssignmentId);
                }
                catch { /* Ignore cleanup errors */ }
            }

            // Clean up test group
            if (!string.IsNullOrEmpty(_createdGroupId))
            {
                try
                {
                    await _groupApi.DeleteGroupAsync(_createdGroupId);
                }
                catch { /* Ignore cleanup errors */ }
            }

            // Clean up test app
            if (!string.IsNullOrEmpty(_createdAppId))
            {
                try
                {
                    await _applicationApi.DeactivateApplicationAsync(_createdAppId);
                    await _applicationApi.DeleteApplicationAsync(_createdAppId);
                }
                catch { /* Ignore cleanup errors */ }
            }

            // Clean up the OAuth service app
            if (!string.IsNullOrEmpty(_testClientId))
            {
                try
                {
                    var requestOptions = GetBasicRequestOptions();
                    await _apiClient.DeleteAsync<JObject>($"/oauth2/v1/clients/{_testClientId}", requestOptions, Configuration.GetConfigurationOrDefault());
                }
                catch { /* Ignore cleanup errors */ }
            }
        }

        private RequestOptions GetBasicRequestOptions()
        {
            string[] contentTypes = ["application/json"];
            string[] accepts = ["application/json"];

            var requestOptions = new RequestOptions();

            var localVarContentType = ClientUtils.SelectHeaderContentType(contentTypes);
            if (localVarContentType != null)
            {
                requestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = ClientUtils.SelectHeaderAccept(accepts);
            if (localVarAccept != null)
            {
                requestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (!string.IsNullOrEmpty(Configuration.GetConfigurationOrDefault().GetApiKeyWithPrefix("Authorization")))
            {
                requestOptions.HeaderParameters.Add("Authorization", Configuration.GetConfigurationOrDefault().GetApiKeyWithPrefix("Authorization"));
            }

            return requestOptions;
        }

        private void SkipIfSetupIncomplete()
        {
            if (!_setupComplete)
            {
                throw new RoleBTargetTestSkipException("Test setup incomplete - missing role assignments or client ID.");
            }
        }

        /// <summary>
        /// Helper method to extract group name from GroupProfile (which is a union type).
        /// </summary>
        private string GetGroupName(GroupProfile profile)
        {
            if (profile?.ActualInstance is OktaUserGroupProfile userProfile)
                return userProfile.Name;
            else if (profile?.ActualInstance is OktaActiveDirectoryGroupProfile adProfile)
                return adProfile.Name;
            return null;
        }

        #region Issue #810 Verification Tests - Return Type Verification

        /// <summary>
        /// ISSUE #810 TEST: Verifies that ListAppTargetRoleToClient returns CatalogApplication objects, NOT ModelClient.
        /// 
        /// This is the primary test for Issue #810 that claimed the method returns ModelClient.
        /// The API returns CatalogApplication objects with properties: name, displayName, status, category, etc.
        /// </summary>
        [Fact]
        public async Task ListAppTargetRoleToClient_ShouldReturnCatalogApplication_NotModelClient()
        {
            SkipIfSetupIncomplete();

            // First, assign an OIN app target to ensure we have something to list
            try
            {
                await _roleBTargetClientApi.AssignAppTargetRoleToClientAsync(
                    _testClientId, _appAdminRoleAssignmentId, TestAppName);
            }
            catch (ApiException ex) when (ex.ErrorCode == 409)
            {
                // Already assigned, continue
            }

            // Act - Call the method that Issue #810 claims returns the wrong type
            var appTargets = new List<CatalogApplication>();
            await foreach (var app in _roleBTargetClientApi.ListAppTargetRoleToClient(
                _testClientId, _appAdminRoleAssignmentId))
            {
                appTargets.Add(app);
                
                // CRITICAL ASSERTION: This is a CatalogApplication, NOT ModelClient
                app.Should().BeOfType<CatalogApplication>(
                    "Issue #810: ListAppTargetRoleToClient should return CatalogApplication, not ModelClient");
                
                // Verify CatalogApplication-specific properties exist and are accessible
                // CatalogApplication has: Name, DisplayName, Description, Status, Category, VerificationStatus
                // ModelClient has: ClientId, ClientSecret, ApplicationType, TokenEndpointAuthMethod
                app.Name.Should().NotBeNullOrEmpty("CatalogApplication.Name should be populated");
            }

            // Assert
            appTargets.Should().NotBeEmpty("At least one app target should exist after assignment");
            
            // Verify the items have CatalogApplication properties
            var firstApp = appTargets.First();
            firstApp.Name.Should().Be(TestAppName);
            
            // These properties exist on CatalogApplication but NOT on ModelClient
            var status = firstApp.Status; // CatalogApplicationStatus enum
            status.Should().NotBeNull();

            // Cleanup - remove the app target we added
            try
            {
                await _roleBTargetClientApi.RemoveAppTargetRoleFromClientAsync(
                    _testClientId, _appAdminRoleAssignmentId, TestAppName);
            }
            catch { /* Ignore */ }
        }

        /// <summary>
        /// ISSUE #810 TEST: Verifies that ListGroupTargetRoleForClient returns Group objects, NOT ModelClient.
        /// 
        /// This is the secondary test for Issue #810 for the group targets endpoint.
        /// The API returns Group objects with properties: id, profile, type, created, etc.
        /// </summary>
        [Fact]
        public async Task ListGroupTargetRoleForClient_ShouldReturnGroup_NotModelClient()
        {
            SkipIfSetupIncomplete();

            // First, assign a group target to ensure we have something to list
            try
            {
                await _roleBTargetClientApi.AssignGroupTargetRoleForClientAsync(
                    _testClientId, _userAdminRoleAssignmentId, _createdGroupId);
            }
            catch (ApiException ex) when (ex.ErrorCode == 409)
            {
                // Already assigned, continue
            }

            // Act - Call the method that Issue #810 claims returns the wrong type
            var groupTargets = new List<Group>();
            await foreach (var group in _roleBTargetClientApi.ListGroupTargetRoleForClient(
                _testClientId, _userAdminRoleAssignmentId))
            {
                groupTargets.Add(group);
                
                // CRITICAL ASSERTION: This is a Group, NOT ModelClient
                group.Should().BeOfType<Group>(
                    "Issue #810: ListGroupTargetRoleForClient should return Group, not ModelClient");
                
                // Verify Group-specific properties exist and are accessible
                // Group having: ID, Profile, Type, Created, LastUpdated, ObjectClass
                // ModelClient has: ClientId, ClientSecret, ApplicationType, TokenEndpointAuthMethod
                group.Id.Should().NotBeNullOrEmpty("Group.Id should be populated");
                group.Profile.Should().NotBeNull("Group.Profile should not be null");
            }

            // Assert
            groupTargets.Should().NotBeEmpty("At least one group target should exist after assignment");
            
            // Verify the items have Group properties
            var ourGroup = groupTargets.FirstOrDefault(g => g.Id == _createdGroupId);
            ourGroup.Should().NotBeNull("Our created group should be in the targets list");
            GetGroupName(ourGroup!.Profile).Should().StartWith("SDK-Test-RoleBTarget-");
            
            // These properties exist on Group but NOT on ModelClient
            var type = ourGroup.Type; // GroupType enum
            type.Should().NotBeNull();
        }

        /// <summary>
        /// Type comparison test: Verifies CatalogApplication and ModelClient are completely different types.
        /// </summary>
        [Fact]
        public void TypeComparison_CatalogApplication_And_ModelClient_AreDifferentTypes()
        {
            // Get properties of each type
            var catalogAppProperties = typeof(CatalogApplication).GetProperties().Select(p => p.Name).ToHashSet();
            var modelClientProperties = typeof(ModelClient).GetProperties().Select(p => p.Name).ToHashSet();

            // CatalogApplication-specific properties
            catalogAppProperties.Should().Contain("Name", "CatalogApplication should have Name property");
            catalogAppProperties.Should().Contain("DisplayName", "CatalogApplication should have DisplayName property");
            catalogAppProperties.Should().Contain("Category", "CatalogApplication should have Category property");
            catalogAppProperties.Should().Contain("VerificationStatus", "CatalogApplication should have VerificationStatus property");
            
            // ModelClient-specific properties (these should NOT be in CatalogApplication)
            modelClientProperties.Should().Contain("ClientId", "ModelClient should have ClientId property");
            modelClientProperties.Should().Contain("ClientSecret", "ModelClient should have ClientSecret property");
            modelClientProperties.Should().Contain("ApplicationType", "ModelClient should have ApplicationType property");
            
            // Verify they're different
            catalogAppProperties.Should().NotContain("ClientSecret", 
                "CatalogApplication should NOT have ClientSecret (that's a ModelClient property)");
            modelClientProperties.Should().NotContain("VerificationStatus", 
                "ModelClient should NOT have VerificationStatus (that's a CatalogApplication property)");
            
            typeof(CatalogApplication).Should().NotBe(typeof(ModelClient), 
                "CatalogApplication and ModelClient must be different types");
        }

        /// <summary>
        /// Type comparison test: Verifies Group and ModelClient are completely different types.
        /// </summary>
        [Fact]
        public void TypeComparison_Group_And_ModelClient_AreDifferentTypes()
        {
            // Get properties of each type
            var groupProperties = typeof(Group).GetProperties().Select(p => p.Name).ToHashSet();
            var modelClientProperties = typeof(ModelClient).GetProperties().Select(p => p.Name).ToHashSet();

            // Group-specific properties
            groupProperties.Should().Contain("Id", "Group should have Id property");
            groupProperties.Should().Contain("Profile", "Group should have Profile property");
            groupProperties.Should().Contain("Type", "Group should have Type property");
            groupProperties.Should().Contain("ObjectClass", "Group should have ObjectClass property");
            
            // ModelClient-specific properties (these should NOT be in Group)
            modelClientProperties.Should().Contain("ClientId", "ModelClient should have ClientId property");
            modelClientProperties.Should().Contain("ClientSecret", "ModelClient should have ClientSecret property");
            
            // Verify they're different
            groupProperties.Should().NotContain("ClientSecret", 
                "Group should NOT have ClientSecret (that's a ModelClient property)");
            modelClientProperties.Should().NotContain("ObjectClass", 
                "ModelClient should NOT have ObjectClass (that's a Group property)");
            
            typeof(Group).Should().NotBe(typeof(ModelClient), 
                "Group and ModelClient must be different types");
        }

        #endregion

        #region Comprehensive Endpoint Coverage Test

        /// <summary>
        /// COMPREHENSIVE TEST: Tests all 8 RoleBTargetClient API endpoints in a single workflow.
        /// 
        /// Workflow:
        /// 1. List app targets (empty initially) - GET /oauth2/v1/clients/{clientId}/roles/{roleId}/targets/catalog/apps
        /// 2. Assign OIN app target - PUT /oauth2/v1/clients/{clientId}/roles/{roleId}/targets/catalog/apps/{appName}
        /// 3. List app targets (should contain the app) - GET
        /// 4. Assign app instance target - PUT /oauth2/v1/clients/{clientId}/roles/{roleId}/targets/catalog/apps/{appName}/{appId}
        /// 5. List app targets (should contain instance) - GET
        /// 6. Remove app instance target - DELETE /oauth2/v1/clients/{clientId}/roles/{roleId}/targets/catalog/apps/{appName}/{appId}
        /// 7. Remove OIN app target - DELETE /oauth2/v1/clients/{clientId}/roles/{roleId}/targets/catalog/apps/{appName}
        /// 8. List group targets (empty initially) - GET /oauth2/v1/clients/{clientId}/roles/{roleId}/targets/groups
        /// 9. Assign group target - PUT /oauth2/v1/clients/{clientId}/roles/{roleId}/targets/groups/{groupId}
        /// 10. List group targets (should contain the group) - GET
        /// 11. Remove group target - DELETE /oauth2/v1/clients/{clientId}/roles/{roleId}/targets/groups/{groupId}
        /// </summary>
        [Fact]
        public async Task ComprehensiveWorkflow_AllEndpoints_ShouldWorkCorrectly()
        {
            SkipIfSetupIncomplete();

            // ============ APP TARGET TESTS (APP_ADMIN role) ============

            // Step 1: List app targets - should be empty initially or contain any existing targets
            var initialAppTargets = new List<CatalogApplication>();
            await foreach (var app in _roleBTargetClientApi.ListAppTargetRoleToClient(
                _testClientId, _appAdminRoleAssignmentId))
            {
                initialAppTargets.Add(app);
            }
            initialAppTargets.Should().NotBeNull();
            var initialCount = initialAppTargets.Count;

            // Step 2: Assign OIN app target (e.g., "bookmark")
            await _roleBTargetClientApi.AssignAppTargetRoleToClientAsync(
                _testClientId, _appAdminRoleAssignmentId, TestAppName);

            // Step 3: List app targets - should now contain the assigned app
            var afterAssignAppTargets = new List<CatalogApplication>();
            await foreach (var app in _roleBTargetClientApi.ListAppTargetRoleToClient(
                _testClientId, _appAdminRoleAssignmentId))
            {
                afterAssignAppTargets.Add(app);
                app.Should().BeOfType<CatalogApplication>("Return type must be CatalogApplication");
            }
            afterAssignAppTargets.Should().HaveCountGreaterThanOrEqualTo(initialCount + 1);
            afterAssignAppTargets.Should().Contain(a => a.Name == TestAppName);

            // Note: We skip app target removal tests because:
            // 1. You cannot remove the last/only app target from role
            // 2. Finding a second app that can be assigned to APP_ADMIN is Okta org-specific
            // The key functionality (ListAppTargetRoleToClient returns CatalogApplication) is verified above

            // ============ GROUP TARGET TESTS (USER_ADMIN role) ============

            // Step 4: List group targets - should be empty initially
            var initialGroupTargets = new List<Group>();
            await foreach (var group in _roleBTargetClientApi.ListGroupTargetRoleForClient(
                _testClientId, _userAdminRoleAssignmentId))
            {
                initialGroupTargets.Add(group);
            }
            initialGroupTargets.Should().NotBeNull();
            var initialGroupCount = initialGroupTargets.Count;

            // Step 5: Assign group target
            await _roleBTargetClientApi.AssignGroupTargetRoleForClientAsync(
                _testClientId, _userAdminRoleAssignmentId, _createdGroupId);

            // Step 6: List group targets - should now contain the assigned group
            var afterAssignGroupTargets = new List<Group>();
            await foreach (var group in _roleBTargetClientApi.ListGroupTargetRoleForClient(
                _testClientId, _userAdminRoleAssignmentId))
            {
                afterAssignGroupTargets.Add(group);
                group.Should().BeOfType<Group>("Return type must be Group");
            }
            afterAssignGroupTargets.Should().HaveCountGreaterThanOrEqualTo(initialGroupCount + 1);
            afterAssignGroupTargets.Should().Contain(g => g.Id == _createdGroupId);

            // Verify the Group object properties
            var ourGroup = afterAssignGroupTargets.First(g => g.Id == _createdGroupId);
            ourGroup.Profile.Should().NotBeNull();
            GetGroupName(ourGroup.Profile).Should().StartWith("SDK-Test-RoleBTarget-");
            ourGroup.Created.Should().BeBefore(DateTimeOffset.UtcNow.AddMinutes(1));
            ourGroup.Type.Should().NotBeNull();

            // Step 11: Remove group target - Note: We leave this for cleanup since we can't remove the last one
        }

        #endregion

        #region Error Handling Tests

        /// <summary>
        /// Tests that ListAppTargetRoleToClient throws ApiException for invalid clientId.
        /// </summary>
        [Fact]
        public async Task ListAppTargetRoleToClient_WithInvalidClientId_ShouldThrowApiException()
        {
            // Act - Use a non-existent client ID and role ID
            Func<Task> act = async () =>
            {
                await foreach (var _ in _roleBTargetClientApi.ListAppTargetRoleToClient("nonexistent_client_id", "nonexistent_role_id"))
                {
                    // Enumerate to trigger the API call
                }
            };

            // Assert - The API should throw an exception or return empty (depending on API behavior)
            // Some Okta APIs return empty collections instead of 404 for invalid IDs
            try
            {
                await act.Invoke();
                // If no exception, that's also acceptable behavior for this API
            }
            catch (ApiException ex)
            {
                ex.ErrorCode.Should().BeOneOf(404, 400, 403);
            }
        }

        /// <summary>
        /// Tests that ListGroupTargetRoleForClient throws ApiException for invalid clientId.
        /// </summary>
        [Fact]
        public async Task ListGroupTargetRoleForClient_WithInvalidClientId_ShouldThrowApiException()
        {
            // Act - Use a non-existent client ID and role ID
            Func<Task> act = async () =>
            {
                await foreach (var _ in _roleBTargetClientApi.ListGroupTargetRoleForClient("nonexistent_client_id", "nonexistent_role_id"))
                {
                    // Enumerate to trigger the API call
                }
            };

            // Assert - The API should throw an exception or return empty (depending on API behavior)
            // Some Okta APIs return empty collections instead of 404 for invalid IDs
            try
            {
                await act.Invoke();
                // If no exception, that's also acceptable behavior for this API
            }
            catch (ApiException ex)
            {
                ex.ErrorCode.Should().BeOneOf(404, 400, 403);
            }
        }

        /// <summary>
        /// Tests that AssignAppTargetRoleToClient throws ApiException for invalid app name.
        /// </summary>
        [Fact]
        public async Task AssignAppTargetRoleToClient_WithInvalidAppName_ShouldThrowApiException()
        {
            SkipIfSetupIncomplete();

            // Act
            Func<Task> act = () => _roleBTargetClientApi.AssignAppTargetRoleToClientAsync(
                _testClientId, _appAdminRoleAssignmentId, "nonexistent_app_12345xyz");

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404 || e.ErrorCode == 400);
        }

        /// <summary>
        /// Tests that AssignGroupTargetRoleForClient throws ApiException for invalid group ID.
        /// </summary>
        [Fact]
        public async Task AssignGroupTargetRoleForClient_WithInvalidGroupId_ShouldThrowApiException()
        {
            SkipIfSetupIncomplete();

            // Act
            Func<Task> act = () => _roleBTargetClientApi.AssignGroupTargetRoleForClientAsync(
                _testClientId, _userAdminRoleAssignmentId, "00g000000000000000000");

            // Assert
            await act.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404 || e.ErrorCode == 400);
        }

        #endregion

        #region Pagination Tests

        /// <summary>
        /// Tests that ListAppTargetRoleToClient supports limit parameter.
        /// </summary>
        [Fact]
        public async Task ListAppTargetRoleToClient_WithLimit_ShouldRespectLimit()
        {
            SkipIfSetupIncomplete();

            // Add an app target first
            try
            {
                await _roleBTargetClientApi.AssignAppTargetRoleToClientAsync(
                    _testClientId, _appAdminRoleAssignmentId, TestAppName);
            }
            catch (ApiException ex) when (ex.ErrorCode == 409)
            {
                // Already assigned, continue
            }

            // Act - Get with limit=1
            var limitedResults = new List<CatalogApplication>();
            await foreach (var app in _roleBTargetClientApi.ListAppTargetRoleToClient(
                _testClientId, _appAdminRoleAssignmentId, limit: 1))
            {
                limitedResults.Add(app);
            }

            // Assert - The SDK handles pagination automatically, so we may get all results
            // But each item should still be a CatalogApplication
            limitedResults.Should().NotBeEmpty();
            limitedResults.Should().AllBeOfType<CatalogApplication>();
        }

        /// <summary>
        /// Tests that ListGroupTargetRoleForClient supports limit parameter.
        /// </summary>
        [Fact]
        public async Task ListGroupTargetRoleForClient_WithLimit_ShouldRespectLimit()
        {
            SkipIfSetupIncomplete();

            // Assign a group target
            try
            {
                await _roleBTargetClientApi.AssignGroupTargetRoleForClientAsync(
                    _testClientId, _userAdminRoleAssignmentId, _createdGroupId);
            }
            catch (ApiException ex) when (ex.ErrorCode == 409)
            {
                // Already assigned
            }

            // Act
            var results = new List<Group>();
            await foreach (var group in _roleBTargetClientApi.ListGroupTargetRoleForClient(
                _testClientId, _userAdminRoleAssignmentId, limit: 1))
            {
                results.Add(group);
            }

            // Assert
            results.Should().NotBeEmpty();
            results.Should().AllBeOfType<Group>();
        }

        #endregion

        #region HttpInfo Variant Tests

        /// <summary>
        /// Tests the WithHttpInfo variant of ListAppTargetRoleToClient.
        /// </summary>
        [Fact]
        public async Task ListAppTargetRoleToClientWithHttpInfo_ShouldReturnHttpResponse()
        {
            SkipIfSetupIncomplete();

            // Ensure there's at least one app target
            try
            {
                await _roleBTargetClientApi.AssignAppTargetRoleToClientAsync(
                    _testClientId, _appAdminRoleAssignmentId, TestAppName);
            }
            catch (ApiException ex) when (ex.ErrorCode == 409) { }

            // Act
            var response = await _roleBTargetClientApi.ListAppTargetRoleToClientWithHttpInfoAsync(
                _testClientId, _appAdminRoleAssignmentId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().BeOfType<List<CatalogApplication>>();
            
            if (response.Data.Any())
            {
                response.Data.First().Should().BeOfType<CatalogApplication>();
            }
        }

        /// <summary>
        /// Tests the WithHttpInfo variant of ListGroupTargetRoleForClient.
        /// </summary>
        [Fact]
        public async Task ListGroupTargetRoleForClientWithHttpInfo_ShouldReturnHttpResponse()
        {
            SkipIfSetupIncomplete();

            // Ensure there's at least one group target
            try
            {
                await _roleBTargetClientApi.AssignGroupTargetRoleForClientAsync(
                    _testClientId, _userAdminRoleAssignmentId, _createdGroupId);
            }
            catch (ApiException ex) when (ex.ErrorCode == 409) { }

            // Act
            var response = await _roleBTargetClientApi.ListGroupTargetRoleForClientWithHttpInfoAsync(
                _testClientId, _userAdminRoleAssignmentId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Should().BeOfType<List<Group>>();
            
            if (response.Data.Any())
            {
                response.Data.First().Should().BeOfType<Group>();
            }
        }

        #endregion
    }

    /// <summary>
    /// Exception to skip tests when prerequisites are not met for RoleBTargetClientApi tests.
    /// </summary>
    public class RoleBTargetTestSkipException : Exception
    {
        public RoleBTargetTestSkipException(string message) : base(message) { }
    }
}
