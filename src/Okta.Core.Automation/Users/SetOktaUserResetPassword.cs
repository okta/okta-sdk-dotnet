using System.Management.Automation;
using Okta.Core.Models;

namespace Okta.Core.Automation
{
    [Cmdlet(VerbsCommon.Set, "OktaUserResetPassword")]
    public class SetOktaUserResetPassword : OktaCmdlet
    {
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "User Id to reset password for"
        )]
        public string Id { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "$true to send password reset email, $false to return an activation link"
        )]
        public bool SendEmail { get; set; }

        protected override void ProcessRecord()
        {
            var usersClient = Client.GetUsersClient();
            System.Uri passwordResetUri = null;
            try
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    passwordResetUri = usersClient.ForgotPassword(Id, SendEmail );
                }

                if (passwordResetUri != null)
                {
                    WriteObject(passwordResetUri);
                }
            }
            catch (OktaException oex)
            {
                ErrorRecord er = new ErrorRecord(oex, oex.ErrorId, ErrorCategory.InvalidData, usersClient);
                ErrorDetails errorDetails = new ErrorDetails(string.Format("An error occurred while resetting the password of the user: {0}", oex.ErrorSummary));
                er.ErrorDetails = errorDetails;
                WriteError(er);
            }
        }
    }
}
