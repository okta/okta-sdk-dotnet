using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class ResourceFactoryShould
    {
        [Fact]
        public void InstantiateEmptyResource()
        {
            var resource = ResourceFactory.Create<Test>();
            resource.Should().NotBeNull();
            resource.Foo.Should().BeNullOrEmpty();
        }

        [Fact]
        public void InstantiateResourceWithData()
        {
            var data = new Dictionary<string, object>()
            {
                ["Foo"] = "bar!"
            };

            var resource = ResourceFactory.Create<Test>(data);
            resource.Should().NotBeNull();
            resource.Foo.Should().Be("bar!");
        }

        public class Test : Resource
        {
            public string Foo => GetStringProperty("foo");
        }
    }
}
