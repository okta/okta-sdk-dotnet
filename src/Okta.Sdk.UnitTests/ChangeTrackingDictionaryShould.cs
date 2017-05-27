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
            var dictionary = new ChangeTrackingDictionary();

            dictionary.Count.Should().Be(0);
        }

        [Fact]
        public void UseSpecifiedKeyComparer()
        {
            var caseSensitiveDictionary = new ChangeTrackingDictionary(keyComparer: StringComparer.Ordinal)
            {
                ["foo"] = 123
            };

            caseSensitiveDictionary.ContainsKey("foo").Should().BeTrue();
            caseSensitiveDictionary.ContainsKey("Foo").Should().BeFalse();

            var caseInsensitiveDictionary = new ChangeTrackingDictionary(keyComparer: StringComparer.OrdinalIgnoreCase)
            {
                ["foo"] = 123
            };

            caseInsensitiveDictionary.ContainsKey("foo").Should().BeTrue();
            caseInsensitiveDictionary.ContainsKey("Foo").Should().BeTrue();
        }

        [Fact]
        public void ApplyKeyComparerToExistingData()
        {
            var initialData = new Dictionary<string, object>(StringComparer.Ordinal)
            {
                ["foo"] = 123
            };
            initialData.ContainsKey("Foo").Should().BeFalse();

            var caseInsensitiveDictionary = new ChangeTrackingDictionary(
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
            var dictionary = new ChangeTrackingDictionary(initialData, StringComparer.OrdinalIgnoreCase);

            dictionary.ContainsKey("foo").Should().Be(true);
            dictionary["foo"].Should().Be("bar");

            dictionary.ModifiedData.Count.Should().Be(0);
        }

        [Fact]
        public void AllowChanges()
        {
            var dictionary = new ChangeTrackingDictionary(keyComparer: StringComparer.OrdinalIgnoreCase);

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
            var dictionary = new ChangeTrackingDictionary(initialData, StringComparer.OrdinalIgnoreCase)
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
            var dictionary = new ChangeTrackingDictionary(initialData, StringComparer.OrdinalIgnoreCase)
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
        public void ResetNestedDictionariesToInitialState()
        {
            var dictionary = new ChangeTrackingDictionary(new Dictionary<string, object>()
            {
                ["foo"] = 123,
                ["bar"] = new Dictionary<string, object>()
                {
                    ["nested"] = "works"
                }
            }, StringComparer.OrdinalIgnoreCase);

            dictionary.ModifiedData.Count.Should().Be(0);

            dictionary["foo"] = 456;
            ((ChangeTrackingDictionary)dictionary["bar"])["nested"] = 789;

            dictionary.ResetChanges();

            dictionary.ModifiedData.Count.Should().Be(0);

            dictionary["foo"].Should().Be(123);
            ((ChangeTrackingDictionary)dictionary["bar"])["nested"].Should().Be("works");
        }

        [Fact]
        public void TrackChangesToGraph()
        {
            var dictionary = new ChangeTrackingDictionary(new Dictionary<string, object>()
            {
                ["foo"] = 123,
                ["bar"] = new Dictionary<string, object>()
                {
                    ["nested"] = "works"
                }
            }, StringComparer.OrdinalIgnoreCase);

            dictionary.ModifiedData.Count.Should().Be(0);

            ((ChangeTrackingDictionary)dictionary["bar"])["nested"] = "is magic!";

            dictionary.ModifiedData.Keys.Should().BeEquivalentTo("bar");
            ((IDictionary<string, object>)dictionary.ModifiedData["bar"]).Keys.Should().BeEquivalentTo("nested");
        }

        [Fact]
        public void ResetChangesToGraph()
        {
            var dictionary = new ChangeTrackingDictionary(new Dictionary<string, object>()
            {
                ["foo"] = 123,
                ["bar"] = new Dictionary<string, object>()
                {
                    ["nested"] = "works"
                }
            }, StringComparer.OrdinalIgnoreCase);

            ((ChangeTrackingDictionary)dictionary["bar"])["nested"] = "is magic!";
            dictionary.ModifiedData.Count.Should().Be(1);

            dictionary.ResetChanges();
            dictionary.ModifiedData.Count.Should().Be(0);
        }

        [Fact]
        public void MarkParentCleanWhenResettingNested()
        {
            var dictionary = new ChangeTrackingDictionary(new Dictionary<string, object>()
            {
                ["foo"] = 123,
                ["bar"] = new Dictionary<string, object>()
                {
                    ["nested"] = "works"
                }
            }, StringComparer.OrdinalIgnoreCase);

            ((ChangeTrackingDictionary)dictionary["bar"])["nested"] = "is magic!";
            dictionary.ModifiedData.Count.Should().Be(1);

            ((ChangeTrackingDictionary)dictionary["bar"]).ResetChanges();
            dictionary.ModifiedData.Count.Should().Be(0);
        }
    }
}
