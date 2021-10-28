// <copyright file="FactorStatus.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of FactorStatus values in the Okta API.
    /// </summary>
    public sealed class FactorStatus : StringEnum
    {
        /// <summary>The PENDING_ACTIVATION FactorStatus.</summary>
        public static FactorStatus PendingActivation = new FactorStatus("PENDING_ACTIVATION");

        /// <summary>The ACTIVE FactorStatus.</summary>
        public static FactorStatus Active = new FactorStatus("ACTIVE");

        /// <summary>The INACTIVE FactorStatus.</summary>
        public static FactorStatus Inactive = new FactorStatus("INACTIVE");

        /// <summary>The NOT_SETUP FactorStatus.</summary>
        public static FactorStatus NotSetup = new FactorStatus("NOT_SETUP");

        /// <summary>The ENROLLED FactorStatus.</summary>
        public static FactorStatus Enrolled = new FactorStatus("ENROLLED");

        /// <summary>The DISABLED FactorStatus.</summary>
        public static FactorStatus Disabled = new FactorStatus("DISABLED");

        /// <summary>The EXPIRED FactorStatus.</summary>
        public static FactorStatus Expired = new FactorStatus("EXPIRED");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="FactorStatus"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator FactorStatus(string value) => new FactorStatus(value);

        /// <summary>
        /// Creates a new <see cref="FactorStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public FactorStatus(string value)
            : base(value)
        {
        }

    }
}
