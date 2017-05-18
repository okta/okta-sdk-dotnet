// <copyright file="CollectionClient{T}.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

namespace Okta.Sdk
{
    public sealed class CollectionClient<T> : IAsyncEnumerable<T>
        where T : Resource, new()
    {
        private readonly IDataStore _dataStore;
        private readonly string _uri;
        private readonly KeyValuePair<string, object>[] _initialQueryParameters;

        public CollectionClient(
            IDataStore dataStore,
            string uri,
            IEnumerable<KeyValuePair<string, object>> queryParameters)
        {
            _dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
            _uri = uri ?? throw new ArgumentNullException(nameof(uri));
            _initialQueryParameters = queryParameters?.ToArray() ?? new KeyValuePair<string, object>[0];
        }

        public IAsyncEnumerator<T> GetEnumerator()
            => new CollectionAsyncEnumerator<T>(_dataStore, _uri, _initialQueryParameters);
    }
}
