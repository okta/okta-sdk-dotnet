using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Okta.Core;

namespace Okta.Core.Automation
{
    [Cmdlet(VerbsCommon.Get, "OktaAppUser")]
    public class GetOktaAppUser : OktaCmdlet
    {

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Id of the Okta application the user is assigned to"
        )]
        public string AppId { get; set; }

        [Parameter(
    Mandatory = false,
    ValueFromPipelineByPropertyName = true,
    Position = 1,
    HelpMessage = "Maximum number of app users to retrieve"
)]
        public int Limit { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
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

                if (!string.IsNullOrEmpty(UserId))
                {
                    var appUser = appUsersClient.Get(new Models.AppUser
                    {
                        Id = UserId
                    });

                    if (appUser != null)
                    {
                        WriteObject(appUser);
                    }
                    else
                    {
                        WriteWarning(string.Format("The provided UserId parameter ({0}) seems to be invalid, please try with a different AppId value.", UserId));
                    }
                }
                else
                {
                    var appUsers = appUsersClient.GetFilteredEnumerator(pageSize: (Limit > 0) ? Limit : 200);
                    WriteObject(appUsers);
                }
            }
        }
    }
}
