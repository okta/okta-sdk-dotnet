using FluentAssertions;
using Xunit;

namespace Okta.Sdk.UnitTests
{
    public class ResourceShould
    {
        public class DummyResource : Resource
        {
            public DummyResource Nested => GetProperty<DummyResource>("foobar");
        }

        [Fact]
        public void NotThrowForNullData()
        {
            var resource = new DummyResource();
            resource.Should().NotBeNull();
        }

        [Fact]
        public void NotThrowForNonexistentNestedProperty()
        {
            var resource = new DummyResource();
            resource.Nested.Should().NotBeNull();
        }
    }
}
