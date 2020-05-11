// <copyright file="EventHookChannelConfigAuthSchemeType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of EventHookChannelConfigAuthSchemeType values in the Okta API.
    /// </summary>
    public sealed class EventHookChannelConfigAuthSchemeType : StringEnum
    {
        /// <summary>The HEADER EventHookChannelConfigAuthSchemeType.</summary>
        public static EventHookChannelConfigAuthSchemeType Header = new EventHookChannelConfigAuthSchemeType("HEADER");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="EventHookChannelConfigAuthSchemeType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator EventHookChannelConfigAuthSchemeType(string value) => new EventHookChannelConfigAuthSchemeType(value);

        /// <summary>
        /// Creates a new <see cref="EventHookChannelConfigAuthSchemeType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public EventHookChannelConfigAuthSchemeType(string value)
            : base(value)
        {
        }

    }
}
