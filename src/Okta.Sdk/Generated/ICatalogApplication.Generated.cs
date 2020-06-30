// <copyright file="ICatalogApplication.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>Represents a CatalogApplication resource in the Okta API.</summary>
    public partial interface ICatalogApplication : IResource
    {
        string Category { get; set; }

        string Description { get; set; }

        string DisplayName { get; set; }

        IList<string> Features { get; set; }

        string Id { get; }

        DateTimeOffset? LastUpdated { get; }

        string Name { get; set; }

        IList<string> SignOnModes { get; set; }

        CatalogApplicationStatus Status { get; set; }

        string VerificationStatus { get; set; }

        string Website { get; set; }

    }
}
