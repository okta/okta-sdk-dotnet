using Okta.Sdk.Abstractions;

namespace Okta.Sdk.UnitTests
{
    public class TestResource : Resource
    {
        public TestResource() : base(null) { }

        public TestResource(IChangeTrackingDictionary<string, object> data) : base(data) { }

        public string Foo
        {
            get => GetStringProperty("foo");
            set => SetProperty("foo", value);
        }

        public bool? Bar
        {
            get => GetBooleanProperty("bar");
            set => SetProperty("bar", value);
        }
    }
}
