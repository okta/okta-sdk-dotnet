// <copyright file="AbstractResourceTypeResolver.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// Resolves a resource type based on the resource data. Base class for all resource type resolvers.
    /// </summary>
    /// <typeparam name="T">The base type of resource to resolve.</typeparam>
    public abstract class AbstractResourceTypeResolver<T>
    {
        /// <summary>
        /// Get the resolved resource type given its <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The resource data.</param>
        /// <returns>The resource type.</returns>
        public abstract Type GetResolvedType(IDictionary<string, object> data);
    }
}
