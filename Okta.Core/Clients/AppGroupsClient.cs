namespace Okta.Core.Clients
{
    using Okta.Core.Models;

    /// <summary>
    /// A client to manage <see cref="App"/>s for a <see cref="Group"/>
    /// </summary>
    public class AppGroupsClient : ApiClient<AppGroup>
    {
        public AppGroupsClient(App app, IOktaHttpClient clientWrapper) : base(clientWrapper, Constants.EndpointV1 + Constants.AppsEndpoint + "/" + app.Id + Constants.GroupsEndpoint) { }
        public AppGroupsClient(App app, OktaSettings oktaSettings) : base(oktaSettings, Constants.EndpointV1 + Constants.AppsEndpoint + "/" + app.Id + Constants.GroupsEndpoint) { }
        public AppGroupsClient(App app, string apiToken, string subdomain) : base(apiToken, subdomain, Constants.EndpointV1 + Constants.AppsEndpoint + "/" + app.Id + Constants.GroupsEndpoint) { }

        public virtual AppGroup Add(Group group)
        {
            return base.Update(group.Id, Constants.EmptyObject);
        }

        public virtual AppGroup Get(AppGroup appGroup)
        {
            return base.Get(appGroup);
        }

        public virtual void Remove(Group group)
        {
            base.Remove(group.Id);
        }
    }
}
