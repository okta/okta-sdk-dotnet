// <copyright file="FactorResolver.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// Resolves Factor resources based on the FactorType property.
    /// </summary>
    public class FactorResolver : AbstractResourceTypeResolver<Factor>
    {
        /// <summary>
        /// Gets the type of a Factor resource given its <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The resource data.</param>
        /// <returns>The resource type.</returns>
        protected override Type GetResolvedTypeInternal(IDictionary<string, object> data)
        {
            var value = data
                ?.Where(kv => kv.Key.Equals("factorType", StringComparison.OrdinalIgnoreCase))
                ?.FirstOrDefault().Value?.ToString();

            if (string.IsNullOrEmpty(value))
            {
                return typeof(Factor);
            }
            
            if (value.Equals("call"))
            {
                return typeof(CallFactor);
            }
            
            if (value.Equals("email"))
            {
                return typeof(EmailFactor);
            }
            
            if (value.Equals("push"))
            {
                return typeof(PushFactor);
            }
            
            if (value.Equals("question"))
            {
                return typeof(SecurityQuestionFactor);
            }
            
            if (value.Equals("sms"))
            {
                return typeof(SmsFactor);
            }
            
            if (value.Equals("token"))
            {
                return typeof(TokenFactor);
            }
            
            if (value.Equals("token:hardware"))
            {
                return typeof(HardwareFactor);
            }
            
            if (value.Equals("token:software:totp"))
            {
                return typeof(TotpFactor);
            }
            
            if (value.Equals("u2f"))
            {
                return typeof(U2fFactor);
            }
            
            if (value.Equals("web"))
            {
                return typeof(WebFactor);
            }
            
            return typeof(Factor);
        }
    }
}
