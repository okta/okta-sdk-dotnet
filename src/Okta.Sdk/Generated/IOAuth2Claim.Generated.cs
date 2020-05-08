// <copyright file="IOAuth2Claim.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a OAuth2Claim resource in the Okta API.</summary>
    public partial interface IOAuth2Claim : IResource
    {
        bool? AlwaysIncludeInToken { get; set; }

        string ClaimType { get; set; }

        IOAuth2ClaimConditions Conditions { get; set; }

        string GroupFilterType { get; set; }

        string Id { get; }

        string Name { get; set; }

        string Status { get; set; }

        bool? System { get; set; }

        string Value { get; set; }

        string ValueType { get; set; }

    }
}
