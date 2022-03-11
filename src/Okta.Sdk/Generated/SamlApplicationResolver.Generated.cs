// <copyright file="SamlApplicationResolver.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// Resolves SamlApplication resources based on the Name property.
    /// </summary>
    public class SamlApplicationResolver : AbstractResourceTypeResolver<SamlApplication>
    {
        /// <summary>
        /// Gets the type of a SamlApplication resource given its <paramref name="data"/>.
        /// </summary>
        /// <param name="data">The resource data.</param>
        /// <returns>The resource type.</returns>
        protected override Type GetResolvedTypeInternal(IDictionary<string, object> data)
        {
            var value = data
                ?.Where(kv => kv.Key.Equals("name", StringComparison.OrdinalIgnoreCase))
                ?.FirstOrDefault().Value?.ToString();

            if (string.IsNullOrEmpty(value))
            {
                return typeof(SamlApplication);
            }
            
            if (value.Equals("okta_org2org"))
            {
                return typeof(Org2OrgApplication);
            }
            
            return typeof(SamlApplication);
        }
    }
}
