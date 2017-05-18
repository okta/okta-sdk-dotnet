using System;
using System.Collections.Generic;

namespace Okta.Sdk.Abstractions
{
    public interface IResourceFactory
    {
        TInterface CreateConcrete<TInterface>(Type concreteType, IReadOnlyDictionary<string, object> data);

        TInterface Create<TInterface>(IReadOnlyDictionary<string, object> data);
    }
}
