/*
 * Okta Management
 *
 * Allows customers to easily access the Okta Management APIs
 *
 * The version of the OpenAPI document: 3.0.0
 * Contact: devex-public@okta.com
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using OpenAPIDateConverter = Okta.Sdk.Client.OpenAPIDateConverter;

namespace Okta.Sdk.Model
{
    /// <summary>
    /// Defines MultifactorEnrollmentPolicyAuthenticatorType
    /// </summary>
    [JsonConverter(typeof(StringEnumSerializingConverter))]

    /// <summary>
    /// An enumeration of MultifactorEnrollmentPolicyAuthenticatorType values in the Okta API.
    /// </summary>
    public sealed class MultifactorEnrollmentPolicyAuthenticatorType : StringEnum
    {
         /// <summary>
        /// StringEnum MultifactorEnrollmentPolicyAuthenticatorType for value: custom_app
        /// </summary>
        public static MultifactorEnrollmentPolicyAuthenticatorType CustomApp = new MultifactorEnrollmentPolicyAuthenticatorType("custom_app");
         /// <summary>
        /// StringEnum MultifactorEnrollmentPolicyAuthenticatorType for value: custom_otp
        /// </summary>
        public static MultifactorEnrollmentPolicyAuthenticatorType CustomOtp = new MultifactorEnrollmentPolicyAuthenticatorType("custom_otp");
         /// <summary>
        /// StringEnum MultifactorEnrollmentPolicyAuthenticatorType for value: duo
        /// </summary>
        public static MultifactorEnrollmentPolicyAuthenticatorType Duo = new MultifactorEnrollmentPolicyAuthenticatorType("duo");
         /// <summary>
        /// StringEnum MultifactorEnrollmentPolicyAuthenticatorType for value: external_idp
        /// </summary>
        public static MultifactorEnrollmentPolicyAuthenticatorType ExternalIdp = new MultifactorEnrollmentPolicyAuthenticatorType("external_idp");
         /// <summary>
        /// StringEnum MultifactorEnrollmentPolicyAuthenticatorType for value: google_otp
        /// </summary>
        public static MultifactorEnrollmentPolicyAuthenticatorType GoogleOtp = new MultifactorEnrollmentPolicyAuthenticatorType("google_otp");
         /// <summary>
        /// StringEnum MultifactorEnrollmentPolicyAuthenticatorType for value: okta_email
        /// </summary>
        public static MultifactorEnrollmentPolicyAuthenticatorType OktaEmail = new MultifactorEnrollmentPolicyAuthenticatorType("okta_email");
         /// <summary>
        /// StringEnum MultifactorEnrollmentPolicyAuthenticatorType for value: okta_password
        /// </summary>
        public static MultifactorEnrollmentPolicyAuthenticatorType OktaPassword = new MultifactorEnrollmentPolicyAuthenticatorType("okta_password");
         /// <summary>
        /// StringEnum MultifactorEnrollmentPolicyAuthenticatorType for value: okta_verify
        /// </summary>
        public static MultifactorEnrollmentPolicyAuthenticatorType OktaVerify = new MultifactorEnrollmentPolicyAuthenticatorType("okta_verify");
         /// <summary>
        /// StringEnum MultifactorEnrollmentPolicyAuthenticatorType for value: onprem_mfa
        /// </summary>
        public static MultifactorEnrollmentPolicyAuthenticatorType OnpremMfa = new MultifactorEnrollmentPolicyAuthenticatorType("onprem_mfa");
         /// <summary>
        /// StringEnum MultifactorEnrollmentPolicyAuthenticatorType for value: phone_number
        /// </summary>
        public static MultifactorEnrollmentPolicyAuthenticatorType PhoneNumber = new MultifactorEnrollmentPolicyAuthenticatorType("phone_number");
         /// <summary>
        /// StringEnum MultifactorEnrollmentPolicyAuthenticatorType for value: rsa_token
        /// </summary>
        public static MultifactorEnrollmentPolicyAuthenticatorType RsaToken = new MultifactorEnrollmentPolicyAuthenticatorType("rsa_token");
         /// <summary>
        /// StringEnum MultifactorEnrollmentPolicyAuthenticatorType for value: security_question
        /// </summary>
        public static MultifactorEnrollmentPolicyAuthenticatorType SecurityQuestion = new MultifactorEnrollmentPolicyAuthenticatorType("security_question");
         /// <summary>
        /// StringEnum MultifactorEnrollmentPolicyAuthenticatorType for value: symantec_vip
        /// </summary>
        public static MultifactorEnrollmentPolicyAuthenticatorType SymantecVip = new MultifactorEnrollmentPolicyAuthenticatorType("symantec_vip");
         /// <summary>
        /// StringEnum MultifactorEnrollmentPolicyAuthenticatorType for value: webauthn
        /// </summary>
        public static MultifactorEnrollmentPolicyAuthenticatorType Webauthn = new MultifactorEnrollmentPolicyAuthenticatorType("webauthn");
         /// <summary>
        /// StringEnum MultifactorEnrollmentPolicyAuthenticatorType for value: yubikey_token
        /// </summary>
        public static MultifactorEnrollmentPolicyAuthenticatorType YubikeyToken = new MultifactorEnrollmentPolicyAuthenticatorType("yubikey_token");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref=""/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator MultifactorEnrollmentPolicyAuthenticatorType(string value) => new MultifactorEnrollmentPolicyAuthenticatorType(value);

        /// <summary>
        /// Creates a new <see cref="MultifactorEnrollmentPolicyAuthenticatorType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public MultifactorEnrollmentPolicyAuthenticatorType(string value)
            : base(value)
        {
        }
    }


}
