// <copyright file="CollectionClientShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Okta.Sdk.Internal;
using Okta.Sdk.UnitTests.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class CollectionClientShould
    {
        private static readonly List<IUser> TestUsers = new List<IUser>()
        {
            TestResourceCreator.NewUser(id: "123", status: "ACTIVE"),
            TestResourceCreator.NewUser(id: "456", status: UserStatus.Deprovisioned),
            TestResourceCreator.NewUser(id: "abc", status: UserStatus.Active),
            TestResourceCreator.NewUser(id: "xyz", status: "UNKNOWN"),
            TestResourceCreator.NewUser(id: "999", status: "UNKNOWN"),
        };

        [Fact]
        public async Task GetAllItems()
        {
            var mockRequestExecutor = new MockedCollectionRequestExecutor<User>(pageSize: 2, items: TestUsers);
            var dataStore = new DefaultDataStore(
                mockRequestExecutor,
                new DefaultSerializer(),
                new ResourceFactory(null, null),
                NullLogger.Instance);

            var collection = new CollectionClient<User>(
                dataStore,
                new HttpRequest { Uri = "http://mock-collection.dev" },
                new RequestContext());

            var all = await collection.ToArrayAsync();
            all.Count.Should().Be(5);
        }

        [Fact]
        public async Task CountCollectionAsynchronously()
        {
            var mockRequestExecutor = new MockedCollectionRequestExecutor<IUser>(pageSize: 2, items: TestUsers);
            var dataStore = new DefaultDataStore(
                mockRequestExecutor,
                new DefaultSerializer(),
                new ResourceFactory(null, null),
                NullLogger.Instance);

            var collection = new CollectionClient<User>(
                dataStore,
                new HttpRequest { Uri = "http://mock-collection.dev" },
                new RequestContext());

            var count = await collection.Count();
            count.Should().Be(5);
        }

        [Fact]
        public async Task FilterCollectionAsynchronously()
        {
            var mockRequestExecutor = new MockedCollectionRequestExecutor<IUser>(pageSize: 2, items: TestUsers);
            var dataStore = new DefaultDataStore(
                mockRequestExecutor,
                new DefaultSerializer(),
                new ResourceFactory(null, null),
                NullLogger.Instance);

            var collection = new CollectionClient<User>(
                dataStore,
                new HttpRequest { Uri = "http://mock-collection.dev" },
                new RequestContext());

            var activeUsers = await collection.Where(x => x.Status == "ACTIVE").ToList();
            activeUsers.Count.Should().Be(2);
        }
    }
}
