using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class DefaultClientShould
    {
        [Fact]
        public async Task GetResource()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(@"{ ""foo"": ""bar"" }");
            var dataStore = new DefaultDataStore(
                mockRequestExecutor,
                new DefaultSerializer());

            var client = new OktaClient(dataStore);

            var resource = await client.GetAsync<TestResource>("http://foobar");
            resource.Foo.Should().Be("bar");
        }
    }
}
