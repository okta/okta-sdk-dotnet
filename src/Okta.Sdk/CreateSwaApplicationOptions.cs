namespace Okta.Sdk
{
    public sealed class CreateSwaApplicationOptions
    {
        public string Label { get; set; }

        public string ButtonField { get; set; }

        public string PasswordField { get; set; }

        public string UsernameField { get; set; }

        public string Url { get; set; }

        public string LoginUrlRegex { get; set; }
    }
}