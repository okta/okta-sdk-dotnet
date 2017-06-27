// <copyright file="GroupStats.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// Do not modify this file directly. This file was automatically generated with:
// spec.json - 0.2.0

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <summary>Represents a GroupStats resource in the Okta API.</summary>
    public sealed partial class GroupStats : Resource, IGroupStats
    {

        public int? AppsCount
        {
            get => GetIntegerProperty("appsCount");
            set => this["appsCount"] = value;
        }

        public int? GroupPushMappingsCount
        {
            get => GetIntegerProperty("groupPushMappingsCount");
            set => this["groupPushMappingsCount"] = value;
        }

        public int? UsersCount
        {
            get => GetIntegerProperty("usersCount");
            set => this["usersCount"] = value;
        }

    }
}
