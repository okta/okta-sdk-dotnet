using FluentAssertions;
using Okta.Sdk.Abstractions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class ListResourceShould
    {
        [Fact]
        public void foo()
        {
            //var data = new Dictionary<string, object>()
            //{
            //    ["foo"] = "bar",
            //    ["strings"] = new List<string>() { "abc", "xyz" },
            //    ["things"] = new List<TestResource>()
            //    {
            //        new TestResource { Foo = "one" },
            //        new TestResource { Foo = "two" }
            //    }
            //};
            //var changeTrackingDictionary = new DefaultChangeTrackingDictionary(data, StringComparer.OrdinalIgnoreCase);
            //var resource = new TestListResource(changeTrackingDictionary);

            //// test a list of primitives
            //resource.Strings.Should().BeEquivalentTo("abc", "xyz");
            //resource.GetModifiedData().Count.Should().Be(0);
            //resource.Strings = new List<string>() { "foobar" };
            //resource.GetModifiedData().Count.Should().Be(1);
            //resource.Strings.Add("123");

        }
    }
}
