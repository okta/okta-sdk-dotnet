using System.Management.Automation;
using Okta.Core.Models;

namespace Okta.Core.Automation
{
    [Cmdlet(VerbsCommon.Get, "OktaUserFactor")]
    public class GetOktaUserFactor : OktaCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Id or username of the Okta user"
        )]
        public string IdOrLogin { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Id of the user's factor to retrieve"
        )]
        public string FactorId { get; set; }

        protected override void ProcessRecord()
        {
            var usersClient = Client.GetUsersClient();
            User user = usersClient.Get(IdOrLogin);
            if (user == null)
                user = usersClient.GetByUsername(IdOrLogin);

            if (user != null)
            {
                var userFactorsClient = usersClient.GetUserFactorsClient(user);

                if (!string.IsNullOrEmpty(FactorId))
                {
                    Factor userFactor = userFactorsClient.GetFactor(FactorId);
                    if (userFactor != null)
                    {
                        WriteObject(userFactor);
                    }
                    else
                    {
                        WriteWarning("The provided factor id seems to be invalid, please try again.");
                    }
                }
                else
                {
                    var userFactors = userFactorsClient.GetFilteredEnumerator();
                    WriteObject(userFactors);
                }
            }
            else
            {
                WriteWarning("The provided user id or username seems to be invalid, please try again.");
            }
        }
    }
}
