namespace Okta.Core.Clients
{
    using Okta.Core.Models;

    /// <summary>
    /// A client to manage <see cref="AppLink"/>s for a <see cref="User"/>
    /// </summary>
    public class UserAppLinksClient : ApiClient<AppLink>
    {
        public UserAppLinksClient(User user, IOktaHttpClient clientWrapper) : base(clientWrapper, Constants.EndpointV1 + Constants.UsersEndpoint + "/" + user.Id + Constants.AppLinksEndpoint) { }
        public UserAppLinksClient(User user, OktaSettings oktaSettings) : base(oktaSettings, Constants.EndpointV1 + Constants.UsersEndpoint + "/" + user.Id + Constants.AppLinksEndpoint) { }
        public UserAppLinksClient(User user, string apiToken, string subdomain) : base(apiToken, subdomain, Constants.EndpointV1 + Constants.UsersEndpoint + "/" + user.Id + Constants.AppLinksEndpoint) { }
    }
}
