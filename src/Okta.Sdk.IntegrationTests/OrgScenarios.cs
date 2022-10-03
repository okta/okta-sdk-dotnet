// <copyright file="OrgScenarios.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Extensions;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    public class OrgScenarios
    {
        [Fact]
        public async Task UpdateOrgSettings()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var orgSettings = await client.Orgs.GetOrgSettingsAsync();

            orgSettings.PhoneNumber = "+1-555-415-1337";
            orgSettings.Address1 = "301 Brannan St.";
            orgSettings.Address2 = guid.ToString();

            try
            {
                var updatedOrgSettings = await client.Orgs.UpdateOrgSettingAsync(orgSettings);
                updatedOrgSettings.PhoneNumber.Should().Be("+1-555-415-1337");
                updatedOrgSettings.Address1.Should().Be("301 Brannan St.");
                updatedOrgSettings.Address2.Should().Be(guid.ToString());
            }
            finally
            {
                orgSettings.PhoneNumber = string.Empty;
                orgSettings.Address1 = string.Empty;
                orgSettings.Address2 = string.Empty;
                await client.Orgs.UpdateOrgSettingAsync(orgSettings);
            }
        }

        [Fact]
        public async Task GetOrgSettingsAsync()
        {
            var client = TestClient.Create();

            var orgSettings = await client.Orgs.GetOrgSettingsAsync();

            orgSettings.Should().NotBeNull();
            orgSettings.Id.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task GetOrgContactTypesAsync()
        {
            var client = TestClient.Create();

            var orgContactTypes = await client.Orgs.GetOrgContactTypes().ToListAsync<IOrgContactTypeObj>();

            orgContactTypes.Should().NotBeNullOrEmpty();
            orgContactTypes.Select(x => x.ContactType == OrgContactType.Billing).Should().NotBeNullOrEmpty();
            orgContactTypes.Select(x => x.ContactType == OrgContactType.Technical).Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task UpdateOrgContactTypeUserAsync()
        {
            var client = TestClient.Create();
            var guid = Guid.NewGuid();

            var billingContactUser = await client.Orgs.GetOrgContactUserAsync(OrgContactType.Billing);
            // Create a user
            var user = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
            {
                Profile = new UserProfile
                {
                    FirstName = "John",
                    LastName = "Update-Contact-Type",
                    Email = $"john-org-contact-{guid}@example.com",
                    Login = $"john-org-contact-{guid}@example.com",
                },
                Password = "P4ssw0rd",
            });

            try
            {
                var orgContactUser = await client.Orgs.UpdateOrgContactUserAsync(
                    new UserIdString
                    {
                        UserId = user.Id,
                    }, OrgContactType.Billing);

                orgContactUser.UserId.Should().Be(user.Id);
            }
            finally
            {
                // Reset
                await client.Orgs.UpdateOrgContactUserAsync(
                    new UserIdString
                    {
                        UserId = billingContactUser?.UserId,
                    }, OrgContactType.Billing);

                // Remove the user
                await user.DeactivateAsync();
                await user.DeactivateOrDeleteAsync();
            }
        }

        [Fact]
        public async Task GetOktaSupportSettingsAsync()
        {
            var client = TestClient.Create();

            var orgSupportSettings = await client.Orgs.GetOrgOktaSupportSettingsAsync();
            orgSupportSettings.Should().NotBeNull();
            orgSupportSettings.Support?.Value.Should().ContainAny(OrgOktaSupportSetting.Disabled, OrgOktaSupportSetting.Enabled);
        }

        [Fact]
        public async Task GrantOktaSupportAsync()
        {
            var client = TestClient.Create();
            try
            {
                var orgSupportSettings = await client.Orgs.GrantOktaSupportAsync();
                orgSupportSettings.Should().NotBeNull();
                orgSupportSettings.Support.Should().Be(OrgOktaSupportSetting.Enabled);
                // Expiration should be in 8 hours
                orgSupportSettings.Expiration.Value.UtcDateTime.TimeOfDay.Should().BeLessThan(DateTimeOffset.UtcNow.AddHours(8).TimeOfDay);
            }
            finally
            {
                await client.Orgs.RevokeOktaSupportAsync();
            }
        }

        [Fact]
        public async Task ExtendOktaSupportAsync()
        {
            var client = TestClient.Create();
            try
            {
                var orgSupportSettings = await client.Orgs.GrantOktaSupportAsync();
                orgSupportSettings.Should().NotBeNull();
                orgSupportSettings.Support.Should().Be(OrgOktaSupportSetting.Enabled);
                var initialExpirationValue = orgSupportSettings.Expiration.Value;
                // Expiration should be in 8 hours
                orgSupportSettings.Expiration.Value.UtcDateTime.TimeOfDay.Should().BeLessThan(DateTimeOffset.UtcNow.AddHours(8).TimeOfDay);

                var updatedSupportSettings = await client.Orgs.ExtendOktaSupportAsync();
                updatedSupportSettings.Support.Should().Be(OrgOktaSupportSetting.Enabled);
                (updatedSupportSettings.Expiration.Value > initialExpirationValue).Should().BeTrue();
            }
            finally
            {
                await client.Orgs.RevokeOktaSupportAsync();
            }
        }

        [Fact]
        public async Task RevokeOktaSupportAsync()
        {
            var client = TestClient.Create();
            try
            {
                var orgSupportSettings = await client.Orgs.GrantOktaSupportAsync();
                orgSupportSettings.Should().NotBeNull();
                orgSupportSettings.Support.Should().Be(OrgOktaSupportSetting.Enabled);

                orgSupportSettings = await client.Orgs.RevokeOktaSupportAsync();
                orgSupportSettings.Support.Should().Be(OrgOktaSupportSetting.Disabled);
            }
            finally
            {
                await client.Orgs.RevokeOktaSupportAsync();
            }
        }

        [Fact]
        public async Task GetOktaCommunicationSettingsAsync()
        {
            var client = TestClient.Create();
            var orgCommunicationSettings = await client.Orgs.GetOktaCommunicationSettingsAsync();
            orgCommunicationSettings.Should().NotBeNull();
        }

        [Fact]
        public async Task OptInEmailUsersAsync()
        {
            var client = TestClient.Create();
            try
            {
                var orgCommunicationSettings = await client.Orgs.OptInUsersToOktaCommunicationEmailsAsync();
                orgCommunicationSettings.OptOutEmailUsers.Should().BeFalse();
            }
            finally
            {
                await client.Orgs.OptOutUsersFromOktaCommunicationEmailsAsync();
            }
        }

        [Fact]
        public async Task OptOutEmailUsersAsync()
        {
            var client = TestClient.Create();
            try
            {
                var orgCommunicationSettings = await client.Orgs.OptOutUsersFromOktaCommunicationEmailsAsync();
                orgCommunicationSettings.OptOutEmailUsers.Should().BeTrue();
            }
            finally
            {
                await client.Orgs.OptOutUsersFromOktaCommunicationEmailsAsync();
            }
        }

        [Fact]
        public async Task GetOrgPreferencesAsync()
        {
            var client = TestClient.Create();
            var orgPreferences = await client.Orgs.GetOrgPreferencesAsync();
            orgPreferences.Should().NotBeNull();
        }

        [Fact]
        public async Task ShowEndUserFooterAsync()
        {
            var client = TestClient.Create();

            var orgPreferences = await client.Orgs.ShowOktaUiFooterAsync();
            orgPreferences.ShowEndUserFooter.Should().BeTrue();
        }

        [Fact]
        public async Task HideEndUserFooterAsync()
        {
            var client = TestClient.Create();

            try
            {
                var orgPreferences = await client.Orgs.HideOktaUiFooterAsync();
                orgPreferences.ShowEndUserFooter.Should().BeFalse();
            }
            finally
            {
                var orgPreferences = await client.Orgs.ShowOktaUiFooterAsync();
            }
        }
    }
}
