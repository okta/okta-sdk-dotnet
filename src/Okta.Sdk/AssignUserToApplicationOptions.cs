using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Sdk
{
    public sealed class AssignUserToApplicationOptions
    {
        public string UserId { get; set; }

        public string Scope { get; set; } = "USER";

        public string Password { get; set; }

        public string UserName { get; set; }

        public string ApplicationId { get; set; }

        public AppUserProfile Profile { get; set; }
    }
}
