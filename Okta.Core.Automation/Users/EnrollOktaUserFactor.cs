using System.Management.Automation;
using Okta.Core.Models;

namespace Okta.Core.Automation
{
    [Cmdlet("Enroll", "OktaUserFactor")]
    public class EnrollOktaUserFactor : OktaCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Id or username of the Okta user"
        )]
        public string IdOrLogin { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Name of the factor to enroll the user with. Use one of the following string: okta_question, okta_sms, okta_otp (Okta Verify), okta_push (Okta Verify Push), google_otp (Google Authenticator), symantec_vip, rsa_token, duo, yubikey_token, okta_call (voice call)"
        )]
        public string FactorType { get; set; }

        protected override void ProcessRecord()
        {
            var usersClient = Client.GetUsersClient();
            User user = usersClient.Get(IdOrLogin);
            if (user == null)
                user = usersClient.GetByUsername(IdOrLogin);

            if (user != null)
            {
                var userFactorsClient = usersClient.GetUserFactorsClient(user);
                var orgFactorsClient = Client.GetOrgFactorsClient();
                Factor orgFactor = orgFactorsClient.GetFactor(FactorType);
                
                
                if (orgFactor != null)
                {
                    Factor userFactor = null;
                    try
                    {
                        userFactor = userFactorsClient.Enroll(orgFactor);
                        WriteObject(userFactor);
                    }
                    catch (System.Exception ex)
                    {
                        //WriteError(new ErrorRecord(ex))
                        throw ex;
                    }
                    
                    WriteObject(userFactor);
                }
                else
                {
                    WriteWarning("The provided factor type seems to be invalid, please try again.");
                }
            }
            else
            {
                WriteWarning("The provided user id or username seems to be invalid, please try again.");
            }
        }
    }
}
