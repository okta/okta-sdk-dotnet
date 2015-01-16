using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okta.Core.Clients;

namespace Okta.Core.Tests
{
    [TestClass]
    public class AuthClientTest
    {
        [TestMethod]
        [ExpectedException(typeof(OktaAuthenticationException))]
        public void AuthExceptionTest()
        {
            var testConfig = new OktaSettings();
            testConfig.ApiToken = "00UeGvRv5SKYzuWgqIg1ycd4uqk2dfgyZq0eAtSMHA";
            testConfig.BaseUri = new Uri("http://rain.okta1.com:1802");
            var client = new AuthClient(testConfig);

            client.Authenticate("fakeusername", "fakepassword");
        }
    }
}
