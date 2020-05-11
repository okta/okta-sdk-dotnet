// <copyright file="FeatureType.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of FeatureType values in the Okta API.
    /// </summary>
    public sealed class FeatureType : StringEnum
    {
        /// <summary>The self-service FeatureType.</summary>
        public static FeatureType SelfService = new FeatureType("self-service");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="FeatureType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator FeatureType(string value) => new FeatureType(value);

        /// <summary>
        /// Creates a new <see cref="FeatureType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public FeatureType(string value)
            : base(value)
        {
        }

    }
}
