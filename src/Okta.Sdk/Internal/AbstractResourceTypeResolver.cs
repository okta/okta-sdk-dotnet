// <copyright file="AbstractResourceTypeResolver.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// Resolves a resource type based on the resource data. Base class for all resource type resolvers.
    /// </summary>
    /// <typeparam name="T">The base type of resource to resolve.</typeparam>
    public abstract class AbstractResourceTypeResolver<T> : IResourceTypeResolver
    {
        /// <summary>
        /// Get the resolved resource type given its <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The resource data.</param>
        /// <returns>The resource type.</returns>
        public Type GetResolvedType(IDictionary<string, object> data)
        {
            var resourceType = GetResolvedTypeInternal(data);

            if (!ResourceTypeResolverFactory.RequiresResolution(resourceType))
            {
                return resourceType;
            }

            // If there is a more specific resolver available, resolve again recursively
            var moreSpecificResolver = ResourceTypeResolverFactory.CreateResolver(forType: resourceType);
            var foundMyself = moreSpecificResolver.GetType() == this.GetType();
            if (foundMyself)
            {
                return resourceType;
            }

            return moreSpecificResolver.GetResolvedType(data);
        }

        /// <summary>
        /// Gets the type depending on the resource's data.
        /// </summary>
        /// <param name="data">The resource data.</param>
        /// <returns>The resource type.</returns>
        /// <remarks>Implemented by specific resolvers in order to control how certain resources are resolved to their types.</remarks>
        protected abstract Type GetResolvedTypeInternal(IDictionary<string, object> data);
    }
}
