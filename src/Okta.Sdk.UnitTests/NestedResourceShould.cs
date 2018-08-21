// <copyright file="NestedResourceShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using FluentAssertions;
using Okta.Sdk.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class NestedResourceShould
    {
        [Fact]
        public void NotThrowForNonexistentNestedProperty()
        {
            var resource = new TestNestedResource();
            resource.Nested.Should().NotBeNull();
        }

        [Fact]
        public void AccessNestedProperties()
        {
            var data = new Dictionary<string, object>()
            {
                ["foo"] = "abc",
                ["bar"] = true,
                ["nested"] = new Dictionary<string, object>()
                {
                    ["foo"] = "nested is neet!",
                    ["bar"] = false,
                },
            };

            var factory = new ResourceFactory(null, null);
            var resource = factory.CreateNew<TestNestedResource>(data);

            resource.Should().NotBeNull();
            resource.Foo.Should().Be("abc");
            resource.Bar.Should().Be(true);

            resource.Nested.Should().NotBeNull();
            resource.Nested.Foo.Should().Be("nested is neet!");
            resource.Nested.Bar.Should().Be(false);
        }

        [Fact]
        public void TrackNestedModifications()
        {
            var data = new Dictionary<string, object>()
            {
                ["foo"] = "abc",
                ["bar"] = true,
                ["nested"] = new Dictionary<string, object>()
                {
                    ["foo"] = "nested is neet!",
                    ["Bar"] = false,
                },
            };
            var factory = new ResourceFactory(null, null);
            var resource = factory.CreateNew<TestNestedResource>(data);

            resource.Nested.Bar = true;
            resource.Nested.GetData().Should().Contain(new KeyValuePair<string, object>("bar", true));
        }

        [Fact]
        public void InstantiateGraphWithModifications()
        {
            var resource = new TestNestedResource()
            {
                Nested = new TestNestedResource()
                {
                    Foo = "turtles all the way down?",
                },
            };

            resource.GetData().Keys.Should().BeEquivalentTo("nested");
            resource.Nested.GetData().Keys.Should().BeEquivalentTo("foo");
        }
    }
}
