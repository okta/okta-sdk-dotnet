// <copyright file="ProxyConfiguration.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using Okta.Sdk.Internal;

namespace Okta.Sdk.Configuration
{
    /// <summary>
    /// HTTP proxy configuration for an <see cref="IOktaClient">OktaClient</see>.
    /// </summary>
    public sealed class ProxyConfiguration : IDeepCloneable<ProxyConfiguration>
    {
        /// <summary>
        /// Gets or sets the proxy port.
        /// </summary>
        /// <value>
        /// The proxy port.
        /// </value>
        public int? Port { get; set; }

        /// <summary>
        /// Gets or sets the proxy hostname.
        /// </summary>
        /// <value>
        /// The proxy hostname.
        /// </value>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the proxy username.
        /// </summary>
        /// <value>
        /// The proxy username.
        /// </value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the proxy password.
        /// </summary>
        /// <value>
        /// The proxy password.
        /// </value>
        public string Password { get; set; }

        /// <inheritdoc/>
        public ProxyConfiguration DeepClone()
            => new ProxyConfiguration
            {
                Port = Port.HasValue ? this.Port.Value : (int?)null,
                Host = Host,
                Username = Username,
                Password = Password,
            };
    }
}
