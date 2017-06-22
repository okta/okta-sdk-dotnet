// <copyright file="AuthenticationProviderType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// Do not modify this file directly. This file was automatically generated with:
// spec.json - 0.3.0

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public sealed class AuthenticationProviderType : StringEnum
    {
        public static AuthenticationProviderType ActiveDirectory = new AuthenticationProviderType("ACTIVE_DIRECTORY");

        public static AuthenticationProviderType Federation = new AuthenticationProviderType("FEDERATION");

        public static AuthenticationProviderType Ldap = new AuthenticationProviderType("LDAP");

        public static AuthenticationProviderType Okta = new AuthenticationProviderType("OKTA");

        public static AuthenticationProviderType Social = new AuthenticationProviderType("SOCIAL");

        public static AuthenticationProviderType Import = new AuthenticationProviderType("IMPORT");

        /// <summary>
        /// Creates a new <see cref="AuthenticationProviderType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public AuthenticationProviderType(string value)
            : base(value)
        {
        }
    }
}
