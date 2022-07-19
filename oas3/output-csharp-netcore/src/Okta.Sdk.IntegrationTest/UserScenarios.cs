﻿using FluentAssertions;
using Okta.Sdk.Abstractions;
using Okta.Sdk.Api;
using Okta.Sdk.Model;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    public class UserScenarios
    {
        private UserApi _userApi;
        private GroupApi _groupApi;
        private LinkedObjectApi _linkedObjectApi;

        public UserScenarios()
        {
            _userApi = new UserApi();
            _groupApi = new GroupApi();
            _linkedObjectApi = new LinkedObjectApi();
        }
            
        [Fact]
        public async Task ListUsers()
        {
            var guid = Guid.NewGuid();

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(ListUsers),
                    Email = $"john-{nameof(ListUsers)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(ListUsers)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(ListUsers)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);
            // this delay and the below retry policy are to handle:
            // https://developer.okta.com/docs/api/resources/users.html#list-users-with-search
            // "Queries data from a replicated store, so changes aren’t always immediately available in search results."
            await Task.Delay(3000);

            try
            {
                async Task UserShouldExist()
                {
                    var foundUsers = await _userApi.ListUsersAsync(search: $"profile.nickName eq \"{createdUser.Profile.NickName}\"").ToArrayAsync();

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
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task GetUser()
        {
            var guid = Guid.NewGuid();

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(GetUser),
                    Email = $"john-{nameof(GetUser)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(GetUser)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(GetUser)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            try
            {
                // Retrieve by ID
                var retrievedById = await _userApi.GetUserAsync(createdUser.Id);
                retrievedById.Profile.FirstName.Should().Be("John");
                retrievedById.Profile.LastName.Should().Be(nameof(GetUser));
                retrievedById.Profile.Email.Should().Be($"john-{nameof(GetUser)}-dotnet-sdk-{guid}@example.com");
                retrievedById.Profile.Login.Should().Be($"john-{nameof(GetUser)}-dotnet-sdk-{guid}@example.com");

                // Retrieve by login
                var retrievedByLogin = await _userApi.GetUserAsync(createdUser.Profile.Login);
                retrievedByLogin.Profile.FirstName.Should().Be("John");
                retrievedByLogin.Profile.LastName.Should().Be(nameof(GetUser));
                retrievedByLogin.Profile.Email.Should().Be($"john-{nameof(GetUser)}-dotnet-sdk-{guid}@example.com");
                retrievedByLogin.Profile.Login.Should().Be($"john-{nameof(GetUser)}-dotnet-sdk-{guid}@example.com");
            }
            finally
            {
                // Remove the user
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task CreateUserWithPasswordImportInlineHookOptions()
        {
            var randomString = RandomString(6); // guid causes fields that are too long and not accepted by the API

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(CreateUserWithPasswordImportInlineHookOptions),
                    Email = $"john-{nameof(CreateUserWithPasswordImportInlineHookOptions)}-dotnet-sdk-{randomString}@example.com",
                    Login = $"john-{nameof(CreateUserWithPasswordImportInlineHookOptions)}-dotnet-sdk-{randomString}@example.com",
                    NickName = $"johny-{nameof(CreateUserWithPasswordImportInlineHookOptions)}-{randomString}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential 
                    {
                        Hook = new PasswordCredentialHook() { Type = "default" } 
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            try
            {
                // Retrieve by ID
                var userRetrievedById = await _userApi.GetUserAsync(createdUser.Id);
                userRetrievedById.Profile.FirstName.Should().Be("John");
                userRetrievedById.Profile.LastName.Should().Be(nameof(CreateUserWithPasswordImportInlineHookOptions));
                userRetrievedById.Credentials.Provider.Type.Should().Be(AuthenticationProviderType.IMPORT);
                userRetrievedById.Credentials.Provider.Name.Should().Be("IMPORT");
            }
            finally
            {
                // Remove the user
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task CreateUserWithImportedHashedPassword()
        {
            var guid = Guid.NewGuid();
            var userLastName = nameof(CreateUserWithImportedHashedPassword);
            var userMail = $"{userLastName.ToLower()}-{guid}@example.com";

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = userLastName,
                    Email = userMail,
                    Login = userMail,
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Hash = new PasswordCredentialHash
                        {
                            Algorithm = PasswordCredentialHashAlgorithm.BCRYPT,
                            WorkFactor = 10,
                            Salt = "rwh3vH166HCH/NT9XV5FYu",
                            Value = "qaMqvAPULkbiQzkTCWo5XDcvzpk8Tna",
                        },
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            try
            {
                // Retrieve by ID
                var userRetrievedById = await _userApi.GetUserAsync(createdUser.Id);
                userRetrievedById.Profile.FirstName.Should().Be("John");
                userRetrievedById.Profile.LastName.Should().Be(userLastName);
                userRetrievedById.Credentials.Provider.Type.Should().Be(AuthenticationProviderType.IMPORT);
                userRetrievedById.Credentials.Provider.Name.Should().Be("IMPORT");
            }
            finally
            {
                // Remove the user
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
            }
        }


        [Fact]
        public async Task ActivateUser()
        {
            var guid = Guid.NewGuid();

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(ActivateUser),
                    Email = $"john-{nameof(ActivateUser)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(ActivateUser)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(ActivateUser)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    }                    
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            try
            {
                await _userApi.DeactivateUserAsync(createdUser.Id, false);

                // Verify user does not exist in list of active users
                var retrievedUser = await _userApi.GetUserAsync(createdUser.Id);
                retrievedUser.Status.Should().Be(UserStatus.DEPROVISIONED);

                // Activate the user
                await _userApi.ActivateUserAsync(createdUser.Id, false);

                // Verify user exists in list of active users
                retrievedUser = await _userApi.GetUserAsync(createdUser.Id);
                retrievedUser.Status.Should().Be(UserStatus.PROVISIONED);
            }
            finally
            {
                // Remove the user
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
            }
        }

        [Theory]
        [InlineData("Batman")]
        [InlineData("")]
        public async Task UpdateUserProfile(string nickName)
        {
            var guid = Guid.NewGuid();

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(UpdateUserProfile),
                    Email = $"john-{nameof(UpdateUserProfile)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(UpdateUserProfile)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(UpdateUserProfile)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            try
            {
                // Update profile
                createdUser.Profile.NickName = nickName;
                var updateUserRequest = new UpdateUserRequest
                {
                    Profile = createdUser.Profile
                };

                var updatedUser = await _userApi.UpdateUserAsync(createdUser.Id, updateUserRequest);
                updatedUser.Profile.NickName.Should().Be(nickName);

                var retrievedUser = await _userApi.GetUserAsync(createdUser.Id);
                retrievedUser.Profile.NickName.Should().Be(nickName);                
            }
            finally
            {
                // Remove the user
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task GetResetPasswordUrl()
        {
            var guid = Guid.NewGuid();

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(GetResetPasswordUrl),
                    Email = $"john-{nameof(GetResetPasswordUrl)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(GetResetPasswordUrl)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(GetResetPasswordUrl)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            try
            {

                var resetPasswordToken = await _userApi.ResetPasswordAsync(createdUser.Id, false);
                resetPasswordToken.ResetPasswordUrl.Should().NotBeNullOrEmpty();
            }
            finally
            {
                // Remove the user
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task SuspendUser()
        {
            var guid = Guid.NewGuid();

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(SuspendUser),
                    Email = $"john-{nameof(SuspendUser)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(SuspendUser)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(SuspendUser)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            try
            {
                await _userApi.SuspendUserAsync(createdUser.Id);

                var retrievedUser = await _userApi.GetUserAsync(createdUser.Id);

                retrievedUser.Status.Should().Be(UserStatus.SUSPENDED);

                await _userApi.UnsuspendUserAsync(createdUser.Id);

                retrievedUser = await _userApi.GetUserAsync(createdUser.Id);

                retrievedUser.Status.Should().Be(UserStatus.ACTIVE);
            }
            finally
            {
                // Remove the user
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task ChangeUserPassword()
        {
            var guid = Guid.NewGuid();

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(ChangeUserPassword),
                    Email = $"john-{nameof(ChangeUserPassword)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(ChangeUserPassword)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(ChangeUserPassword)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            try
            {
                await Task.Delay(1000); // just to make sure the date is later
                var changePasswordRequest = new ChangePasswordRequest
                {
                    OldPassword = new PasswordCredential
                    {
                        Value = "Abcd1234",
                    },
                    NewPassword = new PasswordCredential
                    {
                        Value = "1234Abcd",
                    },
                };

                await _userApi.ChangePasswordAsync(createdUser.Id, changePasswordRequest);

                var updatedUser = await _userApi.GetUserAsync(createdUser.Id);

                updatedUser.PasswordChanged.Value.Should().BeAfter(createdUser.PasswordChanged.Value);
            }
            finally
            {
                // Remove the user
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task ExpireUserPassword()
        {
            var guid = Guid.NewGuid();

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(ExpireUserPassword),
                    Email = $"john-{nameof(ExpireUserPassword)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(ExpireUserPassword)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(ExpireUserPassword)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            try
            {
                // Expire the user password
                var user = _userApi.ExpirePassword(createdUser.Id);

                user.Id.Should().Be(createdUser.Id);
            }
            finally
            {
                // Remove the user
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task ChangeUserRecoveryQuestion()
        {
            var guid = Guid.NewGuid();

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(ChangeUserRecoveryQuestion),
                    Email = $"john-{nameof(ChangeUserRecoveryQuestion)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(ChangeUserRecoveryQuestion)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(ChangeUserRecoveryQuestion)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            try
            {
                // Update the user's recovery question
                var changeRecoveryQuestionRequest = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    },
                    RecoveryQuestion = new RecoveryQuestionCredential
                    {
                        Question = "Answer to life, the universe & everything",
                        Answer = "42 of course"
                    }
                };

                await _userApi.ChangeRecoveryQuestionAsync(createdUser.Id, changeRecoveryQuestionRequest);
            }
            finally
            {
                // Remove the user
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task CreateUserWithProvider()
        {
            var guid = Guid.NewGuid();

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(CreateUserWithProvider),
                    Email = $"john-{nameof(CreateUserWithProvider)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(CreateUserWithProvider)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(CreateUserWithProvider)}-{guid}",
                    
                },
                Credentials = new UserCredentials
                {
                    Provider = new AuthenticationProvider
                    {
                        Type = AuthenticationProviderType.FEDERATION,
                        Name = "FEDERATION",
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest, true, true);

            try
            {
                // Retrieve by ID
                var retrievedById = await _userApi.GetUserAsync(createdUser.Id);
                retrievedById.Profile.LastName.Should().Be(nameof(CreateUserWithProvider));
                retrievedById.Credentials.Provider.Type.Should().Be(AuthenticationProviderType.FEDERATION);
                retrievedById.Credentials.Provider.Name.Should().Be("FEDERATION");
            }
            finally
            {
                // Remove the user
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task AssignRoleToUser()
        {
            var guid = Guid.NewGuid();

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(AssignRoleToUser),
                    Email = $"john-{nameof(AssignRoleToUser)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(AssignRoleToUser)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(AssignRoleToUser)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest, true);

            try
            {
                var assignRoleRequest = new AssignRoleRequest
                {
                    Type = RoleType.SUPERADMIN
                };

                await _userApi.AssignRoleToUserAsync(createdUser.Id, assignRoleRequest);
                var roles = await _userApi.ListAssignedRolesForUserAsync(createdUser.Id).ToListAsync();
                roles.Any(role => role.Type == RoleType.SUPERADMIN).Should().BeTrue();
            }
            finally
            {
                // Remove the user
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task ListRoles()
        {
            var guid = Guid.NewGuid();

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(ListRoles),
                    Email = $"john-{nameof(ListRoles)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(ListRoles)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(ListRoles)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            try
            {
                await _userApi.AssignRoleToUserAsync(createdUser.Id, new AssignRoleRequest
                {
                    Type = RoleType.SUPERADMIN
                });
                await _userApi.AssignRoleToUserAsync(createdUser.Id, new AssignRoleRequest
                {
                    Type = RoleType.APPADMIN
                });
                await _userApi.AssignRoleToUserAsync(createdUser.Id, new AssignRoleRequest
                {
                    Type = RoleType.ORGADMIN
                });

                await Task.Delay(5000);
                var roles = await _userApi.ListAssignedRolesForUserAsync(createdUser.Id).ToListAsync();

                roles.FirstOrDefault(x => x.Type == RoleType.SUPERADMIN).Should().NotBeNull();
                roles.FirstOrDefault(x => x.Type == RoleType.APPADMIN).Should().NotBeNull();
                roles.FirstOrDefault(x => x.Type == RoleType.ORGADMIN).Should().NotBeNull();
            }
            finally
            {
                // Remove the user
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task RemoveRole()
        {
            var guid = Guid.NewGuid();

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(RemoveRole),
                    Email = $"john-{nameof(RemoveRole)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(RemoveRole)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(RemoveRole)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            try
            {
                await _userApi.AssignRoleToUserAsync(createdUser.Id, new AssignRoleRequest
                {
                    Type = RoleType.SUPERADMIN
                });

                await _userApi.AssignRoleToUserAsync(createdUser.Id, new AssignRoleRequest
                {
                    Type = RoleType.ORGADMIN
                });

                await Task.Delay(5000);

                var roles = await _userApi.ListAssignedRolesForUserAsync(createdUser.Id).ToListAsync();
                roles.Any(x => x.Type == RoleType.SUPERADMIN).Should().BeTrue();
                roles.Any(x => x.Type == RoleType.ORGADMIN).Should().BeTrue();

                var role1 = roles.FirstOrDefault(x => x.Type == RoleType.SUPERADMIN);
                var role2 = roles.FirstOrDefault(x => x.Type == RoleType.ORGADMIN);

                await _userApi.RemoveRoleFromUserAsync(createdUser.Id, role1.Id);
                await _userApi.RemoveRoleFromUserAsync(createdUser.Id, role2.Id);

                roles = await _userApi.ListAssignedRolesForUserAsync(createdUser.Id).ToListAsync();
                roles.Any(x => x.Type == RoleType.SUPERADMIN).Should().BeFalse();
                roles.Any(x => x.Type == RoleType.ORGADMIN).Should().BeFalse();
            }
            finally
            {
                // Remove the user
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task ListGroupTargetsForRole()
        {
            var guid = Guid.NewGuid();

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(ListGroupTargetsForRole),
                    Email = $"john-{nameof(ListGroupTargetsForRole)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(ListGroupTargetsForRole)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(ListGroupTargetsForRole)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            var createdGroup = await _groupApi.CreateGroupAsync(new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk:{nameof(ListGroupTargetsForRole)}-{guid}",
                    Description = $"dotnet-sdk:{nameof(ListGroupTargetsForRole)}-{guid}",
                }
            });

            try
            {
                var role = await _userApi.AssignRoleToUserAsync(createdUser.Id, new AssignRoleRequest
                {
                    Type = RoleType.USERADMIN
                });
                _userApi.AddGroupTargetToRole(createdUser.Id, role.Id, createdGroup.Id);

                var retrievedGroupsForRole = await _userApi.ListGroupTargetsForRoleAsync(createdUser.Id, role.Id).ToListAsync();
                retrievedGroupsForRole.Should().Contain(x => x.Id == createdGroup.Id);
            }
            finally
            {
                // Remove the user
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                // Remove the group
                await _groupApi.DeleteGroupAsync(createdGroup.Id);
            }
        }

        [Fact]
        public async Task RemoveGroupTargetFromRole()
        {
            var guid = Guid.NewGuid();

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(ListGroupTargetsForRole),
                    Email = $"john-{nameof(ListGroupTargetsForRole)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(ListGroupTargetsForRole)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(ListGroupTargetsForRole)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            var createdGroup1 = await _groupApi.CreateGroupAsync(new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk:{nameof(ListGroupTargetsForRole)}1-{guid}",
                    Description = $"dotnet-sdk:{nameof(ListGroupTargetsForRole)}1-{guid}",
                }
            });

            var createdGroup2 = await _groupApi.CreateGroupAsync(new Group
            {
                Profile = new GroupProfile
                {
                    Name = $"dotnet-sdk:{nameof(ListGroupTargetsForRole)}2-{guid}",
                    Description = $"dotnet-sdk:{nameof(ListGroupTargetsForRole)}2-{guid}",
                }
            });

            try
            {
                var role = await _userApi.AssignRoleToUserAsync(createdUser.Id, new AssignRoleRequest
                {
                    Type = RoleType.USERADMIN,
                });

                // Need 2 groups, because if you remove the last one it throws an (expected) exception.
                await _userApi.AddGroupTargetToRoleAsync(createdUser.Id, role.Id, createdGroup1.Id);
                await _userApi.AddGroupTargetToRoleAsync(createdUser.Id, role.Id, createdGroup2.Id);

                var retrievedGroupsForRole = await _userApi.ListGroupTargetsForRoleAsync(createdUser.Id, role.Id).ToListAsync();
                retrievedGroupsForRole.Should().Contain(x => x.Id == createdGroup1.Id);
                retrievedGroupsForRole.Should().Contain(x => x.Id == createdGroup2.Id);

                await _userApi.RemoveGroupTargetFromRoleAsync(createdUser.Id, role.Id, createdGroup1.Id);

                retrievedGroupsForRole = await _userApi.ListGroupTargetsForRoleAsync(createdUser.Id, role.Id).ToListAsync(); 
                retrievedGroupsForRole.Should().NotContain(x => x.Id == createdGroup1.Id);
            }
            finally
            {
                // Remove the user
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                // Remove the groups
                await _groupApi.DeleteGroupAsync(createdGroup1.Id);
                await _groupApi.DeleteGroupAsync(createdGroup2.Id);
            }
        }

        [Fact]
        public async Task ForgotPassword()
        {
            var guid = Guid.NewGuid();

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(ForgotPassword),
                    Email = $"john-{nameof(ForgotPassword)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(ForgotPassword)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(ForgotPassword)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            await Task.Delay(5000); // allow for user replication prior to read attempt

            try
            {
                var policy = Polly.Policy
                    .Handle<Exception>()
                    .WaitAndRetryAsync(4, attemptNumber => TimeSpan.FromSeconds(Math.Pow(5, attemptNumber - 1)))
                    .ExecuteAsync(async () =>
                    {
                        var forgotPasswordResponse = await _userApi.ForgotPasswordAsync(createdUser.Id);
                        forgotPasswordResponse.Should().NotBeNull();
                        forgotPasswordResponse.ResetPasswordUrl.Should().NotBeNullOrEmpty();
                    });
            }
            finally
            {
                // Remove the user
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task ForgotPasswordSetNewPassword()
        {
            var guid = Guid.NewGuid();

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(ForgotPasswordSetNewPassword),
                    Email = $"john-{nameof(ForgotPasswordSetNewPassword)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(ForgotPasswordSetNewPassword)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(ForgotPasswordSetNewPassword)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    },
                    RecoveryQuestion = new RecoveryQuestionCredential
                    {
                        Question = "Answer to life, the universe, & everything",
                        Answer = "42 of course",
                    },
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            await Task.Delay(5000); // allow for user replication prior to read attempt

            try
            {
                var forgotPasswordResponse = await _userApi.ForgotPasswordSetNewPasswordAsync(createdUser.Id, new UserCredentials
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
                // Remove the user
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task ExpirePasswordAndGetTemporaryPassword()
        {
            var guid = Guid.NewGuid();

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(ExpirePasswordAndGetTemporaryPassword),
                    Email = $"john-EPAGTP-dotnet-sdk-{guid}@example.com",
                    Login = $"john-EPAGTP-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(ExpirePasswordAndGetTemporaryPassword)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    },
                    RecoveryQuestion = new RecoveryQuestionCredential
                    {
                        Question = "Answer to life, the universe, & everything",
                        Answer = "42 of course",
                    },
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            await Task.Delay(5000); // allow for user replication prior to read attempt

            try
            {
                var tempPassword = await _userApi.ExpirePasswordAndGetTemporaryPasswordAsync(createdUser.Id);
                tempPassword.Should().NotBeNull();
                tempPassword._TempPassword.Should().NotBeNullOrEmpty();
            }
            finally
            {
                // Remove the user
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
            }
        }

        [Fact(Skip = "Error When Run: You do not have permission to access the feature you are requesting")]
        public async Task GetLinkedObjectForUser()
        {
            var randomString = RandomString(6); // use of guid results in field values that are too long

            var primaryRelationshipName = $"dotnet_sdk_{nameof(GetLinkedObjectForUser)}_primary_{randomString}";
            var associatedRelationshipName = $"dotnet_sdk_{nameof(GetLinkedObjectForUser)}_associated_{randomString}";

            var createdPrimaryUser = await _userApi.CreateUserAsync(new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John-Primary",
                    LastName = $"{nameof(GetLinkedObjectForUser)}",
                    Email = $"{nameof(GetLinkedObjectForUser)}-primary-dotnet-sdk-{randomString}@example.com",
                    Login = $"{nameof(GetLinkedObjectForUser)}-primary-dotnet-sdk-{randomString}@example.com",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    },
                    RecoveryQuestion = new RecoveryQuestionCredential
                    {
                        Question = "Answer to life, the universe, & everything",
                        Answer = "42 of course",
                    },
                }
            });

            var createdAssociatedUser = await _userApi.CreateUserAsync(new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "David-Associated",
                    LastName = $"{nameof(GetLinkedObjectForUser)}",
                    Email = $"{nameof(GetLinkedObjectForUser)}-associated-dotnet-sdk-{randomString}@example.com",
                    Login = $"{nameof(GetLinkedObjectForUser)}-associated-dotnet-sdk-{randomString}@example.com",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    },
                    RecoveryQuestion = new RecoveryQuestionCredential
                    {
                        Question = "Answer to life, the universe, & everything",
                        Answer = "42 of course",
                    },
                }
            });

            var createdLinkedObjectDefinition = _linkedObjectApi.AddLinkedObjectDefinitionAsync(new LinkedObject
            {
                Primary = new LinkedObjectDetails
                {
                    Name = primaryRelationshipName,
                    Title = "Primary",
                    Description = "Primary link property",
                    Type = LinkedObjectDetailsType.USER,
                },
                Associated = new LinkedObjectDetails
                {
                    Name = associatedRelationshipName,
                    Title = "Associated",
                    Description = "Associated link property",
                    Type = LinkedObjectDetailsType.USER,
                }
            });

            await Task.Delay(3000); // allow for user replication prior to read attempt

            try
            {
                await _userApi.SetLinkedObjectForUserAsync(createdAssociatedUser.Id, primaryRelationshipName, createdPrimaryUser.Id);

                var links = await _userApi.GetLinkedObjectsForUserAsync(createdAssociatedUser.Id, primaryRelationshipName).ToListAsync();
                links.Should().NotBeNull();
                links.Count.Should().Be(1);
            }
            finally
            {
                await _userApi.DeactivateOrDeleteUserAsync(createdPrimaryUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdPrimaryUser.Id);

                await _userApi.DeactivateOrDeleteUserAsync(createdAssociatedUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdAssociatedUser.Id);

                await _linkedObjectApi.DeleteLinkedObjectDefinitionAsync(primaryRelationshipName);
            }
        }

        [Fact(Skip = "Error When Run: You do not have permission to access the feature you are requesting")]
        public async Task RemoveLinkedObjectForUser()
        {
            var randomString = RandomString(6); // use of guid results in field values that are too long

            var primaryRelationshipName = $"dotnet_sdk_{nameof(RemoveLinkedObjectForUser)}_primary_{randomString}";
            var associatedRelationshipName = $"dotnet_sdk_{nameof(RemoveLinkedObjectForUser)}_associated_{randomString}";

            var createdPrimaryUser = await _userApi.CreateUserAsync(new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John-Primary",
                    LastName = $"{nameof(RemoveLinkedObjectForUser)}",
                    Email = $"{nameof(RemoveLinkedObjectForUser)}-primary-dotnet-sdk-{randomString}@example.com",
                    Login = $"{nameof(RemoveLinkedObjectForUser)}-primary-dotnet-sdk-{randomString}@example.com",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    },
                    RecoveryQuestion = new RecoveryQuestionCredential
                    {
                        Question = "Answer to life, the universe, & everything",
                        Answer = "42 of course",
                    },
                }
            });

            var createdAssociatedUser = await _userApi.CreateUserAsync(new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "David-Associated",
                    LastName = $"{nameof(RemoveLinkedObjectForUser)}",
                    Email = $"{nameof(RemoveLinkedObjectForUser)}-associated-dotnet-sdk-{randomString}@example.com",
                    Login = $"{nameof(RemoveLinkedObjectForUser)}-associated-dotnet-sdk-{randomString}@example.com",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    },
                    RecoveryQuestion = new RecoveryQuestionCredential
                    {
                        Question = "Answer to life, the universe, & everything",
                        Answer = "42 of course",
                    },
                }
            });

            var createdLinkedObjectDefinition = _linkedObjectApi.AddLinkedObjectDefinitionAsync(new LinkedObject
            {
                Primary = new LinkedObjectDetails
                {
                    Name = primaryRelationshipName,
                    Title = "Primary",
                    Description = "Primary link property",
                    Type = LinkedObjectDetailsType.USER,
                },
                Associated = new LinkedObjectDetails
                {
                    Name = associatedRelationshipName,
                    Title = "Associated",
                    Description = "Associated link property",
                    Type = LinkedObjectDetailsType.USER,
                }
            });

            await Task.Delay(3000); // allow for user replication prior to read attempt

            try
            {
                await _userApi.SetLinkedObjectForUserAsync(createdAssociatedUser.Id, primaryRelationshipName, createdPrimaryUser.Id);

                var links = await _userApi.GetLinkedObjectsForUserAsync(createdAssociatedUser.Id, primaryRelationshipName).ToListAsync();
                links.Should().NotBeNull();
                links.Count.Should().Be(1);

                await _userApi.RemoveLinkedObjectForUserAsync(createdAssociatedUser.Id, primaryRelationshipName);//await createdAssociatedUser.RemoveLinkedObjectAsync(primaryRelationshipName);
                links = await _userApi.GetLinkedObjectsForUserAsync(createdAssociatedUser.Id, primaryRelationshipName).ToListAsync();
                links.Should().NotBeNull();
                links.Count.Should().Be(0);
            }
            finally
            {
                await _userApi.DeactivateOrDeleteUserAsync(createdPrimaryUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdPrimaryUser.Id);

                await _userApi.DeactivateOrDeleteUserAsync(createdAssociatedUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdAssociatedUser.Id);

                await _linkedObjectApi.DeleteLinkedObjectDefinitionAsync(primaryRelationshipName);
            }
        }

        [Fact]
        public async Task ListAssignedRolesForUser()
        {
            var guid = Guid.NewGuid();

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(ListAssignedRolesForUser),
                    Email = $"john-{nameof(ListAssignedRolesForUser)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(ListAssignedRolesForUser)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(ListAssignedRolesForUser)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    },
                    RecoveryQuestion = new RecoveryQuestionCredential
                    {
                        Question = "Answer to life, the universe, & everything",
                        Answer = "42 of course",
                    },
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest);

            await Task.Delay(5000); // allow for user replication prior to read attempt

            try
            {
                var assignedRoles = await _userApi.ListAssignedRolesForUserAsync(createdUser.Id).ToListAsync();
                assignedRoles.Should().NotBeNull();
                assignedRoles.Count.Should().Be(0);
                await _userApi.AssignRoleToUserAsync(createdUser.Id, new AssignRoleRequest
                {
                    Type = RoleType.ORGADMIN,
                });

                assignedRoles = await _userApi.ListAssignedRolesForUserAsync(createdUser.Id).ToListAsync();
                assignedRoles.Should().NotBeNull();
                assignedRoles.Count.Should().Be(1);
                assignedRoles[0].Type.Should().Be(RoleType.ORGADMIN);
            }
            finally
            {
                // Remove the user
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
                await _userApi.DeactivateOrDeleteUserAsync(createdUser.Id);
            }
        }

        private static string RandomString(int length)
        {
            var random = new Random();
            var result = string.Empty;
            for (var i = 0; i < length; i++)
            {
                result += Convert.ToChar(random.Next(97, 122)); // ascii codes for printable alphabet
            }

            return result;
        }
    }
}
