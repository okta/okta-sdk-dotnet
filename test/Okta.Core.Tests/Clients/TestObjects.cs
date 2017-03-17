using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okta.Core.Tests.Clients
{
    class Tenant
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string ApiKey { get; set; }
        public string TestUserLogin { get; set; }
        public string TestUserId { get; set; }
    }

    class TestUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Activate { get; set; }
        public List<string> Factors { get; set; }

    }

    class TestGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Users { get; set; }
    }

    class TestCustomAttribute
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Login { get; set; }
        public bool MultiValued { get; set; }
    }
}
