using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Okta.Core;

namespace Okta.Core.Automation
{
    [Cmdlet(VerbsCommon.Get, "OktaEvents")]
    public class GetOktaEvents : OktaCmdlet
    {
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Start date of events to retrieve from Okta"
        )]
        public DateTime StartDate { get; set; }


        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Events filter (see http://developer.okta.com/docs/api/resources/events.html#filters for syntax details)"
        )]
        public string Filter { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "Maximum number of events to return"
        )]
        public int Limit { get; set; }

        protected override void ProcessRecord()
        {
            var eventsClient = Client.GetEventsClient();
            if (Limit <= 0) Limit = 200;
            EnumerableResults<Models.Event> events = null;
            if (!string.IsNullOrEmpty(Filter))
            {
                events = eventsClient.GetFilteredEnumerator(filter: new FilterBuilder(Filter), pageSize: Limit);
            }
            else
            {
                events = eventsClient.GetFilteredEnumerator(startDate: StartDate, pageSize: Limit);
            }
            WriteObject(events, false);
        }
    }
}
