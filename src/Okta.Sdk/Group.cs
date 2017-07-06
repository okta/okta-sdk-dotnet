// <copyright file="Group.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public sealed partial class Group : IGroup
    {
        /// <inheritdoc/>
        public IAsyncEnumerable<IUser> Users
            => GetClient().Groups.ListGroupUsers(Id);
    }
}
