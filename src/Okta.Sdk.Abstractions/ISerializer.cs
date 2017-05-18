using System.Collections.Generic;

namespace Okta.Sdk.Abstractions
{
    public interface ISerializer
    {
        IReadOnlyDictionary<string, object> Deserialize(string json);

        IEnumerable<IReadOnlyDictionary<string, object>> DeserializeArray(string json);
    }
}