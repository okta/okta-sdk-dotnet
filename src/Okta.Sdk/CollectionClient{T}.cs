// <copyright file="CollectionClient{T}.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using Okta.Sdk.Abstractions;

namespace Okta.Sdk
{
    public sealed class CollectionClient<T> : IAsyncEnumerable<T>
        where T : Resource, new()
    {
        private readonly IDataStore _dataStore;
        private readonly HttpRequest _initialRequest;

        public CollectionClient(
            IDataStore dataStore,
            HttpRequest initialRequest)
        {
            _dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
            _initialRequest = initialRequest ?? throw new ArgumentNullException(nameof(initialRequest));
        }

        public IAsyncEnumerator<T> GetEnumerator()
            => new CollectionAsyncEnumerator<T>(_dataStore, _initialRequest);
    }
}
