using System.Management.Automation;
using Okta.Core.Models;

namespace Okta.Core.Automation
{
    [Cmdlet(VerbsCommon.Unlock, "OktaUser")]
    public class UnlockOktaUser : OktaCmdlet
    {
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Id to unlock"
        )]
        public string Id { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "User to unlock"
        )]
        public User User { get; set; }

        protected override void ProcessRecord()
        {
            var usersClient = Client.GetUsersClient();
            if (!string.IsNullOrEmpty(Id))
            {
                usersClient.Unlock(Id);
            }
            else if(User != null)
            {
                usersClient.Unlock(User);
            }
        }
    }
}
