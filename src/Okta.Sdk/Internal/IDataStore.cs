// <copyright file="IDataStore.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk.Internal
{
    public interface IDataStore
    {
        IRequestExecutor RequestExecutor { get; }

        ISerializer Serializer { get; }

        Task<HttpResponse<T>> GetAsync<T>(HttpRequest request, CancellationToken cancellationToken)
            where T : Resource, new();

        Task<HttpResponse<IEnumerable<T>>> GetArrayAsync<T>(HttpRequest request, CancellationToken cancellationToken)
            where T : Resource, new();

        Task<HttpResponse<TResponse>> PostAsync<TResponse>(HttpRequest request, CancellationToken cancellationToken)
            where TResponse : Resource, new();

        Task<HttpResponse<TResponse>> PutAsync<TResponse>(HttpRequest request, CancellationToken cancellationToken)
            where TResponse : Resource, new();

        Task<HttpResponse> DeleteAsync(HttpRequest request, CancellationToken cancellationToken);
    }
}
