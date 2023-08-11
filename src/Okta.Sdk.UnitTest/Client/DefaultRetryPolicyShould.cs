using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Moq.Protected;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.UnitTest.Internal;
using RestSharp;
using RichardSzalay.MockHttp;
using RichardSzalay.MockHttp.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
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
