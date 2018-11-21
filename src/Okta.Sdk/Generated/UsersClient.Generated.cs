// <copyright file="UsersClient.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Okta.Sdk.Configuration;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public sealed partial class UsersClient : OktaClient, IUsersClient
    {
        // Remove parameterless constructor
        private UsersClient()
        {
        }

        internal UsersClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public ICollectionClient<IUser> ListUsers(string q = null, string after = null, int? limit = -1, string filter = null, string format = null, string search = null, string expand = null)
            => GetCollectionClient<IUser>(new HttpRequest
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
        public async Task<IUser> CreateUserAsync(IUser user, bool? activate = true, bool? provider = false, UserNextLogin nextLogin = null, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<User>(new HttpRequest
            {
                Uri = "/api/v1/users",
                Payload = user,
                QueryParameters = new Dictionary<string, object>()
                {
                    ["activate"] = activate,
                    ["provider"] = provider,
                    ["nextLogin"] = nextLogin,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeactivateOrDeleteUserAsync(string userId, bool? sendEmail = false, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["sendEmail"] = sendEmail,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IUser> GetUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<User>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IUser> UpdateUserAsync(IUser user, string userId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<User>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}",
                Payload = user,
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IAppLink> ListAppLinks(string userId, bool? showAll = false)
            => GetCollectionClient<IAppLink>(new HttpRequest
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
        public async Task<IUserCredentials> ChangePasswordAsync(IChangePasswordRequest changePasswordRequest, string userId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<UserCredentials>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/credentials/change_password",
                Payload = changePasswordRequest,
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IUserCredentials> ChangeRecoveryQuestionAsync(IUserCredentials userCredentials, string userId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<UserCredentials>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/credentials/change_recovery_question",
                Payload = userCredentials,
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IGroup> ListUserGroups(string userId, string after = null, int? limit = -1)
            => GetCollectionClient<IGroup>(new HttpRequest
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
        public async Task<IUserActivationToken> ActivateUserAsync(string userId, bool? sendEmail = true, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<UserActivationToken>(new HttpRequest
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
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeactivateUserAsync(string userId, bool? sendEmail = false, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/lifecycle/deactivate",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["sendEmail"] = sendEmail,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<ITempPassword> ExpirePasswordAsync(string userId, bool? tempPassword = false, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<TempPassword>(new HttpRequest
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
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task ResetAllFactorsAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/lifecycle/reset_factors",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IResetPasswordToken> ResetPasswordAsync(string userId, AuthenticationProviderType provider = null, bool? sendEmail = null, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<ResetPasswordToken>(new HttpRequest
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
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task SuspendUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/lifecycle/suspend",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task UnlockUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/lifecycle/unlock",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task UnsuspendUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/lifecycle/unsuspend",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IRole> ListAssignedRoles(string userId, string expand = null)
            => GetCollectionClient<IRole>(new HttpRequest
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
        public async Task RemoveRoleFromUserAsync(string userId, string roleId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/roles/{roleId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["roleId"] = roleId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IGroup> ListGroupTargetsForRole(string userId, string roleId, string after = null, int? limit = -1)
            => GetCollectionClient<IGroup>(new HttpRequest
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
        public async Task RemoveGroupTargetFromRoleAsync(string userId, string roleId, string groupId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/roles/{roleId}/targets/groups/{groupId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["roleId"] = roleId,
                    ["groupId"] = groupId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task AddGroupTargetToRoleAsync(string userId, string roleId, string groupId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/roles/{roleId}/targets/groups/{groupId}",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["roleId"] = roleId,
                    ["groupId"] = groupId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task EndAllUserSessionsAsync(string userId, bool? oauthTokens = false, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/sessions",
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["oauthTokens"] = oauthTokens,
                },
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
