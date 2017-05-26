using System.Collections.Generic;

namespace Okta.Sdk.Abstractions
{
    public interface ISerializer
    {
        string Serialize(object model);

        IReadOnlyDictionary<string, object> Deserialize(string json);

        IEnumerable<IReadOnlyDictionary<string, object>> DeserializeArray(string json);
    }
}