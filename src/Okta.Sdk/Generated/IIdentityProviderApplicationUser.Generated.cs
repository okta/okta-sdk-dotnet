// <copyright file="IIdentityProviderApplicationUser.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a IdentityProviderApplicationUser resource in the Okta API.</summary>
    public partial interface IIdentityProviderApplicationUser : IResource
    {
        string Created { get; set; }

        string ExternalId { get; set; }

        string Id { get; }

        string LastUpdated { get; set; }

        Resource Profile { get; set; }

    }
}
