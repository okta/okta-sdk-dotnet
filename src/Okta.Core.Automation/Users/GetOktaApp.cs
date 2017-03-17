using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Okta.Core;

namespace Okta.Core.Automation
{
    [Cmdlet(VerbsCommon.Get, "OktaApp")]
    public class GetOktaApp : OktaCmdlet
    {
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "App id to retrieve"
        )]
        public string Id { get; set; }

        protected override void ProcessRecord()
        {
            var appsClient = Client.GetAppsClient();
            if (!string.IsNullOrEmpty(Id))
            {
                try
                {
                    var app = appsClient.Get(Id);
                    WriteObject(app);

                }
                catch (OktaException oex)
                {
                    ErrorRecord er = new ErrorRecord(oex, oex.ErrorId, ErrorCategory.InvalidData, appsClient);
                    ErrorDetails errorDetails = new ErrorDetails("You likely did not enter a valid Okta application id. Please verify that you have a valid Okta application id (such as 0oa86pahb099w70q00h6) and enter it again.");
                    errorDetails.RecommendedAction = "Please verify that you have a valid Okta application id available.";
                    er.ErrorDetails = errorDetails;
                    WriteError(er);
                }
            }
            else
            {
                var apps = appsClient.GetFilteredEnumerator();
                WriteObject(apps);
            }
        }
    }
}
