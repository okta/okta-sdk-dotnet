using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Okta.Core.Models;

namespace Okta.Core.Automation
{
    [Cmdlet(VerbsCommon.Set, "OktaUser")]
    public class SetOktaUser : OktaCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "User to save"
        )]
        public User User { get; set; }

        protected override void ProcessRecord()
        {
            var usersClient = Client.GetUsersClient();
            usersClient.Update(User);
        }
    }
}
