using Okta.Sdk.Abstractions;
using System.Collections.Generic;

namespace Okta.Sdk.UnitTests
{
    public class TestListResource : TestResource
    {
        public TestListResource() : base(null) { }
        public TestListResource(IChangeTrackingDictionary<string, object> data) : base(data) { }

        public IList<string> Strings
        {
            get => GetListProperty<string>("strings");
            set => SetProperty("strings", value);
        }

        public IList<TestResource> Things
        {
            get => GetListProperty<TestResource>("things");
            set => SetProperty("things", value);
        }
    }
}
