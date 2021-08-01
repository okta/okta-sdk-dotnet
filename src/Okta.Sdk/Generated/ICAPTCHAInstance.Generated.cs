// <copyright file="ICAPTCHAInstance.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a CAPTCHAInstance resource in the Okta API.</summary>
    public partial interface ICAPTCHAInstance : IResource
    {
        object Link { get; }

        string Id { get; }

        string Name { get; set; }

        string SecretKey { get; set; }

        string SiteKey { get; set; }

        string Type { get; set; }

    }
}
