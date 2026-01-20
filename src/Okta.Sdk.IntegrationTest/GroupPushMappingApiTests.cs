// <copyright file="GroupPushMappingApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

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
    /// Fixture to set up test resources for Group Push Mapping API tests.
    /// Creates the necessary groups and an application that supports group push.
    /// This fixture is instantiated once per test collection and shared across all tests.
    /// </summary>
    public class GroupPushMappingApiTestFixture : IAsyncLifetime
    {
        private readonly GroupApi _groupApi = new();
        private readonly ApplicationApi _applicationApi = new();

        public string SourceGroup1Id { get; private set; }
        public string SourceGroup2Id { get; private set; }
        public string SourceGroup3Id { get; private set; }
        public string TestApplicationId { get; private set; }

        public async Task InitializeAsync()
        {
            var guid = Guid.NewGuid();

            // Create source groups for mapping tests
            var group1 = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"GroupPushMapping-Source1-{guid}",
                    Description = "Source group 1 for group push mapping tests"
                }
            };

            var group2 = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"GroupPushMapping-Source2-{guid}",
                    Description = "Source group 2 for group push mapping tests"
                }
            };

            var group3 = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"GroupPushMapping-Source3-{guid}",
                    Description = "Source group 3 for group push mapping tests"
                }
            };

            var createdGroup1 = await _groupApi.AddGroupAsync(group1);
            var createdGroup2 = await _groupApi.AddGroupAsync(group2);
            var createdGroup3 = await _groupApi.AddGroupAsync(group3);

            SourceGroup1Id = createdGroup1.Id;
            SourceGroup2Id = createdGroup2.Id;
            SourceGroup3Id = createdGroup3.Id;

            // Create an OIDC application that can support group push
            // Note: For actual group push to work in production, the application would need 
            // provisioning configured, but for testing the API endpoints, a basic OIDC app works
            var testClientId = $"GroupPushMapping-TestApp-{guid}";
            
            var application = new OpenIdConnectApplication
            {
                Name = "oidc_client",
                Label = $"GroupPushMapping-TestApp-{guid}",
                SignOnMode = "OPENID_CONNECT",
                Credentials = new OAuthApplicationCredentials
                {
                    OauthClient = new ApplicationCredentialsOAuthClient
                    {
                        ClientId = testClientId,
                        TokenEndpointAuthMethod = "client_secret_post",
                        AutoKeyRotation = true
                    }
                },
                Settings = new OpenIdConnectApplicationSettings
                {
                    OauthClient = new OpenIdConnectApplicationSettingsClient
                    {
                        ClientUri = "https://example.com/client",
                        ResponseTypes = [OAuthResponseType.Code],
                        RedirectUris = ["https://example.com/oauth2/callback"],
                        GrantTypes = [GrantType.AuthorizationCode],
                        ApplicationType = OpenIdConnectApplicationType.Web
                    }
                }
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(application);
            TestApplicationId = createdApp.Id;
        }

        public async Task DisposeAsync()
        {
            // Clean up groups
            if (!string.IsNullOrEmpty(SourceGroup1Id))
            {
                try { await _groupApi.DeleteGroupAsync(SourceGroup1Id); } catch (ApiException) { }
            }

            if (!string.IsNullOrEmpty(SourceGroup2Id))
            {
                try { await _groupApi.DeleteGroupAsync(SourceGroup2Id); } catch (ApiException) { }
            }

            if (!string.IsNullOrEmpty(SourceGroup3Id))
            {
                try { await _groupApi.DeleteGroupAsync(SourceGroup3Id); } catch (ApiException) { }
            }

            // Cleanup application
            if (!string.IsNullOrEmpty(TestApplicationId))
            {
                try
                {
                    await _applicationApi.DeactivateApplicationAsync(TestApplicationId);
                    await _applicationApi.DeleteApplicationAsync(TestApplicationId);
                }
                catch (ApiException) { }
            }
        }
    }

    [CollectionDefinition(nameof(GroupPushMappingApiTests))]
    public class GroupPushMappingApiTestsCollection : ICollectionFixture<GroupPushMappingApiTestFixture>;

    [Collection(nameof(GroupPushMappingApiTests))]
    public class GroupPushMappingApiTests(GroupPushMappingApiTestFixture fixture) : IDisposable
    {
        private readonly GroupPushMappingApi _groupPushMappingApi = new();
        private readonly List<string> _createdMappingIds = [];

        public void Dispose()
        {
            CleanupMappings().GetAwaiter().GetResult();
        }

        private async Task CleanupMappings()
        {
            foreach (var mappingId in _createdMappingIds)
            {
                try
                {
                    // First try to deactivate the mapping
                    try
                    {
                        var updateRequest = new UpdateGroupPushMappingRequest
                        {
                            Status = GroupPushMappingStatusUpsert.INACTIVE
                        };
                        await _groupPushMappingApi.UpdateGroupPushMappingAsync(
                            fixture.TestApplicationId, 
                            mappingId, 
                            updateRequest);
                    }
                    catch (ApiException) { }

                    // Then delete it (deleteTargetGroup = false to preserve downstream groups)
                    await _groupPushMappingApi.DeleteGroupPushMappingAsync(
                        fixture.TestApplicationId, 
                        mappingId, 
                        deleteTargetGroup: false);
                }
                catch (ApiException) { }
            }
            _createdMappingIds.Clear();
        }

        /// <summary>
        /// Comprehensive test covering all Group Push Mapping API operations and endpoints.
        /// Tests CRUD lifecycle, status management, filtering, pagination, HttpInfo variants,
        /// error handling, and proper cleanup.
        /// 
        /// Covers all 10 methods (5 standard + 5 WithHttpInfo variants) across 5 REST endpoints:
        /// - POST /api/v1/apps/{appId}/group-push/mappings (Create)
        /// - GET /api/v1/apps/{appId}/group-push/mappings (List)
        /// - GET /api/v1/apps/{appId}/group-push/mappings/{mappingId} (Get)
        /// - PATCH /api/v1/apps/{appId}/group-push/mappings/{mappingId} (Update)
        /// - DELETE /api/v1/apps/{appId}/group-push/mappings/{mappingId} (Delete)
        /// </summary>
        [Fact]
        public async Task GivenGroupPushMappings_WhenPerformingAllOperations_ThenAllEndpointsAndMethodsWork()
        {
            var guid = Guid.NewGuid();

            // ==================== CREATE OPERATIONS ====================

            //CreateGroupPushMappingAsync - Create mapping with a new target group (targetGroupName)
            var targetGroupName1 = $"PushTarget-New-{guid}";
            var createRequest1 = new CreateGroupPushMappingRequest
            {
                SourceGroupId = fixture.SourceGroup1Id,
                TargetGroupName = targetGroupName1,
                Status = GroupPushMappingStatusUpsert.ACTIVE
            };

            var createdMapping1 = await _groupPushMappingApi.CreateGroupPushMappingAsync(
                fixture.TestApplicationId,
                createRequest1);
            _createdMappingIds.Add(createdMapping1.Id);

            createdMapping1.Should().NotBeNull();
            createdMapping1.Id.Should().NotBeNullOrEmpty();
            createdMapping1.Id.Should().StartWith("gPm", "mapping ID should have correct prefix");
            createdMapping1.SourceGroupId.Should().Be(fixture.SourceGroup1Id);
            createdMapping1.TargetGroupId.Should().NotBeNullOrEmpty("target group should be created");
            createdMapping1.Status.Should().Be(GroupPushMappingStatus.ACTIVE);
            createdMapping1.Created.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
            createdMapping1.Created.Should().BeAfter(DateTimeOffset.UtcNow.AddMinutes(-5));
            createdMapping1.LastUpdated.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
            createdMapping1.LastUpdated.Should().BeAfter(DateTimeOffset.UtcNow.AddMinutes(-5));
            
            // Validate complete Links structure
            createdMapping1.Links.Should().NotBeNull();
            createdMapping1.Links.App.Should().NotBeNull();
            createdMapping1.Links.App.Href.Should().NotBeNullOrEmpty();
            createdMapping1.Links.App.Href.Should().Contain($"/api/v1/apps/{fixture.TestApplicationId}");
            createdMapping1.Links.SourceGroup.Should().NotBeNull();
            createdMapping1.Links.SourceGroup.Href.Should().NotBeNullOrEmpty();
            createdMapping1.Links.SourceGroup.Href.Should().Contain($"/api/v1/groups/{fixture.SourceGroup1Id}");
            createdMapping1.Links.TargetGroup.Should().NotBeNull();
            createdMapping1.Links.TargetGroup.Href.Should().NotBeNullOrEmpty();
            createdMapping1.Links.TargetGroup.Href.Should().Contain("/api/v1/groups/");
            
            // Verify lastPush field is present (maybe null for new mappings)
            // ErrorSummary should be empty or null for successful creation
            if (!string.IsNullOrEmpty(createdMapping1.ErrorSummary))
            {
                createdMapping1.ErrorSummary.Should().BeEmpty("successful creation should have no error");
            }

            var mapping1Id = createdMapping1.Id;
            var targetGroupId1 = createdMapping1.TargetGroupId;

            // Scenario 2: CreateGroupPushMappingWithHttpInfoAsync - Verify HTTP response details
            var targetGroupName2 = $"PushTarget-HttpInfo-{guid}";
            var createRequest2 = new CreateGroupPushMappingRequest
            {
                SourceGroupId = fixture.SourceGroup2Id,
                TargetGroupName = targetGroupName2,
                Status = GroupPushMappingStatusUpsert.INACTIVE
            };

            var createResponse = await _groupPushMappingApi.CreateGroupPushMappingWithHttpInfoAsync(
                fixture.TestApplicationId,
                createRequest2);
            _createdMappingIds.Add(createResponse.Data.Id);

            createResponse.Should().NotBeNull();
            createResponse.StatusCode.Should().Be(HttpStatusCode.OK, "POST create should return 200 OK");
            createResponse.Headers.Should().NotBeNull();
            createResponse.Headers.Should().ContainKey("Content-Type");
            createResponse.Data.Should().NotBeNull();
            createResponse.Data.Id.Should().NotBeNullOrEmpty();
            createResponse.Data.Id.Should().StartWith("gPm");
            createResponse.Data.SourceGroupId.Should().Be(fixture.SourceGroup2Id);
            createResponse.Data.Status.Should().Be(GroupPushMappingStatus.INACTIVE);
            createResponse.Data.Links.Should().NotBeNull();
            createResponse.Data.Links.App.Href.Should().Contain(fixture.TestApplicationId);
            createResponse.Data.Links.SourceGroup.Href.Should().Contain(fixture.SourceGroup2Id);
            createResponse.Data.Links.TargetGroup.Href.Should().NotBeNullOrEmpty();

            var mapping2Id = createResponse.Data.Id;

            // Create mapping with another new target group (not linking to existing)
            // Note: Cannot link multiple source groups to the same target group
            var targetGroupName3 = $"PushTarget-Link-{guid}";
            var createRequest3 = new CreateGroupPushMappingRequest
            {
                SourceGroupId = fixture.SourceGroup3Id,
                TargetGroupName = targetGroupName3, // Use a new target group, not existing one
                Status = GroupPushMappingStatusUpsert.ACTIVE
            };

            var createdMapping3 = await _groupPushMappingApi.CreateGroupPushMappingAsync(
                fixture.TestApplicationId,
                createRequest3);
            _createdMappingIds.Add(createdMapping3.Id);

            createdMapping3.Should().NotBeNull();
            createdMapping3.SourceGroupId.Should().Be(fixture.SourceGroup3Id);
            createdMapping3.TargetGroupId.Should().NotBeNullOrEmpty();
            createdMapping3.Status.Should().Be(GroupPushMappingStatus.ACTIVE);

            var mapping3Id = createdMapping3.Id;

            // ==================== READ OPERATIONS ====================

            // GetGroupPushMappingAsync - Retrieve specific mapping by ID
            var retrievedMapping1 = await _groupPushMappingApi.GetGroupPushMappingAsync(
                fixture.TestApplicationId,
                mapping1Id);

            retrievedMapping1.Should().NotBeNull();
            retrievedMapping1.Id.Should().Be(mapping1Id);
            retrievedMapping1.SourceGroupId.Should().Be(fixture.SourceGroup1Id);
            retrievedMapping1.TargetGroupId.Should().Be(targetGroupId1);
            retrievedMapping1.Status.Should().Be(GroupPushMappingStatus.ACTIVE);
            retrievedMapping1.Created.Should().NotBe(default(DateTimeOffset));
            retrievedMapping1.LastUpdated.Should().NotBe(default(DateTimeOffset));
            retrievedMapping1.Created.Should().Be(createdMapping1.Created, "timestamps should match original creation");
            
            // Verify Links structure on retrieved mapping
            retrievedMapping1.Links.Should().NotBeNull();
            retrievedMapping1.Links.App.Should().NotBeNull();
            retrievedMapping1.Links.App.Href.Should().Contain(fixture.TestApplicationId);
            retrievedMapping1.Links.SourceGroup.Should().NotBeNull();
            retrievedMapping1.Links.SourceGroup.Href.Should().Contain(fixture.SourceGroup1Id);
            retrievedMapping1.Links.TargetGroup.Should().NotBeNull();
            retrievedMapping1.Links.TargetGroup.Href.Should().Contain(targetGroupId1);

            // GetGroupPushMappingWithHttpInfoAsync - Verify HTTP response details
            var getResponse = await _groupPushMappingApi.GetGroupPushMappingWithHttpInfoAsync(
                fixture.TestApplicationId,
                mapping2Id);

            getResponse.Should().NotBeNull();
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK, "GET should return 200 OK");
            getResponse.Headers.Should().NotBeNull();
            getResponse.Headers.Should().ContainKey("Content-Type");
            getResponse.Data.Should().NotBeNull();
            getResponse.Data.Id.Should().Be(mapping2Id);
            getResponse.Data.SourceGroupId.Should().Be(fixture.SourceGroup2Id);
            getResponse.Data.Status.Should().Be(GroupPushMappingStatus.INACTIVE);
            getResponse.Data.Created.Should().NotBe(default(DateTimeOffset));
            getResponse.Data.LastUpdated.Should().NotBe(default(DateTimeOffset));
            getResponse.Data.Links.App.Href.Should().Contain(fixture.TestApplicationId);
            getResponse.Data.Links.SourceGroup.Href.Should().Contain(fixture.SourceGroup2Id);

            // ListGroupPushMappings - List all mappings for application
            var allMappings = await _groupPushMappingApi.ListGroupPushMappings(
                fixture.TestApplicationId)
                .ToListAsync();

            allMappings.Should().NotBeNull();
            allMappings.Should().HaveCountGreaterThanOrEqualTo(3, "should have at least our 3 created mappings");
            allMappings.Should().Contain(m => m.Id == mapping1Id);
            allMappings.Should().Contain(m => m.Id == mapping2Id);
            allMappings.Should().Contain(m => m.Id == mapping3Id);
            
            // Verify all mappings have complete data structure
            foreach (var mapping in allMappings)
            {
                mapping.Id.Should().NotBeNullOrEmpty();
                mapping.Id.Should().StartWith("gPm");
                mapping.SourceGroupId.Should().NotBeNullOrEmpty();
                mapping.TargetGroupId.Should().NotBeNullOrEmpty();
                mapping.Status.Should().NotBeNull();
                mapping.Created.Should().NotBe(default(DateTimeOffset));
                mapping.LastUpdated.Should().NotBe(default(DateTimeOffset));
                mapping.Links.Should().NotBeNull();
                mapping.Links.App.Should().NotBeNull();
                mapping.Links.SourceGroup.Should().NotBeNull();
                mapping.Links.TargetGroup.Should().NotBeNull();
            }

            // ListGroupPushMappings with filtering by sourceGroupId
            var filteredBySource = await _groupPushMappingApi.ListGroupPushMappings(
                fixture.TestApplicationId,
                sourceGroupId: fixture.SourceGroup1Id)
                .ToListAsync();

            filteredBySource.Should().NotBeNull();
            filteredBySource.Should().Contain(m => m.Id == mapping1Id);
            filteredBySource.Should().AllSatisfy(m => m.SourceGroupId.Should().Be(fixture.SourceGroup1Id));

            // ListGroupPushMappings with filtering by status
            var activeOnly = await _groupPushMappingApi.ListGroupPushMappings(
                fixture.TestApplicationId,
                status: GroupPushMappingStatus.ACTIVE)
                .ToListAsync();

            activeOnly.Should().NotBeNull();
            activeOnly.Should().Contain(m => m.Id == mapping1Id);
            activeOnly.Should().Contain(m => m.Id == mapping3Id);
            activeOnly.Should().AllSatisfy(m => m.Status.Should().Be(GroupPushMappingStatus.ACTIVE));

            var inactiveOnly = await _groupPushMappingApi.ListGroupPushMappings(
                fixture.TestApplicationId,
                status: GroupPushMappingStatus.INACTIVE)
                .ToListAsync();

            inactiveOnly.Should().NotBeNull();
            inactiveOnly.Should().Contain(m => m.Id == mapping2Id);
            inactiveOnly.Should().AllSatisfy(m => m.Status.Should().Be(GroupPushMappingStatus.INACTIVE));

            // ListGroupPushMappings with limit parameter
            var limitedMappings = await _groupPushMappingApi.ListGroupPushMappings(
                fixture.TestApplicationId,
                limit: 2)
                .Take(2)
                .ToListAsync();

            limitedMappings.Should().NotBeNull();
            limitedMappings.Should().HaveCountLessThanOrEqualTo(2);

            // ListGroupPushMappings with pagination (after cursor)
            var firstPage = await _groupPushMappingApi.ListGroupPushMappings(
                fixture.TestApplicationId,
                limit: 1)
                .Take(1)
                .ToListAsync();

            firstPage.Should().HaveCount(1);

            // Get the next page using pagination
            var secondPage = await _groupPushMappingApi.ListGroupPushMappings(
                fixture.TestApplicationId,
                after: firstPage[0].Id,
                limit: 1)
                .Take(1)
                .ToListAsync();

            if (secondPage.Count > 0)
            {
                secondPage[0].Id.Should().NotBe(firstPage[0].Id, "pagination should return different results");
            }

            // ListGroupPushMappings with lastUpdated filter
            var yesterday = DateTimeOffset.UtcNow.AddDays(-1).ToString("yyyy-MM-ddTHH:mm:ssZ");
            var recentMappings = await _groupPushMappingApi.ListGroupPushMappings(
                fixture.TestApplicationId,
                lastUpdated: yesterday)
                .ToListAsync();

            recentMappings.Should().NotBeNull();
            recentMappings.Should().Contain(m => m.Id == mapping1Id);
            recentMappings.Should().Contain(m => m.Id == mapping2Id);

            // ListGroupPushMappingsWithHttpInfoAsync - Verify HTTP response
            var listResponse = await _groupPushMappingApi.ListGroupPushMappingsWithHttpInfoAsync(
                fixture.TestApplicationId);

            listResponse.Should().NotBeNull();
            listResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            listResponse.Headers.Should().NotBeNull();
            listResponse.Data.Should().NotBeNull();
            listResponse.Data.Should().HaveCountGreaterThanOrEqualTo(3);

            // ==================== UPDATE OPERATIONS ====================

            // UpdateGroupPushMappingAsync - Change status from ACTIVE to INACTIVE
            var updateRequest1 = new UpdateGroupPushMappingRequest
            {
                Status = GroupPushMappingStatusUpsert.INACTIVE
            };

            var updatedMapping1 = await _groupPushMappingApi.UpdateGroupPushMappingAsync(
                fixture.TestApplicationId,
                mapping1Id,
                updateRequest1);

            updatedMapping1.Should().NotBeNull();
            updatedMapping1.Id.Should().Be(mapping1Id);
            updatedMapping1.Status.Should().Be(GroupPushMappingStatus.INACTIVE);
            updatedMapping1.LastUpdated.Should().BeOnOrBefore(DateTimeOffset.UtcNow);
            updatedMapping1.LastUpdated.Should().BeAfter(createdMapping1.LastUpdated, "lastUpdated should be newer after update");
            
            // Verify all other fields remain unchanged
            updatedMapping1.SourceGroupId.Should().Be(fixture.SourceGroup1Id);
            updatedMapping1.TargetGroupId.Should().Be(targetGroupId1);
            updatedMapping1.Created.Should().Be(createdMapping1.Created, "created timestamp should not change");
            updatedMapping1.Links.Should().NotBeNull();
            updatedMapping1.Links.App.Href.Should().Contain(fixture.TestApplicationId);

            // Verify the status change persisted
            var verifyInactive = await _groupPushMappingApi.GetGroupPushMappingAsync(
                fixture.TestApplicationId,
                mapping1Id);
            verifyInactive.Status.Should().Be(GroupPushMappingStatus.INACTIVE);

            // UpdateGroupPushMappingAsync - Change status from INACTIVE to ACTIVE
            var updateRequest2 = new UpdateGroupPushMappingRequest
            {
                Status = GroupPushMappingStatusUpsert.ACTIVE
            };

            var updatedMapping2 = await _groupPushMappingApi.UpdateGroupPushMappingAsync(
                fixture.TestApplicationId,
                mapping2Id,
                updateRequest2);

            updatedMapping2.Should().NotBeNull();
            updatedMapping2.Id.Should().Be(mapping2Id);
            updatedMapping2.Status.Should().Be(GroupPushMappingStatus.ACTIVE);

            // UpdateGroupPushMappingWithHttpInfoAsync - Verify HTTP response
            var updateRequest3 = new UpdateGroupPushMappingRequest
            {
                Status = GroupPushMappingStatusUpsert.INACTIVE
            };

            var updateResponse = await _groupPushMappingApi.UpdateGroupPushMappingWithHttpInfoAsync(
                fixture.TestApplicationId,
                mapping3Id,
                updateRequest3);

            updateResponse.Should().NotBeNull();
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK, "PATCH update should return 200 OK");
            updateResponse.Headers.Should().NotBeNull();
            updateResponse.Headers.Should().ContainKey("Content-Type");
            updateResponse.Data.Should().NotBeNull();
            updateResponse.Data.Id.Should().Be(mapping3Id);
            updateResponse.Data.Status.Should().Be(GroupPushMappingStatus.INACTIVE);
            updateResponse.Data.LastUpdated.Should().BeAfter(createdMapping3.LastUpdated);
            updateResponse.Data.SourceGroupId.Should().Be(fixture.SourceGroup3Id, "source group should not change");
            updateResponse.Data.Created.Should().Be(createdMapping3.Created, "created timestamp should not change");

            // ==================== DELETE OPERATIONS ====================

            // DeleteGroupPushMappingAsync - Delete without deleting target group
            // Mapping must be INACTIVE to delete (mapping1 is already INACTIVE from update)
            await _groupPushMappingApi.DeleteGroupPushMappingAsync(
                fixture.TestApplicationId,
                mapping1Id,
                deleteTargetGroup: false);

            _createdMappingIds.Remove(mapping1Id);

            // Verify deletion - should throw 404
            var deleteVerifyException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _groupPushMappingApi.GetGroupPushMappingAsync(
                    fixture.TestApplicationId,
                    mapping1Id);
            });
            
            deleteVerifyException.ErrorCode.Should().Be(404, "deleted mapping should return 404");
            deleteVerifyException.Message.Should().Contain("Not found", "error message should indicate resource not found");

            // DeleteGroupPushMappingAsync - Delete with target group deletion
            // First ensure mapping2 is INACTIVE (it was changed to ACTIVE earlier, so deactivate it)
            await _groupPushMappingApi.UpdateGroupPushMappingAsync(
                fixture.TestApplicationId,
                mapping2Id,
                new UpdateGroupPushMappingRequest { Status = GroupPushMappingStatusUpsert.INACTIVE });

            await _groupPushMappingApi.DeleteGroupPushMappingAsync(
                fixture.TestApplicationId,
                mapping2Id,
                deleteTargetGroup: true);

            _createdMappingIds.Remove(mapping2Id);

            // Verify mapping deletion
            var deleteVerify2Exception = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _groupPushMappingApi.GetGroupPushMappingAsync(
                    fixture.TestApplicationId,
                    mapping2Id);
            });
            
            deleteVerify2Exception.ErrorCode.Should().Be(404);
            deleteVerify2Exception.Message.Should().NotBeNullOrEmpty();

            // DeleteGroupPushMappingWithHttpInfoAsync - Verify HTTP response
            // mapping3 is already INACTIVE from earlier update
            var deleteResponse = await _groupPushMappingApi.DeleteGroupPushMappingWithHttpInfoAsync(
                fixture.TestApplicationId,
                mapping3Id,
                deleteTargetGroup: false);

            deleteResponse.Should().NotBeNull();
            // API may return either 200 OK or 204 NoContent for successful deletion
            var validStatusCodes = new[] { HttpStatusCode.OK, HttpStatusCode.NoContent };
            validStatusCodes.Should().Contain(deleteResponse.StatusCode, 
                "DELETE should return 200 OK or 204 NoContent");
            deleteResponse.Headers.Should().NotBeNull();
            _createdMappingIds.Remove(mapping3Id);

            // Verify deletion
            var deleteVerify3Exception = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _groupPushMappingApi.GetGroupPushMappingAsync(
                    fixture.TestApplicationId,
                    mapping3Id);
            });
            
            deleteVerify3Exception.ErrorCode.Should().Be(404);
            deleteVerify3Exception.Message.Should().NotBeNullOrEmpty();

            // ==================== EDGE CASES & VALIDATION ====================

            // Verify all mappings have been cleaned up
            var remainingMappings = await _groupPushMappingApi.ListGroupPushMappings(
                fixture.TestApplicationId)
                .ToListAsync();

            remainingMappings.Should().NotContain(m => m.Id == mapping1Id);
            remainingMappings.Should().NotContain(m => m.Id == mapping2Id);
            remainingMappings.Should().NotContain(m => m.Id == mapping3Id);
        }

        /// <summary>
        /// Tests error scenarios and proper error handling for Group Push Mapping API.
        /// Validates that appropriate HTTP status codes and error messages are returned
        /// for invalid operations.
        /// </summary>
        [Fact]
        public async Task GivenInvalidOperations_WhenCallingApi_ThenCorrectErrorCodesAreReturned()
        {
            var guid = Guid.NewGuid();
            var nonExistentAppId = "0oa" + guid.ToString("N").Substring(0, 17);
            var nonExistentMappingId = "gPm" + guid.ToString("N").Substring(0, 17);

            // ==================== ERROR SCENARIOS ====================

            // GetGroupPushMappingAsync - 404 for non-existent mapping
            var getException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _groupPushMappingApi.GetGroupPushMappingAsync(
                    fixture.TestApplicationId,
                    nonExistentMappingId);
            });

            getException.Should().NotBeNull();
            getException.ErrorCode.Should().Be(404, "non-existent mapping should return 404");
            getException.Message.Should().NotBeNullOrEmpty("error should have message");
            getException.ErrorContent.Should().NotBeNull("error should have content");
            getException.Message.Should().Contain("Not found", "error message should indicate resource not found");

            // CreateGroupPushMappingAsync - 400 for missing required sourceGroupId
            var createException1 = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                var invalidRequest = new CreateGroupPushMappingRequest
                {
                    // Missing SourceGroupId
                    TargetGroupName = $"Invalid-{guid}",
                    Status = GroupPushMappingStatusUpsert.ACTIVE
                };

                await _groupPushMappingApi.CreateGroupPushMappingAsync(
                    fixture.TestApplicationId,
                    invalidRequest);
            });

            createException1.Should().NotBeNull();
            createException1.ErrorCode.Should().Be(400, "missing sourceGroupId should return 400 Bad Request");
            createException1.Message.Should().NotBeNullOrEmpty();
            createException1.ErrorContent.Should().NotBeNull();
            // Error should mention missing source information - using OR logic for flexible matching
            var hasSourceError = createException1.Message.Contains("sourceGroupId", StringComparison.OrdinalIgnoreCase) ||
                                 createException1.Message.Contains("source", StringComparison.OrdinalIgnoreCase) ||
                                 createException1.Message.Contains("required", StringComparison.OrdinalIgnoreCase);
            hasSourceError.Should().BeTrue("error should mention missing sourceGroupId");

            // CreateGroupPushMappingAsync - 400 for missing both targetGroupId and targetGroupName
            var createException2 = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                var invalidRequest = new CreateGroupPushMappingRequest
                {
                    SourceGroupId = fixture.SourceGroup1Id,
                    // Missing both TargetGroupId and TargetGroupName
                    Status = GroupPushMappingStatusUpsert.ACTIVE
                };

                await _groupPushMappingApi.CreateGroupPushMappingAsync(
                    fixture.TestApplicationId,
                    invalidRequest);
            });

            createException2.Should().NotBeNull();
            createException2.ErrorCode.Should().Be(400, "missing target should return 400 Bad Request");
            createException2.Message.Should().NotBeNullOrEmpty();
            createException2.ErrorContent.Should().NotBeNull();
            // Error should mention missing target information
            var hasTargetError = createException2.Message.Contains("target", StringComparison.OrdinalIgnoreCase) ||
                                 createException2.Message.Contains("required", StringComparison.OrdinalIgnoreCase);
            hasTargetError.Should().BeTrue("error should mention missing target group information");

            // CreateGroupPushMappingAsync - 404 for non-existent application
            var createException3 = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                var validRequest = new CreateGroupPushMappingRequest
                {
                    SourceGroupId = fixture.SourceGroup1Id,
                    TargetGroupName = $"Test-{guid}",
                    Status = GroupPushMappingStatusUpsert.ACTIVE
                };

                await _groupPushMappingApi.CreateGroupPushMappingAsync(
                    nonExistentAppId,
                    validRequest);
            });

            createException3.Should().NotBeNull();
            createException3.ErrorCode.Should().Be(404, "non-existent app should return 404");
            createException3.Message.Should().NotBeNullOrEmpty();
            createException3.ErrorContent.Should().NotBeNull();
            createException3.Message.Should().Contain("Not found");

            // UpdateGroupPushMappingAsync - 404 for non-existent mapping
            var updateException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                var updateRequest = new UpdateGroupPushMappingRequest
                {
                    Status = GroupPushMappingStatusUpsert.INACTIVE
                };

                await _groupPushMappingApi.UpdateGroupPushMappingAsync(
                    fixture.TestApplicationId,
                    nonExistentMappingId,
                    updateRequest);
            });

            updateException.Should().NotBeNull();
            updateException.ErrorCode.Should().Be(404, "updating non-existent mapping should return 404");
            updateException.Message.Should().NotBeNullOrEmpty();
            updateException.ErrorContent.Should().NotBeNull();
            updateException.Message.Should().Contain("Not found");

            // DeleteGroupPushMappingAsync - 404 for non-existent mapping
            var deleteException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _groupPushMappingApi.DeleteGroupPushMappingAsync(
                    fixture.TestApplicationId,
                    nonExistentMappingId,
                    deleteTargetGroup: false);
            });

            deleteException.Should().NotBeNull();
            deleteException.ErrorCode.Should().Be(404, "deleting non-existent mapping should return 404");
            deleteException.Message.Should().NotBeNullOrEmpty();
            deleteException.ErrorContent.Should().NotBeNull();
            deleteException.Message.Should().Contain("Not found");

            // DeleteGroupPushMappingAsync - Cannot delete ACTIVE mapping
            // Create a mapping in ACTIVE state
            var createRequest = new CreateGroupPushMappingRequest
            {
                SourceGroupId = fixture.SourceGroup1Id,
                TargetGroupName = $"DeleteActiveTest-{guid}",
                Status = GroupPushMappingStatusUpsert.ACTIVE
            };

            var createdMapping = await _groupPushMappingApi.CreateGroupPushMappingAsync(
                fixture.TestApplicationId,
                createRequest);
            _createdMappingIds.Add(createdMapping.Id);

            try
            {
                // Try to delete it while ACTIVE - should fail
                var deleteActiveException = await Assert.ThrowsAsync<ApiException>(async () =>
                {
                    await _groupPushMappingApi.DeleteGroupPushMappingAsync(
                        fixture.TestApplicationId,
                        createdMapping.Id,
                        deleteTargetGroup: false);
                });

                deleteActiveException.Should().NotBeNull();
                deleteActiveException.ErrorCode.Should().Be(400, "cannot delete ACTIVE mapping - should return 400");
                deleteActiveException.Message.Should().NotBeNullOrEmpty();
                deleteActiveException.ErrorContent.Should().NotBeNull();
                // Error should indicate that mapping must be INACTIVE before deletion
                var hasInactiveError = deleteActiveException.Message.Contains("INACTIVE", StringComparison.OrdinalIgnoreCase) ||
                                       deleteActiveException.Message.Contains("deactivate", StringComparison.OrdinalIgnoreCase);
                hasInactiveError.Should().BeTrue("error message should indicate mapping must be INACTIVE");
            }
            finally
            {
                // Clean up - deactivate then delete
                try
                {
                    await _groupPushMappingApi.UpdateGroupPushMappingAsync(
                        fixture.TestApplicationId,
                        createdMapping.Id,
                        new UpdateGroupPushMappingRequest { Status = GroupPushMappingStatusUpsert.INACTIVE });

                    await _groupPushMappingApi.DeleteGroupPushMappingAsync(
                        fixture.TestApplicationId,
                        createdMapping.Id,
                        deleteTargetGroup: false);

                    _createdMappingIds.Remove(createdMapping.Id);
                }
                catch (ApiException) { }
            }

            // CreateGroupPushMappingAsync - Invalid sourceGroupId
            var invalidSourceException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                var invalidRequest = new CreateGroupPushMappingRequest
                {
                    SourceGroupId = "00g" + guid.ToString("N").Substring(0, 17), // Non-existent group
                    TargetGroupName = $"InvalidSource-{guid}",
                    Status = GroupPushMappingStatusUpsert.ACTIVE
                };

                await _groupPushMappingApi.CreateGroupPushMappingAsync(
                    fixture.TestApplicationId,
                    invalidRequest);
            });

            invalidSourceException.Should().NotBeNull();
            var validInvalidSourceCodes = new[] { 400, 404 };
            validInvalidSourceCodes.Should().Contain(invalidSourceException.ErrorCode, 
                "invalid source group should return 400 or 404");
            invalidSourceException.Message.Should().NotBeNullOrEmpty();
            invalidSourceException.ErrorContent.Should().NotBeNull();

            // ListGroupPushMappings - 404 for non-existent application
            var listException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _groupPushMappingApi.ListGroupPushMappings(nonExistentAppId)
                    .ToListAsync();
            });

            listException.Should().NotBeNull();
            listException.ErrorCode.Should().Be(404, "listing mappings for non-existent app should return 404");
            listException.Message.Should().NotBeNullOrEmpty();
            listException.ErrorContent.Should().NotBeNull();
            listException.Message.Should().Contain("Not found");

            // Verify error messages are meaningful
            // All thrown exceptions should have non-empty error messages
            var allExceptions = new[]
            {
                getException,
                createException1,
                createException2,
                createException3,
                updateException,
                deleteException,
                invalidSourceException,
                listException
            };

            foreach (var exception in allExceptions)
            {
                exception.Message.Should().NotBeNullOrEmpty("all API errors should have meaningful messages");
                exception.ErrorContent.Should().NotBeNull("all API errors should have error content");
            }
        }

        /// <summary>
        /// Tests that verify the group push mapping lifecycle with proper state transitions.
        /// Ensures that status changes are properly enforced and mappings can only be deleted
        /// when in INACTIVE state.
        /// </summary>
        [Fact]
        public async Task GivenLifecycleOperations_WhenPerforming_ThenProperLifecycleIsEnforced()
        {
            var guid = Guid.NewGuid();

            // Create a mapping in ACTIVE state
            var createRequest = new CreateGroupPushMappingRequest
            {
                SourceGroupId = fixture.SourceGroup1Id,
                TargetGroupName = $"LifecycleTest-{guid}",
                Status = GroupPushMappingStatusUpsert.ACTIVE
            };

            var mapping = await _groupPushMappingApi.CreateGroupPushMappingAsync(
                fixture.TestApplicationId,
                createRequest);
            _createdMappingIds.Add(mapping.Id);

            try
            {
                // Verify initial state
                mapping.Status.Should().Be(GroupPushMappingStatus.ACTIVE);

                // Transition: ACTIVE → INACTIVE
                var deactivateRequest = new UpdateGroupPushMappingRequest
                {
                    Status = GroupPushMappingStatusUpsert.INACTIVE
                };

                var deactivatedMapping = await _groupPushMappingApi.UpdateGroupPushMappingAsync(
                    fixture.TestApplicationId,
                    mapping.Id,
                    deactivateRequest);

                deactivatedMapping.Status.Should().Be(GroupPushMappingStatus.INACTIVE);

                // Transition: INACTIVE → ACTIVE
                var reactivateRequest = new UpdateGroupPushMappingRequest
                {
                    Status = GroupPushMappingStatusUpsert.ACTIVE
                };

                var reactivatedMapping = await _groupPushMappingApi.UpdateGroupPushMappingAsync(
                    fixture.TestApplicationId,
                    mapping.Id,
                    reactivateRequest);

                reactivatedMapping.Status.Should().Be(GroupPushMappingStatus.ACTIVE);

                // Final transition to INACTIVE before deletion
                await _groupPushMappingApi.UpdateGroupPushMappingAsync(
                    fixture.TestApplicationId,
                    mapping.Id,
                    deactivateRequest);

                // Now delete should succeed
                await _groupPushMappingApi.DeleteGroupPushMappingAsync(
                    fixture.TestApplicationId,
                    mapping.Id,
                    deleteTargetGroup: false);

                _createdMappingIds.Remove(mapping.Id);

                // Verify deletion
                await Assert.ThrowsAsync<ApiException>(async () =>
                {
                    await _groupPushMappingApi.GetGroupPushMappingAsync(
                        fixture.TestApplicationId,
                        mapping.Id);
                });
            }
            catch
            {
                // Cleanup on failure
                try
                {
                    await _groupPushMappingApi.UpdateGroupPushMappingAsync(
                        fixture.TestApplicationId,
                        mapping.Id,
                        new UpdateGroupPushMappingRequest { Status = GroupPushMappingStatusUpsert.INACTIVE });

                    await _groupPushMappingApi.DeleteGroupPushMappingAsync(
                        fixture.TestApplicationId,
                        mapping.Id,
                        deleteTargetGroup: false);

                    _createdMappingIds.Remove(mapping.Id);
                }
                catch (ApiException) { }

                throw;
            }
        }
    }
}
