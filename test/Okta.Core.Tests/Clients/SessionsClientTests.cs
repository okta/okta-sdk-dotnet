using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Okta.Core.Clients;

namespace Okta.Core.Tests.Clients
{
    [TestClass]
    public class SessionsClientTests
    {
        [TestMethod]
        public void CreateSessionRedirectUrl()
        {
            String fakeEndpoint = "http://validurl.com:9999";
            String fakeSessionToken = "FakeSessionToken";
            String fakeRedirect = "https://this.is.fake:42/really?really=true&also=very+true";

            // Create a SessionsClient
            OktaSettings oktaSettings = new OktaSettings();
            oktaSettings.BaseUri = new Uri(fakeEndpoint);
            oktaSettings.ApiToken = "fakeApiToken";
            SessionsClient sessionsClient = new SessionsClient(oktaSettings);

            // Crate the session url string
            String sessionUrlString = sessionsClient.CreateSessionUrlString(fakeSessionToken, new Uri(fakeRedirect));

            // Check the format
            Assert.AreEqual("http://validurl.com:9999/login/sessionCookieRedirect?token=FakeSessionToken&redirectUrl=https%3A%2F%2Fthis.is.fake%3A42%2Freally%3Freally%3Dtrue%26also%3Dvery%2Btrue", sessionUrlString);
        }

        //[TestMethod]
        //public void DeleteSessionToken()
        //{
        //    OktaSettings oktaSettings = new OktaSettings();
        //    oktaSettings.BaseUri = new Uri(Environment.GetEnvironmentVariable("OKTA_TEST_URL"));
        //    oktaSettings.ApiToken = Environment.GetEnvironmentVariable("OKTA_TEST_KEY");

        //    String username = Environment.GetEnvironmentVariable("OKTA_TEST_ADMIN_NAME");
        //    String password = Environment.GetEnvironmentVariable("OKTA_TEST_ADMIN_PASSWORD");

        //    SessionsClient sessionsClient = new SessionsClient(oktaSettings);

        //    var session = sessionsClient.Create(username, password);
        //    sessionsClient.Close(session.Id);
        //}
    }
}
