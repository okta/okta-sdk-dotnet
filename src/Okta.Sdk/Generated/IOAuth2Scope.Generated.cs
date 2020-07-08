// <copyright file="IOAuth2Scope.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a OAuth2Scope resource in the Okta API.</summary>
    public partial interface IOAuth2Scope : IResource
    {
        string Consent { get; set; }

        bool? Default { get; set; }

        string Description { get; set; }

        string DisplayName { get; set; }

        string Id { get; }

        string MetadataPublish { get; set; }

        string Name { get; set; }

        bool? System { get; set; }

    }
}
