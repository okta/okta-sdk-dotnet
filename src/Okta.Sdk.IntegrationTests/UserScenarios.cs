// <copyright file="UserScenarios.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Polly;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    [Collection(nameof(UserScenarios))]
    public class UserScenarios
    {
        [Fact]
        public async Task ListUsers()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var profile = new UserProfile
            {
                FirstName = "John",
                LastName = "List-Users",
                Email = $"john-list-users-dotnet-sdk-{guid}@example.com",
                Login = $"john-list-users-dotnet-sdk-{guid}@example.com",
            };
            profile["nickName"] = "johny-list-users";

            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = profile,
                Password = "Abcd1234",
            });

            // this delay and the below retry policy are to handle:
            // https://developer.okta.com/docs/api/resources/users.html#list-users-with-search
            // "Queries data from a replicated store, so changes aren’t always immediately available in search results."
            await Task.Delay(10000);

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

                var policy = Polly.Policy
                    .Handle<Exception>()
                    .WaitAndRetryAsync(3, attemptNumber => TimeSpan.FromSeconds(Math.Pow(5, attemptNumber - 1)));

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
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            // Create a user
            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Get-User",
                    Email = $"john-get-user-dotnet-sdk-{guid}@example.com",
                    Login = $"john-get-user-dotnet-sdk-{guid}@example.com",
                },
                Password = "Abcd1234",
                Activate = false,
            });

            try
            {
                // Retrieve by ID
                var retrievedById = await client.Users.GetUserAsync(createdUser.Id);
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
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            // Create a user
            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Activate",
                    Email = $"john-activate-dotnet-sdk-{guid}@example.com",
                    Login = $"john-activate-dotnet-sdk-{guid}@example.com",
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

        [Theory]
        [InlineData("Batman")]
        [InlineData("")]
        public async Task UpdateUserProfile(string nickName)
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            // Create a user
            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Profile-Update",
                    Email = $"john-profile-update-dotnet-sdk-{guid}@example.com",
                    Login = $"john-profile-update-dotnet-sdk-{guid}@example.com",
                },
                Password = "Abcd1234",
                Activate = false,
            });

            try
            {
                // Update profile
                createdUser.Profile["nickName"] = nickName;

                var updatedUser = await createdUser.UpdateAsync();
                var retrievedUpdatedUser = await client.Users.GetUserAsync(createdUser.Id);

                updatedUser.Profile.GetProperty<string>("nickName").Should().Be(nickName);
                retrievedUpdatedUser.Profile.GetProperty<string>("nickName").Should().Be(nickName);
            }
            finally
            {
                // Deactivate + delete
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }

        [Fact]
        public async Task UpdateUserProfileWithDynamicObject()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            // Create a user
            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Dynamic Profile",
                    Email = $"john-dynamic-profile-dotnet-sdk-{guid}@example.com",
                    Login = $"john-dynamic-profile-dotnet-sdk-{guid}@example.com",
                },
                Password = "Abcd1234",
                Activate = false,
            });

            try
            {
                var titleObject = new
                {
                    prop1 = "prop1",
                    prop2 = new List<string> { "item1", "item2", "item3" },
                    prop3 = new { name = "ObjectSample" },
                    prop4 = 4,
                };

                createdUser.Profile["title"] = JsonConvert.SerializeObject(titleObject);
                var updatedUser = await createdUser.UpdateAsync();
                var retrievedUpdatedUser = await client.Users.GetUserAsync(createdUser.Id);

                var retrievedTitleStr = retrievedUpdatedUser.Profile.GetProperty<string>("title");
                dynamic retrievedTitle = JsonConvert.DeserializeObject(retrievedTitleStr);

                ((string)retrievedTitle.prop1).Should().Be("prop1");
                ((JArray)retrievedTitle.prop2).Should().HaveCount(3);
                ((string)retrievedTitle.prop3.name).Should().Be("ObjectSample");
                ((int)retrievedTitle.prop4).Should().Be(4);
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
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Get-Reset-Password-URL",
                    Email = $"john-get-reset-password-url-dotnet-sdk-{guid}@example.com",
                    Login = $"john-get-reset-password-url-dotnet-sdk-{guid}@example.com",
                },
                Password = "Abcd1234",
                Activate = true,
            });

            try
            {
                var resetPasswordToken = await createdUser.ResetPasswordAsync(sendEmail: false);
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
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            // Create a user
            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Suspend",
                    Email = $"john-suspend-dotnet-sdk-{guid}@example.com",
                    Login = $"john-suspend-dotnet-sdk-{guid}@example.com",
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
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Change-User-Password",
                    Email = $"john-change-user-password-dotnet-sdk-{guid}@example.com",
                    Login = $"john-change-user-password-dotnet-sdk-{guid}@example.com",
                },
                Password = "Abcd1234",
                Activate = true,
            });

            try
            {
                await Task.Delay(1000); // just to make sure the date is later
                await createdUser.ChangePasswordAsync(new ChangePasswordOptions
                {
                    CurrentPassword = "Abcd1234",
                    NewPassword = "1234Abcd",
                });

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
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            // Create a user
            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Expire-Password",
                    Email = $"john-expire-password-dotnet-sdk-{guid}@example.com",
                    Login = $"john-expire-password-dotnet-sdk-{guid}@example.com",
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
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            // Create a user
            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Change-Recovery-Question",
                    Email = $"john-change-recover-question-dotnet-sdk-{guid}@example.com",
                    Login = $"john-change-recover-question-dotnet-sdk-{guid}@example.com",
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

        [Fact]
        public async Task CreateUserWithProvider()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            // Create a user
            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithProviderOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "Joanna",
                    LastName = "CreatedWithProvider",
                    Email = $"joanna-create-with-provider-dotnet-sdk-{guid}@example.com",
                    Login = $"joanna-create-with-provider-dotnet-sdk-{guid}@example.com",
                },
                ProviderType = AuthenticationProviderType.Federation,
                ProviderName = "FEDERATION",
            });

            try
            {
                // Retrieve by ID
                var retrievedById = await client.Users.GetUserAsync(createdUser.Id);
                retrievedById.Profile.LastName.Should().Be("CreatedWithProvider");
                retrievedById.Credentials.Provider.Type.Should().Be(AuthenticationProviderType.Federation);
                retrievedById.Credentials.Provider.Name.Should().Be("FEDERATION");
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

        [Fact(Skip = "TODO")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task AssignUserRole()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw new NotImplementedException();
        }

        [Fact(Skip = "https://github.com/okta/okta-sdk-dotnet/issues/88")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task UserGroupTargetRole()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            throw new NotImplementedException();
        }
    }
}
