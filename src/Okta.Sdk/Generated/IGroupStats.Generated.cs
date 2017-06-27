// <copyright file="IGroupStats.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// Do not modify this file directly. This file was automatically generated with:
// spec.json - 0.2.0

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>Contains the method contract for GroupStats resources.</summary>
    public partial interface IGroupStats
    {

        int? AppsCount { get; set; }

        int? GroupPushMappingsCount { get; set; }

        int? UsersCount { get; set; }

    }
}
