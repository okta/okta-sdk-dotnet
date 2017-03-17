using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Okta.Core;

namespace Okta.Core.Automation
{
    [Cmdlet(VerbsCommon.Get, "OktaGroup")]
    public class GetOktaGroup : OktaCmdlet
    {
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Id or Name of the group to retrieve"
        )]
        public string IdOrName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Search query string (see http://developer.okta.com/docs/api/resources/groups.html#search-groups)"
        )]
        public string Query { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "Group filter (see http://developer.okta.com/docs/api/resources/groups.html#filters)"
        )]
        public string Filter { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "Maximum number of groups to return"
        )]
        public int Limit { get; set; }

        protected override void ProcessRecord()
        {
            var groupsClient = Client.GetGroupsClient();
            if (!string.IsNullOrEmpty(IdOrName))
            {
                Models.Group group = null;
                try
                {
                     group = groupsClient.Get(IdOrName);
                }
                catch (OktaException)
                {
                        group = groupsClient.GetByName(IdOrName);
                }
                if(group != null)
                {
                    WriteObject(group);
                }
                else
                {
                    WriteWarning(string.Format("The group with ID or name {0} is invalid. Please try again.", IdOrName));
                }
            }
            else
            {
                if (Limit <= 0) Limit = 200;
                var groups = groupsClient.GetFilteredEnumerator(query: Query, filter: new FilterBuilder(Filter), pageSize: Limit);
                WriteObject(groups);
            }
        }
    }
}
