// <copyright file="FeatureStageState.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of FeatureStageState values in the Okta API.
    /// </summary>
    public sealed class FeatureStageState : StringEnum
    {
        /// <summary>The OPEN FeatureStageState.</summary>
        public static FeatureStageState Open = new FeatureStageState("OPEN");

        /// <summary>The CLOSED FeatureStageState.</summary>
        public static FeatureStageState Closed = new FeatureStageState("CLOSED");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="FeatureStageState"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator FeatureStageState(string value) => new FeatureStageState(value);

        /// <summary>
        /// Creates a new <see cref="FeatureStageState"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public FeatureStageState(string value)
            : base(value)
        {
        }

    }
}
