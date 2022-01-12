// <copyright file="ISubscription.Generated.cs" company="Okta, Inc">
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
    /// <summary>Represents a Subscription resource in the Okta API.</summary>
    public partial interface ISubscription : IResource
    {
        IList<string> Channels { get; set; }

        NotificationType NotificationType { get; set; }

        SubscriptionStatus Status { get; set; }

        ICollectionClient<ISubscription> ListRoleSubscriptions(
            string roleTypeOrRoleId);

        Task<ISubscription> GetRoleSubscriptionByNotificationTypeAsync(
            string roleTypeOrRoleId, string notificationType, CancellationToken cancellationToken = default(CancellationToken));

        Task<ISubscription> GetUserSubscriptionByNotificationTypeAsync(
            string userId, string notificationType, CancellationToken cancellationToken = default(CancellationToken));

        ICollectionClient<ISubscription> ListUserSubscriptions(
            string userId);

        Task SubscribeUserSubscriptionByNotificationTypeAsync(
            string userId, string notificationType, CancellationToken cancellationToken = default(CancellationToken));

        Task UnsubscribeRoleSubscriptionByNotificationTypeAsync(
            string roleTypeOrRoleId, string notificationType, CancellationToken cancellationToken = default(CancellationToken));

        Task SubscribeRoleSubscriptionByNotificationTypeAsync(
            string roleTypeOrRoleId, string notificationType, CancellationToken cancellationToken = default(CancellationToken));

        Task UnsubscribeUserSubscriptionByNotificationTypeAsync(
            string userId, string notificationType, CancellationToken cancellationToken = default(CancellationToken));

    }
}
