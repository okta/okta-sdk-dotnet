// <copyright file="CollectionClientShould.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Okta.Sdk.Abstractions;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class CollectionClientShould
    {
        private static readonly List<User> TestUsers = new List<User>()
        {
            new ResourceCreator<User>().With((u => u.Id, "123"), (u => u.Status, "ACTIVE")),
            new ResourceCreator<User>().With((u => u.Id, "456"), (u => u.Status, "DISABLED")),
            new ResourceCreator<User>().With((u => u.Id, "abc"), (u => u.Status, "ACTIVE")),
            new ResourceCreator<User>().With((u => u.Id, "xyz"), (u => u.Status, "UNKNOWN")),
            new ResourceCreator<User>().With((u => u.Id, "999"), (u => u.Status, "UNKNOWN")),
        };

        [Fact]
        public async Task CountCollectionAsynchronously()
        {
            var mockRequestExecutor = new MockedCollectionRequestExecutor<User>(pageSize: 2, items: TestUsers);
            var dataStore = new DefaultDataStore(
                mockRequestExecutor,
                new DefaultSerializer(),
                NullLogger.Instance);

            var collection = new CollectionClient<User>(
                dataStore, new HttpRequest { Uri = "http://mock-collection.dev" });

            var count = await collection.Count();
        }

        [Fact]
        public async Task FilterCollectionAsynchronously()
        {
            var mockRequestExecutor = new MockedCollectionRequestExecutor<User>(pageSize: 2, items: TestUsers);
            var dataStore = new DefaultDataStore(
                mockRequestExecutor,
                new DefaultSerializer(),
                NullLogger.Instance);

            var collection = new CollectionClient<User>(
                dataStore, new HttpRequest { Uri = "http://mock-collection.dev" });

            var activeUsers = await collection.Where(x => x.Status == "ACTIVE").ToList();
            activeUsers.Count.Should().Be(2);
        }
    }
}
