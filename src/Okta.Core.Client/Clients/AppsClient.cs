namespace Okta.Core.Clients
{
    using Okta.Core.Models;

    /// <summary>
    /// A client to manage <see cref="App"/>s
    /// </summary>
    public class AppsClient : ApiClient<App>
    {
        public AppsClient(IOktaHttpClient clientWrapper) : base(clientWrapper, Constants.EndpointV1 + Constants.AppsEndpoint) { }
        public AppsClient(OktaSettings oktaSettings) : base(oktaSettings, Constants.EndpointV1 + Constants.AppsEndpoint) { }
        public AppsClient(string apiToken, string subdomain) : base(apiToken, subdomain, Constants.EndpointV1 + Constants.AppsEndpoint) { }

        public virtual App Get(string appId)
        {
            return base.Get(appId);
        }

        public virtual App Add(App app)
        {
            return base.Add(app);
        }

        public virtual AppUser Add(App app, User user)
        {
            return GetAppUsersClient(app).Add(user);
        }

        public virtual AppGroup Add(App app, Group group)
        {
            return GetAppGroupsClient(app).Add(group);
        }

        public virtual App Update(App app)
        {
            return base.Update(app);
        }

        public virtual void Remove(App app)
        {
            base.Remove(app);
        }
            
        public virtual void Remove(App app, User user)
        {
            GetAppUsersClient(app).Remove(user);
        }

        public virtual void Remove(App app, Group group)
        {
            GetAppGroupsClient(app).Remove(group);
        }

        public virtual void Activate(App app)
        {
            PerformLifecycle(app, Constants.LifecycleActivate);
        }

        public virtual void Deactivate(App app)
        {
            PerformLifecycle(app, Constants.LifecycleDeactivate);
        }

        public virtual AppUsersClient GetAppUsersClient(App app)
        {
            return new AppUsersClient(app, BaseClient);
        }

        public virtual AppGroupsClient GetAppGroupsClient(App app)
        {
            return new AppGroupsClient(app, BaseClient);
        }
    }
}
