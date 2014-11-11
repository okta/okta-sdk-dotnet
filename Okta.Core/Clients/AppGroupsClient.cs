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
    /// A client to manage <see cref="App"/>s for a <see cref="Group"/>
    /// </summary>
    public class AppGroupsClient : ApiClient<AppGroup>
    {
        public AppGroupsClient(App app, IOktaHttpClient clientWrapper) : base(clientWrapper, Constants.EndpointV1 + Constants.AppsEndpoint + "/" + app.Id + Constants.GroupsEndpoint) { }
        public AppGroupsClient(App app, OktaSettings oktaSettings) : base(oktaSettings, Constants.EndpointV1 + Constants.AppsEndpoint + "/" + app.Id + Constants.GroupsEndpoint) { }
        public AppGroupsClient(App app, string apiToken, string subdomain) : base(apiToken, subdomain, Constants.EndpointV1 + Constants.AppsEndpoint + "/" + app.Id + Constants.GroupsEndpoint) { }

        public AppGroup Add(Group group)
        {
            return base.Update(group.Id, Constants.EmptyObject);
        }

        public AppGroup Get(AppGroup appGroup)
        {
            return base.Get(appGroup);
        }

        public void Remove(Group group)
        {
            base.Remove(group.Id);
        }
    }
}
