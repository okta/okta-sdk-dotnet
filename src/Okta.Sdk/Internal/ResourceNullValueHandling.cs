// <copyright file="ResourceNullValueHandling.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// Specifies null value handling options for the ResourceSerializingConverter.
    /// </summary>
    public enum ResourceNullValueHandling
    {
        /// <summary>
        /// Include null values when serializing and deserializing resources.
        /// </summary>
        Include,

        /// <summary>
        /// Ignore null values when serializing and deserializing resources.
        /// </summary>
        Ignore,
    }
}
