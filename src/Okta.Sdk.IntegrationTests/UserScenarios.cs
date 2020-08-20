// <copyright file="UserScenarios.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
                ["nickName"] = $"johny-list-users-{guid}",
            };

            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = profile,
                Password = "Abcd1234",
            });

            // this delay and the below retry policy are to handle:
            // https://developer.okta.com/docs/api/resources/users.html#list-users-with-search
            // "Queries data from a replicated store, so changes aren’t always immediately available in search results."
            await Task.Delay(3000);

            try
            {
                async Task UserShouldExist()
                {
                    var foundUsers = await client.Users
                        .ListUsers(search: $"profile.nickName eq \"{createdUser.Profile.GetProperty<string>("nickName")}\"")
                        .ToArrayAsync();

                    foundUsers.Length.Should().Be(1);
                    foundUsers.Single().Id.Should().Be(createdUser.Id);
                }

                var policy = Polly.Policy
                    .Handle<Exception>()
                    .WaitAndRetryAsync(4, attemptNumber => TimeSpan.FromSeconds(Math.Pow(5, attemptNumber - 1)));

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
        public async Task CreateUserWithPasswordImportInlineHookOptions()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            // Create a user
            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordImportInlineHookOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "CreateUserWithPasswordImportInlineHookOptions",
                    Email = $"john-create-user-inline-hooks-pass-dotnet-sdk-{guid}@example.com",
                    Login = $"john-create-user-inline-hooks-pass-dotnet-sdk-{guid}@example.com",
                },
                Activate = false,
            });

            try
            {
                // Retrieve by ID
                var userRetrievedById = await client.Users.GetUserAsync(createdUser.Id);
                userRetrievedById.Profile.FirstName.Should().Be("John");
                userRetrievedById.Profile.LastName.Should().Be("CreateUserWithPasswordImportInlineHookOptions");
                userRetrievedById.Credentials.Provider.Type.Should().Be(AuthenticationProviderType.Import);
                userRetrievedById.Credentials.Provider.Name.Should().Be("IMPORT");

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
                var activeUsers = await client.Users.ListUsers(filter: "status eq \"ACTIVE\"").ToArrayAsync();
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

                var suspendedUsers = await client.Users.ListUsers(filter: "status eq \"SUSPENDED\"").ToArrayAsync();
                suspendedUsers.Should().Contain(u => u.Id == createdUser.Id);

                await createdUser.UnsuspendAsync();

                var activeUsers = await client.Users.ListUsers(filter: "status eq \"ACTIVE\"").ToArrayAsync();
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
                var user = await createdUser.ExpirePasswordAsync();

                user.Id.Should().Be(createdUser.Id);
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

        [Fact]
        public async Task AssignRoleToUser()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = $"{nameof(AssignRoleToUser)}",
                    Email = $"john-{nameof(AssignRoleToUser)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(AssignRoleToUser)}-dotnet-sdk-{guid}@example.com",
                },
                Password = "Abcd1234",
                Activate = true,
            });

            try
            {
                await createdUser.AssignRoleAsync(
                    new AssignRoleRequest()
                        {
                            Type = RoleType.SuperAdmin,
                        });

                var roles = await createdUser.Roles.ToListAsync();
                roles.FirstOrDefault(x => x.Type == RoleType.SuperAdmin).Should().NotBeNull();
            }
            finally
            {
                // Remove the user
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }

        [Fact]
        public async Task ListRoles()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = $"{nameof(ListRoles)}",
                    Email = $"john-{nameof(ListRoles)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(ListRoles)}-dotnet-sdk-{guid}@example.com",
                },
                Password = "Abcd1234",
                Activate = true,
            });

            try
            {
                await createdUser.AssignRoleAsync(
                    new AssignRoleRequest()
                    {
                        Type = RoleType.SuperAdmin,
                    });

                await createdUser.AssignRoleAsync(
                    new AssignRoleRequest()
                    {
                        Type = RoleType.AppAdmin,
                    });

                await createdUser.AssignRoleAsync(
                    new AssignRoleRequest()
                    {
                        Type = RoleType.OrgAdmin,
                    });

                var roles = await createdUser.Roles.ToListAsync();
                roles.Count.Should().Be(3);
                roles.FirstOrDefault(x => x.Type == RoleType.SuperAdmin).Should().NotBeNull();
                roles.FirstOrDefault(x => x.Type == RoleType.AppAdmin).Should().NotBeNull();
                roles.FirstOrDefault(x => x.Type == RoleType.OrgAdmin).Should().NotBeNull();
            }
            finally
            {
                // Remove the user
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }

        [Fact]
        public async Task RemoveRole()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = $"{nameof(RemoveRole)}",
                    Email = $"john-{nameof(RemoveRole)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(RemoveRole)}-dotnet-sdk-{guid}@example.com",
                },
                Password = "Abcd1234",
                Activate = true,
            });

            try
            {
                await createdUser.AssignRoleAsync(
                    new AssignRoleRequest()
                    {
                        Type = RoleType.SuperAdmin,
                    });

                await createdUser.AssignRoleAsync(
                    new AssignRoleRequest()
                    {
                        Type = RoleType.OrgAdmin,
                    });

                var roles = await createdUser.Roles.ToListAsync();
                roles.Count.Should().Be(2);

                var role1 = roles.FirstOrDefault(x => x.Type == RoleType.SuperAdmin);
                var role2 = roles.FirstOrDefault(x => x.Type == RoleType.OrgAdmin);

                await createdUser.RemoveRoleAsync(role1.Id);
                await createdUser.RemoveRoleAsync(role2.Id);

                roles = await createdUser.Roles.ToListAsync();
                roles.Count.Should().Be(0);
            }
            finally
            {
                // Remove the user
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }

        [Fact]
        public async Task ListGroupTargetsForRole()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = $"{nameof(ListGroupTargetsForRole)}",
                    Email = $"john-{nameof(ListGroupTargetsForRole)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(ListGroupTargetsForRole)}-dotnet-sdk-{guid}@example.com",
                },
                Password = "Abcd1234",
                Activate = true,
            });

            var createdGroup = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk:{nameof(ListGroupTargetsForRole)}-{guid}",
                Description = $"dotnet-sdk:{nameof(ListGroupTargetsForRole)}-{guid}",
            });

            try
            {
                var role = await createdUser.AssignRoleAsync(
                    new AssignRoleRequest
                    {
                        Type = RoleType.UserAdmin,
                    });

                await createdUser.AddGroupTargetAsync(role.Id, createdGroup.Id);

                var retrievedGroupsForRole = await createdUser.ListGroupTargets(role.Id).ToListAsync();
                retrievedGroupsForRole.Should().Contain(x => x.Id == createdGroup.Id);
            }
            finally
            {
                // Remove the user
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
                await createdGroup.DeleteAsync();
            }
        }

        [Fact]
        public async Task RemoveGroupTargetFromRole()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = $"{nameof(RemoveGroupTargetFromRole)}",
                    Email = $"john-{nameof(RemoveGroupTargetFromRole)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(RemoveGroupTargetFromRole)}-dotnet-sdk-{guid}@example.com",
                },
                Password = "Abcd1234",
                Activate = true,
            });

            var createdGroup1 = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk:{nameof(RemoveGroupTargetFromRole)}1-{guid}",
                Description = $"dotnet-sdk:{nameof(RemoveGroupTargetFromRole)}1-{guid}",
            });

            var createdGroup2 = await client.Groups.CreateGroupAsync(new CreateGroupOptions
            {
                Name = $"dotnet-sdk:{nameof(RemoveGroupTargetFromRole)}2-{guid}",
                Description = $"dotnet-sdk:{nameof(RemoveGroupTargetFromRole)}2-{guid}",
            });

            try
            {
                var role = await createdUser.AssignRoleAsync(
                    new AssignRoleRequest
                    {
                        Type = RoleType.UserAdmin,
                    });

                // Need 2 groups, because if you remove the last one it throws an (expected) exception.
                await createdUser.AddGroupTargetAsync(role.Id, createdGroup1.Id);
                await createdUser.AddGroupTargetAsync(role.Id, createdGroup2.Id);

                var retrievedGroupsForRole = await createdUser.ListGroupTargets(role.Id).ToListAsync();
                retrievedGroupsForRole.Should().Contain(x => x.Id == createdGroup1.Id);
                retrievedGroupsForRole.Should().Contain(x => x.Id == createdGroup2.Id);

                await createdUser.RemoveGroupTargetAsync(role.Id, createdGroup1.Id);

                retrievedGroupsForRole = await createdUser.ListGroupTargets(role.Id).ToListAsync();
                retrievedGroupsForRole.Should().NotContain(x => x.Id == createdGroup1.Id);
            }
            finally
            {
                // Remove the user
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
                await createdGroup1.DeleteAsync();
                await createdGroup2.DeleteAsync();
            }
        }

        [Fact]
        public async Task ForgotPasswordGenerateOneTimeToken()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = $"{nameof(ForgotPasswordGenerateOneTimeToken)}",
                    Email = $"{nameof(ForgotPasswordGenerateOneTimeToken)}-dotnet-sdk-{guid}@example.com",
                    Login = $"{nameof(ForgotPasswordGenerateOneTimeToken)}-dotnet-sdk-{guid}@example.com",
                },
                RecoveryQuestion = "Answer to life, the universe, & everything",
                RecoveryAnswer = "42 of course",
                Password = "Abcd1234",
                Activate = true,
            });

            Thread.Sleep(5000); // allow for user replication prior to read attempt

            try
            {
                var policy = Polly.Policy
                    .Handle<Exception>()
                    .WaitAndRetryAsync(4, attemptNumber => TimeSpan.FromSeconds(Math.Pow(5, attemptNumber - 1)))
                    .ExecuteAsync(async () =>
                    {
                        var forgotPasswordResponse = await createdUser.ForgotPasswordGenerateOneTimeTokenAsync(false);
                        forgotPasswordResponse.Should().NotBeNull();
                        forgotPasswordResponse.ResetPasswordUrl.Should().NotBeNullOrEmpty();
                    });
            }
            finally
            {
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }

        [Fact]
        public async Task ForgotPasswordSetNewPassword()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = $"{nameof(ForgotPasswordSetNewPassword)}",
                    Email = $"{nameof(ForgotPasswordSetNewPassword)}-dotnet-sdk-{guid}@example.com",
                    Login = $"{nameof(ForgotPasswordSetNewPassword)}-dotnet-sdk-{guid}@example.com",
                },
                RecoveryQuestion = "Answer to life, the universe, & everything",
                RecoveryAnswer = "42 of course",
                Password = "Abcd1234",
                Activate = true,
            });

            Thread.Sleep(3000); // allow for user replication prior to read attempt

            try
            {
                var forgotPasswordResponse = await createdUser.ForgotPasswordSetNewPasswordAsync(
                    new UserCredentials
                    {
                        Password = new PasswordCredential
                        {
                            Value = "NewPassword1!",
                        },
                        RecoveryQuestion = new RecoveryQuestionCredential
                        {
                            Question = "Answer to life, the universe, & everything",
                            Answer = "42 of course",
                        },
                    });
                forgotPasswordResponse.Should().NotBeNull();
            }
            finally
            {
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }

        [Fact]
        public async Task ExpirePasswordAndGetTemporaryPassword()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = $"{nameof(ExpirePasswordAndGetTemporaryPassword)}",
                    Email = $"{nameof(ExpirePasswordAndGetTemporaryPassword)}-dotnet-sdk-{guid}@example.com",
                    Login = $"{nameof(ExpirePasswordAndGetTemporaryPassword)}-dotnet-sdk-{guid}@example.com",
                },
                RecoveryQuestion = "Answer to life, the universe, & everything",
                RecoveryAnswer = "42 of course",
                Password = "Abcd1234",
                Activate = true,
            });

            Thread.Sleep(3000); // allow for user replication prior to read attempt

            try
            {
                var tempPassword = await createdUser.ExpirePasswordAndGetTemporaryPasswordAsync();
                tempPassword.Should().NotBeNull();
                tempPassword.Password.Should().NotBeNullOrEmpty();
            }
            finally
            {
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }
        
        [Fact]
        public async Task GetLinkedObjectForUser()
        {
            var client = TestClient.Create();
            var randomString = TestClient.RandomString(6); // use of guid results in field values that are too long

            var primaryRelationshipName = $"dotnet_sdk_{nameof(GetLinkedObjectForUser)}_primary_{randomString}";
            var associatedRelationshipName = $"dotnet_sdk_{nameof(GetLinkedObjectForUser)}_associated_{randomString}";

            var createdPrimaryUser = await client.Users.CreateUserAsync(
                new CreateUserWithPasswordOptions
                {
                    Profile = new UserProfile
                    {
                        FirstName = "John-Primary",
                        LastName = $"{nameof(GetLinkedObjectForUser)}",
                        Email = $"{nameof(GetLinkedObjectForUser)}-primary-dotnet-sdk-{randomString}@example.com",
                        Login = $"{nameof(GetLinkedObjectForUser)}-primary-dotnet-sdk-{randomString}@example.com",
                    },
                    RecoveryQuestion = "Answer to life, the universe, & everything",
                    RecoveryAnswer = "42 of course",
                    Password = "Abcd1234",
                    Activate = true,
                });

            var createdAssociatedUser = await client.Users.CreateUserAsync(
                new CreateUserWithPasswordOptions
                {
                    Profile = new UserProfile
                    {
                        FirstName = "David-Associated",
                        LastName = $"{nameof(GetLinkedObjectForUser)}",
                        Email = $"{nameof(GetLinkedObjectForUser)}-associated-dotnet-sdk-{randomString}@example.com",
                        Login = $"{nameof(GetLinkedObjectForUser)}-associated-dotnet-sdk-{randomString}@example.com",
                    },
                    RecoveryQuestion = "Answer to life, the universe, & everything",
                    RecoveryAnswer = "42 of course",
                    Password = "Abcd1234",
                    Activate = true,
                });

            var createdLinkedObjectDefinition = await client.LinkedObjects.AddLinkedObjectDefinitionAsync(
                new LinkedObject
                {
                    Primary = new LinkedObjectDetails
                    {
                        Name = primaryRelationshipName,
                        Title = "Primary",
                        Description = "Primary link property",
                        Type = "USER",
                    },
                    Associated = new LinkedObjectDetails
                    {
                        Name = associatedRelationshipName,
                        Title = "Associated",
                        Description = "Associated link property",
                        Type = "USER",
                    },
                });

            Thread.Sleep(3000); // allow for user replication prior to read attempt

            try
            {
                await createdAssociatedUser.SetLinkedObjectAsync(primaryRelationshipName, createdPrimaryUser.Id);
                var links = await createdAssociatedUser.GetLinkedObjects(primaryRelationshipName).ToListAsync();
                links.Should().NotBeNull();
                links.Count.Should().Be(1);
            }
            finally
            {
                await createdPrimaryUser.DeactivateAsync();
                await createdPrimaryUser.DeactivateOrDeleteAsync();
                await createdAssociatedUser.DeactivateAsync();
                await createdAssociatedUser.DeactivateOrDeleteAsync();
                await client.LinkedObjects.DeleteLinkedObjectDefinitionAsync(primaryRelationshipName);
            }
        }

        [Fact]
        public async Task RemoveLinkedObjectForUser()
        {
            var client = TestClient.Create();
            var randomString = TestClient.RandomString(6); // use of guid results in field values that are too long

            var primaryRelationshipName = $"dotnet_sdk_{nameof(RemoveLinkedObjectForUser)}_primary_{randomString}";
            var associatedRelationshipName = $"dotnet_sdk_{nameof(RemoveLinkedObjectForUser)}_associated_{randomString}";

            var createdPrimaryUser = await client.Users.CreateUserAsync(
                new CreateUserWithPasswordOptions
                {
                    Profile = new UserProfile
                    {
                        FirstName = "John-Primary",
                        LastName = $"{nameof(RemoveLinkedObjectForUser)}",
                        Email = $"{nameof(RemoveLinkedObjectForUser)}-primary-dotnet-sdk-{randomString}@example.com",
                        Login = $"{nameof(RemoveLinkedObjectForUser)}-primary-dotnet-sdk-{randomString}@example.com",
                    },
                    RecoveryQuestion = "Answer to life, the universe, & everything",
                    RecoveryAnswer = "42 of course",
                    Password = "Abcd1234",
                    Activate = true,
                });

            var createdAssociatedUser = await client.Users.CreateUserAsync(
                new CreateUserWithPasswordOptions
                {
                    Profile = new UserProfile
                    {
                        FirstName = "David-Associated",
                        LastName = $"{nameof(RemoveLinkedObjectForUser)}",
                        Email = $"{nameof(RemoveLinkedObjectForUser)}-associated-dotnet-sdk-{randomString}@example.com",
                        Login = $"{nameof(RemoveLinkedObjectForUser)}-associated-dotnet-sdk-{randomString}@example.com",
                    },
                    RecoveryQuestion = "Answer to life, the universe, & everything",
                    RecoveryAnswer = "42 of course",
                    Password = "Abcd1234",
                    Activate = true,
                });

            var createdLinkedObjectDefinition = await client.LinkedObjects.AddLinkedObjectDefinitionAsync(
                new LinkedObject
                {
                    Primary = new LinkedObjectDetails
                    {
                        Name = primaryRelationshipName,
                        Title = "Primary",
                        Description = "Primary link property",
                        Type = "USER",
                    },
                    Associated = new LinkedObjectDetails
                    {
                        Name = associatedRelationshipName,
                        Title = "Associated",
                        Description = "Associated link property",
                        Type = "USER",
                    },
                });

            Thread.Sleep(3000); // allow for user replication prior to read attempt

            try
            {
                await createdAssociatedUser.SetLinkedObjectAsync(primaryRelationshipName, createdPrimaryUser.Id);
                var links = await createdAssociatedUser.GetLinkedObjects(primaryRelationshipName).ToListAsync();
                links.Should().NotBeNull();
                links.Count.Should().Be(1);
                await createdAssociatedUser.RemoveLinkedObjectAsync(primaryRelationshipName);
                links = await createdAssociatedUser.GetLinkedObjects(primaryRelationshipName).ToListAsync();
                links.Should().NotBeNull();
                links.Count.Should().Be(0);
            }
            finally
            {
                await createdPrimaryUser.DeactivateAsync();
                await createdPrimaryUser.DeactivateOrDeleteAsync();
                await createdAssociatedUser.DeactivateAsync();
                await createdAssociatedUser.DeactivateOrDeleteAsync();
                await client.LinkedObjects.DeleteLinkedObjectDefinitionAsync(primaryRelationshipName);
            }
        }

        [Fact]
        public async Task ListAssignedRolesForUser()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();
            var createdUser = await client.Users.CreateUserAsync(
                new CreateUserWithPasswordOptions
                {
                    Profile = new UserProfile
                    {
                        FirstName = "John",
                        LastName = $"{nameof(ListAssignedRolesForUser)}",
                        Email = $"{nameof(ListAssignedRolesForUser)}-dotnet-sdk-{guid}@example.com",
                        Login = $"{nameof(ListAssignedRolesForUser)}-dotnet-sdk-{guid}@example.com",
                    },
                    RecoveryQuestion = "Answer to life, the universe, & everything",
                    RecoveryAnswer = "42 of course",
                    Password = "Abcd1234",
                    Activate = true,
                });

            Thread.Sleep(3000); // allow for user replication prior to read attempt

            try
            {
                var assignedRoles = await createdUser.ListAssignedRoles().ToListAsync();
                assignedRoles.Should().NotBeNull();
                assignedRoles.Count.Should().Be(0);
                await createdUser.AssignRoleAsync(
                    new AssignRoleRequest
                    {
                        Type = RoleType.OrgAdmin,
                    });
                assignedRoles = await createdUser.ListAssignedRoles().ToListAsync();
                assignedRoles.Should().NotBeNull();
                assignedRoles.Count.Should().Be(1);
                assignedRoles[0].Type.Should().Be(RoleType.OrgAdmin);
            }
            finally
            {
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();
            }
        }
    }
}
