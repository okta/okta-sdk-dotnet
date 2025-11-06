// <copyright file="UserLinkedObjectApiTests.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using FluentAssertions;
using Newtonsoft.Json.Linq;
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
    [Collection(nameof(UserLinkedObjectApiTests))]
    public class UserLinkedObjectApiTests : IDisposable
    {
        private readonly UserLinkedObjectApi _userLinkedObjectApi = new();
        private readonly LinkedObjectApi _linkedObjectApi = new();
        private readonly UserApi _userApi = new();
        private readonly List<string> _createdUserIds = [];
        private readonly List<string> _createdLinkedObjectNames = [];

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
                catch (ApiException) { }
            }
            _createdUserIds.Clear();

            foreach (var linkedObjectName in _createdLinkedObjectNames)
            {
                try
                {
                    await _linkedObjectApi.DeleteLinkedObjectDefinitionAsync(linkedObjectName);
                }
                catch (ApiException) { }
            }
            _createdLinkedObjectNames.Clear();
        }

        [Fact]
        public async Task GivenLinkedObjects_WhenPerformingCrudOperations_ThenAllEndpointsAndMethodsWork()
        {
            var guid = Guid.NewGuid();
            
            var serviceClientPayload = $@"{{
                ""client_name"": ""dotnet-sdk: UserLinkedObject StandardMethods {guid}"",
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

            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain.TrimEnd('/');
            var apiClient = new ApiClient(oktaDomain);
            var requestOptions = GetBasicRequestOptions();
            requestOptions.Data = JObject.Parse(serviceClientPayload);

            var serviceResponse = await apiClient.PostAsync<JObject>("/oauth2/v1/clients", requestOptions);
            var clientId = serviceResponse.Data["client_id"]?.ToString();

            try
            {
                var roleAssignmentPayload = @"{""type"":""SUPER_ADMIN""}";
                var roleAssignmentRequest = GetBasicRequestOptions();
                roleAssignmentRequest.Data = JObject.Parse(roleAssignmentPayload);
                await apiClient.PostAsync<JObject>($"/oauth2/v1/clients/{clientId}/roles", roleAssignmentRequest);

                var usersGrantPayload = $@"{{""scopeId"": ""okta.users.manage"", ""issuer"": ""{oktaDomain}""}}";
                var linkedObjectsGrantPayload = $@"{{""scopeId"": ""okta.linkedObjects.manage"", ""issuer"": ""{oktaDomain}""}}";

                requestOptions = GetBasicRequestOptions();
                requestOptions.Data = JObject.Parse(usersGrantPayload);
                await apiClient.PostAsync<JObject>($"/api/v1/apps/{clientId}/grants", requestOptions);

                requestOptions = GetBasicRequestOptions();
                requestOptions.Data = JObject.Parse(linkedObjectsGrantPayload);
                await apiClient.PostAsync<JObject>($"/api/v1/apps/{clientId}/grants", requestOptions);

                await Task.Delay(2000);

                var jsonPrivateKey = @"{
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

                var oauthConfiguration = new Configuration
                {
                    Scopes = ["okta.users.manage", "okta.linkedObjects.manage"],
                    ClientId = clientId,
                    PrivateKey = new JsonWebKeyConfiguration(jsonPrivateKey),
                    AuthorizationMode = AuthorizationMode.PrivateKey,
                    OktaDomain = oktaDomain
                };

                var oauthUserLinkedObjectApi = new UserLinkedObjectApi(oauthConfiguration);
                var oauthLinkedObjectApi = new LinkedObjectApi(oauthConfiguration);
                var oauthUserApi = new UserApi(oauthConfiguration);

                var linkedObjectDefinition = new LinkedObject
                {
                    Primary = new LinkedObjectDetails
                    {
                        Name = $"mgr{guid.ToString().Replace("-", "")}",
                        Title = "Manager",
                        Description = "Manager relationship",
                        Type = LinkedObjectDetailsType.USER
                    },
                    Associated = new LinkedObjectDetails
                    {
                        Name = $"sub{guid.ToString().Replace("-", "")}",
                        Title = "Subordinate",
                        Description = "Subordinate relationship",
                        Type = LinkedObjectDetailsType.USER
                    }
                };

                var createdLinkedObject = await oauthLinkedObjectApi.CreateLinkedObjectDefinitionAsync(linkedObjectDefinition);
                _createdLinkedObjectNames.Add(createdLinkedObject.Primary.Name);

                var primaryRelationshipName = createdLinkedObject.Primary.Name;
                var associatedRelationshipName = createdLinkedObject.Associated.Name;

                await Task.Delay(2000);

                var managerUser = new CreateUserRequest
                {
                    Profile = new UserProfile
                    {
                        FirstName = "Manager",
                        LastName = "Standard",
                        Email = $"mgr-std-{guid}@example.com",
                        Login = $"mgr-std-{guid}@example.com"
                    },
                    Credentials = new UserCredentialsWritable
                    {
                        Password = new PasswordCredential { Value = "P@ssw0rd!2024" }
                    }
                };

                var subordinateUser = new CreateUserRequest
                {
                    Profile = new UserProfile
                    {
                        FirstName = "Subordinate",
                        LastName = "Standard",
                        Email = $"sub-std-{guid}@example.com",
                        Login = $"sub-std-{guid}@example.com"
                    },
                    Credentials = new UserCredentialsWritable
                    {
                        Password = new PasswordCredential { Value = "P@ssw0rd!2024" }
                    }
                };

                var createdManager = await oauthUserApi.CreateUserAsync(managerUser, activate: true);
                var createdSubordinate = await oauthUserApi.CreateUserAsync(subordinateUser, activate: true);

                _createdUserIds.Add(createdManager.Id);
                _createdUserIds.Add(createdSubordinate.Id);

                await Task.Delay(2000);

                // CREATE: AssignLinkedObjectValueForPrimaryAsync
                await oauthUserLinkedObjectApi.AssignLinkedObjectValueForPrimaryAsync(
                    createdSubordinate.Id,
                    primaryRelationshipName,
                    createdManager.Id
                );

                await Task.Delay(2000);

                // READ: ListLinkedObjectsForUser - verify from subordinate perspective
                var subordinateLinks = await oauthUserLinkedObjectApi.ListLinkedObjectsForUser(
                    createdSubordinate.Id,
                    primaryRelationshipName
                ).ToListAsync();

                subordinateLinks.Should().NotBeNull();
                subordinateLinks.Should().HaveCount(1, "Subordinate should have one manager");
                subordinateLinks.First().Links.Self.Href.Should().Contain(createdManager.Id);

                // READ: ListLinkedObjectsForUser - verify from manager perspective
                var managerSubordinates = await oauthUserLinkedObjectApi.ListLinkedObjectsForUser(
                    createdManager.Id,
                    associatedRelationshipName
                ).ToListAsync();

                managerSubordinates.Should().NotBeNull();
                managerSubordinates.Should().HaveCount(1, "Manager should have one subordinate");
                managerSubordinates.First().Links.Self.Href.Should().Contain(createdSubordinate.Id);

                // DELETE: DeleteLinkedObjectForUserAsync
                await oauthUserLinkedObjectApi.DeleteLinkedObjectForUserAsync(
                    createdSubordinate.Id,
                    primaryRelationshipName
                );

                await Task.Delay(2000);

                // Verify deletion
                var linksAfterDelete = await oauthUserLinkedObjectApi.ListLinkedObjectsForUser(
                    createdSubordinate.Id,
                    primaryRelationshipName
                ).ToListAsync();

                linksAfterDelete.Should().BeEmpty("Relationship should be deleted");
            }
            finally
            {
                requestOptions = GetBasicRequestOptions();
                await apiClient.DeleteAsync<JObject>($"/oauth2/v1/clients/{clientId}", requestOptions, Configuration.GetConfigurationOrDefault());
            }
        }

        [Fact]
        public async Task GivenHttpInfoMethods_WhenCallingApi_ThenHttpMetadataIsReturned()
        {
            var guid = Guid.NewGuid();

            // Setup: Create linked object definition with API Token
            var linkedObjectDefinition = new LinkedObject
            {
                Primary = new LinkedObjectDetails
                {
                    Name = $"mgr{guid.ToString().Replace("-", "")}",
                    Title = "Manager",
                    Description = "Manager relationship",
                    Type = LinkedObjectDetailsType.USER
                },
                Associated = new LinkedObjectDetails
                {
                    Name = $"sub{guid.ToString().Replace("-", "")}",
                    Title = "Subordinate",
                    Description = "Subordinate relationship",
                    Type = LinkedObjectDetailsType.USER
                }
            };

            var createdLinkedObject = await _linkedObjectApi.CreateLinkedObjectDefinitionAsync(linkedObjectDefinition);
            _createdLinkedObjectNames.Add(createdLinkedObject.Primary.Name);

            var primaryRelationshipName = createdLinkedObject.Primary.Name;

            await Task.Delay(2000);

            // Setup: Create test users with API Token
            var managerUser = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "Manager",
                    LastName = "HttpInfo",
                    Email = $"mgr-{guid}@example.com",
                    Login = $"mgr-{guid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "P@ssw0rd!2024" }
                }
            };

            var subordinateUser = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "Subordinate",
                    LastName = "HttpInfo",
                    Email = $"sub-{guid}@example.com",
                    Login = $"sub-{guid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "P@ssw0rd!2024" }
                }
            };

            var createdManager = await _userApi.CreateUserAsync(managerUser, activate: true);
            var createdSubordinate = await _userApi.CreateUserAsync(subordinateUser, activate: true);

            _createdUserIds.Add(createdManager.Id);
            _createdUserIds.Add(createdSubordinate.Id);

            await Task.Delay(2000);

            // READ (empty): ListLinkedObjectsForUserWithHttpInfoAsync - HTTP 200
            var initialReadResponse = await _userLinkedObjectApi.ListLinkedObjectsForUserWithHttpInfoAsync(
                createdSubordinate.Id,
                primaryRelationshipName
            );

            initialReadResponse.Should().NotBeNull();
            initialReadResponse.StatusCode.Should().Be(HttpStatusCode.OK, "GET should return 200");
            initialReadResponse.Data.Should().BeEmpty("No relationships established yet");

            // Now setup OAuth2 for CREATE operations
            var serviceClientPayload = $@"{{
                ""client_name"": ""dotnet-sdk: UserLinkedObject HttpInfo Test {guid}"",
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

            var oktaDomain = Configuration.GetConfigurationOrDefault().OktaDomain.TrimEnd('/');
            var apiClient = new ApiClient(oktaDomain);
            var requestOptions = GetBasicRequestOptions();
            requestOptions.Data = JObject.Parse(serviceClientPayload);

            var serviceResponse = await apiClient.PostAsync<JObject>("/oauth2/v1/clients", requestOptions);
            var clientId = serviceResponse.Data["client_id"]?.ToString();

            try
            {
                // Assign SUPER_ADMIN role
                var roleAssignmentPayload = @"{""type"":""SUPER_ADMIN""}";
                var roleAssignmentRequest = GetBasicRequestOptions();
                roleAssignmentRequest.Data = JObject.Parse(roleAssignmentPayload);
                await apiClient.PostAsync<JObject>($"/oauth2/v1/clients/{clientId}/roles", roleAssignmentRequest);

                // Grant scopes
                var usersGrantPayload = $@"{{""scopeId"": ""okta.users.manage"", ""issuer"": ""{oktaDomain}""}}";
                var linkedObjectsGrantPayload = $@"{{""scopeId"": ""okta.linkedObjects.manage"", ""issuer"": ""{oktaDomain}""}}";

                requestOptions = GetBasicRequestOptions();
                requestOptions.Data = JObject.Parse(usersGrantPayload);
                await apiClient.PostAsync<JObject>($"/api/v1/apps/{clientId}/grants", requestOptions);

                requestOptions = GetBasicRequestOptions();
                requestOptions.Data = JObject.Parse(linkedObjectsGrantPayload);
                await apiClient.PostAsync<JObject>($"/api/v1/apps/{clientId}/grants", requestOptions);

                await Task.Delay(3000);

                // Configure OAuth2
                var jsonPrivateKey = @"{
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

                var oauthConfiguration = new Configuration
                {
                    Scopes = ["okta.users.manage", "okta.linkedObjects.manage"],
                    ClientId = clientId,
                    PrivateKey = new JsonWebKeyConfiguration(jsonPrivateKey),
                    AuthorizationMode = AuthorizationMode.PrivateKey,
                    OktaDomain = oktaDomain
                };

                var oauthUserLinkedObjectApi = new UserLinkedObjectApi(oauthConfiguration);

                // CREATE: AssignLinkedObjectValueForPrimaryWithHttpInfoAsync - HTTP 204
                var createResponse = await oauthUserLinkedObjectApi.AssignLinkedObjectValueForPrimaryWithHttpInfoAsync(
                    createdSubordinate.Id,
                    primaryRelationshipName,
                    createdManager.Id
                );

                createResponse.Should().NotBeNull();
                createResponse.StatusCode.Should().Be(HttpStatusCode.NoContent, "PUT should return 204");

                await Task.Delay(2000);

                // READ (with data): ListLinkedObjectsForUserWithHttpInfoAsync - HTTP 200 using API Token
                var readResponse = await _userLinkedObjectApi.ListLinkedObjectsForUserWithHttpInfoAsync(
                    createdSubordinate.Id,
                    primaryRelationshipName
                );

                readResponse.Should().NotBeNull();
                readResponse.StatusCode.Should().Be(HttpStatusCode.OK, "GET should return 200");
                readResponse.Data.Should().HaveCount(1, "One relationship should exist");
                readResponse.Data.First().Links.Self.Href.Should().Contain(createdManager.Id);

                // DELETE: DeleteLinkedObjectForUserWithHttpInfoAsync - HTTP 204 using API Token
                var deleteResponse = await _userLinkedObjectApi.DeleteLinkedObjectForUserWithHttpInfoAsync(
                    createdSubordinate.Id,
                    primaryRelationshipName
                );

                deleteResponse.Should().NotBeNull();
                deleteResponse.StatusCode.Should().Be(HttpStatusCode.NoContent, "DELETE should return 204");

                await Task.Delay(2000);

                // Verify deletion using API Token
                var verifyResponse = await _userLinkedObjectApi.ListLinkedObjectsForUserWithHttpInfoAsync(
                    createdSubordinate.Id,
                    primaryRelationshipName
                );

                verifyResponse.StatusCode.Should().Be(HttpStatusCode.OK);
                verifyResponse.Data.Should().BeEmpty("Relationship should be deleted");
            }
            finally
            {
                requestOptions = GetBasicRequestOptions();
                await apiClient.DeleteAsync<JObject>($"/oauth2/v1/clients/{clientId}", requestOptions, Configuration.GetConfigurationOrDefault());
            }
        }

        [Fact]
        public async Task GivenErrorScenarios_WhenCallingApi_ThenApiExceptionIsThrown()
        {
            var guid = Guid.NewGuid();

            // Setup: Create valid test data
            var linkedObjectDefinition = new LinkedObject
            {
                Primary = new LinkedObjectDetails
                {
                    Name = $"error{guid.ToString().Replace("-", "")}",
                    Title = "Error Test",
                    Description = "For error testing",
                    Type = LinkedObjectDetailsType.USER
                },
                Associated = new LinkedObjectDetails
                {
                    Name = $"errorAssoc{guid.ToString().Replace("-", "")}",
                    Title = "Error Test Associated",
                    Description = "For error testing",
                    Type = LinkedObjectDetailsType.USER
                }
            };

            var createdLinkedObject = await _linkedObjectApi.CreateLinkedObjectDefinitionAsync(linkedObjectDefinition);
            _createdLinkedObjectNames.Add(createdLinkedObject.Primary.Name);

            await Task.Delay(2000);

            var testUser = new CreateUserRequest
            {
                Profile = new UserProfile
                {
                    FirstName = "Error",
                    LastName = "Test",
                    Email = $"error-{guid}@example.com",
                    Login = $"error-{guid}@example.com"
                },
                Credentials = new UserCredentialsWritable
                {
                    Password = new PasswordCredential { Value = "P@ssw0rd!2024" }
                }
            };

            var createdUser = await _userApi.CreateUserAsync(testUser, activate: true);
            _createdUserIds.Add(createdUser.Id);

            await Task.Delay(2000);

            // ListLinkedObjectsForUser with invalid relationship - 404
            var listInvalidRelationship = async () => await _userLinkedObjectApi.ListLinkedObjectsForUser(
                createdUser.Id,
                "non_existent_relationship"
            ).ToListAsync();

            var ex1 = await listInvalidRelationship.Should().ThrowAsync<ApiException>();
            ex1.Which.ErrorCode.Should().Be((int)HttpStatusCode.NotFound);

            // ListLinkedObjectsForUserWithHttpInfoAsync with invalid user - 404
            var listInvalidUser = async () => await _userLinkedObjectApi.ListLinkedObjectsForUserWithHttpInfoAsync(
                "invalid_user_id",
                createdLinkedObject.Primary.Name
            );

            var ex2 = await listInvalidUser.Should().ThrowAsync<ApiException>();
            ex2.Which.ErrorCode.Should().Be((int)HttpStatusCode.NotFound);

            // DeleteLinkedObjectForUserAsync with invalid relationship - 404
            var deleteInvalidRelationship = async () => await _userLinkedObjectApi.DeleteLinkedObjectForUserAsync(
                createdUser.Id,
                "non_existent_relationship"
            );

            var ex3 = await deleteInvalidRelationship.Should().ThrowAsync<ApiException>();
            ex3.Which.ErrorCode.Should().Be((int)HttpStatusCode.NotFound);

            // DeleteLinkedObjectForUserWithHttpInfoAsync with invalid user - 404
            var deleteInvalidUser = async () => await _userLinkedObjectApi.DeleteLinkedObjectForUserWithHttpInfoAsync(
                "invalid_user_id",
                createdLinkedObject.Primary.Name
            );

            var ex4 = await deleteInvalidUser.Should().ThrowAsync<ApiException>();
            ex4.Which.ErrorCode.Should().Be((int)HttpStatusCode.NotFound);

            // AssignLinkedObjectValueForPrimaryAsync with invalid users
            var assignInvalidUsers = async () => await _userLinkedObjectApi.AssignLinkedObjectValueForPrimaryAsync(
                "invalid_user_1",
                createdLinkedObject.Primary.Name,
                "invalid_user_2"
            );

            await assignInvalidUsers.Should().ThrowAsync<ApiException>();

            // AssignLinkedObjectValueForPrimaryWithHttpInfoAsync with invalid relationship
            var assignInvalidRelationship = async () => await _userLinkedObjectApi.AssignLinkedObjectValueForPrimaryWithHttpInfoAsync(
                createdUser.Id,
                "non_existent_relationship",
                createdUser.Id
            );

            await assignInvalidRelationship.Should().ThrowAsync<ApiException>();
        }

        private RequestOptions GetBasicRequestOptions()
        {
            var requestOptions = new RequestOptions();
            
            string[] contentTypes = ["application/json"];
            string[] accepts = ["application/json"];

            var contentType = ClientUtils.SelectHeaderContentType(contentTypes);
            if (contentType != null)
            {
                requestOptions.HeaderParameters.Add("Content-Type", contentType);
            }

            var accept = ClientUtils.SelectHeaderAccept(accepts);
            if (accept != null)
            {
                requestOptions.HeaderParameters.Add("Accept", accept);
            }

            var apiKey = Configuration.GetConfigurationOrDefault().GetApiKeyWithPrefix("Authorization");
            if (!string.IsNullOrEmpty(apiKey))
            {
                requestOptions.HeaderParameters.Add("Authorization", apiKey);
            }

            return requestOptions;
        }
    }
}
