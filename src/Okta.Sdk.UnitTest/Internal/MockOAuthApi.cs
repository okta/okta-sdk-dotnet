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
        public MockOAuthApi(IReadableConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IReadableConfiguration Configuration { get ; set; }
        public ExceptionFactory ExceptionFactory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string GetBasePath()
        {
            return "https://foo.com";
        }

        public Task<OAuthTokenResponse> GetBearerTokenAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult<OAuthTokenResponse>(new OAuthTokenResponse { AccessToken = "foo" });
        }

        public Task<ApiResponse<OAuthTokenResponse>> GetBearerTokenWithHttpInfoAsync(CancellationToken cancellationToken = default)
        {
            return null;
        }
    }
}
