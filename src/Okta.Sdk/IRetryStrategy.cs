// <copyright file="IRetryStrategy.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>
    /// Interface for retry strategies
    /// </summary>
    public interface IRetryStrategy
    {
        /// <summary>
        /// Gets or sets the number of times to retry
        /// </summary>
        int MaxRetries { get; set; }

        /// <summary>
        /// Gets or sets the request timeout in seconds
        /// </summary>
        int RequestTimeOut { get; set; }

        /// <summary>
        /// Retries an operation
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="operation">The operation to retry</param>
        /// <returns>The response</returns>
        Task<HttpResponseMessage> WaitAndRetryAsync(HttpRequestMessage request, Func<HttpRequestMessage, Task<HttpResponseMessage>> operation);
    }
}
