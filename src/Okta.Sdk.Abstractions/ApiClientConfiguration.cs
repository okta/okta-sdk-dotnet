namespace Okta.Sdk.Abstractions
{
    public sealed class ApiClientConfiguration
    {
        public CacheManagerConfiguration CacheManager { get; set; }

        public int? ConnectionTimeout { get; set; } = 30; // Seconds

        public string OrgUrl { get; set; }

        public ProxyConfiguration Proxy { get; set; }

        public string Token { get; set; }
    }
}
