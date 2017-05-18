// <copyright file="UsersClient.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public sealed class UsersClient : OktaClient
    {
        private const string GetUserUri = "/api/v1/users/{id}";

        public UsersClient(OktaClient oktaClient)
            : base(oktaClient.DataStore)
        {
        }

        public IAsyncEnumerable<User> Users { get; }

        public Task<User> GetUserAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
            => GetAsync<User>(string.Format(GetUserUri, id), cancellationToken);

        public Task SaveUserAsync(User user, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }
    }
}
