// <copyright file="OktaClientConfigurationValidator.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Text.RegularExpressions;
using Okta.Sdk.Configuration;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// Helper validator class for OktaClient settings
    /// </summary>
    public class OktaClientConfigurationValidator
    {
        /// <summary>
        /// Validates the OktaClient configuration
        /// </summary>
        /// <param name="configuration">The configuration to be validated</param>
        public static void Validate(OktaClientConfiguration configuration)
        {
            if (string.IsNullOrEmpty(configuration.OktaDomain))
            {
                throw new ArgumentNullException(nameof(configuration.OktaDomain), "Your Okta URL is missing. Okta URLs should look like: https://{yourOktaDomain}. You can copy your domain from the Okta Developer Console.");
            }

            configuration.OktaDomain = EnsureTrailingSlash(configuration.OktaDomain);

            if (!configuration.OktaDomain.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentNullException(nameof(configuration.OktaDomain), "Your Okta URL must start with https. You can copy your domain from the Okta Developer Console.");
            }

            if (configuration.OktaDomain.IndexOf("{yourOktaDomain}", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                throw new ArgumentNullException(nameof(configuration.OktaDomain), "Replace {yourOktaDomain} with your Okta domain. You can copy your domain from the Okta Developer Console.");
            }

            if (configuration.OktaDomain.IndexOf("-admin.okta.com", StringComparison.OrdinalIgnoreCase) >= 0 ||
                configuration.OktaDomain.IndexOf("-admin.oktapreview.com", StringComparison.OrdinalIgnoreCase) >= 0 ||
                configuration.OktaDomain.IndexOf("-admin.okta-emea.com", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                throw new ArgumentNullException(nameof(configuration.OktaDomain), "Your Okta domain should not contain -admin. Your domain is: {valueWithoutAdmin}. You can copy your domain from the Okta Developer Console.");
            }

            if (configuration.OktaDomain.IndexOf(".com.com", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                throw new ArgumentNullException(nameof(configuration.OktaDomain), "It looks like there's a typo in your Okta domain. You can copy your domain from the Okta Developer Console.");
            }

            if (Regex.Matches(configuration.OktaDomain, "://").Count != 1)
            {
                throw new ArgumentNullException(nameof(configuration.OktaDomain), "It looks like there's a typo in your Okta domain. You can copy your domain from the Okta Developer Console.");
            }

            if (string.IsNullOrEmpty(configuration.Token))
            {
                throw new ArgumentNullException(nameof(configuration.Token), "You must supply an Okta API token. You can create one in the Okta developer dashboard.");
            }
        }

        /// <summary>
        /// Ensures that this URI ends with a trailing slash <c>/</c>
        /// </summary>
        /// <param name="oktaDomain">The okta domain URI string</param>
        /// <returns>The URI string, appended with <c>/</c> if necessary.</returns>
        public static string EnsureTrailingSlash(string oktaDomain)
        {
            if (!oktaDomain.EndsWith("/"))
            {
                oktaDomain += "/";
            }

            return oktaDomain;
        }
    }
}
