// <copyright file="ResourceTypeResolverFactory.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Okta.Sdk.Internal
{
    internal static class ResourceTypeResolverFactory
    {
        private static readonly Type DefaultResolverType = typeof(DefaultResourceTypeResolver<>);

        private static readonly (Type Resolver, Type For)[] CachedResolvers =
            typeof(Resource).GetTypeInfo().Assembly.DefinedTypes
            .Where(typeInfo =>
            {
                if (typeInfo?.BaseType == null)
                {
                    return false;
                }

                var baseTypeInfo = typeInfo.BaseType.GetTypeInfo();
                var inheritsFromAbstractResolver = baseTypeInfo.IsGenericType
                    && baseTypeInfo.GetGenericTypeDefinition() == typeof(AbstractResourceTypeResolver<>);

                return inheritsFromAbstractResolver;
            })
            .Select(typeInfo => (typeInfo.AsType(), typeInfo.BaseType.GenericTypeArguments[0]))
            .ToArray();

        public static bool RequiresResolution(Type resourceType)
            => GetResolver(resourceType) != null;

        public static IResourceTypeResolver CreateResolver<T>()
            => CreateResolver(forType: typeof(T));

        public static IResourceTypeResolver CreateResolver(Type forType)
        {
            var resolverType = GetResolver(forType);

            if (resolverType == null)
            {
                // equivalent to: new DefaultResourceTypeResolver<T>();
                var defaultResolverOfT = DefaultResolverType.MakeGenericType(forType);
                return (IResourceTypeResolver)Activator.CreateInstance(defaultResolverOfT);
            }

            return (IResourceTypeResolver)Activator.CreateInstance(resolverType);
        }

        private static Type GetResolver(Type resourceType)
            => CachedResolvers.FirstOrDefault(x => x.For == resourceType).Resolver;
    }
}
