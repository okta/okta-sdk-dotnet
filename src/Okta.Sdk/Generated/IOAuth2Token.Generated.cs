// <copyright file="IOAuth2Token.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a OAuth2Token resource in the Okta API.</summary>
    public partial interface IOAuth2Token : IResource
    {
        string ClientId { get; set; }

        DateTimeOffset? Created { get; }

        DateTimeOffset? ExpiresAt { get; }

        string Id { get; }

        string Issuer { get; set; }

        DateTimeOffset? LastUpdated { get; }

        IList<string> Scopes { get; set; }

        string Status { get; set; }

        string UserId { get; set; }

    }
}
