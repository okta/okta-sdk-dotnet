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
            var successful = true;
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
                successful = false;
            }
            finally
            {
                // Remove the users
                var tasks = createdUsers.Select(x => DeleteUser(x));

                await Task.WhenAll(tasks);
            }

            successful.Should().BeTrue();
        }

        /// <summary>
        /// Tests that a developer can use the PagedCollectionEnumerator to enumerate a collection.
        /// In most cases it is easier to use LINQ, but this approach is available if you access to each page.
        /// </summary>
        /// <returns>The asynchronous test.</returns>
        [Fact]
        public async Task EnumerateCollectionManually()
        {
            var successful = true;
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
                var retrievedUsers = new List<IUser>();
                var users = client.Users.ListUsers(limit: 2, filter: "profile.lastName eq \"CollectionEnumeration\"");
                var enumerator = users.GetPagedEnumerator();

                while (await enumerator.MoveNextAsync())
                {
                    retrievedUsers.AddRange(enumerator.CurrentPage.Items);
                }

                retrievedUsers.Count.Should().Be(10);
            }
            catch (Exception e)
            {
                _logger.LogMessage($"Exception while running test: {e.Message}");
                successful = false;
            }
            finally
            {
                // Remove the users
                var tasks = createdUsers.Select(x => DeleteUser(x));

                await Task.WhenAll(tasks);
            }

            successful.Should().BeTrue();
        }

        /// <summary>
        /// Tests that a developer can use the PagedCollectionEnumerator to retrieve a page
        /// and manually set up another PagedCollectionEnumerator to resume enumeration with the NextLink.
        /// In most cases it is easier to use LINQ, but this approach is available if you need to manually resume.
        /// </summary>
        /// <returns>The asynchronous test.</returns>
        [Fact]
        public async Task EnumerateCollectionManuallyAndResume()
        {
            var successful = true;
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
                var retrievedUsers = new List<IUser>();
                var users = client.Users.ListUsers(limit: 2, filter: "profile.lastName eq \"CollectionEnumeration\"");
                var enumerator = users.GetPagedEnumerator();

                while (await enumerator.MoveNextAsync())
                {
                    retrievedUsers.AddRange(enumerator.CurrentPage.Items);

                    var nextPageHref = enumerator.CurrentPage.NextLink?.Target;

                    if (string.IsNullOrEmpty(nextPageHref))
                    {
                        break;
                    }

                    users = client.GetCollection<IUser>(nextPageHref);
                    enumerator = users.GetPagedEnumerator();
                }

                retrievedUsers.Count.Should().Be(10);
            }
            catch (Exception e)
            {
                _logger.LogMessage($"Exception while running test: {e.Message}");
                successful = false;
            }
            finally
            {
                // Remove the users
                var tasks = createdUsers.Select(x => DeleteUser(x));

                await Task.WhenAll(tasks);
            }

            successful.Should().BeTrue();
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
