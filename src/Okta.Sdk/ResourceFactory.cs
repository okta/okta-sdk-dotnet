using System.Collections.Generic;

namespace Okta.Sdk
{
    public static class ResourceFactory
    {
        public static T Create<T>(IReadOnlyDictionary<string, object> data)
            where T : Resource, new()
        {
            var model = new T();
            model.ResetWithData(data);
            return model;
        }
    }
}
