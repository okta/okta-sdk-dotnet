using System;
using System.Collections.Generic;

namespace Okta.Sdk.Internal
{
    public interface IResourceTypeResolver
    {
        Type GetResolvedType(IDictionary<string, object> data);
    }
}
