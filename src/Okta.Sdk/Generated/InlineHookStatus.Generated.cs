// <copyright file="InlineHookStatus.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of InlineHookStatus values in the Okta API.
    /// </summary>
    public sealed class InlineHookStatus : StringEnum
    {
        /// <summary>The ACTIVE InlineHookStatus.</summary>
        public static InlineHookStatus Active = new InlineHookStatus("ACTIVE");

        /// <summary>The INACTIVE InlineHookStatus.</summary>
        public static InlineHookStatus Inactive = new InlineHookStatus("INACTIVE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="InlineHookStatus"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator InlineHookStatus(string value) => new InlineHookStatus(value);

        /// <summary>
        /// Creates a new <see cref="InlineHookStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public InlineHookStatus(string value)
            : base(value)
        {
        }

    }
}
