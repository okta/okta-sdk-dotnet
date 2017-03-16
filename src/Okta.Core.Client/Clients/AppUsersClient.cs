namespace Okta.Core.Clients
{
    using Okta.Core.Models;

    /// <summary>
    /// A client to manage <see cref="User"/>s of an <see cref="App"/>
    /// </summary>
    public class AppUsersClient : ApiClient<AppUser>
    {
        public AppUsersClient(App app, IOktaHttpClient clientWrapper) : base(clientWrapper, Constants.EndpointV1 + Constants.AppsEndpoint + "/" + app.Id + Constants.UsersEndpoint) { }
        public AppUsersClient(App app, OktaSettings oktaSettings) : base(oktaSettings, Constants.EndpointV1 + Constants.AppsEndpoint + "/" + app.Id + Constants.UsersEndpoint) { }
        public AppUsersClient(App app, string apiToken, string subdomain) : base(apiToken, subdomain, Constants.EndpointV1 + Constants.AppsEndpoint + "/" + app.Id + Constants.UsersEndpoint) { }

        public virtual AppUser Add(User user)
        {
            return Add(user.Id, Constants.EmptyObject);
        }

        public virtual AppUser Add(string userId)
        {
            return base.Update(userId, Constants.EmptyObject);
        }

        public virtual AppUser Get(AppUser appUser)
        {
            return base.Get(appUser);
        }

        public virtual void Remove(User user)
        {
            base.Remove(user.Id);
        }
    }
}
