// <copyright file="IOktaClient.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Abstractions;

namespace Okta.Sdk
{
    public interface IOktaClient
    {
        UserClient Users { get; }

        GroupClient Groups { get; }

        Task<T> GetAsync<T>(string href, CancellationToken cancellationToken = default(CancellationToken))
            where T : Resource, new();

        Task<T> GetAsync<T>(HttpRequest request, CancellationToken cancellationToken = default(CancellationToken))
            where T : Resource, new();

        Task PostAsync(
            string href,
            object model,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<TResponse> PostAsync<TResponse>(
            string href,
            object model,
            CancellationToken cancellationToken = default(CancellationToken))
            where TResponse : Resource, new();

        Task PostAsync(
            HttpRequest request,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<TResponse> PostAsync<TResponse>(
            HttpRequest request,
            CancellationToken cancellationToken = default(CancellationToken))
            where TResponse : Resource, new();

        Task PutAsync(
            string href,
            object model,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<TResponse> PutAsync<TResponse>(
            string href,
            object model,
            CancellationToken cancellationToken = default(CancellationToken))
            where TResponse : Resource, new();

        Task PutAsync(
            HttpRequest request,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<TResponse> PutAsync<TResponse>(
            HttpRequest request,
            CancellationToken cancellationToken = default(CancellationToken))
            where TResponse : Resource, new();

        Task DeleteAsync(
            string href,
            CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteAsync(
            HttpRequest request,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
