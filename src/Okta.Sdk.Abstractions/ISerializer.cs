using System.Collections.Generic;

namespace Okta.Sdk.Abstractions
{
    public interface ISerializer
    {
        string Serialize(object model);

        IDictionary<string, object> Deserialize(string json);

        IEnumerable<IDictionary<string, object>> DeserializeArray(string json);
    }
}