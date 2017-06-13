// <copyright file="MockedCollectionRequestExecutor{T}.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Okta.Sdk.Internal;

namespace Okta.Sdk.UnitTests
{
    public class MockedCollectionRequestExecutor<T> : IRequestExecutor
    {
        private const string BaseUrl = "http://mock-collection.dev";
        private readonly int _pageSize;
        private readonly T[] _items;

        private int _currentPage = 0;

        public MockedCollectionRequestExecutor(int pageSize, IEnumerable<T> items)
        {
            _pageSize = pageSize;
            _items = items.ToArray();
        }

        public Task<string> GetBodyAsync(string href, CancellationToken ct)
        {
            var items = _items
                .Skip(_currentPage * _pageSize)
                .Take(_pageSize)
                .ToArray();

            // Increment page
            _currentPage++;

            return Task.FromResult(JsonConvert.SerializeObject(items));
        }

        public async Task<HttpResponse<string>> GetAsync(string href, CancellationToken cancellationToken)
        {
            var headers = new List<KeyValuePair<string, IEnumerable<string>>>
            {
                new KeyValuePair<string, IEnumerable<string>>("Link", new[] { $"<{BaseUrl}?page={_currentPage}>; rel=\"self\"" }),
            };

            if ((_currentPage + 1) * _pageSize < _items.Length)
            {
                headers.Add(new KeyValuePair<string, IEnumerable<string>>("Link", new[] { $"<{BaseUrl}?page={_currentPage + 1}>; rel=\"next\"" }));
            }

            return new HttpResponse<string>
            {
                StatusCode = 200,
                Headers = headers,
                Payload = await GetBodyAsync(href, cancellationToken),
            };
        }

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
