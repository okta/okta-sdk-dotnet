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
using Polly;
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

            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = profile,
                Password = "Abcd1234",
            });

            try
            {
                async Task UserShouldExist()
                {
                    var foundUsers = await client.Users
                        .ListUsers(search: $"profile.nickName eq \"{createdUser.Profile.GetProperty<string>("nickName")}\"")
                        .ToArray();

                    foundUsers.Length.Should().Be(1);
                    foundUsers.Single().Id.Should().Be(createdUser.Id);
                }

                // this delay is to handle:
                // https://developer.okta.com/docs/api/resources/users.html#list-users-with-search
                // "Queries data from a replicated store, so changes aren’t always immediately available in search results."

                var policy = Policy
                    .Handle<Exception>()
                    .WaitAndRetryAsync(3, attemptNumber => TimeSpan.FromSeconds(Math.Pow(2, attemptNumber - 1)));

                await policy.ExecuteAsync(UserShouldExist);
            }
            finally
            {
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
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

            try
            {
                // Retrieve by ID
                var retrievedById = await client.Users.GetUserAsync(createdUser.Id); // todo: Get(string)?
                retrievedById.Profile.FirstName.Should().Be("John");
                retrievedById.Profile.LastName.Should().Be("Get-User");

                // Retrieve by login
                var retrievedByLogin = await client.Users.GetUserAsync(createdUser.Profile.Login);
                retrievedByLogin.Profile.FirstName.Should().Be("John");
                retrievedByLogin.Profile.LastName.Should().Be("Get-User");
            }
            finally
            {
                // Remove the user
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }

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

            try
            {
                // Activate the user
                await createdUser.ActivateAsync(sendEmail: false);

                // Verify user exists in list of active users
                var activeUsers = await client.Users.ListUsers(filter: "status eq \"ACTIVE\"").ToArray();
                activeUsers.Should().Contain(u => u.Id == createdUser.Id);
            }
            finally
            {
                // Remove the user
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }

        [Fact(Skip = "Needs work!")]
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

            try
            {
                // Update profile
                createdUser.Profile["nickName"] = "Batman";

                throw new NotImplementedException("TODO - need a better Update method");
                //var updatedUser = await client.Users.UpdateUserAsync(createdUser, createdUser.Id);
                // TODO: make this better
                var retrievedUpdatedUser = await client.Users.GetUserAsync(createdUser.Id);

                //updatedUser.Profile.GetProperty<string>("nickName").Should().Be("Batman");
                //retrievedUpdatedUser.Profile.GetProperty<string>("nickName").Should().Be("Batman");
            }
            finally
            {
                // Deactivate + delete
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }

        [Fact]
        public async Task GetResetPasswordUrl()
        {
            var client = GetClient("get-reset-password-url");

            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Get-Reset-Password-URL",
                    Email = "john-get-reset-password-url@example.com",
                    Login = "john-get-reset-password-url@example.com",
                },
                Password = "Abcd1234",
                Activate = true,
            });

            try
            {
                var resetPasswordToken = await client.Users.ResetPasswordAsync(createdUser.Id, null, false);
                resetPasswordToken.ResetPasswordUrl.Should().NotBeNullOrEmpty();
            }
            finally
            {
                // Deactivate + delete
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }

        [Fact]
        public async Task SuspendUser()
        {
            var client = GetClient("suspend");

            // Create a user
            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Suspend",
                    Email = "john-suspend@example.com",
                    Login = "john-suspend@example.com",
                },
                Password = "Abcd1234",
                Activate = true,
            });

            try
            {
                await createdUser.SuspendAsync();

                var suspendedUsers = await client.Users.ListUsers(filter: "status eq \"SUSPENDED\"").ToArray();
                suspendedUsers.Should().Contain(u => u.Id == createdUser.Id);

                await createdUser.UnsuspendAsync();

                var activeUsers = await client.Users.ListUsers(filter: "status eq \"ACTIVE\"").ToArray();
                activeUsers.Should().Contain(u => u.Id == createdUser.Id);
            }
            finally
            {
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }

        [Fact]
        public async Task ChangeUserPassword()
        {
            var client = GetClient("change-user-password");

            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Change-User-Password",
                    Email = "john-change-user-password@example.com",
                    Login = "john-change-user-password@example.com",
                },
                Password = "Abcd1234",
                Activate = true,
            });

            try
            {
                // TODO: Make this easier? (maybe ChangePasswordAsync(userId, oldPassword, newPassword)?
                var updatedUserCredentials = await client.Users.ChangePasswordAsync(
                    new ChangePasswordRequest
                    {
                        OldPassword = new PasswordCredential { Value = "Abcd1234" },
                        NewPassword = new PasswordCredential { Value = "1234Abcd" },
                    },
                    createdUser.Id);

                var updatedUser = await client.Users.GetUserAsync(createdUser.Id);

                updatedUser.PasswordChanged.Value.Should().BeAfter(createdUser.PasswordChanged.Value);

                // TODO: Add Check that you can now authn with the new password (Not in the SDK yet)
            }
            finally
            {
                // Deactivate + delete
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }

        [Fact]
        public async Task ExpireUserPassword()
        {
            var client = GetClient("expire-password");

            // Create a user
            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Expire-Password",
                    Email = "john-expire-password@example.com",
                    Login = "john-expire-password@example.com",
                },
                Password = "Abcd1234",
                Activate = true,
            });

            try
            {
                // Expire the user password
                var tempPassword = await createdUser.ExpirePasswordAsync(tempPassword: true);

                tempPassword.Password.Should().NotBeNullOrEmpty();
            }
            finally
            {
                // Remove the user
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }

        [Fact]
        public async Task ChangeUserRecoveryQuestion()
        {
            var client = GetClient("change-recover-question");

            // Create a user
            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Change-Recovery-Question",
                    Email = "john-change-recover-question@example.com",
                    Login = "john-change-recover-question@example.com",
                },
                Password = "Abcd1234",
                Activate = true,
            });

            try
            {
                // Update the user's recovery question
                await createdUser.ChangeRecoveryQuestionAsync(new ChangeRecoveryQuestionOptions
                {
                    CurrentPassword = "Abcd1234",
                    RecoveryQuestion = "Answer to life, the universe, & everything",
                    RecoveryAnswer = "42 of course",
                });
            }
            finally
            {
                // Remove the user
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }

        [Fact(Skip = "TODO")]
        public async Task AssignUserRole()
        {
            throw new NotImplementedException();
        }

        [Fact(Skip = "TODO")]
        public async Task UserGroupTargetRole()
        {
            throw new NotImplementedException();
        }
    }
}
