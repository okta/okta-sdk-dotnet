using FluentAssertions;
using System;
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
            resource.Bar.Should().BeNull();
        }

        [Fact]
        public void InstantiateResourceWithData()
        {
            var data = new ChangeTrackingDictionary(keyComparer: StringComparer.OrdinalIgnoreCase)
            {
                ["Foo"] = "bar!",
                ["bar"] = true
            };

            var resource = ResourceFactory.Create<TestResource>(data);
            resource.Should().NotBeNull();
            resource.Foo.Should().Be("bar!");
            resource.Bar.Should().Be(true);
        }
    }
}
