// <copyright file="UserTypeApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    [Collection(nameof(UserTypeApiTests))]
    public class UserTypeApiTests : IDisposable
    {
        private readonly UserTypeApi _userTypeApi = new();
        private readonly List<string> _createdUserTypeIds = [];
        private const string TestTypePrefix = "test_type_";

        public UserTypeApiTests()
        {
            // Clean up any leftover test user types from previous runs
            CleanupLeftoverTestUserTypes().GetAwaiter().GetResult();
        }

        public void Dispose()
        {
            CleanupResources().GetAwaiter().GetResult();
        }

        private async Task CleanupLeftoverTestUserTypes()
        {
            try
            {
                var allUserTypes = await _userTypeApi.ListUserTypes().ToListAsync();
                foreach (var userType in allUserTypes)
                {
                    if (userType.Name?.StartsWith(TestTypePrefix) == true && userType.Default != true)
                    {
                        try
                        {
                            await _userTypeApi.DeleteUserTypeAsync(userType.Id);
                        }
                        catch (ApiException)
                        {
                            // Ignore cleanup errors - a user type may be in use
                        }
                    }
                }
            }
            catch (ApiException)
            {
                // Ignore errors during cleanup discovery
            }
        }

        private async Task CleanupResources()
        {
            foreach (var typeId in _createdUserTypeIds)
            {
                try
                {
                    await _userTypeApi.DeleteUserTypeAsync(typeId);
                }
                catch (ApiException)
                {
                    // Ignore cleanup errors
                }
            }
            _createdUserTypeIds.Clear();
        }

        [Fact]
        public async Task GivenUserTypes_WhenPerformingCrudOperations_ThenAllEndpointsAndMethodsWork()
        {
            var guid = Guid.NewGuid();
            var userTypeName = $"test_type_{guid.ToString().Replace("-", "").Substring(0, 15)}";

            // CreateUserTypeAsync - Create a new user type
            var createRequest = new UserType
            {
                Name = userTypeName,
                DisplayName = "Test User Type",
                Description = "Integration test user type"
            };

            var createdUserType = await _userTypeApi.CreateUserTypeAsync(createRequest);
            _createdUserTypeIds.Add(createdUserType.Id);

            createdUserType.Should().NotBeNull();
            createdUserType.Id.Should().NotBeNullOrEmpty();
            createdUserType.Name.Should().Be(userTypeName);
            createdUserType.DisplayName.Should().Be("Test User Type");
            createdUserType.Description.Should().Be("Integration test user type");
            createdUserType.Default.Should().BeFalse();
            createdUserType.Created.Should().BeBefore(DateTimeOffset.UtcNow.AddMinutes(1));
            createdUserType.LastUpdated.Should().BeBefore(DateTimeOffset.UtcNow.AddMinutes(1));

            await Task.Delay(1000);

            // ListUserTypes - List all user types
            var userTypes = await _userTypeApi.ListUserTypes().ToListAsync();

            userTypes.Should().NotBeNull();
            userTypes.Should().NotBeEmpty();
            userTypes.Should().Contain(ut => ut.Id == createdUserType.Id);
            userTypes.Should().Contain(ut => ut.Default == true, "Should include default user type");

            // GetUserTypeAsync - Retrieve a specific user type
            var retrievedUserType = await _userTypeApi.GetUserTypeAsync(createdUserType.Id);

            retrievedUserType.Should().NotBeNull();
            retrievedUserType.Id.Should().Be(createdUserType.Id);
            retrievedUserType.Name.Should().Be(userTypeName);
            retrievedUserType.DisplayName.Should().Be("Test User Type");
            retrievedUserType.Description.Should().Be("Integration test user type");

            // GetUserTypeAsync with "default" - Retrieve default user type
            var defaultUserType = await _userTypeApi.GetUserTypeAsync("default");

            defaultUserType.Should().NotBeNull();
            defaultUserType.Default.Should().BeTrue();
            defaultUserType.Name.Should().Be("user");

            // UpdateUserTypeAsync - Partial update
            var updateRequest = new UserTypePostRequest
            {
                DisplayName = "Updated Display Name",
                Description = "Updated description"
            };

            var updatedUserType = await _userTypeApi.UpdateUserTypeAsync(createdUserType.Id, updateRequest);

            updatedUserType.Should().NotBeNull();
            updatedUserType.Id.Should().Be(createdUserType.Id);
            updatedUserType.Name.Should().Be(userTypeName, "Name should not change");
            updatedUserType.DisplayName.Should().Be("Updated Display Name");
            updatedUserType.Description.Should().Be("Updated description");
            updatedUserType.LastUpdated.Should().BeAfter(createdUserType.LastUpdated);

            await Task.Delay(1000);

            // ReplaceUserTypeAsync - Full update
            var replaceRequest = new UserTypePutRequest
            {
                Name = userTypeName, // Name must be included but can't be changed
                DisplayName = "Replaced Display Name",
                Description = "Replaced description"
            };

            var replacedUserType = await _userTypeApi.ReplaceUserTypeAsync(createdUserType.Id, replaceRequest);

            replacedUserType.Should().NotBeNull();
            replacedUserType.Id.Should().Be(createdUserType.Id);
            replacedUserType.Name.Should().Be(userTypeName, "Name should not change");
            replacedUserType.DisplayName.Should().Be("Replaced Display Name");
            replacedUserType.Description.Should().Be("Replaced description");
            replacedUserType.LastUpdated.Should().BeAfter(updatedUserType.LastUpdated);

            await Task.Delay(1000);

            // DeleteUserTypeAsync - Delete the user type
            await _userTypeApi.DeleteUserTypeAsync(createdUserType.Id);
            _createdUserTypeIds.Remove(createdUserType.Id);

            await Task.Delay(1000);

            // Verify deletion
            var deleteException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userTypeApi.GetUserTypeAsync(createdUserType.Id);
            });
            deleteException.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task GivenHttpInfoMethods_WhenCallingApi_ThenHttpMetadataIsReturned()
        {
            var guid = Guid.NewGuid();
            var userTypeName = $"test_type_{guid.ToString().Replace("-", "").Substring(0, 15)}";

            // TEST 1: CreateUserTypeWithHttpInfoAsync - Create with HTTP metadata
            var createRequest = new UserType
            {
                Name = userTypeName,
                DisplayName = "Test HttpInfo Type",
                Description = "Test description for HttpInfo"
            };

            var createResponse = await _userTypeApi.CreateUserTypeWithHttpInfoAsync(createRequest);
            _createdUserTypeIds.Add(createResponse.Data.Id);

            createResponse.Should().NotBeNull();
            createResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            createResponse.Data.Should().NotBeNull();
            createResponse.Data.Name.Should().Be(userTypeName);
            createResponse.Data.DisplayName.Should().Be("Test HttpInfo Type");
            createResponse.Headers.Should().NotBeNull();

            await Task.Delay(1000);

            // ListUserTypesWithHttpInfoAsync - List with HTTP metadata
            var listResponse = await _userTypeApi.ListUserTypesWithHttpInfoAsync();

            listResponse.Should().NotBeNull();
            listResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            listResponse.Data.Should().NotBeNull();
            listResponse.Data.Should().NotBeEmpty();
            listResponse.Data.Should().Contain(ut => ut.Id == createResponse.Data.Id);
            listResponse.Headers.Should().NotBeNull();

            // GetUserTypeWithHttpInfoAsync - Retrieve with HTTP metadata
            var getResponse = await _userTypeApi.GetUserTypeWithHttpInfoAsync(createResponse.Data.Id);

            getResponse.Should().NotBeNull();
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.Data.Should().NotBeNull();
            getResponse.Data.Id.Should().Be(createResponse.Data.Id);
            getResponse.Data.Name.Should().Be(userTypeName);
            getResponse.Headers.Should().NotBeNull();

            // UpdateUserTypeWithHttpInfoAsync - Partial update with HTTP metadata
            var updateRequest = new UserTypePostRequest
            {
                DisplayName = "HttpInfo Updated",
                Description = "HttpInfo updated description"
            };

            var updateResponse = await _userTypeApi.UpdateUserTypeWithHttpInfoAsync(
                createResponse.Data.Id,
                updateRequest
            );

            updateResponse.Should().NotBeNull();
            updateResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            updateResponse.Data.Should().NotBeNull();
            updateResponse.Data.DisplayName.Should().Be("HttpInfo Updated");
            updateResponse.Data.Description.Should().Be("HttpInfo updated description");
            updateResponse.Headers.Should().NotBeNull();

            await Task.Delay(1000);

            // ReplaceUserTypeWithHttpInfoAsync - Full update with HTTP metadata
            var replaceRequest = new UserTypePutRequest
            {
                Name = userTypeName,
                DisplayName = "HttpInfo Replaced",
                Description = "HttpInfo replaced description"
            };

            var replaceResponse = await _userTypeApi.ReplaceUserTypeWithHttpInfoAsync(
                createResponse.Data.Id,
                replaceRequest
            );

            replaceResponse.Should().NotBeNull();
            replaceResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            replaceResponse.Data.Should().NotBeNull();
            replaceResponse.Data.DisplayName.Should().Be("HttpInfo Replaced");
            replaceResponse.Data.Description.Should().Be("HttpInfo replaced description");
            replaceResponse.Headers.Should().NotBeNull();

            await Task.Delay(1000);

            // DeleteUserTypeWithHttpInfoAsync - Delete with HTTP metadata
            var deleteResponse = await _userTypeApi.DeleteUserTypeWithHttpInfoAsync(createResponse.Data.Id);
            _createdUserTypeIds.Remove(createResponse.Data.Id);

            deleteResponse.Should().NotBeNull();
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);
            deleteResponse.Headers.Should().NotBeNull();
        }

        [Fact]
        public async Task GivenErrorScenarios_WhenCallingApi_ThenApiExceptionIsThrown()
        {
            const string invalidTypeId = "invalid_type_id_12345";

            // GetUserTypeAsync with invalid typeId - should throw 404
            var getException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userTypeApi.GetUserTypeAsync(invalidTypeId);
            });
            getException.ErrorCode.Should().Be(404);

            // UpdateUserTypeAsync with invalid typeId - should throw 404
            var updateRequest = new UserTypePostRequest
            {
                DisplayName = "Invalid Update"
            };

            var updateException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userTypeApi.UpdateUserTypeAsync(invalidTypeId, updateRequest);
            });
            updateException.ErrorCode.Should().Be(404);

            // ReplaceUserTypeAsync with invalid typeId - should throw 404
            var replaceRequest = new UserTypePutRequest
            {
                Name = "invalid",
                DisplayName = "Invalid Replace",
                Description = "Invalid description"
            };

            var replaceException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userTypeApi.ReplaceUserTypeAsync(invalidTypeId, replaceRequest);
            });
            replaceException.ErrorCode.Should().Be(404);

            // DeleteUserTypeAsync with invalid typeId - should throw 404
            var deleteException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userTypeApi.DeleteUserTypeAsync(invalidTypeId);
            });
            deleteException.ErrorCode.Should().Be(404);

            // GetUserTypeWithHttpInfoAsync with invalid typeId - should throw 404
            var getHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userTypeApi.GetUserTypeWithHttpInfoAsync(invalidTypeId);
            });
            getHttpInfoException.ErrorCode.Should().Be(404);

            // UpdateUserTypeWithHttpInfoAsync with invalid typeId - should throw 404
            var updateHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userTypeApi.UpdateUserTypeWithHttpInfoAsync(invalidTypeId, updateRequest);
            });
            updateHttpInfoException.ErrorCode.Should().Be(404);

            // ReplaceUserTypeWithHttpInfoAsync with invalid typeId - should throw 404
            var replaceHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userTypeApi.ReplaceUserTypeWithHttpInfoAsync(invalidTypeId, replaceRequest);
            });
            replaceHttpInfoException.ErrorCode.Should().Be(404);

            // DeleteUserTypeWithHttpInfoAsync with invalid typeId - should throw 404
            var deleteHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userTypeApi.DeleteUserTypeWithHttpInfoAsync(invalidTypeId);
            });
            deleteHttpInfoException.ErrorCode.Should().Be(404);

            // CreateUserTypeAsync with duplicate name - should throw 400
            var guid = Guid.NewGuid();
            var userTypeName = $"test_type_{guid.ToString().Replace("-", "").Substring(0, 15)}";
            
            var firstType = new UserType
            {
                Name = userTypeName,
                DisplayName = "First Type",
                Description = "First description"
            };

            var created = await _userTypeApi.CreateUserTypeAsync(firstType);
            _createdUserTypeIds.Add(created.Id);

            await Task.Delay(1000);

            // Try to create another type with the same name
            var duplicateType = new UserType
            {
                Name = userTypeName,
                DisplayName = "Duplicate Type",
                Description = "Duplicate description"
            };

            var duplicateException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userTypeApi.CreateUserTypeAsync(duplicateType);
            });
            duplicateException.ErrorCode.Should().Be(400);
        }
    }
}
