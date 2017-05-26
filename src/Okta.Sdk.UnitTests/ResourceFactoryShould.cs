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
            var resource = ResourceFactory.Create<TestResource>(null);
            resource.Should().NotBeNull();
            resource.Foo.Should().BeNullOrEmpty();
            resource.Bar.Should().BeNullOrEmpty();
        }

        [Fact]
        public void InstantiateResourceWithData()
        {
            var data = new Dictionary<string, object>()
            {
                ["Foo"] = "bar!",
                ["bar"] = "BAZ"
            };

            var resource = ResourceFactory.Create<TestResource>(data);
            resource.Should().NotBeNull();
            resource.Foo.Should().Be("bar!");
            resource.Bar.Should().Be("BAZ");
        }
    }
}
