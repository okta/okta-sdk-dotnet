// <copyright file="SubscriptionStatus.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of SubscriptionStatus values in the Okta API.
    /// </summary>
    public sealed class SubscriptionStatus : StringEnum
    {
        /// <summary>The subscribed SubscriptionStatus.</summary>
        public static SubscriptionStatus Subscribed = new SubscriptionStatus("subscribed");

        /// <summary>The unsubscribed SubscriptionStatus.</summary>
        public static SubscriptionStatus Unsubscribed = new SubscriptionStatus("unsubscribed");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="SubscriptionStatus"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator SubscriptionStatus(string value) => new SubscriptionStatus(value);

        /// <summary>
        /// Creates a new <see cref="SubscriptionStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public SubscriptionStatus(string value)
            : base(value)
        {
        }

    }
}
