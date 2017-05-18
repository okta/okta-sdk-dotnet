// <copyright file="ChangeTrackingDictionaryShould.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class ChangeTrackingDictionaryShould
    {
        [Fact]
        public void CreateEmptyDictionary()
        {
            var dictionary = new DefaultChangeTrackingDictionary();

            dictionary.Count.Should().Be(0);
        }

        [Fact]
        public void UseSpecifiedKeyComparer()
        {
            var caseSensitiveDictionary = new DefaultChangeTrackingDictionary(keyComparer: StringComparer.Ordinal)
            {
                ["foo"] = 123,
            };

            caseSensitiveDictionary.ContainsKey("foo").Should().BeTrue();
            caseSensitiveDictionary.ContainsKey("Foo").Should().BeFalse();

            var caseInsensitiveDictionary = new DefaultChangeTrackingDictionary(keyComparer: StringComparer.OrdinalIgnoreCase)
            {
                ["foo"] = 123,
            };

            caseInsensitiveDictionary.ContainsKey("foo").Should().BeTrue();
            caseInsensitiveDictionary.ContainsKey("Foo").Should().BeTrue();
        }

        [Fact]
        public void ApplyKeyComparerToExistingData()
        {
            var initialData = new Dictionary<string, object>(StringComparer.Ordinal)
            {
                ["foo"] = 123,
            };
            initialData.ContainsKey("Foo").Should().BeFalse();

            var caseInsensitiveDictionary = new DefaultChangeTrackingDictionary(
                initialData, StringComparer.OrdinalIgnoreCase);

            caseInsensitiveDictionary.ContainsKey("foo").Should().BeTrue();
            caseInsensitiveDictionary.ContainsKey("Foo").Should().BeTrue();
        }

        [Fact]
        public void SetInitialState()
        {
            var initialData = new Dictionary<string, object>()
            {
                ["foo"] = "bar",
            };
            var dictionary = new DefaultChangeTrackingDictionary(initialData, StringComparer.OrdinalIgnoreCase);

            dictionary.ContainsKey("foo").Should().Be(true);
            dictionary["foo"].Should().Be("bar");

            (dictionary.Difference as IDictionary<string, object>).Count.Should().Be(0);
        }

        [Fact]
        public void AllowChanges()
        {
            var dictionary = new DefaultChangeTrackingDictionary(keyComparer: StringComparer.OrdinalIgnoreCase);

            dictionary.ContainsKey("foo").Should().Be(false);

            dictionary["foo"] = "bar";

            dictionary["foo"].Should().Be("bar");

            (dictionary.Difference as IDictionary<string, object>).Keys.Should().BeEquivalentTo("foo");
        }

        [Fact]
        public void TrackChanges()
        {
            var initialData = new Dictionary<string, object>()
            {
                ["foo"] = "a",
                ["bar"] = "b",
            };
            var dictionary = new DefaultChangeTrackingDictionary(initialData, StringComparer.OrdinalIgnoreCase)
            {
                ["foo"] = "c",
                ["baz"] = "d",
            };

            dictionary.ContainsKey("foo").Should().Be(true);
            dictionary.ContainsKey("bar").Should().Be(true);
            dictionary.ContainsKey("baz").Should().Be(true);

            dictionary["foo"].Should().Be("c");
            dictionary["bar"].Should().Be("b");
            dictionary["baz"].Should().Be("d");

            (dictionary.Difference as IDictionary<string, object>).Keys.Should().BeEquivalentTo("foo", "baz");
        }

        [Fact]
        public void Reset()
        {
            var initialData = new Dictionary<string, object>()
            {
                ["foo"] = "a",
                ["bar"] = "b",
            };
            var dictionary = new DefaultChangeTrackingDictionary(initialData, StringComparer.OrdinalIgnoreCase)
            {
                ["foo"] = "c",
                ["baz"] = "d",
            };

            (dictionary.Difference as IDictionary<string, object>).Count.Should().Be(2);

            dictionary.Reset();

            (dictionary.Difference as IDictionary<string, object>).Count.Should().Be(0);

            dictionary["foo"].Should().Be("a");
            dictionary["bar"].Should().Be("b");
            dictionary.ContainsKey("baz").Should().Be(false);
        }

        [Fact]
        public void ResetNestedDictionariesToInitialState()
        {
            var dictionary = new DefaultChangeTrackingDictionary(
                new Dictionary<string, object>()
            {
                ["foo"] = 123,
                ["bar"] = new Dictionary<string, object>()
                {
                    ["nested"] = "works",
                },
            }, StringComparer.OrdinalIgnoreCase);

            (dictionary.Difference as IDictionary<string, object>).Count.Should().Be(0);

            dictionary["foo"] = 456;
            ((DefaultChangeTrackingDictionary)dictionary["bar"])["nested"] = 789;

            dictionary.Reset();

            (dictionary.Difference as IDictionary<string, object>).Count.Should().Be(0);

            dictionary["foo"].Should().Be(123);
            ((DefaultChangeTrackingDictionary)dictionary["bar"])["nested"].Should().Be("works");
        }

        [Fact]
        public void TrackChangesToGraph()
        {
            var dictionary = new DefaultChangeTrackingDictionary(
                new Dictionary<string, object>()
            {
                ["foo"] = 123,
                ["bar"] = new Dictionary<string, object>()
                {
                    ["nested"] = "works",
                },
            }, StringComparer.OrdinalIgnoreCase);

            (dictionary.Difference as IDictionary<string, object>).Count.Should().Be(0);

            ((DefaultChangeTrackingDictionary)dictionary["bar"])["nested"] = "is magic!";

            (dictionary.Difference as IDictionary<string, object>).Keys.Should().BeEquivalentTo("bar");

            var bar = (IDictionary<string, object>)(dictionary.Difference as IDictionary<string, object>)["bar"];
            bar.Keys.Should().BeEquivalentTo("nested");
        }

        [Fact]
        public void ResetToGraph()
        {
            var dictionary = new DefaultChangeTrackingDictionary(
                new Dictionary<string, object>()
            {
                ["foo"] = 123,
                ["bar"] = new Dictionary<string, object>()
                {
                    ["nested"] = "works",
                },
            }, StringComparer.OrdinalIgnoreCase);

            ((DefaultChangeTrackingDictionary)dictionary["bar"])["nested"] = "is magic!";
            (dictionary.Difference as IDictionary<string, object>).Count.Should().Be(1);

            dictionary.Reset();
            (dictionary.Difference as IDictionary<string, object>).Count.Should().Be(0);
        }

        [Fact]
        public void MarkParentCleanWhenResettingNested()
        {
            var dictionary = new DefaultChangeTrackingDictionary(
                new Dictionary<string, object>()
            {
                ["foo"] = 123,
                ["bar"] = new Dictionary<string, object>()
                {
                    ["nested"] = "works",
                },
            }, StringComparer.OrdinalIgnoreCase);

            ((DefaultChangeTrackingDictionary)dictionary["bar"])["nested"] = "is magic!";
            (dictionary.Difference as IDictionary<string, object>).Count.Should().Be(1);

            ((DefaultChangeTrackingDictionary)dictionary["bar"]).Reset();
            (dictionary.Difference as IDictionary<string, object>).Count.Should().Be(0);
        }
    }
}
