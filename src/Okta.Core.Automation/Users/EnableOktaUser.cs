using System.Management.Automation;
using Okta.Core.Models;

namespace Okta.Core.Automation
{
    [Cmdlet(VerbsLifecycle.Enable, "OktaUser")]
    public class EnableOktaUser : OktaCmdlet
    {
        public EnableOktaUser()
        {
            SendEmail = false;
        }

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

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "true to send activation email, false to return an activation link"
        )]
        public bool SendEmail { get; set; }

        protected override void ProcessRecord()
        {
            var usersClient = Client.GetUsersClient();
            System.Uri activationUri = null;
            try
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    activationUri = usersClient.Activate(Id, SendEmail);
                }
                else if (User != null)
                {
                    activationUri = usersClient.Activate(User, SendEmail);
                    WriteObject(string.Format("An activation email was sent to {0}", User.Profile.Email));
                }
                if (activationUri != null)
                {
                    WriteObject(activationUri);
                }
            }
            catch (OktaException oex)
            {
                ErrorRecord er = new ErrorRecord(oex, oex.ErrorId, ErrorCategory.InvalidData, usersClient);
                ErrorDetails errorDetails = new ErrorDetails(string.Format("An error occurred while enabling the user: {0}", oex.ErrorSummary));
                er.ErrorDetails = errorDetails;
                WriteError(er);
            }
        }
    }
}
