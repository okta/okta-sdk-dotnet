// <copyright file="Subscription.Generated.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

// This file was automatically generated. Don't modify it directly.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Okta.Sdk.Internal;

namespace Okta.Sdk
{
    /// <inheritdoc/>
    public sealed partial class Subscription : Resource, ISubscription
    {
        /// <inheritdoc/>
        public IList<string> Channels 
        {
            get => GetArrayProperty<string>("channels");
            set => this["channels"] = value;
        }
        
        /// <inheritdoc/>
        public NotificationType NotificationType 
        {
            get => GetEnumProperty<NotificationType>("notificationType");
            set => this["notificationType"] = value;
        }
        
        /// <inheritdoc/>
        public SubscriptionStatus Status 
        {
            get => GetEnumProperty<SubscriptionStatus>("status");
            set => this["status"] = value;
        }
        
        /// <inheritdoc />
        public ICollectionClient<ISubscription> ListRoleSubscriptions(
            string roleTypeOrRoleId)
            => GetClient().Subscriptions.ListRoleSubscriptions(roleTypeOrRoleId);
        
        /// <inheritdoc />
        public Task<ISubscription> GetRoleSubscriptionByNotificationTypeAsync(
            string roleTypeOrRoleId, string notificationType, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Subscriptions.GetRoleSubscriptionByNotificationTypeAsync(roleTypeOrRoleId, notificationType, cancellationToken);
        
        /// <inheritdoc />
        public Task<ISubscription> GetUserSubscriptionByNotificationTypeAsync(
            string userId, string notificationType, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Users.GetUserSubscriptionByNotificationTypeAsync(userId, notificationType, cancellationToken);
        
        /// <inheritdoc />
        public ICollectionClient<ISubscription> ListUserSubscriptions(
            string userId)
            => GetClient().Users.ListUserSubscriptions(userId);
        
        /// <inheritdoc />
        public Task SubscribeUserSubscriptionByNotificationTypeAsync(
            string userId, string notificationType, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Subscriptions.SubscribeUserSubscriptionByNotificationTypeAsync(userId, notificationType, cancellationToken);
        
        /// <inheritdoc />
        public Task UnsubscribeRoleSubscriptionByNotificationTypeAsync(
            string roleTypeOrRoleId, string notificationType, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Subscriptions.UnsubscribeRoleSubscriptionByNotificationTypeAsync(roleTypeOrRoleId, notificationType, cancellationToken);
        
        /// <inheritdoc />
        public Task SubscribeRoleSubscriptionByNotificationTypeAsync(
            string roleTypeOrRoleId, string notificationType, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Subscriptions.SubscribeRoleSubscriptionByNotificationTypeAsync(roleTypeOrRoleId, notificationType, cancellationToken);
        
        /// <inheritdoc />
        public Task UnsubscribeUserSubscriptionByNotificationTypeAsync(
            string userId, string notificationType, CancellationToken cancellationToken = default(CancellationToken))
            => GetClient().Subscriptions.UnsubscribeUserSubscriptionByNotificationTypeAsync(userId, notificationType, cancellationToken);
        
    }
}
