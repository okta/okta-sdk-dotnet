// <copyright file="MockedStringRequestExecutor.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Abstractions;

namespace Okta.Sdk.UnitTests
{
    public class MockedStringRequestExecutor : IRequestExecutor
    {
        private readonly string _returnThis;

        public MockedStringRequestExecutor(string returnThis)
        {
            _returnThis = returnThis ?? throw new ArgumentNullException(nameof(returnThis));
        }

        public Task<string> GetBodyAsync(string href, CancellationToken cancellationToken)
            => Task.FromResult(_returnThis);

        public async Task<HttpResponse<string>> GetAsync(string href, CancellationToken cancellationToken)
            => new HttpResponse<string>
            {
                StatusCode = 200,
                Payload = await GetBodyAsync(href, cancellationToken),
            };

        public Task<HttpResponse<string>> PostAsync(string href, string body, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponse<string>> PutAsync(string href, string body, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponse<string>> DeleteAsync(string href, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
