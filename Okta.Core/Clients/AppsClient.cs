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
    /// A client to manage <see cref="App"/>s
    /// </summary>
    public class AppsClient : ApiClient<App>
    {
        public AppsClient(IOktaHttpClient clientWrapper) : base(clientWrapper, Constants.EndpointV1 + Constants.AppsEndpoint) { }
        public AppsClient(OktaSettings oktaSettings) : base(oktaSettings, Constants.EndpointV1 + Constants.AppsEndpoint) { }
        public AppsClient(string apiToken, string subdomain) : base(apiToken, subdomain, Constants.EndpointV1 + Constants.AppsEndpoint) { }

        public App Add(App app)
        {
            return base.Add(app);
        }

        public AppUser Add(App app, User user)
        {
            return GetAppUsersClient(app).Add(user);
        }

        public AppGroup Add(App app, Group group)
        {
            return GetAppGroupsClient(app).Add(group);
        }

        public App Update(App app)
        {
            return base.Update(app);
        }

        public void Remove(App app)
        {
            base.Remove(app);
        }
            
        public void Remove(App app, User user)
        {
            GetAppUsersClient(app).Remove(user);
        }

        public void Remove(App app, Group group)
        {
            GetAppGroupsClient(app).Remove(group);
        }

        public void Activate(App app)
        {
            PerformLifecycle(app, Constants.LifecycleActivate);
        }

        public void Deactivate(App app)
        {
            PerformLifecycle(app, Constants.LifecycleDeactivate);
        }

        public AppUsersClient GetAppUsersClient(App app)
        {
            return new AppUsersClient(app, BaseClient);
        }

        public AppGroupsClient GetAppGroupsClient(App app)
        {
            return new AppGroupsClient(app, BaseClient);
        }
    }
}
