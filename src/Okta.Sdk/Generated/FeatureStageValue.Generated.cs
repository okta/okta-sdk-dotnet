// <copyright file="FeatureStageValue.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of FeatureStageValue values in the Okta API.
    /// </summary>
    public sealed class FeatureStageValue : StringEnum
    {
        /// <summary>The EA FeatureStageValue.</summary>
        public static FeatureStageValue Ea = new FeatureStageValue("EA");

        /// <summary>The BETA FeatureStageValue.</summary>
        public static FeatureStageValue Beta = new FeatureStageValue("BETA");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="FeatureStageValue"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator FeatureStageValue(string value) => new FeatureStageValue(value);

        /// <summary>
        /// Creates a new <see cref="FeatureStageValue"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public FeatureStageValue(string value)
            : base(value)
        {
        }

    }
}
