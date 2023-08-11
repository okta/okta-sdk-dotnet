using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Client;
using Okta.Sdk.UnitTest.Internal;
using RestSharp;
using RichardSzalay.MockHttp;
using Xunit;
using Xunit.Abstractions;


namespace Okta.Sdk.UnitTest.Client
{
    public class DefaultOAuthRetryPolicyShould
    {
        private readonly ITestOutputHelper _output;

        public DefaultOAuthRetryPolicyShould(ITestOutputHelper output)
        {
            _output = output;
        }


        [Fact]
        public async Task RetryOnlyWith401Responses()
        {
            var globalRetry = 0;
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
            configuration.ClientId = "foo";
            configuration.PrivateKey = new JsonWebKeyConfiguration(jsonPrivateKey);
            configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
            configuration.OktaDomain = "https://foo.com";
            var request = new RestRequest(new Uri($"http://localhost/api/user/{globalRetry}"));

            var defaultOAuthPolicy = new DefaultOAuthTokenProvider(configuration, new MockOAuthApi(configuration)).GetOAuthRetryPolicy((response, retryAttempt, ctx) =>
            {
                globalRetry++;
                request = new RestRequest(new Uri($"http://localhost/api/user/{globalRetry}"));
                _output.WriteLine(
                    $"Got a response of {response.Result.StatusCode}, retrying {retryAttempt}");

                return Task.CompletedTask;
            });


            var mockHttp = new MockHttpMessageHandler();
            
            mockHttp
                .When("http://localhost/api/user/0")
                .Respond(HttpStatusCode.Unauthorized, "application/json", "{}");

            mockHttp
                .When("http://localhost/api/user/1")
                .Respond(HttpStatusCode.Unauthorized, "application/json", "{}");

            var client = new RestClient(options: new RestClientOptions { ConfigureMessageHandler = _ => mockHttp });
            
            _ = await defaultOAuthPolicy.ExecuteAndCaptureAsync(async action =>
                await client.ExecuteAsync(request), CancellationToken.None);

            

            globalRetry.Should().Be(2);
        }

        [Fact]
        public async Task UpdateTokenInRetry()
        {
            var globalRetry = 0;
            var request = new RestRequest(new Uri($"http://localhost/api/user/{globalRetry}"));
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
            configuration.ClientId = "foo";
            configuration.PrivateKey = new JsonWebKeyConfiguration(jsonPrivateKey);
            configuration.AuthorizationMode = AuthorizationMode.PrivateKey;
            configuration.OktaDomain = "https://foo.com";

            var tokensQueue = new Queue<string>();
            tokensQueue.Enqueue("foo");
            tokensQueue.Enqueue("bar");

            var defaultOAuthPolicy = new DefaultOAuthTokenProvider(configuration, new MockOAuthApi(configuration, tokensQueue)).GetOAuthRetryPolicy((response, retryAttempt, ctx) =>
            {
                globalRetry++;
                ctx.Keys.Should().Contain("access_token");
                ctx["access_token"].Should().Be("foo");

                DefaultOAuthTokenProvider.AddOrUpdateAuthorizationHeader(ctx, request);

                ctx.Keys.Should().Contain("access_token");
                ctx["access_token"].Should().Be("bar");
                
                ctx.Keys.ToList().ForEach(x =>
                    _output.WriteLine($"key: {x} - value: {ctx[x]}"));
                _output.WriteLine(
                    $"Got a response of {response.Result.StatusCode}, retrying {retryAttempt}.");

                return Task.CompletedTask;
            });

            var mockHttp = new MockHttpMessageHandler();

            mockHttp
                .When("http://localhost/api/user/*")
                .Respond(HttpStatusCode.Unauthorized, "application/json", "{}");

            var client = new RestClient(options: new RestClientOptions { ConfigureMessageHandler = _ => mockHttp });


            _ = await defaultOAuthPolicy.ExecuteAndCaptureAsync(async action =>
                await client.ExecuteAsync(request), CancellationToken.None);
        }
    }
}
