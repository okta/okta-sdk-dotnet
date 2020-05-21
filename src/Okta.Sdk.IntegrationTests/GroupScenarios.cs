// <copyright file="GroupScenarios.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Linq;
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
    }
}
