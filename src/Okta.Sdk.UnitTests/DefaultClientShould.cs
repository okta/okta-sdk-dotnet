// <copyright file="DefaultClientShould.cs" company="Okta, Inc">
// Copyright (c) 2014-2017 Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class DefaultClientShould
    {
        [Fact]
        public async Task GetResource()
        {
            var mockRequestExecutor = new MockedStringRequestExecutor(@"{ ""foo"": ""bar"" }");
            var dataStore = new DefaultDataStore(
                mockRequestExecutor,
                new DefaultSerializer());

            var client = new OktaClient(dataStore);

            var resource = await client.GetAsync<TestResource>("http://foobar");
            resource.Foo.Should().Be("bar");
        }
    }
}
