using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class CollectionClientShould
    {
        private static readonly List<User> TestUsers = new List<User>()
        {
            new User { Id = "123", Status = "ACTIVE" },
            new User { Id = "456", Status = "DISABLED" },
            new User { Id = "abc", Status = "ACTIVE" },
            new User { Id = "xyz", Status = "UNKNOWN" },
            new User { Id = "999", Status = "UNKNOWN" },
        };

        [Fact]
        public async Task CountCollectionAsynchronously()
        {
            var mockRequestExecutor = new MockedCollectionRequestExecutor<User>(pageSize: 2, items: TestUsers);
            var dataStore = new DefaultDataStore(
                mockRequestExecutor,
                new DefaultSerializer());

            var collection = new CollectionClient<User>(
                dataStore, "http://mock-collection.dev", null);

            var count = await collection.Count();
        }

        [Fact]
        public async Task FilterCollectionAsynchronously()
        {
            var mockRequestExecutor = new MockedCollectionRequestExecutor<User>(pageSize: 2, items: TestUsers);
            var dataStore = new DefaultDataStore(
                mockRequestExecutor,
                new DefaultSerializer());

            var collection = new CollectionClient<User>(
                dataStore, "http://mock-collection.dev", null);

            var activeUsers = await collection.Where(x => x.Status == "ACTIVE").ToList();
            activeUsers.Count.Should().Be(2);
        }
    }
}
