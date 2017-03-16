using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Okta.Core;
using Okta.Core.Models;

namespace Okta.Core.Automation
{
    [Cmdlet("Delete", "OktaUser")]
    public class DeleteOktaUser : OktaCmdlet
    {
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "ID or username of the user to delete"
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
            HelpMessage = "Use a filter (see http://developer.okta.com/docs/api/resources/users.html#list-users-with-a-filter)"
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
                List<User> users = new List<User>();
                if (!string.IsNullOrEmpty(Id))
                {
                    var user = usersClient.Get(Id);
                    if (user != null)
                    {
                        users.Add(user);
                    }
                }
                else
                {
                    SearchType searchType = SearchType.Filter;
                    if (Search)
                    {
                        searchType = SearchType.ElasticSearch;
                    }
                    var usersEnum = usersClient.GetFilteredEnumerator(query: Query, searchType: searchType, filter: new FilterBuilder(Filter));
                    users = usersEnum.ToList<User>();
                }

                foreach (User user in users)
                {
                    string strUserLogin = user.Profile.Login;
                    bool bDeactivated = false;
                    try
                    {
                        usersClient.Deactivate(user);
                        bDeactivated = true;
                    }
                    catch (OktaException oex2)
                    {
                        if (oex2.ErrorCode == OktaErrorCodes.ResourceNotFoundException)
                        {
                            bDeactivated = true;
                        }
                    }

                    if (bDeactivated)
                    {
                        usersClient.Delete(user);
                        WriteObject(string.Format("Successfully deleted user: {0}", strUserLogin));
                    }
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
