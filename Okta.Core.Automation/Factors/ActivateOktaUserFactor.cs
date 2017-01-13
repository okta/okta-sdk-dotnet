using System.Management.Automation;
using Okta.Core.Models;

namespace Okta.Core.Automation
{
    [Cmdlet("Activate", "OktaUserFactor")]
    public class ActivateOktaUserFactor : OktaCmdlet
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
            HelpMessage = "Id of the user factor to remove. If empty, removes all user factors"
        )]
        public string FactorId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "Passcode for SMS or voice call"
        )]
        public string PassCode { get; set; }

        protected override void ProcessRecord()
        {
            var usersClient = Client.GetUsersClient();
            User user = usersClient.Get(IdOrLogin);
            if (user == null)
                user = usersClient.GetByUsername(IdOrLogin);

            if (user != null)
            {
                var userFactorsClient = usersClient.GetUserFactorsClient(user);
                Factor userFactor = null;
                if (!string.IsNullOrEmpty(FactorId))
                {
                    userFactor = userFactorsClient.GetFactor(FactorId);
                    if (userFactor != null)
                    {
                        try
                        {
                            userFactor = userFactorsClient.Activate(userFactor, PassCode);
                            WriteObject($"The factor was successfully activated for user {IdOrLogin} with status {userFactor.Status}.");
                            WriteObject(userFactor);
                        }
                        catch (OktaException oex)
                        {
                            ErrorRecord er = new ErrorRecord(oex, oex.ErrorId, ErrorCategory.NotSpecified, userFactorsClient);
                            ErrorDetails errorDetails = new ErrorDetails($"Could not remove factor {FactorId} for user {IdOrLogin}: {oex.ErrorSummary}.");
                            er.ErrorDetails = errorDetails;
                            WriteError(er);
                        }
                    }
                    else
                    {
                        WriteWarning("The provided factor type seems to be invalid, please try again.");
                    }
                }
                else
                {
                    WriteInformation("About to delete all user factors...", null);
                    var factors = userFactorsClient.GetList();
                    foreach(Factor factor in factors.Results)
                    {
                        userFactorsClient.Reset(factor);
                    }
                }
            }
            else
            {
                WriteWarning("The provided user id or username seems to be invalid, please try again.");
            }
        }
    }
}


