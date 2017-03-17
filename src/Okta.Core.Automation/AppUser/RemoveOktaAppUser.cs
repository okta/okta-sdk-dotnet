using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Okta.Core.Models;
using Okta.Core.Clients;

namespace Okta.Core.Automation
{
    [Cmdlet(VerbsCommon.Remove, "OktaAppUser")]
    public class RemoveOktaAppUser : OktaCmdlet
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
            HelpMessage = "Id of the user assigned to the Okta application"
        )]
        public string UserId { get; set; }

        protected override void ProcessRecord()
        {
            var appsClient = Client.GetAppsClient();
            var usersClient = Client.GetUsersClient();
            AppUsersClient appUsersClient = null;
            App app = null;
            AppUser appUser = null;
            try
            {
                app = appsClient.Get(AppId);
                if (app == null)
                {
                    WriteWarning(string.Format("The provided AppId parameter ({0}) seems to be invalid, please try with a different AppId value.", AppId));
                }
                else
                {
                    appUsersClient = appsClient.GetAppUsersClient(app);
                    appUser = appUsersClient.Get(new AppUser { Id = UserId });
                    if (appUser != null)
                    {
                        appUsersClient.Remove(new User { Id = UserId });
                    }
                    WriteObject(string.Format("Successfully removed user {0} from app {1}", appUser.Credentials.UserName, app.Label));
                }
            }
            catch (OktaException oex)
            {
                ErrorRecord er = new ErrorRecord(oex, oex.ErrorId, ErrorCategory.InvalidData, appUsersClient);
                ErrorDetails errorDetails = null;
                if (app == null)
                {
                    errorDetails = new ErrorDetails(string.Format("The '{1}' app doesn't seem to exist: {2}", UserId, AppId, oex.ErrorSummary));
                }
                else
                {
                    if (appUser == null)
                    {
                        errorDetails = new ErrorDetails(string.Format("The user '{0} is not assigned to this app. Error message: {1}", UserId, oex.ErrorSummary));
                    }
                    else
                    {
                        errorDetails = new ErrorDetails(string.Format("An error occurred while removing the user '{0}' from the '{1}' app: {2}", UserId, app.Label, oex.ErrorSummary));
                    }
                }
                er.ErrorDetails = errorDetails;
                WriteError(er);
            }
        }
    }
}
