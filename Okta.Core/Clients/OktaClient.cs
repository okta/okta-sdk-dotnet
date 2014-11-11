using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Okta.Core.Models;

namespace Okta.Core.Clients
{
    /// <summary>
    /// A convenience client to build all other clients without building a new <see cref="AuthenticatedClient.BaseClient"/> for every one.
    /// </summary>
    public class OktaClient : AuthenticatedClient
    {
        public OktaClient(string apiToken, string subdomain) : base(apiToken, subdomain) { }
        public OktaClient(string apiToken, Uri baseUri) : base(apiToken, baseUri) { }
        public OktaClient(OktaSettings oktaSettings) : base(oktaSettings) { }

        public UsersClient GetUsersClient()
        {
            return new UsersClient(BaseClient);
        }

        public UserGroupsClient GetUserGroupsClient(User user)
        {
            return new UserGroupsClient(user, BaseClient);
        }

        public UserFactorsClient GetUserFactorsClient(User user)
        {
            return new UserFactorsClient(user, BaseClient);
        }

        public UserAppLinksClient GetUserAppLinksClient(User user)
        {
            return new UserAppLinksClient(user, BaseClient);
        }

        public GroupsClient GetGroupsClient()
        {
            return new GroupsClient(BaseClient);
        }

        public GroupUsersClient GetGroupUsersClient(Group group)
        {
            return new GroupUsersClient(group, BaseClient);
        }

        public AppsClient GetAppsClient()
        {
            return new AppsClient(BaseClient);
        }

        public AppUsersClient GetAppUsersClient(App app)
        {
            return new AppUsersClient(app, BaseClient);
        }

        public AppGroupsClient GetAppGroupsClient(App app)
        {
            return new AppGroupsClient(app, BaseClient);
        }

        public AuthClient GetAuthClient()
        {
            return new AuthClient(BaseClient);
        }

        public EventsClient GetEventsClient()
        {
            return new EventsClient(BaseClient);
        }

        public SessionsClient GetSessionsClient()
        {
            return new SessionsClient(BaseClient);
        }

        public OrgFactorsClient GetOrgFactorsClient()
        {
            return new OrgFactorsClient(BaseClient);
        }
    }
}
