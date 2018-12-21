// <copyright file="NoRetryStrategy.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>
    /// No retry strategy
    /// </summary>
    public class NoRetryStrategy : IRetryStrategy
    {
        /// <inheritdoc/>
        public async Task<HttpResponseMessage> WaitAndRetryAsync(HttpRequestMessage request, CancellationToken cancellationToken, Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> operation)
        {
            return await operation(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
