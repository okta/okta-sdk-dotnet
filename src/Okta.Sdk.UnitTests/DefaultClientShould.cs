using System.Collections.Generic;
using System.Threading.Tasks;
using Okta.Sdk.Abstractions;
using Xunit;
using FluentAssertions;

namespace Okta.Sdk.UnitTests
{
    public class DefaultClientShould
    {
        public class Test : AbstractResource
        {
            public Test(IReadOnlyDictionary<string, object> data, IResourceFactory resourceFactory)
                : base(data, resourceFactory)
            {
            }

            public string Foo => GetStringProperty("foo");
        }

        [Fact]
        public async Task GetResource()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(@"
{
  ""foo"": ""bar""
}
");
            var dataStore = new DefaultDataStore(mockRequestExecutor,
                new DefaultSerializer(),
                new DefaultResourceFactory());

            var client = new OktaClient(dataStore);

            var resource = await client.GetAsync<Test>("http://foobar");
            resource.Foo.Should().Be("bar");
        }
    }
}
