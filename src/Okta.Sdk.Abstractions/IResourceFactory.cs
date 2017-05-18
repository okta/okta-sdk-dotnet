using System;
using System.Collections.Generic;

namespace Okta.Sdk.Abstractions
{
    public interface IResourceFactory
    {
        TInterface Create<TInterface>(IReadOnlyDictionary<string, object> data);
    }
}
