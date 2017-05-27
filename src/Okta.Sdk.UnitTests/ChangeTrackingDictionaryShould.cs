using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class ChangeTrackingDictionaryShould
    {
        [Fact]
        public void CreateEmptyDictionary()
        {
            var dictionary = new ChangeTrackingDictionary<string, int>();

            dictionary.Count.Should().Be(0);
        }

        [Fact]
        public void UseSpecifiedKeyComparer()
        {
            var caseSensitiveDictionary = new ChangeTrackingDictionary<string, int>(keyComparer: StringComparer.Ordinal)
            {
                ["foo"] = 123
            };

            caseSensitiveDictionary.ContainsKey("foo").Should().BeTrue();
            caseSensitiveDictionary.ContainsKey("Foo").Should().BeFalse();

            var caseInsensitiveDictionary = new ChangeTrackingDictionary<string, int>(keyComparer: StringComparer.OrdinalIgnoreCase)
            {
                ["foo"] = 123
            };

            caseInsensitiveDictionary.ContainsKey("foo").Should().BeTrue();
            caseInsensitiveDictionary.ContainsKey("Foo").Should().BeTrue();
        }

        [Fact]
        public void ApplyKeyComparerToExistingData()
        {
            var initialData = new Dictionary<string, int>(StringComparer.Ordinal)
            {
                ["foo"] = 123
            };
            initialData.ContainsKey("Foo").Should().BeFalse();

            var caseInsensitiveDictionary = new ChangeTrackingDictionary<string, int>(
                initialData, StringComparer.OrdinalIgnoreCase);

            caseInsensitiveDictionary.ContainsKey("foo").Should().BeTrue();
            caseInsensitiveDictionary.ContainsKey("Foo").Should().BeTrue();
        }

        [Fact]
        public void SetInitialState()
        {
            var initialData = new Dictionary<string, object>()
            {
                ["foo"] = "bar"
            };
            var dictionary = new ChangeTrackingDictionary<string, object>(initialData, StringComparer.OrdinalIgnoreCase);

            dictionary.ContainsKey("foo").Should().Be(true);
            dictionary["foo"].Should().Be("bar");

            dictionary.ModifiedData.Count.Should().Be(0);
        }

        [Fact]
        public void AllowChanges()
        {
            var dictionary = new ChangeTrackingDictionary<string, object>(keyComparer: StringComparer.OrdinalIgnoreCase);

            dictionary.ContainsKey("foo").Should().Be(false);

            dictionary["foo"] = "bar";

            dictionary["foo"].Should().Be("bar");

            dictionary.ModifiedData.Keys.Should().BeEquivalentTo("foo");
        }

        [Fact]
        public void TrackChanges()
        {
            var initialData = new Dictionary<string, object>()
            {
                ["foo"] = "a",
                ["bar"] = "b"
            };
            var dictionary = new ChangeTrackingDictionary<string, object>(initialData, StringComparer.OrdinalIgnoreCase)
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
            var dictionary = new ChangeTrackingDictionary<string, object>(initialData, StringComparer.OrdinalIgnoreCase)
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
            var dictionary = new ChangeTrackingDictionary<string, object>(initialData, StringComparer.OrdinalIgnoreCase)
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
