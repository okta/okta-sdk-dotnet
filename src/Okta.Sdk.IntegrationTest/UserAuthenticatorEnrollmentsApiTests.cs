using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    [Collection(nameof(UserAuthenticatorEnrollmentsApiTests))]
    public class UserAuthenticatorEnrollmentsApiTests : IDisposable
    {
        private readonly UserAuthenticatorEnrollmentsApi _userAuthenticatorEnrollmentsApi = new();
        private readonly UserApi _userApi = new();
        private readonly AuthenticatorApi _authenticatorApi = new();
        private readonly List<string> _createdUserIds = [];
        private readonly List<(string userId, string enrollmentId)> _createdEnrollments = [];

        public void Dispose()
        {
            CleanupResources().GetAwaiter().GetResult();
        }

        private async Task CleanupResources()
        {
            foreach (var (userId, enrollmentId) in _createdEnrollments)
            {
                try
                {
                    await _userAuthenticatorEnrollmentsApi.DeleteAuthenticatorEnrollmentAsync(userId, enrollmentId);
                }
                catch (ApiException) { }
            }
            _createdEnrollments.Clear();

            foreach (var userId in _createdUserIds)
            {
                try
                {
                    await _userApi.DeleteUserAsync(userId);
                    await _userApi.DeleteUserAsync(userId);
                }
                catch (ApiException) { }
            }
            _createdUserIds.Clear();
        }

        [Fact]
        public async Task UserAuthenticatorEnrollmentsApi_CompleteCrudLifecycle_ShouldCoverAllEndpointsAndMethods()
        {
            var guid = Guid.NewGuid();
            string phoneAuthenticatorId = null;
            string tacAuthenticatorId = null;

            // Create test user
            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "AuthEnroll",
                    LastName = $"Test{guid.ToString().Substring(0, 8)}",
                    Email = $"auth-enroll-{guid}@example.com",
                    Login = $"auth-enroll-{guid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "ComplexP@ssw0rd!2024" }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest, activate: true);
            _createdUserIds.Add(createdUser.Id);
            var userId = createdUser.Id;

            createdUser.Should().NotBeNull();
            createdUser.Id.Should().NotBeNullOrEmpty();

            // Get authenticator IDs for setup
            try
            {
                var authenticatorsCollection = _authenticatorApi.ListAuthenticators();
                var authenticators = await authenticatorsCollection.ToListAsync();

                phoneAuthenticatorId = authenticators
                    .FirstOrDefault(a => a.Type == AuthenticatorType.Phone || a.Key == "phone_number")?.Id;
                
                tacAuthenticatorId = authenticators
                    .FirstOrDefault(a => a.Key == "okta_temporary_access_codes" || a.Key == "tac")?.Id;
            }
            catch (ApiException){}

            // CreateAuthenticatorEnrollmentAsync
            string phoneEnrollmentId = null;
            
            if (!string.IsNullOrEmpty(phoneAuthenticatorId))
            {
                try
                {
                    var phoneEnrollmentRequest = new AuthenticatorEnrollmentCreateRequest
                    {
                        AuthenticatorId = phoneAuthenticatorId,
                        Profile = new AuthenticatorProfile { PhoneNumber = "+12065551234" }
                    };

                    var phoneEnrollment = await _userAuthenticatorEnrollmentsApi
                        .CreateAuthenticatorEnrollmentAsync(userId, phoneEnrollmentRequest);

                    phoneEnrollment.Should().NotBeNull();
                    phoneEnrollment.Id.Should().NotBeNullOrEmpty();
                    phoneEnrollment.Type.Should().Be("phone");
                    phoneEnrollment.Key.Should().Be("phone_number");
                    phoneEnrollment.Status.Should().Be("ACTIVE");
                    phoneEnrollment.Name.Should().NotBeNullOrEmpty();
                    phoneEnrollment.Created.Should().BeBefore(DateTimeOffset.UtcNow.AddMinutes(1));
                    phoneEnrollment.LastUpdated.Should().BeBefore(DateTimeOffset.UtcNow.AddMinutes(1));
                    phoneEnrollment.Profile.Should().NotBeNull();
                    phoneEnrollment.Profile.PhoneNumber.Should().NotBeNullOrEmpty();
                    
                    phoneEnrollmentId = phoneEnrollment.Id;
                    _createdEnrollments.Add((userId, phoneEnrollmentId));
                }
                catch (ApiException ex) when (ex.ErrorCode == 400 || ex.ErrorCode == 403 || ex.ErrorCode == 404){}
            }

            // CreateTacAuthenticatorEnrollmentAsync
            string tacEnrollmentId = null;
            
            if (!string.IsNullOrEmpty(tacAuthenticatorId))
            {
                try
                {
                    var tacEnrollmentRequest = new AuthenticatorEnrollmentCreateRequestTac
                    {
                        AuthenticatorId = tacAuthenticatorId,
                        Profile = new AuthenticatorProfileTacRequest
                        {
                            Ttl = "60",
                            MultiUse = false
                        }
                    };

                    var tacEnrollment = await _userAuthenticatorEnrollmentsApi
                        .CreateTacAuthenticatorEnrollmentAsync(userId, tacEnrollmentRequest);

                    tacEnrollment.Should().NotBeNull();
                    tacEnrollment.Id.Should().NotBeNullOrEmpty();
                    tacEnrollment.Type.Should().Be("tac");
                    tacEnrollment.Key.Should().Be("tac");
                    tacEnrollment.Status.Should().Be("ACTIVE");
                    tacEnrollment.Name.Should().NotBeNullOrEmpty();
                    tacEnrollment.Created.Should().BeBefore(DateTimeOffset.UtcNow.AddMinutes(1));
                    tacEnrollment.LastUpdated.Should().BeBefore(DateTimeOffset.UtcNow.AddMinutes(1));
                    tacEnrollment.Profile.Should().NotBeNull();
                    tacEnrollment.Profile.Tac.Should().NotBeNullOrEmpty();
                    tacEnrollment.Profile.ExpiresAt.Should().BeAfter(DateTimeOffset.UtcNow);
                    tacEnrollment.Profile.MultiUse.Should().BeFalse();
                    
                    tacEnrollmentId = tacEnrollment.Id;
                    _createdEnrollments.Add((userId, tacEnrollmentId));
                }
                catch (ApiException ex) when (ex.ErrorCode == 400 || ex.ErrorCode == 403 || ex.ErrorCode == 404) { }
            }

            // ListAuthenticatorEnrollmentsAsync
            try
            {
                var enrollmentsList = await _userAuthenticatorEnrollmentsApi
                    .ListAuthenticatorEnrollmentsAsync(userId);

                if (enrollmentsList != null)
                {
                    enrollmentsList.Should().BeAssignableTo<AuthenticatorEnrollment>();
                    enrollmentsList.Id.Should().NotBeNullOrEmpty();
                    enrollmentsList.Status.Should().NotBeNullOrEmpty();
                }
            }
            catch (ApiException ex)
            {
                throw new Exception($"ListAuthenticatorEnrollmentsAsync failed: {ex.Message}", ex);
            }

            // GetAuthenticatorEnrollmentAsync
            var enrollmentIdToTest = phoneEnrollmentId ?? tacEnrollmentId;
            
            if (!string.IsNullOrEmpty(enrollmentIdToTest))
            {
                var retrievedEnrollment = await _userAuthenticatorEnrollmentsApi
                    .GetAuthenticatorEnrollmentAsync(userId, enrollmentIdToTest);

                retrievedEnrollment.Should().NotBeNull();
                retrievedEnrollment.Id.Should().Be(enrollmentIdToTest);
                retrievedEnrollment.Type.Should().NotBeNull();
                retrievedEnrollment.Key.Should().NotBeNullOrEmpty();
                retrievedEnrollment.Status.Should().Be("ACTIVE");
                retrievedEnrollment.Name.Should().NotBeNullOrEmpty();
                retrievedEnrollment.Created.Should().BeBefore(DateTimeOffset.UtcNow.AddMinutes(1));
                retrievedEnrollment.LastUpdated.Should().BeBefore(DateTimeOffset.UtcNow.AddMinutes(1));
                retrievedEnrollment.Profile.Should().NotBeNull();
                
                if (retrievedEnrollment.Type == AuthenticatorType.Phone)
                {
                    retrievedEnrollment.Profile.PhoneNumber.Should().NotBeNullOrEmpty();
                }
            }

            // DeleteAuthenticatorEnrollmentAsync
            if (!string.IsNullOrEmpty(phoneEnrollmentId))
            {
                await _userAuthenticatorEnrollmentsApi.DeleteAuthenticatorEnrollmentAsync(userId, phoneEnrollmentId);

                var getDeleted = async () => await _userAuthenticatorEnrollmentsApi
                    .GetAuthenticatorEnrollmentAsync(userId, phoneEnrollmentId);
                
                await getDeleted.Should().ThrowAsync<ApiException>()
                    .Where(ex => ex.ErrorCode == 404);
            }

            _createdEnrollments.Clear();
        }

        [Fact]
        public async Task UserAuthenticatorEnrollmentsApi_WithHttpInfo_ShouldReturnHttpMetadata()
        {
            var guid = Guid.NewGuid();
            string phoneAuthenticatorId = null;
            string tacAuthenticatorId = null;

            // Create test user
            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "AuthEnrollHttpInfo",
                    LastName = $"Test{guid.ToString().Substring(0, 8)}",
                    Email = $"auth-enroll-http-info-{guid}@example.com",
                    Login = $"auth-enroll-http-info-{guid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "ComplexP@ssw0rd!2024" }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest, activate: true);
            _createdUserIds.Add(createdUser.Id);
            var userId = createdUser.Id;

            // Get authenticator IDs for setup
            try
            {
                var authenticatorsCollection = _authenticatorApi.ListAuthenticators();
                var authenticators = await authenticatorsCollection.ToListAsync();

                phoneAuthenticatorId = authenticators
                    .FirstOrDefault(a => a.Type == AuthenticatorType.Phone || a.Key == "phone_number")?.Id;
                
                tacAuthenticatorId = authenticators
                    .FirstOrDefault(a => a.Key == "okta_temporary_access_codes" || a.Key == "tac")?.Id;
            }
            catch (ApiException){}

            // CreateAuthenticatorEnrollmentWithHttpInfoAsync - Phone enrollment with HTTP metadata
            string phoneEnrollmentId = null;
            
            if (!string.IsNullOrEmpty(phoneAuthenticatorId))
            {
                try
                {
                    var phoneEnrollmentRequest = new AuthenticatorEnrollmentCreateRequest
                    {
                        AuthenticatorId = phoneAuthenticatorId,
                        Profile = new AuthenticatorProfile { PhoneNumber = "+12065559999" }
                    };

                    var phoneEnrollmentResponse = await _userAuthenticatorEnrollmentsApi
                        .CreateAuthenticatorEnrollmentWithHttpInfoAsync(userId, phoneEnrollmentRequest);

                    phoneEnrollmentResponse.Should().NotBeNull();
                    phoneEnrollmentResponse.StatusCode.Should().BeOneOf(
                        System.Net.HttpStatusCode.OK, 
                        System.Net.HttpStatusCode.Created
                    );
                    phoneEnrollmentResponse.Data.Should().NotBeNull();
                    phoneEnrollmentResponse.Data.Id.Should().NotBeNullOrEmpty();
                    phoneEnrollmentResponse.Data.Type.Should().Be("phone");
                    phoneEnrollmentResponse.Data.Status.Should().Be("ACTIVE");
                    phoneEnrollmentResponse.Data.Profile.Should().NotBeNull();
                    phoneEnrollmentResponse.Data.Profile.PhoneNumber.Should().NotBeNullOrEmpty();
                    phoneEnrollmentResponse.Headers.Should().NotBeNull();
                    phoneEnrollmentResponse.Headers.Should().ContainKey("Content-Type");
                    
                    if (!string.IsNullOrEmpty(phoneEnrollmentResponse.Data.Id))
                    {
                        phoneEnrollmentId = phoneEnrollmentResponse.Data.Id;
                        _createdEnrollments.Add((userId, phoneEnrollmentId));
                    }
                }
                catch (ApiException ex) when (ex.ErrorCode == 400 || ex.ErrorCode == 403 || ex.ErrorCode == 404){}
            }

            // CreateTacAuthenticatorEnrollmentWithHttpInfoAsync - TAC enrollment with HTTP metadata
            string tacEnrollmentId = null;
            
            if (!string.IsNullOrEmpty(tacAuthenticatorId))
            {
                try
                {
                    var tacEnrollmentRequest = new AuthenticatorEnrollmentCreateRequestTac
                    {
                        AuthenticatorId = tacAuthenticatorId,
                        Profile = new AuthenticatorProfileTacRequest
                        {
                            Ttl = "120",
                            MultiUse = true
                        }
                    };

                    var tacEnrollmentResponse = await _userAuthenticatorEnrollmentsApi
                        .CreateTacAuthenticatorEnrollmentWithHttpInfoAsync(userId, tacEnrollmentRequest);

                    tacEnrollmentResponse.Should().NotBeNull();
                    tacEnrollmentResponse.StatusCode.Should().BeOneOf(
                        System.Net.HttpStatusCode.OK, 
                        System.Net.HttpStatusCode.Created
                    );
                    tacEnrollmentResponse.Data.Should().NotBeNull();
                    tacEnrollmentResponse.Data.Id.Should().NotBeNullOrEmpty();
                    tacEnrollmentResponse.Data.Type.Should().Be("tac");
                    tacEnrollmentResponse.Data.Status.Should().Be("ACTIVE");
                    tacEnrollmentResponse.Data.Profile.Should().NotBeNull();
                    tacEnrollmentResponse.Data.Profile.Tac.Should().NotBeNullOrEmpty();
                    tacEnrollmentResponse.Data.Profile.MultiUse.Should().BeTrue();
                    tacEnrollmentResponse.Headers.Should().NotBeNull();
                    tacEnrollmentResponse.Headers.Should().ContainKey("Content-Type");
                    
                    if (!string.IsNullOrEmpty(tacEnrollmentResponse.Data.Id))
                    {
                        tacEnrollmentId = tacEnrollmentResponse.Data.Id;
                        _createdEnrollments.Add((userId, tacEnrollmentId));
                    }
                }
                catch (ApiException ex) when (ex.ErrorCode == 400 || ex.ErrorCode == 403 || ex.ErrorCode == 404) { }
            }

            // ListAuthenticatorEnrollmentsWithHttpInfoAsync - List with HTTP metadata
            var enrollmentsResponse = await _userAuthenticatorEnrollmentsApi
                .ListAuthenticatorEnrollmentsWithHttpInfoAsync(userId);

            enrollmentsResponse.Should().NotBeNull();
            enrollmentsResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            enrollmentsResponse.Headers.Should().NotBeNull();
            enrollmentsResponse.Headers.Should().ContainKey("Content-Type");
            enrollmentsResponse.Data?.Should().BeAssignableTo<AuthenticatorEnrollment>();

            // GetAuthenticatorEnrollmentWithHttpInfoAsync - Get specific enrollment with HTTP metadata
            var enrollmentIdToTest = phoneEnrollmentId ?? tacEnrollmentId;
            
            if (!string.IsNullOrEmpty(enrollmentIdToTest))
            {
                var retrievedEnrollmentResponse = await _userAuthenticatorEnrollmentsApi
                    .GetAuthenticatorEnrollmentWithHttpInfoAsync(userId, enrollmentIdToTest);

                retrievedEnrollmentResponse.Should().NotBeNull();
                retrievedEnrollmentResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
                retrievedEnrollmentResponse.Headers.Should().NotBeNull();
                retrievedEnrollmentResponse.Headers.Should().ContainKey("Content-Type");
                retrievedEnrollmentResponse.Data.Should().NotBeNull();
                retrievedEnrollmentResponse.Data.Id.Should().Be(enrollmentIdToTest);
                retrievedEnrollmentResponse.Data.Type.Should().NotBeNull();
                retrievedEnrollmentResponse.Data.Status.Should().Be("ACTIVE");
                retrievedEnrollmentResponse.Data.Profile.Should().NotBeNull();
            }

            // DeleteAuthenticatorEnrollmentWithHttpInfoAsync - Delete with HTTP metadata
            if (!string.IsNullOrEmpty(tacEnrollmentId))
            {
                var deleteResponse = await _userAuthenticatorEnrollmentsApi
                    .DeleteAuthenticatorEnrollmentWithHttpInfoAsync(userId, tacEnrollmentId);

                deleteResponse.Should().NotBeNull();
                deleteResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
                deleteResponse.Headers.Should().NotBeNull();

                var getDeleted = async () => await _userAuthenticatorEnrollmentsApi
                    .GetAuthenticatorEnrollmentAsync(userId, tacEnrollmentId);
                
                await getDeleted.Should().ThrowAsync<ApiException>()
                    .Where(ex => ex.ErrorCode == 404);
            }

            _createdEnrollments.Clear();
        }

        /// <summary>
        /// Tests error scenarios with invalid inputs for all methods.
        /// </summary>
        [Fact]
        public async Task UserAuthenticatorEnrollmentsApi_ErrorScenarios_ShouldThrowApiException()
        {
            const string invalidUserId = "invalid_user_id_12345";
            const string invalidEnrollmentId = "invalid_enrollment_id_12345";
            const string invalidAuthenticatorId = "invalid_authenticator_id_12345";

            // ListAuthenticatorEnrollmentsAsync with invalid userId - should throw 404
            var listException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userAuthenticatorEnrollmentsApi.ListAuthenticatorEnrollmentsAsync(invalidUserId);
            });
            listException.ErrorCode.Should().Be(404);

            // GetAuthenticatorEnrollmentAsync with invalid userId - should throw 404
            var getException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userAuthenticatorEnrollmentsApi.GetAuthenticatorEnrollmentAsync(invalidUserId, invalidEnrollmentId);
            });
            getException.ErrorCode.Should().Be(404);

            // CreateAuthenticatorEnrollmentAsync with invalid userId - should throw 404
            var createRequest = new AuthenticatorEnrollmentCreateRequest
            {
                AuthenticatorId = invalidAuthenticatorId,
                Profile = new AuthenticatorProfile { PhoneNumber = "+12065551234" }
            };

            var createException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userAuthenticatorEnrollmentsApi.CreateAuthenticatorEnrollmentAsync(invalidUserId, createRequest);
            });
            createException.ErrorCode.Should().Be(404);

            // CreateTacAuthenticatorEnrollmentAsync with invalid userId - should throw 404
            var tacCreateRequest = new AuthenticatorEnrollmentCreateRequestTac
            {
                AuthenticatorId = invalidAuthenticatorId,
                Profile = new AuthenticatorProfileTacRequest { Ttl = "60", MultiUse = false }
            };

            var tacCreateException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userAuthenticatorEnrollmentsApi.CreateTacAuthenticatorEnrollmentAsync(invalidUserId, tacCreateRequest);
            });
            tacCreateException.ErrorCode.Should().Be(404);

            // DeleteAuthenticatorEnrollmentAsync with invalid userId - should throw 404
            var deleteException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userAuthenticatorEnrollmentsApi.DeleteAuthenticatorEnrollmentAsync(invalidUserId, invalidEnrollmentId);
            });
            deleteException.ErrorCode.Should().Be(404);

            // ListAuthenticatorEnrollmentsWithHttpInfoAsync with invalid userId - should throw 404
            var listHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userAuthenticatorEnrollmentsApi.ListAuthenticatorEnrollmentsWithHttpInfoAsync(invalidUserId);
            });
            listHttpInfoException.ErrorCode.Should().Be(404);

            // GetAuthenticatorEnrollmentWithHttpInfoAsync with invalid userId - should throw 404
            var getHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userAuthenticatorEnrollmentsApi.GetAuthenticatorEnrollmentWithHttpInfoAsync(invalidUserId, invalidEnrollmentId);
            });
            getHttpInfoException.ErrorCode.Should().Be(404);

            // CreateAuthenticatorEnrollmentWithHttpInfoAsync with invalid userId - should throw 404
            var createHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userAuthenticatorEnrollmentsApi.CreateAuthenticatorEnrollmentWithHttpInfoAsync(invalidUserId, createRequest);
            });
            createHttpInfoException.ErrorCode.Should().Be(404);

            // CreateTacAuthenticatorEnrollmentWithHttpInfoAsync with invalid userId - should throw 404
            var tacCreateHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userAuthenticatorEnrollmentsApi.CreateTacAuthenticatorEnrollmentWithHttpInfoAsync(invalidUserId, tacCreateRequest);
            });
            tacCreateHttpInfoException.ErrorCode.Should().Be(404);

            // DeleteAuthenticatorEnrollmentWithHttpInfoAsync with invalid userId - should throw 404
            var deleteHttpInfoException = await Assert.ThrowsAsync<ApiException>(async () =>
            {
                await _userAuthenticatorEnrollmentsApi.DeleteAuthenticatorEnrollmentWithHttpInfoAsync(invalidUserId, invalidEnrollmentId);
            });
            deleteHttpInfoException.ErrorCode.Should().Be(404);
        }
    }
}
