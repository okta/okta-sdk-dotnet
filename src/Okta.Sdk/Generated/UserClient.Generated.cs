// <copyright file="Client.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// Do not modify this file directly. This file was automatically generated with:
// spec.json - 0.3.0

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    public sealed partial class UserClient : OktaClient, IUserClient
    {
        public UserClient(IDataStore dataStore)
            : base(dataStore)
        {
        }
        
        /// <inheritdoc />
        public IAsyncEnumerable<User> ListUsers(string q = null, string after = null, int? limit = -1, string filter = null, string format = null, string search = null, string expand = null)
            => new CollectionClient<User>(DataStore, new HttpRequest
        {
            Uri = "/api/v1/users",
            
            QueryParams = new Dictionary<string, object>()
            {
                ["q"] = q,
                ["after"] = after,
                ["limit"] = limit,
                ["filter"] = filter,
                ["format"] = format,
                ["search"] = search,
                ["expand"] = expand,
            },
        });

        /// <inheritdoc />
        public Task<User> CreateUserAsync(User user, bool? activate = true, bool? provider = false, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync<User>(new HttpRequest
        {
            Uri = "/api/v1/users",
            Payload = user,
            QueryParams = new Dictionary<string, object>()
            {
                ["activate"] = activate,
                ["provider"] = provider,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task DeactivateOrDeleteUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
            => DeleteAsync(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}",
            
            PathParams = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task<User> GetUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
            => GetAsync<User>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}",
            
            PathParams = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task<User> UpdateUserAsync(User user, string userId, CancellationToken cancellationToken = default(CancellationToken))
            => PutAsync<User>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}",
            Payload = user,
            PathParams = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public IAsyncEnumerable<AppLink> ListAppLinks(string userId, bool? showAll = false)
            => new CollectionClient<AppLink>(DataStore, new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/appLinks",
            
            PathParams = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
            QueryParams = new Dictionary<string, object>()
            {
                ["showAll"] = showAll,
            },
        });

        /// <inheritdoc />
        public Task<UserCredentials> ChangePasswordAsync(ChangePasswordRequest changePasswordRequest, string userId, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync<UserCredentials>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/credentials/change_password",
            Payload = changePasswordRequest,
            PathParams = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task<UserCredentials> ChangeRecoveryQuestionAsync(UserCredentials userCredentials, string userId, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync<UserCredentials>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/credentials/change_recovery_question",
            Payload = userCredentials,
            PathParams = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task<ForgotPasswordResponse> ForgotPasswordAsync(UserCredentials userCredentials, string userId, bool? sendEmail, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync<ForgotPasswordResponse>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/credentials/forgot_password",
            Payload = userCredentials,
            PathParams = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
            QueryParams = new Dictionary<string, object>()
            {
                ["sendEmail"] = sendEmail,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public IAsyncEnumerable<Group> ListUserGroups(string userId, string after = null, int? limit = -1)
            => new CollectionClient<Group>(DataStore, new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/groups",
            
            PathParams = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
            QueryParams = new Dictionary<string, object>()
            {
                ["after"] = after,
                ["limit"] = limit,
            },
        });

        /// <inheritdoc />
        public Task<UserActivationToken> ActivateUserAsync(string userId, bool? sendEmail, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync<UserActivationToken>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/lifecycle/activate",
            
            PathParams = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
            QueryParams = new Dictionary<string, object>()
            {
                ["sendEmail"] = sendEmail,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task DeactivateUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/lifecycle/deactivate",
            
            PathParams = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task<TempPassword> ExpirePasswordAsync(string userId, bool? tempPassword = false, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync<TempPassword>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/lifecycle/expire_password",
            
            PathParams = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
            QueryParams = new Dictionary<string, object>()
            {
                ["tempPassword"] = tempPassword,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task ResetAllFactorsAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/lifecycle/reset_factors",
            
            PathParams = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task<ResetPasswordToken> ResetPasswordAsync(string userId, string provider = null, bool? sendEmail = null, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync<ResetPasswordToken>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/lifecycle/reset_password",
            
            PathParams = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
            QueryParams = new Dictionary<string, object>()
            {
                ["provider"] = provider,
                ["sendEmail"] = sendEmail,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task SuspendUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/lifecycle/suspend",
            
            PathParams = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task UnlockUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/lifecycle/unlock",
            
            PathParams = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task UnsuspendUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/lifecycle/unsuspend",
            
            PathParams = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public IAsyncEnumerable<Role> ListAssignedRoles(string userId, string expand = null)
            => new CollectionClient<Role>(DataStore, new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/roles",
            
            PathParams = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
            QueryParams = new Dictionary<string, object>()
            {
                ["expand"] = expand,
            },
        });

        /// <inheritdoc />
        public Task<Role> AddRoleToUserAsync(Role role, string userId, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync<Role>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/roles",
            Payload = role,
            PathParams = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task RemoveRoleFromUserAsync(string userId, string roleId, CancellationToken cancellationToken = default(CancellationToken))
            => DeleteAsync(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/roles/{roleId}",
            
            PathParams = new Dictionary<string, object>()
            {
                ["userId"] = userId,
                ["roleId"] = roleId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public IAsyncEnumerable<Group> ListGroupTargetsForRole(string userId, string roleId, string after = null, int? limit = -1)
            => new CollectionClient<Group>(DataStore, new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/roles/{roleId}/targets/groups",
            
            PathParams = new Dictionary<string, object>()
            {
                ["userId"] = userId,
                ["roleId"] = roleId,
            },
            QueryParams = new Dictionary<string, object>()
            {
                ["after"] = after,
                ["limit"] = limit,
            },
        });

        /// <inheritdoc />
        public Task RemoveGroupTargetFromRoleAsync(string userId, string roleId, string groupId, CancellationToken cancellationToken = default(CancellationToken))
            => DeleteAsync(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/roles/{roleId}/targets/groups/{groupId}",
            
            PathParams = new Dictionary<string, object>()
            {
                ["userId"] = userId,
                ["roleId"] = roleId,
                ["groupId"] = groupId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task AddGroupTargetToRoleAsync(string userId, string roleId, string groupId, CancellationToken cancellationToken = default(CancellationToken))
            => PutAsync(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/roles/{roleId}/targets/groups/{groupId}",
            
            PathParams = new Dictionary<string, object>()
            {
                ["userId"] = userId,
                ["roleId"] = roleId,
                ["groupId"] = groupId,
            },
        }, cancellationToken);
    }
}