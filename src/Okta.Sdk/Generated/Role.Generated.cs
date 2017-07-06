// <copyright file="Role.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// Do not modify this file directly. This file was automatically generated with:
// spec.json - 0.3.0

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public sealed partial class Role : Resource, IRole
    {

        /// <inheritdoc/>
        public DateTimeOffset? Created => GetDateTimeProperty("created");

        /// <inheritdoc/>
        public string Description
        {
            get => GetStringProperty("description");
            set => this["description"] = value;
        }

        /// <inheritdoc/>
        public string Id => GetStringProperty("id");

        /// <inheritdoc/>
        public string Label => GetStringProperty("label");

        /// <inheritdoc/>
        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");

        /// <inheritdoc/>
        public RoleStatus Status => GetEnumProperty<RoleStatus>("status");

        /// <inheritdoc/>
        public string Type => GetStringProperty("type");

    }
}
