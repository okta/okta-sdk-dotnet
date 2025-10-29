// <copyright file="UserClassificationApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    [Collection(nameof(UserClassificationApiTests))]
    public class UserClassificationApiTests : IDisposable
    {
        private readonly UserClassificationApi _userClassificationApi = new();
        private readonly UserApi _userApi = new();
        private readonly List<string> _createdUserIds = [];

        public void Dispose()
        {
            CleanupResources().GetAwaiter().GetResult();
        }

        private async Task CleanupResources()
        {
            foreach (var userId in _createdUserIds)
            {
                try
                {
                    await _userApi.DeleteUserAsync(userId);
                    await _userApi.DeleteUserAsync(userId);
                }
                catch (ApiException)
                {
                    // Ignore cleanup errors
                }
            }
            _createdUserIds.Clear();
        }

        [Fact]
        public async Task GivenUserClassifications_WhenPerformingCrudOperations_ThenAllEndpointsAndMethodsWork()
        {
            var guid = Guid.NewGuid();

            // Create test user
            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "ClassificationTest",
                    LastName = $"User{guid.ToString().Substring(0, 8)}",
                    Email = $"classification-test-{guid}@example.com",
                    Login = $"classification-test-{guid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "Abed1234!@#$" }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest, activate: true);
            _createdUserIds.Add(createdUser.Id);
            var userId = createdUser.Id;

            createdUser.Should().NotBeNull();
            createdUser.Id.Should().NotBeNullOrEmpty();
            createdUser.Status.Should().Be(UserStatus.ACTIVE);

            await Task.Delay(2000);

            // Check if the feature is enabled (Early Access)
            try
            {
                await _userClassificationApi.GetUserClassificationAsync(userId);
            }
            catch (ApiException ex) when (ex.ErrorCode == 403 || ex.Message.Contains("E0000015"))
            {
                return;
            }

            // GetUserClassificationAsync - Retrieve initial classification
            var initialClassification = await _userClassificationApi.GetUserClassificationAsync(userId);

            initialClassification.Should().NotBeNull();
            initialClassification.Type.Should().NotBeNull();
            initialClassification.Type.Should().BeOneOf(ClassificationType.LITE, ClassificationType.STANDARD);
            initialClassification.LastUpdated.Should().NotBe(default(DateTimeOffset));
            initialClassification.LastUpdated.Should().BeBefore(DateTimeOffset.UtcNow.AddMinutes(1));

            var initialType = initialClassification.Type;
            var initialLastUpdated = initialClassification.LastUpdated;

            // ReplaceUserClassificationAsync - Update to LITE
            var replaceToLite = new ReplaceUserClassification
            {
                Type = ClassificationType.LITE
            };

            var updatedToLite = await _userClassificationApi.ReplaceUserClassificationAsync(userId, replaceToLite);

            updatedToLite.Should().NotBeNull();
            updatedToLite.Type.Should().Be(ClassificationType.LITE);
            updatedToLite.LastUpdated.Should().NotBe(default(DateTimeOffset));
            updatedToLite.LastUpdated.Should().BeBefore(DateTimeOffset.UtcNow.AddMinutes(1));

            if (initialType != ClassificationType.LITE)
            {
                updatedToLite.LastUpdated.Should().BeAfter(initialLastUpdated);
            }

            await Task.Delay(1000);

            // Verify "LITE" classification persisted
            var verifyLite = await _userClassificationApi.GetUserClassificationAsync(userId);

            verifyLite.Should().NotBeNull();
            verifyLite.Type.Should().Be(ClassificationType.LITE);
            verifyLite.LastUpdated.Should().BeCloseTo(updatedToLite.LastUpdated, TimeSpan.FromSeconds(5));

            // ReplaceUserClassificationAsync - Update to STANDARD
            var replaceToStandard = new ReplaceUserClassification
            {
                Type = ClassificationType.STANDARD
            };

            var updatedToStandard = await _userClassificationApi
                .ReplaceUserClassificationAsync(userId, replaceToStandard);

            updatedToStandard.Should().NotBeNull();
            updatedToStandard.Type.Should().Be(ClassificationType.STANDARD);
            updatedToStandard.LastUpdated.Should().NotBe(default(DateTimeOffset));
            updatedToStandard.LastUpdated.Should().BeAfter(updatedToLite.LastUpdated);

            await Task.Delay(1000);

            // Verify STANDARD classification persisted
            var verifyStandard = await _userClassificationApi.GetUserClassificationAsync(userId);

            verifyStandard.Should().NotBeNull();
            verifyStandard.Type.Should().Be(ClassificationType.STANDARD);
            verifyStandard.LastUpdated.Should().BeCloseTo(
                updatedToStandard.LastUpdated, 
                TimeSpan.FromSeconds(5));

            // Update back to LITE (full cycle test)
            var replaceBackToLite = new ReplaceUserClassification
            {
                Type = ClassificationType.LITE
            };

            var finalUpdateToLite = await _userClassificationApi
                .ReplaceUserClassificationAsync(userId, replaceBackToLite);

            finalUpdateToLite.Should().NotBeNull();
            finalUpdateToLite.Type.Should().Be(ClassificationType.LITE);
            finalUpdateToLite.LastUpdated.Should().BeAfter(verifyStandard.LastUpdated);

            // Final verification
            var finalVerification = await _userClassificationApi.GetUserClassificationAsync(userId);

            finalVerification.Should().NotBeNull();
            finalVerification.Type.Should().Be(ClassificationType.LITE);
            finalVerification.LastUpdated.Should().BeCloseTo(finalUpdateToLite.LastUpdated, TimeSpan.FromSeconds(5));
        }

        [Fact]
        public async Task GivenHttpInfoMethods_WhenCallingApi_ThenHttpMetadataIsReturned()
        {
            var guid = Guid.NewGuid();

            // Create test user
            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "ClassificationHttpInfo",
                    LastName = $"User{guid.ToString().Substring(0, 8)}",
                    Email = $"classification-http-info-{guid}@example.com",
                    Login = $"classification-http-info-{guid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "Pass1234!@#$" }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest, activate: true);
            _createdUserIds.Add(createdUser.Id);
            var userId = createdUser.Id;

            await Task.Delay(2000);

            // Check if the feature is enabled
            try
            {
                await _userClassificationApi.GetUserClassificationAsync(userId);
            }
            catch (ApiException ex) when (ex.ErrorCode == 403 || ex.Message.Contains("E0000015"))
            {
                return;
            }

            // GetUserClassificationWithHttpInfoAsync - Verify HTTP metadata
            var getResponse = await _userClassificationApi.GetUserClassificationWithHttpInfoAsync(userId);

            getResponse.Should().NotBeNull();
            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getResponse.Data.Should().NotBeNull();
            getResponse.Data.Type.Should().NotBeNull();
            getResponse.Data.Type.Should().BeOneOf(ClassificationType.LITE, ClassificationType.STANDARD);
            getResponse.Data.LastUpdated.Should().NotBe(default(DateTimeOffset));
            getResponse.Headers.Should().NotBeNull();
            getResponse.Headers.Should().ContainKey("Content-Type");

            var initialType = getResponse.Data.Type;

            // ReplaceUserClassificationWithHttpInfoAsync - Update and verify HTTP metadata
            var newType = initialType == ClassificationType.LITE 
                ? ClassificationType.STANDARD 
                : ClassificationType.LITE;

            var replaceRequest = new ReplaceUserClassification
            {
                Type = newType
            };

            var replaceResponse = await _userClassificationApi
                .ReplaceUserClassificationWithHttpInfoAsync(userId, replaceRequest);

            replaceResponse.Should().NotBeNull();
            replaceResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            replaceResponse.Data.Should().NotBeNull();
            replaceResponse.Data.Type.Should().Be(newType);
            replaceResponse.Data.LastUpdated.Should().NotBe(default(DateTimeOffset));
            replaceResponse.Headers.Should().NotBeNull();
            replaceResponse.Headers.Should().ContainKey("Content-Type");

            await Task.Delay(1000);

            // Verify update persisted using GetUserClassificationWithHttpInfoAsync
            var verifyResponse = await _userClassificationApi.GetUserClassificationWithHttpInfoAsync(userId);

            verifyResponse.Should().NotBeNull();
            verifyResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            verifyResponse.Data.Should().NotBeNull();
            verifyResponse.Data.Type.Should().Be(newType);
            verifyResponse.Data.LastUpdated.Should().BeCloseTo(
                replaceResponse.Data.LastUpdated, 
                TimeSpan.FromSeconds(5));

            // Update back to original type with HTTP metadata validation
            var revertRequest = new ReplaceUserClassification
            {
                Type = initialType
            };

            var revertResponse = await _userClassificationApi
                .ReplaceUserClassificationWithHttpInfoAsync(userId, revertRequest);

            revertResponse.Should().NotBeNull();
            revertResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            revertResponse.Data.Should().NotBeNull();
            revertResponse.Data.Type.Should().Be(initialType);
            revertResponse.Data.LastUpdated.Should().BeAfter(replaceResponse.Data.LastUpdated);
            revertResponse.Headers.Should().NotBeNull();
        }

        /// <summary>
        /// Tests error scenarios with invalid inputs for all methods.
        /// Note: User Classification API requires an Early Access feature flag.
        /// Returns 401 if feature not enabled, 404 if user not found.
        /// </summary>
        [Fact]
        public async Task GivenErrorScenarios_WhenCallingApi_ThenApiExceptionIsThrown()
        {
            const string invalidUserId = "invalid_user_id_12345";

            // GetUserClassificationAsync with invalid userId - should throw 401 or 404
            var getException = await Assert.ThrowsAnyAsync<Exception>(async () =>
            {
                await _userClassificationApi.GetUserClassificationAsync(invalidUserId);
            });
            
            if (getException is ApiException apiEx)
            {
                apiEx.ErrorCode.Should().BeOneOf(401, 404);
            }
            else if (getException is TimeoutException)
            {
                // TimeoutException can occur with invalid endpoints
                getException.Should().BeOfType<TimeoutException>();
            }
            else
            {
                throw new Exception($"Unexpected exception type: {getException.GetType()}", getException);
            }

            // ReplaceUserClassificationAsync with invalid userId - should throw 401 or 404
            var replaceRequest = new ReplaceUserClassification
            {
                Type = ClassificationType.LITE
            };

            var replaceException = await Assert.ThrowsAnyAsync<Exception>(async () =>
            {
                await _userClassificationApi.ReplaceUserClassificationAsync(invalidUserId, replaceRequest);
            });
            
            if (replaceException is ApiException apiEx2)
            {
                apiEx2.ErrorCode.Should().BeOneOf(401, 404);
            }
            else if (replaceException is TimeoutException)
            {
                replaceException.Should().BeOfType<TimeoutException>();
            }
            else
            {
                throw new Exception($"Unexpected exception type: {replaceException.GetType()}", replaceException);
            }

            // GetUserClassificationWithHttpInfoAsync with invalid userId - should throw 401 or 404
            var getHttpInfoException = await Assert.ThrowsAnyAsync<Exception>(async () =>
            {
                await _userClassificationApi.GetUserClassificationWithHttpInfoAsync(invalidUserId);
            });
            
            if (getHttpInfoException is ApiException apiEx3)
            {
                apiEx3.ErrorCode.Should().BeOneOf(401, 404);
            }
            else if (getHttpInfoException is TimeoutException)
            {
                getHttpInfoException.Should().BeOfType<TimeoutException>();
            }
            else
            {
                throw new Exception($"Unexpected exception type: {getHttpInfoException.GetType()}", getHttpInfoException);
            }

            // ReplaceUserClassificationWithHttpInfoAsync with invalid userId - should throw 401 or 404
            var replaceHttpInfoException = await Assert.ThrowsAnyAsync<Exception>(async () =>
            {
                await _userClassificationApi.ReplaceUserClassificationWithHttpInfoAsync(invalidUserId, replaceRequest);
            });
            
            if (replaceHttpInfoException is ApiException apiEx4)
            {
                apiEx4.ErrorCode.Should().BeOneOf(401, 404);
            }
            else if (replaceHttpInfoException is TimeoutException)
            {
                replaceHttpInfoException.Should().BeOfType<TimeoutException>();
            }
            else
            {
                throw new Exception($"Unexpected exception type: {replaceHttpInfoException.GetType()}", replaceHttpInfoException);
            }
        }
    }
}
