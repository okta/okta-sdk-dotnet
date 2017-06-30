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
using Okta.Sdk.Configuration;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    public sealed partial class UserClient : OktaClient, IUserClient
    {
        // Remove parameterless constructor
        private UserClient()
        {
        }

        internal UserClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public IAsyncEnumerable<User> ListUsers(string q = null, string after = null, int? limit = -1, string filter = null, string format = null, string search = null, string expand = null)
            => GetCollectionClient<User>(new HttpRequest
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
        });

        /// <inheritdoc />
        public Task<User> CreateUserAsync(User user, bool? activate = true, bool? provider = false, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync<User>(new HttpRequest
        {
            Uri = "/api/v1/users",
            Payload = user,
            QueryParameters = new Dictionary<string, object>()
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
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task<User> GetUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
            => GetAsync<User>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}",
            
            PathParameters = new Dictionary<string, object>()
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
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public IAsyncEnumerable<AppLink> ListAppLinks(string userId, bool? showAll = false)
            => GetCollectionClient<AppLink>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/appLinks",
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
            QueryParameters = new Dictionary<string, object>()
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
            PathParameters = new Dictionary<string, object>()
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
            PathParameters = new Dictionary<string, object>()
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
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
            QueryParameters = new Dictionary<string, object>()
            {
                ["sendEmail"] = sendEmail,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public IAsyncEnumerable<Group> ListUserGroups(string userId, string after = null, int? limit = -1)
            => GetCollectionClient<Group>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/groups",
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
            QueryParameters = new Dictionary<string, object>()
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
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
            QueryParameters = new Dictionary<string, object>()
            {
                ["sendEmail"] = sendEmail,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task DeactivateUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/lifecycle/deactivate",
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task<TempPassword> ExpirePasswordAsync(string userId, bool? tempPassword = false, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync<TempPassword>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/lifecycle/expire_password",
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
            QueryParameters = new Dictionary<string, object>()
            {
                ["tempPassword"] = tempPassword,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task ResetAllFactorsAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/lifecycle/reset_factors",
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task<ResetPasswordToken> ResetPasswordAsync(string userId, string provider = null, bool? sendEmail = null, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync<ResetPasswordToken>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/lifecycle/reset_password",
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
            QueryParameters = new Dictionary<string, object>()
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
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task UnlockUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/lifecycle/unlock",
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task UnsuspendUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
            => PostAsync(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/lifecycle/unsuspend",
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public IAsyncEnumerable<Role> ListAssignedRoles(string userId, string expand = null)
            => GetCollectionClient<Role>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/roles",
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
            QueryParameters = new Dictionary<string, object>()
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
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public Task RemoveRoleFromUserAsync(string userId, string roleId, CancellationToken cancellationToken = default(CancellationToken))
            => DeleteAsync(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/roles/{roleId}",
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
                ["roleId"] = roleId,
            },
        }, cancellationToken);

        /// <inheritdoc />
        public IAsyncEnumerable<Group> ListGroupTargetsForRole(string userId, string roleId, string after = null, int? limit = -1)
            => GetCollectionClient<Group>(new HttpRequest
        {
            Uri = "/api/v1/users/{userId}/roles/{roleId}/targets/groups",
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
                ["roleId"] = roleId,
            },
            QueryParameters = new Dictionary<string, object>()
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
            
            PathParameters = new Dictionary<string, object>()
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
            
            PathParameters = new Dictionary<string, object>()
            {
                ["userId"] = userId,
                ["roleId"] = roleId,
                ["groupId"] = groupId,
            },
        }, cancellationToken);
    }
}
