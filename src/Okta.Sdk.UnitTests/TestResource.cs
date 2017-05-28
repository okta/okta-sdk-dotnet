namespace Okta.Sdk.UnitTests
{
    public class TestResource : Resource
    {
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
