// <copyright file="DefaultRequestExecutor.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Okta.Sdk.Internal
{
    public sealed class DefaultRequestExecutor : IRequestExecutor
    {
        private const string OktaClientUserAgentName = "oktasdk-dotnet";

        private readonly string _orgUrl;
        private readonly string _defaultUserAgent;
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;

        public DefaultRequestExecutor(string orgUrl, string token, ILogger logger)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException(nameof(token));
            }

            _orgUrl = EnsureCorrectOrgUrl(orgUrl);
            _defaultUserAgent = CreateUserAgent();
            _httpClient = CreateClient(_orgUrl, token, _defaultUserAgent);
            _logger = logger;
        }

        private static string EnsureCorrectOrgUrl(string orgUrl)
        {
            if (string.IsNullOrEmpty(orgUrl))
            {
                throw new ArgumentNullException(nameof(orgUrl));
            }

            if (!orgUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Org URL must start with https://");
            }

            if (!orgUrl.EndsWith("/"))
            {
                orgUrl += "/";
            }

            return orgUrl;
        }

        // TODO IFrameworkUserAgentBuilder
        private static string CreateUserAgent()
            => $"{OktaClientUserAgentName}/0.0.1"; // todo assembly version

        private static HttpClient CreateClient(string orgBaseUrl, string token, string userAgent)
        {
            var handler = new HttpClientHandler
            {
                AllowAutoRedirect = false,
            };

            var client = new HttpClient(handler, true)
            {
                BaseAddress = new Uri(orgBaseUrl, UriKind.Absolute),
            };

            client.DefaultRequestHeaders.Add("User-Agent", userAgent);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("SSWS", token);

            // Workaround for https://github.com/dotnet/corefx/issues/11224
            client.DefaultRequestHeaders.Add("Connection", "close");

            return client;
        }

        private string EnsureRelativeUrl(string uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                throw new ArgumentException("The request URI was empty.");
            }

            if (uri.StartsWith(_orgUrl))
            {
                return uri.Replace(_orgUrl, string.Empty);
            }

            if (uri.Contains("://"))
            {
                throw new InvalidOperationException($"The client is configured to connect to {_orgUrl}, but this request URI does not match: ${uri}");
            }

            return uri.TrimStart('/');
        }

        private async Task<HttpResponse<string>> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            _logger.LogTrace($"{request.Method} {request.RequestUri}");

            using (var response = await _httpClient.SendAsync(request, cancellationToken).ConfigureAwait(false))
            {
                _logger.LogTrace($"{(int)response.StatusCode} {request.RequestUri.PathAndQuery}");

                string stringContent = null;
                if (response.Content != null)
                {
                    stringContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                }

                return new HttpResponse<string>
                {
                    Headers = ExtractHeaders(response),
                    StatusCode = (int)response.StatusCode,
                    Payload = stringContent,
                };
            }
        }

        private IEnumerable<KeyValuePair<string, IEnumerable<string>>> ExtractHeaders(HttpResponseMessage response)
            => response.Headers.Concat(response.Content.Headers);

        public Task<HttpResponse<string>> GetAsync(string href, CancellationToken cancellationToken)
        {
            var path = EnsureRelativeUrl(href);

            var request = new HttpRequestMessage(HttpMethod.Get, new Uri(path, UriKind.Relative));
            return SendAsync(request, cancellationToken);
        }

        public async Task<string> GetBodyAsync(string href, CancellationToken cancellationToken)
        {
            var response = await GetAsync(href, cancellationToken).ConfigureAwait(false);
            return response.Payload;
        }

        public Task<HttpResponse<string>> PostAsync(string href, string body, CancellationToken cancellationToken)
        {
            var path = EnsureRelativeUrl(href);

            var request = new HttpRequestMessage(HttpMethod.Post, new Uri(path, UriKind.Relative));
            request.Content = new StringContent(body, System.Text.Encoding.UTF8);
            return SendAsync(request, cancellationToken);
        }

        public Task<HttpResponse<string>> PutAsync(string href, string body, CancellationToken cancellationToken)
        {
            var path = EnsureRelativeUrl(href);

            var request = new HttpRequestMessage(HttpMethod.Put, new Uri(path, UriKind.Relative));
            request.Content = new StringContent(body, System.Text.Encoding.UTF8);
            return SendAsync(request, cancellationToken);
        }

        public Task<HttpResponse<string>> DeleteAsync(string href, CancellationToken cancellationToken)
        {
            var path = EnsureRelativeUrl(href);

            var request = new HttpRequestMessage(HttpMethod.Delete, new Uri(path, UriKind.Relative));
            return SendAsync(request, cancellationToken);
        }
    }
}
