// <copyright file="UrlFormatter.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Linq;
using System.Net;
using System.Text;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// Contains helper methods for URL formatting.
    /// </summary>
    public static class UrlFormatter
    {
        /// <summary>
        /// Encodes values using URL encoding rules.
        /// </summary>
        /// <param name="value">The value to encode.</param>
        /// <returns>A URL encoded string.</returns>
        /// <remarks>Wraps built-in URL encoding functionality with existing logic.</remarks>
        public static string Encode(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            if (value is bool b)
            {
                return b.ToString().ToLower();
            }

            // TODO sanitize dates as ISO 8601

            return WebUtility.UrlEncode(value.ToString());
        }

        /// <summary>
        /// Applies path parameters to a URL template.
        /// </summary>
        /// <param name="request">The HTTP request options.</param>
        /// <returns>A URL with template variables replaced with matching path parameters.</returns>
        public static string ApplyParametersToPath(HttpRequest request)
        {
            var updatedPath = new StringBuilder(request.Uri);

            foreach (var pathParam in request.PathParameters)
            {
                updatedPath.Replace("{" + pathParam.Key + "}", pathParam.Value?.ToString());
            }

            if (!request.QueryParameters.Any())
            {
                return updatedPath.ToString();
            }

            var addedQuestionMark = false;
            if (!request.Uri.Contains("?"))
            {
                updatedPath = updatedPath.Append("?");
                addedQuestionMark = true;
            }

            foreach (var queryParam in request.QueryParameters)
            {
                var shouldAddAmpersand = !addedQuestionMark;
                addedQuestionMark = false;

                if (shouldAddAmpersand)
                {
                    updatedPath.Append("&");
                }

                updatedPath.Append($"{queryParam.Key}={Encode(queryParam.Value)}");
            }

            return updatedPath.ToString();
        }
    }
}
