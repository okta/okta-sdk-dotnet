/*
 * Okta Admin Management
 *
 * Allows customers to easily access the Okta Management APIs
 *
 * The version of the OpenAPI document: 2024.07.0
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
    /// All Okta orgs contain only one IdP Discovery Policy with an immutable default Rule routing to your org&#39;s sign-in page.  Creating or replacing a policy with &#x60;IDP_DISCOVERY&#x60; type isn&#39;t supported. The following policy types are available with the Okta Identity Engine: &#x60;ACCESS_POLICY&#x60;, &#x60;PROFILE_ENROLLMENT&#x60;, &#x60;CONTINUOUS_ACCESS&#x60;, and &#x60;ENTITY_RISK&#x60;. The &#x60;CONTINUOUS_ACCESS&#x60;, and &#x60;ENTITY_RISK&#x60;  policy types are in Early Access (EA). Contact your Okta account team to enable these features.
    /// </summary>
    /// <value>All Okta orgs contain only one IdP Discovery Policy with an immutable default Rule routing to your org&#39;s sign-in page.  Creating or replacing a policy with &#x60;IDP_DISCOVERY&#x60; type isn&#39;t supported. The following policy types are available with the Okta Identity Engine: &#x60;ACCESS_POLICY&#x60;, &#x60;PROFILE_ENROLLMENT&#x60;, &#x60;CONTINUOUS_ACCESS&#x60;, and &#x60;ENTITY_RISK&#x60;. The &#x60;CONTINUOUS_ACCESS&#x60;, and &#x60;ENTITY_RISK&#x60;  policy types are in Early Access (EA). Contact your Okta account team to enable these features.</value>
    [JsonConverter(typeof(StringEnumSerializingConverter))]
    public sealed class PolicyType : StringEnum
    {
        /// <summary>
        /// StringEnum PolicyType for value: OKTA_SIGN_ON
        /// </summary>
        public static PolicyType OKTASIGNON = new PolicyType("OKTA_SIGN_ON");
        /// <summary>
        /// StringEnum PolicyType for value: PASSWORD
        /// </summary>
        public static PolicyType PASSWORD = new PolicyType("PASSWORD");
        /// <summary>
        /// StringEnum PolicyType for value: MFA_ENROLL
        /// </summary>
        public static PolicyType MFAENROLL = new PolicyType("MFA_ENROLL");
        /// <summary>
        /// StringEnum PolicyType for value: IDP_DISCOVERY
        /// </summary>
        public static PolicyType IDPDISCOVERY = new PolicyType("IDP_DISCOVERY");
        /// <summary>
        /// StringEnum PolicyType for value: ACCESS_POLICY
        /// </summary>
        public static PolicyType ACCESSPOLICY = new PolicyType("ACCESS_POLICY");
        /// <summary>
        /// StringEnum PolicyType for value: PROFILE_ENROLLMENT
        /// </summary>
        public static PolicyType PROFILEENROLLMENT = new PolicyType("PROFILE_ENROLLMENT");
        /// <summary>
        /// StringEnum PolicyType for value: POST_AUTH_SESSION
        /// </summary>
        public static PolicyType POSTAUTHSESSION = new PolicyType("POST_AUTH_SESSION");
        /// <summary>
        /// StringEnum PolicyType for value: ENTITY_RISK
        /// </summary>
        public static PolicyType ENTITYRISK = new PolicyType("ENTITY_RISK");

        /// <summary>
        /// Implicit operator declaration to accept and convert a string value as a <see cref="PolicyType"/>
        /// </summary>
        /// <param name="value">The value to use</param>
        public static implicit operator PolicyType(string value) => new PolicyType(value);

        /// <summary>
        /// Creates a new <see cref="PolicyType"/> instance.
        /// </summary>
        /// <param name="value">The value to use.</param>
        public PolicyType(string value)
            : base(value)
        {
        }
    }


}
