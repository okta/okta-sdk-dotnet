using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk
{
    public sealed class CreateSwaNoPluginApplicationOptions
    {
        public string Label { get; set; }

        public string Url { get; set; }

        public string PasswordField { get; set; }

        public string UsernameField { get; set; }

        public string OptionalField1 { get; set; }

        public string OptionalField1Value { get; set; }

        public string OptionalField2 { get; set; }

        public string OptionalField2Value { get; set; }

        public string OptionalField3 { get; set; }

        public string OptionalField3Value { get; set; }

        public bool Activate { get; set; } = true;

    }
}
