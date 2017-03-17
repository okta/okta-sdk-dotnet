namespace Okta.Core.Clients
{
    using Okta.Core.Models;

    /// <summary>
    /// A client to manage <see cref="Group"/>s
    /// </summary>
    public class GroupsClient : ApiClient<Group>
    {
        public GroupsClient(IOktaHttpClient clientWrapper) : base(clientWrapper, Constants.EndpointV1 + Constants.GroupsEndpoint) { }
        public GroupsClient(OktaSettings oktaSettings) : base(oktaSettings, Constants.EndpointV1 + Constants.GroupsEndpoint) { }
        public GroupsClient(string apiToken, string subdomain) : base(apiToken, subdomain, Constants.EndpointV1 + Constants.GroupsEndpoint) { }

        public virtual Group Add(Group group)
        {
            return base.Add(group);
        }

        public virtual Group Get(Group group)
        {
            return base.Get(group);
        }

        public virtual Group Get(string groupId)
        {
            return base.Get(groupId);
        }

        public virtual Group GetByName(string groupName)
        {
            Group g = null;
            PagedResults<Group> groups = this.GetList(query: groupName);
            if (groups.Results != null && groups.Results.Count > 0)
            {
                g = groups.Results[0];
            }
            return g;
        }

        public virtual Group Update(Group group)
        {
            return base.Update(group);
        }

        public virtual void Remove(Group group)
        {
            base.Remove(group);
        }

        public virtual void Remove(string groupId)
        {
            base.Remove(groupId);
        }

        public virtual GroupUsersClient GetGroupUsersClient(Group group)
        {
            return new GroupUsersClient(group, BaseClient);
        }
    }
}