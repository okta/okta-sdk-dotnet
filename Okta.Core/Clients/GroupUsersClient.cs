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
    /// A client to manage <see cref="User"/>s in a <see cref="Group"/>
    /// </summary>
    public class GroupUsersClient : ApiClient<User>
    {
        public GroupUsersClient(Group group, IOktaHttpClient clientWrapper) : base(clientWrapper, Constants.EndpointV1 + Constants.GroupsEndpoint + "/" + group.Id + Constants.UsersEndpoint) { }
        public GroupUsersClient(Group group, OktaSettings oktaSettings) : base(oktaSettings, Constants.EndpointV1 + Constants.GroupsEndpoint + "/" + group.Id + Constants.UsersEndpoint) { }
        public GroupUsersClient(Group group, string apiToken, string subdomain) : base(apiToken, subdomain, Constants.EndpointV1 + Constants.GroupsEndpoint + "/" + group.Id + Constants.UsersEndpoint) { }

        public User Add(User oktaObject)
        {
            var result = BaseClient.Put(resourcePath + "/" + oktaObject.Id, null);
            return oktaObject;
        }

        public void Remove(User oktaObject)
        {
            BaseClient.Delete(resourcePath + "/" + oktaObject.Id);
        }
    }
}
