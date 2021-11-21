// <copyright file="ResourceSerializingConverterShould.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Okta.Sdk.Internal;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class ResourceSerializingConverterShould
    {
        [Fact]
        public void KeepNullPropertiesInSerializationUserProfile()
        {
            var user = new User()
            {
                Profile = new UserProfile()
                {
                    FirstName = "John",
                },
            };

            user.Profile["foo"] = "fooValue";
            user.Profile["bar"] = null;
            user.Profile["baz"] = new List<string>() { "1", "2" };

            var serializer = new DefaultSerializer();
            var serializedUser = serializer.Serialize(user);

            serializedUser.Trim().Should().Contain("\"foo\":\"fooValue\"");
            serializedUser.Trim().Should().Contain("\"bar\":");
            serializedUser.Trim().Should().Contain("\"baz\":[\"1\",\"2\"]");
        }

        [Fact]
        public void RemoveNullPropertiesInSerialization()
        {
            var user = new Application()
            {
                Profile = new Resource(),
            };

            user.Profile["foo"] = "fooValue";
            user.Profile["bar"] = null;
            user.Profile["baz"] = new List<string>() { "1", "2" };

            var serializer = new DefaultSerializer();
            var serializedUser = serializer.Serialize(user);

            serializedUser.Trim().Should().Contain("\"foo\":\"fooValue\"");
            serializedUser.Trim().Should().NotContain("\"bar\":");
            serializedUser.Trim().Should().Contain("\"baz\":[\"1\",\"2\"]");
        }

        [Fact]
        public void AllowEmptyArraysInSerialization()
        {
            var user = new User()
            {
                Profile = new UserProfile()
                {
                    FirstName = "John",
                },
            };

            user.Profile["foo"] = "fooValue";
            user.Profile["baz"] = new List<string>();

            var serializer = new DefaultSerializer();
            var serializedUser = serializer.Serialize(user);

            serializedUser.Trim().Should().Contain("\"foo\":\"fooValue\"");
            serializedUser.Trim().Should().Contain("\"baz\":[]");
        }
    }
}
