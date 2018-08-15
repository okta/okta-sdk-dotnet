// <copyright file="DefaultSerializerShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Okta.Sdk.Internal;
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
        public void DeserializeArraysAsLists()
        {
            var json = @"
{
  ""things"": [
    ""foo"", ""bar"", ""baz""
  ]
}";

            var serializer = new DefaultSerializer();
            var dict = serializer.Deserialize(json);

            dict["things"].Should().NotBeNull();

            var things = dict["things"] as IList<object>;
            things.OfType<string>().Should().BeEquivalentTo("foo", "bar", "baz");
        }

        [Fact]
        public void SerializeObject()
        {
            var serializer = new DefaultSerializer();

            var json = serializer.Serialize(new { foo = "bar" });

            json.Should().Be("{\"foo\":\"bar\"}");
        }

        [Fact]
        public void SerializeEnum()
        {
            var serializer = new DefaultSerializer();

            var json = serializer.Serialize(new { test = FactorStatus.Active });

            json.Should().Be("{\"test\":\"ACTIVE\"}");
        }

        [Fact]
        public void SerializeEmptyEnum()
        {
            var serializer = new DefaultSerializer();

            var json = serializer.Serialize(new { test = new FactorStatus(string.Empty) });

            json.Should().Be("{\"test\":\"\"}");
        }

        [Fact]
        public void SerializeNullEnum()
        {
            var serializer = new DefaultSerializer();

            var json = serializer.Serialize(new { test = new FactorStatus(null) });

            json.Should().Be("{\"test\":\"\"}");
        }

        [Fact]
        public void SerializeObjectAndPreserveCase()
        {
            var serializer = new DefaultSerializer();

            var json = serializer.Serialize(new { Foo = "bar" });

            json.Should().Be("{\"Foo\":\"bar\"}");
        }

        [Fact]
        public void SerializeResource()
        {
            var serializer = new DefaultSerializer();
            var user = new User
            {
                Credentials = new UserCredentials
                {
                    Password = new PasswordCredential
                    {
                        Value = "secret",
                    },
                },
            };

            var json = serializer.Serialize(user);

            json.Should().Be("{\"credentials\":{\"password\":{\"value\":\"secret\"}}}");
        }

        [Fact]
        public void SerializeResourceWithCustomProperties()
        {
            var serializer = new DefaultSerializer();
            var profile = new UserProfile
            {
                FirstName = "Foo",
            };
            profile["Custom"] = "Bar";
            var user = new User
            {
                Profile = profile,
            };

            var json = serializer.Serialize(user);

            json.Should().Be("{\"profile\":{\"firstName\":\"Foo\",\"Custom\":\"Bar\"}}");
        }
    }
}
