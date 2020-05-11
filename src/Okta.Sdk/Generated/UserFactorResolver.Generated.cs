// <copyright file="UserFactorResolver.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// Resolves UserFactor resources based on the FactorType property.
    /// </summary>
    public class UserFactorResolver : AbstractResourceTypeResolver<UserFactor>
    {
        /// <summary>
        /// Gets the type of a UserFactor resource given its <paramref name="data"/>.
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
                return typeof(UserFactor);
            }
            
            if (value.Equals("call"))
            {
                return typeof(CallUserFactor);
            }
            
            if (value.Equals("email"))
            {
                return typeof(EmailUserFactor);
            }
            
            if (value.Equals("push"))
            {
                return typeof(PushUserFactor);
            }
            
            if (value.Equals("question"))
            {
                return typeof(SecurityQuestionUserFactor);
            }
            
            if (value.Equals("sms"))
            {
                return typeof(SmsUserFactor);
            }
            
            if (value.Equals("token"))
            {
                return typeof(TokenUserFactor);
            }
            
            if (value.Equals("token:hardware"))
            {
                return typeof(HardwareUserFactor);
            }
            
            if (value.Equals("token:software:totp"))
            {
                return typeof(TotpUserFactor);
            }
            
            if (value.Equals("u2f"))
            {
                return typeof(U2fUserFactor);
            }
            
            if (value.Equals("web"))
            {
                return typeof(WebUserFactor);
            }
            
            return typeof(UserFactor);
        }
    }
}
