// <copyright file="Group.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a Group resource in the Okta API.</summary>
    public sealed partial class Group : Resource, IGroup
    {


        public DateTimeOffset? Created => GetDateTimeProperty("created");

        public string Id => GetStringProperty("id");

        public DateTimeOffset? LastMembershipUpdated => GetDateTimeProperty("lastMembershipUpdated");

        public DateTimeOffset? LastUpdated => GetDateTimeProperty("lastUpdated");

        public IList<string> ObjectClass => GetArrayProperty<string>("objectClass");

        public GroupProfile Profile
        {
            get => GetResourceProperty<GroupProfile>("profile");
            set => this["profile"] = value;
        }

        public string Type => GetStringProperty("type");


        /// <inheritdoc />
        public Task RemoveUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Groups.RemoveGroupUserAsync(Id, userId, cancellationToken);
    }
}
