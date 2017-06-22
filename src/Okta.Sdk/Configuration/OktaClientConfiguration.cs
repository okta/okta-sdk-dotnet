// <copyright file="ApiClientConfiguration.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk.Configuration
{
    public sealed class OktaClientConfiguration
    {
        public const int DefaultConnectionTimeout = 30; // Seconds

        public int? ConnectionTimeout { get; set; } = DefaultConnectionTimeout;

        public string OrgUrl { get; set; }

        public ProxyConfiguration Proxy { get; set; }

        public string Token { get; set; }
    }
}
