namespace Okta.Sdk.Abstractions
{
    public sealed class CacheManagerConfiguration
    {
        public bool? Enabled { get; set; } = true;

        public int? DefaultTtl { get; set; } = 300; // Seconds

        public int? DefaultTti { get; set; } = 300; // Seconds

        // TODO - Caches
    }
}