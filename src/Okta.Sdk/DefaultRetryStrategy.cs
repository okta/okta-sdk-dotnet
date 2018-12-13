// <copyright file="DefaultRetryStrategy.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>
    /// Default retry strategy
    /// </summary>
    public class DefaultRetryStrategy : IRetryStrategy
    {
        /// <summary>
        /// The default delta used in the back-off formula to account for some clock skew in our service
        /// </summary>
        public static readonly int DefaultBackOffSecondsDelta = 1;

        /// <inheritdoc/>
        public int MaxRetries { get; set; }

        /// <inheritdoc/>
        public int RequestTimeOut { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultRetryStrategy"/> class.
        /// </summary>
        /// <param name="maxRetries">the number of times to retry</param>
        /// <param name="requestTimeOut">The request timeout in seconds</param>
        public DefaultRetryStrategy(int maxRetries, int requestTimeOut)
        {
            MaxRetries = maxRetries;
            RequestTimeOut = requestTimeOut;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultRetryStrategy"/> class.
        /// </summary>
        public DefaultRetryStrategy()
        {
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> WaitAndRetryAsync(HttpRequestMessage request, Func<HttpRequestMessage, Task<HttpResponseMessage>> operation)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            var attempts = 0;
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            do
            {
                attempts++;

                var response = await operation(request).ConfigureAwait(false);
                var statusCode = (int)response.StatusCode;

                try
                {
                    if (statusCode == 429 && attempts < MaxRetries + 1 &&
                        ((RequestTimeOut > 0 && stopwatch.Elapsed.Seconds < RequestTimeOut) || RequestTimeOut == 0))
                    {
                        await CreateDelayAsync(response).ConfigureAwait(false);
                        response.Headers.TryGetValues("X-Okta-Request-Id", out var requestId);
                        AddRetryOktaHeaders(request, requestId.First(), attempts);
                    }
                    else
                    {
                        return response;
                    }
                }
                catch
                {
                    return response;
                }
            }
            while (true);
        }

        private void AddRetryOktaHeaders(HttpRequestMessage request, string requestId, int numberOfRetries)
        {
            if (!request.Headers.Contains("X-Okta-Retry-For"))
            {
                request.Headers.Add("X-Okta-Retry-For", requestId);
            }

            if (request.Headers.Contains("X-Okta-Retry-Count"))
            {
                request.Headers.Remove("X-Okta-Retry-Count");
            }

            request.Headers.Add("X-Okta-Retry-Count", numberOfRetries.ToString());
        }

        private Task CreateDelayAsync(HttpResponseMessage response)
        {
            var requestTime = DateTimeOffset.UtcNow;
            var retryDate = DateTimeOffset.UtcNow;

            if (response.Headers.TryGetValues("Date", out var dates))
            {
                requestTime = DateTimeOffset.Parse(dates.First()).UtcDateTime;
            }

            if (response.Headers.TryGetValues("x-rate-limit-reset", out var rateLimits))
            {
                if (rateLimits == null || rateLimits.Count() > 1)
                {
                    throw new InvalidOperationException("Multiple x-rate-limit-reset headers in the response");
                }

                retryDate = DateTimeOffset.FromUnixTimeSeconds(long.Parse(rateLimits.First())).UtcDateTime;
            }

            var backoffSeconds = retryDate.Subtract(requestTime).Add(new TimeSpan(0, 0, DefaultBackOffSecondsDelta)).Seconds;

            return Task.Delay(new TimeSpan(0, 0, backoffSeconds));
        }
    }
}
