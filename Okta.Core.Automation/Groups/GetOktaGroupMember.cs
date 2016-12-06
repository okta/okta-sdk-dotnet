using System.Management.Automation;
using Okta.Core.Models;

namespace Okta.Core.Automation
{
    [Cmdlet(VerbsCommon.Get, "OktaGroupMember")]
    public class GetOktaGroupMember : OktaCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "ID or Name of the group to retrieve"
        )]
        public string IdOrName { get; set; }

        protected override void ProcessRecord()
        {
            var groupsClient = Client.GetGroupsClient();
            Models.Group group = null;
            try
            {
                group = groupsClient.Get(IdOrName);
            }
            catch (OktaException)
            {
                group = groupsClient.GetByName(IdOrName);
            }
            if (group != null)
            {
                var groupUsersClient = Client.GetGroupUsersClient(group);
                var users = groupUsersClient.GetFilteredEnumerator();
                WriteObject(users);
            }
            else
            {
                WriteWarning(string.Format("The group with ID or name {0} is invalid. Please try again", IdOrName));
            }
        }
    }
}
