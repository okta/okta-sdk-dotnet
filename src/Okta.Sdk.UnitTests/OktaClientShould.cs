// <copyright file="OktaClientShould.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using Okta.Sdk.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class OktaClientShould
    {
        [Fact]
        public async Task GetCollection()
        {
            var testItems = new[]
            {
                new TestResource { Foo = "foo1" },
                new TestResource { Foo = "foo2", Bar = true },
                new TestResource { Foo = "foo3", Bar = false },
            };
            var mockRequestExecutor = new MockedCollectionRequestExecutor<TestResource>(pageSize: 2, items: testItems);
            var dataStore = new DefaultDataStore(
                mockRequestExecutor,
                new DefaultSerializer(),
                new ResourceFactory(null, null),
                NullLogger.Instance);

            var client = new TestableOktaClient(dataStore);

            var items = await client.GetCollection<TestResource>("https://stuff").ToArray();

            items.Count().Should().Be(3);
            items.ElementAt(0).Foo.Should().Be("foo1");
            items.ElementAt(2).Foo.Should().Be("foo3");
            items.ElementAt(2).Bar.Should().Be(false);
        }
    }
}
