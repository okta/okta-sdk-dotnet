using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Okta.Sdk.Internal
{
    public class HttpRequestMessageProvider : IHttpRequestMessageProvider
    {
        private readonly Dictionary<HttpVerb, HttpMethod> _httpMethods = new Dictionary<HttpVerb, HttpMethod>
        {
            { HttpVerb.Get, HttpMethod.Get },
            { HttpVerb.Post, HttpMethod.Post },
            { HttpVerb.Put, HttpMethod.Put },
            { HttpVerb.Delete, HttpMethod.Delete },
        };

        public static IHttpRequestMessageProvider Default => new HttpRequestMessageProvider();

        public HttpRequestMessage CreateHttpRequestMessage(HttpRequest httpRequest, string relativePath)
        {
            var httpRequestMessage = new HttpRequestMessage(_httpMethods[httpRequest.Verb], new Uri(relativePath, UriKind.Relative));
            ApplyHeadersToRequest(
                httpRequestMessage,
                httpRequest.Headers.Keys
                    .Select(header => new KeyValuePair<string, string>(header, httpRequest.Headers[header]))
                    .ToList());
            httpRequest.SetHttpRequestMessageContent(httpRequestMessage);
            return httpRequestMessage;
        }

        private static void ApplyHeadersToRequest(HttpRequestMessage request, IEnumerable<KeyValuePair<string, string>> headers)
        {
            if (headers == null || !headers.Any())
            {
                return;
            }

            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
        }
    }
}