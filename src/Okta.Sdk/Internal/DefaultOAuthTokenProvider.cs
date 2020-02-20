using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Okta.Sdk.Configuration;

namespace Okta.Sdk.Internal
{
    public class DefaultOAuthTokenProvider : IOAuthTokenProvider
    {
        private OktaClientConfiguration Configuration { get; }

        private string _accessToken;

        private ResourceFactory _resourceFactory;

        private ILogger _logger;

        private HttpClient _httpClient;

        private IJwtGenerator _jwtGenerator;

        public DefaultOAuthTokenProvider(OktaClientConfiguration configuration, ResourceFactory resourceFactory, HttpClient httpClient = null, IJwtGenerator jwtGenerator = null, ILogger logger = null)
        {
            Configuration = configuration;
            _resourceFactory = resourceFactory;
            _logger = logger ?? NullLogger.Instance;
            _httpClient = httpClient ?? new HttpClient();
            _jwtGenerator = jwtGenerator ?? new DefaultJwtGenerator();
        }

        /// <summary>
        /// Gets an access token.
        /// </summary>
        /// <returns>The access token.</returns>
        public async Task<string> GetAccessTokenAsync(bool forceRenew = false)
        {
            if (string.IsNullOrEmpty(_accessToken) || forceRenew)
            {
                _accessToken = await RequestAccessTokenAsync().ConfigureAwait(false);
            }

            return _accessToken;
        }

        /// <summary>
        /// Requests an access token
        /// </summary>
        /// <returns>The access token.</returns>
        private async Task<string> RequestAccessTokenAsync()
        {
            _httpClient.BaseAddress = new Uri(Configuration.OktaDomain);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var jwtSecurityToken = _jwtGenerator.GenerateSignedJWT(Configuration);

            var accessTokenUri = $@"oauth2/v1/token?grant_type=client_credentials&scope={string.Join("+", Configuration.Scopes)}&client_assertion_type=urn:ietf:params:oauth:client-assertion-type:jwt-bearer&client_assertion={jwtSecurityToken.ToString()}";

            var request = new HttpRequestMessage(HttpMethod.Post, accessTokenUri) { Content = new FormUrlEncodedContent(new Dictionary<string, string>()) };
            using (var response = await _httpClient.SendAsync(request).ConfigureAwait(false))
            {
                if (response == null || response.Content == null)
                {
                    throw new InvalidOperationException("The access token response from the server was null.");
                }

                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var data = new DefaultSerializer().Deserialize(responseContent);

                if ((int)response.StatusCode < 200 || (int)response.StatusCode >= 300)
                {
                    throw new OktaOAuthException((int)response.StatusCode, _resourceFactory.CreateNew<OAuthApiError>(data));
                }

                if (!data.ContainsKey("access_token"))
                {
                    throw new MissingFieldException("Access token not found");
                }

                return data["access_token"].ToString();
            }
        }
    }
}
