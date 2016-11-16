using System.Management.Automation;
using Okta.Core.Models;

namespace Okta.Core.Automation
{
    [Cmdlet(VerbsCommon.Get, "OktaUserFactors")]
    public class GetOktaUserFactors : OktaCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Id or username of the Okta user"
        )]
        public string IdOrLogin { get; set; }

        protected override void ProcessRecord()
        {
            var usersClient = Client.GetUsersClient();
            User user = usersClient.Get(IdOrLogin);
            if (user == null)
                user = usersClient.GetByUsername(IdOrLogin);

            if (user != null)
            {
                var userFactorsClient = usersClient.GetUserFactorsClient(user);
                var userFactors = userFactorsClient.GetFactorCatalog();
                if (userFactors != null)
                {
                    WriteObject(userFactors);
                }
                else
                {
                    WriteWarning("The provided user doesn't seem to have any assigned factor.");
                }
            }
            else
            {
                WriteWarning("The provided user id or username seems to be invalid, please try again.");
            }
        }
    }
}
