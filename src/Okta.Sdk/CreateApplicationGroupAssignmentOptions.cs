using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk
{
    public sealed class CreateApplicationGroupAssignmentOptions
    {
        public int Priority { get; set; }

        public string ApplicationId { get; set; }

        public string GroupId { get; set; }
    }
}
