using System;
using System.Collections.Generic;
using System.Linq;

namespace Okta.Sdk.Abstractions
{
    public static class LinkHeaderParser
    {
        public static IEnumerable<WebLink> Parse(params string[] headerValues)
        {
            if (headerValues == null || headerValues.Length == 0) yield break;

            var values = headerValues
                .Where(x => !string.IsNullOrEmpty(x))
                .SelectMany(x =>
            {
                if (!x.Contains(",")) return new[] { x };
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

                if (segments.Length < 2) continue;

                var targetToken = segments[0];
                var validTarget = targetToken.StartsWith("<") && targetToken.EndsWith(">");
                if (!validTarget) continue;

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

        public static IEnumerable<WebLink> Parse(IEnumerable<string> headerValues)
            => Parse(headerValues.ToArray());
    }
}
