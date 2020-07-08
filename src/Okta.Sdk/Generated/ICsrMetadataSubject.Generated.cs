// <copyright file="ICsrMetadataSubject.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a CsrMetadataSubject resource in the Okta API.</summary>
    public partial interface ICsrMetadataSubject : IResource
    {
        string CommonName { get; set; }

        string CountryName { get; set; }

        string LocalityName { get; set; }

        string OrganizationName { get; set; }

        string OrganizationalUnitName { get; set; }

        string StateOrProvinceName { get; set; }

    }
}
