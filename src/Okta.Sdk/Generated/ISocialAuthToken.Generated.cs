// <copyright file="ISocialAuthToken.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a SocialAuthToken resource in the Okta API.</summary>
    public partial interface ISocialAuthToken : IResource
    {
        DateTimeOffset? ExpiresAt { get; }

        string Id { get; }

        IList<string> Scopes { get; set; }

        string Token { get; set; }

        string TokenAuthScheme { get; set; }

        string TokenType { get; set; }

    }
}
