namespace Okta.Sdk.Abstractions
{
    /// <summary>
    /// Represents an RFC 5988 web link.
    /// </summary>
    /// <see>https://tools.ietf.org/html/rfc5988</see>
    public sealed class WebLink
    {
        public string Target { get; set; }

        public string Relation { get; set; }
    }
}
