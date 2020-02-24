// <copyright file="MockHttpMessageHandler.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk.UnitTests.Internal
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly string _returnThis;
        private readonly HttpStatusCode _statusCode;

        public int NumberOfCalls { get; private set; }

        public MockHttpMessageHandler(string returnThis, HttpStatusCode statusCode)
        {
            _returnThis = returnThis;
            _statusCode = statusCode;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            NumberOfCalls++;

            return new HttpResponseMessage
            {
                StatusCode = _statusCode,
                Content = new StringContent(_returnThis),
            };
        }
    }
}
