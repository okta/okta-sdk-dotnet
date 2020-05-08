﻿// <copyright file="MockedStringRequestExecutor.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
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
