// <copyright file="DefaultRetryPolicyShould.cs" company="Okta, Inc">
// Copyright (c) 2014-present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Client;
using RestSharp;
using RichardSzalay.MockHttp;
using Xunit;
using Xunit.Abstractions;

namespace Okta.Sdk.UnitTest.Client
{
    public class DefaultRetryPolicyShould
    {
        private readonly ITestOutputHelper _output;
        public DefaultRetryPolicyShould(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task RetryOperationUntilMaxRetriesIsReached()
        {
            var dateHeader = new DateTimeOffset(DateTime.Now);
            var resetTime = dateHeader.AddSeconds(1).ToUnixTimeSeconds();
            var globalRetry = 0;
            var config = new Okta.Sdk.Client.Configuration { MaxRetries = 2 };

            var defaultRetryPolicy = DefaultRetryStrategy.GetRetryPolicy(config,
                (response, timeSpan, retryAttempt, ctx) =>
                {
                    globalRetry++;
                    ctx.Keys.ToList().ForEach(x =>
                        _output.WriteLine($"key: {x} - value: {ctx[x]}"));
                    _output.WriteLine(
                        $"Got a response of {response.Result.StatusCode}, retrying {retryAttempt}. Delaying for {timeSpan}");

                    return Task.CompletedTask;
                });


            var mockHttp = new MockHttpMessageHandler();

            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("Date", dateHeader.ToString()));
            headers.Add(new KeyValuePair<string, string>("x-rate-limit-reset", resetTime.ToString()));
            headers.Add(new KeyValuePair<string, string>(DefaultRetryStrategy.XOktaRequestId, "foo"));

            mockHttp
                .When("http://localhost/api/user/0")
                .Respond(HttpStatusCode.TooManyRequests, headers, "application/json", "{}");

            mockHttp
                .When("http://localhost/api/user/*")
                .Respond(HttpStatusCode.TooManyRequests, headers, "application/json", "{}");

            var client = new RestClient(options: new RestClientOptions { ConfigureMessageHandler = _ => mockHttp });

            _ = await defaultRetryPolicy.ExecuteAndCaptureAsync(async action =>
                await client.ExecuteAsync(new RestRequest(new Uri("http://localhost/api/user/foo"))), CancellationToken.None);

            globalRetry.Should().Be(2);
        }

        [Fact]
        public async Task RetryOnlyWith429Responses()
        {
            var dateHeader = new DateTimeOffset(DateTime.Now);
            var resetTime = dateHeader.AddSeconds(10).ToUnixTimeSeconds();
            var globalRetry = 0;
            var config = new Okta.Sdk.Client.Configuration { MaxRetries = 2 };
            var request = new RestRequest(new Uri($"http://localhost/api/user/{globalRetry}"));

            var defaultRetryPolicy = DefaultRetryStrategy.GetRetryPolicy(config,
                (response, timeSpan, retryAttempt, ctx) =>
                {
                    globalRetry++;
                    request = new RestRequest(new Uri($"http://localhost/api/user/{globalRetry}"));
                    _output.WriteLine(
                        $"Got a response of {response.Result.StatusCode}, retrying {retryAttempt}. Delaying for {timeSpan}");

                    return Task.CompletedTask;
                });

            var mockHttp = new MockHttpMessageHandler();

            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("Date", dateHeader.ToString()));
            headers.Add(new KeyValuePair<string, string>("x-rate-limit-reset", resetTime.ToString()));
            headers.Add(new KeyValuePair<string, string>(DefaultRetryStrategy.XOktaRequestId, "foo"));
            
            mockHttp
                .When("http://localhost/api/user/0")
                .Respond(HttpStatusCode.TooManyRequests, headers, "application/json", "{}");
            
            mockHttp
                .When("http://localhost/api/user/1")
                .Respond(HttpStatusCode.BadRequest, headers, "application/json", "{}");

            var client = new RestClient(options: new RestClientOptions { ConfigureMessageHandler = _ => mockHttp });

            _ = await defaultRetryPolicy.ExecuteAndCaptureAsync(async action =>
                await client.ExecuteAsync(request), CancellationToken.None);

