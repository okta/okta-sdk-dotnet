using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class ResourceShould
    {
        [Fact]
        public void NotThrowForNullData()
        {
            var resource = new Resource(null);

            resource.Should().NotBeNull();
        }

        [Fact]
        public void InstantiateDerivedResourceFromScratch()
        {
            var resource = new TestResource();

            resource.Should().NotBeNull();
            resource.Foo.Should().BeNullOrEmpty();
            resource.Bar.Should().BeNull();
        }

        [Fact]
        public void InstantiateDerivedResourceWithData()
        {
            var data = new ChangeTrackingDictionary(keyComparer: StringComparer.OrdinalIgnoreCase)
            {
                ["Foo"] = "bar!",
                ["bar"] = true
            };

            var resource = new TestResource(data);

            resource.Foo.Should().Be("bar!");
            resource.Bar.Should().Be(true);
        }

        [Fact]
        public void AccessStringProperty()
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
        public void AccessBooleanProperty()
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
        public void TrackInstanceModifications()
        {
            var resource = new TestResource()
            {
                Foo = "xyz"
            };

            resource.ModifiedData.Keys.Should().BeEquivalentTo("foo");

            resource.Bar = true;

            resource.ModifiedData.Count.Should().Be(2);
            resource.ModifiedData.Should().Contain(new KeyValuePair<string, object>("foo", "xyz"));
            resource.ModifiedData.Should().Contain(new KeyValuePair<string, object>("bar", true));
        }
    }
}
