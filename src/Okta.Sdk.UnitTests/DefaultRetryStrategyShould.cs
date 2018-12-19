// <copyright file="DefaultRetryStrategyShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class DefaultRetryStrategyShould
    {
        [Fact]
        public async Task RetryOperationUntilMaxRetriesIsReached()
        {
            var dateHeader = DateTime.Now;
            var resetTime = new DateTimeOffset(dateHeader).AddSeconds(1).ToUnixTimeSeconds();

            var response = Substitute.For<HttpResponseMessage>();
            response.StatusCode = (HttpStatusCode)429;
            response.Headers.Add("X-Rate-Limit-Reset", resetTime.ToString());
            response.Headers.Add("Date", dateHeader.ToUniversalTime().ToString("ddd, dd MMM yyyy HH:mm:ss 'GMT'"));
            response.Headers.Add("X-Okta-Request-Id", "foo");

            var request = Substitute.For<HttpRequestMessage>();
            request.RequestUri = new Uri("https://foo.dev");

            var operation = Substitute.For<Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>>>();
            operation(request, default(CancellationToken)).Returns(response);

            operation(request, default(CancellationToken)).Result.StatusCode.Should().Be(429);
            operation.ClearReceivedCalls();

            var retryStrategy = new DefaultRetryStrategy(1, 0);

            var retryResponse = await retryStrategy.WaitAndRetryAsync(request, default(CancellationToken), operation);
            operation.ReceivedCalls().Count().Should().Be(2);
            retryResponse.StatusCode.Should().Be((HttpStatusCode)429);
        }

        [Fact]
        public async Task RetryOnlyWith429Responses()
        {
            var dateHeader = DateTime.Now;
            var resetTime = new DateTimeOffset(dateHeader).AddSeconds(1).ToUnixTimeSeconds();

            var response = Substitute.For<HttpResponseMessage>();
            response.StatusCode = (HttpStatusCode)429;
            response.Headers.Add("X-Rate-Limit-Reset", resetTime.ToString());
            response.Headers.Add("Date", dateHeader.ToUniversalTime().ToString("ddd, dd MMM yyyy HH:mm:ss 'GMT'"));
            response.Headers.Add("X-Okta-Request-Id", "foo");

            var successResponse = Substitute.For<HttpResponseMessage>();
            successResponse.StatusCode = HttpStatusCode.OK;

            var request = Substitute.For<HttpRequestMessage>();
            request.RequestUri = new Uri("https://foo.dev");

            var operation = Substitute.For<Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>>>();
            operation(request, default(CancellationToken)).Returns(x => response, x => successResponse);

            var retryStrategy = new DefaultRetryStrategy(5, 0);

            var retryResponse = await retryStrategy.WaitAndRetryAsync(request, default(CancellationToken), operation);
            operation.ReceivedCalls().Count().Should().Be(2);
            retryResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task AddOktaHeadersInRetry()
        {
            var dateHeader = DateTime.Now;
            var resetTime = new DateTimeOffset(dateHeader).AddSeconds(1).ToUnixTimeSeconds();

            var response = Substitute.For<HttpResponseMessage>();
            response.StatusCode = (HttpStatusCode)429;
            response.Headers.Add("X-Rate-Limit-Reset", resetTime.ToString());
            response.Headers.Add("Date", dateHeader.ToUniversalTime().ToString("ddd, dd MMM yyyy HH:mm:ss 'GMT'"));
            response.Headers.Add("X-Okta-Request-Id", "foo");

            var request = Substitute.For<HttpRequestMessage>();
            request.RequestUri = new Uri("https://foo.dev");

            var requestHeadersDictionary = new Dictionary<int, List<KeyValuePair<string, IEnumerable<string>>>>();
            var numberOfExecutions = 0;
            var operation = Substitute.For<Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>>>();

            operation(request, default(CancellationToken)).Returns(
                x =>
                {
                    requestHeadersDictionary.Add(numberOfExecutions, request.Headers.ToList());
                    numberOfExecutions++;

                    return response;
                });

            var retryStrategy = new DefaultRetryStrategy(1, 0);

            var retryResponse = await retryStrategy.WaitAndRetryAsync(request, default(CancellationToken), operation);
            numberOfExecutions.Should().Be(2);
            retryResponse.StatusCode.Should().Be((HttpStatusCode)429);

            var receivedCalls = operation.ReceivedCalls();
            receivedCalls.Count().Should().Be(2);

            requestHeadersDictionary.Count.Should().Be(2);
            requestHeadersDictionary[0].Should().BeNullOrEmpty();

            requestHeadersDictionary[1].Should().HaveCount(2);
            var retryForHeader = requestHeadersDictionary[1].FirstOrDefault(x => x.Key == "X-Okta-Retry-For");
            retryForHeader.Should().NotBeNull();
            retryForHeader.Value.Should().Contain("foo");

            var retryCountHeader = requestHeadersDictionary[1].FirstOrDefault(x => x.Key == "X-Okta-Retry-Count");
            retryCountHeader.Should().NotBeNull();
            retryCountHeader.Value.Should().Contain("1");
        }

        [Fact]
        public async Task StopRetryWhenTimeoutIsReached()
        {
            var dateHeader = DateTime.Now;
            var resetTime = new DateTimeOffset(dateHeader).AddSeconds(5).ToUnixTimeSeconds();

            var response = Substitute.For<HttpResponseMessage>();
            response.StatusCode = (HttpStatusCode)429;
            response.Headers.Add("X-Rate-Limit-Reset", resetTime.ToString());
            response.Headers.Add("Date", dateHeader.ToUniversalTime().ToString("ddd, dd MMM yyyy HH:mm:ss 'GMT'"));
            response.Headers.Add("X-Okta-Request-Id", "foo");

            var request = Substitute.For<HttpRequestMessage>();
            request.RequestUri = new Uri("https://foo.dev");

            var operation = Substitute.For<Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>>>();
            operation(request, default(CancellationToken)).Returns(x =>
            {
                Thread.Sleep(2000);
                return response;
            });

            var retryStrategy = new DefaultRetryStrategy(10, 1);
            var retryResponse = await retryStrategy.WaitAndRetryAsync(request, default(CancellationToken), operation);
            retryResponse.StatusCode.Should().Be((HttpStatusCode)429);

            var receivedCalls = operation.ReceivedCalls();
            receivedCalls.Count().Should().Be(1);
        }

        [Fact]
        public async Task ReturnIfBackoffExceedsRequestTimeout()
        {
            var dateHeader = DateTime.Now;
            var resetTime = new DateTimeOffset(dateHeader).AddSeconds(5).ToUnixTimeSeconds();

            var response = Substitute.For<HttpResponseMessage>();
            response.StatusCode = (HttpStatusCode)429;
            response.Headers.Add("X-Rate-Limit-Reset", resetTime.ToString());
            response.Headers.Add("Date", dateHeader.ToUniversalTime().ToString("ddd, dd MMM yyyy HH:mm:ss 'GMT'"));
            response.Headers.Add("X-Okta-Request-Id", "foo");

            var request = Substitute.For<HttpRequestMessage>();
            request.RequestUri = new Uri("https://foo.dev");

            var operation = Substitute.For<Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>>>();
            operation(request, default(CancellationToken)).Returns(x =>
            {
                return response;
            });

            var retryStrategy = new DefaultRetryStrategy(10, 2);
            var retryResponse = await retryStrategy.WaitAndRetryAsync(request, default(CancellationToken), operation);
            retryResponse.StatusCode.Should().Be((HttpStatusCode)429);

            var receivedCalls = operation.ReceivedCalls();
            receivedCalls.Count().Should().Be(1);
        }

        [Fact]
        public void ThrowIfBackoffDeltaExceedsRequesTimeout()
        {
            Action constructor = () => new DefaultRetryStrategy(10, 1, 5);

            constructor.Should().Throw<ArgumentException>();
        }
    }
}
