using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class ResourceShould
    {
        public class TestierResource : TestResource
        {
            public TestierResource Nested => GetProperty<TestierResource>("nested");
        }

        [Fact]
        public void NotThrowForNullData()
        {
            var resource = new TestierResource();
            resource.Should().NotBeNull();
        }

        [Fact]
        public void NotThrowForNonexistentNestedProperty()
        {
            var resource = new TestierResource();
            resource.Nested.Should().NotBeNull();
        }

        [Fact]
        public void GetInheritedAndNestedProperties()
        {
            var data = new Dictionary<string, object>()
            {
                ["foo"] = "abc",
                ["bar"] = "xyz",
                ["nested"] = new Dictionary<string, object>()
                {
                    ["foo"] = "123",
                    ["Bar"] = "nested is neet!"
                }
            };

            var resource = ResourceFactory.Create<TestierResource>(data);

            resource.Should().NotBeNull();
            resource.Foo.Should().Be("abc");
            resource.Bar.Should().Be("xyz");

            resource.Nested.Should().NotBeNull();
            resource.Nested.Foo.Should().Be("123");
            resource.Nested.Bar.Should().Be("nested is neet!");
        }
    }
}
