using System;
using System.Collections.Generic;

namespace Okta.Sdk
{
    public static class DictionaryFactory
    {
        public static Dictionary<string, object> NewCaseInsensitiveDictionary()
            => new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
    }
}
