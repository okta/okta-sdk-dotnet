using System.Collections.Generic;

namespace Okta.Sdk.Abstractions
{
    public interface ISaveable
    {
        IReadOnlyDictionary<string, object> GetModifiedProperties();
    }
}
