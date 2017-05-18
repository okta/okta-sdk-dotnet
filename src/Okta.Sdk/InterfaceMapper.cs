using Okta.Sdk.Abstractions;
using System;
using System.Linq;
using System.Reflection;

namespace Okta.Sdk
{
    public static class InterfaceMapper
    {
        public static Type GetConcrete<TInterface>()
        {
            var interfaceInfo = typeof(TInterface).GetTypeInfo();
            if (!interfaceInfo.IsInterface) return typeof(TInterface);

            var foundMap = interfaceInfo
                .Assembly
                .DefinedTypes
                .Select(ti => new
                {
                    Concrete = ti.AsType(),
                    Interface = ti.GetCustomAttribute<ConcreteForAttribute>()?.Interface
                })
                .SingleOrDefault(x => x.Interface == typeof(TInterface));

            return foundMap.Concrete;
        }
    }
}
