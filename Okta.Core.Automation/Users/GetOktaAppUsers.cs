using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Okta.Core;

namespace Okta.Core.Automation
{
    [Cmdlet(VerbsCommon.Get, "OktaAppUsers")]
    public class GetOktaAppUsers : OktaCmdlet
    {

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Id of the Okta application the users are assigned to"
        )]
        public string AppId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Number of users to retrieve from the app users list"
        )]
        public int Limit { get; set; }


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
                PagedResults<Models.AppUser> appUsers = appUsersClient.GetList(pageSize: Limit, searchType: SearchType.Filter);

                if (appUsers != null)
                {
                    WriteObject(appUsers);
                }
                else
                {
                    WriteWarning("There seems to be no assigned user in the requested Okta app");
                }
            }
        }
    }
}
