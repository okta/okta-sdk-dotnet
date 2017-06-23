// <copyright file="UserClient.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public sealed partial class UserClient : OktaClient, IUserClient, IAsyncEnumerable<User>
    {
        /// <inheritdoc/>
        public Task<User> CreateUserAsync(UserWithPasswordCreationOptions createUserOptions, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (createUserOptions == null)
            {
                throw new ArgumentNullException(nameof(createUserOptions));
            }

            var user = new User
            {
                Profile = createUserOptions.Profile,
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential { Value = createUserOptions.Password },
                },
            };

            return CreateUserAsync(user, createUserOptions.Activate, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        public IAsyncEnumerator<User> GetEnumerator() => ListUsers().GetEnumerator();
    }
}
