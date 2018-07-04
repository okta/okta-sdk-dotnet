using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk
{
    public sealed class CreateSwaCustomApplicationOptions
    {
        public string Label { get; set; }

        public bool AutoSubmitToolbar { get; set; } = false;

        public bool HideIOs { get; set; } = false;

        public bool HideWeb { get; set; } = false;

        public string RedirectUrl { get; set; }

        public string LoginUrl { get; set; }

        public IList<string> Features { get; set; }

        public bool Activate { get; set; } = true;
    }
}
