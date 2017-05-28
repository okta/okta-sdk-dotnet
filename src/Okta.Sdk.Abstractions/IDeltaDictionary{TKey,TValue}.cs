using System.Collections.Generic;

namespace Okta.Sdk.Abstractions
{
    public interface IDeltaDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        void Reset();

        IDictionary<string, object> ModifiedData { get; }
    }
}
