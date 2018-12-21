// <copyright file="DefaultRetryStrategy.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
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
        public const int DefaultBackoffSecondsDelta = 1;

        private readonly int _maxRetries;
        private readonly int _requestTimeout;
        private readonly int _backoffSecondsDelta;

        // Now we are only managing 429 errors, but we can accept other codes in the future
        private IList<HttpStatusCode> _retryableStatusCodes = new List<HttpStatusCode> { (HttpStatusCode)429 };

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultRetryStrategy"/> class.
        /// </summary>
        /// <param name="maxRetries">the number of times to retry</param>
        /// <param name="requestTimeout">The request timeout in seconds</param>
        /// <param name="backoffSecondsDelta">The delta of seconds included the back-off calculation</param>
        public DefaultRetryStrategy(int maxRetries, int requestTimeout, int backoffSecondsDelta = DefaultBackoffSecondsDelta)
        {
            if (requestTimeout > 0 && backoffSecondsDelta > requestTimeout)
            {
                throw new ArgumentException("The backoff delta cannot be greater than the request timeout");
            }

            _maxRetries = maxRetries;
            _requestTimeout = requestTimeout;
            _backoffSecondsDelta = backoffSecondsDelta;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> WaitAndRetryAsync(HttpRequestMessage request, CancellationToken cancellationToken, Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> operation)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            var numberOfRetries = 0;
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            do
            {
                var response = await operation(request, cancellationToken).ConfigureAwait(false);

                if (IsRetryable(response) && numberOfRetries < _maxRetries &&
                    (_requestTimeout <= 0 || stopwatch.Elapsed.Seconds < _requestTimeout))
                {
                    numberOfRetries++;
                    var delayTimeSpan = CalculateDelay(response);
                    if (delayTimeSpan > TimeSpan.Zero)
                    {
                        await Task.Delay(delayTimeSpan, cancellationToken).ConfigureAwait(false);
                        response.Headers.TryGetValues("X-Okta-Request-Id", out var requestId);
                        AddRetryOktaHeaders(request, requestId.FirstOrDefault(), numberOfRetries);
                    }
                    else
                    {
                        return response;
                    }
                }
                else
                {
                    return response;
                }
            }
            while (true);
        }

        /// <summary>
        /// Checks if a http response message should be retried
        /// </summary>
        /// <param name="response">The http response message</param>
        /// <returns>True if the value is must be retried, otherwise false.</returns>
        public bool IsRetryable(HttpResponseMessage response)
            => response != null && _retryableStatusCodes.Contains(response.StatusCode);

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

        private TimeSpan CalculateDelay(HttpResponseMessage response)
        {
            DateTime? requestTime = null;
            DateTime? retryDate = null;
            TimeSpan backoffSeconds = TimeSpan.Zero;

            if (response.Headers.TryGetValues("Date", out var dates) && dates != null)
            {
                requestTime = DateTimeOffset.Parse(dates.First()).UtcDateTime;
            }

            if (response.Headers.TryGetValues("x-rate-limit-reset", out var rateLimits) && rateLimits != null)
            {
                // If there are multiple headers, choose the smallest one
                retryDate = DateTimeOffset.FromUnixTimeSeconds(rateLimits.Min(x => long.Parse(x))).UtcDateTime;
            }

            if (requestTime.HasValue && retryDate.HasValue)
            {
                var backoffSecondsAux = retryDate.Value.Subtract(requestTime.Value).Add(new TimeSpan(0, 0, _backoffSecondsDelta));
                // _requestTimeout <= 0 means no timeout
                if (_requestTimeout <= 0 || (_requestTimeout > 0 && backoffSecondsAux.Seconds <= _requestTimeout))
                {
                    backoffSeconds = backoffSecondsAux;
                }
            }

            return backoffSeconds;
        }
    }
}
