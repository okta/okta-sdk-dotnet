// <copyright file="ProfileMappingPropertyPushStatus.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of ProfileMappingPropertyPushStatus values in the Okta API.
    /// </summary>
    public sealed class ProfileMappingPropertyPushStatus : StringEnum
    {
        /// <summary>The PUSH ProfileMappingPropertyPushStatus.</summary>
        public static ProfileMappingPropertyPushStatus Push = new ProfileMappingPropertyPushStatus("PUSH");

        /// <summary>The DONT_PUSH ProfileMappingPropertyPushStatus.</summary>
        public static ProfileMappingPropertyPushStatus DontPush = new ProfileMappingPropertyPushStatus("DONT_PUSH");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="ProfileMappingPropertyPushStatus"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator ProfileMappingPropertyPushStatus(string value) => new ProfileMappingPropertyPushStatus(value);

        /// <summary>
        /// Creates a new <see cref="ProfileMappingPropertyPushStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public ProfileMappingPropertyPushStatus(string value)
            : base(value)
        {
        }

    }
}
