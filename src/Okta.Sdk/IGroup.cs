// <copyright file="IGroup.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace Okta.Sdk
{
    public partial interface IGroup
    {
        /// <summary>
        /// Gets the collection of <see cref="IUser">Users</see> in this Group.
        /// </summary>
        /// <value>The colletion of Users in this Group.</value>
        IAsyncEnumerable<IUser> Users { get; }
    }
}
