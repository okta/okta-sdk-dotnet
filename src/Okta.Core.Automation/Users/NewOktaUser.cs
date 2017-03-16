using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Okta.Core.Models;

namespace Okta.Core.Automation
{
    [Cmdlet(VerbsCommon.New, "OktaUser")]
    public class NewOktaUser : OktaCmdlet
    {

        public NewOktaUser()
        {
            Activate = false;
        }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Unique login for the user (must be an email address)"
        )]
        [Alias("UserName")]
        public string Login { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Unique email"
        )]
        public string Email { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "First name of the user"
        )]
        public string FirstName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "Last name of the user"
        )]
        public string LastName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 4,
            HelpMessage = "Phone number of the user"
        )]
        public string MobilePhone { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 5,
            HelpMessage = "Activates the user by sending an activation email"
        )]
        public bool Activate { get; set; }

        protected override void ProcessRecord()
        {
            var usersClient = Client.GetUsersClient();
            try
            {
                var user = new User(Login, Email, FirstName, LastName, MobilePhone);
                user = usersClient.Add(user, Activate);
                WriteObject(user);
            }
            catch (OktaException oex)
            {
                ErrorRecord er = new ErrorRecord(oex, oex.ErrorId, ErrorCategory.InvalidData, usersClient);
                ErrorDetails errorDetails = new ErrorDetails(string.Format("An error occurred while creating the user: {0}", oex.ErrorCauses[0].ErrorSummary));
                er.ErrorDetails = errorDetails;
                WriteError(er);
            }

            }
    }
}
