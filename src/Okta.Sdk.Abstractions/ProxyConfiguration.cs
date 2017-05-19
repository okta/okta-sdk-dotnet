namespace Okta.Sdk.Abstractions
{
    public sealed class ProxyConfiguration
    {
        public int? Port { get; set; }

        public string Host { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}