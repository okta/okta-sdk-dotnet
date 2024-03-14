using FluentAssertions;
using Microsoft.Extensions.Options;
using Okta.Sdk.Abstractions;
using Okta.Sdk.Api;
using Okta.Sdk.Model;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    public class GroupScenarios
    {
        private UserApi _userApi;
        private GroupApi _groupApi;
        private ApplicationApi _appsApi;
        private RoleAssignmentApi _roleAssignmentApi;
        private RoleTargetApi _roleTargetApi;
        private ApplicationGroupsApi _appGroupsApi;

        public GroupScenarios()
        {
            _userApi = new UserApi();
            _groupApi = new GroupApi();
            _appsApi = new ApplicationApi();
            _roleAssignmentApi = new RoleAssignmentApi();
            _roleTargetApi = new RoleTargetApi();
            _appGroupsApi = new ApplicationGroupsApi();
        }

        [Fact]
        public async Task GetGroup()
        {
            
            var guid = Guid.NewGuid();
            
            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: {nameof(GetGroup)} {guid}"
                },
            };

            var createdGroup = await _groupApi.CreateGroupAsync(group);

            try
            {
                var retrievedGroup = await _groupApi.GetGroupAsync(createdGroup.Id);
                retrievedGroup.Profile.Name.Should().Be(group.Profile.Name);
                retrievedGroup.Should().NotBeNull();

            }
            finally
            {
                await _groupApi.DeleteGroupAsync(createdGroup.Id);
            }
        }

        [Fact]
        public async Task ListGroups()
        {

            var guid = Guid.NewGuid();

            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: {nameof(ListGroups)} {guid}"
                },
            };

            var createdGroup = await _groupApi.CreateGroupAsync(group);

            try
            {
                var groupList = await _groupApi.ListGroups().ToListAsync();
                groupList.SingleOrDefault(g => g.Id == createdGroup.Id).Should().NotBeNull();
            }
            finally
            {
                await _groupApi.DeleteGroupAsync(createdGroup.Id);
            }
        }


        [Fact]
        public async Task SearchGroup()
        {
            var groupName = $"dotnet-sdk: {nameof(SearchGroup)} {Guid.NewGuid()}";

            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = groupName
                },
            };

            var createdGroup = await _groupApi.CreateGroupAsync(group);

            try
            {
                Thread.Sleep(2000);
                var groupList = await _groupApi.ListGroups(search:$"profile.name sw \"{groupName}\"").ToListAsync();
                groupList.SingleOrDefault(g => g.Id == createdGroup.Id).Should().NotBeNull();
            }
            finally
            {
                await _groupApi.DeleteGroupAsync(createdGroup.Id);
            }
        }

        [Fact]
        public async Task UpdateGroup()
        {
            var guid = Guid.NewGuid();

            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: {nameof(UpdateGroup)} {guid}"
                },
            };

            var createdGroup = await _groupApi.CreateGroupAsync(group);
            await Task.Delay(1000);
            var updatedDescription = "This group has been updated";
            createdGroup.Profile.Description = updatedDescription;

            try
            {
                var updatedGroup = await _groupApi.ReplaceGroupAsync(createdGroup.Id, createdGroup);
                updatedGroup.LastUpdated.Should().BeAfter(updatedGroup.Created);
                updatedGroup.Profile.Description.Should().Be(updatedDescription);
            }
            finally
            {
                await _groupApi.DeleteGroupAsync(createdGroup.Id);
            }
        }

        [Fact]
        public async Task RemoveGroup()
        {

            var guid = Guid.NewGuid();

            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: {nameof(RemoveGroup)} {guid}"
                },
            };

            var createdGroup = await _groupApi.CreateGroupAsync(group);

            var retrievedGroup = await _groupApi.GetGroupAsync(createdGroup.Id);
            retrievedGroup.Should().NotBeNull();

            await Task.Delay(1000);

            await _groupApi.DeleteGroupAsync(createdGroup.Id);
            var groups = await _groupApi.ListGroups().ToListAsync();
            groups.FirstOrDefault(x => x.Id == createdGroup.Id).Should().BeNull();
           
        }

        [Fact]
        public async Task AddUserToGroup()
        {
            var guid = Guid.NewGuid();

            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: {nameof(AddUserToGroup)} {guid}"
                },
            };

            var createdGroup = await _groupApi.CreateGroupAsync(group);

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(AddUserToGroup),
                    Email = $"john-{nameof(AddUserToGroup)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(AddUserToGroup)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(AddUserToGroup)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "MyPass1234"
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);


            try
            {
                await _groupApi.AssignUserToGroupAsync(createdGroup.Id, createdUser.Id);
                var groupUsers = await _groupApi.ListGroupUsers(createdGroup.Id).ToListAsync();
                groupUsers.Any(x => x.Id == createdUser.Id).Should().BeTrue();
            }
            finally
            {
                await _groupApi.DeleteGroupAsync(createdGroup.Id);
                await _userApi.DeactivateUserAsync(createdUser.Id);
                await _userApi.DeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task RemoveUserFromGroup()
        {
            var guid = Guid.NewGuid();

            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: {nameof(RemoveUserFromGroup)} {guid}"
                },
            };

            var createdGroup = await _groupApi.CreateGroupAsync(group);

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(RemoveUserFromGroup),
                    Email = $"john-{nameof(RemoveUserFromGroup)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(RemoveUserFromGroup)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(RemoveUserFromGroup)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "MyPass1234"
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);


            try
            {
                await _groupApi.AssignUserToGroupAsync(createdGroup.Id, createdUser.Id);
                var groupUsers = await _groupApi.ListGroupUsers(createdGroup.Id).ToListAsync();
                groupUsers.Any(x => x.Id == createdUser.Id).Should().BeTrue();

                await _groupApi.UnassignUserFromGroupAsync(createdGroup.Id, createdUser.Id);
                groupUsers = await _groupApi.ListGroupUsers(createdGroup.Id).ToListAsync();
                groupUsers?.Any(x => x.Id == createdUser.Id).Should().BeFalse();
            }
            finally
            {
                await _groupApi.DeleteGroupAsync(createdGroup.Id);
                await _userApi.DeactivateUserAsync(createdUser.Id);
                await _userApi.DeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task ListRolesAssignedToGroup()
        {

            var guid = Guid.NewGuid();

            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: {nameof(ListRolesAssignedToGroup)} {guid}"
                },
            };

            var createdGroup = await _groupApi.CreateGroupAsync(group);

            try
            {
                var role1 = await _roleAssignmentApi.AssignRoleToGroupAsync(createdGroup.Id, new AssignRoleRequest
                {
                    Type = "SUPER_ADMIN"
                });

                var role2 = await _roleAssignmentApi.AssignRoleToGroupAsync(createdGroup.Id, new AssignRoleRequest
                {
                    Type = "APP_ADMIN"
                });

                var roles = await _roleAssignmentApi.ListGroupAssignedRoles(createdGroup.Id).ToListAsync();

                roles.Should().NotBeNullOrEmpty();
                roles.Should().Contain(x => x.Id == role1.Id);
                roles.Should().Contain(x => x.Id == role2.Id);
            }
            finally
            {
                await _groupApi.DeleteGroupAsync(createdGroup.Id);
            }
        }

        [Fact]
        public async Task UnassignRoleFromGroup()
        {

            var guid = Guid.NewGuid();

            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: {nameof(UnassignRoleFromGroup)} {guid}"
                },
            };

            var createdGroup = await _groupApi.CreateGroupAsync(group);

            try
            {
                var role1 = await _roleAssignmentApi.AssignRoleToGroupAsync(createdGroup.Id, new AssignRoleRequest
                {
                    Type = "SUPER_ADMIN"
                });
                
                var roles = await _roleAssignmentApi.ListGroupAssignedRoles(createdGroup.Id).ToListAsync();

                roles.Should().NotBeNullOrEmpty();
                roles.Should().Contain(x => x.Id == role1.Id);

                await _roleAssignmentApi.UnassignRoleFromGroupAsync(createdGroup.Id, role1.Id);

                roles = await _roleAssignmentApi.ListGroupAssignedRoles(createdGroup.Id).ToListAsync();
                roles.Should().BeNullOrEmpty();

            }
            finally
            {
                await _groupApi.DeleteGroupAsync(createdGroup.Id);
            }
        }

        [Fact]
        public async Task ListGroupTargetsForGroup()
        {

            var guid = Guid.NewGuid();

            var group1 = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: {nameof(ListGroupTargetsForGroup)}1 {guid}"
                },
            };

            var group2 = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: {nameof(ListGroupTargetsForGroup)}2 {guid}"
                },
            };

            var createdGroup1 = await _groupApi.CreateGroupAsync(group1);
            var createdGroup2 = await _groupApi.CreateGroupAsync(group2);

            try
            {
                var role1 = await _roleAssignmentApi.AssignRoleToGroupAsync(createdGroup1.Id, new AssignRoleRequest
                {
                    Type = "USER_ADMIN"
                });


                await _roleTargetApi.AssignGroupTargetToGroupAdminRoleAsync(createdGroup1.Id, role1.Id,
                    createdGroup2.Id);

                var groupTargetList =
                    await _roleTargetApi.ListGroupTargetsForGroupRole(createdGroup1.Id, role1.Id).ToListAsync();
                
                groupTargetList.Should().NotBeNullOrEmpty();
                groupTargetList.Should().Contain(x => x.Id == createdGroup2.Id);


            }
            finally
            {
                await _groupApi.DeleteGroupAsync(createdGroup1.Id);
                await _groupApi.DeleteGroupAsync(createdGroup2.Id);
            }
        }

        [Fact]
        public async Task RemoveGroupTargetFromGroupAdministratorRoleGivenToGroup()
        {

            var guid = Guid.NewGuid();

            var group1 = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: {nameof(RemoveGroupTargetFromGroupAdministratorRoleGivenToGroup)}1 {guid}"
                },
            };

            var group2 = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: {nameof(RemoveGroupTargetFromGroupAdministratorRoleGivenToGroup)}2 {guid}"
                },
            };

            var group3 = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk: {nameof(RemoveGroupTargetFromGroupAdministratorRoleGivenToGroup)}3 {guid}"
                },
            };

            var createdGroup1 = await _groupApi.CreateGroupAsync(group1);
            var createdGroup2 = await _groupApi.CreateGroupAsync(group2);
            var createdGroup3 = await _groupApi.CreateGroupAsync(group3);

            try
            {
                var role1 = await _roleAssignmentApi.AssignRoleToGroupAsync(createdGroup1.Id, new AssignRoleRequest
                {
                    Type = RoleType.USERADMIN
                });


                await _roleTargetApi.AssignGroupTargetToGroupAdminRoleAsync(createdGroup1.Id, role1.Id,
                    createdGroup2.Id);
                await _roleTargetApi.AssignGroupTargetToGroupAdminRoleAsync(createdGroup1.Id, role1.Id,
                    createdGroup3.Id);

                var groupTargetList =
                    await _roleTargetApi.ListGroupTargetsForGroupRole(createdGroup1.Id, role1.Id).ToListAsync();

                groupTargetList.Should().NotBeNullOrEmpty();
                groupTargetList.Should().Contain(x => x.Id == createdGroup2.Id);
                groupTargetList.Should().Contain(x => x.Id == createdGroup3.Id);

                await _roleTargetApi.UnassignGroupTargetFromGroupAdminRoleAsync(createdGroup1.Id, role1.Id,
                    createdGroup2.Id);

                groupTargetList =
                    await _roleTargetApi.ListGroupTargetsForGroupRole(createdGroup1.Id, role1.Id).ToListAsync();
                groupTargetList.Should().NotContain(x => x.Id == createdGroup2.Id);


            }
            finally
            {
                await _groupApi.DeleteGroupAsync(createdGroup1.Id);
                await _groupApi.DeleteGroupAsync(createdGroup2.Id);
                await _groupApi.DeleteGroupAsync(createdGroup3.Id);
            }
        }

        [Fact]
        public async Task CreateGroupRule()
        {
            var guid = Guid.NewGuid();

            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk:{nameof(CreateGroupRule)}-{guid}"
                },
            };

            var createdGroup = await _groupApi.CreateGroupAsync(group);

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(CreateGroupRule),
                    Email = $"john-{nameof(CreateGroupRule)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(CreateGroupRule)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(CreateGroupRule)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "MyPass1234"
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            var groupRule = new GroupRule
            {
                Type = "group_rule",
                Name = $"US group rule ({guid.ToString().Substring(6)})",
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

            var createdGroupRule = await _groupApi.CreateGroupRuleAsync(groupRule);

            try
            {
                createdGroupRule.Should().NotBeNull();
                createdGroupRule.Id.Should().NotBeNullOrEmpty();
                createdGroupRule.Type.Should().Be(groupRule.Type);
                createdGroupRule.Name.Should().Be(groupRule.Name);
            }
            finally
            {
                await _groupApi.DeleteGroupAsync(createdGroup.Id);
                await _groupApi.DeleteGroupRuleAsync(createdGroupRule.Id);
                await _userApi.DeactivateUserAsync(createdUser.Id);
                await _userApi.DeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task UpdateGroupRule()
        {
            var guid = Guid.NewGuid();

            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk:{nameof(UpdateGroupRule)}-{guid}"
                },
            };

            var createdGroup = await _groupApi.CreateGroupAsync(group);

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(UpdateGroupRule),
                    Email = $"john-{nameof(UpdateGroupRule)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(UpdateGroupRule)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(UpdateGroupRule)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "MyPass1234"
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            var groupRule = new GroupRule
            {
                Type = "group_rule",
                Name = $"US group rule ({guid.ToString().Substring(6)})",
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

            var createdGroupRule = await _groupApi.CreateGroupRuleAsync(groupRule);

            try
            {
                var updatedGroupRuleName = $"{groupRule.Name} upd";
                createdGroupRule.Name = updatedGroupRuleName;
                var updatedGroupRule = await _groupApi.ReplaceGroupRuleAsync(createdGroupRule.Id, createdGroupRule);

                updatedGroupRule.Id.Should().NotBeNullOrEmpty();
                updatedGroupRule.Id.Should().Be(createdGroupRule.Id);
                updatedGroupRule.Type.Should().Be(groupRule.Type);
                updatedGroupRule.Name.Should().Be(updatedGroupRuleName);
            }
            finally
            {
                await _groupApi.DeleteGroupAsync(createdGroup.Id);
                await _groupApi.DeleteGroupRuleAsync(createdGroupRule.Id);
                await _userApi.DeactivateUserAsync(createdUser.Id);
                await _userApi.DeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task ListGroupRules()
        {
            var guid = Guid.NewGuid();

            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk:{nameof(ListGroupRules)}-{guid}"
                },
            };

            var createdGroup = await _groupApi.CreateGroupAsync(group);

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(ListGroupRules),
                    Email = $"john-{nameof(ListGroupRules)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(ListGroupRules)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(ListGroupRules)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "MyPass1234"
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            var groupRule = new GroupRule
            {
                Type = "group_rule",
                Name = $"US group rule ({guid.ToString().Substring(6)})",
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

            var createdGroupRule = await _groupApi.CreateGroupRuleAsync(groupRule);

            try
            {
                var groupRules = await _groupApi.ListGroupRules().ToListAsync();
                groupRules.Any(x => x.Id == createdGroupRule.Id).Should().BeTrue();
            }
            finally
            {
                await _groupApi.DeleteGroupAsync(createdGroup.Id);
                await _groupApi.DeleteGroupRuleAsync(createdGroupRule.Id);
                await _userApi.DeactivateUserAsync(createdUser.Id);
                await _userApi.DeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task GetGroupRule()
        {
            var guid = Guid.NewGuid();

            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk:{nameof(GetGroupRule)}-{guid}"
                },
            };

            var createdGroup = await _groupApi.CreateGroupAsync(group);

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(GetGroupRule),
                    Email = $"john-{nameof(GetGroupRule)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(GetGroupRule)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(GetGroupRule)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "MyPass1234"
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            var groupRule = new GroupRule
            {
                Type = "group_rule",
                Name = $"US group rule ({guid.ToString().Substring(6)})",
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

            var createdGroupRule = await _groupApi.CreateGroupRuleAsync(groupRule);

            try
            {
                var retrievedGroupRule = await _groupApi.GetGroupRuleAsync(createdGroupRule.Id);
                retrievedGroupRule.Should().NotBeNull();
            }
            finally
            {
                await _groupApi.DeleteGroupAsync(createdGroup.Id);
                await _groupApi.DeleteGroupRuleAsync(createdGroupRule.Id);
                await _userApi.DeactivateUserAsync(createdUser.Id);
                await _userApi.DeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task DeleteGroupRule()
        {
            var guid = Guid.NewGuid();

            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk:{nameof(DeleteGroupRule)}-{guid}"
                },
            };

            var createdGroup = await _groupApi.CreateGroupAsync(group);

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(DeleteGroupRule),
                    Email = $"john-{nameof(DeleteGroupRule)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(DeleteGroupRule)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(DeleteGroupRule)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "MyPass1234"
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            var groupRule = new GroupRule
            {
                Type = "group_rule",
                Name = $"US group rule ({guid.ToString().Substring(6)})",
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

            var createdGroupRule = await _groupApi.CreateGroupRuleAsync(groupRule);

            try
            {
                var retrievedGroupRule = await _groupApi.GetGroupRuleAsync(createdGroupRule.Id);
                retrievedGroupRule.Should().NotBeNull();

                await _groupApi.DeleteGroupRuleAsync(createdGroupRule.Id);
                Thread.Sleep(3000);
                
                var ex = await Assert.ThrowsAsync<Okta.Sdk.Client.ApiException>(async () => await _groupApi.GetGroupRuleAsync(createdGroup.Id));
                ex.ErrorCode.Should().Be(404);


            }
            finally
            {
                await _groupApi.DeleteGroupAsync(createdGroup.Id);
                await _userApi.DeactivateUserAsync(createdUser.Id);
                await _userApi.DeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task ActivateDeactivateGroupRule()
        {
            var guid = Guid.NewGuid();

            var group = new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk:{nameof(ActivateDeactivateGroupRule)}-{guid}"
                },
            };

            var createdGroup = await _groupApi.CreateGroupAsync(group);

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(ActivateDeactivateGroupRule),
                    Email = $"john-{nameof(ActivateDeactivateGroupRule)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(ActivateDeactivateGroupRule)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(ActivateDeactivateGroupRule)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "MyPass1234"
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            var groupRule = new GroupRule
            {
                Type = "group_rule",
                Name = $"US group rule ({guid.ToString().Substring(6)})",
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

            var createdGroupRule = await _groupApi.CreateGroupRuleAsync(groupRule);

            try
            {
                createdGroupRule.Should().NotBeNull();
                createdGroupRule.Status.Should().Be(GroupRuleStatus.INACTIVE);

                await _groupApi.ActivateGroupRuleAsync(createdGroupRule.Id);

                Thread.Sleep(3000); // allow group replication prior to read attempt

                var retrievedGroupRule = await _groupApi.GetGroupRuleAsync(createdGroupRule.Id);
                retrievedGroupRule.Should().NotBeNull();
                retrievedGroupRule.Status.Should().Be(GroupRuleStatus.ACTIVE);

                await _groupApi.DeactivateGroupRuleAsync(createdGroupRule.Id);

                Thread.Sleep(3000); // allow group replication prior to read attempt

                retrievedGroupRule = await _groupApi.GetGroupRuleAsync(createdGroupRule.Id);
                retrievedGroupRule.Should().NotBeNull();
                retrievedGroupRule.Status.Should().Be(GroupRuleStatus.INACTIVE);
            }
            finally
            {
                await _groupApi.DeleteGroupAsync(createdGroup.Id);
                await _groupApi.DeleteGroupRuleAsync(createdGroupRule.Id);
                await _userApi.DeactivateUserAsync(createdUser.Id);
                await _userApi.DeleteUserAsync(createdUser.Id);
            }
        }


        //[Fact]
        //public async Task ListAssignedApplications()
        //{

        //    var guid = Guid.NewGuid();

        //    var group = new Group
        //    {
        //        Profile = new GroupProfile
        //        {
        //            Name = $"dotnet-sdk: Get Test Group {guid}"
        //        },
        //    };

        //    var createdGroup = await _groupApi.CreateGroupAsync(group);

        //    var app = new BasicAuthApplication
        //    {
        //        Name = "template_basic_auth",
        //        Label = $"dotnet-sdk: ListAssignedApplications {guid}",
        //        SignOnMode = "BASIC_AUTH",
        //        Settings = new BasicApplicationSettings
        //        {
        //            App = new BasicApplicationSettingsApplication
        //            {
        //                Url = "https://example.com/login.html",
        //                AuthURL = "https://example.com/auth.html",
        //            },
        //        },
        //    };

        //    var createdApp = await _appsApi.CreateApplicationAsync(app);
        //    try
        //    {
        //        var groupAssignment = new ApplicationGroupAssignment
        //        {
        //            Priority = 0,
        //        };

        //        await _appGroupsApi.AssignGroupToApplicationAsync(createdApp.Id, createdGroup.Id, groupAssignment);

        //        Thread.Sleep(3000); // allow for replication prior to read attempt

        //        var assignedApplications = await _groupApi.ListAssignedApplicationsForGroup(createdGroup.Id).ToListAsync();
        //        assignedApplications.Should().NotBeNull();
        //        assignedApplications.FirstOrDefault(app => app.Id.Equals(createdApp.Id)).Should().NotBeNull();
        //    }
        //    finally
        //    {
        //        await _groupApi.DeleteGroupAsync(createdGroup.Id);
        //    }
        //}
    }
}
