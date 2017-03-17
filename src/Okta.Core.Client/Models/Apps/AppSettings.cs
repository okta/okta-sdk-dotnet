namespace Okta.Core.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Attributes of an <see cref="App"/>
    /// </summary>
    public class AppSettings : ApiObject
    {
        /// <summary>
        /// The URL of the login page for this app
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Would you like Okta to add an integration for this app?
        /// </summary>
        [JsonProperty("requestIntegration")]
        public bool RequestIntegration { get; set; }

        /// <summary>
        /// The URL of the authenticating site for this app
        /// </summary>
        [JsonProperty("authURL")]
        public string AuthURL { get; set; }

        /// <summary>
        /// CSS selector for the username field in the login form
        /// </summary>
        [JsonProperty("usernameField")]
        public string UsernameField { get; set; }

        /// <summary>
        /// CSS selector for the password field in the login form
        /// </summary>
        [JsonProperty("passwordField")]
        public string PasswordField { get; set; }

        /// <summary>
        /// CSS selector for the login button in the login form
        /// </summary>
        [JsonProperty("buttonField")]
        public string ButtonField { get; set; }

        /// <summary>
        /// CSS selector for the extra field in the form
        /// </summary>
        [JsonProperty("extraFieldSelector")]
        public string ExtraFieldSelector { get; set; }

        /// <summary>
        /// Value for extra field form field
        /// </summary>
        [JsonProperty("extraFieldValue")]
        public string ExtraFieldValue { get; set; }

        /// <summary>
        /// Name of the optional parameter in the login form
        /// </summary>
        [JsonProperty("optionalField1")]
        public string OptionalField1 { get; set; }

        /// <summary>
        /// Name of the optional value in the login form
        /// </summary>
        [JsonProperty("optionalField1Value")]
        public string OptionalField1Value { get; set; }

        /// <summary>
        /// Name of the optional parameter in the login form
        /// </summary>
        [JsonProperty("optionalField2")]
        public string OptionalField2 { get; set; }

        /// <summary>
        /// Name of the optional value in the login form
        /// </summary>
        [JsonProperty("optionalField2Value")]
        public string OptionalField2Value { get; set; }

        /// <summary>
        /// Name of the optional parameter in the login form
        /// </summary>
        [JsonProperty("optionalField3")]
        public string OptionalField3 { get; set; }

        /// <summary>
        /// Name of the optional value in the login form
        /// </summary>
        [JsonProperty("optionalField3Value")]
        public string OptionalField3Value { get; set; }

        /// <summary>
        /// WS-Fed or SAML 2.0 Audience Restriction
        /// </summary>
        [JsonProperty("audienceRestriction")]
        public string AudienceRestriction { get; set; }

        /// <summary>
        /// WS-Federation Group Attribute Name (Optional)
        /// </summary>
        /// <remarks>Specifies the SAML attribute name for a user's group memberships.</remarks>
        /// <value>Default value is http://schemas.microsoft.com/ws/2008/06/identity/claims/role </value>
        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        /// <summary>
        /// Specifies the SAML assertion attribute value for filtered groups (WS-Federation).
        /// </summary>
        /// <value>windowsDomainQualifiedName, samAccountName or dn </value>
        [JsonProperty("groupValueFormat")]
        public string GroupValueFormat { get; set; }

        /// <summary>
        ///Realm of the WS-Fed web application. If empty, a generated realm will be provided in the WS-Federation setup instructions
        /// </summary>
        [JsonProperty("realm")]
        public string Realm { get; set; }

        /// <summary>
        ///The ReplyTo URL to which responses are directed
        /// </summary>
        [JsonProperty("wReplyURL")]
        public string WReplyURL { get; set; }

        /// <summary>
        ///Name ID Format
        /// </summary>
        /// <value>Default value is urn:oasis:names:tc:SAML:1.1:nameid-format:unspecified, can also be urn:oasis:names:tc:SAML:1.1:nameid-format:emailAddress, urn:oasis:names:tc:SAML:2.0:nameid-format:persistent, urn:oasis:names:tc:SAML:2.0:nameid-format:transient or urn:oasis:names:tc:SAML:1.1:nameid-format:x509SubjectName</value>
        [JsonProperty("nameIDFormat")]
        public string NameIDFormat { get; set; }

        /// <summary>
        /// Defines custom SAML attribute statements 
        /// </summary>
        /// <value>AttributeName|AttributeValue|AttributeNameFormat. Multiple attribute statements can be defined using a comma(,) AttributeNameFormat is optional</value>
        /// <example>http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname|${user.firstName}|,http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname|${user.lastName}| </example>
        [JsonProperty("attributeStatements")]
        public string AttributeStatements { get; set; }

        /// <summary>
        /// Assertion Authentication Context - specifies the Authentication Context for the issued SAML Assertion 
        /// </summary>
        /// <value>Set to urn:oasis:names:tc:SAML:2.0:ac:classes:PasswordProtectedTransport by default, can also be urn:oasis:names:tc:SAML:2.0:ac:classes:Password, urn:oasis:names:tc:SAML:2.0:ac:classes:unspecified, urn:oasis:names:tc:SAML:2.0:ac:classes:TLSClient, urn:oasis:names:tc:SAML:2.0:ac:classes:X509, urn:federation:authentication:windows or oasis:names:tc:SAML:2.0:ac:classes:Kerberos</value>
        [JsonProperty("authnContextClassRef")]
        public string AuthnContextClassRef { get; set; }

        /// <summary>
        /// Launch URL for the Web Application 
        /// </summary>
        [JsonProperty("siteURL")]
        public string SiteURL { get; set; }

        /// <summary>
        /// Enable web application to override ReplyTo URL with wreply param
        /// </summary>
        [JsonProperty("wReplyOverride")]
        public bool WReplyOverride { get; set; }

        /// <summary>
        /// Create an expression that will be used to filter groups. If the Okta group name matches the expression, the group name will be included in the SAML Assertion Attribute Statement. Uses regular expression syntax 
        /// </summary>
        /// <example>app1.* </example>
        [JsonProperty("groupFilter")]
        public string GroupFilter { get; set; }

        /// <summary>
        /// Specifies additional username attribute statements to include in the SAML Assertion.  Simplifies integration with .NET apps that ignore Subject statements
        /// </summary>
        /// <example>username, upn, upnAndUsername, none</example>
        [JsonProperty("usernameAttribute")]
        public string UsernameAttribute { get; set; }

    }
}