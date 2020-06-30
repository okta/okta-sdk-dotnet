// <copyright file="CatalogApplicationStatus.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

namespace Okta.Sdk
{
    /// <summary>
    /// An enumeration of CatalogApplicationStatus values in the Okta API.
    /// </summary>
    public sealed class CatalogApplicationStatus : StringEnum
    {
        /// <summary>The ACTIVE CatalogApplicationStatus.</summary>
        public static CatalogApplicationStatus Active = new CatalogApplicationStatus("ACTIVE");

        /// <summary>The INACTIVE CatalogApplicationStatus.</summary>
        public static CatalogApplicationStatus Inactive = new CatalogApplicationStatus("INACTIVE");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="CatalogApplicationStatus"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator CatalogApplicationStatus(string value) => new CatalogApplicationStatus(value);

        /// <summary>
        /// Creates a new <see cref="CatalogApplicationStatus"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public CatalogApplicationStatus(string value)
            : base(value)
        {
        }

    }
}
