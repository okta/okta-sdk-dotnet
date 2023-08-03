using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Okta.Sdk.Abstractions;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Polly;
using RestSharp;
using Xunit;

namespace Okta.Sdk.IntegrationTest
{
    public class OAuthScenarios
    {
        [Fact]
        public async Task RetrieveAccessToken()
        {
            var guid = Guid.NewGuid();
            var payload = $@"{{
                                ""client_name"": ""dotnet-sdk: Service Client {guid}"",
                                ""response_types"": [
                                  ""token""
                                ],
                                ""grant_types"": [
                                  ""client_credentials""
                                ],
                                ""token_endpoint_auth_method"": ""private_key_jwt"",
                                ""application_type"": ""service"",
                                ""jwks"": {{
    	                            ""keys"": [
      		                            {{
                                            ""kty"":""RSA"",
                                            ""e"":""AQAB"",
                                            ""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
                                        }}   
                                   ]
                                }}
                             }}";
            
            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;

            // Remove '/' at the end since endpoint fails otherwise
            oktaDomain = oktaDomain.Remove(oktaDomain.Length - 1);
            
            var apiClient = new ApiClient(oktaDomain);

            var grantPayload = $@"{{
                                        ""scopeId"" : ""okta.users.read"",
                                        ""issuer"" : ""{oktaDomain}""
                                    }}";



            var requestOptions = getBasicRequestOptions();
            requestOptions.Data = JObject.Parse(payload);

            var serviceResponse = await apiClient.PostAsync<JsonObject>("/oauth2/v1/clients", requestOptions);

            var clientId = serviceResponse.Data["client_id"].ToString();

            try
            {

                requestOptions = getBasicRequestOptions();
                requestOptions.Data = JObject.Parse(grantPayload);

                // Add grant to the service
                var grantResponse = await apiClient.PostAsync<JsonObject>($"/api/v1/apps/{clientId}/grants", requestOptions);


                // Use OAuth to get list of users
                var jsonPrivateKey = @"{
                                    ""p"":""2-8pgwYv9jrkM2KsbnQmnJZnr69Rsj95M20I1zx5HhM3tgjGSa7d_dELPRkp9Usy8UGISt7eUHpYOVl529irHwbXevuId1Q804aQ_AtNJwpbRY48rw2T8LdtyVSaEyoFMCa8PJwtzZYzKJCKAe5eoXvW5zxB65RaIct0igYcoIs"",
                                    ""kty"":""RSA"",
                                    ""q"":""slkNUY_SCIn95ip7HoPs_IIiNoKOGeesIV1gacyoAycly1vBPMhtar9gwx51nN1tCMVGlSOk583eRJe2omAbqkIEYm1jSWtMdJKQSOJvx812xbF1afMgJDlJ6iRIlcnWEYhNNMCK5s_UR5zE0Mc5jktxDFeiEatriyu6o9hQix8"",
                                    ""d"":""LIpJTKCi9hPTiuUU954hayd3lXNwTVS6Fdny2iUj6iZ22eRp1V_UswECuMy5B-8lWbp1Gu_eASvhElSCB26m3UgHRVy8LP6Lmvm9VlJuZ5NtOK5D0R-gzFLINGdQH1PehzEc44jsTWyu297lgCLrVy-VScHQJodni3txTzxY4jwjILMfLB7OWdKVkvDQ4g70BYTVN5kZKjA9B0lLsofi1gUY_EVlojuvSKbm3HY0JR_JThtEd_nZw_tXTYmlP58plVYX-9JnA8NcFRB6dUNO7XqcXU1SafWqoM9yam1nGSMYRknwjSSTKRdBXHSy7PVxVHhpC72wb3aWNsOqWNo0ZQ"",
                                    ""e"":""AQAB"",
                                    ""qi"":""u1mS53N4BUSoMeOHFd0o4_n3QGH4izNUsiJVBIkv_UZUAk4LYudPEikTWRLqWsrcXmOyZYao5sSaZyt-B2XCkfdnkIhl-Q7b0_W0yt3Eh5XjAzH9oy5Dklog255lh-Y0yoWXvLjq-KEDs7Nd2uIT4gvKU4ymTqybvzazr2jY9qQ"",""dp"":""nCtPBsK1-9oFgJdoaWYApOAH8DBFipSXs3SQ-oTuW_S5coD4jAmniDuQB2p-6LblDXrDFKb8pZi6XL60UO-hUv7As4s4c8NVDb5X5SEBP9-Sv-koHgU-L4eQZY21ejY0SOS4dTFRNNKasQsxc_2XJIOTLc8T3_wPpD-cGQYN_dE"",""dq"":""ZWb4iZ0qICzFLW6N3gXIYrFi3ndQcC4m0jmTLdRs2o4RkRQ0RGj4vS7ex1G0MWI8MjZoMTe49Qs6Cunvr1bRo_YxI_1p7D6Tk9wZKTeFsqaBl1mUlo7jgXUJL5U9p9zAV-uVah7nWuBjo-vgg4wij2MZfZj9zuoWFWThk3LUKKU"",""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
                                 }";

                var configuration = new Configuration();
                configuration.Scopes = new HashSet<string> { "okta.users.read" };
                configuration.ClientId = clientId;
                configuration.PrivateKey = new JsonWebKeyConfiguration(jsonPrivateKey);
                configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
                configuration.OktaDomain = oktaDomain;

                var oauthApi = new OAuthApi(configuration);

                var tokenResponse = await oauthApi.GetBearerTokenAsync();

                tokenResponse.Should().NotBeNull();
            }
            finally
            {
                requestOptions = getBasicRequestOptions();
                await apiClient.DeleteAsync<JsonObject>($"/oauth2/v1/clients/{clientId}", requestOptions, Configuration.GetConfigurationOrDefault());
            }
        }

        [Fact ]
        public async Task ListAppsWithAccessToken()
        {
            var guid = Guid.NewGuid();
            var payload = $@"{{
                                ""client_name"": ""dotnet-sdk: {nameof(ListAppsWithAccessToken)} {guid}"",
                                ""response_types"": [
                                  ""token""
                                ],
                                ""grant_types"": [
                                  ""client_credentials""
                                ],
                                ""token_endpoint_auth_method"": ""private_key_jwt"",
                                ""application_type"": ""service"",
                                ""jwks"": {{
    	                            ""keys"": [
      		                            {{
                                            ""kty"":""RSA"",
                                            ""e"":""AQAB"",
                                            ""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
                                        }}   
                                   ]
                                }}
                             }}";

            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;

            // Remove '/' at the end since endpoint fails otherwise
            oktaDomain = oktaDomain.Remove(oktaDomain.Length - 1);

            var apiClient = new ApiClient(oktaDomain);

            var grantPayload = $@"{{
                                        ""scopeId"" : ""okta.apps.read"",
                                        ""issuer"" : ""{oktaDomain}""
                                    }}";



            var requestOptions = getBasicRequestOptions();
            requestOptions.Data = JObject.Parse(payload);

            var serviceResponse = await apiClient.PostAsync<JsonObject>("/oauth2/v1/clients", requestOptions);

            var clientId = serviceResponse.Data["client_id"].ToString();

            try
            {
                var roleAssignmentPayload = $@"{{'type':'SUPER_ADMIN'}}";
                var roleAssignmentRequest = getBasicRequestOptions();
                roleAssignmentRequest.Data = JObject.Parse(roleAssignmentPayload);

                var roleAssignmentResponse = await apiClient.PostAsync<JsonObject>($"/oauth2/v1/clients/{clientId}/roles", roleAssignmentRequest);

                requestOptions = getBasicRequestOptions();
                requestOptions.Data = JObject.Parse(grantPayload);

                // Add grant to the service
                var grantResponse = await apiClient.PostAsync<JsonObject>($"/api/v1/apps/{clientId}/grants", requestOptions);


                // Use OAuth to get list of users
                var jsonPrivateKey = @"{
                                    ""p"":""2-8pgwYv9jrkM2KsbnQmnJZnr69Rsj95M20I1zx5HhM3tgjGSa7d_dELPRkp9Usy8UGISt7eUHpYOVl529irHwbXevuId1Q804aQ_AtNJwpbRY48rw2T8LdtyVSaEyoFMCa8PJwtzZYzKJCKAe5eoXvW5zxB65RaIct0igYcoIs"",
                                    ""kty"":""RSA"",
                                    ""q"":""slkNUY_SCIn95ip7HoPs_IIiNoKOGeesIV1gacyoAycly1vBPMhtar9gwx51nN1tCMVGlSOk583eRJe2omAbqkIEYm1jSWtMdJKQSOJvx812xbF1afMgJDlJ6iRIlcnWEYhNNMCK5s_UR5zE0Mc5jktxDFeiEatriyu6o9hQix8"",
                                    ""d"":""LIpJTKCi9hPTiuUU954hayd3lXNwTVS6Fdny2iUj6iZ22eRp1V_UswECuMy5B-8lWbp1Gu_eASvhElSCB26m3UgHRVy8LP6Lmvm9VlJuZ5NtOK5D0R-gzFLINGdQH1PehzEc44jsTWyu297lgCLrVy-VScHQJodni3txTzxY4jwjILMfLB7OWdKVkvDQ4g70BYTVN5kZKjA9B0lLsofi1gUY_EVlojuvSKbm3HY0JR_JThtEd_nZw_tXTYmlP58plVYX-9JnA8NcFRB6dUNO7XqcXU1SafWqoM9yam1nGSMYRknwjSSTKRdBXHSy7PVxVHhpC72wb3aWNsOqWNo0ZQ"",
                                    ""e"":""AQAB"",
                                    ""qi"":""u1mS53N4BUSoMeOHFd0o4_n3QGH4izNUsiJVBIkv_UZUAk4LYudPEikTWRLqWsrcXmOyZYao5sSaZyt-B2XCkfdnkIhl-Q7b0_W0yt3Eh5XjAzH9oy5Dklog255lh-Y0yoWXvLjq-KEDs7Nd2uIT4gvKU4ymTqybvzazr2jY9qQ"",""dp"":""nCtPBsK1-9oFgJdoaWYApOAH8DBFipSXs3SQ-oTuW_S5coD4jAmniDuQB2p-6LblDXrDFKb8pZi6XL60UO-hUv7As4s4c8NVDb5X5SEBP9-Sv-koHgU-L4eQZY21ejY0SOS4dTFRNNKasQsxc_2XJIOTLc8T3_wPpD-cGQYN_dE"",""dq"":""ZWb4iZ0qICzFLW6N3gXIYrFi3ndQcC4m0jmTLdRs2o4RkRQ0RGj4vS7ex1G0MWI8MjZoMTe49Qs6Cunvr1bRo_YxI_1p7D6Tk9wZKTeFsqaBl1mUlo7jgXUJL5U9p9zAV-uVah7nWuBjo-vgg4wij2MZfZj9zuoWFWThk3LUKKU"",""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
                                 }";

                var configuration = new Configuration();
                configuration.Scopes = new HashSet<string> { "okta.apps.read" };
                configuration.ClientId = clientId;
                configuration.PrivateKey = new JsonWebKeyConfiguration(jsonPrivateKey);
                configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
                configuration.OktaDomain = oktaDomain;

                var oauthAppsApi = new ApplicationApi(configuration);

                var apps = await oauthAppsApi.ListApplications().ToListAsync();

                apps.Should().NotBeEmpty();
            }
            finally
            {
                requestOptions = getBasicRequestOptions();
                await apiClient.DeleteAsync<JsonObject>($"/oauth2/v1/clients/{clientId}", requestOptions, Configuration.GetConfigurationOrDefault());
            }
        }

        [Fact]
        public async Task GetUserWithAccessToken()
        {
            var guid = Guid.NewGuid();
            var payload = $@"{{
                                ""client_name"": ""dotnet-sdk: {nameof(GetUserWithAccessToken)} {guid}"",
                                ""response_types"": [
                                  ""token""
                                ],
                                ""grant_types"": [
                                  ""client_credentials""
                                ],
                                ""token_endpoint_auth_method"": ""private_key_jwt"",
                                ""application_type"": ""service"",
                                ""jwks"": {{
    	                            ""keys"": [
      		                            {{
                                            ""kty"":""RSA"",
                                            ""e"":""AQAB"",
                                            ""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
                                        }}   
                                   ]
                                }}
                             }}";

            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;

            // Remove '/' at the end since endpoint fails otherwise
            oktaDomain = oktaDomain.Remove(oktaDomain.Length - 1);

            var apiClient = new ApiClient(oktaDomain);
            var userApi = new UserApi();

            var grantPayload = $@"{{
                                        ""scopeId"" : ""okta.users.read"",
                                        ""issuer"" : ""{oktaDomain}""
                                    }}";



            var requestOptions = getBasicRequestOptions();
            requestOptions.Data = JObject.Parse(payload);

            var serviceResponse = await apiClient.PostAsync<JsonObject>("/oauth2/v1/clients", requestOptions);

            var clientId = serviceResponse.Data["client_id"].ToString();

            var roleAssignmentPayload = $@"{{'type':'SUPER_ADMIN'}}";
            var roleAssignmentRequest = getBasicRequestOptions();
            roleAssignmentRequest.Data = JObject.Parse(roleAssignmentPayload);

            var roleAssignmentResponse = await apiClient.PostAsync<JsonObject>($"/oauth2/v1/clients/{clientId}/roles", roleAssignmentRequest);


            var createUserRequest = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(GetUserWithAccessToken),
                    Email = $"john-{nameof(GetUserWithAccessToken)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(GetUserWithAccessToken)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(GetUserWithAccessToken)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    }
                }
            };

            var createdUser = await userApi.CreateUserAsync(createUserRequest);
            // this delay and the below retry policy are to handle:
            // https://developer.okta.com/docs/api/resources/users.html#list-users-with-search
            // "Queries data from a replicated store, so changes aren’t always immediately available in search results."
            await Task.Delay(3000);

            try
            {
                var roleApi = new RoleAssignmentApi();
                await roleApi.AssignRoleToUserAsync(createdUser.Id, new AssignRoleRequest { Type = RoleType.SUPERADMIN });

                requestOptions = getBasicRequestOptions();
                requestOptions.Data = JObject.Parse(grantPayload);

                // Add grant to the service
                var grantResponse = await apiClient.PostAsync<JsonObject>($"/api/v1/apps/{clientId}/grants", requestOptions);


                // Use OAuth to get list of users
                var jsonPrivateKey = @"{
                                    ""p"":""2-8pgwYv9jrkM2KsbnQmnJZnr69Rsj95M20I1zx5HhM3tgjGSa7d_dELPRkp9Usy8UGISt7eUHpYOVl529irHwbXevuId1Q804aQ_AtNJwpbRY48rw2T8LdtyVSaEyoFMCa8PJwtzZYzKJCKAe5eoXvW5zxB65RaIct0igYcoIs"",
                                    ""kty"":""RSA"",
                                    ""q"":""slkNUY_SCIn95ip7HoPs_IIiNoKOGeesIV1gacyoAycly1vBPMhtar9gwx51nN1tCMVGlSOk583eRJe2omAbqkIEYm1jSWtMdJKQSOJvx812xbF1afMgJDlJ6iRIlcnWEYhNNMCK5s_UR5zE0Mc5jktxDFeiEatriyu6o9hQix8"",
                                    ""d"":""LIpJTKCi9hPTiuUU954hayd3lXNwTVS6Fdny2iUj6iZ22eRp1V_UswECuMy5B-8lWbp1Gu_eASvhElSCB26m3UgHRVy8LP6Lmvm9VlJuZ5NtOK5D0R-gzFLINGdQH1PehzEc44jsTWyu297lgCLrVy-VScHQJodni3txTzxY4jwjILMfLB7OWdKVkvDQ4g70BYTVN5kZKjA9B0lLsofi1gUY_EVlojuvSKbm3HY0JR_JThtEd_nZw_tXTYmlP58plVYX-9JnA8NcFRB6dUNO7XqcXU1SafWqoM9yam1nGSMYRknwjSSTKRdBXHSy7PVxVHhpC72wb3aWNsOqWNo0ZQ"",
                                    ""e"":""AQAB"",
                                    ""qi"":""u1mS53N4BUSoMeOHFd0o4_n3QGH4izNUsiJVBIkv_UZUAk4LYudPEikTWRLqWsrcXmOyZYao5sSaZyt-B2XCkfdnkIhl-Q7b0_W0yt3Eh5XjAzH9oy5Dklog255lh-Y0yoWXvLjq-KEDs7Nd2uIT4gvKU4ymTqybvzazr2jY9qQ"",""dp"":""nCtPBsK1-9oFgJdoaWYApOAH8DBFipSXs3SQ-oTuW_S5coD4jAmniDuQB2p-6LblDXrDFKb8pZi6XL60UO-hUv7As4s4c8NVDb5X5SEBP9-Sv-koHgU-L4eQZY21ejY0SOS4dTFRNNKasQsxc_2XJIOTLc8T3_wPpD-cGQYN_dE"",""dq"":""ZWb4iZ0qICzFLW6N3gXIYrFi3ndQcC4m0jmTLdRs2o4RkRQ0RGj4vS7ex1G0MWI8MjZoMTe49Qs6Cunvr1bRo_YxI_1p7D6Tk9wZKTeFsqaBl1mUlo7jgXUJL5U9p9zAV-uVah7nWuBjo-vgg4wij2MZfZj9zuoWFWThk3LUKKU"",""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
                                 }";

                var configuration = new Configuration();
                configuration.Scopes = new HashSet<string> { "okta.users.read" };
                configuration.ClientId = clientId;
                configuration.PrivateKey = new JsonWebKeyConfiguration(jsonPrivateKey);
                configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
                configuration.OktaDomain = oktaDomain;

                var oauthUsersApi = new UserApi(configuration);

                var user = await oauthUsersApi.GetUserAsync(createdUser.Id);

                user.Should().NotBeNull();
            }
            finally
            {
                requestOptions = getBasicRequestOptions();
                await apiClient.DeleteAsync<JsonObject>($"/oauth2/v1/clients/{clientId}", requestOptions, Configuration.GetConfigurationOrDefault());
                await userApi.DeactivateUserAsync(createdUser.Id);
                await userApi.DeleteUserAsync(createdUser.Id);
            }
        }

        [Fact]
        public async Task ListUsersWithPagination()
        {
            var guid = Guid.NewGuid();
            var payload = $@"{{
                                ""client_name"": ""dotnet-sdk: {nameof(ListUsersWithPagination)} {guid}"",
                                ""response_types"": [
                                  ""token""
                                ],
                                ""grant_types"": [
                                  ""client_credentials""
                                ],
                                ""token_endpoint_auth_method"": ""private_key_jwt"",
                                ""application_type"": ""service"",
                                ""jwks"": {{
    	                            ""keys"": [
      		                            {{
                                            ""kty"":""RSA"",
                                            ""e"":""AQAB"",
                                            ""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
                                        }}   
                                   ]
                                }}
                             }}";

            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;

            // Remove '/' at the end since endpoint fails otherwise
            oktaDomain = oktaDomain.Remove(oktaDomain.Length - 1);

            var apiClient = new ApiClient(oktaDomain);
            var userApi = new UserApi();

            var grantPayload = $@"{{
                                        ""scopeId"" : ""okta.users.read"",
                                        ""issuer"" : ""{oktaDomain}""
                                    }}";



            var requestOptions = getBasicRequestOptions();
            requestOptions.Data = JObject.Parse(payload);

            var serviceResponse = await apiClient.PostAsync<JsonObject>("/oauth2/v1/clients", requestOptions);

            var clientId = serviceResponse.Data["client_id"].ToString();

            var roleAssignmentPayload = $@"{{'type':'SUPER_ADMIN'}}";
            var roleAssignmentRequest = getBasicRequestOptions();
            roleAssignmentRequest.Data = JObject.Parse(roleAssignmentPayload);

            var roleAssignmentResponse = await apiClient.PostAsync<JsonObject>($"/oauth2/v1/clients/{clientId}/roles", roleAssignmentRequest);


            var createUserRequest1 = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(GetUserWithAccessToken),
                    Email = $"john-{nameof(GetUserWithAccessToken)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(GetUserWithAccessToken)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(GetUserWithAccessToken)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    }
                }
            };

            var createdUser1 = await userApi.CreateUserAsync(createUserRequest1);

            var createUserRequest2 = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "Bob",
                    LastName = nameof(GetUserWithAccessToken),
                    Email = $"bob-{nameof(GetUserWithAccessToken)}-dotnet-sdk-{guid}@example.com",
                    Login = $"bob-{nameof(GetUserWithAccessToken)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"bobby-{nameof(GetUserWithAccessToken)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    }
                }
            };

            var createdUser2 = await userApi.CreateUserAsync(createUserRequest2);

            // this delay and the below retry policy are to handle:
            // https://developer.okta.com/docs/api/resources/users.html#list-users-with-search
            // "Queries data from a replicated store, so changes aren’t always immediately available in search results."
            await Task.Delay(3000);

            try
            {

                requestOptions = getBasicRequestOptions();
                requestOptions.Data = JObject.Parse(grantPayload);

                // Add grant to the service
                var grantResponse = await apiClient.PostAsync<JsonObject>($"/api/v1/apps/{clientId}/grants", requestOptions);


                // Use OAuth to get list of users
                var jsonPrivateKey = @"{
                                    ""p"":""2-8pgwYv9jrkM2KsbnQmnJZnr69Rsj95M20I1zx5HhM3tgjGSa7d_dELPRkp9Usy8UGISt7eUHpYOVl529irHwbXevuId1Q804aQ_AtNJwpbRY48rw2T8LdtyVSaEyoFMCa8PJwtzZYzKJCKAe5eoXvW5zxB65RaIct0igYcoIs"",
                                    ""kty"":""RSA"",
                                    ""q"":""slkNUY_SCIn95ip7HoPs_IIiNoKOGeesIV1gacyoAycly1vBPMhtar9gwx51nN1tCMVGlSOk583eRJe2omAbqkIEYm1jSWtMdJKQSOJvx812xbF1afMgJDlJ6iRIlcnWEYhNNMCK5s_UR5zE0Mc5jktxDFeiEatriyu6o9hQix8"",
                                    ""d"":""LIpJTKCi9hPTiuUU954hayd3lXNwTVS6Fdny2iUj6iZ22eRp1V_UswECuMy5B-8lWbp1Gu_eASvhElSCB26m3UgHRVy8LP6Lmvm9VlJuZ5NtOK5D0R-gzFLINGdQH1PehzEc44jsTWyu297lgCLrVy-VScHQJodni3txTzxY4jwjILMfLB7OWdKVkvDQ4g70BYTVN5kZKjA9B0lLsofi1gUY_EVlojuvSKbm3HY0JR_JThtEd_nZw_tXTYmlP58plVYX-9JnA8NcFRB6dUNO7XqcXU1SafWqoM9yam1nGSMYRknwjSSTKRdBXHSy7PVxVHhpC72wb3aWNsOqWNo0ZQ"",
                                    ""e"":""AQAB"",
                                    ""qi"":""u1mS53N4BUSoMeOHFd0o4_n3QGH4izNUsiJVBIkv_UZUAk4LYudPEikTWRLqWsrcXmOyZYao5sSaZyt-B2XCkfdnkIhl-Q7b0_W0yt3Eh5XjAzH9oy5Dklog255lh-Y0yoWXvLjq-KEDs7Nd2uIT4gvKU4ymTqybvzazr2jY9qQ"",""dp"":""nCtPBsK1-9oFgJdoaWYApOAH8DBFipSXs3SQ-oTuW_S5coD4jAmniDuQB2p-6LblDXrDFKb8pZi6XL60UO-hUv7As4s4c8NVDb5X5SEBP9-Sv-koHgU-L4eQZY21ejY0SOS4dTFRNNKasQsxc_2XJIOTLc8T3_wPpD-cGQYN_dE"",""dq"":""ZWb4iZ0qICzFLW6N3gXIYrFi3ndQcC4m0jmTLdRs2o4RkRQ0RGj4vS7ex1G0MWI8MjZoMTe49Qs6Cunvr1bRo_YxI_1p7D6Tk9wZKTeFsqaBl1mUlo7jgXUJL5U9p9zAV-uVah7nWuBjo-vgg4wij2MZfZj9zuoWFWThk3LUKKU"",""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
                                 }";

                var configuration = new Configuration();
                configuration.Scopes = new HashSet<string> { "okta.users.read" };
                configuration.ClientId = clientId;
                configuration.PrivateKey = new JsonWebKeyConfiguration(jsonPrivateKey);
                configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
                configuration.OktaDomain = oktaDomain;

                var oauthUsersApi = new UserApi(configuration);
                
                var usersCollection = oauthUsersApi.ListUsers(limit:1);
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
                requestOptions = getBasicRequestOptions();
                await apiClient.DeleteAsync<JsonObject>($"/oauth2/v1/clients/{clientId}", requestOptions, Configuration.GetConfigurationOrDefault());
                await userApi.DeactivateUserAsync(createdUser1.Id);
                await userApi.DeleteUserAsync(createdUser1.Id);
                await userApi.DeactivateUserAsync(createdUser2.Id);
                await userApi.DeleteUserAsync(createdUser2.Id);
            }
        }

        [Fact]
        public async Task ListUsersWithPaginationAndRetry()
        {
            var guid = Guid.NewGuid();
            var payload = $@"{{
                                ""client_name"": ""dotnet-sdk: {nameof(ListUsersWithPagination)} {guid}"",
                                ""response_types"": [
                                  ""token""
                                ],
                                ""grant_types"": [
                                  ""client_credentials""
                                ],
                                ""token_endpoint_auth_method"": ""private_key_jwt"",
                                ""application_type"": ""service"",
                                ""jwks"": {{
    	                            ""keys"": [
      		                            {{
                                            ""kty"":""RSA"",
                                            ""e"":""AQAB"",
                                            ""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
                                        }}   
                                   ]
                                }}
                             }}";

            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain;

            // Remove '/' at the end since endpoint fails otherwise
            oktaDomain = oktaDomain.Remove(oktaDomain.Length - 1);

            var apiClient = new ApiClient(oktaDomain);
            var userApi = new UserApi();

            var grantPayload = $@"{{
                                        ""scopeId"" : ""okta.users.read"",
                                        ""issuer"" : ""{oktaDomain}""
                                    }}";



            var requestOptions = getBasicRequestOptions();
            requestOptions.Data = JObject.Parse(payload);

            var serviceResponse = await apiClient.PostAsync<JsonObject>("/oauth2/v1/clients", requestOptions);

            var clientId = serviceResponse.Data["client_id"].ToString();

            var roleAssignmentPayload = $@"{{'type':'SUPER_ADMIN'}}";
            var roleAssignmentRequest = getBasicRequestOptions();
            roleAssignmentRequest.Data = JObject.Parse(roleAssignmentPayload);

            var roleAssignmentResponse = await apiClient.PostAsync<JsonObject>($"/oauth2/v1/clients/{clientId}/roles", roleAssignmentRequest);


            var createUserRequest1 = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = nameof(GetUserWithAccessToken),
                    Email = $"john-{nameof(GetUserWithAccessToken)}-dotnet-sdk-{guid}@example.com",
                    Login = $"john-{nameof(GetUserWithAccessToken)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"johny-{nameof(GetUserWithAccessToken)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    }
                }
            };

            var createdUser1 = await userApi.CreateUserAsync(createUserRequest1);

            var createUserRequest2 = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "Bob",
                    LastName = nameof(GetUserWithAccessToken),
                    Email = $"bob-{nameof(GetUserWithAccessToken)}-dotnet-sdk-{guid}@example.com",
                    Login = $"bob-{nameof(GetUserWithAccessToken)}-dotnet-sdk-{guid}@example.com",
                    NickName = $"bobby-{nameof(GetUserWithAccessToken)}-{guid}",
                },
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "Abcd1234"
                    }
                }
            };

            var createdUser2 = await userApi.CreateUserAsync(createUserRequest2);

            // this delay and the below retry policy are to handle:
            // https://developer.okta.com/docs/api/resources/users.html#list-users-with-search
            // "Queries data from a replicated store, so changes aren’t always immediately available in search results."
            await Task.Delay(3000);

            try
            {

                requestOptions = getBasicRequestOptions();
                requestOptions.Data = JObject.Parse(grantPayload);

                // Add grant to the service
                var grantResponse = await apiClient.PostAsync<JsonObject>($"/api/v1/apps/{clientId}/grants", requestOptions);


                // Use OAuth to get list of users
                var jsonPrivateKey = @"{
                                    ""p"":""2-8pgwYv9jrkM2KsbnQmnJZnr69Rsj95M20I1zx5HhM3tgjGSa7d_dELPRkp9Usy8UGISt7eUHpYOVl529irHwbXevuId1Q804aQ_AtNJwpbRY48rw2T8LdtyVSaEyoFMCa8PJwtzZYzKJCKAe5eoXvW5zxB65RaIct0igYcoIs"",
                                    ""kty"":""RSA"",
                                    ""q"":""slkNUY_SCIn95ip7HoPs_IIiNoKOGeesIV1gacyoAycly1vBPMhtar9gwx51nN1tCMVGlSOk583eRJe2omAbqkIEYm1jSWtMdJKQSOJvx812xbF1afMgJDlJ6iRIlcnWEYhNNMCK5s_UR5zE0Mc5jktxDFeiEatriyu6o9hQix8"",
                                    ""d"":""LIpJTKCi9hPTiuUU954hayd3lXNwTVS6Fdny2iUj6iZ22eRp1V_UswECuMy5B-8lWbp1Gu_eASvhElSCB26m3UgHRVy8LP6Lmvm9VlJuZ5NtOK5D0R-gzFLINGdQH1PehzEc44jsTWyu297lgCLrVy-VScHQJodni3txTzxY4jwjILMfLB7OWdKVkvDQ4g70BYTVN5kZKjA9B0lLsofi1gUY_EVlojuvSKbm3HY0JR_JThtEd_nZw_tXTYmlP58plVYX-9JnA8NcFRB6dUNO7XqcXU1SafWqoM9yam1nGSMYRknwjSSTKRdBXHSy7PVxVHhpC72wb3aWNsOqWNo0ZQ"",
                                    ""e"":""AQAB"",
                                    ""qi"":""u1mS53N4BUSoMeOHFd0o4_n3QGH4izNUsiJVBIkv_UZUAk4LYudPEikTWRLqWsrcXmOyZYao5sSaZyt-B2XCkfdnkIhl-Q7b0_W0yt3Eh5XjAzH9oy5Dklog255lh-Y0yoWXvLjq-KEDs7Nd2uIT4gvKU4ymTqybvzazr2jY9qQ"",""dp"":""nCtPBsK1-9oFgJdoaWYApOAH8DBFipSXs3SQ-oTuW_S5coD4jAmniDuQB2p-6LblDXrDFKb8pZi6XL60UO-hUv7As4s4c8NVDb5X5SEBP9-Sv-koHgU-L4eQZY21ejY0SOS4dTFRNNKasQsxc_2XJIOTLc8T3_wPpD-cGQYN_dE"",""dq"":""ZWb4iZ0qICzFLW6N3gXIYrFi3ndQcC4m0jmTLdRs2o4RkRQ0RGj4vS7ex1G0MWI8MjZoMTe49Qs6Cunvr1bRo_YxI_1p7D6Tk9wZKTeFsqaBl1mUlo7jgXUJL5U9p9zAV-uVah7nWuBjo-vgg4wij2MZfZj9zuoWFWThk3LUKKU"",""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
                                 }";

                var configuration = new Configuration();
                configuration.Scopes = new HashSet<string> { "okta.users.read" };
                configuration.ClientId = clientId;
                configuration.PrivateKey = new JsonWebKeyConfiguration(jsonPrivateKey);
                configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
                configuration.OktaDomain = oktaDomain;


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
                requestOptions = getBasicRequestOptions();
                await apiClient.DeleteAsync<JsonObject>($"/oauth2/v1/clients/{clientId}", requestOptions, Configuration.GetConfigurationOrDefault());
                await userApi.DeactivateUserAsync(createdUser1.Id);
                await userApi.DeleteUserAsync(createdUser1.Id);
                await userApi.DeactivateUserAsync(createdUser2.Id);
                await userApi.DeleteUserAsync(createdUser2.Id);
            }
        }



        private RequestOptions getBasicRequestOptions()
        {
            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json"
            };

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

            // authentication (API_Token) required
            if (!string.IsNullOrEmpty(Configuration.GetConfigurationOrDefault().GetApiKeyWithPrefix("Authorization")))
            {
                requestOptions.HeaderParameters.Add("Authorization", Configuration.GetConfigurationOrDefault().GetApiKeyWithPrefix("Authorization"));
            }

            return requestOptions;
        }

        /// <summary>
        /// Mock to test retry when using private key. The first time, the token will be invalid forcing a legit token retrieval.
        /// </summary>
        public class MockOAuthProvider : IOAuthTokenProvider
        {
            private IOAuthTokenProvider _defaulTokenProvider;
            private int _counter;
            private Queue<string> _tokensQueue;

            public Queue<string> TokensQueue
            {
                get { return _tokensQueue; }
            }
            public MockOAuthProvider(DefaultOAuthTokenProvider defaultProvider)
            {
                _defaulTokenProvider = defaultProvider;
                _counter = 0;
                _tokensQueue = new Queue<string>();

            }
            public Task<string> GetAccessTokenAsync(bool forceRenew = false, CancellationToken cancellationToken = default)
            {
                
                if (_counter == 0)
                {
                    _tokensQueue.Enqueue("invalidToken");
                    _counter++;
                    return Task.FromResult("invalidToken");
                }

                _counter++;
                _tokensQueue.Enqueue("validToken");
                return _defaulTokenProvider.GetAccessTokenAsync(forceRenew);
            }

            public AsyncPolicy<IRestResponse> GetOAuthRetryPolicy(Func<DelegateResult<IRestResponse>, int, Context, Task> onRetryAsyncFunc = null)
            {
                return _defaulTokenProvider.GetOAuthRetryPolicy(onRetryAsyncFunc);
            }
        }
    }
}
