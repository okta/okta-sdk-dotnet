// <copyright file="PolicyRuleResolver.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// Resolves PolicyRule resources based on the Type property.
    /// </summary>
    public class PolicyRuleResolver : AbstractResourceTypeResolver<PolicyRule>
    {
        /// <summary>
        /// Gets the type of a PolicyRule resource given its <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The resource data.</param>
        /// <returns>The resource type.</returns>
        protected override Type GetResolvedTypeInternal(IDictionary<string, object> data)
        {
            var value = data
                ?.Where(kv => kv.Key.Equals("type", StringComparison.OrdinalIgnoreCase))
                ?.FirstOrDefault().Value?.ToString();

            if (string.IsNullOrEmpty(value))
            {
                return typeof(PolicyRule);
            }
            
            if (value.Equals("PASSWORD"))
            {
                return typeof(PasswordPolicyRule);
            }
            
            if (value.Equals("SIGN_ON"))
            {
                return typeof(OktaSignOnPolicyRule);
            }
            
            return typeof(PolicyRule);
        }
    }
}
