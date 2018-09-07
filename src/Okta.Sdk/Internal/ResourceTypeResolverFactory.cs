// <copyright file="ResourceTypeResolverFactory.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Okta.Sdk.Internal
{
    internal static class ResourceTypeResolverFactory
    {
        private static readonly Type DefaultResolverType = typeof(DefaultResourceTypeResolver<>);

        private static readonly IEnumerable<TypeInfo> AllTypes = typeof(Resource).GetTypeInfo().Assembly.DefinedTypes.ToArray();

        private static readonly IEnumerable<(Type Resolver, Type For)> AllResolvers = AllTypes
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
            var concreteType = GetConcreteForInterface(forType);
            var resolverType = GetResolver(concreteType);

            if (resolverType == null)
            {
                // equivalent to: new DefaultResourceTypeResolver<T>();
                var defaultResolverOfT = DefaultResolverType.MakeGenericType(concreteType);
                return (IResourceTypeResolver)Activator.CreateInstance(defaultResolverOfT);
            }

            return (IResourceTypeResolver)Activator.CreateInstance(resolverType);
        }

        private static Type GetConcreteForInterface(Type possiblyInterface)
        {
            var typeInfo = possiblyInterface.GetTypeInfo();
            if (!typeInfo.IsInterface)
            {
                return possiblyInterface;
            }

            var foundConcrete = AllTypes.FirstOrDefault(x =>
                x.IsClass == true
                && typeInfo.IsAssignableFrom(x)
                && x.BaseType == typeof(Resource));
            return foundConcrete?.AsType() ?? possiblyInterface;
        }

        private static Type GetResolver(Type resourceType)
            => AllResolvers.FirstOrDefault(x => x.For == resourceType).Resolver;
    }
}
