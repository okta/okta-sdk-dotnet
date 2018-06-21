// <copyright file="UsersClient.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <summary>
    /// Provides methods that manipulate <see cref="User"/> resources, by communicating with the Okta Users API.
    /// </summary>
    public sealed partial class UsersClient : OktaClient, IUsersClient, IAsyncEnumerable<IUser>
    {
        /// <inheritdoc/>
        public IAsyncEnumerator<IUser> GetEnumerator() => ListUsers().GetEnumerator();

        /// <inheritdoc/>
        public Task<IUser> CreateUserAsync(CreateUserWithoutCredentialsOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var user = new User
            {
                Profile = options.Profile,
            };

            return CreateUserAsync(user, options.Activate, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IUser> CreateUserAsync(CreateUserWithRecoveryQuestionOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var user = new User
            {
                Profile = options.Profile,
                Credentials = new UserCredentials
                {
                    RecoveryQuestion = new RecoveryQuestionCredential
                    {
                        Question = options.RecoveryQuestion,
                        Answer = options.RecoveryAnswer,
                    },
                },
            };

            return CreateUserAsync(user, options.Activate, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IUser> CreateUserAsync(CreateUserWithPasswordOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var user = new User
            {
                Profile = options.Profile,
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential { Value = options.Password },
                },
            };

            var hasRecoveryQuestionAndAnswer = !string.IsNullOrEmpty(options.RecoveryQuestion) && !string.IsNullOrEmpty(options.RecoveryAnswer);
            if (hasRecoveryQuestionAndAnswer)
            {
                user.Credentials.RecoveryQuestion = new RecoveryQuestionCredential
                {
                    Question = options.RecoveryQuestion,
                    Answer = options.RecoveryAnswer,
                };
            }

            return CreateUserAsync(user, options.Activate, cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IUser> CreateUserAsync(CreateUserWithProviderOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var user = new User
            {
                Profile = options.Profile,
                Credentials = new UserCredentials
                {
                    Provider = new AuthenticationProvider
                    {
                        Type = options.ProviderType,
                        Name = options.ProviderName,
                    },
                },
            };

            return CreateUserAsync(user, options.Activate, true, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IUserCredentials> ChangePasswordAsync(
            string userId,
            ChangePasswordOptions options,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var changePasswordRequest = new ChangePasswordRequest
            {
                OldPassword = new PasswordCredential { Value = options.CurrentPassword },
                NewPassword = new PasswordCredential { Value = options.NewPassword },
            };

            return ChangePasswordAsync(changePasswordRequest, userId, cancellationToken);
        }

        /// <inheritdoc/>
        public Task ChangeRecoveryQuestionAsync(string userId, ChangeRecoveryQuestionOptions options, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var newCredentials = new UserCredentials
            {
                Password = new PasswordCredential { Value = options.CurrentPassword },
                RecoveryQuestion = new RecoveryQuestionCredential
                {
                    Question = options.RecoveryQuestion,
                    Answer = options.RecoveryAnswer,
                },
            };

            return ChangeRecoveryQuestionAsync(newCredentials, userId, cancellationToken);
        }

        /// <inheritdoc/>
        public Task<IResetPasswordToken> ResetPasswordAsync(
            string userId,
            bool? sendEmail = true,
            CancellationToken cancellationToken = default(CancellationToken))
            => ResetPasswordAsync(userId, null, sendEmail, cancellationToken);

        /// <summary>
        /// Lists the users asynchronous.
        /// </summary>
        /// <param name="q">The q.</param>
        /// <param name="after">The after.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="format">The format.</param>
        /// <param name="search">The search.</param>
        /// <param name="expand">The expand.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// page of users.
        /// </returns>
        public async Task<PageOfResults<User>> ListUsersAsync(
            string q = null,
            string after = null,
            int? limit = -1,
            string filter = null,
            string format = null,
            string search = null,
            string expand = null,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await GetPageOfResultsAsync<User>(
                new HttpRequest
                {
                    Uri = "/api/v1/users",

                    QueryParameters = new Dictionary<string, object>()
                    {
                        ["q"] = q,
                        ["after"] = after,
                        ["limit"] = limit,
                        ["filter"] = filter,
                        ["format"] = format,
                        ["search"] = search,
                        ["expand"] = expand,
                    },
                },
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Lists the users asynchronous.
        /// </summary>
        /// <param name="serializedNextRequest">The serialized next request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// page of users.
        /// </returns>
        public async Task<PageOfResults<User>> ListUsersContinuationAsync(string serializedNextRequest, CancellationToken cancellationToken = default(CancellationToken))
        {
            HttpRequest req = JsonConvert.DeserializeObject<HttpRequest>(serializedNextRequest);
            return await GetPageOfResultsAsync<User>(req, cancellationToken).ConfigureAwait(false);
        }
    }
}
