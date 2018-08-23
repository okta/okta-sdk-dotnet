// <copyright file="IResourceTypeResolver.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;

namespace Okta.Sdk.Internal
{
    /// <summary>A type resolver that works with Okta resources.</summary>
    public interface IResourceTypeResolver
    {
        /// <summary>
        /// Gets the resolved type based on the data
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The resource type</returns>
        Type GetResolvedType(IDictionary<string, object> data);
    }
}
