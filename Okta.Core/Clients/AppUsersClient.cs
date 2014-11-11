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
    /// A client to manage <see cref="User"/>s of an <see cref="App"/>
    /// </summary>
    public class AppUsersClient : ApiClient<AppUser>
    {
        public AppUsersClient(App app, IOktaHttpClient clientWrapper) : base(clientWrapper, Constants.EndpointV1 + Constants.AppsEndpoint + "/" + app.Id + Constants.UsersEndpoint) { }
        public AppUsersClient(App app, OktaSettings oktaSettings) : base(oktaSettings, Constants.EndpointV1 + Constants.AppsEndpoint + "/" + app.Id + Constants.UsersEndpoint) { }
        public AppUsersClient(App app, string apiToken, string subdomain) : base(apiToken, subdomain, Constants.EndpointV1 + Constants.AppsEndpoint + "/" + app.Id + Constants.UsersEndpoint) { }

        public AppUser Add(User user)
        {
            return base.Update(user.Id, Constants.EmptyObject);
        }

        public AppUser Get(AppUser appUser)
        {
            return base.Get(appUser);
        }

        public void Remove(User user)
        {
            base.Remove(user.Id);
        }
    }
}
