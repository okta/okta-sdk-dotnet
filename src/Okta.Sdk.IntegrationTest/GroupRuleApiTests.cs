// <copyright file="GroupRuleApiTests.cs" company="Okta, Inc">
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
    [Collection(nameof(GroupRuleApiTests))]
    public class GroupRuleApiTests : IAsyncLifetime
    {
        private readonly GroupRuleApi _groupRuleApi = new();
        private readonly GroupApi _groupApi = new();
        private readonly UserApi _userApi = new();
        private readonly UserLifecycleApi _userLifecycleApi = new();

        // Target groups for rule assignments
        private string TargetGroup1Id { get; set; }
        private string TargetGroup2Id { get; set; }
        private string TargetGroup3Id { get; set; }

        // Test users for validation
        private string TestUser1Id { get; set; }
        private string TestUser2Id { get; set; }

        // Track created group rules for cleanup
        private readonly List<string> _createdGroupRuleIds = [];

        private string TestGuid { get; set; }

        public async Task InitializeAsync()
        {
            TestGuid = Guid.NewGuid().ToString();

            // Create target groups for rule assignments
            var targetGroup1 = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"GroupRuleTarget1-{TestGuid}",
                    Description = "Target group for group rule testing"
                }
            };

            var targetGroup2 = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"GroupRuleTarget2-{TestGuid}",
                    Description = "Second target group for group rule testing"
                }
            };

            var targetGroup3 = new AddGroupRequest
            {
                Profile = new OktaUserGroupProfile
                {
                    Name = $"GroupRuleTarget3-{TestGuid}",
                    Description = "Third target group for group rule testing"
                }
            };

            var createdGroup1 = await _groupApi.AddGroupAsync(targetGroup1);
            var createdGroup2 = await _groupApi.AddGroupAsync(targetGroup2);
            var createdGroup3 = await _groupApi.AddGroupAsync(targetGroup3);

            TargetGroup1Id = createdGroup1.Id;
            TargetGroup2Id = createdGroup2.Id;
            TargetGroup3Id = createdGroup3.Id;

            // Create test users for validation
            var testUser1 = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "GroupRuleTest1",
                    LastName = "User",
                    Email = $"group-rule-test1-{TestGuid}@example.com",
                    Login = $"group-rule-test1-{TestGuid}@example.com",
                    Department = "Engineering"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "P@ssw0rd!2024" }
                }
            };

            var testUser2 = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "GroupRuleTest2",
                    LastName = "User",
                    Email = $"group-rule-test2-{TestGuid}@example.com",
                    Login = $"group-rule-test2-{TestGuid}@example.com",
                    Department = "Marketing"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "P@ssw0rd!2024" }
                }
            };

            var createdUser1 = await _userApi.CreateUserAsync(testUser1, activate: true);
            var createdUser2 = await _userApi.CreateUserAsync(testUser2, activate: true);

            TestUser1Id = createdUser1.Id;
            TestUser2Id = createdUser2.Id;

            await Task.Delay(2000); // Wait for resources to be fully created
        }

        public async Task DisposeAsync()
        {
            // Cleanup all created group rules
            foreach (var ruleId in _createdGroupRuleIds)
            {
                try
                {
                    // Try to deactivate first (in case it's active)
                    try
                    {
                        await _groupRuleApi.DeactivateGroupRuleAsync(ruleId);
                        await Task.Delay(1000);
                    }
                    catch (ApiException) { }

                    // Then delete
                    await _groupRuleApi.DeleteGroupRuleAsync(ruleId, removeUsers: true);
                }
                catch (ApiException) { }
            }

            // Cleanup target groups
            var groupsToDelete = new[] { TargetGroup1Id, TargetGroup2Id, TargetGroup3Id };
            foreach (var groupId in groupsToDelete)
            {
                if (!string.IsNullOrEmpty(groupId))
                {
                    try
                    {
                        await _groupApi.DeleteGroupAsync(groupId);
                    }
                    catch (ApiException) { }
                }
            }

            // Cleanup test users (deactivate first, then delete it)
            var usersToDelete = new[] { TestUser1Id, TestUser2Id };
            foreach (var userId in usersToDelete)
            {
                if (!string.IsNullOrEmpty(userId))
                {
                    try
                    {
                        await _userLifecycleApi.DeactivateUserAsync(userId);
                        await _userApi.DeleteUserAsync(userId);
                    }
                    catch (ApiException) { }
                }
            }
        }

        private void TrackCreatedGroupRule(string ruleId)
        {
            if (!string.IsNullOrEmpty(ruleId) && !_createdGroupRuleIds.Contains(ruleId))
            {
                _createdGroupRuleIds.Add(ruleId);
            }
        }

        #region Comprehensive CRUD + Lifecycle Test

        [Fact]
        public async Task GivenGroupRules_WhenPerformingCrudOperations_ThenAllMethodsAndEndpointsWork()
        {
            // CREATE
            var createRequest1 = new CreateGroupRuleRequest
            {
                Type = CreateGroupRuleRequest.TypeEnum.GroupRule,
                Name = $"Eng Rule {TestGuid.Substring(0, 8)}",
                Conditions = new GroupRuleConditions
                {
                    Expression = new GroupRuleExpression
                    {
                        Type = "urn:okta:expression:1.0",
                        Value = "user.department==\"Engineering\""
                    }
                },
                Actions = new GroupRuleAction
                {
                    AssignUserToGroups = new GroupRuleGroupAssignment
                    {
                        GroupIds = [TargetGroup1Id]
                    }
                }
            };

            var createdRule1 = await _groupRuleApi.CreateGroupRuleAsync(createRequest1);
            TrackCreatedGroupRule(createdRule1.Id);

            // Validate created rule
            createdRule1.Should().NotBeNull();
            createdRule1.Id.Should().NotBeNullOrEmpty();
            createdRule1.Name.Should().Be($"Eng Rule {TestGuid.Substring(0, 8)}");
            createdRule1.Status.Should().Be(GroupRuleStatus.INACTIVE); // Rules are created as INACTIVE
            createdRule1.Type.Should().Be("group_rule");
            createdRule1.Created.Should().BeAfter(DateTimeOffset.UtcNow.AddMinutes(-5));
            createdRule1.LastUpdated.Should().BeAfter(DateTimeOffset.UtcNow.AddMinutes(-5));
            createdRule1.Conditions.Should().NotBeNull();
            createdRule1.Conditions.Expression.Should().NotBeNull();
            createdRule1.Conditions.Expression.Value.Should().Be("user.department==\"Engineering\"");
            createdRule1.Actions.Should().NotBeNull();
            createdRule1.Actions.AssignUserToGroups.Should().NotBeNull();
            createdRule1.Actions.AssignUserToGroups.GroupIds.Should().Contain(TargetGroup1Id);

            // Create a second group rule for Marketing department
            var createRequest2 = new CreateGroupRuleRequest
            {
                Type = CreateGroupRuleRequest.TypeEnum.GroupRule,
                Name = $"Mkt Rule {TestGuid.Substring(0, 8)}",
                Conditions = new GroupRuleConditions
                {
                    Expression = new GroupRuleExpression
                    {
                        Type = "urn:okta:expression:1.0",
                        Value = "user.department==\"Marketing\""
                    }
                },
                Actions = new GroupRuleAction
                {
                    AssignUserToGroups = new GroupRuleGroupAssignment
                    {
                        GroupIds = [TargetGroup2Id]
                    }
                }
            };

            var createdRule2 = await _groupRuleApi.CreateGroupRuleAsync(createRequest2);
            TrackCreatedGroupRule(createdRule2.Id);

            createdRule2.Should().NotBeNull();
            createdRule2.Id.Should().NotBeNullOrEmpty();
            createdRule2.Name.Should().Be($"Mkt Rule {TestGuid.Substring(0, 8)}");

            await Task.Delay(2000);

            // READ - ListGroupRules (with retry for eventual consistency)
            List<GroupRule> allRules = null;
            for (int i = 0; i < 5; i++)
            {
                allRules = await _groupRuleApi.ListGroupRules().ToListAsync();
                if (allRules.Any(r => r.Id == createdRule1.Id) && allRules.Any(r => r.Id == createdRule2.Id))
                    break;
                await Task.Delay(2000);
            }
            allRules.Should().NotBeNull();
            allRules.Should().HaveCountGreaterThanOrEqualTo(2);
            allRules.Should().Contain(r => r.Id == createdRule1.Id);
            allRules.Should().Contain(r => r.Id == createdRule2.Id);

            // Test ListGroupRules with limit parameter
            var limitedRules = await _groupRuleApi.ListGroupRules(limit: 1).ToListAsync();
            limitedRules.Should().NotBeNull();
            limitedRules.Should().HaveCountGreaterThanOrEqualTo(1);

            // Test ListGroupRules with search parameter
            var searchedRules = await _groupRuleApi.ListGroupRules(search: $"Eng Rule {TestGuid.Substring(0, 8)}").ToListAsync();
            searchedRules.Should().NotBeNull();
            searchedRules.Should().Contain(r => r.Id == createdRule1.Id);
            searchedRules.Should().Contain(r => r.Name.Contains("Eng"));

            // READ - GetGroupRule
            var retrievedRule = await _groupRuleApi.GetGroupRuleAsync(createdRule1.Id);
            retrievedRule.Should().NotBeNull();
            retrievedRule.Id.Should().Be(createdRule1.Id);
            retrievedRule.Name.Should().Be(createdRule1.Name);
            retrievedRule.Status.Should().Be(GroupRuleStatus.INACTIVE);
            retrievedRule.Conditions.Expression.Value.Should().Be("user.department==\"Engineering\"");
            retrievedRule.Actions.AssignUserToGroups.GroupIds.Should().Contain(TargetGroup1Id);

            // Test GetGroupRule with expanded parameter (groupIdToGroupNameMap)
            var retrievedRuleExpanded = await _groupRuleApi.GetGroupRuleAsync(createdRule1.Id, expand: "groupIdToGroupNameMap");
            retrievedRuleExpanded.Should().NotBeNull();
            retrievedRuleExpanded.Id.Should().Be(createdRule1.Id);

            // UPDATE - ReplaceGroupRule
            retrievedRule.Name = $"Upd Eng {TestGuid.Substring(0, 8)}";
            retrievedRule.Conditions.Expression.Value = "user.department==\"Engineering\" and isMemberOfAnyGroup(\"" + TargetGroup2Id + "\")";

            var updatedRule = await _groupRuleApi.ReplaceGroupRuleAsync(createdRule1.Id, retrievedRule);
            updatedRule.Should().NotBeNull();
            updatedRule.Id.Should().Be(createdRule1.Id);
            updatedRule.Name.Should().Be($"Upd Eng {TestGuid.Substring(0, 8)}");
            updatedRule.Conditions.Expression.Value.Should().Contain("isMemberOfAnyGroup");
            updatedRule.Status.Should().Be(GroupRuleStatus.INACTIVE);
            updatedRule.LastUpdated.Should().BeAfter(retrievedRule.LastUpdated);

            await Task.Delay(1000); // Wait for update to propagate

            // Verify the update persisted
            var verifyUpdated = await _groupRuleApi.GetGroupRuleAsync(createdRule1.Id);
            verifyUpdated.Name.Should().Be($"Upd Eng {TestGuid.Substring(0, 8)}");
            verifyUpdated.Conditions.Expression.Value.Should().Contain("isMemberOfAnyGroup");

            // LIFECYCLE - ActivateGroupRule
            await _groupRuleApi.ActivateGroupRuleAsync(createdRule1.Id);
            await Task.Delay(2000); // Wait for activation to complete

            // Verify rule is now active
            var activatedRule = await _groupRuleApi.GetGroupRuleAsync(createdRule1.Id);
            activatedRule.Should().NotBeNull();
            activatedRule.Status.Should().Be(GroupRuleStatus.ACTIVE);

            // Activate second rule as well
            await _groupRuleApi.ActivateGroupRuleAsync(createdRule2.Id);
            await Task.Delay(2000);

            var activatedRule2 = await _groupRuleApi.GetGroupRuleAsync(createdRule2.Id);
            activatedRule2.Status.Should().Be(GroupRuleStatus.ACTIVE);

            // LIFECYCLE - DeactivateGroupRule
            await _groupRuleApi.DeactivateGroupRuleAsync(createdRule1.Id);
            await Task.Delay(2000);

            // Verify rule is now inactive
            var deactivatedRule = await _groupRuleApi.GetGroupRuleAsync(createdRule1.Id);
            deactivatedRule.Should().NotBeNull();
            deactivatedRule.Status.Should().Be(GroupRuleStatus.INACTIVE);

            // Deactivate second rule as well
            await _groupRuleApi.DeactivateGroupRuleAsync(createdRule2.Id);
            await Task.Delay(2000);

            var deactivatedRule2 = await _groupRuleApi.GetGroupRuleAsync(createdRule2.Id);
            deactivatedRule2.Status.Should().Be(GroupRuleStatus.INACTIVE);

            // DELETE - DeleteGroupRule
            await _groupRuleApi.DeleteGroupRuleAsync(createdRule1.Id);
            _createdGroupRuleIds.Remove(createdRule1.Id);

            await Task.Delay(1000);

            // Verify rule is deleted - should throw 404
            Func<Task> getDeletedRule = async () => await _groupRuleApi.GetGroupRuleAsync(createdRule1.Id);
            await getDeletedRule.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404);

            // Test DeleteGroupRule with removeUsers=true parameter
            await _groupRuleApi.DeleteGroupRuleAsync(createdRule2.Id, removeUsers: true);
            _createdGroupRuleIds.Remove(createdRule2.Id);

            await Task.Delay(1000);

            // Verify second rule is also deleted
            Func<Task> getDeletedRule2 = async () => await _groupRuleApi.GetGroupRuleAsync(createdRule2.Id);
            await getDeletedRule2.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404);

            // Verify rules are removed from a list
            var finalRulesList = await _groupRuleApi.ListGroupRules().ToListAsync();
            finalRulesList.Should().NotContain(r => r.Id == createdRule1.Id);
            finalRulesList.Should().NotContain(r => r.Id == createdRule2.Id);
        }

        #endregion

        #region Additional Edge Cases and Validation Tests

        [Fact]
        public async Task GivenEdgeCasesAndValidation_WhenCallingApi_ThenCasesAreHandledCorrectly()
        {
            // Create a rule with multiple target groups
            var multiGroupRule = new CreateGroupRuleRequest
            {
                Type = CreateGroupRuleRequest.TypeEnum.GroupRule,
                Name = $"Multi {TestGuid.Substring(0, 8)}",
                Conditions = new GroupRuleConditions
                {
                    Expression = new GroupRuleExpression
                    {
                        Type = "urn:okta:expression:1.0",
                        Value = "user.department==\"Engineering\""
                    }
                },
                Actions = new GroupRuleAction
                {
                    AssignUserToGroups = new GroupRuleGroupAssignment
                    {
                        GroupIds = [TargetGroup1Id, TargetGroup2Id, TargetGroup3Id]
                    }
                }
            };

            var createdMultiGroupRule = await _groupRuleApi.CreateGroupRuleAsync(multiGroupRule);
            TrackCreatedGroupRule(createdMultiGroupRule.Id);

            createdMultiGroupRule.Should().NotBeNull();
            createdMultiGroupRule.Actions.AssignUserToGroups.GroupIds.Should().HaveCount(3);
            createdMultiGroupRule.Actions.AssignUserToGroups.GroupIds.Should().Contain(TargetGroup1Id);
            createdMultiGroupRule.Actions.AssignUserToGroups.GroupIds.Should().Contain(TargetGroup2Id);
            createdMultiGroupRule.Actions.AssignUserToGroups.GroupIds.Should().Contain(TargetGroup3Id);

            await Task.Delay(2000);

            // Test pagination with after parameter (with retry for eventual consistency)
            List<GroupRule> firstPage = null;
            for (int i = 0; i < 5; i++)
            {
                firstPage = await _groupRuleApi.ListGroupRules(limit: 1).ToListAsync();
                if (firstPage.Count > 0)
                    break;
                await Task.Delay(2000);
            }
            firstPage.Should().NotBeNull();
            firstPage.Should().HaveCountGreaterThanOrEqualTo(1);

            // If we have more than one rule, test the after parameter
            if (firstPage is { Count: > 0 })
            {
                var firstRuleId = firstPage[0].Id;
                var secondPage = await _groupRuleApi.ListGroupRules(limit: 1, after: firstRuleId).ToListAsync();
                secondPage.Should().NotBeNull();
                // The after parameter should return rules after the specified ID
            }

            // Activate the rule for testing active rule constraints
            await _groupRuleApi.ActivateGroupRuleAsync(createdMultiGroupRule.Id);
            await Task.Delay(2000);

            var activeRule = await _groupRuleApi.GetGroupRuleAsync(createdMultiGroupRule.Id);
            activeRule.Status.Should().Be(GroupRuleStatus.ACTIVE);

            // Attempt to update an active rule - should fail with 400 Bad Request
            activeRule.Name = $"UpdAct {TestGuid.Substring(0, 8)}";
            Func<Task> updateActiveRule = async () => await _groupRuleApi.ReplaceGroupRuleAsync(createdMultiGroupRule.Id, activeRule);
            await updateActiveRule.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 400);

            // Attempt to delete an active rule - should fail with 400 Bad Request
            Func<Task> deleteActiveRule = async () => await _groupRuleApi.DeleteGroupRuleAsync(createdMultiGroupRule.Id);
            await deleteActiveRule.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 400);

            // Deactivate before cleanup
            await _groupRuleApi.DeactivateGroupRuleAsync(createdMultiGroupRule.Id);
            await Task.Delay(2000);

            // Now deletion should work
            await _groupRuleApi.DeleteGroupRuleAsync(createdMultiGroupRule.Id, removeUsers: true);
            _createdGroupRuleIds.Remove(createdMultiGroupRule.Id);
        }

        #endregion

        #region Error Handling Tests

        [Fact]
        public async Task GivenInvalidOperations_WhenCallingApi_ThenAppropriateExceptionsAreThrown()
        {
            var nonExistentRuleId = "0pr9999999999999999";

            // Test GetGroupRule with non-existent ID - should throw 404
            Func<Task> getNonExistent = async () => await _groupRuleApi.GetGroupRuleAsync(nonExistentRuleId);
            await getNonExistent.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404);

            // Test ActivateGroupRule with non-existent ID - should throw 404
            Func<Task> activateNonExistent = async () => await _groupRuleApi.ActivateGroupRuleAsync(nonExistentRuleId);
            await activateNonExistent.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404);

            // Test DeactivateGroupRule with non-existent ID - should throw 404
            Func<Task> deactivateNonExistent = async () => await _groupRuleApi.DeactivateGroupRuleAsync(nonExistentRuleId);
            await deactivateNonExistent.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404);

            // Test DeleteGroupRule with non-existent ID - should throw 404
            Func<Task> deleteNonExistent = async () => await _groupRuleApi.DeleteGroupRuleAsync(nonExistentRuleId);
            await deleteNonExistent.Should().ThrowAsync<ApiException>()
                .Where(e => e.ErrorCode == 404);

            // Create a rule for testing duplicate operations
            var testRule = new CreateGroupRuleRequest
            {
                Type = CreateGroupRuleRequest.TypeEnum.GroupRule,
                Name = $"ErrT {TestGuid.Substring(0, 8)}",
                Conditions = new GroupRuleConditions
                {
                    Expression = new GroupRuleExpression
                    {
                        Type = "urn:okta:expression:1.0",
                        Value = "user.department==\"Engineering\""
                    }
                },
                Actions = new GroupRuleAction
                {
                    AssignUserToGroups = new GroupRuleGroupAssignment
                    {
                        GroupIds = [TargetGroup1Id]
                    }
                }
            };

            var createdTestRule = await _groupRuleApi.CreateGroupRuleAsync(testRule);
            TrackCreatedGroupRule(createdTestRule.Id);

            await Task.Delay(1000);

            // Rule is created as INACTIVE - attempting to deactivate should succeed (idempotent) or return the appropriate response
            // Note: Deactivating an already inactive rule may be idempotent in Okta
            await _groupRuleApi.DeactivateGroupRuleAsync(createdTestRule.Id);

            // Activate the rule
            await _groupRuleApi.ActivateGroupRuleAsync(createdTestRule.Id);
            await Task.Delay(2000);

            // Attempting to activate an already active rule should succeed (idempotent) or return the appropriate response
            // Note: Activating an already active rule may be idempotent in Okta
            await _groupRuleApi.ActivateGroupRuleAsync(createdTestRule.Id);

            // Cleanup
            await _groupRuleApi.DeactivateGroupRuleAsync(createdTestRule.Id);
            await Task.Delay(1000);
            await _groupRuleApi.DeleteGroupRuleAsync(createdTestRule.Id);
            _createdGroupRuleIds.Remove(createdTestRule.Id);
        }

        #endregion

        #region Complex Expression Tests

        /// <summary>
        /// Tests group rules with complex expressions:
        /// - Multiple conditions with AND/OR operators
        /// - Different user attributes (department, title, status, etc.)
        /// - Expression validation
        /// </summary>
        [Fact]
        public async Task GivenComplexExpressions_WhenCreatingRules_ThenRulesAreCreatedAndManagedCorrectly()
        {
            // Create rule with complex AND expression
            var complexAndRule = new CreateGroupRuleRequest
            {
                Type = CreateGroupRuleRequest.TypeEnum.GroupRule,
                Name = $"ComplexAND {TestGuid.Substring(0, 8)}",
                Conditions = new GroupRuleConditions
                {
                    Expression = new GroupRuleExpression
                    {
                        Type = "urn:okta:expression:1.0",
                        Value = "user.department==\"Engineering\" and isMemberOfAnyGroup(\"" + TargetGroup2Id + "\")"
                    }
                },
                Actions = new GroupRuleAction
                {
                    AssignUserToGroups = new GroupRuleGroupAssignment
                    {
                        GroupIds = [TargetGroup1Id]
                    }
                }
            };

            var createdAndRule = await _groupRuleApi.CreateGroupRuleAsync(complexAndRule);
            TrackCreatedGroupRule(createdAndRule.Id);

            createdAndRule.Should().NotBeNull();
            createdAndRule.Conditions.Expression.Value.Should().Contain("and");

            // Create rule with OR expression
            var complexOrRule = new CreateGroupRuleRequest
            {
                Type = CreateGroupRuleRequest.TypeEnum.GroupRule,
                Name = $"ComplexOR {TestGuid.Substring(0, 8)}",
                Conditions = new GroupRuleConditions
                {
                    Expression = new GroupRuleExpression
                    {
                        Type = "urn:okta:expression:1.0",
                        Value = "user.department==\"Engineering\" or user.department==\"Marketing\""
                    }
                },
                Actions = new GroupRuleAction
                {
                    AssignUserToGroups = new GroupRuleGroupAssignment
                    {
                        GroupIds = [TargetGroup2Id]
                    }
                }
            };

            var createdOrRule = await _groupRuleApi.CreateGroupRuleAsync(complexOrRule);
            TrackCreatedGroupRule(createdOrRule.Id);

            createdOrRule.Should().NotBeNull();
            createdOrRule.Conditions.Expression.Value.Should().Contain("or");

            // Create rule with additional user attribute expression
            var patternRule = new CreateGroupRuleRequest
            {
                Type = CreateGroupRuleRequest.TypeEnum.GroupRule,
                Name = $"UserAttr {TestGuid.Substring(0, 8)}",
                Conditions = new GroupRuleConditions
                {
                    Expression = new GroupRuleExpression
                    {
                        Type = "urn:okta:expression:1.0",
                        Value = "user.lastName==\"GroupRuleTestUser\""
                    }
                },
                Actions = new GroupRuleAction
                {
                    AssignUserToGroups = new GroupRuleGroupAssignment
                    {
                        GroupIds = [TargetGroup3Id]
                    }
                }
            };

            var createdPatternRule = await _groupRuleApi.CreateGroupRuleAsync(patternRule);
            TrackCreatedGroupRule(createdPatternRule.Id);

            createdPatternRule.Should().NotBeNull();
            createdPatternRule.Conditions.Expression.Value.Should().Contain("lastName");

            // Verify all rules are in the list (with retry for eventual consistency)
            List<GroupRule> allComplexRules = null;
            for (int i = 0; i < 5; i++)
            {
                await Task.Delay(2000);
                allComplexRules = await _groupRuleApi.ListGroupRules().ToListAsync();
                if (allComplexRules.Any(r => r.Id == createdAndRule.Id) &&
                    allComplexRules.Any(r => r.Id == createdOrRule.Id) &&
                    allComplexRules.Any(r => r.Id == createdPatternRule.Id))
                    break;
            }
            allComplexRules.Should().Contain(r => r.Id == createdAndRule.Id);
            allComplexRules.Should().Contain(r => r.Id == createdOrRule.Id);
            allComplexRules.Should().Contain(r => r.Id == createdPatternRule.Id);

            // Cleanup
            await _groupRuleApi.DeleteGroupRuleAsync(createdAndRule.Id);
            await _groupRuleApi.DeleteGroupRuleAsync(createdOrRule.Id);
            await _groupRuleApi.DeleteGroupRuleAsync(createdPatternRule.Id);
            _createdGroupRuleIds.Remove(createdAndRule.Id);
            _createdGroupRuleIds.Remove(createdOrRule.Id);
            _createdGroupRuleIds.Remove(createdPatternRule.Id);
        }

        #endregion
    }
}
