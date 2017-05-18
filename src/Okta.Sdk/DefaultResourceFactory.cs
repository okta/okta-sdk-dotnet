using Okta.Sdk.Abstractions;
using System;
using System.Collections.Generic;

namespace Okta.Sdk
{
    public sealed class DefaultResourceFactory : IResourceFactory
    {
        public TInterface Create<TInterface>(IReadOnlyDictionary<string, object> data)
        {
            var concreteType = InterfaceMapper.GetConcrete<TInterface>();
            if (concreteType == null) throw new InvalidOperationException($"Could not find concrete class for interface type {typeof(TInterface).Name}.");

            return CreateConcrete<TInterface>(concreteType, data);
        }

        public TInterface CreateConcrete<TInterface>(Type concreteType, IReadOnlyDictionary<string, object> data)
            => (TInterface)Activator.CreateInstance(concreteType, data);
    }
}
