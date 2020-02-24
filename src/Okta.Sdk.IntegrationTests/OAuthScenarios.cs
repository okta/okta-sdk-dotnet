// <copyright file="OAuthScenarios.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Okta.Sdk.Configuration;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    public class OAuthScenarios
    {
        [Fact]
        public async Task ListUsers()
        {
            var client = TestClient.Create();
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

            // Register new service
            var service = await client.PostAsync<Resource>(new HttpRequest()
            {
                Uri = $"/oauth2/v1/clients",
                Payload = JObject.Parse(payload),
            });

            // Create a user so I can assert user list is not empty afterward
            var profile = new UserProfile
            {
                FirstName = "John",
                LastName = "OAuth-List-Users",
                Email = $"john-list-users-dotnet-sdk-{guid}@example.com",
                Login = $"john-list-users-dotnet-sdk-{guid}@example.com",
            };
            profile["nickName"] = "johny-list-users";

            var createdUser = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = profile,
                Password = "Abcd1234",
            });


            try
            {
                // Remove '/' at the end since endpoint fails otherwise
                var oktaDomain = client.Configuration.OktaDomain.Remove(client.Configuration.OktaDomain.Length - 1);

                var grantPayload = $@"{{
                                        ""scopeId"" : ""okta.users.read"",
                                        ""issuer"" : ""{oktaDomain}""
                                    }}";
                // Add grant to the service
                var grantResponse = await client.PostAsync<Resource>(new HttpRequest()
                {
                    Uri = $"/api/v1/apps/{service.GetProperty<string>("client_id")}/grants",
                    Payload = JObject.Parse(grantPayload),
                });

                // Use OAuth to get list of users
                var jsonPrivateKey = @"{
                                    ""p"":""2-8pgwYv9jrkM2KsbnQmnJZnr69Rsj95M20I1zx5HhM3tgjGSa7d_dELPRkp9Usy8UGISt7eUHpYOVl529irHwbXevuId1Q804aQ_AtNJwpbRY48rw2T8LdtyVSaEyoFMCa8PJwtzZYzKJCKAe5eoXvW5zxB65RaIct0igYcoIs"",
                                    ""kty"":""RSA"",
                                    ""q"":""slkNUY_SCIn95ip7HoPs_IIiNoKOGeesIV1gacyoAycly1vBPMhtar9gwx51nN1tCMVGlSOk583eRJe2omAbqkIEYm1jSWtMdJKQSOJvx812xbF1afMgJDlJ6iRIlcnWEYhNNMCK5s_UR5zE0Mc5jktxDFeiEatriyu6o9hQix8"",
                                    ""d"":""LIpJTKCi9hPTiuUU954hayd3lXNwTVS6Fdny2iUj6iZ22eRp1V_UswECuMy5B-8lWbp1Gu_eASvhElSCB26m3UgHRVy8LP6Lmvm9VlJuZ5NtOK5D0R-gzFLINGdQH1PehzEc44jsTWyu297lgCLrVy-VScHQJodni3txTzxY4jwjILMfLB7OWdKVkvDQ4g70BYTVN5kZKjA9B0lLsofi1gUY_EVlojuvSKbm3HY0JR_JThtEd_nZw_tXTYmlP58plVYX-9JnA8NcFRB6dUNO7XqcXU1SafWqoM9yam1nGSMYRknwjSSTKRdBXHSy7PVxVHhpC72wb3aWNsOqWNo0ZQ"",
                                    ""e"":""AQAB"",
                                    ""qi"":""u1mS53N4BUSoMeOHFd0o4_n3QGH4izNUsiJVBIkv_UZUAk4LYudPEikTWRLqWsrcXmOyZYao5sSaZyt-B2XCkfdnkIhl-Q7b0_W0yt3Eh5XjAzH9oy5Dklog255lh-Y0yoWXvLjq-KEDs7Nd2uIT4gvKU4ymTqybvzazr2jY9qQ"",""dp"":""nCtPBsK1-9oFgJdoaWYApOAH8DBFipSXs3SQ-oTuW_S5coD4jAmniDuQB2p-6LblDXrDFKb8pZi6XL60UO-hUv7As4s4c8NVDb5X5SEBP9-Sv-koHgU-L4eQZY21ejY0SOS4dTFRNNKasQsxc_2XJIOTLc8T3_wPpD-cGQYN_dE"",""dq"":""ZWb4iZ0qICzFLW6N3gXIYrFi3ndQcC4m0jmTLdRs2o4RkRQ0RGj4vS7ex1G0MWI8MjZoMTe49Qs6Cunvr1bRo_YxI_1p7D6Tk9wZKTeFsqaBl1mUlo7jgXUJL5U9p9zAV-uVah7nWuBjo-vgg4wij2MZfZj9zuoWFWThk3LUKKU"",""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
                                 }";

                var configuration = new OktaClientConfiguration();
                configuration.Scopes = new List<string> { "okta.users.read" };
                configuration.ClientId = service.GetProperty<string>("client_id");
                configuration.PrivateKey = new JsonWebKeyConfiguration(jsonPrivateKey);
                configuration.AuthorizationMode = AuthorizationMode.PrivateKey;

                var oAuthClient = TestClient.Create(configuration);

                var users = await oAuthClient.Users.ListUsers().ToArrayAsync();

                users.Should().NotBeEmpty();
            }
            finally
            {
                // Delete user
                await createdUser.DeactivateAsync();
                await createdUser.DeactivateOrDeleteAsync();

                // Delete service
                await client.DeleteAsync(new HttpRequest()
                {
                    Uri = $"/oauth2/v1/clients/{service.GetProperty<string>("client_id")}",
                });
            }
        }
    }
}
