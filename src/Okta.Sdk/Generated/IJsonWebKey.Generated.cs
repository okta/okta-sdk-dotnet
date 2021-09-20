// <copyright file="IJsonWebKey.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a JsonWebKey resource in the Okta API.</summary>
    public partial interface IJsonWebKey : IResource
    {
        string Alg { get; set; }

        DateTimeOffset? Created { get; set; }

        string E { get; set; }

        DateTimeOffset? ExpiresAt { get; set; }

        IList<string> KeyOps { get; set; }

        string Kid { get; set; }

        string Kty { get; set; }

        DateTimeOffset? LastUpdated { get; set; }

        string N { get; set; }

        string Status { get; set; }

        string Use { get; set; }

        IList<string> X5C { get; set; }

        string X5T { get; set; }

        string X5TS256 { get; set; }

        string X5U { get; set; }

    }
}
