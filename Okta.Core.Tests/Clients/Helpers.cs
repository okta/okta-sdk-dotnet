using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Okta.Core.Tests.Clients
{
    class Helpers
    {
        internal static Tenant GetTenantFromConfig()
        {
            Tenant tenant = new Tenant
            {
                Url = ConfigurationManager.AppSettings["TenantUrl"],
                ApiKey = ConfigurationManager.AppSettings["ApiKey"]

            };

            return tenant;
        }

        internal static TestUser GetUser(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext context)
        {
            TestUser user = new TestUser
            {
                Id = Convert.ToInt32(context.DataRow["Id"]),
                Login = Convert.ToString(context.DataRow["Login"]),
                FirstName = Convert.ToString(context.DataRow["FirstName"]),
                LastName = Convert.ToString(context.DataRow["LastName"]),
                Email = Convert.ToString(context.DataRow["Email"]),
                Password = Convert.ToString(context.DataRow["Password"]),
            };

            //if Activate is not checked, the column value will be null, not false
            if (context.DataRow["Activate"] != System.DBNull.Value)
            {
                user.Activate = Convert.ToBoolean(context.DataRow["Activate"]);
            }

            if (context.DataRow["Factors"] != null && !(context.DataRow["Factors"] is System.DBNull) && !string.IsNullOrEmpty((string)context.DataRow["Factors"]))
            {
                string strFactors = (string)context.DataRow["Factors"];
                List<string> lstFactors = strFactors.Split(',').ToList<string>();
                user.Factors = lstFactors;
            }

            return user;
        }

        internal static TestGroup GetGroup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext context)
        {
            TestGroup group = new TestGroup
            {
                Id = Convert.ToInt32(context.DataRow["Id"]),
                Name = Convert.ToString(context.DataRow["Name"]),
                Description = Convert.ToString(context.DataRow["Description"]),
            };

            if (context.DataRow["Users"] != null && !(context.DataRow["Users"] is System.DBNull) && !string.IsNullOrEmpty((string)context.DataRow["Users"]))
            {
                string strUsers = (string)context.DataRow["Users"];
                group.Users = strUsers.Split(',').ToList<string>();
            }


            return group;
        }

        internal static TestCustomAttribute GetCustomAttribute(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext context)
        {
            TestCustomAttribute attr = new TestCustomAttribute
            {
                Login = Convert.ToString(context.DataRow["Login"]),
                Name = Convert.ToString(context.DataRow["AttributeName"]),
                Value = Convert.ToString(context.DataRow["AttributeValue"]),
                
            };

            if (context.DataRow["MultiValued"] != System.DBNull.Value)
            {
                attr.MultiValued = Convert.ToBoolean(context.DataRow["MultiValued"]);
            }

            return attr;
        }

    }
}
