// <copyright file="OktaClientConfiguration.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Diagnostics;
using Okta.Sdk.Internal;

namespace Okta.Sdk.Configuration
{
    /// <summary>
    /// Configuration for an <see cref="IOktaClient">OktaClient</see>.
    /// </summary>
    public sealed class OktaClientConfiguration : IDeepCloneable<OktaClientConfiguration>
    {
        private bool _disableHttpsCheck = false;

        /// <summary>
        /// The default HTTP connection timeout in seconds.
        /// </summary>
        public const int DefaultConnectionTimeout = 30; // Seconds

        /// <summary>
        /// Gets or sets the HTTP connection timeout in seconds. If <c>null</c>, the default timeout is used.
        /// </summary>
        /// <value>
        /// The HTTP connection timeout in seconds.
        /// </value>
        public int? ConnectionTimeout { get; set; } = DefaultConnectionTimeout;

        /// <summary>
        /// Gets or sets the Okta Organization URL to use.
        /// </summary>
        /// <value>
        /// The Okta Organization URL to use.
        /// </value>
        /// <remarks>
        /// This URL is typically in the form <c>https://dev-12345.oktapreview.com</c>. If your Okta domain includes <c>-admin</c>, remove it.
        /// </remarks>
        public string OktaDomain { get; set; }

        /// <summary>
        /// Gets or sets the optional proxy to use for HTTP connections. If <c>null</c>, the default system proxy is used, if any.
        /// </summary>
        /// <value>
        /// The proxy to use for HTTP connections.
        /// </value>
        public ProxyConfiguration Proxy { get; set; }

        /// <summary>
        /// Gets or sets the Okta API token.
        /// </summary>
        /// <value>
        /// The Okta API token.
        /// </value>
        /// <remarks>An API token can be generated from the Okta developer dashboard.</remarks>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the flag to disable https check.
        /// This allows for insecure configurations and is NOT recommended for production use.
        /// </summary>
        public bool DisableHttpsCheck
        {
            get
            {
                return _disableHttpsCheck;
            }

            set
            {
                if (value)
                {
                    Trace.TraceWarning("Warning: HTTPS check is disabled. This allows for insecure configurations and is NOT recommended for production use.");
                }

                _disableHttpsCheck = value;
            }
        }

        /// <inheritdoc/>
        public OktaClientConfiguration DeepClone()
            => new OktaClientConfiguration
            {
                ConnectionTimeout = ConnectionTimeout.HasValue ? this.ConnectionTimeout.Value : (int?)null,
                OktaDomain = this.OktaDomain,
                Token = this.Token,
                Proxy = this.Proxy?.DeepClone(),
                DisableHttpsCheck = this.DisableHttpsCheck,
            };
    }
}
