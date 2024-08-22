/*
 * Okta Admin Management
 *
 * Allows customers to easily access the Okta Management APIs
 *
 * The version of the OpenAPI document: 2024.07.0
 * Contact: devex-public@okta.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using Polly;
using Polly.Timeout;
using System;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;

namespace Okta.Sdk.Client
{
    /// <summary>
    /// Configuration class to set the polly retry policies to be applied to the requests.
    /// </summary>
    public static class RetryConfiguration
    {
        /// <summary>
        /// Async retry policy
        /// </summary>
        public static AsyncPolicy<RestResponse> AsyncRetryPolicy { get; set; }
    }
    
     
    /// <summary>
    /// The default retry strategy.
    /// </summary>
    public static class DefaultRetryStrategy
    {
        public static string XOktaRetryCountHeader = "x-Okta-Retry-Count";
        public static string XOktaRetryForHeader = "X-Okta-Retry-For";
        public static string XOktaRequestId = "X-Okta-Request-Id";
     
        /// <summary>
        /// Add retry headers to the request
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="request">The request.</param>
        public static void AddRetryHeaders (Context context, RestRequest request)
        {
            if (context.Keys.Contains(XOktaRetryCountHeader))
            {
                request.AddOrUpdateHeader(XOktaRetryCountHeader, context[XOktaRetryCountHeader].ToString());
            }

            if (context.Keys.Contains(XOktaRequestId))
            {
                request.AddOrUpdateHeader(XOktaRetryForHeader, context[XOktaRequestId].ToString());
            }
        }

        /// <summary>
        /// Add retry headers to the request if they are present in the context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="request">The request.</param>
        /// <returns>true if headers were added to the request, false otherwise.</returns>
        public static bool TryAddRetryHeaders(Context context, RestRequest request)
        {
            bool retryHeadersAdded = false;

            if (context.Keys.Contains(XOktaRetryCountHeader))
            {
                retryHeadersAdded = true;
                request.AddOrUpdateHeader(XOktaRetryCountHeader, context[XOktaRetryCountHeader].ToString());
            }

            if (context.Keys.Contains(XOktaRequestId))
            {
                retryHeadersAdded = true;
                request.AddOrUpdateHeader(XOktaRetryForHeader, context[XOktaRequestId].ToString());
            }

            return retryHeadersAdded;
        }
        
        /// <summary>
        /// Gets the policy to be used for retrying requests.
        /// </summary>
        /// <param name="configuration">The configuration</param>
        /// <param name="onRetryAsyncFunc">The function to call before retrying a request</param>
        /// <returns></returns>
        public static Polly.AsyncPolicy<RestResponse> GetRetryPolicy(IReadableConfiguration configuration, Func<DelegateResult<RestResponse>, TimeSpan, int, Context, Task> onRetryAsyncFunc = null)
        {
            AsyncTimeoutPolicy timeoutPolicy = null;
            if (configuration.RequestTimeout.HasValue && configuration.RequestTimeout.Value > 0)
            {
                // Timeout in seconds
                timeoutPolicy = Policy.TimeoutAsync(new TimeSpan(0, 0, 0, 0, configuration.RequestTimeout.Value));
            }

            AsyncPolicy<RestResponse> retryAsyncPolicy = Policy
                .Handle<ApiException>(ex => ex.ErrorCode == 429)
                .OrResult<RestResponse>(r => (int)r.StatusCode == 429)
                .WaitAndRetryAsync(configuration.MaxRetries.Value,
                    sleepDurationProvider: (retryAttempt, response,
                        context) => CalculateDelay(retryAttempt, response, context),
                    onRetryAsync: (response, timeSpan, retryAttempt, ctx) =>
                        OnRetryAsync(response, timeSpan, retryAttempt, ctx, onRetryAsyncFunc)
                );

            AsyncPolicy<RestResponse> finalPolicy = retryAsyncPolicy;

            // Combine timeout + retry policies
            if (timeoutPolicy != null)
            {
                finalPolicy = timeoutPolicy.WrapAsync(retryAsyncPolicy);
            }

            return finalPolicy;
        }

        private static TimeSpan CalculateDelay(int retryCount, DelegateResult<RestResponse> response, Context context)
        {
            DateTime? requestTime = null;
            DateTime? retryDate = null;
            TimeSpan backoffSeconds = TimeSpan.Zero;
            int defaultBackoffSecondsDelta = 1;

            var dateParam = response.Result.Headers.FirstOrDefault(x =>
                x.Name.Equals("Date", StringComparison.InvariantCultureIgnoreCase));
            
            if (dateParam != null)
            {
                requestTime = DateTimeOffset.Parse(dateParam.Value.ToString()).UtcDateTime;
            }

            var rateLimitsParam = response.Result.Headers.Where(x =>
                x.Name.Equals("x-rate-limit-reset", StringComparison.InvariantCultureIgnoreCase)).Select(x => x).ToList();

            if (rateLimitsParam != null)
            {
                // If there are multiple headers, choose the smallest one
                retryDate = DateTimeOffset.FromUnixTimeSeconds(rateLimitsParam.Min(x => long.Parse(x.Value.ToString()))).UtcDateTime;
            }

            var requestIdParam = response.Result.Headers.FirstOrDefault(x =>
                x.Name.Equals(XOktaRequestId, StringComparison.InvariantCultureIgnoreCase));

            if (requestIdParam != null)
            {
                AddToContext(context, XOktaRequestId, requestIdParam.Value.ToString());
            }

            if (requestTime.HasValue && retryDate.HasValue)
            {
                backoffSeconds = retryDate.Value.Subtract(requestTime.Value)
                    .Add(new TimeSpan(0, 0, defaultBackoffSecondsDelta));
            }

            return backoffSeconds;
        }


        private static void AddToContext(Context context, string key, object value)
        {
            if (context.Any(x =>
                String.Equals(x.Key, key, StringComparison.InvariantCultureIgnoreCase)))
            {
                context.Remove(key);
            }

            context.Add(key, value);
        }

        private static Task OnRetryAsync(DelegateResult<RestResponse> response, TimeSpan delayingForTimeSpan, int retryCount, Context context, Func<DelegateResult<RestResponse>, TimeSpan, int, Context, Task> onRetryAsyncFunc = null)
        {
            AddToContext(context, XOktaRetryCountHeader, retryCount);

            if (onRetryAsyncFunc != null)
            {
                onRetryAsyncFunc(response, delayingForTimeSpan, retryCount, context);
            }
            return Task.CompletedTask;
        }
    }
}
