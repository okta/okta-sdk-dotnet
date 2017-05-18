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

            var found = interfaceInfo
                .Assembly
                .DefinedTypes
                .SingleOrDefault(ti => ti.ImplementedInterfaces.Any(i => i == typeof(TInterface)))
                ?.AsType();

            return found;
        }
    }
}
