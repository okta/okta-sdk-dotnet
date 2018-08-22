// <copyright file="CollectionScenarios.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.IntegrationTests
{
    [Collection(nameof(CollectionScenarios))]
    public class CollectionScenarios : IClassFixture<LoggingFixture>
    {
        private readonly LoggingFixture _logger;

        public CollectionScenarios(LoggingFixture logger)
        {
            _logger = logger;
        }

        [Fact]
        public async Task EnumerateCollectionWithLinq()
        {
            var client = TestClient.Create();
            var createdUsers = new ConcurrentBag<IUser>();

            try
            {
                // Create 10 users (in parallel)
                var tasks = new List<Task>();
                for (var i = 0; i < 10; i++)
                {
                    tasks.Add(CreateRandomUser(client, createdUsers));
                }

                await Task.WhenAll(tasks);

                // Alright, all set up. Try enumerating users by pages of 2:
                var users = client.Users.ListUsers(limit: 2, filter: "profile.lastName eq \"CollectionEnumeration\"");
                var count = await users.Count();
                count.Should().Be(10);
            }
            catch (Exception e)
            {
                _logger.LogMessage($"Exception while running test: {e.Message}");
            }
            finally
            {
                // Remove the users
                var tasks = createdUsers.Select(x => DeleteUser(x));

                await Task.WhenAll(tasks);
            }
        }

        private async Task CreateRandomUser(IOktaClient client, ConcurrentBag<IUser> createdUsers)
        {
            var randomGuid = Guid.NewGuid();

            var user = await client.Users.CreateUserAsync(new CreateUserWithoutCredentialsOptions
            {
                Profile = new UserProfile
                {
                    FirstName = $"Jack-{randomGuid}",
                    LastName = "CollectionEnumeration",
                    Email = $"collection-enumeration-{randomGuid}@example.com",
                    Login = $"collection-enumeration-{randomGuid}@example.com",
                },
                Activate = false,
            });

            createdUsers.Add(user);
        }

        private async Task DeleteUser(IUser user)
        {
            try
            {
                await user.DeactivateAsync();
                await user.DeactivateOrDeleteAsync();
            }
            catch (Exception e)
            {
                _logger.LogMessage($"Exception while cleaning up test: {e.Message}");
            }
        }
    }
}
