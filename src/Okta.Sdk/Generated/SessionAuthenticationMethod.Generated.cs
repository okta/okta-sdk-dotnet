// <copyright file="SessionAuthenticationMethod.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of SessionAuthenticationMethod values in the Okta API.
    /// </summary>
    public sealed class SessionAuthenticationMethod : StringEnum
    {
        /// <summary>The pwd SessionAuthenticationMethod.</summary>
        public static SessionAuthenticationMethod Pwd = new SessionAuthenticationMethod("pwd");

        /// <summary>The swk SessionAuthenticationMethod.</summary>
        public static SessionAuthenticationMethod Swk = new SessionAuthenticationMethod("swk");

        /// <summary>The hwk SessionAuthenticationMethod.</summary>
        public static SessionAuthenticationMethod Hwk = new SessionAuthenticationMethod("hwk");

        /// <summary>The otp SessionAuthenticationMethod.</summary>
        public static SessionAuthenticationMethod Otp = new SessionAuthenticationMethod("otp");

        /// <summary>The sms SessionAuthenticationMethod.</summary>
        public static SessionAuthenticationMethod Sms = new SessionAuthenticationMethod("sms");

        /// <summary>The tel SessionAuthenticationMethod.</summary>
        public static SessionAuthenticationMethod Tel = new SessionAuthenticationMethod("tel");

        /// <summary>The geo SessionAuthenticationMethod.</summary>
        public static SessionAuthenticationMethod Geo = new SessionAuthenticationMethod("geo");

        /// <summary>The fpt SessionAuthenticationMethod.</summary>
        public static SessionAuthenticationMethod Fpt = new SessionAuthenticationMethod("fpt");

        /// <summary>The kba SessionAuthenticationMethod.</summary>
        public static SessionAuthenticationMethod Kba = new SessionAuthenticationMethod("kba");

        /// <summary>The mfa SessionAuthenticationMethod.</summary>
        public static SessionAuthenticationMethod Mfa = new SessionAuthenticationMethod("mfa");

        /// <summary>
        /// Creates a new <see cref="SessionAuthenticationMethod"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public SessionAuthenticationMethod(string value)
            : base(value)
        {
        }
    }
}
