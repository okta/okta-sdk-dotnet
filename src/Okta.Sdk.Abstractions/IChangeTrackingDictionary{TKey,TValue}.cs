using System.Collections.Generic;

namespace Okta.Sdk.Abstractions
{
    public interface IChangeTrackingDictionary<TKey, TValue> : IDictionary<TKey, TValue>, IChangeTrackable
    {
    }
}
