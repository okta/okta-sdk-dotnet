using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Okta.Core.Models;

namespace Okta.Core.Clients
{
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
