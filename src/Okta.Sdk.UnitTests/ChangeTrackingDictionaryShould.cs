using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class ChangeTrackingDictionaryShould
    {
        [Fact]
        public void SetInitialState()
        {
            var initialData = new Dictionary<string, object>()
            {
                ["foo"] = "bar"
            };
            var dictionary = new ChangeTrackingDictionary<string, object>(DictionaryFactory.NewDictionary, initialData);

            dictionary.ContainsKey("foo").Should().Be(true);
            dictionary["foo"].Should().Be("bar");
        }

        [Fact]
        public void AllowChanges()
        {
            var dictionary = new ChangeTrackingDictionary<string, object>(DictionaryFactory.NewDictionary);

            dictionary.ContainsKey("foo").Should().Be(false);

            dictionary["foo"] = "bar";

            dictionary["foo"].Should().Be("bar");
        }

        [Fact]
        public void TrackChanges()
        {
            var initialData = new Dictionary<string, object>()
            {
                ["foo"] = "a",
                ["bar"] = "b"
            };
            var dictionary = new ChangeTrackingDictionary<string, object>(DictionaryFactory.NewDictionary, initialData)
            {
                ["foo"] = "c",
                ["baz"] = "d"
            };

            dictionary.ContainsKey("foo").Should().Be(true);
            dictionary.ContainsKey("bar").Should().Be(true);
            dictionary.ContainsKey("baz").Should().Be(true);

            dictionary["foo"].Should().Be("c");
            dictionary["bar"].Should().Be("b");
            dictionary["baz"].Should().Be("d");

            dictionary.ModifiedData.Keys.Should().BeEquivalentTo("foo", "baz");
        }

        [Fact]
        public void ResetChanges()
        {
            var initialData = new Dictionary<string, object>()
            {
                ["foo"] = "a",
                ["bar"] = "b"
            };
            var dictionary = new ChangeTrackingDictionary<string, object>(DictionaryFactory.NewDictionary, initialData)
            {
                ["foo"] = "c",
                ["baz"] = "d"
            };

            dictionary.ModifiedData.Count.Should().Be(2);

            dictionary.ResetChanges();

            dictionary.ModifiedData.Count.Should().Be(0);

            dictionary["foo"].Should().Be("a");
            dictionary["bar"].Should().Be("b");
            dictionary.ContainsKey("baz").Should().Be(false);
        }

        [Fact]
        public void TrackWhenCleared()
        {
            var initialData = new Dictionary<string, object>()
            {
                ["foo"] = "a",
                ["bar"] = "b"
            };
            var dictionary = new ChangeTrackingDictionary<string, object>(DictionaryFactory.NewDictionary, initialData)
            {
                ["foo"] = "c",
                ["baz"] = "d"
            };

            dictionary.Clear();

            dictionary.Count.Should().Be(2);
            dictionary.ModifiedData.Count.Should().Be(2);

            dictionary["foo"].Should().BeNull();
        }
    }
}
