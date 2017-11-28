// <copyright file="FactorResultType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of FactorResultType values in the Okta API.
    /// </summary>
    public sealed class FactorResultType : StringEnum
    {
        /// <summary>The SUCCESS FactorResultType.</summary>
        public static FactorResultType Success = new FactorResultType("SUCCESS");

        /// <summary>The CHALLENGE FactorResultType.</summary>
        public static FactorResultType Challenge = new FactorResultType("CHALLENGE");

        /// <summary>The WAITING FactorResultType.</summary>
        public static FactorResultType Waiting = new FactorResultType("WAITING");

        /// <summary>The FAILED FactorResultType.</summary>
        public static FactorResultType Failed = new FactorResultType("FAILED");

        /// <summary>The REJECTED FactorResultType.</summary>
        public static FactorResultType Rejected = new FactorResultType("REJECTED");

        /// <summary>The TIMEOUT FactorResultType.</summary>
        public static FactorResultType Timeout = new FactorResultType("TIMEOUT");

        /// <summary>The TIME_WINDOW_EXCEEDED FactorResultType.</summary>
        public static FactorResultType TimeWindowExceeded = new FactorResultType("TIME_WINDOW_EXCEEDED");

        /// <summary>The PASSCODE_REPLAYED FactorResultType.</summary>
        public static FactorResultType PasscodeReplayed = new FactorResultType("PASSCODE_REPLAYED");

        /// <summary>The ERROR FactorResultType.</summary>
        public static FactorResultType Error = new FactorResultType("ERROR");

        /// <summary>
        /// Creates a new <see cref="FactorResultType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public FactorResultType(string value)
            : base(value)
        {
        }
    }
}
