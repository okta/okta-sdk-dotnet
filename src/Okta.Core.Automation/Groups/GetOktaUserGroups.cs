using System.Management.Automation;
using Okta.Core.Models;

namespace Okta.Core.Automation
{
    [Cmdlet(VerbsCommon.Get, "OktaUserGroups")]
    public class GetOktaUserGroups : OktaCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "ID or username of the Okta user"
        )]
        public string IdOrLogin { get; set; }


        protected override void ProcessRecord()
        {
            var usersClient = Client.GetUsersClient();
            User user = usersClient.Get(IdOrLogin);
            if (user == null)
                user = usersClient.GetByUsername(IdOrLogin);

            if (user != null)
            {
                var userGroupsClient = usersClient.GetUserGroupsClient(user);
                var userGroups = userGroupsClient.GetFilteredEnumerator();
                WriteObject(userGroups);
            }
            else
            {
                WriteWarning("The provided user ID or username is invalid. Please try again.");
            }
        }
    }
}