            globalRetry.Should().Be(1);
        }

        [Fact]
        public async Task AddOktaHeadersInRetry()
        {
            var dateHeader = new DateTimeOffset(DateTime.Now);
            var resetTime = dateHeader.AddSeconds(1).ToUnixTimeSeconds();
            var globalRetry = 0;
            var config = new Okta.Sdk.Client.Configuration { MaxRetries = 2 };
            var request = new RestRequest();

            var defaultRetryPolicy = DefaultRetryStrategy.GetRetryPolicy(config,
                (response, timeSpan, retryAttempt, ctx) =>
                {
                    globalRetry++;
                    ctx.Keys.Should().Contain(DefaultRetryStrategy.XOktaRetryCountHeader);
                    ctx[DefaultRetryStrategy.XOktaRetryCountHeader].Should().Be(retryAttempt);

                    ctx.Keys.Should().Contain(DefaultRetryStrategy.XOktaRequestId);
                    ctx[DefaultRetryStrategy.XOktaRequestId].Should().Be("foo");


                    DefaultRetryStrategy.AddRetryHeaders(ctx, request);
                    request.Parameters.Should().Contain(x => x.Name == DefaultRetryStrategy.XOktaRetryForHeader);
                    request.Parameters.First(x => x.Name == DefaultRetryStrategy.XOktaRetryForHeader).Value.Should()
                        .Be("foo");
                    request.Parameters.Should().Contain(x => x.Name == DefaultRetryStrategy.XOktaRetryCountHeader);
                    request.Parameters.First(x => x.Name == DefaultRetryStrategy.XOktaRetryCountHeader).Value.Should()
                        .Be(retryAttempt.ToString());


                    ctx.Keys.ToList().ForEach(x =>
                        _output.WriteLine($"key: {x} - value: {ctx[x]}"));
                    _output.WriteLine(
                        $"Got a response of {response.Result.StatusCode}, retrying {retryAttempt}. Delaying for {timeSpan}");

                    return Task.CompletedTask;
                });

            var mockHttp = new MockHttpMessageHandler();
            
            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("Date", dateHeader.ToString()));
            headers.Add(new KeyValuePair<string, string>("x-rate-limit-reset", resetTime.ToString()));
            headers.Add(new KeyValuePair<string, string>(DefaultRetryStrategy.XOktaRequestId, "foo"));

            mockHttp
                .When("http://localhost/api/user/*")
                .Respond(HttpStatusCode.TooManyRequests, headers, "application/json", "{}");

            var client = new RestClient(options: new RestClientOptions { ConfigureMessageHandler = _ => mockHttp });

            _ = await defaultRetryPolicy.ExecuteAndCaptureAsync(async action =>
                await client.ExecuteAsync(new RestRequest(new Uri("http://localhost/api/user/foo"))), CancellationToken.None);

