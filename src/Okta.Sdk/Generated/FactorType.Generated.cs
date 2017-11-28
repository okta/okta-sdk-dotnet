// <copyright file="FactorType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of FactorType values in the Okta API.
    /// </summary>
    public sealed class FactorType : StringEnum
    {
        /// <summary>The push FactorType.</summary>
        public static FactorType Push = new FactorType("push");

        /// <summary>The sms FactorType.</summary>
        public static FactorType Sms = new FactorType("sms");

        /// <summary>The call FactorType.</summary>
        public static FactorType Call = new FactorType("call");

        /// <summary>The token FactorType.</summary>
        public static FactorType Token = new FactorType("token");

        /// <summary>The token:software:totp FactorType.</summary>
        public static FactorType TokenSoftwareTotp = new FactorType("token:software:totp");

        /// <summary>The token:hardware FactorType.</summary>
        public static FactorType TokenHardware = new FactorType("token:hardware");

        /// <summary>The question FactorType.</summary>
        public static FactorType Question = new FactorType("question");

        /// <summary>The web FactorType.</summary>
        public static FactorType Web = new FactorType("web");

        /// <summary>The email FactorType.</summary>
        public static FactorType Email = new FactorType("email");

        /// <summary>
        /// Creates a new <see cref="FactorType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public FactorType(string value)
            : base(value)
        {
        }
    }
}
