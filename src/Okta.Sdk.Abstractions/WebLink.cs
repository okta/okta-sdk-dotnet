namespace Okta.Sdk.Abstractions
{
    /// <summary>
    /// Represents an RFC 5988 web link.
    /// </summary>
    /// <see>https://tools.ietf.org/html/rfc5988</see>
    public struct WebLink
    {
        public WebLink(string target, string relation)
        {
            Target = target;
            Relation = relation;
        }

        public string Target { get; }

        public string Relation { get; }
    }
}
