// <copyright file="MockedCollectionRequestExecutor{T}.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Okta.Sdk.Internal;

namespace Okta.Sdk.UnitTests.Internal
{
    public class MockedCollectionRequestExecutor<T> : IRequestExecutor
    {
        private const string BaseUrl = "http://mock-collection.dev";
        private readonly int _pageSize;
        private readonly T[] _items;

        private int _currentPage = 0;

        public string OktaDomain => BaseUrl;

        public MockedCollectionRequestExecutor(int pageSize, IEnumerable<T> items)
        {
            _pageSize = pageSize;
            _items = items.ToArray();
        }

        public Task<string> GetBodyAsync(string href, CancellationToken ct)
        {
            var resources = _items
                .Skip(_currentPage * _pageSize)
                .Take(_pageSize)
                .Cast<Resource>();

            var itemData = resources
                .Select(x => x.GetData())
                .ToArray();

            // Increment page
            _currentPage++;

            var serializer = new DefaultSerializer();

            return Task.FromResult(serializer.Serialize(itemData));
        }

        public async Task<HttpResponse<string>> GetAsync(string href, IEnumerable<KeyValuePair<string, string>> headers, CancellationToken cancellationToken)
        {
            var responseHeaders = new List<KeyValuePair<string, IEnumerable<string>>>
            {
                new KeyValuePair<string, IEnumerable<string>>("Link", new[] { $"<{BaseUrl}?page={_currentPage}>; rel=\"self\"" }),
            };

            if ((_currentPage + 1) * _pageSize < _items.Length)
            {
                responseHeaders.Add(new KeyValuePair<string, IEnumerable<string>>("Link", new[] { $"<{BaseUrl}?page={_currentPage + 1}>; rel=\"next\"" }));
            }

            return new HttpResponse<string>
            {
                StatusCode = 200,
                Headers = responseHeaders,
                Payload = await GetBodyAsync(href, cancellationToken),
            };
        }

        public Task<HttpResponse<string>> PostAsync(string href, IEnumerable<KeyValuePair<string, string>> headers, string body, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponse<string>> PutAsync(string href, IEnumerable<KeyValuePair<string, string>> headers, string body, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponse<string>> DeleteAsync(string href, IEnumerable<KeyValuePair<string, string>> headers, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
