// <copyright file="DefaultHttpClient.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Okta.Sdk.Configuration;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// Represents the default HTTP client options.
    /// </summary>
    public static class DefaultHttpClient
    {
        /// <summary>
        /// Creates an <see cref="HttpClient"/> with the default options.
        /// </summary>
        /// <param name="connectionTimeout">The connection timeout in seconds.</param>
        /// <param name="proxyConfiguration">The proxy configuration, if any.</param>
        /// <param name="logger">The logger.</param>
        /// <returns>The HTTP client.</returns>
        public static HttpClient Create(
            int? connectionTimeout,
            ProxyConfiguration proxyConfiguration,
            ILogger logger)
        {
            logger = logger ?? NullLogger.Instance;

            var handler = new HttpClientHandler
            {
                AllowAutoRedirect = false,
            };

            if (proxyConfiguration != null)
            {
                handler.Proxy = new DefaultProxy(proxyConfiguration, logger);
                logger.LogInformation("Using proxy from configuration");
            }

            var client = new HttpClient(handler, true)
            {
                Timeout = TimeSpan.FromSeconds(connectionTimeout ?? OktaClientConfiguration.DefaultConnectionTimeout),
            };

            logger.LogTrace($"Using timeout of {client.Timeout} second(s) from configuration");

            return client;
        }
    }
}
