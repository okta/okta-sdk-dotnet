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
        public ICollectionClient<IUser> ListUsers(string q = null, string after = null, int? limit = 10, string filter = null, string search = null, string sortBy = null, string sortOrder = null)
            => GetCollectionClient<IUser>(new HttpRequest
            {
                Uri = "/api/v1/users",
                Verb = HttpVerb.Get,
                
                QueryParameters = new Dictionary<string, object>()
                {
                    ["q"] = q,
                    ["after"] = after,
                    ["limit"] = limit,
                    ["filter"] = filter,
                    ["search"] = search,
                    ["sortBy"] = sortBy,
                    ["sortOrder"] = sortOrder,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IUser> CreateUserAsync(ICreateUserRequest body, bool? activate = true, bool? provider = false, UserNextLogin nextLogin = null, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<User>(new HttpRequest
            {
                Uri = "/api/v1/users",
                Verb = HttpVerb.Post,
                Payload = body,
                QueryParameters = new Dictionary<string, object>()
                {
                    ["activate"] = activate,
                    ["provider"] = provider,
                    ["nextLogin"] = nextLogin,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task SetLinkedObjectForUserAsync(string associatedUserId, string primaryRelationshipName, string primaryUserId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{associatedUserId}/linkedObjects/{primaryRelationshipName}/{primaryUserId}",
                Verb = HttpVerb.Put,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["associatedUserId"] = associatedUserId,
                    ["primaryRelationshipName"] = primaryRelationshipName,
                    ["primaryUserId"] = primaryUserId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task DeactivateOrDeleteUserAsync(string userId, bool? sendEmail = false, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}",
                Verb = HttpVerb.Delete,
                
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
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IUser> PartialUpdateUserAsync(IUser user, string userId, bool? strict = null, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<User>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}",
                Verb = HttpVerb.Post,
                Payload = user,
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["strict"] = strict,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IUser> UpdateUserAsync(IUser user, string userId, bool? strict = null, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync<User>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}",
                Verb = HttpVerb.Put,
                Payload = user,
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["strict"] = strict,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IAppLink> ListAppLinks(string userId)
            => GetCollectionClient<IAppLink>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/appLinks",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
            });
                    
        /// <inheritdoc />
        public ICollectionClient<IOAuth2Client> ListUserClients(string userId)
            => GetCollectionClient<IOAuth2Client>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/clients",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
            });
                    
        /// <inheritdoc />
        public async Task RevokeGrantsForUserAndClientAsync(string userId, string clientId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/clients/{clientId}/grants",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["clientId"] = clientId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IOAuth2ScopeConsentGrant> ListGrantsForUserAndClient(string userId, string clientId, string expand = null, string after = null, int? limit = 20)
            => GetCollectionClient<IOAuth2ScopeConsentGrant>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/clients/{clientId}/grants",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["clientId"] = clientId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["expand"] = expand,
                    ["after"] = after,
                    ["limit"] = limit,
                },
            });
                    
        /// <inheritdoc />
        public async Task RevokeTokensForUserAndClientAsync(string userId, string clientId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/clients/{clientId}/tokens",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["clientId"] = clientId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IOAuth2RefreshToken> ListRefreshTokensForUserAndClient(string userId, string clientId, string expand = null, string after = null, int? limit = 20)
            => GetCollectionClient<IOAuth2RefreshToken>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/clients/{clientId}/tokens",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["clientId"] = clientId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["expand"] = expand,
                    ["after"] = after,
                    ["limit"] = limit,
                },
            });
                    
        /// <inheritdoc />
        public async Task RevokeTokenForUserAndClientAsync(string userId, string clientId, string tokenId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/clients/{clientId}/tokens/{tokenId}",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["clientId"] = clientId,
                    ["tokenId"] = tokenId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IOAuth2RefreshToken> GetRefreshTokenForUserAndClientAsync(string userId, string clientId, string tokenId, string expand = null, int? limit = 20, string after = null, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<OAuth2RefreshToken>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/clients/{clientId}/tokens/{tokenId}",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["clientId"] = clientId,
                    ["tokenId"] = tokenId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["expand"] = expand,
                    ["limit"] = limit,
                    ["after"] = after,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IUserCredentials> ChangePasswordAsync(IChangePasswordRequest changePasswordRequest, string userId, bool? strict = null, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<UserCredentials>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/credentials/change_password",
                Verb = HttpVerb.Post,
                Payload = changePasswordRequest,
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["strict"] = strict,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IUserCredentials> ChangeRecoveryQuestionAsync(IUserCredentials userCredentials, string userId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<UserCredentials>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/credentials/change_recovery_question",
                Verb = HttpVerb.Post,
                Payload = userCredentials,
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IForgotPasswordResponse> ForgotPasswordGenerateOneTimeTokenAsync(string userId, bool? sendEmail = true, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<ForgotPasswordResponse>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/credentials/forgot_password",
                Verb = HttpVerb.Post,
                
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
        public async Task<IForgotPasswordResponse> ForgotPasswordSetNewPasswordAsync(IUserCredentials user, string userId, bool? sendEmail = true, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<ForgotPasswordResponse>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/credentials/forgot_password",
                Verb = HttpVerb.Post,
                Payload = user,
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
        public async Task RevokeUserGrantsAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/grants",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IOAuth2ScopeConsentGrant> ListUserGrants(string userId, string scopeId = null, string expand = null, string after = null, int? limit = 20)
            => GetCollectionClient<IOAuth2ScopeConsentGrant>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/grants",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["scopeId"] = scopeId,
                    ["expand"] = expand,
                    ["after"] = after,
                    ["limit"] = limit,
                },
            });
                    
        /// <inheritdoc />
        public async Task RevokeUserGrantAsync(string userId, string grantId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/grants/{grantId}",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["grantId"] = grantId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IOAuth2ScopeConsentGrant> GetUserGrantAsync(string userId, string grantId, string expand = null, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<OAuth2ScopeConsentGrant>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/grants/{grantId}",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["grantId"] = grantId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["expand"] = expand,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IGroup> ListUserGroups(string userId)
            => GetCollectionClient<IGroup>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/groups",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
            });
                    
        /// <inheritdoc />
        public ICollectionClient<IIdentityProvider> ListUserIdentityProviders(string userId)
            => GetCollectionClient<IIdentityProvider>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/idps",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
            });
                    
        /// <inheritdoc />
        public async Task<IUserActivationToken> ActivateUserAsync(string userId, bool? sendEmail = true, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<UserActivationToken>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/lifecycle/activate",
                Verb = HttpVerb.Post,
                
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
                Verb = HttpVerb.Post,
                
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
        public async Task<IUser> ExpirePasswordAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<User>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/lifecycle/expire_password?tempPassword=false",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<ITempPassword> ExpirePasswordAndGetTemporaryPasswordAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<TempPassword>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/lifecycle/expire_password?tempPassword=true",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IUserActivationToken> ReactivateUserAsync(string userId, bool? sendEmail = false, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<UserActivationToken>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/lifecycle/reactivate",
                Verb = HttpVerb.Post,
                
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
        public async Task ResetFactorsAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/lifecycle/reset_factors",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IResetPasswordToken> ResetPasswordAsync(string userId, bool? sendEmail, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<ResetPasswordToken>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/lifecycle/reset_password",
                Verb = HttpVerb.Post,
                
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
        public async Task SuspendUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/lifecycle/suspend",
                Verb = HttpVerb.Post,
                
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
                Verb = HttpVerb.Post,
                
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
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task RemoveLinkedObjectForUserAsync(string userId, string relationshipName, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/linkedObjects/{relationshipName}",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["relationshipName"] = relationshipName,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IResponseLinks> GetLinkedObjectsForUser(string userId, string relationshipName, string after = null, int? limit = -1)
            => GetCollectionClient<IResponseLinks>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/linkedObjects/{relationshipName}",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["relationshipName"] = relationshipName,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["after"] = after,
                    ["limit"] = limit,
                },
            });
                    
        /// <inheritdoc />
        public ICollectionClient<IRole> ListAssignedRolesForUser(string userId, string expand = null)
            => GetCollectionClient<IRole>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/roles",
                Verb = HttpVerb.Get,
                
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
        public async Task<IRole> AssignRoleToUserAsync(IAssignRoleRequest assignRoleRequest, string userId, bool? disableNotifications = null, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync<Role>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/roles",
                Verb = HttpVerb.Post,
                Payload = assignRoleRequest,
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["disableNotifications"] = disableNotifications,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task RemoveRoleFromUserAsync(string userId, string roleId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/roles/{roleId}",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["roleId"] = roleId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task<IRole> GetUserRoleAsync(string userId, string roleId, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<Role>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/roles/{roleId}",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["roleId"] = roleId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<ICatalogApplication> ListApplicationTargetsForApplicationAdministratorRoleForUser(string userId, string roleId, string after = null, int? limit = 20)
            => GetCollectionClient<ICatalogApplication>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/roles/{roleId}/targets/catalog/apps",
                Verb = HttpVerb.Get,
                
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
        public async Task AddAllAppsAsTargetToRoleAsync(string userId, string roleId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/roles/{roleId}/targets/catalog/apps",
                Verb = HttpVerb.Put,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["roleId"] = roleId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task RemoveApplicationTargetFromApplicationAdministratorRoleForUserAsync(string userId, string roleId, string appName, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/roles/{roleId}/targets/catalog/apps/{appName}",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["roleId"] = roleId,
                    ["appName"] = appName,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task AddApplicationTargetToAdminRoleForUserAsync(string userId, string roleId, string appName, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/roles/{roleId}/targets/catalog/apps/{appName}",
                Verb = HttpVerb.Put,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["roleId"] = roleId,
                    ["appName"] = appName,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task RemoveApplicationTargetFromAdministratorRoleForUserAsync(string userId, string roleId, string appName, string applicationId, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/roles/{roleId}/targets/catalog/apps/{appName}/{applicationId}",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["roleId"] = roleId,
                    ["appName"] = appName,
                    ["applicationId"] = applicationId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task AddApplicationTargetToAppAdminRoleForUserAsync(string userId, string roleId, string appName, string applicationId, CancellationToken cancellationToken = default(CancellationToken))
            => await PutAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/roles/{roleId}/targets/catalog/apps/{appName}/{applicationId}",
                Verb = HttpVerb.Put,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["roleId"] = roleId,
                    ["appName"] = appName,
                    ["applicationId"] = applicationId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<IGroup> ListGroupTargetsForRole(string userId, string roleId, string after = null, int? limit = 20)
            => GetCollectionClient<IGroup>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/roles/{roleId}/targets/groups",
                Verb = HttpVerb.Get,
                
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
                Verb = HttpVerb.Delete,
                
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
                Verb = HttpVerb.Put,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["roleId"] = roleId,
                    ["groupId"] = groupId,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task ClearUserSessionsAsync(string userId, bool? oauthTokens = false, CancellationToken cancellationToken = default(CancellationToken))
            => await DeleteAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/sessions",
                Verb = HttpVerb.Delete,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
                QueryParameters = new Dictionary<string, object>()
                {
                    ["oauthTokens"] = oauthTokens,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public ICollectionClient<ISubscription> ListUserSubscriptions(string userId)
            => GetCollectionClient<ISubscription>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/subscriptions",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                },
            });
                    
        /// <inheritdoc />
        public async Task<ISubscription> GetUserSubscriptionByNotificationTypeAsync(string userId, string notificationType, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<Subscription>(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/subscriptions/{notificationType}",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["notificationType"] = notificationType,
                },
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
