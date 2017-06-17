// <copyright file="UserClient.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace Okta.Sdk
{
    public sealed partial class UserClient : OktaClient, IUserClient, IAsyncEnumerable<User>
    {
        /// <inheritdoc/>
        public IAsyncEnumerator<User> GetEnumerator() => ListUsers().GetEnumerator();
    }
}
