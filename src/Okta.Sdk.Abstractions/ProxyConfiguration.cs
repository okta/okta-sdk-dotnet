// <copyright file="ProxyConfiguration.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk.Abstractions
{
    public sealed class ProxyConfiguration
    {
        public int? Port { get; set; }

        public string Host { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
