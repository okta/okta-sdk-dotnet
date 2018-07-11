// <copyright file="ApplicationResolver.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// Resolves Application resources based on the SignOnMode property.
    /// </summary>
    public class ApplicationResolver : AbstractResourceTypeResolver<Application>
    {
        /// <summary>
        /// Gets the type of a Application resource given its <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The resource data.</param>
        /// <returns>The resource type.</returns>
        protected override Type GetResolvedTypeInternal(IDictionary<string, object> data)
        {
            var value = data
                ?.Where(kv => kv.Key.Equals("signOnMode", StringComparison.OrdinalIgnoreCase))
                ?.FirstOrDefault().Value?.ToString();

            if (string.IsNullOrEmpty(value))
            {
                return typeof(Application);
            }
            
            if (value.Equals("AUTO_LOGIN"))
            {
                return typeof(AutoLoginApplication);
            }
            
            if (value.Equals("BASIC_AUTH"))
            {
                return typeof(BasicAuthApplication);
            }
            
            if (value.Equals("BOOKMARK"))
            {
                return typeof(BookmarkApplication);
            }
            
            if (value.Equals("BROWSER_PLUGIN"))
            {
                return typeof(BrowserPluginApplication);
            }
            
            if (value.Equals("OPENID_CONNECT"))
            {
                return typeof(OpenIdConnectApplication);
            }
            
            if (value.Equals("SAML_2_0"))
            {
                return typeof(SamlApplication);
            }
            
            if (value.Equals("SECURE_PASSWORD_STORE"))
            {
                return typeof(SecurePasswordStoreApplication);
            }
            
            if (value.Equals("WS_FEDERATION"))
            {
                return typeof(WsFederationApplication);
            }
            
            return typeof(Application);
        }
    }
}
