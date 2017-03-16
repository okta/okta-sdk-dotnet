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
            HelpMessage = "Search query string (see http://developer.okta.com/docs/api/resources/users.html#find-users)"
        )]
        public string Query { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "Filter (see http://developer.okta.com/docs/api/resources/users.html#list-users-with-a-filter)"
        )]
        public string Filter { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "Use advanced search (see http://developer.okta.com/docs/api/resources/users.html#list-users-with-search)"
        )]
        public bool Search { get; set; }

        protected override void ProcessRecord()
        {
            var usersClient = Client.GetUsersClient();
            try
            {

                if (!string.IsNullOrEmpty(Id))
                {
                    var user = usersClient.Get(Id);
                    WriteObject(user);
                }
                else
                {
                    SearchType searchType = SearchType.Filter;
                    if (Search)
                    {
                        searchType = SearchType.ElasticSearch;
                    }
                    var users = usersClient.GetFilteredEnumerator(query: Query, searchType: searchType, filter: new FilterBuilder(Filter));
                    WriteObject(users);
                }
            }
            catch (OktaException oex)
            {
                ErrorRecord er = new ErrorRecord(oex, oex.ErrorId, ErrorCategory.InvalidData, usersClient);
                ErrorDetails errorDetails = new ErrorDetails(string.Format("An error occurred: {0}", oex.ErrorSummary));
                er.ErrorDetails = errorDetails;
                WriteError(er);
            }

        }
    }
}
