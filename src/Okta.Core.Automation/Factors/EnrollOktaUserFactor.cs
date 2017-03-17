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
            HelpMessage = "Name of the factor to enroll the user with. Use one of the following values:  okta_sms (SMS) or okta_call (voice call)"
        )]
        public string FactorType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "Phone number to register (including country code) for SMS and voice call factors"
        )]
        public string PhoneNumber { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "Phone extension (optional for voice call factor only)"
)]
        public string PhoneExtension { get; set; }

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
                    if (orgFactor.Status == "ACTIVE")
                    {
                        Factor userFactor = new Factor();
                        userFactor.FactorType = orgFactor.FactorType;
                        userFactor.Provider = orgFactor.Provider;
                        if (orgFactor.Id == Constants.MfaTypes.SMS || orgFactor.Id == Constants.MfaTypes.VoiceCall)
                        {
                            if (string.IsNullOrEmpty(PhoneNumber))
                            {
                                WriteWarning("You must specify a phone number when enrolling the SMS or Voice Call factor");
                                return;
                            }
                            else
                            {
                                userFactor.Profile.PhoneNumber = PhoneNumber;
                            }
                            if (orgFactor.Id == Constants.MfaTypes.VoiceCall && !string.IsNullOrEmpty(PhoneExtension))
                            {
                                userFactor.Profile.PhoneExtension = PhoneExtension;
                            }
                            try
                            {
                                userFactor = userFactorsClient.Enroll(userFactor);
                                WriteObject(userFactor);
                            }
                            catch (OktaException oex)
                            {
                                ErrorRecord er = new ErrorRecord(oex, oex.ErrorId, ErrorCategory.NotSpecified, userFactorsClient);
                                ErrorDetails errorDetails = new ErrorDetails(string.Format("Could not enroll factor '{0}' for user {1}: {2}", FactorType, IdOrLogin, oex.ErrorCauses[0].ErrorSummary));
                                er.ErrorDetails = errorDetails;
                                WriteError(er);
                            }
                        }
                        else
                        {
                            WriteWarning(string.Format("The chosen factor ({0}) is inactive in this organization. Please choose an active factor.", FactorType));
                        }

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
}
