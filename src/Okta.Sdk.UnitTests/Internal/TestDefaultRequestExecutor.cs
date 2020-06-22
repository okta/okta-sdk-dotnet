using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Okta.Sdk.Configuration;
using Okta.Sdk.Internal;

namespace Okta.Sdk.UnitTests.Internal
{
    public class TestDefaultRequestExecutor : DefaultRequestExecutor
    {
        public TestDefaultRequestExecutor(OktaClientConfiguration configuration, HttpClient httpClient, ILogger logger, IRetryStrategy retryStrategy = null, IOAuthTokenProvider oAuthTokenProvider = null)
            : base(configuration, httpClient, logger, retryStrategy, oAuthTokenProvider)
        {
            VerbExecutionCounts = new Dictionary<HttpVerb, int>
            {
                { HttpVerb.Get, 0 },
                { HttpVerb.Post, 0 },
                { HttpVerb.Put, 0 },
                { HttpVerb.Delete, 0 },
            };
        }

        public Dictionary<HttpVerb, int> VerbExecutionCounts { get; set; }

        public string ReceivedHref { get; set; }

        public override Task<HttpResponse<string>> GetAsync(string href, IEnumerable<KeyValuePair<string, string>> headers, CancellationToken cancellationToken)
        {
            VerbExecutionCounts[HttpVerb.Get] += 1;
            return Task.FromResult(GetTestResponse());
        }

        public override Task<HttpResponse<string>> PostAsync(string href, IEnumerable<KeyValuePair<string, string>> headers, string body, CancellationToken cancellationToken)
        {
            VerbExecutionCounts[HttpVerb.Post] += 1;
            return Task.FromResult(GetTestResponse());
        }

        public override Task<HttpResponse<string>> PutAsync(string href, IEnumerable<KeyValuePair<string, string>> headers, string body, CancellationToken cancellationToken)
        {
            VerbExecutionCounts[HttpVerb.Put] += 1;
            return Task.FromResult(GetTestResponse());
        }

        public override Task<HttpResponse<string>> DeleteAsync(string href, IEnumerable<KeyValuePair<string, string>> headers, CancellationToken cancellationToken)
        {
            VerbExecutionCounts[HttpVerb.Delete] += 1;
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