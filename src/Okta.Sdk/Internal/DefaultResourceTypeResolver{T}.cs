// <copyright file="DefaultResourceTypeResolver{T}.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;

namespace Okta.Sdk.Internal
{
    internal sealed class DefaultResourceTypeResolver<T> : AbstractResourceTypeResolver<T>
    {
        protected override Type GetResolvedTypeInternal(IDictionary<string, object> data)
            => typeof(T);
    }
}
