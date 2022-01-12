// <copyright file="ISubscriptionsClient.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Okta.Sdk
{
    /// <summary>A client that works with Okta Subscription resources.</summary>
    public partial interface ISubscriptionsClient
    {
        /// <summary>
        /// When roleType List all subscriptions of a Role. Else when roleId List subscriptions of a Custom Role
        /// </summary>
        /// <param name="roleTypeOrRoleId"></param>
        /// <returns>A collection of <see cref="ISubscription"/> that can be enumerated asynchronously.</returns>
        ICollectionClient<ISubscription> ListRoleSubscriptions(string roleTypeOrRoleId);

        /// <summary>
        /// When roleType Get subscriptions of a Role with a specific notification type. Else when roleId Get subscription of a Custom Role with a specific notification type.
        /// </summary>
        /// <param name="roleTypeOrRoleId"></param>
        /// <param name="notificationType"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="ISubscription"/> response.</returns>
        Task<ISubscription> GetRoleSubscriptionByNotificationTypeAsync(string roleTypeOrRoleId, string notificationType, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// When roleType Subscribes a Role to a specific notification type. When you change the subscription status of a Role, it overrides the subscription of any individual user of that Role. Else when roleId Subscribes a Custom Role to a specific notification type. When you change the subscription status of a Custom Role, it overrides the subscription of any individual user of that Custom Role.
        /// </summary>
        /// <param name="roleTypeOrRoleId"></param>
        /// <param name="notificationType"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task SubscribeRoleSubscriptionByNotificationTypeAsync(string roleTypeOrRoleId, string notificationType, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// When roleType Unsubscribes a Role from a specific notification type. When you change the subscription status of a Role, it overrides the subscription of any individual user of that Role. Else when roleId Unsubscribes a Custom Role from a specific notification type. When you change the subscription status of a Custom Role, it overrides the subscription of any individual user of that Custom Role.
        /// </summary>
        /// <param name="roleTypeOrRoleId"></param>
        /// <param name="notificationType"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task UnsubscribeRoleSubscriptionByNotificationTypeAsync(string roleTypeOrRoleId, string notificationType, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Subscribes a User to a specific notification type. Only the current User can subscribe to a specific notification type. An AccessDeniedException message is sent if requests are made from other users.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="notificationType"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task SubscribeUserSubscriptionByNotificationTypeAsync(string userId, string notificationType, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Unsubscribes a User from a specific notification type. Only the current User can unsubscribe from a specific notification type. An AccessDeniedException message is sent if requests are made from other users.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="notificationType"></param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task UnsubscribeUserSubscriptionByNotificationTypeAsync(string userId, string notificationType, CancellationToken cancellationToken = default(CancellationToken));

    }
}
