using System.Management.Automation;
using Okta.Core.Models;

namespace Okta.Core.Automation
{
    [Cmdlet(VerbsLifecycle.Disable, "OktaUser")]
    public class DisableOktaUser : OktaCmdlet
    {
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Id to disable"
        )]
        public string Id { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "User to disable"
        )]
        public User User { get; set; }

        protected override void ProcessRecord()
        {
            var usersClient = Client.GetUsersClient();
            if (!string.IsNullOrEmpty(Id))
            {
                usersClient.Deactivate(Id);
            }
            else if(User != null)
            {
                usersClient.Deactivate(User);
            }
        }
    }
}
