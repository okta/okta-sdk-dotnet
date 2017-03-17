namespace Okta.Core.Clients
{
    using Okta.Core.Models;

    /// <summary>
    /// A client to manage <see cref="Group"/>s for a <see cref="User"/>
    /// </summary>
    public class UserGroupsClient : ApiClient<Group>
    {
        public UserGroupsClient(User user, IOktaHttpClient clientWrapper) : base(clientWrapper, Constants.EndpointV1 + Constants.UsersEndpoint + "/" + user.Id + Constants.GroupsEndpoint) { }
        public UserGroupsClient(User user, OktaSettings oktaSettings) : base(oktaSettings, Constants.EndpointV1 + Constants.UsersEndpoint + "/" + user.Id + Constants.GroupsEndpoint) { }
        public UserGroupsClient(User user, string apiToken, string subdomain) : base(apiToken, subdomain, Constants.EndpointV1 + Constants.UsersEndpoint + "/" + user.Id + Constants.GroupsEndpoint) { }
    }
}