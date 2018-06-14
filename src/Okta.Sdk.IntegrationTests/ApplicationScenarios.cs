// <copyright file="ApplicationScenarios.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    [Collection(nameof(ScenariosCollection))]
    public class ApplicationScenarios : ScenarioGroup
    {
        [Fact]
        public async Task AddBookmarkApp()
        {
            var client = GetClient();

            var createdApp = await client.Applications.CreateApplicationAsync(new BookmarkApplication
            {
                Name = "bookmark",
                Label = "Sample Bookmark App",
                SignOnMode = ApplicationSignOnMode.Bookmark,
                Settings = new BookmarkApplicationSettings
                {
                    App = new BookmarkApplicationSettingsApplication
                    {
                        RequestIntegration = false,
                        Url = "https://example.com/bookmark.htm",
                    },
                },
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync(createdApp.Id);
                retrieved.Name.Should().Be("bookmark");
                retrieved.Label.Should().Be("Sample Bookmark App");
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.Bookmark);


                ((BookmarkApplication)retrieved).Settings.App.RequestIntegration.Should().Be(false);
                ((BookmarkApplication)retrieved).Settings.App.Url.Should().Be("https://example.com/bookmark.htm");
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task AddBasicAuthenticationApp()
        {
            var client = GetClient();

            var createdApp = await client.Applications.CreateApplicationAsync(new BasicAuthApplication
            {
                Name = "template_basic_auth",
                Label = "Sample Basic Auth App",
                SignOnMode = ApplicationSignOnMode.BasicAuth,
                Settings = new BasicApplicationSettings
                {
                    App = new BasicApplicationSettingsApplication
                    {
                        Url = "https://example.com/login.html",
                        AuthUrl = "https://example.com/auth.html",
                    },
                },
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync(createdApp.Id);
                retrieved.Name.Should().Be("template_basic_auth");
                retrieved.Label.Should().Be("Sample Basic Auth App");
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.BasicAuth);


                ((BasicAuthApplication)retrieved).Settings.App.AuthUrl.Should().Be("https://example.com/auth.html");
                ((BasicAuthApplication)retrieved).Settings.App.Url.Should().Be("https://example.com/login.html");
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        public async Task AddSwaApp()
        {
            var client = GetClient();

            var createdApp = await client.Applications.CreateApplicationAsync(new SwaApplication
            {
                Name = "template_swa",
                Label = "Sample Plugin App",
                SignOnMode = ApplicationSignOnMode.BrowserPlugin,
                Settings = new SwaApplicationSettings
                {
                    App = new SwaApplicationSettingsApplication
                    {
                          ButtonField = "btn-login",
                          PasswordField = "txtbox-password",
                          UsernameField = "txtbox-username",
                          Url = "https://example.com/login.html",
                          LoginUrlRegex = "^https://example.com/login.html",
                    },
                },
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync(createdApp.Id);
                retrieved.Name.Should().Be("template_swa");
                retrieved.Label.Should().Be("Sample Plugin App");
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.BrowserPlugin);

                var retrievedSettings = retrieved.GetProperty<SwaApplicationSettings>("settings");

                ((SwaApplicationSettingsApplication)retrievedSettings.App).ButtonField.Should().Be("btn-login");
                ((SwaApplicationSettingsApplication)retrievedSettings.App).PasswordField.Should().Be("txtbox-password");
                ((SwaApplicationSettingsApplication)retrievedSettings.App).UsernameField.Should().Be("txtbox-username");
                ((SwaApplicationSettingsApplication)retrievedSettings.App).Url.Should().Be("https://example.com/login.html");
                ((SwaApplicationSettingsApplication)retrievedSettings.App).LoginUrlRegex.Should().Be("^https://example.com/login.html");
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }

        /// <Fail>
        /// This test FAILS because the expected name for the TargetUrl field in the request is TargetURL.
        /// If I change    set => this["targetUrl"] = value; by    set => this["targetURL"] = value; it works as expected
        /// </Fail>
        [Fact]
        public async Task AddSwaThreeFieldApp()
        {
            var client = GetClient();

            var createdApp = await client.Applications.CreateApplicationAsync(new SwaThreeFieldApplication
            {
                Name = "template_swa3field",
                Label = "Sample Plugin App",
                SignOnMode = ApplicationSignOnMode.BrowserPlugin,
                Settings = new SwaThreeFieldApplicationSettings
                {
                    App = new SwaThreeFieldApplicationSettingsApplication
                    {
                        ButtonSelector = "#btn-login",
                        PasswordSelector = "#txtbox-password",
                        UserNameSelector = "#txtbox-username",
                        TargetUrl = "https://example.com/login.html",
                        ExtraFieldSelector = ".login",
                        ExtraFieldValue = "SOMEVALUE",
                        LoginUrlRegex = "^https://example.com/login.html",
                    },
                },
            });

            try
            {
                var retrieved = await client.Applications.GetApplicationAsync(createdApp.Id);
                retrieved.Name.Should().Be("template_swa3field");
                retrieved.Label.Should().Be("Sample Plugin App");
                retrieved.SignOnMode.Should().Be(ApplicationSignOnMode.BrowserPlugin);

                var retrievedSettings = retrieved.GetProperty<SwaThreeFieldApplicationSettings>("settings");

                ((ISwaThreeFieldApplicationSettingsApplication)retrievedSettings.App).ButtonSelector.Should().Be("#btn-login");
                ((ISwaThreeFieldApplicationSettingsApplication)retrievedSettings.App).PasswordSelector.Should().Be("#txtbox-password");
                ((ISwaThreeFieldApplicationSettingsApplication)retrievedSettings.App).UserNameSelector.Should().Be("#txtbox-username");
                ((ISwaThreeFieldApplicationSettingsApplication)retrievedSettings.App).TargetUrl.Should().Be("https://example.com/login.html");
                ((ISwaThreeFieldApplicationSettingsApplication)retrievedSettings.App).LoginUrlRegex.Should().Be("^https://example.com/login.html");
                ((ISwaThreeFieldApplicationSettingsApplication)retrievedSettings.App).ExtraFieldSelector.Should().Be(".login");
                ((ISwaThreeFieldApplicationSettingsApplication)retrievedSettings.App).ExtraFieldValue.Should().Be("SOMEVALUE");

            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }
    }
}
