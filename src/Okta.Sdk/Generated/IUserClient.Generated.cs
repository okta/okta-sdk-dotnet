// <copyright file="IClient.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// Do not modify this file directly. This file was automatically generated with:
// spec.json - 0.3.0

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    public partial interface IUserClient : IOktaClient
    {
        /// <summary>
        /// Lists users in your organization with pagination in most cases.  A subset of users can be returned that match a supported filter expression or search criteria.
        /// </summary>
        /// <param name="q">Finds a user that matches firstName, lastName, and email properties</param>
        /// <param name="after">Specifies the pagination cursor for the next page of users</param>
        /// <param name="limit">Specifies the number of results returned</param>
        /// <param name="filter">Filters users with a supported expression for a subset of properties</param>
        /// <param name="format"></param>
        /// <param name="search">Searches for users with a supported filtering  expression for most properties</param>
        /// <param name="expand"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        IAsyncEnumerable<User> ListUsers(string q = null, string after = null, int? limit = -1, string filter = null, string format = null, string search = null, string expand = null);

        /// <summary>
        /// Creates a new user in your Okta organization with or without credentials.
        /// </summary>
        /// <param name="user">The User resource.</param>
        /// <param name="activate">Executes activation lifecycle operation when creating the user</param>
        /// <param name="provider">Indicates whether to create a user with a specified authentication provider</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<User> CreateUserAsync(User user, bool? activate = true, bool? provider = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task DeactivateOrDeleteUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<User> GetUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user">The User resource.</param>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<User> UpdateUserAsync(User user, string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="showAll"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        IAsyncEnumerable<AppLink> ListAppLinks(string userId, bool? showAll = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="changePasswordRequest">The ChangePasswordRequest resource.</param>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<UserCredentials> ChangePasswordAsync(ChangePasswordRequest changePasswordRequest, string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userCredentials">The UserCredentials resource.</param>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<UserCredentials> ChangeRecoveryQuestionAsync(UserCredentials userCredentials, string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userCredentials">The UserCredentials resource.</param>
        /// <param name="userId"></param>
        /// <param name="sendEmail"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<ForgotPasswordResponse> ForgotPasswordAsync(UserCredentials userCredentials, string userId, bool? sendEmail, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="after"></param>
        /// <param name="limit"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        IAsyncEnumerable<Group> ListUserGroups(string userId, string after = null, int? limit = -1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="sendEmail"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<UserActivationToken> ActivateUserAsync(string userId, bool? sendEmail, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task DeactivateUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="tempPassword"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<TempPassword> ExpirePasswordAsync(string userId, bool? tempPassword = false, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task ResetAllFactorsAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="provider"></param>
        /// <param name="sendEmail"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<ResetPasswordToken> ResetPasswordAsync(string userId, string provider = null, bool? sendEmail = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task SuspendUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task UnlockUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task UnsuspendUserAsync(string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="expand"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        IAsyncEnumerable<Role> ListAssignedRoles(string userId, string expand = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="role">The Role resource.</param>
        /// <param name="userId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<Role> AddRoleToUserAsync(Role role, string userId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task RemoveRoleFromUserAsync(string userId, string roleId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="after"></param>
        /// <param name="limit"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        IAsyncEnumerable<Group> ListGroupTargetsForRole(string userId, string roleId, string after = null, int? limit = -1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="groupId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task RemoveGroupTargetFromRoleAsync(string userId, string roleId, string groupId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        /// <param name="groupId"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task AddGroupTargetToRoleAsync(string userId, string roleId, string groupId, CancellationToken cancellationToken = default(CancellationToken));
    }
}
