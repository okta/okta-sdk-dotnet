// <copyright file="ResourceShould.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using FluentAssertions;
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

            var resource = new TestResource();
            resource.Initialize(data);

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
            var resource = new Resource();
            resource.Initialize(data);

            resource.GetStringProperty("foo").Should().Be("abc");
            resource.GetStringProperty("empty").Should().Be(string.Empty);
            resource.GetStringProperty("nothing").Should().BeNull();
            resource.GetStringProperty("reallyNothing").Should().BeNull();
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
            var resource = new Resource();
            resource.Initialize(data);

            resource.GetBooleanProperty("yes").Should().BeTrue();
            resource.GetBooleanProperty("no").Should().BeFalse();
            resource.GetBooleanProperty("nothing").Should().BeNull();
            resource.GetBooleanProperty("reallyNothing").Should().BeNull();
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
            var resource = new Resource();
            resource.Initialize(data);

            resource.GetIntProperty("min").Should().Be(int.MinValue);
            resource.GetIntProperty("max").Should().Be(int.MaxValue);
            resource.GetIntProperty("nothing").Should().BeNull();
            resource.GetIntProperty("reallyNothing").Should().BeNull();
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
            var resource = new Resource();
            resource.Initialize(data);

            resource.GetLongProperty("min").Should().Be(long.MinValue);
            resource.GetLongProperty("max").Should().Be(long.MaxValue);
            resource.GetLongProperty("nothing").Should().BeNull();
            resource.GetLongProperty("reallyNothing").Should().BeNull();
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
            var resource = new Resource();
            resource.Initialize(data);

            resource.GetDateTimeProperty("dto").Should().Be(new DateTimeOffset(2015, 12, 27, 20, 15, 00, TimeSpan.FromHours(-6)));
            resource.GetDateTimeProperty("iso").Should().Be(new DateTimeOffset(2016, 11, 6, 17, 05, 30, 400, TimeSpan.FromHours(-8)));
            resource.GetDateTimeProperty("nothing").Should().BeNull();
            resource.GetDateTimeProperty("reallyNothing").Should().BeNull();
        }

        [Fact]
        public void TrackInstanceModifications()
        {
            var resource = new TestResource()
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
