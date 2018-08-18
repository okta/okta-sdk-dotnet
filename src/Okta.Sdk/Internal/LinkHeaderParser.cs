// <copyright file="LinkHeaderParser.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Linq;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// Parses Web Links according to <a href="https://tools.ietf.org/html/rfc5988">RFC 5988</a>.
    /// </summary>
    public static class LinkHeaderParser
    {
        /// <summary>
        /// Parses a set of header values to <see cref="WebLink"/>s.
        /// </summary>
        /// <param name="headerValues">The HTTP header values to parse.</param>
        /// <returns>Any Web Links found in the headers.</returns>
        public static IEnumerable<WebLink> Parse(params string[] headerValues)
        {
            if (headerValues == null || headerValues.Length == 0)
            {
                yield break;
            }

            var values = headerValues
                .Where(x => !string.IsNullOrEmpty(x))
                .SelectMany(x =>
            {
                if (!x.Contains(","))
                {
                    return new[] { x };
                }

                return x.Split(',');
            })
            .Select(x => x.Trim())
            .Where(x => !string.IsNullOrEmpty(x));

            foreach (var value in values)
            {
                var segments = value
                    .Split(';')
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrEmpty(x))
                    .ToArray();

                if (segments.Length < 2)
                {
                    continue;
                }

                var targetToken = segments[0];
                var validTarget = targetToken.StartsWith("<") && targetToken.EndsWith(">");
                if (!validTarget)
                {
                    continue;
                }

                var target = targetToken.TrimStart('<').TrimEnd('>');

                string relation = null;
                var relationToken = segments.Where(x => x.StartsWith("rel=")).SingleOrDefault();
                var validRelation = !string.IsNullOrEmpty(relationToken) && relationToken.StartsWith("rel=\"") && relationToken.EndsWith("\"");
                if (validRelation)
                {
                    var start = "rel=\"".Length;
                    relation = relationToken.Substring(start, relationToken.Length - start - 1);
                }

                yield return new WebLink(target, relation);
            }
        }

        /// <summary>
        /// Parses a set of header values to <see cref="WebLink"/>s.
        /// </summary>
        /// <param name="headerValues">The HTTP header values to parse.</param>
        /// <returns>
        /// Any Web Links found in the headers. If <paramref name="headerValues"/> is null, an empty enumerable is returned.
        /// </returns>
        public static IEnumerable<WebLink> Parse(IEnumerable<string> headerValues)
            => Parse(headerValues?.ToArray() ?? new string[0]);
    }
}
