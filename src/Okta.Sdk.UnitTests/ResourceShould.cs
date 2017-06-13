// <copyright file="ResourceShould.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using FluentAssertions;
using Okta.Sdk.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class ResourceShould
    {
        [Fact]
        public void NotThrowForNullData()
        {
            var resource = new Resource();

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
            var data = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
            {
                ["Foo"] = "bar!",
                ["bar"] = true,
            };

            var factory = new ResourceFactory();
            var resource = factory.CreateNew<TestResource>(data);

            resource.Foo.Should().Be("bar!");
            resource.Bar.Should().Be(true);
        }

        [Fact]
        public void AccessStringProperty()
        {
            var data = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
            {
                ["foo"] = "abc",
                ["empty"] = string.Empty,
                ["nothing"] = null,
            };

            var factory = new ResourceFactory();
            var resource = factory.CreateNew<Resource>(data);

            resource.GetProperty<string>("foo").Should().Be("abc");
            resource.GetProperty<string>("empty").Should().Be(string.Empty);
            resource.GetProperty<string>("nothing").Should().BeNull();
            resource.GetProperty<string>("reallyNothing").Should().BeNull();
        }

        [Fact]
        public void AccessBooleanProperty()
        {
            var data = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
            {
                ["yes"] = true,
                ["no"] = false,
                ["nothing"] = null,
            };

            var factory = new ResourceFactory();
            var resource = factory.CreateNew<Resource>(data);

            resource.GetProperty<bool?>("yes").Should().BeTrue();
            resource.GetProperty<bool?>("no").Should().BeFalse();
            resource.GetProperty<bool?>("nothing").Should().BeNull();
            resource.GetProperty<bool?>("reallyNothing").Should().BeNull();
        }

        [Fact]
        public void AccessIntProperty()
        {
            var data = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
            {
                ["min"] = int.MinValue,
                ["max"] = int.MaxValue,
                ["nothing"] = null,
            };

            var factory = new ResourceFactory();
            var resource = factory.CreateNew<Resource>(data);

            resource.GetProperty<int?>("min").Should().Be(int.MinValue);
            resource.GetProperty<int?>("max").Should().Be(int.MaxValue);
            resource.GetProperty<int?>("nothing").Should().BeNull();
            resource.GetProperty<int?>("reallyNothing").Should().BeNull();
        }

        [Fact]
        public void AccessLongProperty()
        {
            var data = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
            {
                ["min"] = long.MinValue,
                ["max"] = long.MaxValue,
                ["nothing"] = null,
            };

            var factory = new ResourceFactory();
            var resource = factory.CreateNew<Resource>(data);

            resource.GetProperty<long?>("min").Should().Be(long.MinValue);
            resource.GetProperty<long?>("max").Should().Be(long.MaxValue);
            resource.GetProperty<long?>("nothing").Should().BeNull();
            resource.GetProperty<long?>("reallyNothing").Should().BeNull();
        }

        [Fact]
        public void AccessDateTimeProperty()
        {
            var data = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
            {
                ["dto"] = new DateTimeOffset(2015, 12, 27, 20, 15, 00, TimeSpan.FromHours(-6)),
                ["iso"] = "2016-11-06T17:05:30.400-08:00",
                ["nothing"] = null,
            };

            var factory = new ResourceFactory();
            var resource = factory.CreateNew<Resource>(data);

            resource.GetProperty<DateTimeOffset?>("dto").Should().Be(new DateTimeOffset(2015, 12, 27, 20, 15, 00, TimeSpan.FromHours(-6)));
            resource.GetProperty<DateTimeOffset?>("iso").Should().Be(new DateTimeOffset(2016, 11, 6, 17, 05, 30, 400, TimeSpan.FromHours(-8)));
            resource.GetProperty<DateTimeOffset?>("nothing").Should().BeNull();
            resource.GetProperty<DateTimeOffset?>("reallyNothing").Should().BeNull();
        }

        [Fact]
        public void AccessListProperty()
        {
            var data = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase)
            {
                ["things"] = new List<object>() { "foo", "bar", "baz" },
            };

            var factory = new ResourceFactory();
            var resource = factory.CreateNew<Resource>(data);

            var things = resource.GetArrayProperty<string>("things");
            things.Should().BeEquivalentTo("foo", "bar", "baz");
        }

        [Fact]
        public void TrackInstanceModifications()
        {
            var resource = new TestResource() // has DictionaryType.ChangeTracking
            {
                Foo = "xyz",
            };

            resource.GetModifiedData().Keys.Should().BeEquivalentTo("foo");

            resource.Bar = true;

            resource.GetModifiedData().Count.Should().Be(2);
            resource.GetModifiedData().Should().Contain(new KeyValuePair<string, object>("foo", "xyz"));
            resource.GetModifiedData().Should().Contain(new KeyValuePair<string, object>("bar", true));
        }
    }
}
