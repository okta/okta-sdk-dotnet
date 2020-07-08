// <copyright file="IProvisioningGroups.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a ProvisioningGroups resource in the Okta API.</summary>
    public partial interface IProvisioningGroups : IResource
    {
        string Action { get; set; }

        IList<string> Assignments { get; set; }

        IList<string> Filter { get; set; }

        string SourceAttributeName { get; set; }

    }
}
