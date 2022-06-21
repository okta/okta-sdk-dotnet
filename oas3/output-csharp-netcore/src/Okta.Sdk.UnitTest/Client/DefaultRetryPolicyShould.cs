using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NSubstitute;
using Okta.Sdk.Api;
using Okta.Sdk.Client;
using Okta.Sdk.Model;
using Okta.Sdk.UnitTest.Internal;
using Polly;
using RestSharp;
using Xunit;
using Xunit.Abstractions;
using Policy = Polly.Policy;

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
                (exception, timeSpan, retryAttempt, ctx) =>
                {
                    globalRetry++;
                    ctx.Keys.ToList().ForEach(x =>
                        _output.WriteLine($"key: {x} - value: {ctx[x]}"));
                    _output.WriteLine(
                        $"Got a response of {exception.Message}, retrying {retryAttempt}. Delaying for {timeSpan}");

                    return Task.CompletedTask;
                });

            var headers = new Multimap<string, string>();
            headers.Add("x-rate-limit-reset", new List<string> { resetTime.ToString() });
            headers.Add(DefaultRetryStrategy.XOktaRequestId, new List<string> { "foo" });
            headers.Add("Date", new List<string> { dateHeader.ToUniversalTime().ToString() });

            var mockClient = new MockAsyncClient("", HttpStatusCode.TooManyRequests, headers);
            var appApi = new ApplicationApi(new ApiClient(), mockClient,
                new Configuration { BasePath = "https://foo.com" });

            _ = await defaultRetryPolicy.ExecuteAndCaptureAsync(action =>
                appApi.GetApplicationAsync("foo"), CancellationToken.None);

            globalRetry.Should().Be(2);
        }

        [Fact]
        public async Task RetryOnlyWith429Responses()
        {
            var dateHeader = new DateTimeOffset(DateTime.Now);
            var resetTime = dateHeader.AddSeconds(10).ToUnixTimeSeconds();
            var globalRetry = 0;
            var config = new Okta.Sdk.Client.Configuration { MaxRetries = 5 };

            var defaultRetryPolicy = DefaultRetryStrategy.GetRetryPolicy(config,
                (exception, timeSpan, retryAttempt, ctx) =>
                {
                    globalRetry++;
                    _output.WriteLine(
                        $"Got a response of {exception.Message}, retrying {retryAttempt}. Delaying for {timeSpan}");

                    return Task.CompletedTask;
                });

            var headers = new Multimap<string, string>();
            headers.Add("x-rate-limit-reset", new List<string> { resetTime.ToString() });
            headers.Add(DefaultRetryStrategy.XOktaRequestId, new List<string> { "foo" });
            headers.Add("Date", new List<string> { dateHeader.ToUniversalTime().ToString() });

            Queue<MockResponseInfo> responseQueue = new Queue<MockResponseInfo>();
            responseQueue.Enqueue(new MockResponseInfo
                { ReceivedHeaders = headers, ReturnThis = "", StatusCode = HttpStatusCode.TooManyRequests });
            responseQueue.Enqueue(new MockResponseInfo
                { ReceivedHeaders = headers, ReturnThis = "", StatusCode = HttpStatusCode.BadRequest });

            var mockClient = new MockAsyncClient(responseQueue);
            var appApi = new ApplicationApi(new ApiClient(), mockClient,
                new Configuration { BasePath = "https://foo.com" });

            _ = await defaultRetryPolicy.ExecuteAndCaptureAsync(action =>
                appApi.GetApplicationAsync("foo"), CancellationToken.None);


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
                (exception, timeSpan, retryAttempt, ctx) =>
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
                        $"Got a response of {exception.Message}, retrying {retryAttempt}. Delaying for {timeSpan}");

                    return Task.CompletedTask;
                });

            var headers = new Multimap<string, string>();
            headers.Add("x-rate-limit-reset", new List<string> { resetTime.ToString() });
            headers.Add("X-Okta-Request-Id", new List<string> { "foo" });
            headers.Add("Date", new List<string> { dateHeader.ToUniversalTime().ToString() });

            var mockClient = new MockAsyncClient("", HttpStatusCode.TooManyRequests, headers);
            var appApi = new ApplicationApi(new ApiClient(), mockClient,
                new Configuration { BasePath = "https://foo.com" });


            _ = await defaultRetryPolicy
                .ExecuteAndCaptureAsync(action: (ctx) => appApi.GetApplicationAsync("foo"), new Context())
                .ConfigureAwait(false);
            globalRetry.Should().Be(2);
        }


        [Fact]
        public async Task StopRetryWhenTimeoutIsReached()
        {
            var dateHeader = new DateTimeOffset(DateTime.Now);
            var resetTime = dateHeader.AddSeconds(5).ToUnixTimeSeconds();
            var globalRetry = 0;
            var config = new Okta.Sdk.Client.Configuration { MaxRetries = 10, RequestTimeout = 1 };

            var defaultRetryPolicy = DefaultRetryStrategy.GetRetryPolicy(config,
                (exception, timeSpan, retryAttempt, ctx) =>
                {
                    globalRetry++;
                    ctx.Keys.ToList().ForEach(x =>
                        _output.WriteLine($"key: {x} - value: {ctx[x]}"));
                    _output.WriteLine(
                        $"Got a response of {exception.Message}, retrying {retryAttempt}. Delaying for {timeSpan}");

                    return Task.CompletedTask;
                });

            Func<int, ApplicationApi, Task<Application>> func = (sleepFor, appApi) =>
            {
                Thread.Sleep(sleepFor);
                return appApi.GetApplicationAsync("foo");
            };

            var headers = new Multimap<string, string>();
            headers.Add("x-rate-limit-reset", new List<string> { resetTime.ToString() });
            headers.Add(DefaultRetryStrategy.XOktaRequestId, new List<string> { "foo" });
            headers.Add("Date", new List<string> { dateHeader.ToUniversalTime().ToString() });

            var mockClient = new MockAsyncClient("", HttpStatusCode.TooManyRequests, headers);
            var appApi = new ApplicationApi(new ApiClient(), mockClient,
                new Configuration { BasePath = "https://foo.com" });

            var policyResult  = await defaultRetryPolicy.ExecuteAndCaptureAsync(action =>
                func(2000, appApi), CancellationToken.None);
            policyResult.FinalException.Message.Should().Contain("Timeout");

            globalRetry.Should().Be(1);
        }
    }
}
