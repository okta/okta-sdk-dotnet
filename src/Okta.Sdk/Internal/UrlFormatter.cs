// <copyright file="UrlFormatter.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Linq;
using System.Net;
using System.Text;

namespace Okta.Sdk.Internal
{
    public static class UrlFormatter
    {
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

        public static string ApplyParametersToPath(HttpRequest request)
        {
            var updatedPath = new StringBuilder(request.Uri);

            foreach (var pathParam in request.PathParams)
            {
                updatedPath.Replace("{" + pathParam.Key + "}", pathParam.Value?.ToString());
            }

            if (!request.QueryParams.Any())
            {
                return updatedPath.ToString();
            }

            var addedQuestionMark = false;
            if (!request.Uri.Contains("?"))
            {
                updatedPath = updatedPath.Append("?");
                addedQuestionMark = true;
            }

            foreach (var queryParam in request.QueryParams)
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
