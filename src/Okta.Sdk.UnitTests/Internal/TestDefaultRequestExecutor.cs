using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Okta.Sdk.Configuration;
using Okta.Sdk.Internal;

namespace Okta.Sdk.UnitTests.Internal
{
    public class TestDefaultRequestExecutor : IRequestExecutor
    {
        public TestDefaultRequestExecutor(OktaClientConfiguration configuration, HttpClient httpClient, ILogger logger, IRetryStrategy retryStrategy = null, IOAuthTokenProvider oAuthTokenProvider = null)
        {
            VerbExecutionCounts = new Dictionary<HttpVerb, int>
            {
                { HttpVerb.GET, 0 },
                { HttpVerb.POST, 0 },
                { HttpVerb.PUT, 0 },
                { HttpVerb.DELETE, 0 },
            };
        }

        public Dictionary<HttpVerb, int> VerbExecutionCounts { get; set; }

        public string ReceivedHref { get; set; }

        public Task<HttpResponse<string>> ExecuteRequestAsync(HttpRequest request, CancellationToken cancellationToken)
        {
            switch (request.Verb)
            {
                case HttpVerb.GET:
                    return GetAsync(request.Uri, request.Headers, cancellationToken);
                case HttpVerb.POST:
                    return PostAsync(request.Uri, request.Headers, request.GetBody(), cancellationToken);
                case HttpVerb.PUT:
                    return PutAsync(request.Uri, request.Headers, request.GetBody(), cancellationToken);
                case HttpVerb.DELETE:
                    return DeleteAsync(request.Uri, request.Headers, cancellationToken);
                default:
                    return GetAsync(request.Uri, request.Headers, cancellationToken);
            }
        }

        public Task<HttpResponse<string>> GetAsync(string href, IEnumerable<KeyValuePair<string, string>> headers, CancellationToken cancellationToken)
        {
            VerbExecutionCounts[HttpVerb.GET] += 1;
            return Task.FromResult(GetTestResponse());
        }

        public Task<HttpResponse<string>> PostAsync(HttpRequest request, CancellationToken cancellationToken)
        {
            var headers = request
                .Headers
                .Keys
                .Select(header => new KeyValuePair<string, string>(header, request.Headers[header]))
                .ToList();
            return PostAsync(request.Uri, headers, request.GetBody(), cancellationToken);
        }

        public Task<HttpResponse<string>> PostAsync(string href, IEnumerable<KeyValuePair<string, string>> headers, string body, CancellationToken cancellationToken)
        {
            VerbExecutionCounts[HttpVerb.POST] += 1;
            return Task.FromResult(GetTestResponse());
        }

        public Task<HttpResponse<string>> PutAsync(string href, IEnumerable<KeyValuePair<string, string>> headers, string body, CancellationToken cancellationToken)
        {
            VerbExecutionCounts[HttpVerb.PUT] += 1;
            return Task.FromResult(GetTestResponse());
        }

        public Task<HttpResponse<string>> DeleteAsync(string href, IEnumerable<KeyValuePair<string, string>> headers, CancellationToken cancellationToken)
        {
            VerbExecutionCounts[HttpVerb.DELETE] += 1;
            return Task.FromResult(GetTestResponse());
        }

        private HttpResponse<string> GetTestResponse()
        {
            return new HttpResponse<string>
            {
                StatusCode = 200,
                Payload = "test",
            };
        }
    }
}