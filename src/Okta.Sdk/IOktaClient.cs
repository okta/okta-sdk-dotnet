// <copyright file="IOktaClient.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public interface IOktaClient
    {
        Task<T> GetAsync<T>(string href, CancellationToken cancellationToken = default(CancellationToken))
            where T : Resource, new();

        Task<TResponse> PostAsync<TResponse>(
            string href,
            object model,
            CancellationToken cancellationToken = default(CancellationToken))
            where TResponse : Resource, new();
    }
}
