namespace Okta.Sdk
{
    public sealed class CreateBookmarkApplicationOptions
    {
        public string Label { get; set; }

        public bool RequestIntegration { get; set; } = false;

        public string Url { get; set; }
    }
}
