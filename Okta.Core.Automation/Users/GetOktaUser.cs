using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Okta.Core;

namespace Okta.Core.Automation
{
    [Cmdlet(VerbsCommon.Get, "OktaUser")]
    public class GetOktaUser : OktaCmdlet
    {
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Id to retrieve"
        )]
        public string Id { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Search query string"
        )]
        public string Query { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "Filter"
        )]
        public string Filter { get; set; }

        protected override void ProcessRecord()
        {
            var usersClient = Client.GetUsersClient();
            if (!string.IsNullOrEmpty(Id))
            {
                var user = usersClient.Get(Id);
                WriteObject(user);
            }
            else
            {
                var users = usersClient.GetFilteredEnumerator(query: Query, filter: new FilterBuilder(Filter));
                WriteObject(users);
            }
        }
    }
}
