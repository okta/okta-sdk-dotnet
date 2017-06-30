// <copyright file="UserScenarios.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    [Collection(nameof(ScenariosCollection))]
    public class UserScenarios : ScenarioGroup
    {
        [Fact]
        public async Task ListUsers()
        {
            var client = GetClient("list-users");

            var profile = new UserProfile
            {
                FirstName = "John",
                LastName = "List-Users",
                Email = "john-list-users@example.com",
                Login = "john-list-users@example.com",
            };
            profile["nickName"] = "johny-list-users";

            var user = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = profile,
                Password = "Abcd1234",
            });

            try
            {
                // this delay is to handle:
                // https://developer.okta.com/docs/api/resources/users.html#list-users-with-search
                // "Queries data from a replicated store, so changes aren’t always immediately available in search results."
                await Task.Delay(1000);
                var foundUsers = await client
                    .Users
                    .ListUsers(search: $"profile.nickName eq \"{user.Profile.GetProperty<string>("nickName")}\"")
                    .ToArray();

                foundUsers.Length.Should().Be(1);
                foundUsers.Single().Id.Should().Be(user.Id);
            }
            finally
            {
                await user.DeactivateAsync();
                await user.DeactivateOrDeleteAsync();
            }
        }

        [Fact]
        public async Task GetUser()
        {
            var client = GetClient("user-get");

            // Create a user
            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Get-User",
                    Email = "john-get-user@example.com",
                    Login = "john-get-user@example.com",
                },
                Password = "Abcd1234",
                Activate = false,
            });

            // Retrieve by ID
            var retrievedById = await client.Users.GetUserAsync(createdUser.Id); // todo: Get(string)?
            retrievedById.Profile.FirstName.Should().Be("John");
            retrievedById.Profile.LastName.Should().Be("Get-User");

            // Retrieve by login
            var retrievedByLogin = await client.Users.GetUserAsync(createdUser.Profile.Login);
            retrievedByLogin.Profile.FirstName.Should().Be("John");
            retrievedByLogin.Profile.LastName.Should().Be("Get-User");

            // Remove the user
            await createdUser.DeactivateAsync();
            await createdUser.DeactivateOrDeleteAsync();

            // Getting by ID should result in 404 error
            await Assert.ThrowsAsync<OktaApiException>(
                () => client.Users.GetUserAsync(createdUser.Id));
        }

        [Fact]
        public async Task ActivateUser()
        {
            var client = GetClient("user-activate");

            // Create a user
            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Activate",
                    Email = "john-activate@example.com",
                    Login = "john-activate@example.com",
                },
                Password = "Abcd1234",
                Activate = false,
            });

            // Activate the user
            await createdUser.ActivateAsync(sendEmail: false);

            // Verify user exists in list of active users
            var activeUsers = await client.Users.ListUsers(filter: "status eq \"ACTIVE\"").ToArray();
            activeUsers.Should().Contain(u => u.Id == createdUser.Id);

            // Remove the user
            await createdUser.DeactivateAsync();
            await createdUser.DeactivateOrDeleteAsync();
        }

        [Fact]
        public async Task UpdateUserProfile()
        {
            var client = GetClient("user-proflie-update");

            // Create a user
            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Profile-Update",
                    Email = "john-profile-update@example.com",
                    Login = "john-profile-update@example.com",
                },
                Password = "Abcd1234",
                Activate = false,
            });

            // Update profile
            createdUser.Profile["nickName"] = "Batman";

            var updatedUser = await client.Users.UpdateUserAsync(createdUser, createdUser.Id);
            // TODO: make this better
            var retrievedUpdatedUser = await client.Users.GetUserAsync(createdUser.Id);

            updatedUser.Profile.GetProperty<string>("nickName").Should().Be("Batman");
            retrievedUpdatedUser.Profile.GetProperty<string>("nickName").Should().Be("Batman");

            // Deactivate + delete
            await createdUser.DeactivateAsync();
            await createdUser.DeactivateOrDeleteAsync();
        }
    }
}
