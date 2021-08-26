// <copyright file="PolicyRuleActionsEnrollSelf.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of PolicyRuleActionsEnrollSelf values in the Okta API.
    /// </summary>
    public sealed class PolicyRuleActionsEnrollSelf : StringEnum
    {
        /// <summary>The CHALLENGE PolicyRuleActionsEnrollSelf.</summary>
        public static PolicyRuleActionsEnrollSelf Challenge = new PolicyRuleActionsEnrollSelf("CHALLENGE");

        /// <summary>The LOGIN PolicyRuleActionsEnrollSelf.</summary>
        public static PolicyRuleActionsEnrollSelf Login = new PolicyRuleActionsEnrollSelf("LOGIN");

        /// <summary>The NEVER PolicyRuleActionsEnrollSelf.</summary>
        public static PolicyRuleActionsEnrollSelf Never = new PolicyRuleActionsEnrollSelf("NEVER");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="PolicyRuleActionsEnrollSelf"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator PolicyRuleActionsEnrollSelf(string value) => new PolicyRuleActionsEnrollSelf(value);

        /// <summary>
        /// Creates a new <see cref="PolicyRuleActionsEnrollSelf"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public PolicyRuleActionsEnrollSelf(string value)
            : base(value)
        {
        }

    }
}