            globalRetry.Should().Be(2);
        }


        [Fact]
        public async Task UpdateDPoPJwtInRetry()
        {
            var dateHeader = new DateTimeOffset(DateTime.Now);
            var resetTime = dateHeader.AddSeconds(1).ToUnixTimeSeconds();
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
            configuration.Scopes = new HashSet<string> { "okta.users.read" };
            configuration.ClientId = "foo";
            configuration.PrivateKey = new JsonWebKeyConfiguration(jsonPrivateKey);
            configuration.MaxRetries = 2;

            var request = new RestRequest();
            bool somethingWentWrong = false;

            var defaultRetryPolicy = DefaultRetryStrategy.GetRetryPolicy(configuration,
                (response, timeSpan, retryAttempt, ctx) =>
                {
                    try
                    {
                        globalRetry++;
                        ctx.Keys.Should().Contain(DefaultRetryStrategy.XOktaRetryCountHeader);
                        ctx[DefaultRetryStrategy.XOktaRetryCountHeader].Should().Be(retryAttempt);

                        ctx.Keys.Should().Contain(DefaultRetryStrategy.XOktaRequestId);
                        ctx[DefaultRetryStrategy.XOktaRequestId].Should().Be("foo");


                        DefaultRetryStrategy.AddRetryHeaders(ctx, request);

                        request.Parameters.Should().Contain(x => x.Name == DefaultRetryStrategy.XOktaRetryForHeader);
                        request.Parameters.First(x => x.Name == DefaultRetryStrategy.XOktaRetryForHeader).Value.Should()
                            .Be("foo");
                        request.Parameters.Should().Contain(x => x.Name == DefaultRetryStrategy.XOktaRetryCountHeader);
                        request.Parameters.First(x => x.Name == DefaultRetryStrategy.XOktaRetryCountHeader).Value
                            .Should()
                            .Be(retryAttempt.ToString());


                        ctx.Keys.ToList().ForEach(x =>
                            _output.WriteLine($"key: {x} - value: {ctx[x]}"));
                        _output.WriteLine(
                            $"Got a response of {response.Result.StatusCode}, retrying {retryAttempt}. Delaying for {timeSpan}");
                    }
                    catch
                    {
                        somethingWentWrong = true;
                    }

                    return Task.CompletedTask;
                });

            var mockHttp = new MockHttpMessageHandler();

            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("Date", dateHeader.ToString()));
            headers.Add(new KeyValuePair<string, string>("x-rate-limit-reset", resetTime.ToString()));
            headers.Add(new KeyValuePair<string, string>(DefaultRetryStrategy.XOktaRequestId, "foo"));

            mockHttp
                .When("http://localhost/api/user/*")
                .Respond(HttpStatusCode.TooManyRequests, headers, "application/json", "{}");

            var client = new RestClient(options: new RestClientOptions { ConfigureMessageHandler = _ => mockHttp });

            _ = await defaultRetryPolicy.ExecuteAndCaptureAsync(async action =>
                await client.ExecuteAsync(new RestRequest(new Uri("http://localhost/api/user/foo"))), CancellationToken.None);

            globalRetry.Should().Be(2);
            somethingWentWrong.Should().BeFalse();
        }


        [Fact]
        public async Task StopRetryWhenTimeoutIsReached()
        {
            var dateHeader = new DateTimeOffset(DateTime.Now);
            var resetTime = dateHeader.AddSeconds(5).ToUnixTimeSeconds();
            var globalRetry = 0;
            var config = new Okta.Sdk.Client.Configuration { MaxRetries = 10, RequestTimeout = 1000 };

            var defaultRetryPolicy = DefaultRetryStrategy.GetRetryPolicy(config,
                (response, timeSpan, retryAttempt, ctx) =>
                {
                    globalRetry++;
                    ctx.Keys.ToList().ForEach(x =>
                        _output.WriteLine($"key: {x} - value: {ctx[x]}"));
                    _output.WriteLine(
                        $"Got a response of {response.Result}, retrying {retryAttempt}. Delaying for {timeSpan}");

                    return Task.CompletedTask;
                });

            Func<int, RestClient, Task<RestResponse>> func = (sleepFor, mockClient) =>
            {
                Thread.Sleep(sleepFor);
                return mockClient.ExecuteAsync(new RestRequest(new Uri("http://localhost/api/user/foo")));
            };

            var mockHttp = new MockHttpMessageHandler();

            var headers = new List<KeyValuePair<string, string>>();
            headers.Add(new KeyValuePair<string, string>("Date", dateHeader.ToString()));
            headers.Add(new KeyValuePair<string, string>("x-rate-limit-reset", resetTime.ToString()));
            headers.Add(new KeyValuePair<string, string>(DefaultRetryStrategy.XOktaRequestId, "foo"));

            mockHttp
                .When("http://localhost/api/user/*")
                .Respond(HttpStatusCode.TooManyRequests, headers, "application/json", "{}");

            var client = new RestClient(options: new RestClientOptions { ConfigureMessageHandler = _ => mockHttp });
            
            var policyResult = await defaultRetryPolicy.ExecuteAndCaptureAsync(action =>
               func(2000, client), CancellationToken.None);
            policyResult.FinalException.Message.Should().Contain("Timeout");

            globalRetry.Should().Be(1);
        }
    }
}
