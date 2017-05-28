using FluentAssertions;
using Okta.Sdk.Abstractions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class ResourceShould
    {
        public class TestierResource : TestResource
        {
            public TestierResource() : base(null) { }
            public TestierResource(IDeltaDictionary<string, object> data) : base(data) { }

            public TestierResource Nested => GetProperty<TestierResource>("nested");
        }

        [Fact]
        public void NotThrowForNullData()
        {
            var resource = new Resource(null);
            resource.Should().NotBeNull();
        }

        [Fact]
        public void NotThrowForNonexistentNestedProperty()
        {
            var resource = new TestierResource();
            resource.Nested.Should().NotBeNull();
        }

        [Fact]
        public void GetStringProperty()
        {
            var data = new Dictionary<string, object>()
            {
                ["foo"] = "abc",
                ["bar"] = true
            };
            var changeTrackingDictionary = new ChangeTrackingDictionary(data, StringComparer.OrdinalIgnoreCase);

            var resource = new Resource(changeTrackingDictionary);

            resource.GetStringProperty("foo").Should().Be("abc");
        }

        [Fact]
        public void GetBooleanProperty()
        {
            var data = new Dictionary<string, object>()
            {
                ["foo"] = "abc",
                ["bar"] = true
            };
            var changeTrackingDictionary = new ChangeTrackingDictionary(data, StringComparer.OrdinalIgnoreCase);

            var resource = new Resource(changeTrackingDictionary);

            resource.GetBooleanProperty("bar").Should().Be(true);
        }

        [Fact]
        public void GetInheritedAndNestedProperties()
        {
            var data = new Dictionary<string, object>()
            {
                ["foo"] = "abc",
                ["bar"] = true,
                ["nested"] = new Dictionary<string, object>()
                {
                    ["foo"] = "nested is neet!",
                    ["Bar"] = false
                }
            };
            var changeTrackingDictionary = new ChangeTrackingDictionary(data, StringComparer.OrdinalIgnoreCase);

            var resource = new TestierResource(changeTrackingDictionary);

            resource.Should().NotBeNull();
            resource.Foo.Should().Be("abc");
            resource.Bar.Should().Be(true);

            resource.Nested.Should().NotBeNull();
            resource.Nested.Foo.Should().Be("nested is neet!");
            resource.Nested.Bar.Should().Be(false);
        }

        [Fact]
        public void GetModifiedData()
        {
            var data = new Dictionary<string, object>()
            {
                ["foo"] = "abc",
                ["bar"] = true
            };
            var changeTrackingDictionary = new ChangeTrackingDictionary(data, StringComparer.OrdinalIgnoreCase);

            var resource = new TestResource(changeTrackingDictionary)
            {
                Foo = "xyz"
            };

            resource.ModifiedData.Count.Should().Be(1);
            resource.ModifiedData.Should().Contain(new KeyValuePair<string, object>("foo", "xyz"));
        }
    }
}
