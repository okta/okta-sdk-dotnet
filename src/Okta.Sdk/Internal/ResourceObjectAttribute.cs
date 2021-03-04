// <copyright file="ResourceObjectAttribute.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;

namespace Okta.Sdk.Internal
{
    /// <summary>
    /// Specifies null value handling options for the ResourceSerializingConverter.
    /// </summary>
    public class ResourceObjectAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the NullValueHandling
        /// </summary>
        public ResourceNullValueHandling NullValueHandling { get; set; }
    }
}
