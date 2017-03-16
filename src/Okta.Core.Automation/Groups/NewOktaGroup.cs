using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Okta.Core.Models;

namespace Okta.Core.Automation
{
    [Cmdlet(VerbsCommon.New, "OktaGroup")]
    public class NewOktaGroup : OktaCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Group name"
        )]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Group description"
        )]
        public string Description { get; set; }


        protected override void ProcessRecord()
        {
            var groupsClient = Client.GetGroupsClient();
            var group = new Group(Name, Description);
            group = groupsClient.Add(group);
            WriteObject(group);
        }
    }
}
