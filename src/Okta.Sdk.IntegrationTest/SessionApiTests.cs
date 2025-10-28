using FluentAssertions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    /// <summary>
    /// Shared fixture for SessionApiTests - creates one test user for all tests
    /// </summary>
    public class SessionApiTestFixture : IAsyncLifetime
    {
        private readonly UserApi _userApi = new();
        private readonly Configuration _configuration = Configuration.GetConfigurationOrDefault();
        private readonly HttpClient _httpClient = new();

        public string TestUserId { get; private set; }
        public string TestUserEmail { get; private set; }
        public static string TestUserPassword => "ComplexP@ssw0rd!2024";

        public async Task InitializeAsync()
        {
            // Create a single test user for all tests
            var guid = Guid.NewGuid();
            TestUserEmail = $"test-session-{guid}@example.com";

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "SessionTest",
                    LastName = "User",
                    Email = TestUserEmail,
                    Login = TestUserEmail
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential
                    {
                        Value = TestUserPassword
                    }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(createUserRequest, activate: true);
            TestUserId = createdUser.Id;
        }

        public async Task<string> GetSessionTokenAsync()
        {
            var authEndpoint = $"{_configuration.OktaDomain}/api/v1/authn";
            var authPayload = new
            {
                username = TestUserEmail,
                password = TestUserPassword
            };

            var jsonPayload = JsonSerializer.Serialize(authPayload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(authEndpoint, content);
            
            response.EnsureSuccessStatusCode();
            
            var responseContent = await response.Content.ReadAsStringAsync();
            using var jsonDoc = JsonDocument.Parse(responseContent);
            
            if (jsonDoc.RootElement.TryGetProperty("sessionToken", out var sessionTokenElement))
            {
                return sessionTokenElement.GetString();
            }
            
            throw new Exception($"Session token not found in response: {responseContent}");
        }

        public async Task DisposeAsync()
        {
            // Cleanup: Delete test user
            if (!string.IsNullOrEmpty(TestUserId))
            {
                try
                {
                    await _userApi.DeleteUserAsync(TestUserId);
                    await _userApi.DeleteUserAsync(TestUserId);
                }
                catch (ApiException)
                {
                    // Ignore cleanup errors
                }
            }
            
            _httpClient?.Dispose();
        }
    }

    [Collection(name: nameof(SessionApiTests))]
    public class SessionApiTests : IClassFixture<SessionApiTestFixture>, IDisposable
    {
        private readonly SessionApi _sessionApi = new();
        private readonly SessionApiTestFixture _fixture;
        private readonly List<string> _createdSessionIds = new List<string>();

        public SessionApiTests(SessionApiTestFixture fixture)
        {
            _fixture = fixture;
        }

        public void Dispose()
        {
            CleanupSessions().GetAwaiter().GetResult();
        }

        private async Task CleanupSessions()
        {
            foreach (var sessionId in _createdSessionIds)
            {
                try
                {
                    await _sessionApi.RevokeSessionAsync(sessionId);
                }
                catch (ApiException)
                {
                    // Session might already be revoked
                }
            }
            _createdSessionIds.Clear();
        }

        #region Complete CRUD Lifecycle Tests

        [Fact]
        public async Task GivenSession_WhenPerformingCrudOperations_ThenAllOperationsComplete()
        {
            // CREATE
            var sessionToken = await _fixture.GetSessionTokenAsync();
            var createSessionRequest = new CreateSessionRequest { SessionToken = sessionToken };
            var createdSession = await _sessionApi.CreateSessionAsync(createSessionRequest);
            _createdSessionIds.Add(createdSession.Id);
            
            createdSession.Should().NotBeNull();
            createdSession.Id.Should().NotBeNullOrEmpty();
            createdSession.UserId.Should().Be(_fixture.TestUserId);
            createdSession.Login.Should().Be(_fixture.TestUserEmail);
            createdSession.Status.Should().NotBeNull();
            createdSession.ExpiresAt.Should().BeAfter(DateTimeOffset.UtcNow);

            var sessionId = createdSession.Id;

            // READ
            var retrievedSession = await _sessionApi.GetSessionAsync(sessionId);
            retrievedSession.Should().NotBeNull();
            retrievedSession.Id.Should().Be(sessionId);
            retrievedSession.UserId.Should().Be(_fixture.TestUserId);

            // UPDATE (Refresh)
            var refreshedSession = await _sessionApi.RefreshSessionAsync(sessionId);
            refreshedSession.Should().NotBeNull();
            refreshedSession.Id.Should().Be(sessionId);
            refreshedSession.ExpiresAt.Should().BeAfter(DateTimeOffset.UtcNow);

            // DELETE
            await _sessionApi.RevokeSessionAsync(sessionId);
            _createdSessionIds.Remove(sessionId);

            var ex = await Assert.ThrowsAsync<ApiException>(async () => 
                await _sessionApi.GetSessionAsync(sessionId));
            ex.ErrorCode.Should().Be(404);
        }

        #endregion

        #region CREATE Operation Tests

        [Fact]
        public async Task GivenValidSessionToken_WhenCreatingSession_ThenSessionIsCreated()
        {
            var sessionToken = await _fixture.GetSessionTokenAsync();
            var createSessionRequest = new CreateSessionRequest { SessionToken = sessionToken };

            var session = await _sessionApi.CreateSessionAsync(createSessionRequest);
            _createdSessionIds.Add(session.Id);

            // Validate all critical session properties
            session.Should().NotBeNull();
            session.Id.Should().NotBeNullOrEmpty();
            session.UserId.Should().Be(_fixture.TestUserId);
            session.Login.Should().Be(_fixture.TestUserEmail);
            session.Status.Should().NotBeNull();
            session.ExpiresAt.Should().BeAfter(DateTimeOffset.UtcNow);
            session.CreatedAt.Should().BeBefore(DateTimeOffset.UtcNow.AddSeconds(30));
            session.Amr.Should().NotBeNull("Authentication method reference should be set");
            session.Amr.Should().Contain(SessionAuthenticationMethod.Pwd, "Password authentication should be in AMR");
        }

        [Fact]
        public async Task GivenValidSessionToken_WhenCreatingSessionWithHttpInfo_ThenHttpResponseIsReturned()
        {
            var sessionToken = await _fixture.GetSessionTokenAsync();
            var createSessionRequest = new CreateSessionRequest { SessionToken = sessionToken };

            var response = await _sessionApi.CreateSessionWithHttpInfoAsync(createSessionRequest);
            _createdSessionIds.Add(response.Data.Id);

            // Validate HTTP response
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Headers.Should().NotBeNull();
            
            // Validate response data
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().NotBeNullOrEmpty();
            response.Data.UserId.Should().Be(_fixture.TestUserId);
            response.Data.Login.Should().Be(_fixture.TestUserEmail);
            response.Data.Status.Should().NotBeNull();
            response.Data.ExpiresAt.Should().BeAfter(DateTimeOffset.UtcNow);
            response.Data.CreatedAt.Should().BeBefore(DateTimeOffset.UtcNow.AddSeconds(30));
        }

        [Fact]
        public async Task GivenInvalidSessionToken_WhenCreatingSession_ThenOperationFails()
        {
            var createSessionRequest = new CreateSessionRequest { SessionToken = "invalid_token_12345" };

            var ex = await Assert.ThrowsAsync<ApiException>(async () => 
                await _sessionApi.CreateSessionAsync(createSessionRequest));

            ex.ErrorCode.Should().Be(401);
        }

        [Fact]
        public async Task GivenNullSessionToken_WhenCreatingSession_ThenOperationFails()
        {
            var createSessionRequest = new CreateSessionRequest { SessionToken = null };

            var ex = await Assert.ThrowsAsync<ApiException>(async () => 
                await _sessionApi.CreateSessionAsync(createSessionRequest));

            ex.ErrorCode.Should().BeOneOf(400, 401);
        }

        #endregion

        #region READ Operation Tests

        [Fact]
        public async Task GivenValidId_WhenGettingSession_ThenSessionIsReturned()
        {
            var sessionToken = await _fixture.GetSessionTokenAsync();
            var createSessionRequest = new CreateSessionRequest { SessionToken = sessionToken };
            var createdSession = await _sessionApi.CreateSessionAsync(createSessionRequest);
            _createdSessionIds.Add(createdSession.Id);

            var retrievedSession = await _sessionApi.GetSessionAsync(createdSession.Id);

            // Validate all properties match
            retrievedSession.Should().NotBeNull();
            retrievedSession.Id.Should().Be(createdSession.Id);
            retrievedSession.UserId.Should().Be(_fixture.TestUserId);
            retrievedSession.Login.Should().Be(_fixture.TestUserEmail);
            retrievedSession.Status.Should().Be(createdSession.Status);
            retrievedSession.ExpiresAt.Should().Be(createdSession.ExpiresAt);
            retrievedSession.CreatedAt.Should().Be(createdSession.CreatedAt);
        }

        [Fact]
        public async Task GivenValidId_WhenGettingSessionWithHttpInfo_ThenHttpResponseIsReturned()
        {
            var sessionToken = await _fixture.GetSessionTokenAsync();
            var createSessionRequest = new CreateSessionRequest { SessionToken = sessionToken };
            var createdSession = await _sessionApi.CreateSessionAsync(createSessionRequest);
            _createdSessionIds.Add(createdSession.Id);

            var response = await _sessionApi.GetSessionWithHttpInfoAsync(createdSession.Id);

            // Validate HTTP response
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Headers.Should().NotBeNull();
            
            // Validate response data
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(createdSession.Id);
            response.Data.UserId.Should().Be(_fixture.TestUserId);
            response.Data.Login.Should().Be(_fixture.TestUserEmail);
        }

        [Fact]
        public async Task GivenInvalidId_WhenGettingSession_ThenOperationFails()
        {
            var invalidSessionId = "invalid_session_id_12345";

            var ex = await Assert.ThrowsAsync<ApiException>(async () => 
                await _sessionApi.GetSessionAsync(invalidSessionId));

            ex.ErrorCode.Should().Be(404);
            ex.Message.Should().Contain("E0000007");
        }

        #endregion

        #region UPDATE Operation Tests

        [Fact]
        public async Task GivenValidId_WhenRefreshingSession_ThenSessionIsRefreshed()
        {
            var sessionToken = await _fixture.GetSessionTokenAsync();
            var createSessionRequest = new CreateSessionRequest { SessionToken = sessionToken };
            var createdSession = await _sessionApi.CreateSessionAsync(createSessionRequest);
            _createdSessionIds.Add(createdSession.Id);

            var refreshedSession = await _sessionApi.RefreshSessionAsync(createdSession.Id);

            // Validate refreshed session properties
            refreshedSession.Should().NotBeNull();
            refreshedSession.Id.Should().Be(createdSession.Id);
            refreshedSession.UserId.Should().Be(_fixture.TestUserId);
            refreshedSession.Login.Should().Be(_fixture.TestUserEmail);
            refreshedSession.ExpiresAt.Should().BeAfter(DateTimeOffset.UtcNow);
            refreshedSession.Status.Should().NotBeNull();
        }

        [Fact]
        public async Task GivenValidId_WhenRefreshingSessionWithHttpInfo_ThenHttpResponseIsReturned()
        {
            var sessionToken = await _fixture.GetSessionTokenAsync();
            var createSessionRequest = new CreateSessionRequest { SessionToken = sessionToken };
            var createdSession = await _sessionApi.CreateSessionAsync(createSessionRequest);
            _createdSessionIds.Add(createdSession.Id);

            var response = await _sessionApi.RefreshSessionWithHttpInfoAsync(createdSession.Id);

            // Validate HTTP response
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Headers.Should().NotBeNull();
            
            // Validate response data
            response.Data.Should().NotBeNull();
            response.Data.Id.Should().Be(createdSession.Id);
            response.Data.UserId.Should().Be(_fixture.TestUserId);
            response.Data.ExpiresAt.Should().BeAfter(DateTimeOffset.UtcNow);
        }

        [Fact]
        public async Task GivenInvalidId_WhenRefreshingSession_ThenOperationFails()
        {
            var invalidSessionId = "invalid_session_id_12345";

            var ex = await Assert.ThrowsAsync<ApiException>(async () => 
                await _sessionApi.RefreshSessionAsync(invalidSessionId));

            ex.ErrorCode.Should().Be(404);
            ex.Message.Should().Contain("E0000007");
        }

        #endregion

        #region DELETE Operation Tests

        [Fact]
        public async Task GivenValidId_WhenRevokingSession_ThenSessionIsRevoked()
        {
            var sessionToken = await _fixture.GetSessionTokenAsync();
            var createSessionRequest = new CreateSessionRequest { SessionToken = sessionToken };
            var createdSession = await _sessionApi.CreateSessionAsync(createSessionRequest);

            await _sessionApi.RevokeSessionAsync(createdSession.Id);

            var ex = await Assert.ThrowsAsync<ApiException>(async () => 
                await _sessionApi.GetSessionAsync(createdSession.Id));
            ex.ErrorCode.Should().Be(404);
        }

        [Fact]
        public async Task GivenInvalidId_WhenRevokingSession_ThenOperationFails()
        {
            var invalidSessionId = "invalid_session_id_12345";

            var ex = await Assert.ThrowsAsync<ApiException>(async () => 
                await _sessionApi.RevokeSessionAsync(invalidSessionId));

            ex.ErrorCode.Should().Be(404);
            ex.Message.Should().Contain("E0000007");
        }

        [Fact]
        public async Task GivenRevokedSession_WhenRevokingAgain_ThenOperationFails()
        {
            var sessionToken = await _fixture.GetSessionTokenAsync();
            var createSessionRequest = new CreateSessionRequest { SessionToken = sessionToken };
            var createdSession = await _sessionApi.CreateSessionAsync(createSessionRequest);

            await _sessionApi.RevokeSessionAsync(createdSession.Id);

            var ex = await Assert.ThrowsAsync<ApiException>(async () => 
                await _sessionApi.RevokeSessionAsync(createdSession.Id));

            ex.ErrorCode.Should().Be(404);
            ex.Message.Should().Contain("E0000007");
        }

        [Fact]
        public async Task GivenValidId_WhenRevokingSessionWithHttpInfo_ThenHttpResponseIsReturned()
        {
            var sessionToken = await _fixture.GetSessionTokenAsync();
            var createSessionRequest = new CreateSessionRequest { SessionToken = sessionToken };
            var createdSession = await _sessionApi.CreateSessionAsync(createSessionRequest);

            var response = await _sessionApi.RevokeSessionWithHttpInfoAsync(createdSession.Id);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
            
            // Verify session is actually revoked
            var ex = await Assert.ThrowsAsync<ApiException>(async () => 
                await _sessionApi.GetSessionAsync(createdSession.Id));
            ex.ErrorCode.Should().Be(404);
        }

        #endregion

        #region Edge Case Tests

        [Fact]
        public async Task GivenSameUser_WhenCreatingMultipleSessions_ThenSessionsWorkIndependently()
        {
            var sessionToken1 = await _fixture.GetSessionTokenAsync();
            var createSessionRequest1 = new CreateSessionRequest { SessionToken = sessionToken1 };
            var session1 = await _sessionApi.CreateSessionAsync(createSessionRequest1);
            _createdSessionIds.Add(session1.Id);

            var sessionToken2 = await _fixture.GetSessionTokenAsync();
            var createSessionRequest2 = new CreateSessionRequest { SessionToken = sessionToken2 };
            var session2 = await _sessionApi.CreateSessionAsync(createSessionRequest2);
            _createdSessionIds.Add(session2.Id);

            session1.Id.Should().NotBe(session2.Id);
            session1.UserId.Should().Be(session2.UserId);

            var retrievedSession1 = await _sessionApi.GetSessionAsync(session1.Id);
            var retrievedSession2 = await _sessionApi.GetSessionAsync(session2.Id);

            retrievedSession1.Should().NotBeNull();
            retrievedSession2.Should().NotBeNull();

            await _sessionApi.RevokeSessionAsync(session1.Id);
            _createdSessionIds.Remove(session1.Id);

            var stillActiveSession = await _sessionApi.GetSessionAsync(session2.Id);
            stillActiveSession.Should().NotBeNull();
        }

        [Fact]
        public async Task GivenSession_WhenRefreshingMultipleTimes_ThenAllRefreshesSucceed()
        {
            var sessionToken = await _fixture.GetSessionTokenAsync();
            var createSessionRequest = new CreateSessionRequest { SessionToken = sessionToken };
            var createdSession = await _sessionApi.CreateSessionAsync(createSessionRequest);
            _createdSessionIds.Add(createdSession.Id);

            // Refresh multiple times without delay
            for (int i = 0; i < 3; i++)
            {
                var refreshedSession = await _sessionApi.RefreshSessionAsync(createdSession.Id);
                refreshedSession.Should().NotBeNull($"Session should be refreshable on iteration {i + 1}");
                refreshedSession.Id.Should().Be(createdSession.Id);
            }

            var finalSession = await _sessionApi.GetSessionAsync(createdSession.Id);
            finalSession.Should().NotBeNull();
        }

        #endregion
    }
}
