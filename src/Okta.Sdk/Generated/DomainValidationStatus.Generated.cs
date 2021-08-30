// <copyright file="DomainValidationStatus.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of DomainValidationStatus values in the Okta API.
    /// </summary>
    public sealed class DomainValidationStatus : StringEnum
    {
        /// <summary>The NOT_STARTED DomainValidationStatus.</summary>
        public static DomainValidationStatus NotStarted = new DomainValidationStatus("NOT_STARTED");

        /// <summary>The IN_PROGRESS DomainValidationStatus.</summary>
        public static DomainValidationStatus InProgress = new DomainValidationStatus("IN_PROGRESS");

        /// <summary>The VERIFIED DomainValidationStatus.</summary>
        public static DomainValidationStatus Verified = new DomainValidationStatus("VERIFIED");

        /// <summary>The COMPLETED DomainValidationStatus.</summary>
        public static DomainValidationStatus Completed = new DomainValidationStatus("COMPLETED");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="DomainValidationStatus"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator DomainValidationStatus(string value) => new DomainValidationStatus(value);

        /// <summary>
        /// Creates a new <see cref="DomainValidationStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public DomainValidationStatus(string value)
            : base(value)
        {
        }

    }
}
