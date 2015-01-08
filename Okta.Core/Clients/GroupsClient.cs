using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Okta.Core.Models;

namespace Okta.Core.Clients
{
    /// <summary>
    /// A client to manage <see cref="Group"/>s
    /// </summary>
    public class GroupsClient : ApiClient<Group>
    {
        public GroupsClient(IOktaHttpClient clientWrapper) : base(clientWrapper, Constants.EndpointV1 + Constants.GroupsEndpoint) { }
        public GroupsClient(OktaSettings oktaSettings) : base(oktaSettings, Constants.EndpointV1 + Constants.GroupsEndpoint) { }
        public GroupsClient(string apiToken, string subdomain) : base(apiToken, subdomain, Constants.EndpointV1 + Constants.GroupsEndpoint) { }

        public Group Add(Group group)
        {
            return base.Add(group);
        }

        public Group Get(Group group)
        {
            return base.Get(group);
        }

        public Group Get(string groupId)
        {
            return base.Get(groupId);
        }

        public Group Update(Group group)
        {
            return base.Update(group);
        }

        public void Remove(Group group)
        {
            base.Remove(group);
        }

        public void Remove(string groupId)
        {
            base.Remove(groupId);
        }

        public GroupUsersClient GetGroupUsersClient(Group group)
        {
            return new GroupUsersClient(group, BaseClient);
        }
    }
}