// <copyright file="IRetryStrategy.cs" company="Okta, Inc">
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
    /// Interface for retry strategies
    /// </summary>
    public interface IRetryStrategy
    {
        /// <summary>
        /// Retries an operation
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <param name="operation">The operation to retry</param>
        /// <returns>The response</returns>
        Task<HttpResponseMessage> WaitAndRetryAsync(HttpRequestMessage request, CancellationToken cancellationToken, Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> operation);
    }
}
