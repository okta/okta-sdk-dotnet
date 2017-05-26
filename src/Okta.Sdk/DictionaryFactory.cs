using System;
using System.Collections.Generic;

namespace Okta.Sdk
{
    public static class DictionaryFactory
    {
        public static IDictionary<string, object> NewDictionary()
            => NewDictionary(null);

        public static IDictionary<string, object> NewDictionary(IDictionary<string, object> initialData)
        {
            return initialData == null
                ? new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
                : new Dictionary<string, object>(initialData, StringComparer.OrdinalIgnoreCase);
        }
    }
}
