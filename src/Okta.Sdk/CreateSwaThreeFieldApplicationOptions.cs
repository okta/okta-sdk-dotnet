namespace Okta.Sdk
{
    public sealed class CreateSwaThreeFieldApplicationOptions
    {
        public string Label { get; set; }

        public string ButtonSelector { get; set; }

        public string PasswordSelector { get; set; }

        public string UserNameSelector { get; set; }

        public string TargetUrl { get; set; }

        public string ExtraFieldSelector { get; set; }

        public string ExtraFieldValue { get; set; }

        public string LoginUrlRegex { get; set; }
    }
}
