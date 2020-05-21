// <copyright file="UsersClientShould.cs" company="Okta, Inc">
// Copyright (c) 2020 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class UsersClientShould
    {
        [Fact]
        public async Task ListApplicationTargetsForApplicationAdministratorRoleForUser()
        {
            var rawResponse = @"[
                                  {
                                    ""name"": ""salesforce"",
                                    ""displayName"": ""Salesforce.com"",
                                    ""description"": ""Salesforce"",
                                    ""status"": ""ACTIVE"",
                                    ""lastUpdated"": ""2014-06-03T16:17:13.000Z"",
                                    ""category"": ""CRM"",
                                    ""verificationStatus"": ""OKTA_VERIFIED"",
                                    ""website"": ""http://www.salesforce.com"",
                                    ""signOnModes"": [
                                      ""SAML_2_0""
                                    ],
                                    ""features"": [
                                      ""IMPORT_NEW_USERS"",
                                    ],
                                    ""_links"": {
                                      ""logo"": [
                                        {
                                          ""name"": ""medium"",
                                          ""href"": ""https://${yourOktaDomain}/img/logos/salesforce_logo.png"",
                                          ""type"": ""image/png""
                                        }
                                      ],
                                      ""self"": {
                                          ""href"": ""https://${yourOktaDomain}/api/v1/catalog/apps/salesforce""
                                      }
                                    }
                                  },
                                  {
                                    ""name"": ""Facebook (Toronto)"",
                                    ""status"": ""ACTIVE"",
                                    ""id"": ""0obdfgrQ5dv29pqyQo0f5"",
                                    ""_links"": {
                                       ""self"": {
                                           ""href"": ""https://${yourOktaDomain}/api/v1/apps/0obdfgrQ5dv29pqyQo0f5""
                                       }
                                    }
                                  }
                                ]";

            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);

            var apps = await client.Users.ListApplicationTargetsForApplicationAdministratorRoleForUser("foo", "bar").ToListAsync();

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/users/foo/roles/bar/targets/catalog/apps");

            apps.Should().NotBeNullOrEmpty();
            apps.Should().HaveCount(2);
            apps.FirstOrDefault().Name.Should().Be("salesforce");
            apps.FirstOrDefault().Status.Should().Be("ACTIVE");
            apps.FirstOrDefault().Id.Should().BeNullOrEmpty();
            apps.FirstOrDefault().GetProperty<string>("description").Should().Be("Salesforce");
            apps.FirstOrDefault().GetProperty<string>("displayName").Should().Be("Salesforce.com");
            apps.FirstOrDefault().GetProperty<string>("category").Should().Be("CRM");
            apps.FirstOrDefault().GetProperty<string>("verificationStatus").Should().Be("OKTA_VERIFIED");
            apps.FirstOrDefault().GetProperty<string>("website").Should().Be("http://www.salesforce.com");
            apps.FirstOrDefault().Features.Should().Contain("IMPORT_NEW_USERS");

            apps[1].Name.Should().Be("Facebook (Toronto)");
            apps[1].Status.Should().Be("ACTIVE");
            apps[1].Id.Should().Be("0obdfgrQ5dv29pqyQo0f5");
        }

        [Fact]
        public async Task AddApplicationTargetForAdministratorRole()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty, 204);
            var client = new TestableOktaClient(mockRequestExecutor);

            await client.Users.AddApplicationTargetToAdminRoleForUserAsync("foo", "bar", "baz");

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/users/foo/roles/bar/targets/catalog/apps/baz");
        }

        [Fact]
        public async Task AddApplicationTargetToAppAdminRoleForUser()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty, 204);
            var client = new TestableOktaClient(mockRequestExecutor);

            await client.Users.AddApplicationTargetToAppAdminRoleForUserAsync("foo", "bar", "baz", "bax");

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/users/foo/roles/bar/targets/catalog/apps/baz/bax");
        }

        [Fact]
        public async Task RemoveApplicationTargetFromAdministratorRoleForUser()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty, 204);
            var client = new TestableOktaClient(mockRequestExecutor);

            await client.Users.RemoveApplicationTargetFromAdministratorRoleForUserAsync("foo", "bar", "baz", "bax");

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/users/foo/roles/bar/targets/catalog/apps/baz/bax");
        }

        [Fact]
        public async Task RemoveApplicationTargetFromApplicationAdministratorRoleForUser()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty, 204);
            var client = new TestableOktaClient(mockRequestExecutor);

            await client.Users.RemoveApplicationTargetFromApplicationAdministratorRoleForUserAsync("foo", "bar", "baz");

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/users/foo/roles/bar/targets/catalog/apps/baz");
        }
    }
}
