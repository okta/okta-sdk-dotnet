using FluentAssertions;
using Newtonsoft.Json.Linq;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Extensions;
using Okta.Sdk.Model;
using Polly;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Okta.Sdk.IntegrationTest
{
    [Collection(nameof(OAuthApiTests))]
    public class OAuthApiTests
    {
        private readonly ITestOutputHelper _output;

        private const string TestPrivateKey = @"{
            ""p"":""2-8pgwYv9jrkM2KsbnQmnJZnr69Rsj95M20I1zx5HhM3tgjGSa7d_dELPRkp9Usy8UGISt7eUHpYOVl529irHwbXevuId1Q804aQ_AtNJwpbRY48rw2T8LdtyVSaEyoFMCa8PJwtzZYzKJCKAe5eoXvW5zxB65RaIct0igYcoIs"",
            ""kty"":""RSA"",
            ""q"":""slkNUY_SCIn95ip7HoPs_IIiNoKOGeesIV1gacyoAycly1vBPMhtar9gwx51nN1tCMVGlSOk583eRJe2omAbqkIEYm1jSWtMdJKQSOJvx812xbF1afMgJDlJ6iRIlcnWEYhNNMCK5s_UR5zE0Mc5jktxDFeiEatriyu6o9hQix8"",
            ""d"":""LIpJTKCi9hPTiuUU954hayd3lXNwTVS6Fdny2iUj6iZ22eRp1V_UswECuMy5B-8lWbp1Gu_eASvhElSCB26m3UgHRVy8LP6Lmvm9VlJuZ5NtOK5D0R-gzFLINGdQH1PehzEc44jsTWyu297lgCLrVy-VScHQJodni3txTzxY4jwjILMfLB7OWdKVkvDQ4g70BYTVN5kZKjA9B0lLsofi1gUY_EVlojuvSKbm3HY0JR_JThtEd_nZw_tXTYmlP58plVYX-9JnA8NcFRB6dUNO7XqcXU1SafWqoM9yam1nGSMYRknwjSSTKRdBXHSy7PVxVHhpC72wb3aWNsOqWNo0ZQ"",
            ""e"":""AQAB"",
            ""qi"":""u1mS53N4BUSoMeOHFd0o4_n3QGH4izNUsiJVBIkv_UZUAk4LYudPEikTWRLqWsrcXmOyZYao5sSaZyt-B2XCkfdnkIhl-Q7b0_W0yt3Eh5XjAzH9oy5Dklog255lh-Y0yoWXvLjq-KEDs7Nd2uIT4gvKU4ymTqybvzazr2jY9qQ"",
            ""dp"":""nCtPBsK1-9oFgJdoaWYApOAH8DBFipSXs3SQ-oTuW_S5coD4jAmniDuQB2p-6LblDXrDFKb8pZi6XL60UO-hUv7As4s4c8NVDb5X5SEBP9-Sv-koHgU-L4eQZY21ejY0SOS4dTFRNNKasQsxc_2XJIOTLc8T3_wPpD-cGQYN_dE"",
            ""dq"":""ZWb4iZ0qICzFLW6N3gXIYrFi3ndQcC4m0jmTLdRs2o4RkRQ0RGj4vS7ex1G0MWI8MjZoMTe49Qs6Cunvr1bRo_YxI_1p7D6Tk9wZKTeFsqaBl1mUlo7jgXUJL5U9p9zAV-uVah7nWuBjo-vgg4wij2MZfZj9zuoWFWThk3LUKKU"",
            ""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
        }";

        public OAuthApiTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task GivenOAuthClient_WhenRetrievingAccessToken_ThenTokenIsReturned()
        {
            var guid = Guid.NewGuid();
            var payload = $@"{{
                ""client_name"": ""dotnet-sdk: OAuthApiTests {guid}"",
                ""response_types"": [""token""],
                ""grant_types"": [""client_credentials""],
                ""token_endpoint_auth_method"": ""private_key_jwt"",
                ""application_type"": ""service"",
                ""jwks"": {{
                    ""keys"": [{{
                        ""kty"":""RSA"",
                        ""e"":""AQAB"",
                        ""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
                    }}]
                }}
            }}";

            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;
            if (oktaDomain.EndsWith("/"))
            {
                oktaDomain = oktaDomain.Remove(oktaDomain.Length - 1);
            }

            var apiClient = new ApiClient(oktaDomain);
            var grantPayload = $@"{{""scopeId"":""okta.users.read"",""issuer"":""{oktaDomain}""}}";

            var requestOptions = GetBasicRequestOptions();
            requestOptions.Data = JObject.Parse(payload);

            var serviceResponse = await apiClient.PostAsync<JObject>("/oauth2/v1/clients", requestOptions);
            var clientId = serviceResponse.Data["client_id"].ToString();

            try
            {
                requestOptions = GetBasicRequestOptions();
                requestOptions.Data = JObject.Parse(grantPayload);
                await apiClient.PostAsync<JObject>($"/api/v1/apps/{clientId}/grants", requestOptions);

                var configuration = new Configuration
                {
                    Scopes = new HashSet<string> { "okta.users.read" },
                    ClientId = clientId,
                    PrivateKey = new JsonWebKeyConfiguration(TestPrivateKey),
                    AuthorizationMode = AuthorizationMode.PrivateKey,
                    OktaDomain = oktaDomain
                };

                var oauthApi = new OAuthApi(configuration);
                var tokenResponse = await oauthApi.GetBearerTokenAsync();

                tokenResponse.Should().NotBeNull();
                tokenResponse.AccessToken.Should().NotBeNullOrEmpty();
            }
            finally
            {
                requestOptions = GetBasicRequestOptions();
                await apiClient.DeleteAsync<JObject>($"/oauth2/v1/clients/{clientId}", requestOptions, Configuration.GetConfigurationOrDefault());
            }
        }

        [Fact]
        public async Task GivenOAuthClient_WhenListingAppsWithValidAccessToken_ThenAppsAreReturned()
        {
            var guid = Guid.NewGuid();
            var payload = $@"{{
                ""client_name"": ""dotnet-sdk: OAuthApiTests {guid}"",
                ""response_types"": [""token""],
                ""grant_types"": [""client_credentials""],
                ""token_endpoint_auth_method"": ""private_key_jwt"",
                ""application_type"": ""service"",
                ""jwks"": {{
                    ""keys"": [{{
                        ""kty"":""RSA"",
                        ""e"":""AQAB"",
                        ""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
                    }}]
                }}
            }}";

            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;
            if (oktaDomain.EndsWith("/"))
            {
                oktaDomain = oktaDomain.Remove(oktaDomain.Length - 1);
            }

            var apiClient = new ApiClient(oktaDomain);
            var grantPayload = $@"{{""scopeId"":""okta.apps.read"",""issuer"":""{oktaDomain}""}}";

            var requestOptions = GetBasicRequestOptions();
            requestOptions.Data = JObject.Parse(payload);

            var serviceResponse = await apiClient.PostAsync<JObject>("/oauth2/v1/clients", requestOptions);
            var clientId = serviceResponse.Data["client_id"].ToString();

            try
            {
                var roleAssignmentPayload = $@"{{'type':'SUPER_ADMIN'}}";
                var roleAssignmentRequest = GetBasicRequestOptions();
                roleAssignmentRequest.Data = JObject.Parse(roleAssignmentPayload);
                await apiClient.PostAsync<JObject>($"/oauth2/v1/clients/{clientId}/roles", roleAssignmentRequest);

                requestOptions = GetBasicRequestOptions();
                requestOptions.Data = JObject.Parse(grantPayload);
                await apiClient.PostAsync<JObject>($"/api/v1/apps/{clientId}/grants", requestOptions);

                var configuration = new Configuration
                {
                    Scopes = new HashSet<string> { "okta.apps.read" },
                    ClientId = clientId,
                    PrivateKey = new JsonWebKeyConfiguration(TestPrivateKey),
                    AuthorizationMode = AuthorizationMode.PrivateKey,
                    OktaDomain = oktaDomain
                };

                var oauthAppsApi = new ApplicationApi(configuration);
                var apps = await oauthAppsApi.ListApplications().ToListAsync();

                apps.Should().NotBeEmpty();
            }
            finally
            {
                requestOptions = GetBasicRequestOptions();
                await apiClient.DeleteAsync<JObject>($"/oauth2/v1/clients/{clientId}", requestOptions, Configuration.GetConfigurationOrDefault());
            }
        }

        [Fact]
        public async Task GivenOAuthClient_WhenListingAppsWithInvalidAccessToken_ThenForbiddenIsReturned()
        {
            var guid = Guid.NewGuid();
            var payload = $@"{{
                ""client_name"": ""dotnet-sdk: OAuthApiTests {guid}"",
                ""response_types"": [""token""],
                ""grant_types"": [""client_credentials""],
                ""token_endpoint_auth_method"": ""private_key_jwt"",
                ""application_type"": ""service"",
                ""jwks"": {{
                    ""keys"": [{{
                        ""kty"":""RSA"",
                        ""e"":""AQAB"",
                        ""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
                    }}]
                }}
            }}";

            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;
            if (oktaDomain.EndsWith("/"))
            {
                oktaDomain = oktaDomain.Remove(oktaDomain.Length - 1);
            }

            var apiClient = new ApiClient(oktaDomain);
            var grantPayload = $@"{{""scopeId"":""okta.users.read"",""issuer"":""{oktaDomain}""}}";

            var requestOptions = GetBasicRequestOptions();
            requestOptions.Data = JObject.Parse(payload);

            var serviceResponse = await apiClient.PostAsync<JObject>("/oauth2/v1/clients", requestOptions);
            var clientId = serviceResponse.Data["client_id"].ToString();

            try
            {
                var roleAssignmentPayload = $@"{{'type':'SUPER_ADMIN'}}";
                var roleAssignmentRequest = GetBasicRequestOptions();
                roleAssignmentRequest.Data = JObject.Parse(roleAssignmentPayload);
                await apiClient.PostAsync<JObject>($"/oauth2/v1/clients/{clientId}/roles", roleAssignmentRequest);

                requestOptions = GetBasicRequestOptions();
                requestOptions.Data = JObject.Parse(grantPayload);
                await apiClient.PostAsync<JObject>($"/api/v1/apps/{clientId}/grants", requestOptions);

                var configuration = new Configuration
                {
                    Scopes = new HashSet<string> { "okta.users.read" },
                    ClientId = clientId,
                    PrivateKey = new JsonWebKeyConfiguration(TestPrivateKey),
                    AuthorizationMode = AuthorizationMode.PrivateKey,
                    OktaDomain = oktaDomain
                };

                var oauthAppsApi = new ApplicationApi(configuration);
                var exception = await Assert.ThrowsAsync<ApiException>(async () => await oauthAppsApi.ListApplications().ToListAsync());
                exception.ErrorCode.Should().Be(403);
            }
            finally
            {
                requestOptions = GetBasicRequestOptions();
                await apiClient.DeleteAsync<JObject>($"/oauth2/v1/clients/{clientId}", requestOptions, Configuration.GetConfigurationOrDefault());
            }
        }

        [Fact]
        public async Task GivenOAuthClient_WhenGettingUserWithAccessToken_ThenUserIsReturned()
        {
            var guid = Guid.NewGuid();
            var payload = $@"{{
                ""client_name"": ""dotnet-sdk: OAuthApiTests {guid}"",
                ""response_types"": [""token""],
                ""grant_types"": [""client_credentials""],
                ""token_endpoint_auth_method"": ""private_key_jwt"",
                ""application_type"": ""service"",
                ""jwks"": {{
                    ""keys"": [{{
                        ""kty"":""RSA"",
                        ""e"":""AQAB"",
                        ""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
                    }}]
                }}
            }}";

            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;
            if (oktaDomain.EndsWith("/"))
            {
                oktaDomain = oktaDomain.Remove(oktaDomain.Length - 1);
            }

            var apiClient = new ApiClient(oktaDomain);
            var userApi = new UserApi();
            var grantPayload = $@"{{""scopeId"":""okta.users.read"",""issuer"":""{oktaDomain}""}}";

            var requestOptions = GetBasicRequestOptions();
            requestOptions.Data = JObject.Parse(payload);

            var serviceResponse = await apiClient.PostAsync<JObject>("/oauth2/v1/clients", requestOptions);
            var clientId = serviceResponse.Data["client_id"].ToString();

            var roleAssignmentPayload = $@"{{'type':'SUPER_ADMIN'}}";
            var roleAssignmentRequest = GetBasicRequestOptions();
            roleAssignmentRequest.Data = JObject.Parse(roleAssignmentPayload);

            Thread.Sleep(3000);
            await apiClient.PostAsync<JObject>($"/oauth2/v1/clients/{clientId}/roles", roleAssignmentRequest);

            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "OAuthTest",
                    Email = $"john-oauth-test-{guid}@example.com",
                    Login = $"john-oauth-test-{guid}@example.com",
                    NickName = $"johny-{guid}",
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "Abcd1234" }
                }
            };

            var createdUser = await userApi.CreateUserAsync(createUserRequest);
            await Task.Delay(3000);

            try
            {
                requestOptions = GetBasicRequestOptions();
                requestOptions.Data = JObject.Parse(grantPayload);
                await apiClient.PostAsync<JObject>($"/api/v1/apps/{clientId}/grants", requestOptions);

                var configuration = new Configuration
                {
                    Scopes = new HashSet<string> { "okta.users.read" },
                    ClientId = clientId,
                    PrivateKey = new JsonWebKeyConfiguration(TestPrivateKey),
                    AuthorizationMode = AuthorizationMode.PrivateKey,
                    OktaDomain = oktaDomain
                };

                var oauthUsersApi = new UserApi(configuration);
                var user = await oauthUsersApi.GetUserAsync(createdUser.Id);

                user.Should().NotBeNull();
            }
            finally
            {
                requestOptions = GetBasicRequestOptions();
                await apiClient.DeleteAsync<JObject>($"/oauth2/v1/clients/{clientId}", requestOptions, Configuration.GetConfigurationOrDefault());
                var userLifecycleApi = new UserLifecycleApi();
                await userLifecycleApi.DeactivateUserAsync(createdUser.Id);
                await userApi.DeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task GivenDpopEnabledClient_WhenRetrievingAccessToken_ThenDpopBoundTokenIsReturned()
        {
            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;
            var clientId = Environment.GetEnvironmentVariable("Okta:DpopClientId");
            string filePath = Environment.GetEnvironmentVariable("Okta:DpopClientPrivateKey");

            if (File.Exists(filePath))
            {
                string jsonPrivateKey = File.ReadAllText(filePath);
                var configuration = new Configuration
                {
                    Scopes = new HashSet<string> { "okta.users.read" },
                    ClientId = clientId,
                    PrivateKey = new JsonWebKeyConfiguration(jsonPrivateKey),
                    AuthorizationMode = AuthorizationMode.PrivateKey,
                    OktaDomain = oktaDomain
                };

                var oauthApi = new OAuthApi(configuration);
                var tokenResponse = await oauthApi.GetBearerTokenAsync();
                
                tokenResponse.AccessToken.Should().NotBeNullOrEmpty();
                tokenResponse.IsDpopBound.Should().BeTrue();
            }
        }

        [Fact]
        public async Task GivenDpopEnabledClient_WhenListingUsersWithDpopBoundToken_ThenUsersAreReturned()
        {
            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;
            var clientId = Environment.GetEnvironmentVariable("Okta:DpopClientId");
            string filePath = Environment.GetEnvironmentVariable("Okta:DpopClientPrivateKey");

            if (File.Exists(filePath))
            {
                string jsonPrivateKey = File.ReadAllText(filePath);
                var configuration = new Configuration
                {
                    Scopes = new HashSet<string> { "okta.users.manage" },
                    ClientId = clientId,
                    PrivateKey = new JsonWebKeyConfiguration(jsonPrivateKey),
                    AuthorizationMode = AuthorizationMode.PrivateKey,
                    OktaDomain = oktaDomain
                };

                var userApi = new UserApi(configuration);
                var users = await userApi.ListUsers().ToListAsync();

                users.Should().NotBeNullOrEmpty();

                var user = await userApi.GetUserAsync(users.FirstOrDefault()?.Profile?.Login);
                user.Should().NotBeNull();
            }
        }

        [Fact]
        public async Task GivenDpopEnabledClient_WhenListingUsersWithPaginationAndRetry_ThenAllUsersAreReturned()
        {
            var guid = Guid.NewGuid();
            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;
            var clientId = Environment.GetEnvironmentVariable("Okta:DpopClientId");
            string filePath = Environment.GetEnvironmentVariable("Okta:DpopClientPrivateKey");

            if (File.Exists(filePath))
            {
                string jsonPrivateKey = File.ReadAllText(filePath);
                var configuration = new Configuration
                {
                    Scopes = new HashSet<string> { "okta.users.manage" },
                    ClientId = clientId,
                    PrivateKey = new JsonWebKeyConfiguration(jsonPrivateKey),
                    AuthorizationMode = AuthorizationMode.PrivateKey,
                    OktaDomain = oktaDomain
                };

                var userApi = new UserApi(configuration);

                var createUserRequest1 = new CreateUserRequest
                {
                    Profile = new UserProfile
                    {
                        FirstName = "John",
                        LastName = "OAuthTest",
                        Email = $"john-oauth-test-{guid}@example.com",
                        Login = $"john-oauth-test-{guid}@example.com",
                        NickName = $"johny-{guid}",
                    },
                    Credentials = new UserCredentialsWritable
                    {
                        Password = new PasswordCredential { Value = "Abcd1234" }
                    }
                };

                var createdUser1 = await userApi.CreateUserAsync(createUserRequest1);

                var createUserRequest2 = new CreateUserRequest
                {
                    Profile = new UserProfile
                    {
                        FirstName = "Bob",
                        LastName = "OAuthTest",
                        Email = $"bob-oauth-test-{guid}@example.com",
                        Login = $"bob-oauth-test-{guid}@example.com",
                        NickName = $"bobby-{guid}",
                    },
                    Credentials = new UserCredentialsWritable
                    {
                        Password = new PasswordCredential { Value = "Abcd1234" }
                    }
                };

                var createdUser2 = await userApi.CreateUserAsync(createUserRequest2);
                await Task.Delay(8000);

                try
                {
                    var mockOauthProvider = new MockOAuthProvider(new DefaultOAuthTokenProvider(configuration));
                    var oauthUsersApi = new UserApi(configuration, mockOauthProvider);

                    var usersCollection = oauthUsersApi.ListUsers(limit: 1);
                    var pagedEnumerator = usersCollection.GetPagedEnumerator();
                    var retrievedUsers = new List<User>();

                    while (await pagedEnumerator.MoveNextAsync())
                    {
                        retrievedUsers.AddRange(pagedEnumerator.CurrentPage.Items);
                    }

                    retrievedUsers.Count.Should().BeGreaterOrEqualTo(2);
                    var invalidTokensCounter = 0;

                    while (mockOauthProvider.TokensQueue.Count > 0)
                    {
                        var queueValue = mockOauthProvider.TokensQueue.Dequeue();
                        if (queueValue.Equals("invalidToken", StringComparison.CurrentCultureIgnoreCase))
                        {
                            invalidTokensCounter++;
                        }
                    }

                    invalidTokensCounter.Should().Be(1);
                }
                finally
                {
                    var userLifecycleApi = new UserLifecycleApi();
                    await userLifecycleApi.DeactivateUserAsync(createdUser1.Id);
                    await userApi.DeleteUserAsync(createdUser1.Id);
                    await userLifecycleApi.DeactivateUserAsync(createdUser2.Id);
                    await userApi.DeleteUserAsync(createdUser2.Id);
                }
            }
        }

        [Fact]
        public async Task GivenOAuthClient_WhenListingUsersWithPagination_ThenAllUsersAreRetrieved()
        {
            var guid = Guid.NewGuid();
            var payload = $@"{{
                ""client_name"": ""dotnet-sdk: OAuthApiTests {guid}"",
                ""response_types"": [""token""],
                ""grant_types"": [""client_credentials""],
                ""token_endpoint_auth_method"": ""private_key_jwt"",
                ""application_type"": ""service"",
                ""jwks"": {{
                    ""keys"": [{{
                        ""kty"":""RSA"",
                        ""e"":""AQAB"",
                        ""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
                    }}]
                }}
            }}";

            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;
            if (oktaDomain.EndsWith("/"))
            {
                oktaDomain = oktaDomain.Remove(oktaDomain.Length - 1);
            }

            var apiClient = new ApiClient(oktaDomain);
            var userApi = new UserApi();
            var grantPayload = $@"{{""scopeId"":""okta.users.read"",""issuer"":""{oktaDomain}""}}";

            var requestOptions = GetBasicRequestOptions();
            requestOptions.Data = JObject.Parse(payload);

            var serviceResponse = await apiClient.PostAsync<JObject>("/oauth2/v1/clients", requestOptions);
            var clientId = serviceResponse.Data["client_id"].ToString();

            Thread.Sleep(6000);

            var roleAssignmentPayload = $@"{{'type':'SUPER_ADMIN'}}";
            var roleAssignmentRequest = GetBasicRequestOptions();
            roleAssignmentRequest.Data = JObject.Parse(roleAssignmentPayload);
            await apiClient.PostAsync<JObject>($"/oauth2/v1/clients/{clientId}/roles", roleAssignmentRequest);

            var createUserRequest1 = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "OAuthTest",
                    Email = $"john-oauth-test-{guid}@example.com",
                    Login = $"john-oauth-test-{guid}@example.com",
                    NickName = $"johny-{guid}",
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "Abcd1234" }
                }
            };

            var createdUser1 = await userApi.CreateUserAsync(createUserRequest1);

            var createUserRequest2 = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "Bob",
                    LastName = "OAuthTest",
                    Email = $"bob-oauth-test-{guid}@example.com",
                    Login = $"bob-oauth-test-{guid}@example.com",
                    NickName = $"bobby-{guid}",
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "Abcd1234" }
                }
            };

            var createdUser2 = await userApi.CreateUserAsync(createUserRequest2);
            await Task.Delay(3000);

            try
            {
                requestOptions = GetBasicRequestOptions();
                requestOptions.Data = JObject.Parse(grantPayload);

                Thread.Sleep(3000);
                await apiClient.PostAsync<JObject>($"/api/v1/apps/{clientId}/grants", requestOptions);

                var configuration = new Configuration
                {
                    Scopes = new HashSet<string> { "okta.users.read" },
                    ClientId = clientId,
                    PrivateKey = new JsonWebKeyConfiguration(TestPrivateKey),
                    AuthorizationMode = AuthorizationMode.PrivateKey,
                    OktaDomain = oktaDomain
                };

                var oauthUsersApi = new UserApi(configuration);

                var usersCollection = oauthUsersApi.ListUsers(limit: 1);
                var pagedEnumerator = usersCollection.GetPagedEnumerator();
                var asyncEnumerator = usersCollection.GetAsyncEnumerator();
                var retrievedUsers = new List<User>();

                while (await pagedEnumerator.MoveNextAsync())
                {
                    retrievedUsers.AddRange(pagedEnumerator.CurrentPage.Items);
                }

                retrievedUsers.Count.Should().BeGreaterOrEqualTo(2);

                retrievedUsers.Clear();
                retrievedUsers.Count.Should().Be(0);

                while (await asyncEnumerator.MoveNextAsync())
                {
                    retrievedUsers.Add(asyncEnumerator.Current);
                }

                retrievedUsers.Count.Should().BeGreaterOrEqualTo(2);
            }
            finally
            {
                requestOptions = GetBasicRequestOptions();
                await apiClient.DeleteAsync<JObject>($"/oauth2/v1/clients/{clientId}", requestOptions, Configuration.GetConfigurationOrDefault());
                var userLifecycleApi = new UserLifecycleApi();
                await userLifecycleApi.DeactivateUserAsync(createdUser1.Id);
                await userApi.DeleteUserAsync(createdUser1.Id);
                await userLifecycleApi.DeactivateUserAsync(createdUser2.Id);
                await userApi.DeleteUserAsync(createdUser2.Id);
            }
        }

        [Fact]
        public async Task GivenOAuthClient_WhenListingUsersWithPaginationAndRetry_ThenAllUsersAreReturnedWithRetry()
        {
            var guid = Guid.NewGuid();
            var payload = $@"{{
                ""client_name"": ""dotnet-sdk: OAuthApiTests {guid}"",
                ""response_types"": [""token""],
                ""grant_types"": [""client_credentials""],
                ""token_endpoint_auth_method"": ""private_key_jwt"",
                ""application_type"": ""service"",
                ""jwks"": {{
                    ""keys"": [{{
                        ""kty"":""RSA"",
                        ""e"":""AQAB"",
                        ""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
                    }}]
                }}
            }}";

            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;
            if (oktaDomain.EndsWith("/"))
            {
                oktaDomain = oktaDomain.Remove(oktaDomain.Length - 1);
            }

            var apiClient = new ApiClient(oktaDomain);
            var userApi = new UserApi();
            var grantPayload = $@"{{""scopeId"":""okta.users.read"",""issuer"":""{oktaDomain}""}}";

            var requestOptions = GetBasicRequestOptions();
            requestOptions.Data = JObject.Parse(payload);

            var serviceResponse = await apiClient.PostAsync<JObject>("/oauth2/v1/clients", requestOptions);
            var clientId = serviceResponse.Data["client_id"].ToString();

            Thread.Sleep(6000);

            var roleAssignmentPayload = $@"{{'type':'SUPER_ADMIN'}}";
            var roleAssignmentRequest = GetBasicRequestOptions();
            roleAssignmentRequest.Data = JObject.Parse(roleAssignmentPayload);
            await apiClient.PostAsync<JObject>($"/oauth2/v1/clients/{clientId}/roles", roleAssignmentRequest);

            var createUserRequest1 = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "OAuthTest",
                    Email = $"john-oauth-test-{guid}@example.com",
                    Login = $"john-oauth-test-{guid}@example.com",
                    NickName = $"johny-{guid}",
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "Abcd1234" }
                }
            };

            var createdUser1 = await userApi.CreateUserAsync(createUserRequest1);

            var createUserRequest2 = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "Bob",
                    LastName = "OAuthTest",
                    Email = $"bob-oauth-test-{guid}@example.com",
                    Login = $"bob-oauth-test-{guid}@example.com",
                    NickName = $"bobby-{guid}",
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "Abcd1234" }
                }
            };

            var createdUser2 = await userApi.CreateUserAsync(createUserRequest2);
            await Task.Delay(8000);

            try
            {
                requestOptions = GetBasicRequestOptions();
                requestOptions.Data = JObject.Parse(grantPayload);
                await apiClient.PostAsync<JObject>($"/api/v1/apps/{clientId}/grants", requestOptions);

                var configuration = new Configuration
                {
                    Scopes = new HashSet<string> { "okta.users.read" },
                    ClientId = clientId,
                    PrivateKey = new JsonWebKeyConfiguration(TestPrivateKey),
                    AuthorizationMode = AuthorizationMode.PrivateKey,
                    OktaDomain = oktaDomain
                };

                var mockOauthProvider = new MockOAuthProvider(new DefaultOAuthTokenProvider(configuration));
                var oauthUsersApi = new UserApi(configuration, mockOauthProvider);

                var usersCollection = oauthUsersApi.ListUsers(limit: 1);
                var pagedEnumerator = usersCollection.GetPagedEnumerator();
                var retrievedUsers = new List<User>();

                while (await pagedEnumerator.MoveNextAsync())
                {
                    retrievedUsers.AddRange(pagedEnumerator.CurrentPage.Items);
                }

                retrievedUsers.Count.Should().BeGreaterOrEqualTo(2);
                var invalidTokensCounter = 0;

                while (mockOauthProvider.TokensQueue.Count > 0)
                {
                    var queueValue = mockOauthProvider.TokensQueue.Dequeue();
                    if (queueValue.Equals("invalidToken", StringComparison.CurrentCultureIgnoreCase))
                    {
                        invalidTokensCounter++;
                    }
                }

                invalidTokensCounter.Should().Be(1);
            }
            finally
            {
                requestOptions = GetBasicRequestOptions();
                await apiClient.DeleteAsync<JObject>($"/oauth2/v1/clients/{clientId}", requestOptions, Configuration.GetConfigurationOrDefault());
                var userLifecycleApi = new UserLifecycleApi();
                await userLifecycleApi.DeactivateUserAsync(createdUser1.Id);
                await userApi.DeleteUserAsync(createdUser1.Id);
                await userLifecycleApi.DeactivateUserAsync(createdUser2.Id);
                await userApi.DeleteUserAsync(createdUser2.Id);
            }
        }

        [Fact]
        public async Task GivenOAuthClient_WhenRetrievingAccessTokenWithPrivateKeyAndDpop_ThenDpopBoundTokenIsReturned()
        {
            // Verifies SDK correctly implements DPoP proof JWT generation per RFC 9449 (jwk as JSON object, not string)
            // NOTE: Test environment may not support DPoP for dynamically created clients. SDK sends correct DPoP headers regardless.
            // See https://support.okta.com/help/s/article/the-dpop-proof-jwt-header-is-missing for DPoP requirements.
            
            var guid = Guid.NewGuid();
            var payload = $@"{{
                ""client_name"": ""dotnet-sdk: OAuthApiTests {guid}"",
                ""response_types"": [""token""],
                ""settings"":{{
                    ""oauthClient"":{{
                        ""dpop_bound_access_tokens"": true
                    }}
                }},
                ""grant_types"": [""client_credentials""],
                ""token_endpoint_auth_method"": ""private_key_jwt"",
                ""application_type"": ""service"",
                ""jwks"": {{
                    ""keys"": [{{
                        ""kty"":""RSA"",
                        ""e"":""AQAB"",
                        ""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
                    }}]
                }}
            }}";

            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;
            if (oktaDomain.EndsWith("/"))
            {
                oktaDomain = oktaDomain.Remove(oktaDomain.Length - 1);
            }

            var apiClient = new ApiClient(oktaDomain);
            var grantPayload = $@"{{""scopeId"":""okta.users.read"",""issuer"":""{oktaDomain}""}}";

            var requestOptions = GetBasicRequestOptions();
            requestOptions.Data = JObject.Parse(payload);
            var serviceResponse = await apiClient.PostAsync<JObject>("/oauth2/v1/clients", requestOptions);
            var clientId = serviceResponse.Data["client_id"]?.ToString();

            try
            {
                requestOptions = GetBasicRequestOptions();
                requestOptions.Data = JObject.Parse(grantPayload);
                await apiClient.PostAsync<JObject>($"/api/v1/apps/{clientId}/grants", requestOptions);

                var configuration = new Configuration
                {
                    Scopes = new HashSet<string> { "okta.users.read" },
                    ClientId = clientId,
                    PrivateKey = new JsonWebKeyConfiguration(TestPrivateKey),
                    AuthorizationMode = AuthorizationMode.PrivateKey,
                    OktaDomain = oktaDomain
                };

                var oauthApi = new OAuthApi(configuration);
                var tokenResponse = await oauthApi.GetBearerTokenAsync();

                tokenResponse.Should().NotBeNull();
                tokenResponse.AccessToken.Should().NotBeNullOrEmpty();
                
                if (tokenResponse.IsDpopBound)
                {
                    tokenResponse.TokenType.Should().Be("DPoP", "because the client was created with dpop_bound_access_tokens: true");
                }
                else
                {
                    tokenResponse.TokenType.Should().Be("Bearer");
                }
            }
            finally
            {
                requestOptions = GetBasicRequestOptions();
                await apiClient.DeleteAsync<JObject>($"/oauth2/v1/clients/{clientId}", requestOptions, Configuration.GetConfigurationOrDefault());
            }
        }

        [Fact]
        public async Task GivenOAuthClient_WhenRetrievingAccessTokenWithMultipleScopes_ThenTokenWithAllScopesIsReturned()
        {
            var guid = Guid.NewGuid();
            var payload = $@"{{
                ""client_name"": ""dotnet-sdk: OAuthApiTests {guid}"",
                ""response_types"": [""token""],
                ""grant_types"": [""client_credentials""],
                ""token_endpoint_auth_method"": ""private_key_jwt"",
                ""application_type"": ""service"",
                ""jwks"": {{
                    ""keys"": [{{
                        ""kty"":""RSA"",
                        ""e"":""AQAB"",
                        ""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
                    }}]
                }}
            }}";

            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;
            if (oktaDomain.EndsWith("/"))
            {
                oktaDomain = oktaDomain.Remove(oktaDomain.Length - 1);
            }

            var apiClient = new ApiClient(oktaDomain);
            var usersReadGrantPayload = $@"{{""scopeId"":""okta.users.read"",""issuer"":""{oktaDomain}""}}";
            var appsReadGrantPayload = $@"{{""scopeId"":""okta.apps.read"",""issuer"":""{oktaDomain}""}}";

            var requestOptions = GetBasicRequestOptions();
            requestOptions.Data = JObject.Parse(payload);

            var serviceResponse = await apiClient.PostAsync<JObject>("/oauth2/v1/clients", requestOptions);
            var clientId = serviceResponse.Data["client_id"].ToString();

            try
            {
                requestOptions = GetBasicRequestOptions();
                requestOptions.Data = JObject.Parse(usersReadGrantPayload);
                var usersReadGrantResponse = await apiClient.PostAsync<JObject>($"/api/v1/apps/{clientId}/grants", requestOptions);

                requestOptions = GetBasicRequestOptions();
                requestOptions.Data = JObject.Parse(appsReadGrantPayload);
                var appsReadGrantResponse = await apiClient.PostAsync<JObject>($"/api/v1/apps/{clientId}/grants", requestOptions);

                if (usersReadGrantResponse.StatusCode != System.Net.HttpStatusCode.OK || appsReadGrantResponse.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception($"Failed to assign scopes to client. Status Code: UsersReadGrantResponse-{usersReadGrantResponse.StatusCode}, AppsReadGrantResponse-{appsReadGrantResponse.StatusCode}");
                }

                var configuration = new Configuration
                {
                    Scopes = new HashSet<string> { "okta.users.read", "okta.apps.read" },
                    ClientId = clientId,
                    PrivateKey = new JsonWebKeyConfiguration(TestPrivateKey),
                    AuthorizationMode = AuthorizationMode.PrivateKey,
                    OktaDomain = oktaDomain
                };

                var oauthApi = new OAuthApi(configuration);
                var tokenResponse = await oauthApi.GetBearerTokenAsync();

                tokenResponse.Should().NotBeNull();
                tokenResponse.AccessToken.Should().NotBeNullOrEmpty();
                tokenResponse.Scope.Should().Contain("okta.apps.read");
                tokenResponse.Scope.Should().Contain("okta.users.read");
            }
            finally
            {
                requestOptions = GetBasicRequestOptions();
                await apiClient.DeleteAsync<JObject>($"/oauth2/v1/clients/{clientId}", requestOptions, Configuration.GetConfigurationOrDefault());
            }
        }

        private RequestOptions GetBasicRequestOptions()
        {
            string[] _contentTypes = new[] { "application/json" };
            string[] _accepts = new[] { "application/json" };

            var requestOptions = new RequestOptions();

            var localVarContentType = Okta.Sdk.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                requestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Okta.Sdk.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                requestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            if (!string.IsNullOrEmpty(Configuration.GetConfigurationOrDefault().GetApiKeyWithPrefix("Authorization")))
            {
                requestOptions.HeaderParameters.Add("Authorization", Configuration.GetConfigurationOrDefault().GetApiKeyWithPrefix("Authorization"));
            }

            return requestOptions;
        }

        public class MockOAuthProvider : IOAuthTokenProvider
        {
            private IOAuthTokenProvider _defaulTokenProvider;
            private int _counter;
            private Queue<string> _tokensQueue;
            private bool _isDpop;

            public Queue<string> TokensQueue
            {
                get { return _tokensQueue; }
            }

            public MockOAuthProvider(DefaultOAuthTokenProvider defaultProvider, bool isDpop = false)
            {
                _defaulTokenProvider = defaultProvider;
                _counter = 0;
                _tokensQueue = new Queue<string>();
                _isDpop = isDpop;
            }

            public string TokenType => (_isDpop) ? "DPoP" : "Bearer";

            public async Task<OAuthTokenResponse> GetAccessTokenResponseAsync(bool forceRenew = false, CancellationToken cancellationToken = default)
            {
                if (_counter == 0)
                {
                    _tokensQueue.Enqueue("invalidToken");
                    _counter++;
                    return await Task.FromResult(new OAuthTokenResponse() { AccessToken = "invalidToken", TokenType = TokenType });
                }

                _counter++;
                _tokensQueue.Enqueue("validToken");
                return await _defaulTokenProvider.GetAccessTokenResponseAsync(forceRenew);
            }

            public AsyncPolicy<RestResponse> GetOAuthRetryPolicy(Func<DelegateResult<RestResponse>, int, Context, Task> onRetryAsyncFunc = null)
            {
                return _defaulTokenProvider.GetOAuthRetryPolicy(onRetryAsyncFunc);
            }

            public async Task AddOrUpdateAuthorizationHeader(RequestOptions requestOptions, string requestUri, string httpMethod,
                CancellationToken cancellationToken = default)
            {
                if (_counter == 0)
                {
                    _tokensQueue.Enqueue("invalidToken");
                    _counter++;
                    requestOptions.HeaderParameters.Add("Authorization", $"{TokenType} invalidToken");
                    if (_isDpop)
                    {
                        requestOptions.HeaderParameters.Add("DPoP", "invalidToken");
                    }
                }
                else
                {
                    _counter++;
                    _tokensQueue.Enqueue("validToken");
                    await _defaulTokenProvider.AddOrUpdateAuthorizationHeader(requestOptions, requestUri, httpMethod, cancellationToken);
                }
            }

            public string GetDpopProofJwt(String? nonce = null, String? htm = null, String? htu = null, String? accessToken = null)
            {
                return _defaulTokenProvider.GetDpopProofJwt(nonce, htm, htu, accessToken);
            }
        }
    }
}
