namespace Okta.Core.Models
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// An org's third party integration with Okta
    /// </summary>
    public class App : OktaObject
    {
        public App()
        {
            Accessibility = new Accessibility();
            Visibility = new Visibility();
            Credentials = new AppCredentials();
            Settings = new Settings();
        }

        // TODO: Our api docs are incorrect for requestIntegration being a required parameter
        /// <summary>
        /// Builds a bookmark app.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="label">The label.</param>
        /// <param name="requestIntegration">Whether we should request integration into the OAN.</param>
        /// <returns></returns>
        public static App BuildBookmark(string url, string label = null, bool? requestIntegration = null)
        {
            var app = new App {
                Name = "bookmark", 
                Label = label, 
                SignOnMode = "BOOKMARK"
            };

            app.Settings.App.Url = url;

            if (requestIntegration != null)
            {
                app.Settings.App.RequestIntegration = (bool)requestIntegration;
            }

            return app;
        }

        /// <summary>
        /// Builds a basic authentication app.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="authUrl">The authentication URL.</param>
        /// <param name="label">The label.</param>
        /// <returns></returns>
        public static App BuildBasicAuth(string url, string authUrl, string label = null)
        {
            var app = new App {
                Name = "template_basic_auth", 
                Label = label, 
                SignOnMode = "BASIC_AUTH"
            };

            app.Settings.App = new AppSettings {
                Url = url, 
                AuthURL = authUrl
            };

            return app;
        }

        /// <summary>
        /// Builds a swa plugin app.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="usernameField">The username field.</param>
        /// <param name="passwordField">The password field.</param>
        /// <param name="buttonField">The button field.</param>
        /// <param name="label">The label.</param>
        /// <param name="extraFieldSelector">The extra field selector.</param>
        /// <param name="extraFieldValue">The extra field value.</param>
        /// <returns></returns>
        public static App BuildSwaPlugin(
            string url, 
            string usernameField, 
            string passwordField, 
            string buttonField, 
            string label = null, 
            string extraFieldSelector = null, 
            string extraFieldValue = null)
        {
            var app = new App {
                Name = "template_swa", 
                Label = label, 
                SignOnMode = "BROWSER_PLUGIN"
            };

            app.Settings.App = new AppSettings {
                UsernameField = usernameField, 
                PasswordField = passwordField, 
                ButtonField = buttonField, 
                ExtraFieldSelector = extraFieldSelector, 
                ExtraFieldValue = extraFieldValue,
                Url = url
            };

            return app;
        }

        /// <summary>
        /// Builds a swa app without a plugin (SPS).
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="usernameField">The username field.</param>
        /// <param name="passwordField">The password field.</param>
        /// <param name="label">The label.</param>
        /// <param name="optionalField1">The optional field1.</param>
        /// <param name="optionalField1Value">The optional field1 value.</param>
        /// <param name="optionalField2">The optional field2.</param>
        /// <param name="optionalField2Value">The optional field2 value.</param>
        /// <param name="optionalField3">The optional field3.</param>
        /// <param name="optionalField3Value">The optional field3 value.</param>
        /// <returns></returns>
        public static App BuildSwaNoPlugin(
            string url, 
            string usernameField, 
            string passwordField, 
            string label = null, 
            string optionalField1 = null, 
            string optionalField1Value = null, 
            string optionalField2 = null, 
            string optionalField2Value = null, 
            string optionalField3 = null, 
            string optionalField3Value = null)
        {
            var app = new App {
                Name = "template_sps", 
                Label = label, 
                SignOnMode = "SECURE_PASSWORD_STORE"
            };

            app.Settings.App = new AppSettings {
                Url = url,
                UsernameField = usernameField, 
                PasswordField = passwordField, 
                OptionalField1 = optionalField1, 
                OptionalField1Value = optionalField1Value, 
                OptionalField2 = optionalField2, 
                OptionalField2Value = optionalField2Value, 
                OptionalField3 = optionalField3, 
                OptionalField3Value = optionalField3Value
            };

            return app;
        }

        /*// Build SAML 2.0
        public static App BuildSaml20(
            string label = null,
            string audienceRestriction = "https://example.com/tenant/123",
            bool forceAuthn = false,
            string postBackURL = "https://example.com/sso/saml",
            string authnContextClassRef = "urn:oasis:names:tc:SAML:2.0:ac:classes:PasswordProtectedTransport",
            string requestCompressed = "COMPRESSED",
            string recipient = "https://example.com/sso/saml",
            string signAssertion = "SIGNED",
            string destination = "https://example.com/sso/saml",
            string signResponse = "SIGNED",
            string nameIDFormat = "urn:oasis:names:tc:SAML:1.1:nameid-format:emailAddress",
            string groupName = null,
            string groupFilter = null,
            string defaultRelayState = null,
            string configuredIssuer = null,
            string attributeStatements = null)
        {
            var app = new App()
            {
                Name = "template_saml_2_0",
                Label = label,
                SignOnMode = "SAML_2_0"
            };

            app.Settings.App = new AppSettings()
            {
                AudienceRestriction = audienceRestriction,
                ForceAuthn = forceAuthn,
                PostBackUrl = postBackURL,
                AuthnContextClassRef = authnContextClassRef,
                RequestCompressed = requestCompressed,
                Recipient = recipient,
                SignAssertion = signAssertion,
                Destination = destination,
                SignResponse = signResponse,
                NameIDFormat = nameIDFormat,
                GroupName = groupName,
                GroupFilter =  groupFilter,
                DefaultReplayState = defaultRelayState,
                ConfiguredIssuer = configuredIssuer,
                AttributeStatements = attributeStatements
            };

            return app;
        }*/

         // Build WS-Fed
        public static App BuildWSFed(
            string label = null,
            string audienceRestriction = "urn:example:app",
            string groupName = null,
            string groupValueFormat = "windowsDomainQualifiedName",
            string realm = "urn:example:app",
            string wReplyURL = "https://example.com/replyto",
            string attributeStatements = null,
            string nameIDFormat = "urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified",
            string authnContextClassRef = "urn:oasis:names:tc:SAML:2.0:ac:classes:PasswordProtectedTransport",
            string siteURL = "https://example.com",
            bool wReplyOverride = false,
            string groupFilter = null,
            string usernameAttribute = "username")
        {
            var app = new App()
            {
                Name = "template_wsfed",
                Label = label,
                SignOnMode = "WS_FEDERATION"
            };

            app.Settings.App = new AppSettings()
            {
                AudienceRestriction = audienceRestriction,
                GroupName = groupName,
                GroupValueFormat = groupValueFormat,
                Realm = realm,
                WReplyURL = wReplyURL,
                AttributeStatements = attributeStatements,
                NameIDFormat = nameIDFormat,
                AuthnContextClassRef = authnContextClassRef,
                SiteURL = siteURL,
                WReplyOverride = wReplyOverride,
                GroupFilter = groupFilter,
                UsernameAttribute = usernameAttribute
            };

            return app;
        }
        

        /// <summary>
        /// Unique key for app definition
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Unique user-defined display name for app
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// Timestamp when app was created
        /// </summary>
        [JsonProperty("created")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Timestamp when app was last updated
        /// </summary>
        [JsonProperty("lastUpdated")]
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Status of app
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Timestamp when transition to ACTIVE status completed
        /// </summary>
        [JsonProperty("activated")]
        public DateTime Activated { get; set; }

        /// <summary>
        /// Enabled app features
        /// </summary>
        [JsonProperty("features")]
        public string[] Features { get; set; }

        /// <summary>
        /// Authentication mode of app
        /// </summary>
        [JsonProperty("signOnMode")]
        public string SignOnMode { get; set; }

        [JsonProperty("accessibility")]
        public Accessibility Accessibility { get; set; }

        [JsonProperty("visibility")]
        public Visibility Visibility { get; set; }

        [JsonProperty("credentials")]
        public AppCredentials Credentials { get; set; }

        [JsonProperty("settings")]
        public Settings Settings { get; set; }
    }
}