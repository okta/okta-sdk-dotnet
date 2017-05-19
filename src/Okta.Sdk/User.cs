using Okta.Sdk.Abstractions;
using System.Collections.Generic;

namespace Okta.Sdk
{
    public sealed class User : AbstractResource
    {
        public User() : base(null, null)
        {
            // In new-only mode
            // TODO - does this make sense?
        }

        public User(IReadOnlyDictionary<string, object> data, IResourceFactory resourceFactory)
                : base(data, resourceFactory)
            { }

        public string Id
        {
            get => GetString(nameof(Id));
            set => SetValue(nameof(Id), value);
        }

        public string Status
        {
            get => GetString(nameof(Status));
            set => SetValue(nameof(Status), value);
        }
    }
}
