// <copyright file="DefaultSerializerShould.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class DefaultSerializerShould
    {
        [Fact]
        public void DeserializeDictionaries()
        {
            var json = @"
{
  ""foo"": ""bar"",
  ""baz"": 123
}";

            var serializer = new DefaultSerializer();
            var dict = serializer.Deserialize(json);

            dict["foo"].Should().Be("bar");
            dict["baz"].Should().Be(123L);
        }

        [Fact]
        public void DeserializeNestedDictionaries()
        {
            var json = @"
{
  ""foo"": ""bar"",
  ""baz"": {
    ""qux"": 123
  }
}";

            var serializer = new DefaultSerializer();
            var dict = serializer.Deserialize(json);

            dict["foo"].Should().Be("bar");
            dict["baz"].Should().BeAssignableTo<IReadOnlyDictionary<string, object>>();
            (dict["baz"] as IReadOnlyDictionary<string, object>)["qux"].Should().Be(123L);
        }

        [Fact]
        public void DeserializeNullInput()
        {
            var serializer = new DefaultSerializer();

            var dict = serializer.Deserialize(null);

            dict.Count.Should().Be(0);
        }

        [Fact]
        public void DeserializeEmptyInput()
        {
            var serializer = new DefaultSerializer();

            var dict = serializer.Deserialize(string.Empty);

            dict.Count.Should().Be(0);
        }

        [Fact]
        public void SerializeObject()
        {
            var serializer = new DefaultSerializer();

            var json = serializer.Serialize(new { foo = "bar" });

            json.Should().Be("{\"foo\":\"bar\"}");
        }
    }
}
