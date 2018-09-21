// <copyright file="LogsScenarios.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    [Collection(nameof(LogsScenarios))]
    public class LogsScenarios
    {
        [Fact]
        [Trait("Category", "NoBacon")] // Tests that don't run on internal CI pipeline
        public async Task GetLogs()
        {
            var client = TestClient.Create();

            // Create an Application so there is something in the logs
            var createdApp = await client.Applications.CreateApplicationAsync(new CreateBasicAuthApplicationOptions()
            {
                Label = "App creation to be logged",
                Url = "https://example.com/login.html",
                AuthUrl = "https://example.com/auth.html",
            });

            try
            {
                var logs = await client.Logs.GetLogs().ToList();

                logs.Should().NotBeNullOrEmpty();
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        [Trait("Category", "NoBacon")] // Tests that don't run on internal CI pipeline
        public async Task GetLogsByQueryString()
        {
            var client = TestClient.Create();

            // Create an Application so there is something in the logs
            var createdApp = await client.Applications.CreateApplicationAsync(new CreateBasicAuthApplicationOptions()
            {
                Label = "App creation to be logged",
                Url = "https://example.com/login.html",
                AuthUrl = "https://example.com/auth.html",
            });

            await Task.Delay(2000);

            try
            {
                var query = "App creation to be logged";
                var logs = await client.Logs.GetLogs(null, null, null, query).ToList();

                logs.Should().NotBeNullOrEmpty();
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }

        [Fact]
        [Trait("Category", "NoBacon")] // Tests that don't run on internal CI pipeline
        public async Task GetLogsByEventType()
        {
            var client = TestClient.Create();

            // Create an Application so there is something in the logs
            var createdApp = await client.Applications.CreateApplicationAsync(new CreateBasicAuthApplicationOptions()
            {
                Label = "App creation to be logged",
                Url = "https://example.com/login.html",
                AuthUrl = "https://example.com/auth.html",
            });

            try
            {
                var filter = "eventType eq \"directory.app_user_profile.bootstrap\"";
                var logs = await client.Logs.GetLogs(null, null, filter).ToList();

                logs.Should().NotBeNullOrEmpty();
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }

	[Fact(Skip = "https://github.com/okta/okta-sdk-dotnet/issues/271")]	
        [Trait("Category", "NoBacon")] // Tests that don't run on internal CI pipeline
	public async Task GetLogsBySinceDate()
        {
            var client = TestClient.Create();

            // Create an Application so there is something in the logs
            var createdApp = await client.Applications.CreateApplicationAsync(new CreateBasicAuthApplicationOptions()
            {
                Label = "App creation to be logged",
                Url = "https://example.com/login.html",
                AuthUrl = "https://example.com/auth.html",
            });

            try
            {
                var until = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
                var since = DateTime.UtcNow.AddDays(-1).ToString("yyyy-MM-ddTHH:mm:ssZ");
                var logs = await client.Logs.GetLogs(until, since).ToList();

                logs.Should().NotBeNullOrEmpty();
            }
            finally
            {
                await client.Applications.DeactivateApplicationAsync(createdApp.Id);
                await client.Applications.DeleteApplicationAsync(createdApp.Id);
            }
        }
    }
}
