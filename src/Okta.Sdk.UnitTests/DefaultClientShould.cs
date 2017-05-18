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

            public string Foo => GetString("foo");
        }

        [Fact]
        public async Task GetResource()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(@"
{
  ""foo"": ""bar""
}
");
            var client = new OktaClient(
                mockRequestExecutor,
                new DefaultSerializer(),
                new DefaultResourceFactory());

            var resource = await client.GetAsync<Test>("http://foobar");
            resource.Foo.Should().Be("bar");
        }
    }
}
