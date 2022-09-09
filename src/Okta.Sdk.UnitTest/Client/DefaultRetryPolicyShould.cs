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

            var headers = new List<Parameter>();
            headers.Add(new Parameter("Date", dateHeader, ParameterType.HttpHeader));
            headers.Add(new Parameter("x-rate-limit-reset", resetTime, ParameterType.HttpHeader));
            headers.Add(new Parameter(DefaultRetryStrategy.XOktaRequestId, "foo", ParameterType.HttpHeader));

            var mockClient = TestUtils.MockRestClient(HttpStatusCode.TooManyRequests, "{}", headers);

            _ = await defaultRetryPolicy.ExecuteAndCaptureAsync(action =>
                mockClient.ExecuteAsync(new RestRequest()), CancellationToken.None);

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
                (response, timeSpan, retryAttempt, ctx) =>
                {
                    globalRetry++;
                    _output.WriteLine(
                        $"Got a response of {response.Result.StatusCode}, retrying {retryAttempt}. Delaying for {timeSpan}");

                    return Task.CompletedTask;
                });

            var headers = new List<Parameter>();
            headers.Add(new Parameter("Date", dateHeader, ParameterType.HttpHeader));
            headers.Add(new Parameter("x-rate-limit-reset", resetTime, ParameterType.HttpHeader));
            headers.Add(new Parameter(DefaultRetryStrategy.XOktaRequestId, "foo", ParameterType.HttpHeader));

            Queue<TestUtils.MockResponseInfo> responseQueue = new Queue<TestUtils.MockResponseInfo>();
            responseQueue.Enqueue(new TestUtils.MockResponseInfo
            { Headers = headers, ReturnThis = "", StatusCode = HttpStatusCode.TooManyRequests });
            responseQueue.Enqueue(new TestUtils.MockResponseInfo
            { Headers = new List<Parameter>(), ReturnThis = "", StatusCode = HttpStatusCode.BadRequest });

            var mockClient = TestUtils.MockRestClient(responseQueue);
            _ = await defaultRetryPolicy.ExecuteAndCaptureAsync(action =>
                mockClient.ExecuteAsync(new RestRequest()), CancellationToken.None);


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

            var headers = new List<Parameter>();
            headers.Add(new Parameter("Date", dateHeader, ParameterType.HttpHeader));
            headers.Add(new Parameter("x-rate-limit-reset", resetTime, ParameterType.HttpHeader));
            headers.Add(new Parameter(DefaultRetryStrategy.XOktaRequestId, "foo", ParameterType.HttpHeader));


            var mockClient = TestUtils.MockRestClient(HttpStatusCode.TooManyRequests, "{}", headers);

            _ = await defaultRetryPolicy.ExecuteAndCaptureAsync(action =>
                mockClient.ExecuteAsync(new RestRequest()), CancellationToken.None);

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

            Func<int, IRestClient, Task<IRestResponse>> func = (sleepFor, mockClient) =>
            {
                Thread.Sleep(sleepFor);
                return mockClient.ExecuteAsync(new RestRequest());
            };

            var headers = new List<Parameter>();
            headers.Add(new Parameter("Date", dateHeader, ParameterType.HttpHeader));
            headers.Add(new Parameter("x-rate-limit-reset", resetTime, ParameterType.HttpHeader));
            headers.Add(new Parameter(DefaultRetryStrategy.XOktaRequestId, "foo", ParameterType.HttpHeader));


            var mockClient = TestUtils.MockRestClient(HttpStatusCode.TooManyRequests, "{}", headers);

            var policyResult = await defaultRetryPolicy.ExecuteAndCaptureAsync(action =>
               func(2000, mockClient), CancellationToken.None);
            policyResult.FinalException.Message.Should().Contain("Timeout");

            globalRetry.Should().Be(1);
        }
    }
}
