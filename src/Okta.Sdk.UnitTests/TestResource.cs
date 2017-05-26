namespace Okta.Sdk.UnitTests
{
    public class TestResource : Resource
    {
        public string Foo => GetStringProperty("foo");

        public string Bar => GetStringProperty("bar");
    }
}
