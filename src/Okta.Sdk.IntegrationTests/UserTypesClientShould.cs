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
        private const string SdkPrefix = "dotnet_sdk";

        public UserTypesClientShould()
        {
            DeleteAllUserTypes().Wait();
        }

        [Fact]
        public async Task CreateUserType()
        {
            var testClient = TestClient.Create();

            var testDescription = $"{SdkPrefix}:{nameof(CreateUserType)} Test Description";
            var testDisplayName = $"{SdkPrefix}:{nameof(CreateUserType)} Test DisplayName";
            var testName = $"{SdkPrefix}_{nameof(CreateUserType)}_TestUserType";

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
                await testClient.UserTypes.DeleteUserTypeAsync(createdUserType.Id);
            }
        }

        [Fact]
        public async Task RetrieveUserTypeById()
        {
            var testClient = TestClient.Create();

            var testDescription = $"{SdkPrefix}:{nameof(RetrieveUserTypeById)} Test Description";
            var testDisplayName = $"{SdkPrefix}:{nameof(RetrieveUserTypeById)} Test DisplayName";
            var testName = $"{SdkPrefix}{nameof(RetrieveUserTypeById)}_TestUserType";

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
                await testClient.UserTypes.DeleteUserTypeAsync(createdUserType.Id);
            }
        }

        [Fact]
        public async Task UpdateUserType()
        {
            var testClient = TestClient.Create();

            var testDescription = $"{SdkPrefix}:{nameof(UpdateUserType)} Test Description";
            var testDisplayName = $"{SdkPrefix}:{nameof(UpdateUserType)} Test DisplayName";
            var testName = $"{SdkPrefix}_{nameof(UpdateUserType)}_TestUserType";

            var createdUserType = await testClient.UserTypes.CreateUserTypeAsync(new UserType
            {
                Description = testDescription,
                DisplayName = testDisplayName,
                Name = testName,
            });

            try
            {
                createdUserType.Id.Should().NotBeNullOrEmpty();

                var updatedDescription = $"{createdUserType.Description} Updated";
                var updatedDisplayName = $"{createdUserType.Description} Updated";

                var updatesToUserType = new UserType
                {
                    Description = updatedDescription,
                    DisplayName = updatedDisplayName,
                };

                var updatedUserType = await testClient.UserTypes.UpdateUserTypeAsync(updatesToUserType, createdUserType.Id);
                updatedUserType.Id.Should().Be(createdUserType.Id);
                updatedUserType.Description.Should().Be(updatedDescription);
                updatedUserType.DisplayName.Should().Be(updatedDisplayName);

                var retrievedUserTypeForValidation = await testClient.UserTypes.GetUserTypeAsync(createdUserType.Id);
                retrievedUserTypeForValidation.Id.Should().Be(createdUserType.Id);
                retrievedUserTypeForValidation.Description.Should().Be(updatedDescription);
                retrievedUserTypeForValidation.DisplayName.Should().Be(updatedDisplayName);
            }
            finally
            {
                await testClient.UserTypes.DeleteUserTypeAsync(createdUserType.Id);
            }
        }

        [Fact]
        public async Task ReplaceUserType()
        {
            var testClient = TestClient.Create();
            var testDescription = $"{SdkPrefix}:{nameof(ReplaceUserType)} Test Description";
            var testDisplayName = $"{SdkPrefix}:{nameof(ReplaceUserType)} Test DisplayName";
            var testName = $"{SdkPrefix}_{nameof(ReplaceUserType)}_TestUserType";

            var createdUserType = await testClient.UserTypes.CreateUserTypeAsync(new UserType()
            {
                Description = testDescription,
                DisplayName = testDisplayName,
                Name = testName,
            });

            try
            {
                createdUserType.Id.Should().NotBeNullOrEmpty();

                var replacedDescription = $"{createdUserType.Description} Repl"; // maximum length is 50
                var replacedDisplayName = $"{createdUserType.DisplayName} Repl";

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

                var retrievedUserTypeForValidation = await testClient.UserTypes.GetUserTypeAsync(createdUserType.Id);
                retrievedUserTypeForValidation.Id.Should().Be(createdUserType.Id);
                retrievedUserTypeForValidation.Description.Should().Be(replacedDescription);
                retrievedUserTypeForValidation.DisplayName.Should().Be(replacedDisplayName);
            }
            finally
            {
                await testClient.UserTypes.DeleteUserTypeAsync(createdUserType.Id);
            }
        }


        [Fact]
        public async Task DeleteUserTypeById()
        {
            var testClient = TestClient.Create();
            var testDescription = $"{SdkPrefix}:{nameof(DeleteUserTypeById)} Test Description";
            var testDisplayName = $"{SdkPrefix}:{nameof(DeleteUserTypeById)} Test DisplayName";
            var testName = $"{SdkPrefix}_{nameof(DeleteUserTypeById)}_TestUserType";

            var createdUserType = await testClient.UserTypes.CreateUserTypeAsync(new UserType
            {
                Description = testDescription,
                DisplayName = testDisplayName,
                Name = testName,
            });

            createdUserType.Id.Should().NotBeNullOrEmpty();

            var retrievedUserType = await testClient.UserTypes.GetUserTypeAsync(createdUserType.Id);
            retrievedUserType.Id.Should().Be(createdUserType.Id);

            await testClient.UserTypes.DeleteUserTypeAsync(createdUserType.Id);

            var ex = await Assert.ThrowsAsync<OktaApiException>(() =>
                testClient.UserTypes.GetUserTypeAsync(createdUserType.Id));
            ex.StatusCode.Should().Be(404);
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

            var allUserTypeIds = new HashSet<string>();
            var allUserTypes = testClient.UserTypes.ListUserTypes();
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
