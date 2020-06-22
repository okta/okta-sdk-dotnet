// <copyright file="MockedStringRequestExecutor.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Internal;

namespace Okta.Sdk.UnitTests.Internal
{
    public class MockedStringRequestExecutor : IRequestExecutor
    {
        private readonly string _returnThis;
        private readonly int _statusCode;

        public string ReceivedHref { get; set; }
        public IEnumerable<KeyValuePair<string, string>> ReceivedHeaders { get; set; }

        public string OktaDomain => throw new NotImplementedException();

        public MockedStringRequestExecutor(string returnThis, int statusCode = 200)
        {
            _returnThis = returnThis;
            _statusCode = statusCode;
        }

        public Task<HttpResponse<string>> ExecuteRequestAsync(HttpRequest request, CancellationToken cancellationToken)
        {
            switch (request.Verb)
            {
                case HttpVerb.Get:
                    return GetAsync(request.Uri, request.Headers, cancellationToken);
                case HttpVerb.Post:
                    return PostAsync(request.Uri, request.Headers, request.GetBody(), cancellationToken);
                case HttpVerb.Put:
                    return PutAsync(request.Uri, request.Headers, request.GetBody(), cancellationToken);
                case HttpVerb.Delete:
                    return DeleteAsync(request.Uri, request.Headers, cancellationToken);
                default:
                    return GetAsync(request.Uri, request.Headers, cancellationToken);
            }
        }

        public Task<HttpResponse<string>> GetAsync(string href, IEnumerable<KeyValuePair<string, string>> headers, CancellationToken cancellationToken)
        {
            ReceivedHref = href;
            ReceivedHeaders = headers;

            return Task.FromResult(new HttpResponse<string>
            {
                StatusCode = _statusCode,
                Payload = _returnThis,
            });
        }

        public Task<HttpResponse<string>> PostAsync(HttpRequest request, CancellationToken cancellationToken)
        {
            var headers = request
                .Headers
                .Keys
                .Select(header => new KeyValuePair<string, string>(header, request.Headers[header]))
                .ToList();
            ReceivedHeaders = headers;
            return PostAsync(request.Uri, headers, request.GetBody(), cancellationToken);
        }

        public Task<HttpResponse<string>> PostAsync(string href, IEnumerable<KeyValuePair<string, string>> headers, string body, CancellationToken cancellationToken)
        {
            ReceivedHref = href;
            ReceivedHeaders = headers;

            return Task.FromResult(new HttpResponse<string>
            {
                StatusCode = _statusCode,
                Payload = _returnThis,
            });
        }

        public Task<HttpResponse<string>> PutAsync(string href, IEnumerable<KeyValuePair<string, string>> headers, string body, CancellationToken cancellationToken)
        {
            ReceivedHref = href;
            ReceivedHeaders = headers;

            return Task.FromResult(new HttpResponse<string>
            {
                StatusCode = _statusCode,
                Payload = _returnThis,
            });
        }

        public Task<HttpResponse<string>> DeleteAsync(string href, IEnumerable<KeyValuePair<string, string>> headers, CancellationToken cancellationToken)
        {
            ReceivedHref = href;
            ReceivedHeaders = headers;

            return Task.FromResult(new HttpResponse<string>
            {
                Payload = _returnThis,
                StatusCode = _statusCode,
            });
        }
    }
}
