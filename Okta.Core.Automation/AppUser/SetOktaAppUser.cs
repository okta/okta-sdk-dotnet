using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Okta.Core.Models;

namespace Okta.Core.Automation
{
    [Cmdlet(VerbsCommon.Set, "OktaAppUser")]
    public class SetOktaAppUser : OktaCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Id of the Okta application the user is assigned to"
        )]
        public string AppId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Id of the app user assigned to the Okta application"
        )]
        public string UserId { get; set; }

        protected override void ProcessRecord()
        {
            var appsClient = Client.GetAppsClient();
            var app = appsClient.Get(AppId);
            if (app == null)
            {
                WriteWarning(string.Format("The provided AppId parameter ({0}) seems to be invalid, please try with a different AppId value.", AppId));
            }
            else
            {
                var appUsersClient = appsClient.GetAppUsersClient(app);
                try
                {
                    var appUser = appUsersClient.Add(UserId);
                    WriteObject(appUser);
                }
                catch (OktaException oex)
                {
                    ErrorRecord er = new ErrorRecord(oex, oex.ErrorId, ErrorCategory.InvalidData, appUsersClient);
                    ErrorDetails errorDetails = new ErrorDetails(string.Format("An error occurred while adding the user: {0}", oex.ErrorSummary));
                    er.ErrorDetails = errorDetails;
                    WriteError(er);
                }
            }
        }
    }
}
