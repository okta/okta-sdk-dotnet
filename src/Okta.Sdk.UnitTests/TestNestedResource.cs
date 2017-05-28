using Okta.Sdk.Abstractions;

namespace Okta.Sdk.UnitTests
{
    public class TestNestedResource : TestResource
    {
        public TestNestedResource() : base(null) { }
        public TestNestedResource(IDeltaDictionary<string, object> data) : base(data) { }

        public TestNestedResource Nested
        {
            get => GetProperty<TestNestedResource>("nested");
            set => SetResourceProperty("nested", value);
        }
    }
}
