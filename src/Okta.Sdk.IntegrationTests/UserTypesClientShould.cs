// <copyright file="UserTypesClientShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    public class UserTypesClientShould
    {
        [Fact]
        public async Task CreateUserType()
        {
            var testClient = TestClient.Create();

            var testDescription = $"{nameof(CreateUserType)} Test Description";
            var testDisplayName = $"{nameof(CreateUserType)} Test DisplayName";
            var testName = $"{nameof(CreateUserType)}_TestUserType";

            var createdUserType = await testClient.UserTypes.CreateUserTypeAsync(new UserType
            {
                Description = testDescription,
                DisplayName = testDisplayName,
                Name = testName,
            });

            try
            {
                createdUserType.Id.Should().NotBeNullOrEmpty();
                createdUserType.Description.Should().Be(testDescription);
                createdUserType.DisplayName.Should().Be(testDisplayName);
                createdUserType.Name.Should().Be(testName);
            }
            finally
            {
                await DeleteAllUserTypes();
            }
        }

        [Fact]
        public async Task RetrieveUserTypeById()
        {
            var testClient = TestClient.Create();

            var testDescription = $"{nameof(RetrieveUserTypeById)} Test Description";
            var testDisplayName = $"{nameof(RetrieveUserTypeById)} Test DisplayName";
            var testName = $"{nameof(RetrieveUserTypeById)}_TestUserType";

            var createdUserType = await testClient.UserTypes.CreateUserTypeAsync(new UserType
            {
                Description = testDescription,
                DisplayName = testDisplayName,
                Name = testName,
            });

            try
            {
                createdUserType.Id.Should().NotBeNullOrEmpty();

                var retrievedUserType = await testClient.UserTypes.GetUserTypeAsync(createdUserType.Id);
                retrievedUserType.Should().NotBeNull();
                retrievedUserType.Id.Should().Be(createdUserType.Id);
                retrievedUserType.Description.Should().Be(testDescription);
                retrievedUserType.DisplayName.Should().Be(testDisplayName);
            }
            finally
            {
                await DeleteAllUserTypes();
            }
        }

        [Fact]
        public async Task UpdateUserType()
        {
            var testClient = TestClient.Create();

            var testDescription = $"{nameof(UpdateUserType)} Test Description";
            var testDisplayName = $"{nameof(UpdateUserType)} Test DisplayName";
            var testName = $"{nameof(UpdateUserType)}_TestUserType";

            var createdUserType = await testClient.UserTypes.CreateUserTypeAsync(new UserType
            {
                Description = testDescription,
                DisplayName = testDisplayName,
                Name = testName,
            });

            try
            {
                createdUserType.Id.Should().NotBeNullOrEmpty();

                var updatedDescription = $"{nameof(UpdateUserType)} Test Description Updated";
                var updatedDisplayName = $"{nameof(UpdateUserType)} Test DisplayName Updated";

                var updatesToUserType = new UserType
                {
                    Description = updatedDescription,
                    DisplayName = updatedDisplayName,
                };

                var updatedUserType = await testClient.UserTypes.UpdateUserTypeAsync(updatesToUserType, createdUserType.Id);
                updatedUserType.Id.Should().Be(createdUserType.Id);
                updatedUserType.Description.Should().Be(updatedDescription);
                updatedUserType.DisplayName.Should().Be(updatedDisplayName);

                var retrievedForValidation = await testClient.UserTypes.GetUserTypeAsync(createdUserType.Id);
                retrievedForValidation.Id.Should().Be(createdUserType.Id);
                retrievedForValidation.Description.Should().Be(updatedDescription);
                retrievedForValidation.DisplayName.Should().Be(updatedDisplayName);
            }
            finally
            {
                await DeleteAllUserTypes();
            }
        }

        [Fact]
        public async Task ReplaceUserType()
        {
            var testClient = TestClient.Create();
            var testDescription = $"{nameof(ReplaceUserType)} Test Description";
            var testDisplayName = $"{nameof(ReplaceUserType)} Test DisplayName";
            var testName = $"{nameof(ReplaceUserType)}_TestUserType";

            var createdUserType = await testClient.UserTypes.CreateUserTypeAsync(new UserType()
            {
                Description = testDescription,
                DisplayName = testDisplayName,
                Name = testName,
            });

            try
            {
                createdUserType.Id.Should().NotBeNullOrEmpty();

                var replacedDescription = $"{nameof(ReplaceUserType)} Test Description Replaced";
                var replacedDisplayName = $"{nameof(ReplaceUserType)} Test DisplayName Replaced";

                var replacedUserType = await testClient.UserTypes.ReplaceUserTypeAsync(
                    new UserType()
                    {
                        Description = replacedDescription,
                        DisplayName = replacedDisplayName,
                        Name = testName,
                    }, createdUserType.Id);

                replacedUserType.Id.Should().Be(createdUserType.Id);
                replacedUserType.Description.Should().Be(replacedDescription);
                replacedUserType.DisplayName.Should().Be(replacedDisplayName);
                replacedUserType.Name.Should().Be(testName);

                var retrievedForValidation = await testClient.UserTypes.GetUserTypeAsync(createdUserType.Id);
                retrievedForValidation.Id.Should().Be(createdUserType.Id);
                retrievedForValidation.Description.Should().Be(replacedDescription);
                retrievedForValidation.DisplayName.Should().Be(replacedDisplayName);
            }
            finally
            {
                await DeleteAllUserTypes();
            }
        }


        [Fact]
        public async Task DeleteUserTypeById()
        {
            var testClient = TestClient.Create();
            var testDescription = $"{nameof(DeleteUserTypeById)} Test Description";
            var testDisplayName = $"{nameof(DeleteUserTypeById)} Test DisplayName";
            var testName = $"{nameof(DeleteUserTypeById)}_TestUserType";

            var createdUserType = await testClient.UserTypes.CreateUserTypeAsync(new UserType
            {
                Description = testDescription,
                DisplayName = testDisplayName,
                Name = testName,
            });

            try
            {
                createdUserType.Id.Should().NotBeNullOrEmpty();

                var retrievedUserType = await testClient.UserTypes.GetUserTypeAsync(createdUserType.Id);
                retrievedUserType.Id.Should().Be(createdUserType.Id);

                await testClient.UserTypes.DeleteUserTypeAsync(createdUserType.Id);

                var ex = await Assert.ThrowsAsync<OktaApiException>(() =>
                    testClient.UserTypes.GetUserTypeAsync(createdUserType.Id));
                ex.StatusCode.Should().Be(404);
            }
            finally
            {
                await DeleteAllUserTypes();
            }
        }

        [Fact]
        public async Task ListAllUserTypes()
        {
            var testClient = TestClient.Create();
            var existingUserTypeIds = new HashSet<string>();
            await foreach (IUserType existingUserType in testClient.UserTypes.ListUserTypes())
            {
                existingUserTypeIds.Add(existingUserType.Id);
            }

            var testUserTypeIds = new HashSet<string>();
            for (int i = 0; i < 5; i++)
            {
                var createdUserType = await testClient.UserTypes.CreateUserTypeAsync(new UserType()
                {
                    Description = $"{nameof(ListAllUserTypes)} Test Description ({i})",
                    DisplayName = $"{nameof(ListAllUserTypes)} Test DisplayName ({i})",
                    Name = $"{nameof(ListAllUserTypes)}_TestUserType_{i}",
                });
                testUserTypeIds.Add(createdUserType.Id);
            }

            try
            {
                HashSet<string> allUserTypeIds = new HashSet<string>();
                ICollectionClient<IUserType> allUserTypes = testClient.UserTypes.ListUserTypes();
                int allUserTypesCount = await allUserTypes.CountAsync();
                allUserTypesCount.Should().BeGreaterThan(0);
                allUserTypesCount.Should().Be(existingUserTypeIds.Count + testUserTypeIds.Count);

                await foreach (IUserType userType in allUserTypes)
                {
                    allUserTypeIds.Add(userType.Id);
                }

                foreach (string testUserTypeId in testUserTypeIds)
                {
                    Assert.Contains(testUserTypeId, allUserTypeIds);
                }
            }
            finally
            {
                await DeleteAllUserTypes();
            }
        }

        private async Task DeleteAllUserTypes()
        {
            var testClient = TestClient.Create();
            await foreach (IUserType userType in testClient.UserTypes.ListUserTypes())
            {
                if (userType.Default != null && !userType.Default.Value)
                {
                    await testClient.UserTypes.DeleteUserTypeAsync(userType.Id);
                }
            }
        }
    }
}
