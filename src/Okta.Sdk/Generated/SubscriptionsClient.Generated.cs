// <copyright file="SubscriptionsClient.Generated.cs" company="Okta, Inc">
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
    public sealed partial class SubscriptionsClient : OktaClient, ISubscriptionsClient
    {
        // Remove parameterless constructor
        private SubscriptionsClient()
        {
        }

        internal SubscriptionsClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }
        
        /// <inheritdoc />
        public ICollectionClient<ISubscription> ListRoleSubscriptions(string roleTypeOrRoleId)
            => GetCollectionClient<ISubscription>(new HttpRequest
            {
                Uri = "/api/v1/roles/{roleTypeOrRoleId}/subscriptions",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["roleTypeOrRoleId"] = roleTypeOrRoleId,
                },
            });
                    
        /// <inheritdoc />
        public async Task<ISubscription> GetRoleSubscriptionByNotificationTypeAsync(string roleTypeOrRoleId, string notificationType, CancellationToken cancellationToken = default(CancellationToken))
            => await GetAsync<Subscription>(new HttpRequest
            {
                Uri = "/api/v1/roles/{roleTypeOrRoleId}/subscriptions/{notificationType}",
                Verb = HttpVerb.Get,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["roleTypeOrRoleId"] = roleTypeOrRoleId,
                    ["notificationType"] = notificationType,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task SubscribeRoleSubscriptionByNotificationTypeAsync(string roleTypeOrRoleId, string notificationType, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/roles/{roleTypeOrRoleId}/subscriptions/{notificationType}/subscribe",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["roleTypeOrRoleId"] = roleTypeOrRoleId,
                    ["notificationType"] = notificationType,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task UnsubscribeRoleSubscriptionByNotificationTypeAsync(string roleTypeOrRoleId, string notificationType, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/roles/{roleTypeOrRoleId}/subscriptions/{notificationType}/unsubscribe",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["roleTypeOrRoleId"] = roleTypeOrRoleId,
                    ["notificationType"] = notificationType,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task SubscribeUserSubscriptionByNotificationTypeAsync(string userId, string notificationType, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/subscriptions/{notificationType}/subscribe",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["notificationType"] = notificationType,
                },
                }, cancellationToken).ConfigureAwait(false);
        
        /// <inheritdoc />
        public async Task UnsubscribeUserSubscriptionByNotificationTypeAsync(string userId, string notificationType, CancellationToken cancellationToken = default(CancellationToken))
            => await PostAsync(new HttpRequest
            {
                Uri = "/api/v1/users/{userId}/subscriptions/{notificationType}/unsubscribe",
                Verb = HttpVerb.Post,
                
                PathParameters = new Dictionary<string, object>()
                {
                    ["userId"] = userId,
                    ["notificationType"] = notificationType,
                },
                }, cancellationToken).ConfigureAwait(false);
        
    }
}
