using System;
using System.Collections.Generic;
using System.Linq;

namespace Okta.Sdk.Abstractions
{
    public static class LinkHeaderParser
    {
        public static IEnumerable<WebLink> Parse(params string[] headerValues)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<WebLink> Parse(IEnumerable<string> headerValues)
            => Parse(headerValues.ToArray());
    }
}
