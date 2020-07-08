// <copyright file="GroupsClientShould.cs" company="Okta, Inc">
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
    public class GroupsClientShould
    {
        [Fact]
        public async Task ListApplicationTargetsForApplicationAdministratorRoleForGroup()
        {
            var rawResponse = @"[
                                    {
                                        ""name"": ""facebook"",
                                        ""displayName"": ""Facebook"",
                                        ""description"": ""Description"",
                                        ""status"": ""ACTIVE"",
                                        ""lastUpdated"": ""2017-07-19T23:37:37.000Z"",
                                        ""category"": ""SOCIAL"",
                                        ""verificationStatus"": ""OKTA_VERIFIED"",
                                        ""website"": ""http://www.facebook.com"",
                                        ""signOnModes"": [
                                            ""BROWSER_PLUGIN""
                                        ],
                                        ""_links"": {
                                            ""logo"": [
                                                {
                                                    ""name"": ""medium"",
                                                    ""href"": ""http://${yourOktaDomain}/assets/img/logos/facebook.e8215796628b5eaf687ba414ae245659.png"",
                                                    ""type"": ""image/png""
                                                }
                                            ],
                                            ""self"": {
                                                ""href"": ""http://${yourOktaDomain}/api/v1/catalog/apps/facebook""
                                            }
                                        }
                                    },
                                    {
                                        ""name"": ""24 Seven Office 0"",
                                        ""status"": ""ACTIVE"",
                                        ""id"": ""0oasrudLtMlzAsTxk0g3"",
                                        ""_links"": {
                                            ""self"": {
                                                ""href"": ""http://${yourOktaDomain}/api/v1/apps/0oasrudLtMlzAsTxk0g3""
                                            }
                                        }
                                    }
                                ]";

            var mockRequestExecutor = new MockedStringRequestExecutor(rawResponse);
            var client = new TestableOktaClient(mockRequestExecutor);

            var apps = await client.Groups.ListApplicationTargetsForApplicationAdministratorRoleForGroup("foo", "bar").ToListAsync();

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/groups/foo/roles/bar/targets/catalog/apps");

            apps.Should().NotBeNullOrEmpty();
            apps.Should().HaveCount(2);
            apps.FirstOrDefault().Name.Should().Be("facebook");
            apps.FirstOrDefault().Status.Should().Be(CatalogApplicationStatus.Active);
            apps.FirstOrDefault().Id.Should().BeNullOrEmpty();
            apps.FirstOrDefault().GetProperty<string>("description").Should().Be("Description");
            apps.FirstOrDefault().GetProperty<string>("displayName").Should().Be("Facebook");
            apps.FirstOrDefault().GetProperty<string>("category").Should().Be("SOCIAL");
            apps.FirstOrDefault().GetProperty<string>("verificationStatus").Should().Be("OKTA_VERIFIED");
            apps.FirstOrDefault().GetProperty<string>("website").Should().Be("http://www.facebook.com");
            apps.FirstOrDefault().GetArrayProperty<string>("signOnModes").Should().Contain("BROWSER_PLUGIN");

            apps[1].Name.Should().Be("24 Seven Office 0");
            apps[1].Status.Should().Be(CatalogApplicationStatus.Active);
            apps[1].Id.Should().Be("0oasrudLtMlzAsTxk0g3");
        }

        [Fact]
        public async Task AddApplicationTargetToAdminRoleGivenToGroup()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty, 204);
            var client = new TestableOktaClient(mockRequestExecutor);

            await client.Groups.AddApplicationTargetToAdminRoleGivenToGroupAsync("foo", "bar", "baz");

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/groups/foo/roles/bar/targets/catalog/apps/baz");
        }

        [Fact]
        public async Task AddApplicationInstanceTargetToAppAdminRoleGivenToGroup()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty, 204);
            var client = new TestableOktaClient(mockRequestExecutor);

            await client.Groups.AddApplicationInstanceTargetToAppAdminRoleGivenToGroupAsync("foo", "bar", "baz", "bax");

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/groups/foo/roles/bar/targets/catalog/apps/baz/bax");
        }

        [Fact]
        public async Task RemoveApplicationTargetFromAdministratorRoleGivenToGroup()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty, 204);
            var client = new TestableOktaClient(mockRequestExecutor);

            await client.Groups.RemoveApplicationTargetFromAdministratorRoleGivenToGroupAsync("foo", "bar", "baz", "bax");

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/groups/foo/roles/bar/targets/catalog/apps/baz/bax");
        }

        [Fact]
        public async Task RemoveApplicationTargetFromApplicationAdministratorRoleGivenToGroup()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(string.Empty, 204);
            var client = new TestableOktaClient(mockRequestExecutor);

            await client.Groups.RemoveApplicationTargetFromApplicationAdministratorRoleGivenToGroupAsync("foo", "bar", "baz");

            mockRequestExecutor.ReceivedHref.Should().StartWith("/api/v1/groups/foo/roles/bar/targets/catalog/apps/baz");
        }
    }
}
