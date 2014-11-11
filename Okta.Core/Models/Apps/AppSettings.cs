using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Okta.Core.Models
{
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
    }
}