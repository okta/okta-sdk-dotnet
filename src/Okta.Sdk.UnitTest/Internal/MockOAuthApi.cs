using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Api;
using Okta.Sdk.Client;

namespace Okta.Sdk.UnitTest.Internal
{
    public class MockOAuthApi : IOAuthApi
    {
        private Queue<string> _returnQueue;
        public MockOAuthApi(IReadableConfiguration configuration, Queue<string> returnQueue = null)
        {
            Configuration = configuration;
            _returnQueue = returnQueue;
        }
        public IReadableConfiguration Configuration { get ; set; }
        public ExceptionFactory ExceptionFactory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string GetBasePath()
        {
            return "https://foo.com";
        }

        public Task<OAuthTokenResponse> GetBearerTokenAsync(CancellationToken cancellationToken = default)
        {
            var token = _returnQueue?.Dequeue() ?? "foo";
            return Task.FromResult<OAuthTokenResponse>(new OAuthTokenResponse { AccessToken = token });
        }

        public Task<ApiResponse<OAuthTokenResponse>> GetBearerTokenWithHttpInfoAsync(CancellationToken cancellationToken = default)
        {
            return null;
        }
    }
}
