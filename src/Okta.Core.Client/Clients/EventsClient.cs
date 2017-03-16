namespace Okta.Core.Clients
{
    using Okta.Core.Models;

    /// <summary>
    /// A client to list and query <see cref="Event"/>s
    /// </summary>
    public class EventsClient : ApiClient<Event>
    {
        public EventsClient(IOktaHttpClient clientWrapper) : base(clientWrapper, Constants.EndpointV1 + Constants.EventsEndpoint) { }
        public EventsClient(OktaSettings oktaSettings) : base(oktaSettings, Constants.EndpointV1 + Constants.EventsEndpoint) { }
        public EventsClient(string apiToken, string subdomain) : base(apiToken, subdomain, Constants.EndpointV1 + Constants.EventsEndpoint) { }
    }
}
