using Okta.Sdk.Abstractions;

namespace Okta.Sdk
{
    public sealed class User : Resource
    {
        public User() : base(null) { }

        public User(IDeltaDictionary<string, object> data) : base(data) { }

        public string Id
        {
            get => GetStringProperty(nameof(Id));
            set => SetProperty(nameof(Id), value);
        }

        public string Status
        {
            get => GetStringProperty(nameof(Status));
            set => SetProperty(nameof(Status), value);
        }
    }
}
