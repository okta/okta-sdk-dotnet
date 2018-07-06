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
        string Alg { get; }

        DateTimeOffset? Created { get; }

        string E { get; }

        DateTimeOffset? ExpiresAt { get; }

        IList<string> KeyOps { get; }

        string Kid { get; }

        string Kty { get; }

        DateTimeOffset? LastUpdated { get; }

        string N { get; }

        string Status { get; }

        string Use { get; }

        IList<string> X5C { get; }

        string X5T { get; }

        string X5TS256 { get; }

        string X5U { get; }

    }
}
