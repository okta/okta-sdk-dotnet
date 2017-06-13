// <copyright file="ApiClientConfiguration.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk.Configuration
{
    public sealed class ApiClientConfiguration
    {
        public CacheManagerConfiguration CacheManager { get; set; }

        public int? ConnectionTimeout { get; set; } = 30; // Seconds

        public string OrgUrl { get; set; }

        public ProxyConfiguration Proxy { get; set; }

        public string Token { get; set; }
    }
}
