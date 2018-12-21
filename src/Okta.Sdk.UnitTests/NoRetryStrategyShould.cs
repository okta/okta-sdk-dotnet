// <copyright file="NoRetryStrategyShould.cs" company="Okta, Inc">
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
    public class NoRetryStrategyShould
    {
        [Fact]
        public async Task NotRetry429()
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

            var retryStrategy = new NoRetryStrategy();

            var retryResponse = await retryStrategy.WaitAndRetryAsync(request, default(CancellationToken), operation);
            operation.ReceivedCalls().Count().Should().Be(1);
            retryResponse.StatusCode.Should().Be((HttpStatusCode)429);
        }
    }
}
