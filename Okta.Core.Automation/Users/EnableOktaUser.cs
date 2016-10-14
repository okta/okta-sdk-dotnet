using System.Management.Automation;
using Okta.Core.Models;

namespace Okta.Core.Automation
{
    [Cmdlet(VerbsLifecycle.Enable, "OktaUser")]
    public class EnableOktaUser : OktaCmdlet
    {
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Id to enable"
        )]
        public string Id { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "User to enable"
        )]
        public User User { get; set; }

        protected override void ProcessRecord()
        {
            var usersClient = Client.GetUsersClient();
            if (!string.IsNullOrEmpty(Id))
            {
                usersClient.Activate(Id);
            }
            else if(User != null)
            {
                usersClient.Activate(User);
            }
        }
    }
}
