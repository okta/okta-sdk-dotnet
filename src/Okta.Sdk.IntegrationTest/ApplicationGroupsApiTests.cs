// <copyright file="ApplicationGroupsApiTests.cs" company="Okta, Inc">
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
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Integration tests for ApplicationGroupsApi
    /// Tests group assignment operations for applications
    /// </summary>
    [Collection(nameof(ApplicationGroupsApiTests))]
    public class ApplicationGroupsApiTests : IAsyncLifetime
    {
        private ApplicationApi _applicationApi;
        private ApplicationGroupsApi _applicationGroupsApi;
        private GroupApi _groupApi;
        private string _testAppId;
        private string _testGroupId;

        public async Task InitializeAsync()
        {
            _applicationApi = new ApplicationApi();
            _applicationGroupsApi = new ApplicationGroupsApi();
            _groupApi = new GroupApi();

            // Create a test application
            var testApp = new BookmarkApplication
            {
                Name = "bookmark",
                Label = $"Test App for Groups {Guid.NewGuid()}",
                Settings = new BookmarkApplicationSettings
                {
                    App = new BookmarkApplicationSettingsApplication
                    {
                        Url = "https://example.com/bookmark",
                        RequestIntegration = false
                    }
                }
            };

            var createdApp = await _applicationApi.CreateApplicationAsync(testApp);
            _testAppId = createdApp.Id;

            // Create a test group
            var testGroup = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile 
                { 
                    Name = $"Test Group for App Assignment {Guid.NewGuid()}", 
                    Description = "Integration test group for app assignment" 
                }
            };

            var createdGroup = await _groupApi.AddGroupAsync(testGroup);
            _testGroupId = createdGroup.Id;

            await Task.Delay(3000); // Wait for resources to be ready
        }

        public async Task DisposeAsync()
        {
            if (!string.IsNullOrEmpty(_testGroupId))
            {
                try
                {
                    await _groupApi.DeleteGroupAsync(_testGroupId);
                }
                catch
                {
                    // Best effort cleanup
                }
            }

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
        public async Task GivenGroupAndApplication_WhenAssigningAndRetrieving_ThenAssignmentIsSuccessful()
        {
            // Arrange
            var groupAssignment = new ApplicationGroupAssignment
            {
                Priority = 0
            };

            // Act - Assign a group to application
            var assignment = await _applicationGroupsApi.AssignGroupToApplicationAsync(_testAppId, _testGroupId, groupAssignment);

            // Assert - Verify assignment was created with all expected fields
            assignment.Should().NotBeNull();
            assignment.Id.Should().Be(_testGroupId);
            assignment.Priority.Should().Be(0);
            assignment.Links.Should().NotBeNull();
            assignment.Links.App.Should().NotBeNull();
            assignment.Links.Group.Should().NotBeNull();

            await Task.Delay(3000);

            // Act - Retrieve the specific assignment
            var retrievedAssignment = await _applicationGroupsApi.GetApplicationGroupAssignmentAsync(_testAppId, _testGroupId);

            // Assert - Verify retrieved assignment matches created assignment
            retrievedAssignment.Should().NotBeNull();
            retrievedAssignment.Id.Should().Be(_testGroupId);
            retrievedAssignment.Priority.Should().Be(0);
            retrievedAssignment.Links.Should().NotBeNull();
        }

        [Fact]
        public async Task GivenApplicationGroupAssignments_WhenListing_ThenAssignmentsAreReturned()
        {
            // Arrange - Assign a group to application
            var groupAssignment = new ApplicationGroupAssignment
            {
                Priority = 0
            };

            await _applicationGroupsApi.AssignGroupToApplicationAsync(_testAppId, _testGroupId, groupAssignment);

            // Act - List all group assignments with retry for eventual consistency
            ApiResponse<List<ApplicationGroupAssignment>> assignments = null;
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(2000);
                assignments = await _applicationGroupsApi.ListApplicationGroupAssignmentsWithHttpInfoAsync(_testAppId);
                if (assignments.Data != null && assignments.Data.Count > 0)
                    break;
            }

            // Assert - Validate response and assignment details
            assignments.Should().NotBeNull();
            assignments.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            assignments.Data.Should().NotBeNull();
            assignments.Data.Should().HaveCountGreaterThanOrEqualTo(1);
            
            var matchingAssignment = assignments.Data.FirstOrDefault(a => a.Id == _testGroupId);
            matchingAssignment.Should().NotBeNull();
            if (matchingAssignment != null)
            {
                matchingAssignment.Priority.Should().Be(0);
                matchingAssignment.Links.Should().NotBeNull();
            }
        }

        [Fact]
        public async Task GivenQueryParameter_WhenListingAssignments_ThenFilteredAssignmentsAreReturned()
        {
            // Arrange - Get the group name for a query
            var group = await _groupApi.GetGroupAsync(_testGroupId);
            
            // Handle different group profile types
            string groupName;
            if (group.Profile.ActualInstance is OktaUserGroupProfile userGroupProfile)
            {
                groupName = userGroupProfile.Name;
            }
            else if (group.Profile.ActualInstance is OktaActiveDirectoryGroupProfile adGroupProfile)
            {
                groupName = adGroupProfile.Name;
            }
            else
            {
                groupName = "TestGroup"; // Fallback
            }
            
            var groupNamePrefix = groupName.Length > 10 ? groupName.Substring(0, 10) : groupName;

            var groupAssignment = new ApplicationGroupAssignment
            {
                Priority = 0
            };

            await _applicationGroupsApi.AssignGroupToApplicationAsync(_testAppId, _testGroupId, groupAssignment);

            // Act - List assignments with query filter (with retry for eventual consistency)
            ApiResponse<List<ApplicationGroupAssignment>> assignments = null;
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(2000);
                assignments = await _applicationGroupsApi.ListApplicationGroupAssignmentsWithHttpInfoAsync(
                    _testAppId, 
                    q: groupNamePrefix
                );
                if (assignments.Data != null && assignments.Data.Count > 0)
                    break;
            }

            // Assert
            assignments.Should().NotBeNull();
            assignments.Data.Should().NotBeNull();
            assignments.Data.Should().HaveCountGreaterThanOrEqualTo(1);
        }

        [Fact]
        public async Task GivenMultipleAssignments_WhenListingWithPagination_ThenPaginationWorks()
        {
            // Arrange - Assign a group
            var groupAssignment = new ApplicationGroupAssignment
            {
                Priority = 0
            };

            await _applicationGroupsApi.AssignGroupToApplicationAsync(_testAppId, _testGroupId, groupAssignment);

            // Act - List with limit parameter (with retry for eventual consistency)
            ApiResponse<List<ApplicationGroupAssignment>> assignments = null;
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(2000);
                assignments = await _applicationGroupsApi.ListApplicationGroupAssignmentsWithHttpInfoAsync(
                    _testAppId,
                    limit: 10
                );
                if (assignments.Data != null)
                    break;
            }

            // Assert
            assignments.Should().NotBeNull();
            assignments.Data.Should().NotBeNull();
            assignments.Data.Count.Should().BeLessThanOrEqualTo(10);
        }

        [Fact]
        public async Task GivenExpandParameter_WhenListingAssignments_ThenExpandedDataIsReturned()
        {
            // Arrange - Assign a group
            var groupAssignment = new ApplicationGroupAssignment
            {
                Priority = 0
            };

            await _applicationGroupsApi.AssignGroupToApplicationAsync(_testAppId, _testGroupId, groupAssignment);

            // Act - List with expanded parameter (with retry for eventual consistency)
            ApiResponse<List<ApplicationGroupAssignment>> assignments = null;
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(2000);
                assignments = await _applicationGroupsApi.ListApplicationGroupAssignmentsWithHttpInfoAsync(
                    _testAppId,
                    expand: "group"
                );
                if (assignments.Data != null && assignments.Data.Count > 0)
                    break;
            }

            // Assert
            assignments.Should().NotBeNull();
            assignments.Data.Should().NotBeNull();
            assignments.Data.Should().HaveCountGreaterThanOrEqualTo(1);
        }

        [Fact]
        public async Task GivenExpandParameter_WhenGettingAssignment_ThenExpandedDataIsReturned()
        {
            // Arrange - Assign a group
            var groupAssignment = new ApplicationGroupAssignment
            {
                Priority = 0
            };

            await _applicationGroupsApi.AssignGroupToApplicationAsync(_testAppId, _testGroupId, groupAssignment);
            await Task.Delay(3000);

            // Act - Get assignment with expanding
            var assignment = await _applicationGroupsApi.GetApplicationGroupAssignmentAsync(
                _testAppId,
                _testGroupId,
                expand: "group"
            );

            // Assert
            assignment.Should().NotBeNull();
            assignment.Id.Should().Be(_testGroupId);
        }

        [Fact]
        public async Task GivenGroupAssignment_WhenUpdating_ThenAssignmentIsUpdated()
        {
            // Arrange - Assign a group with priority 0
            var initialAssignment = new ApplicationGroupAssignment
            {
                Priority = 0
            };

            await _applicationGroupsApi.AssignGroupToApplicationAsync(_testAppId, _testGroupId, initialAssignment);
            await Task.Delay(3000);

            // Act - Update assignment priority using JSON Patch
            var patchOperations = new List<JsonPatchOperation>
            {
                new JsonPatchOperation
                {
                    Op = "replace",
                    Path = "/priority",
                    Value = 5
                }
            };

            var updatedAssignment = await _applicationGroupsApi.UpdateGroupAssignmentToApplicationAsync(
                _testAppId,
                _testGroupId,
                patchOperations
            );

            // Assert - Verify the priority was actually updated
            updatedAssignment.Should().NotBeNull();
            updatedAssignment.Id.Should().Be(_testGroupId);
            updatedAssignment.Priority.Should().Be(5);
            updatedAssignment.Links.Should().NotBeNull();

            await Task.Delay(500);

            // Verify update persisted by retrieving the assignment again
            var retrievedAssignment = await _applicationGroupsApi.GetApplicationGroupAssignmentAsync(_testAppId, _testGroupId);
            retrievedAssignment.Should().NotBeNull();
            retrievedAssignment.Priority.Should().Be(5, "priority update should persist");
        }

        [Fact]
        public async Task GivenGroupAssignment_WhenUnassigning_ThenAssignmentIsRemoved()
        {
            // Arrange - Assign a group to application
            var groupAssignment = new ApplicationGroupAssignment
            {
                Priority = 0
            };

            await _applicationGroupsApi.AssignGroupToApplicationAsync(_testAppId, _testGroupId, groupAssignment);
            await Task.Delay(3000);

            // Act - Unassign the group
            await _applicationGroupsApi.UnassignApplicationFromGroupAsync(_testAppId, _testGroupId);
            await Task.Delay(3000);

            // Assert - Verify assignment is removed (should throw 404)
            Func<Task> act = async () => await _applicationGroupsApi.GetApplicationGroupAssignmentAsync(_testAppId, _testGroupId);
            await act.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404);
        }

        [Fact]
        public async Task GivenGroupAndApplication_WhenAssigningWithHttpInfo_ThenHttpResponseIsReturned()
        {
            // Arrange
            var groupAssignment = new ApplicationGroupAssignment
            {
                Priority = 0
            };

            // Act
            var response = await _applicationGroupsApi.AssignGroupToApplicationWithHttpInfoAsync(_testAppId, _testGroupId, groupAssignment);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_testGroupId);
        }

        [Fact]
        public async Task GivenAssignment_WhenGettingWithHttpInfo_ThenHttpResponseIsReturned()
        {
            // Arrange - Assign a group
            var groupAssignment = new ApplicationGroupAssignment
            {
                Priority = 0
            };

            await _applicationGroupsApi.AssignGroupToApplicationAsync(_testAppId, _testGroupId, groupAssignment);
            await Task.Delay(3000);

            // Act
            var response = await _applicationGroupsApi.GetApplicationGroupAssignmentWithHttpInfoAsync(_testAppId, _testGroupId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(_testGroupId);
        }

        [Fact]
        public async Task GivenAssignment_WhenUpdatingWithHttpInfo_ThenHttpResponseIsReturned()
        {
            // Arrange - Assign a group
            var groupAssignment = new ApplicationGroupAssignment
            {
                Priority = 0
            };

            await _applicationGroupsApi.AssignGroupToApplicationAsync(_testAppId, _testGroupId, groupAssignment);
            await Task.Delay(3000);

            var patchOperations = new List<JsonPatchOperation>
            {
                new JsonPatchOperation
                {
                    Op = "replace",
                    Path = "/priority",
                    Value = 3
                }
            };

            // Act
            var response = await _applicationGroupsApi.UpdateGroupAssignmentToApplicationWithHttpInfoAsync(
                _testAppId,
                _testGroupId,
                patchOperations
            );

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Data.Should().NotBeNull();
            response.Data.Priority.Should().Be(3);
        }

        [Fact]
        public async Task GivenAssignment_WhenUnassigningWithHttpInfo_ThenHttpResponseIsReturned()
        {
            // Arrange - Assign a group
            var groupAssignment = new ApplicationGroupAssignment
            {
                Priority = 0
            };

            await _applicationGroupsApi.AssignGroupToApplicationAsync(_testAppId, _testGroupId, groupAssignment);
            await Task.Delay(3000);

            // Act
            var response = await _applicationGroupsApi.UnassignApplicationFromGroupWithHttpInfoAsync(_testAppId, _testGroupId);

            // Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }
    }
}
