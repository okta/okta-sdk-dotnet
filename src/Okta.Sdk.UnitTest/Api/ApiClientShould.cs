// using System;
// using System.Linq;
// using System.Net;
// using Xunit;
// using System.Threading.Tasks;
// using FluentAssertions;
// using Okta.Sdk.UnitTest.Internal;
// using Okta.Sdk.Api;
// using Okta.Sdk.Client;
// using Okta.Sdk.Model;
// using Polly;
// using RestSharp;
// using System.Collections.Generic;
// using System.IO;
// using Newtonsoft.Json;
// using RichardSzalay.MockHttp;
//
// namespace Okta.Sdk.UnitTest.Api
// {
//     public class ApiClientShould
//     {
//         [Fact]
//         public void SendUserAgent()
//         {
//
//             var apiClient = new ApiClient();
//             var client = apiClient.GetConfiguredClient(new Configuration());
//
//             client.Options.UserAgent.Should().Contain("okta-sdk-dotnet");
//         }
//
//         [Fact]
//         public void UseProxySetViaConfiguration()
//         {
//
//             var apiClient = new ApiClient();
//             var configuration = new Configuration
//             {
//                 Proxy = new ProxyConfiguration
//                 {
//                     Host = "foo.com",
//                     Port = 8081,
//                     Username = "bar",
//                     Password = "baz"
//
//                 }
//             };
//
//             var client = apiClient.GetConfiguredClient(configuration);
//             client.Options.Proxy.Should().NotBeNull();
//
//             var webProxy = (WebProxy)client.Options.Proxy;
//             webProxy.Address.ToString().Should().Be("http://foo.com:8081/");
//             webProxy.Credentials.Should().NotBeNull();
//
//             ((NetworkCredential)webProxy.Credentials).UserName.Should().Be("bar");
//             ((NetworkCredential)webProxy.Credentials).Password.Should().Be("baz");
//         }
//
//         [Fact]
//         public void UseProxySetViaConstructor()
//         {
//             var proxy = new WebProxy("foo.com", 8081);
//             proxy.Credentials = new NetworkCredential("bar", "baz");
//             
//             var apiClient = new ApiClient(webProxy: proxy);
//
//             var client = apiClient.GetConfiguredClient(new Configuration());
//             client.Options.Proxy.Should().NotBeNull();
//
//             var webProxy = (WebProxy)client.Options.Proxy;
//             webProxy.Address.ToString().Should().Be("http://foo.com:8081/");
//             webProxy.Credentials.Should().NotBeNull();
//
//             ((NetworkCredential)webProxy.Credentials).UserName.Should().Be("bar");
//             ((NetworkCredential)webProxy.Credentials).Password.Should().Be("baz");
//         }
//
//         [Fact]
//         public async Task AddHeadersWhenRetrying429Request()
//         {
//             
//             Context pollyContext = new Context();
//             RestRequest request = new RestRequest("https://mytestorg.com/resource", Method.Get);
//
//
//             var jsonPrivateKey = @"{
//                                     ""p"":""2-8pgwYv9jrkM2KsbnQmnJZnr69Rsj95M20I1zx5HhM3tgjGSa7d_dELPRkp9Usy8UGISt7eUHpYOVl529irHwbXevuId1Q804aQ_AtNJwpbRY48rw2T8LdtyVSaEyoFMCa8PJwtzZYzKJCKAe5eoXvW5zxB65RaIct0igYcoIs"",
//                                     ""kty"":""RSA"",
//                                     ""q"":""slkNUY_SCIn95ip7HoPs_IIiNoKOGeesIV1gacyoAycly1vBPMhtar9gwx51nN1tCMVGlSOk583eRJe2omAbqkIEYm1jSWtMdJKQSOJvx812xbF1afMgJDlJ6iRIlcnWEYhNNMCK5s_UR5zE0Mc5jktxDFeiEatriyu6o9hQix8"",
//                                     ""d"":""LIpJTKCi9hPTiuUU954hayd3lXNwTVS6Fdny2iUj6iZ22eRp1V_UswECuMy5B-8lWbp1Gu_eASvhElSCB26m3UgHRVy8LP6Lmvm9VlJuZ5NtOK5D0R-gzFLINGdQH1PehzEc44jsTWyu297lgCLrVy-VScHQJodni3txTzxY4jwjILMfLB7OWdKVkvDQ4g70BYTVN5kZKjA9B0lLsofi1gUY_EVlojuvSKbm3HY0JR_JThtEd_nZw_tXTYmlP58plVYX-9JnA8NcFRB6dUNO7XqcXU1SafWqoM9yam1nGSMYRknwjSSTKRdBXHSy7PVxVHhpC72wb3aWNsOqWNo0ZQ"",
//                                     ""e"":""AQAB"",
//                                     ""qi"":""u1mS53N4BUSoMeOHFd0o4_n3QGH4izNUsiJVBIkv_UZUAk4LYudPEikTWRLqWsrcXmOyZYao5sSaZyt-B2XCkfdnkIhl-Q7b0_W0yt3Eh5XjAzH9oy5Dklog255lh-Y0yoWXvLjq-KEDs7Nd2uIT4gvKU4ymTqybvzazr2jY9qQ"",""dp"":""nCtPBsK1-9oFgJdoaWYApOAH8DBFipSXs3SQ-oTuW_S5coD4jAmniDuQB2p-6LblDXrDFKb8pZi6XL60UO-hUv7As4s4c8NVDb5X5SEBP9-Sv-koHgU-L4eQZY21ejY0SOS4dTFRNNKasQsxc_2XJIOTLc8T3_wPpD-cGQYN_dE"",""dq"":""ZWb4iZ0qICzFLW6N3gXIYrFi3ndQcC4m0jmTLdRs2o4RkRQ0RGj4vS7ex1G0MWI8MjZoMTe49Qs6Cunvr1bRo_YxI_1p7D6Tk9wZKTeFsqaBl1mUlo7jgXUJL5U9p9zAV-uVah7nWuBjo-vgg4wij2MZfZj9zuoWFWThk3LUKKU"",""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
//                                  }";
//
//             var configuration = new Configuration();
//             configuration.Scopes = new HashSet<string> { "okta.users.read" };
//             configuration.ClientId = "foo";
//             configuration.PrivateKey = new JsonWebKeyConfiguration(jsonPrivateKey);
//             configuration.MaxRetries = 2;
//             configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
//
//             var oauthTokenProvider = new DefaultOAuthTokenProvider(configuration, new MockOAuthApi(configuration, isDpop: false));
//             var apiClient = new ApiClient(oauthTokenProvider);
//
//             var mockHttp = new MockHttpMessageHandler();
//
//             mockHttp
//                 .When("https://mytestorg.com/resource")
//                 .Respond(HttpStatusCode.OK, "application/json", "{}");
//
//
//             var client = new RestClient(options: new RestClientOptions { ConfigureMessageHandler = _ => mockHttp });
//
//             pollyContext.Add(DefaultRetryStrategy.XOktaRequestId, "bar");
//             pollyContext.Add(DefaultRetryStrategy.XOktaRetryCountHeader, 2);
//
//             request.Parameters.AddParameter(new HeaderParameter("Authorization", "Bearer myAccessToken"));
//             _ = await apiClient.ExecuteAsyncWithRetryHeadersAsync(pollyContext, request, client, configuration);
//
//            var retryCountHeader = request.Parameters.FirstOrDefault(x => x.Name == DefaultRetryStrategy.XOktaRetryCountHeader);
//            retryCountHeader.Should().NotBeNull();
//            retryCountHeader.Value.ToString().Should().Be("2");
//
//            var requestIdHeader = request.Parameters.FirstOrDefault(x => x.Name == DefaultRetryStrategy.XOktaRetryForHeader);
//            requestIdHeader.Should().NotBeNull();
//            requestIdHeader.Value.Should().Be("bar");
//
//            var authHeader = request.Parameters.FirstOrDefault(x => x.Name == "Authorization");
//            authHeader.Value.Should().Be("Bearer myAccessToken");
//         }
//
//         [Fact]
//         public async Task AddDpopHeadersWhenRetrying429Request()
//         {
//
//             Context pollyContext = new Context();
//             RestRequest request = new RestRequest("https://mytestorg.com/resource", Method.Get);
//
//
//             var jsonPrivateKey = @"{
//                                     ""p"":""2-8pgwYv9jrkM2KsbnQmnJZnr69Rsj95M20I1zx5HhM3tgjGSa7d_dELPRkp9Usy8UGISt7eUHpYOVl529irHwbXevuId1Q804aQ_AtNJwpbRY48rw2T8LdtyVSaEyoFMCa8PJwtzZYzKJCKAe5eoXvW5zxB65RaIct0igYcoIs"",
//                                     ""kty"":""RSA"",
//                                     ""q"":""slkNUY_SCIn95ip7HoPs_IIiNoKOGeesIV1gacyoAycly1vBPMhtar9gwx51nN1tCMVGlSOk583eRJe2omAbqkIEYm1jSWtMdJKQSOJvx812xbF1afMgJDlJ6iRIlcnWEYhNNMCK5s_UR5zE0Mc5jktxDFeiEatriyu6o9hQix8"",
//                                     ""d"":""LIpJTKCi9hPTiuUU954hayd3lXNwTVS6Fdny2iUj6iZ22eRp1V_UswECuMy5B-8lWbp1Gu_eASvhElSCB26m3UgHRVy8LP6Lmvm9VlJuZ5NtOK5D0R-gzFLINGdQH1PehzEc44jsTWyu297lgCLrVy-VScHQJodni3txTzxY4jwjILMfLB7OWdKVkvDQ4g70BYTVN5kZKjA9B0lLsofi1gUY_EVlojuvSKbm3HY0JR_JThtEd_nZw_tXTYmlP58plVYX-9JnA8NcFRB6dUNO7XqcXU1SafWqoM9yam1nGSMYRknwjSSTKRdBXHSy7PVxVHhpC72wb3aWNsOqWNo0ZQ"",
//                                     ""e"":""AQAB"",
//                                     ""qi"":""u1mS53N4BUSoMeOHFd0o4_n3QGH4izNUsiJVBIkv_UZUAk4LYudPEikTWRLqWsrcXmOyZYao5sSaZyt-B2XCkfdnkIhl-Q7b0_W0yt3Eh5XjAzH9oy5Dklog255lh-Y0yoWXvLjq-KEDs7Nd2uIT4gvKU4ymTqybvzazr2jY9qQ"",""dp"":""nCtPBsK1-9oFgJdoaWYApOAH8DBFipSXs3SQ-oTuW_S5coD4jAmniDuQB2p-6LblDXrDFKb8pZi6XL60UO-hUv7As4s4c8NVDb5X5SEBP9-Sv-koHgU-L4eQZY21ejY0SOS4dTFRNNKasQsxc_2XJIOTLc8T3_wPpD-cGQYN_dE"",""dq"":""ZWb4iZ0qICzFLW6N3gXIYrFi3ndQcC4m0jmTLdRs2o4RkRQ0RGj4vS7ex1G0MWI8MjZoMTe49Qs6Cunvr1bRo_YxI_1p7D6Tk9wZKTeFsqaBl1mUlo7jgXUJL5U9p9zAV-uVah7nWuBjo-vgg4wij2MZfZj9zuoWFWThk3LUKKU"",""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
//                                  }";
//
//             var configuration = new Configuration();
//             configuration.Scopes = new HashSet<string> { "okta.users.read" };
//             configuration.ClientId = "foo";
//             configuration.PrivateKey = new JsonWebKeyConfiguration(jsonPrivateKey);
//             configuration.MaxRetries = 2;
//             configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
//
//             Queue<string> tokenReturnQueue = new Queue<string>();
//             tokenReturnQueue.Enqueue("myAccessToken2");
//
//             var oauthTokenProvider = new DefaultOAuthTokenProvider(configuration, new MockOAuthApi(configuration, returnQueue: tokenReturnQueue, isDpop: true));
//             var apiClient = new ApiClient(oauthTokenProvider);
//
//             var mockHttp = new MockHttpMessageHandler();
//
//             mockHttp
//                 .When("https://mytestorg.com/resource")
//                 .Respond(HttpStatusCode.OK, "application/json", "{}");
//
//
//             var client = new RestClient(options: new RestClientOptions { ConfigureMessageHandler = _ => mockHttp });
//
//             pollyContext.Add(DefaultRetryStrategy.XOktaRequestId, "bar");
//             pollyContext.Add(DefaultRetryStrategy.XOktaRetryCountHeader, 2);
//
//             request.Parameters.AddParameter(new HeaderParameter("Authorization", "DPoP myAccessToken"));
//             request.Parameters.AddParameter(new HeaderParameter("DPoP", "myDpopJwt"));
//
//             var dpopHeader = request.Parameters.FirstOrDefault(x => x.Name == "DPoP");
//             dpopHeader.Value.Should().Be("myDpopJwt");
//
//             _ = await apiClient.ExecuteAsyncWithRetryHeadersAsync(pollyContext, request, client, configuration);
//
//             var retryCountHeader = request.Parameters.FirstOrDefault(x => x.Name == DefaultRetryStrategy.XOktaRetryCountHeader);
//             retryCountHeader.Should().NotBeNull();
//             retryCountHeader.Value.ToString().Should().Be("2");
//
//             var requestIdHeader = request.Parameters.FirstOrDefault(x => x.Name == DefaultRetryStrategy.XOktaRetryForHeader);
//             requestIdHeader.Should().NotBeNull();
//             requestIdHeader.Value.Should().Be("bar");
//
//             // Token stays the same when retrying a 429
//             var authHeader = request.Parameters.FirstOrDefault(x => x.Name == "Authorization");
//             authHeader.Value.Should().Be("DPoP myAccessToken");
//
//             dpopHeader = request.Parameters.FirstOrDefault(x => x.Name == "DPoP");
//             dpopHeader.Value.Should().NotBe("myDpopJwt");
//
//         }
//
//         [Fact]
//         public async Task NotUpdateHeadersIfItIsNotRetry()
//         {
//
//             Context pollyContext = new Context();
//             RestRequest request = new RestRequest("https://mytestorg.com/resource", Method.Get);
//
//
//             var jsonPrivateKey = @"{
//                                     ""p"":""2-8pgwYv9jrkM2KsbnQmnJZnr69Rsj95M20I1zx5HhM3tgjGSa7d_dELPRkp9Usy8UGISt7eUHpYOVl529irHwbXevuId1Q804aQ_AtNJwpbRY48rw2T8LdtyVSaEyoFMCa8PJwtzZYzKJCKAe5eoXvW5zxB65RaIct0igYcoIs"",
//                                     ""kty"":""RSA"",
//                                     ""q"":""slkNUY_SCIn95ip7HoPs_IIiNoKOGeesIV1gacyoAycly1vBPMhtar9gwx51nN1tCMVGlSOk583eRJe2omAbqkIEYm1jSWtMdJKQSOJvx812xbF1afMgJDlJ6iRIlcnWEYhNNMCK5s_UR5zE0Mc5jktxDFeiEatriyu6o9hQix8"",
//                                     ""d"":""LIpJTKCi9hPTiuUU954hayd3lXNwTVS6Fdny2iUj6iZ22eRp1V_UswECuMy5B-8lWbp1Gu_eASvhElSCB26m3UgHRVy8LP6Lmvm9VlJuZ5NtOK5D0R-gzFLINGdQH1PehzEc44jsTWyu297lgCLrVy-VScHQJodni3txTzxY4jwjILMfLB7OWdKVkvDQ4g70BYTVN5kZKjA9B0lLsofi1gUY_EVlojuvSKbm3HY0JR_JThtEd_nZw_tXTYmlP58plVYX-9JnA8NcFRB6dUNO7XqcXU1SafWqoM9yam1nGSMYRknwjSSTKRdBXHSy7PVxVHhpC72wb3aWNsOqWNo0ZQ"",
//                                     ""e"":""AQAB"",
//                                     ""qi"":""u1mS53N4BUSoMeOHFd0o4_n3QGH4izNUsiJVBIkv_UZUAk4LYudPEikTWRLqWsrcXmOyZYao5sSaZyt-B2XCkfdnkIhl-Q7b0_W0yt3Eh5XjAzH9oy5Dklog255lh-Y0yoWXvLjq-KEDs7Nd2uIT4gvKU4ymTqybvzazr2jY9qQ"",""dp"":""nCtPBsK1-9oFgJdoaWYApOAH8DBFipSXs3SQ-oTuW_S5coD4jAmniDuQB2p-6LblDXrDFKb8pZi6XL60UO-hUv7As4s4c8NVDb5X5SEBP9-Sv-koHgU-L4eQZY21ejY0SOS4dTFRNNKasQsxc_2XJIOTLc8T3_wPpD-cGQYN_dE"",""dq"":""ZWb4iZ0qICzFLW6N3gXIYrFi3ndQcC4m0jmTLdRs2o4RkRQ0RGj4vS7ex1G0MWI8MjZoMTe49Qs6Cunvr1bRo_YxI_1p7D6Tk9wZKTeFsqaBl1mUlo7jgXUJL5U9p9zAV-uVah7nWuBjo-vgg4wij2MZfZj9zuoWFWThk3LUKKU"",""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
//                                  }";
//
//             var configuration = new Configuration();
//             configuration.Scopes = new HashSet<string> { "okta.users.read" };
//             configuration.ClientId = "foo";
//             configuration.PrivateKey = new JsonWebKeyConfiguration(jsonPrivateKey);
//             configuration.MaxRetries = 2;
//             configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
//
//             var oauthTokenProvider = new DefaultOAuthTokenProvider(configuration, new MockOAuthApi(configuration, isDpop: false));
//             var apiClient = new ApiClient(oauthTokenProvider);
//
//             var mockHttp = new MockHttpMessageHandler();
//
//             mockHttp
//                 .When("https://mytestorg.com/resource")
//                 .Respond(HttpStatusCode.OK, "application/json", "{}");
//
//
//             var client = new RestClient(options: new RestClientOptions { ConfigureMessageHandler = _ => mockHttp });
//
//             // Bearer Token scenario
//             request.Parameters.AddParameter(new HeaderParameter("Authorization", "Bearer myAccessToken"));
//             _ = await apiClient.ExecuteAsyncWithRetryHeadersAsync(pollyContext, request, client, configuration);
//
//             var retryCountHeader = request.Parameters.FirstOrDefault(x => x.Name == DefaultRetryStrategy.XOktaRetryCountHeader);
//             retryCountHeader.Should().BeNull();
//
//             var requestIdHeader = request.Parameters.FirstOrDefault(x => x.Name == DefaultRetryStrategy.XOktaRetryForHeader);
//             requestIdHeader.Should().BeNull();
//             
//             var authHeader = request.Parameters.FirstOrDefault(x => x.Name == "Authorization");
//             authHeader.Value.Should().Be("Bearer myAccessToken");
//
//
//             // DPoP scenario
//             request = new RestRequest("https://mytestorg.com/resource", Method.Get);
//             request.Parameters.AddParameter(new HeaderParameter("Authorization", "DPoP myAccessToken"));
//             request.Parameters.AddParameter(new HeaderParameter("DPoP", "myDpopJwt"));
//
//             var dpopHeader = request.Parameters.FirstOrDefault(x => x.Name == "DPoP");
//             dpopHeader.Value.Should().Be("myDpopJwt");
//
//             oauthTokenProvider = new DefaultOAuthTokenProvider(configuration, new MockOAuthApi(configuration, isDpop: true));
//             apiClient = new ApiClient(oauthTokenProvider);
//
//             
//             request.Parameters.AddParameter(new HeaderParameter("Authorization", "Bearer myAccessToken"));
//             _ = await apiClient.ExecuteAsyncWithRetryHeadersAsync(pollyContext, request, client, configuration);
//
//             retryCountHeader = request.Parameters.FirstOrDefault(x => x.Name == DefaultRetryStrategy.XOktaRetryCountHeader);
//             retryCountHeader.Should().BeNull();
//
//             requestIdHeader = request.Parameters.FirstOrDefault(x => x.Name == DefaultRetryStrategy.XOktaRetryForHeader);
//             requestIdHeader.Should().BeNull();
//
//             authHeader = request.Parameters.FirstOrDefault(x => x.Name == "Authorization");
//             authHeader.Value.Should().Be("DPoP myAccessToken");
//
//             dpopHeader = request.Parameters.FirstOrDefault(x => x.Name == "DPoP");
//             dpopHeader.Value.Should().Be("myDpopJwt");
//         }
//
//         [Fact]
//         public async Task AddHeadersWhenRetrying401BearerTokenRequest()
//         {
//
//             Context pollyContext = new Context();
//             RestRequest request = new RestRequest("https://mytestorg.com/resource", Method.Get);
//
//
//             var jsonPrivateKey = @"{
//                                     ""p"":""2-8pgwYv9jrkM2KsbnQmnJZnr69Rsj95M20I1zx5HhM3tgjGSa7d_dELPRkp9Usy8UGISt7eUHpYOVl529irHwbXevuId1Q804aQ_AtNJwpbRY48rw2T8LdtyVSaEyoFMCa8PJwtzZYzKJCKAe5eoXvW5zxB65RaIct0igYcoIs"",
//                                     ""kty"":""RSA"",
//                                     ""q"":""slkNUY_SCIn95ip7HoPs_IIiNoKOGeesIV1gacyoAycly1vBPMhtar9gwx51nN1tCMVGlSOk583eRJe2omAbqkIEYm1jSWtMdJKQSOJvx812xbF1afMgJDlJ6iRIlcnWEYhNNMCK5s_UR5zE0Mc5jktxDFeiEatriyu6o9hQix8"",
//                                     ""d"":""LIpJTKCi9hPTiuUU954hayd3lXNwTVS6Fdny2iUj6iZ22eRp1V_UswECuMy5B-8lWbp1Gu_eASvhElSCB26m3UgHRVy8LP6Lmvm9VlJuZ5NtOK5D0R-gzFLINGdQH1PehzEc44jsTWyu297lgCLrVy-VScHQJodni3txTzxY4jwjILMfLB7OWdKVkvDQ4g70BYTVN5kZKjA9B0lLsofi1gUY_EVlojuvSKbm3HY0JR_JThtEd_nZw_tXTYmlP58plVYX-9JnA8NcFRB6dUNO7XqcXU1SafWqoM9yam1nGSMYRknwjSSTKRdBXHSy7PVxVHhpC72wb3aWNsOqWNo0ZQ"",
//                                     ""e"":""AQAB"",
//                                     ""qi"":""u1mS53N4BUSoMeOHFd0o4_n3QGH4izNUsiJVBIkv_UZUAk4LYudPEikTWRLqWsrcXmOyZYao5sSaZyt-B2XCkfdnkIhl-Q7b0_W0yt3Eh5XjAzH9oy5Dklog255lh-Y0yoWXvLjq-KEDs7Nd2uIT4gvKU4ymTqybvzazr2jY9qQ"",""dp"":""nCtPBsK1-9oFgJdoaWYApOAH8DBFipSXs3SQ-oTuW_S5coD4jAmniDuQB2p-6LblDXrDFKb8pZi6XL60UO-hUv7As4s4c8NVDb5X5SEBP9-Sv-koHgU-L4eQZY21ejY0SOS4dTFRNNKasQsxc_2XJIOTLc8T3_wPpD-cGQYN_dE"",""dq"":""ZWb4iZ0qICzFLW6N3gXIYrFi3ndQcC4m0jmTLdRs2o4RkRQ0RGj4vS7ex1G0MWI8MjZoMTe49Qs6Cunvr1bRo_YxI_1p7D6Tk9wZKTeFsqaBl1mUlo7jgXUJL5U9p9zAV-uVah7nWuBjo-vgg4wij2MZfZj9zuoWFWThk3LUKKU"",""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
//                                  }";
//
//             var configuration = new Configuration();
//             configuration.Scopes = new HashSet<string> { "okta.users.read" };
//             configuration.ClientId = "foo";
//             configuration.PrivateKey = new JsonWebKeyConfiguration(jsonPrivateKey);
//             configuration.MaxRetries = 2;
//             configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
//
//             Queue<string> tokenReturnQueue = new Queue<string>();
//             tokenReturnQueue.Enqueue("myAccessToken3");
//
//
//             var oauthTokenProvider = new DefaultOAuthTokenProvider(configuration, new MockOAuthApi(configuration, returnQueue:tokenReturnQueue, isDpop: false));
//             var apiClient = new ApiClient(oauthTokenProvider);
//
//             var mockHttp = new MockHttpMessageHandler();
//
//             mockHttp
//                 .When("https://mytestorg.com/resource")
//                 .Respond(HttpStatusCode.OK, "application/json", "{}");
//
//
//             var client = new RestClient(options: new RestClientOptions { ConfigureMessageHandler = _ => mockHttp });
//
//             pollyContext.Add("access_token", "myAccessToken2");
//             pollyContext.Add("token_type", "Bearer");
//
//             request.Parameters.AddParameter(new HeaderParameter("Authorization", "Bearer myAccessToken"));
//             _ = await apiClient.ExecuteAsyncWithRetryHeadersAsync(pollyContext, request, client, configuration);
//
//             var authHeader = request.Parameters.FirstOrDefault(x => x.Name == "Authorization");
//             authHeader.Value.Should().Be("Bearer myAccessToken2");
//         }
//
//         [Fact]
//         public async Task AddHeadersWhenRetrying401DpopTokenRequest()
//         {
//
//             Context pollyContext = new Context();
//             RestRequest request = new RestRequest("https://mytestorg.com/resource", Method.Get);
//
//
//             var jsonPrivateKey = @"{
//                                     ""p"":""2-8pgwYv9jrkM2KsbnQmnJZnr69Rsj95M20I1zx5HhM3tgjGSa7d_dELPRkp9Usy8UGISt7eUHpYOVl529irHwbXevuId1Q804aQ_AtNJwpbRY48rw2T8LdtyVSaEyoFMCa8PJwtzZYzKJCKAe5eoXvW5zxB65RaIct0igYcoIs"",
//                                     ""kty"":""RSA"",
//                                     ""q"":""slkNUY_SCIn95ip7HoPs_IIiNoKOGeesIV1gacyoAycly1vBPMhtar9gwx51nN1tCMVGlSOk583eRJe2omAbqkIEYm1jSWtMdJKQSOJvx812xbF1afMgJDlJ6iRIlcnWEYhNNMCK5s_UR5zE0Mc5jktxDFeiEatriyu6o9hQix8"",
//                                     ""d"":""LIpJTKCi9hPTiuUU954hayd3lXNwTVS6Fdny2iUj6iZ22eRp1V_UswECuMy5B-8lWbp1Gu_eASvhElSCB26m3UgHRVy8LP6Lmvm9VlJuZ5NtOK5D0R-gzFLINGdQH1PehzEc44jsTWyu297lgCLrVy-VScHQJodni3txTzxY4jwjILMfLB7OWdKVkvDQ4g70BYTVN5kZKjA9B0lLsofi1gUY_EVlojuvSKbm3HY0JR_JThtEd_nZw_tXTYmlP58plVYX-9JnA8NcFRB6dUNO7XqcXU1SafWqoM9yam1nGSMYRknwjSSTKRdBXHSy7PVxVHhpC72wb3aWNsOqWNo0ZQ"",
//                                     ""e"":""AQAB"",
//                                     ""qi"":""u1mS53N4BUSoMeOHFd0o4_n3QGH4izNUsiJVBIkv_UZUAk4LYudPEikTWRLqWsrcXmOyZYao5sSaZyt-B2XCkfdnkIhl-Q7b0_W0yt3Eh5XjAzH9oy5Dklog255lh-Y0yoWXvLjq-KEDs7Nd2uIT4gvKU4ymTqybvzazr2jY9qQ"",""dp"":""nCtPBsK1-9oFgJdoaWYApOAH8DBFipSXs3SQ-oTuW_S5coD4jAmniDuQB2p-6LblDXrDFKb8pZi6XL60UO-hUv7As4s4c8NVDb5X5SEBP9-Sv-koHgU-L4eQZY21ejY0SOS4dTFRNNKasQsxc_2XJIOTLc8T3_wPpD-cGQYN_dE"",""dq"":""ZWb4iZ0qICzFLW6N3gXIYrFi3ndQcC4m0jmTLdRs2o4RkRQ0RGj4vS7ex1G0MWI8MjZoMTe49Qs6Cunvr1bRo_YxI_1p7D6Tk9wZKTeFsqaBl1mUlo7jgXUJL5U9p9zAV-uVah7nWuBjo-vgg4wij2MZfZj9zuoWFWThk3LUKKU"",""n"":""mTjMc8AxU102LT1Jf-1qkGmaSiK4L7DDlC1SMvtyCRbDaiJDIagedfp1w8Pgud8YWOaS5FFx0S6JqGGP2U8OtpowzBcv5sYa-e5LHfnoueTJPj_jnI3fj5omZM1w-ofhFLPZoYEQ7DFYw0yLrzf8zaKB5-9BZ8yyOLhSKqxaOl2s7lw2TrwBRuQpPXmEir70oDPvazd8-An5ow6F5q7mzMtHAt61DJqrosRHiRwh4N37zIX_RNu-Tn1aMktCBl01rdoDyVq7Y4iwNH8ZAtT5thKK2eo8d-jb9TF9PH6LGffYCth157w-K4AZwXw74Ybo5NOux3XpIpKRbFTwvBLp1Q""
//                                  }";
//
//             var configuration = new Configuration();
//             configuration.Scopes = new HashSet<string> { "okta.users.read" };
//             configuration.ClientId = "foo";
//             configuration.PrivateKey = new JsonWebKeyConfiguration(jsonPrivateKey);
//             configuration.MaxRetries = 2;
//             configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
//
//             Queue<string> tokenReturnQueue = new Queue<string>();
//             tokenReturnQueue.Enqueue("myAccessToken3");
//
//
//             var oauthTokenProvider = new DefaultOAuthTokenProvider(configuration, new MockOAuthApi(configuration, returnQueue: tokenReturnQueue, isDpop: true));
//             var apiClient = new ApiClient(oauthTokenProvider);
//
//             var mockHttp = new MockHttpMessageHandler();
//
//             mockHttp
//                 .When("https://mytestorg.com/resource")
//                 .Respond(HttpStatusCode.OK, "application/json", "{}");
//
//
//             var client = new RestClient(options: new RestClientOptions { ConfigureMessageHandler = _ => mockHttp });
//
//             pollyContext.Add("access_token", "myAccessToken2");
//             pollyContext.Add("token_type", "DPoP");
//             pollyContext.Add("dpop_jwt", "myDpopJwt2");
//
//             request.Parameters.AddParameter(new HeaderParameter("Authorization", "DPoP myAccessToken"));
//             request.Parameters.AddParameter(new HeaderParameter("DPoP", "myDpopJwt"));
//
//             var dpopHeader = request.Parameters.FirstOrDefault(x => x.Name == "DPoP");
//             dpopHeader.Value.Should().Be("myDpopJwt");
//
//             _ = await apiClient.ExecuteAsyncWithRetryHeadersAsync(pollyContext, request, client, configuration);
//
//             var authHeader = request.Parameters.FirstOrDefault(x => x.Name == "Authorization");
//             authHeader.Value.Should().Be("DPoP myAccessToken2");
//
//             dpopHeader = request.Parameters.FirstOrDefault(x => x.Name == "DPoP");
//             dpopHeader.Value.Should().Be("myDpopJwt2");
//         }
//         
//         // Test for the conditions described in the github issue comment here: https://github.com/okta/okta-sdk-dotnet/issues/691#issuecomment-2130299272
//         [Fact]
//         public void NotFailOnEmptyProxyConfig()
//         {
//             Exception thrown = null;
//             string appSettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
//             try
//             {
//                 dynamic appsettings = new
//                 {
//                     useProxy = false, // advice to the configuration system not to treat proxy section as http client proxy.
//                                       // Assume that it is used in an unrelated way
//                                       // see https://github.com/okta/okta-sdk-dotnet/issues/691#issuecomment-2130299272
//                     proxy = new
//                     {
//                         host = "not a good uri"
//                     }
//                 };
//                 
//                 File.WriteAllText(appSettingsPath, JsonConvert.SerializeObject(appsettings));
//                 var apiClient = new ApiClient();
//                 var client = apiClient.GetConfiguredClient(Configuration.GetConfigurationOrDefault());
//             }
//             catch (Exception ex)
//             {
//                 thrown = ex;
//             }
//             finally
//             {
//                 File.Delete(appSettingsPath);
//             }
//
//             thrown.Should().BeNull("because no exception was thrown");
//         }
//     }
// }
