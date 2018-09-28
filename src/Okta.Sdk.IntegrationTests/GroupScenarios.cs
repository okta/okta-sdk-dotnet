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
                var groupList = await client.Groups.ListGroups().ToArray();
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
                    .ToArray();
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
                var groupUsersList = await retrievedGroup.Users.ToList();
                groupUsersList.Should().HaveCount(1);

                var retrievedUser = await retrievedGroup.Users.First(x => x.Id == createdUser.Id);
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
                var groupUsersList = await retrievedGroup.Users.ToList();
                groupUsersList.Should().HaveCount(1);

                var retrievedUser = await retrievedGroup.Users.First(x => x.Id == createdUser.Id);
                retrievedUser.Should().NotBeNull();

                await retrievedGroup.RemoveUserAsync(retrievedUser.Id);
                retrievedGroup = await client.Groups.GetGroupAsync(createdGroup.Id);
                groupUsersList = await retrievedGroup.Users.ToList();
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
                var groupUsersList = await retrievedGroup.Users.ToList();
                groupUsersList.Should().HaveCount(1);

                var retrievedUser = await retrievedGroup.Users.First(x => x.Id == createdUser.Id);
                retrievedUser.Should().NotBeNull();

                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();

                retrievedGroup = await client.Groups.GetGroupAsync(createdGroup.Id);
                groupUsersList = await retrievedGroup.Users.ToList();
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
                var groupUsersList = await retrievedGroup.Users.ToList();
                groupUsersList.Should().HaveCount(1);

                var retrievedUser = await retrievedGroup.Users.First(x => x.Id == createdUser.Id);
                retrievedUser.Should().NotBeNull();

                await client.Groups.DeleteGroupAsync(createdGroup.Id);
                var retrievedGroupsList = await client.Groups.ToList();
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

        [Fact(Skip = "https://github.com/okta/okta-sdk-dotnet/issues/94")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task GroupRuleOperations()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw new NotImplementedException();
        }
    }
}
