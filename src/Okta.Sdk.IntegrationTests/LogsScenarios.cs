using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    [Collection(nameof(ScenariosCollection))]
    public class LogsScenarios : ScenarioGroup
    {
        [Fact]
        public async Task GetLogs()
        {
            var client = GetClient();
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
        public async Task GetLogsByQueryString()
        {
            var client = GetClient();
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
        public async Task GetLogsByEventType()
        {
            var client = GetClient();
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

        [Fact]
        public async Task GetLogsBySinceDate()
        {
            var client = GetClient();
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
