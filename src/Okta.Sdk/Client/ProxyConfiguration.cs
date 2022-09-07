﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Okta.Sdk.Client
{
    /// <summary>
    /// HTTP proxy configuration for an API client.
    /// </summary>
    public sealed class ProxyConfiguration
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

        /// <summary>
        /// Gets a WebProxy's instance
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns>A WebProxy instance</returns>
        public static WebProxy GetProxy(ProxyConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var port = configuration.Port ?? 8080;
            var proxy = new WebProxy(configuration.Host, port);

            if (!string.IsNullOrEmpty(configuration.Username) || !string.IsNullOrEmpty(configuration.Password))
            {
                proxy.Credentials = new NetworkCredential(configuration.Username, configuration.Password);
            }

            return proxy;
        }

    }
}
