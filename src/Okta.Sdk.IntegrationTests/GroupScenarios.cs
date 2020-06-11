// <copyright file="GroupScenarios.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    [Collection(nameof(GroupScenarios))]
    public class GroupScenarios
    {
        [Fact]
        public async Task GetGroup()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var createdGroup = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk: Get Test Group {guid}",
            });

            try
            {
                var retrievedById = await client.Groups.GetGroupAsync(createdGroup.Id);
                retrievedById.Id.Should().Be(createdGroup.Id);
            }
            finally
            {
                await createdGroup.DeleteAsync();
            }

            // Getting by ID should result in 404 error
            await Assert.ThrowsAsync<OktaApiException>(
                () => client.Groups.GetGroupAsync(createdGroup.Id));
        }

        [Fact]
        public async Task ListGroups()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var createdGroup = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk: List Test Group {guid}",
            });

            try
            {
                var groupList = await client.Groups.ListGroups().ToArrayAsync();
                groupList.SingleOrDefault(g => g.Id == createdGroup.Id).Should().NotBeNull();
            }
            finally
            {
                await createdGroup.DeleteAsync();
            }

            // Getting by ID should result in 404 error
            await Assert.ThrowsAsync<OktaApiException>(
                () => client.Groups.GetGroupAsync(createdGroup.Id));
        }

        [Fact]
        public async Task SearchGroups()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var createdGroup = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk: Search Test Group {guid}",
            });

            try
            {
                var groupList = await client.Groups
                    .ListGroups(createdGroup.Profile.GetProperty<string>("name"))
                    .ToArrayAsync();
                groupList.SingleOrDefault(g => g.Id == createdGroup.Id).Should().NotBeNull();
            }
            finally
            {
                await createdGroup.DeleteAsync();
            }

            // Getting by ID should result in 404 error
            await Assert.ThrowsAsync<OktaApiException>(
                () => client.Groups.GetGroupAsync(createdGroup.Id));
        }

        [Fact]
        public async Task UpdateGroup()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var createdGroup = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk: Update Test Group {guid}",
            });

            await Task.Delay(1000);
            createdGroup.Profile.Description = "This group has been updated";

            try
            {
                var updatedGroup = await createdGroup.UpdateAsync();
                updatedGroup.LastUpdated.Value.Should().BeAfter(updatedGroup.Created.Value);
            }
            finally
            {
                await createdGroup.DeleteAsync();
            }

            // Getting by ID should result in 404 error
            await Assert.ThrowsAsync<OktaApiException>(
                () => client.Groups.GetGroupAsync(createdGroup.Id));
        }

        [Fact]
        public async Task AddUserToGroup()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            // Create group
            var createdGroup = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk: New Users Test Group {guid}",
            });

            // Create a user
            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Get-User",
                    Email = $"john-add-group-dotnet-sdk-{guid}@example.com",
                    Login = $"john-add-group-dotnet-sdk-{guid}@example.com",
                },
                Password = "Abcd1234",
                Activate = true,
            });

            try
            {
                await client.Groups.AddUserToGroupAsync(createdGroup.Id, createdUser.Id);

                var retrievedGroup = await client.Groups.GetGroupAsync(createdGroup.Id);
                retrievedGroup.Should().NotBeNull();
                var groupUsersList = await retrievedGroup.Users.ToListAsync();
                groupUsersList.Should().HaveCount(1);

                var retrievedUser = await retrievedGroup.Users.FirstAsync(x => x.Id == createdUser.Id);
                retrievedUser.Should().NotBeNull();
            }
            finally
            {
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
                await createdGroup.DeleteAsync();
            }
        }

        [Fact]
        public async Task RemoveUserFromGroup()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            // Create group
            var createdGroup = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk: New Users Test Group {guid}",
            });

            // Create a user
            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Get-User",
                    Email = $"john-remove-from-group-dotnet-sdk-{guid}@example.com",
                    Login = $"john-remove-from-group-dotnet-sdk-{guid}@example.com",
                },
                Password = "Abcd1234",
                Activate = true,
            });

            try
            {
                await client.Groups.AddUserToGroupAsync(createdGroup.Id, createdUser.Id);

                var retrievedGroup = await client.Groups.GetGroupAsync(createdGroup.Id);
                retrievedGroup.Should().NotBeNull();
                var groupUsersList = await retrievedGroup.Users.ToListAsync();
                groupUsersList.Should().HaveCount(1);

                var retrievedUser = await retrievedGroup.Users.FirstAsync(x => x.Id == createdUser.Id);
                retrievedUser.Should().NotBeNull();

                await retrievedGroup.RemoveUserAsync(retrievedUser.Id);
                retrievedGroup = await client.Groups.GetGroupAsync(createdGroup.Id);
                groupUsersList = await retrievedGroup.Users.ToListAsync();
                groupUsersList.Should().HaveCount(0);
            }
            finally
            {
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
                await createdGroup.DeleteAsync();
            }
        }

        [Fact]
        public async Task RemoveDeletedUserFromGroup()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            // Create group
            var createdGroup = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk: New Users Test Group {guid}",
            });

            // Create a user
            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Get-User",
                    Email = $"john-delete-user-dotnet-sdk-{guid}@example.com",
                    Login = $"john-delete-user-dotnet-sdk-{guid}@example.com",
                },
                Password = "Abcd1234",
                Activate = true,
            });

            try
            {
                await client.Groups.AddUserToGroupAsync(createdGroup.Id, createdUser.Id);

                var retrievedGroup = await client.Groups.GetGroupAsync(createdGroup.Id);
                retrievedGroup.Should().NotBeNull();
                var groupUsersList = await retrievedGroup.Users.ToListAsync();
                groupUsersList.Should().HaveCount(1);

                var retrievedUser = await retrievedGroup.Users.FirstAsync(x => x.Id == createdUser.Id);
                retrievedUser.Should().NotBeNull();

                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();

                retrievedGroup = await client.Groups.GetGroupAsync(createdGroup.Id);
                groupUsersList = await retrievedGroup.Users.ToListAsync();
                groupUsersList.Should().HaveCount(0);
            }
            finally
            {
                await createdGroup.DeleteAsync();
            }
        }

        [Fact]
        public async Task RemoveGroup()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            // Create group
            var createdGroup = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk: New Users Test Group {guid}",
            });

            // Create a user
            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Remove-Group",
                    Email = $"john-remove-group-dotnet-sdk-{guid}@example.com",
                    Login = $"john-remove-group-dotnet-sdk-{guid}@example.com",
                },
                Password = "Abcd1234",
                Activate = true,
            });

            try
            {
                await client.Groups.AddUserToGroupAsync(createdGroup.Id, createdUser.Id);

                var retrievedGroup = await client.Groups.GetGroupAsync(createdGroup.Id);
                retrievedGroup.Should().NotBeNull();
                var groupUsersList = await retrievedGroup.Users.ToListAsync();
                groupUsersList.Should().HaveCount(1);

                var retrievedUser = await retrievedGroup.Users.FirstAsync(x => x.Id == createdUser.Id);
                retrievedUser.Should().NotBeNull();

                await client.Groups.DeleteGroupAsync(createdGroup.Id);
                var retrievedGroupsList = await client.Groups.ToListAsync();
                retrievedGroupsList.FirstOrDefault(x => x.Id == createdGroup.Id).Should().BeNull();

                retrievedUser = await client.Users.GetUserAsync(createdUser.Id);
                retrievedUser.Should().NotBeNull();
            }
            finally
            {
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }

        [Fact]
        public async Task CreateGroup()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            // Create group
            var createdGroup = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk: New Test Group {guid}",
            });

            try
            {
                var retrievedGroup = await client.Groups.GetGroupAsync(createdGroup.Id);

                retrievedGroup.Should().NotBeNull();
                retrievedGroup.Profile.Name.Should().Be($"dotnet-sdk: New Test Group {guid}");
            }
            finally
            {
                await createdGroup.DeleteAsync();
            }
        }

        [Fact]
        public async Task ListRolesAssignedToGroup()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            // Create group
            var createdGroup = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk: {nameof(ListRolesAssignedToGroup)} {guid}",
            });

            try
            {
                var role1 = await createdGroup.AssignRoleAsync(new AssignRoleRequest
                {
                    Type = RoleType.UserAdmin,
                });

                var role2 = await createdGroup.AssignRoleAsync(new AssignRoleRequest
                {
                    Type = RoleType.AppAdmin,
                });

                var roles = await client.Groups.ListGroupAssignedRoles(createdGroup.Id).ToListAsync();

                roles.Should().NotBeNullOrEmpty();
                roles.Should().Contain(x => x.Id == role1.Id);
                roles.Should().Contain(x => x.Id == role2.Id);
            }
            finally
            {
                await createdGroup.DeleteAsync();
            }
        }

        [Fact]
        public async Task UnassignRoleForGroup()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            // Create group
            var createdGroup = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk: {nameof(UnassignRoleForGroup)} {guid}",
            });

            try
            {
                var role = await createdGroup.AssignRoleAsync(new AssignRoleRequest
                {
                    Type = RoleType.UserAdmin,
                });

                var roles = await client.Groups.ListGroupAssignedRoles(createdGroup.Id).ToListAsync();

                roles.Should().NotBeNullOrEmpty();
                roles.Should().Contain(x => x.Id == role.Id);

                await client.Groups.RemoveRoleFromGroupAsync(createdGroup.Id, role.Id);
                roles = await client.Groups.ListGroupAssignedRoles(createdGroup.Id).ToListAsync();
                roles.Should().BeNullOrEmpty();
            }
            finally
            {
                await createdGroup.DeleteAsync();
            }
        }

        [Fact]
        public async Task ListGroupTargetsForGroup()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var createdGroup1 = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk:{nameof(ListGroupTargetsForGroup)}1-{guid}",
                Description = $"dotnet-sdk:{nameof(ListGroupTargetsForGroup)}1-{guid}",
            });

            var createdGroup2 = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk:{nameof(ListGroupTargetsForGroup)}2-{guid}",
                Description = $"dotnet-sdk:{nameof(ListGroupTargetsForGroup)}2-{guid}",
            });

            try
            {
                var role = await createdGroup1.AssignRoleAsync(new AssignRoleRequest
                {
                    Type = RoleType.UserAdmin,
                });

                await client.Groups.AddGroupTargetToGroupAdministratorRoleForGroupAsync(createdGroup1.Id, role.Id, createdGroup2.Id);

                var groups = await client.Groups.ListGroupTargetsForGroupRole(createdGroup1.Id, role.Id).ToListAsync();
                groups.Should().NotBeNullOrEmpty();
                groups.Should().Contain(x => x.Id == createdGroup2.Id);
            }
            finally
            {
                await createdGroup1.DeleteAsync();
                await createdGroup2.DeleteAsync();
            }
        }

        [Fact]
        public async Task RemoveGroupTargetFromGroupAdministratorRoleGivenToGroup()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var createdGroup1 = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk:{nameof(RemoveGroupTargetFromGroupAdministratorRoleGivenToGroup)}1-{guid}",
                Description = $"dotnet-sdk:{nameof(RemoveGroupTargetFromGroupAdministratorRoleGivenToGroup)}1-{guid}",
            });

            var createdGroup2 = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk:{nameof(RemoveGroupTargetFromGroupAdministratorRoleGivenToGroup)}2-{guid}",
                Description = $"dotnet-sdk:{nameof(RemoveGroupTargetFromGroupAdministratorRoleGivenToGroup)}2-{guid}",
            });

            var createdGroup3 = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk:{nameof(RemoveGroupTargetFromGroupAdministratorRoleGivenToGroup)}3-{guid}",
                Description = $"dotnet-sdk:{nameof(RemoveGroupTargetFromGroupAdministratorRoleGivenToGroup)}3-{guid}",
            });

            try
            {
                var role = await createdGroup1.AssignRoleAsync(new AssignRoleRequest
                {
                    Type = RoleType.UserAdmin,
                });

                await client.Groups.AddGroupTargetToGroupAdministratorRoleForGroupAsync(createdGroup1.Id, role.Id, createdGroup2.Id);
                await client.Groups.AddGroupTargetToGroupAdministratorRoleForGroupAsync(createdGroup1.Id, role.Id, createdGroup3.Id);

                var groups = await client.Groups.ListGroupTargetsForGroupRole(createdGroup1.Id, role.Id).ToListAsync();
                groups.Should().NotBeNullOrEmpty();
                groups.Should().Contain(x => x.Id == createdGroup2.Id);
                groups.Should().Contain(x => x.Id == createdGroup3.Id);

                await client.Groups.RemoveGroupTargetFromGroupAdministratorRoleGivenToGroupAsync(createdGroup1.Id, role.Id, createdGroup2.Id);

                groups = await client.Groups.ListGroupTargetsForGroupRole(createdGroup1.Id, role.Id).ToListAsync();
                groups.Should().NotContain(x => x.Id == createdGroup2.Id);
            }
            finally
            {
                await createdGroup1.DeleteAsync();
                await createdGroup2.DeleteAsync();
                await createdGroup3.DeleteAsync();
            }
        }

        [Fact]
        public async Task CreateGroupRule()
        {
            var testClient = TestClient.Create();
            var guid = Guid.NewGuid();
            var testNickName = $"dotnet-sdk-{nameof(CreateGroupRule)}";
            var testUserName = $"{testNickName}-{guid}@example.com";

            var profile = new UserProfile
            {
                FirstName = "John",
                LastName = $"{nameof(CreateGroupRule)}",
                Email = testUserName,
                Login = testUserName,
                ["nickName"] = testNickName,
            };

            var createdUser = await testClient.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = profile,
                Password = "Abcd1234",
            });

            var createdGroup = await testClient.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk:{nameof(CreateGroupRule)}-{guid}",
                Description = $"dotnet-sdk:{nameof(CreateGroupRule)}-{guid}",
            });

            Thread.Sleep(3000); // allow user replication prior to read attempt

            var groupRule = new GroupRule
            {
                Type = "group_rule",
                Name = $"US group rule ({TestClient.RandomString(6)})",
                Conditions = new GroupRuleConditions
                {
                    People = new GroupRulePeopleCondition
                    {
                        Users = new GroupRuleUserCondition
                        {
                            Exclude = new List<string> { createdUser.Id },
                        },
                        Groups = new GroupRuleGroupCondition
                        {
                            Exclude = new List<string>(),
                        },
                    },
                    Expression = new GroupRuleExpression
                    {
                        Value = "user.countryCode==\"US\"",
                        Type = "urn:okta:expression:1.0",
                    },
                },
                Actions = new GroupRuleAction
                {
                    AssignUserToGroups = new GroupRuleGroupAssignment
                    {
                        GroupIds = new List<string> { createdGroup.Id },
                    },
                },
            };

            var createdGroupRule = await testClient.Groups.CreateGroupRuleAsync(groupRule);
            try
            {
                createdGroupRule.Should().NotBeNull();
                createdGroupRule.Id.Should().NotBeNullOrEmpty();
                createdGroupRule.Type.Should().Be(groupRule.Type);
                createdGroupRule.Name.Should().Be(groupRule.Name);
            }
            finally
            {
                await createdGroupRule.DeactivateAsync();
                await testClient.Groups.DeleteGroupRuleAsync(createdGroupRule.Id);
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
                await createdGroup.DeleteAsync();
            }
        }

        [Fact]
        public async Task UpdateGroupRule()
        {
            var testClient = TestClient.Create();
            var guid = Guid.NewGuid();
            var testNickName = $"dotnet-sdk-{nameof(UpdateGroupRule)}";
            var testUserName = $"{testNickName}-{guid}@example.com";

            var profile = new UserProfile
            {
                FirstName = "John",
                LastName = $"{nameof(UpdateGroupRule)}",
                Email = testUserName,
                Login = testUserName,
                ["nickName"] = testNickName,
            };

            var createdUser = await testClient.Users.CreateUserAsync(
                new CreateUserWithPasswordOptions
                {
                    Profile = profile,
                    Password = "Abcd1234",
                });

            var createdGroup = await testClient.Groups.CreateGroupAsync(
                new CreateGroupOptions
                {
                    Name = $"dotnet-sdk:{nameof(UpdateGroupRule)}-{guid}",
                    Description = $"dotnet-sdk:{nameof(UpdateGroupRule)}-{guid}",
                });

            Thread.Sleep(3000); // allow user replication prior to read attempt

            var groupRule = new GroupRule
            {
                Type = "group_rule",
                Name = $"US group rule ({TestClient.RandomString(6)})", // guid causes value to be too long
                Conditions = new GroupRuleConditions
                {
                    People = new GroupRulePeopleCondition
                    {
                        Users = new GroupRuleUserCondition
                        {
                            Exclude = new List<string> { createdUser.Id },
                        },
                        Groups = new GroupRuleGroupCondition
                        {
                            Exclude = new List<string>(),
                        },
                    },
                    Expression = new GroupRuleExpression
                    {
                        Value = "user.countryCode==\"US\"",
                        Type = "urn:okta:expression:1.0",
                    },
                },
                Actions = new GroupRuleAction
                {
                    AssignUserToGroups = new GroupRuleGroupAssignment
                    {
                        GroupIds = new List<string> { createdGroup.Id },
                    },
                },
            };

            var createdGroupRule = await testClient.Groups.CreateGroupRuleAsync(groupRule);
            createdGroupRule.Should().NotBeNull();

            Thread.Sleep(3000); // allow user replication prior to read attempt

            var updatedGroupRuleName = $"{groupRule.Name} updated";
            groupRule.Name = updatedGroupRuleName;
            var updatedGroupRule = await testClient.Groups.UpdateGroupRuleAsync(groupRule, createdGroupRule.Id);
            updatedGroupRule.Should().NotBeNull();
            try
            {
                updatedGroupRule.Id.Should().NotBeNullOrEmpty();
                updatedGroupRule.Id.Should().Be(createdGroupRule.Id);
                updatedGroupRule.Type.Should().Be(groupRule.Type);
                updatedGroupRule.Name.Should().Be(updatedGroupRuleName);
            }
            finally
            {
                await createdGroupRule.DeactivateAsync();
                await testClient.Groups.DeleteGroupRuleAsync(createdGroupRule.Id);
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
                await createdGroup.DeleteAsync();
            }
        }

        [Fact]
        public async Task ListGroupRules()
        {
            var testClient = TestClient.Create();
            var guid = Guid.NewGuid();
            var testNickName = $"dotnet-sdk-{nameof(ListGroupRules)}";
            var testUserName = $"{testNickName}-{guid}@example.com";

            var profile = new UserProfile
            {
                FirstName = "John",
                LastName = $"{nameof(ListGroupRules)}",
                Email = testUserName,
                Login = testUserName,
                ["nickName"] = testNickName,
            };

            var createdUser = await testClient.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = profile,
                Password = "Abcd1234",
            });

            var createdGroup = await testClient.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk:{nameof(ListGroupRules)}-{guid}",
                Description = $"dotnet-sdk:{nameof(ListGroupRules)}-{guid}",
            });

            Thread.Sleep(3000); // allow user replication prior to read attempt

            var groupRule = new GroupRule
            {
                Type = "group_rule",
                Name = $"US group rule ({TestClient.RandomString(6)})", // guid would cause field to be too long
                Conditions = new GroupRuleConditions
                {
                    People = new GroupRulePeopleCondition
                    {
                        Users = new GroupRuleUserCondition
                        {
                            Exclude = new List<string> { createdUser.Id },
                        },
                        Groups = new GroupRuleGroupCondition
                        {
                            Exclude = new List<string>(),
                        },
                    },
                    Expression = new GroupRuleExpression
                    {
                        Value = "user.countryCode==\"US\"",
                        Type = "urn:okta:expression:1.0",
                    },
                },
                Actions = new GroupRuleAction
                {
                    AssignUserToGroups = new GroupRuleGroupAssignment
                    {
                        GroupIds = new List<string> { createdGroup.Id },
                    },
                },
            };

            var createdGroupRule = await testClient.Groups.CreateGroupRuleAsync(groupRule);
            try
            {
                var groupRules = await testClient.Groups.ListGroupRules().ToListAsync();
                groupRules.Should().NotBeNull();
                groupRules.Count.Should().BeGreaterThan(0);
                var groupRuleIds = groupRules.Select(gr => gr.Id).ToHashSet();
                groupRuleIds.Should().Contain(createdGroupRule.Id);
            }
            finally
            {
                await createdGroupRule.DeactivateAsync();
                await testClient.Groups.DeleteGroupRuleAsync(createdGroupRule.Id);
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
                await createdGroup.DeleteAsync();
            }
        }

        [Fact]
        public async Task GetGroupRule()
        {
            var testClient = TestClient.Create();
            var guid = Guid.NewGuid();
            var testNickName = $"dotnet-sdk-{nameof(GetGroupRule)}";
            var testUserName = $"{testNickName}-{guid}@example.com";

            var profile = new UserProfile
            {
                FirstName = "John",
                LastName = $"{nameof(GetGroupRule)}",
                Email = testUserName,
                Login = testUserName,
                ["nickName"] = testNickName,
            };

            var createdUser = await testClient.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = profile,
                Password = "Abcd1234",
            });

            var createdGroup = await testClient.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk:{nameof(GetGroupRule)}-{guid}",
                Description = $"dotnet-sdk:{nameof(GetGroupRule)}-{guid}",
            });

            Thread.Sleep(3000); // allow user replication prior to read attempt

            var groupRule = new GroupRule
            {
                Type = "group_rule",
                Name = $"US group rule ({TestClient.RandomString(6)})", // guid would cause field to be too long
                Conditions = new GroupRuleConditions
                {
                    People = new GroupRulePeopleCondition
                    {
                        Users = new GroupRuleUserCondition
                        {
                            Exclude = new List<string> { createdUser.Id },
                        },
                        Groups = new GroupRuleGroupCondition
                        {
                            Exclude = new List<string>(),
                        },
                    },
                    Expression = new GroupRuleExpression
                    {
                        Value = "user.countryCode==\"US\"",
                        Type = "urn:okta:expression:1.0",
                    },
                },
                Actions = new GroupRuleAction
                {
                    AssignUserToGroups = new GroupRuleGroupAssignment
                    {
                        GroupIds = new List<string> { createdGroup.Id },
                    },
                },
            };

            var createdGroupRule = await testClient.Groups.CreateGroupRuleAsync(groupRule);
            try
            {
                var retrievedGroupRule = await testClient.Groups.GetGroupRuleAsync(createdGroupRule.Id);
                retrievedGroupRule.Should().NotBeNull();
                retrievedGroupRule.Id.Should().Be(createdGroupRule.Id);
                retrievedGroupRule.Name.Should().Be(groupRule.Name);
            }
            finally
            {
                await createdGroupRule.DeactivateAsync();
                await testClient.Groups.DeleteGroupRuleAsync(createdGroupRule.Id);
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
                await createdGroup.DeleteAsync();
            }
        }

        [Fact]
        public async Task DeleteGroupRule()
        {
            var testClient = TestClient.Create();
            var guid = Guid.NewGuid();
            var testNickName = $"dotnet-sdk-{nameof(DeleteGroupRule)}";
            var testUserName = $"{testNickName}-{guid}@example.com";

            var profile = new UserProfile
            {
                FirstName = "John",
                LastName = $"{nameof(DeleteGroupRule)}",
                Email = testUserName,
                Login = testUserName,
                ["nickName"] = testNickName,
            };

            var createdUser = await testClient.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = profile,
                Password = "Abcd1234",
            });

            var createdGroup = await testClient.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk:{nameof(DeleteGroupRule)}-{guid}",
                Description = $"dotnet-sdk:{nameof(DeleteGroupRule)}-{guid}",
            });

            Thread.Sleep(3000); // allow user replication prior to read attempt

            var groupRule = new GroupRule
            {
                Type = "group_rule",
                Name = $"US group rule ({TestClient.RandomString(6)})", // guid would cause field to be too long
                Conditions = new GroupRuleConditions
                {
                    People = new GroupRulePeopleCondition
                    {
                        Users = new GroupRuleUserCondition
                        {
                            Exclude = new List<string> { createdUser.Id },
                        },
                        Groups = new GroupRuleGroupCondition
                        {
                            Exclude = new List<string>(),
                        },
                    },
                    Expression = new GroupRuleExpression
                    {
                        Value = "user.countryCode==\"US\"",
                        Type = "urn:okta:expression:1.0",
                    },
                },
                Actions = new GroupRuleAction
                {
                    AssignUserToGroups = new GroupRuleGroupAssignment
                    {
                        GroupIds = new List<string> { createdGroup.Id },
                    },
                },
            };

            var createdGroupRule = await testClient.Groups.CreateGroupRuleAsync(groupRule);

            try
            {
                var retrievedGroupRule = await testClient.Groups.GetGroupRuleAsync(createdGroupRule.Id);
                retrievedGroupRule.Should().NotBeNull();

                await testClient.Groups.DeleteGroupRuleAsync(createdGroupRule.Id);
                Thread.Sleep(3000);
                var ex = await Assert.ThrowsAsync<OktaApiException>(() => testClient.Groups.GetGroupRuleAsync(createdGroup.Id));
                ex.StatusCode.Should().Be(404);
            }
            finally
            {
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
                await createdGroup.DeleteAsync();
            }
        }

        [Fact]
        public async Task ActivateGroupRule()
        {
            var testClient = TestClient.Create();
            var guid = Guid.NewGuid();
            var testNickName = $"dotnet-sdk-{nameof(ActivateGroupRule)}";
            var testUserName = $"{testNickName}-{guid}@example.com";

            var profile = new UserProfile
            {
                FirstName = "John",
                LastName = $"{nameof(ActivateGroupRule)}",
                Email = testUserName,
                Login = testUserName,
                ["nickName"] = testNickName,
            };

            var createdUser = await testClient.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = profile,
                Password = "Abcd1234",
            });

            var createdGroup = await testClient.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk:{nameof(ActivateGroupRule)}-{guid}",
                Description = $"dotnet-sdk:{nameof(ActivateGroupRule)}-{guid}",
            });

            Thread.Sleep(3000); // allow user replication prior to read attempt

            var groupRule = new GroupRule
            {
                Type = "group_rule",
                Name = $"US group rule ({TestClient.RandomString(6)})", // guid would cause field to be too long
                Conditions = new GroupRuleConditions
                {
                    People = new GroupRulePeopleCondition
                    {
                        Users = new GroupRuleUserCondition
                        {
                            Exclude = new List<string> { createdUser.Id },
                        },
                        Groups = new GroupRuleGroupCondition
                        {
                            Exclude = new List<string>(),
                        },
                    },
                    Expression = new GroupRuleExpression
                    {
                        Value = "user.countryCode==\"US\"",
                        Type = "urn:okta:expression:1.0",
                    },
                },
                Actions = new GroupRuleAction
                {
                    AssignUserToGroups = new GroupRuleGroupAssignment
                    {
                        GroupIds = new List<string> { createdGroup.Id },
                    },
                },
            };

            var createdGroupRule = await testClient.Groups.CreateGroupRuleAsync(groupRule);

            try
            {
                createdGroupRule.Should().NotBeNull();
                createdGroupRule.Status.Value.Should().Be("INACTIVE");

                await testClient.Groups.ActivateGroupRuleAsync(createdGroupRule.Id);
                Thread.Sleep(3000); // allow group replication prior to read attempt
                var retrievedGroupRule = await testClient.Groups.GetGroupRuleAsync(createdGroupRule.Id);
                retrievedGroupRule.Should().NotBeNull();
                retrievedGroupRule.Status.Value.Should().Be("ACTIVE");
            }
            finally
            {
                await createdGroupRule.DeactivateAsync();
                await testClient.Groups.DeleteGroupRuleAsync(createdGroupRule.Id);
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
                await createdGroup.DeleteAsync();
            }
        }

        [Fact]
        public async Task DeactivateGroupRule()
        {
            var testClient = TestClient.Create();
            var guid = Guid.NewGuid();
            var testNickName = $"dotnet-sdk-{nameof(ActivateGroupRule)}";
            var testUserName = $"{testNickName}-{guid}@example.com";

            var profile = new UserProfile
            {
                FirstName = "John",
                LastName = $"{nameof(DeactivateGroupRule)}",
                Email = testUserName,
                Login = testUserName,
                ["nickName"] = testNickName,
            };

            var createdUser = await testClient.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = profile,
                Password = "Abcd1234",
            });

            var createdGroup = await testClient.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk:{nameof(ActivateGroupRule)}-{guid}",
                Description = $"dotnet-sdk:{nameof(ActivateGroupRule)}-{guid}",
            });

            Thread.Sleep(3000); // allow user replication prior to read attempt

            var groupRule = new GroupRule
            {
                Type = "group_rule",
                Name = $"US group rule ({TestClient.RandomString(6)})", // guid would cause field to be too long
                Conditions = new GroupRuleConditions
                {
                    People = new GroupRulePeopleCondition
                    {
                        Users = new GroupRuleUserCondition
                        {
                            Exclude = new List<string> { createdUser.Id },
                        },
                        Groups = new GroupRuleGroupCondition
                        {
                            Exclude = new List<string>(),
                        },
                    },
                    Expression = new GroupRuleExpression
                    {
                        Value = "user.countryCode==\"US\"",
                        Type = "urn:okta:expression:1.0",
                    },
                },
                Actions = new GroupRuleAction
                {
                    AssignUserToGroups = new GroupRuleGroupAssignment
                    {
                        GroupIds = new List<string> { createdGroup.Id },
                    },
                },
            };

            var createdGroupRule = await testClient.Groups.CreateGroupRuleAsync(groupRule);

            try
            {
                createdGroupRule.Should().NotBeNull();

                await testClient.Groups.ActivateGroupRuleAsync(createdGroupRule.Id);
                var retrievedActiveGroupRule = await testClient.Groups.GetGroupRuleAsync(createdGroupRule.Id);
                retrievedActiveGroupRule.Should().NotBeNull();
                retrievedActiveGroupRule.Status.Value.Should().Be("ACTIVE");

                await createdGroupRule.DeactivateAsync();
                var retrievedInactiveGroupRule = await testClient.Groups.GetGroupRuleAsync(createdGroupRule.Id);
                retrievedInactiveGroupRule.Should().NotBeNull();
                retrievedInactiveGroupRule.Status.Value.Should().Be("INACTIVE");
            }
            finally
            {
                await createdGroupRule.DeactivateAsync();
                await testClient.Groups.DeleteGroupRuleAsync(createdGroupRule.Id);
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
                await createdGroup.DeleteAsync();
            }
        }

        [Fact]
        public async Task ListAssignedApplications()
        {
            var testClient = TestClient.Create();
            var guid = Guid.NewGuid();

            var createdApp = await testClient.Applications.CreateApplicationAsync(new CreateSwaApplicationOptions
            {
                Label = $"dotnet-sdk: {nameof(ListAssignedApplications)} {guid}",
                ButtonField = "btn-login",
                PasswordField = "txtbox-password",
                UsernameField = "txtbox-username",
                Url = "https://example.com/login.html",
                LoginUrlRegex = "^https://example.com/login.html",
            });

            var createdGroup = await testClient.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk:{nameof(ListAssignedApplications)}-{guid}",
                Description = $"dotnet-sdk:{nameof(ListAssignedApplications)}-{guid}",
            });

            await testClient.Applications.CreateApplicationGroupAssignmentAsync(new CreateApplicationGroupAssignmentOptions()
            {
                Priority = 0,
                ApplicationId = createdApp.Id,
                GroupId = createdGroup.Id,
            });

            Thread.Sleep(3000); // allow for replication prior to read attempt

            try
            {
                var assignedApplications = await testClient.Groups.ListAssignedApplicationsForGroup(createdGroup.Id).ToListAsync();
                assignedApplications.Should().NotBeNull();
                assignedApplications.Count.Should().BeGreaterThan(0);
                assignedApplications.FirstOrDefault(app => app.Id.Equals(createdApp.Id)).Should().NotBeNull();
            }
            finally
            {
                await createdApp.DeactivateAsync();
                await testClient.Applications.DeleteApplicationAsync(createdApp.Id);
                await testClient.Groups.DeleteGroupAsync(createdGroup.Id);
            }
        }
    }
}
