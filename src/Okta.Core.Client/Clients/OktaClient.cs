namespace Okta.Core.Clients
{
    using System;

    using Okta.Core.Models;

    /// <summary>
    /// A convenience client to build all other clients without building a new <see cref="AuthenticatedClient.BaseClient"/> for every one.
    /// </summary>
    public class OktaClient : AuthenticatedClient
    {
        public OktaClient(string apiToken, string subdomain) : base(apiToken, subdomain) { }
        public OktaClient(string apiToken, Uri baseUri) : base(apiToken, baseUri) { }
        public OktaClient(OktaSettings oktaSettings) : base(oktaSettings) { }

        public virtual UsersClient GetUsersClient()
        {
            return new UsersClient(BaseClient);
        }

        public virtual UserGroupsClient GetUserGroupsClient(User user)
        {
            return new UserGroupsClient(user, BaseClient);
        }

        public virtual UserFactorsClient GetUserFactorsClient(User user)
        {
            return new UserFactorsClient(user, BaseClient);
        }

        public virtual UserAppLinksClient GetUserAppLinksClient(User user)
        {
            return new UserAppLinksClient(user, BaseClient);
        }

        public virtual GroupsClient GetGroupsClient()
        {
            return new GroupsClient(BaseClient);
        }

        public virtual GroupUsersClient GetGroupUsersClient(Group group)
        {
            return new GroupUsersClient(group, BaseClient);
        }

        public virtual AppsClient GetAppsClient()
        {
            return new AppsClient(BaseClient);
        }

        public virtual AppUsersClient GetAppUsersClient(App app)
        {
            return new AppUsersClient(app, BaseClient);
        }

        public virtual AppGroupsClient GetAppGroupsClient(App app)
        {
            return new AppGroupsClient(app, BaseClient);
        }

        public virtual AuthClient GetAuthClient()
        {
            return new AuthClient(BaseClient);
        }

        public virtual EventsClient GetEventsClient()
        {
            return new EventsClient(BaseClient);
        }

        public virtual SessionsClient GetSessionsClient()
        {
            return new SessionsClient(BaseClient);
        }

        public virtual OrgFactorsClient GetOrgFactorsClient()
        {
            return new OrgFactorsClient(BaseClient);
        }

        public virtual UserSchemasClient GetUserTypesClient()
        {
            return new UserSchemasClient(BaseClient);
        }
    }
}
