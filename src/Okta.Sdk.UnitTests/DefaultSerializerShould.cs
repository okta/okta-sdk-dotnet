using FluentAssertions;
using System.Collections.Generic;
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
        public void DeserializeWithCaseInsensitiveKeys()
        {
            var json = @"
{
  ""foo"": ""bar"",
  ""baz"": 123
}";

            var serializer = new DefaultSerializer();
            var dict = serializer.Deserialize(json);

            dict["foo"].Should().Be("bar");
            dict["FOO"].Should().Be("bar");
            dict["BaZ"].Should().Be(123L);
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
    }
}
