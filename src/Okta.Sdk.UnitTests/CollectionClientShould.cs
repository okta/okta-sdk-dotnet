using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class CollectionClientShould
    {
        [Fact]
        public async Task CountCollectionAsynchronously()
        {
            var mockRequestExecutor = new MockedCollectionRequestExecutor<int>(
                pageSize: 2,
                items: new List<int>() { 1, 2, 3, 4, 5 });

            var collection = new CollectionClient<int>(
                mockRequestExecutor,
                new DefaultSerializer(),
                new DefaultResourceFactory(),
                "http://foo/bar",
                null);

            var count = await collection.Count();
        }
    }
}
