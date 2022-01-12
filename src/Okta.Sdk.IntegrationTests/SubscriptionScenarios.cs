// <copyright file="SubscriptionScenarios.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    public class SubscriptionScenarios
    {
        [Fact]
        public async Task SubscribeUnsubscribeRoleToNotification()
        {
            var client = TestClient.Create();

            await client.Subscriptions.SubscribeRoleSubscriptionByNotificationTypeAsync(RoleType.HelpDeskAdmin, NotificationType.OktaAnnouncement);

            var subscriptions =
                await client.Subscriptions.ListRoleSubscriptions(RoleType.HelpDeskAdmin).ToListAsync();

            var subscription = subscriptions.FirstOrDefault(x => x.NotificationType == NotificationType.OktaAnnouncement);
            subscription.Should().NotBeNull();
            subscription.Status.Should().Be(SubscriptionStatus.Subscribed);

            await client.Subscriptions.UnsubscribeRoleSubscriptionByNotificationTypeAsync(RoleType.HelpDeskAdmin, NotificationType.OktaAnnouncement);

            subscriptions =
                await client.Subscriptions.ListRoleSubscriptions(RoleType.HelpDeskAdmin).ToListAsync();

            subscription = subscriptions.FirstOrDefault(x => x.NotificationType == NotificationType.OktaAnnouncement);
            subscription.Status.Should().Be(SubscriptionStatus.Unsubscribed);
        }

        [Fact]
        public async Task ListSubscriptionsOfRole()
        {
            var client = TestClient.Create();

            var subscriptions =
                await client.Subscriptions.ListRoleSubscriptions(RoleType.HelpDeskAdmin).ToListAsync();

            // Response contains all the subscriptions with status subscribed or unsubscribed
            subscriptions.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetSubscriptionOfRoleWithSpecificNotificationType()
        {
            var client = TestClient.Create();

            await client.Subscriptions.SubscribeRoleSubscriptionByNotificationTypeAsync(RoleType.SuperAdmin, NotificationType.IwaAgent);
            var subscription = await client.Subscriptions.GetRoleSubscriptionByNotificationTypeAsync(RoleType.SuperAdmin, NotificationType.IwaAgent);

            subscription.Should().NotBeNull();
            subscription.Status.Should().Be(SubscriptionStatus.Subscribed);

            await client.Subscriptions.UnsubscribeRoleSubscriptionByNotificationTypeAsync(RoleType.SuperAdmin, NotificationType.IwaAgent);
        }

        [Fact(Skip = "Missing custom role API")]
        public async Task ListSubscriptionsOfCustomRole()
        {
            var client = TestClient.Create();

            // TODO: Create custom role

            var subscriptions =
                await client.Subscriptions.ListRoleSubscriptions(RoleType.HelpDeskAdmin).ToListAsync();

            // Response contains all the subscriptions with status subscribed or unsubscribed
            subscriptions.Should().NotBeNullOrEmpty();
        }
    }
}
