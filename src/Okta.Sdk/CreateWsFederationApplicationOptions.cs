using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk
{
    public sealed class CreateWsFederationApplicationOptions
    {
        public string Label { get; set; }

        public bool Activate { get; set; } = true;

        public string AudienceRestriction { get; set; }

        public string GroupName { get; set; }

        public string GroupValueFormat { get; set; }

        public string Realm { get; set; }

        public string WReplyUrl { get; set; }

        public string AttributeStatements { get; set; }

        public string NameIdFormat { get; set; }

        public string AuthenticationContextClassName { get; set; }

        public string SiteUrl { get; set; }

        public bool WReplyOverride { get; set; }

        public string GroupFilter { get; set; }

        public string UsernameAttribute { get; set; }

    }
}
