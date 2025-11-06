# Okta.Sdk.Model.SamlApplicationSettingsSignOn
SAML 2.0 sign-on attributes. > **Note:** Set either `destinationOverride` or `ssoAcsUrl` to configure any other SAML 2.0 attributes in this section.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AcsEndpoints** | [**List&lt;AcsEndpoint&gt;**](AcsEndpoint.md) | An array of ACS endpoints. You can configure a maximum of 100 endpoints. | [optional] 
**AllowMultipleAcsEndpoints** | **bool** | Determines whether the app allows you to configure multiple ACS URIs | 
**AssertionEncryption** | [**SamlAssertionEncryption**](SamlAssertionEncryption.md) |  | [optional] 
**AssertionSigned** | **bool** | Determines whether the SAML assertion is digitally signed | 
**AttributeStatements** | [**List&lt;SamlAttributeStatement&gt;**](SamlAttributeStatement.md) | A list of custom attribute statements for the app&#39;s SAML assertion. See [SAML 2.0 Technical Overview](https://docs.oasis-open.org/security/saml/Post2.0/sstc-saml-tech-overview-2.0-cd-02.html).  There are two types of attribute statements: | Type | Description | | - -- - | - -- -- -- -- -- | | EXPRESSION | Generic attribute statement that can be dynamic and supports [Okta Expression Language](https://developer.okta.com/docs/reference/okta-expression-language/) | | GROUP | Group attribute statement |  | [optional] 
**Audience** | **string** | The entity ID of the SP. Use the entity ID value exactly as provided by the SP. | 
**AudienceOverride** | **string** | Audience override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm). | [optional] 
**AuthnContextClassRef** | **string** | Identifies the SAML authentication context class for the assertion&#39;s authentication statement | 
**ConfiguredAttributeStatements** | [**List&lt;SamlAttributeStatement&gt;**](SamlAttributeStatement.md) | The list of dynamic attribute statements for the SAML assertion inherited from app metadata (apps from the OIN) during app creation.  There are two types of attribute statements: &#x60;EXPRESSION&#x60; and &#x60;GROUP&#x60;.  | [optional] 
**DefaultRelayState** | **string** | Identifies a specific application resource in an IdP-initiated SSO scenario | [optional] 
**Destination** | **string** | Identifies the location inside the SAML assertion where the SAML response should be sent | 
**DestinationOverride** | **string** | Destination override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm). | [optional] 
**DigestAlgorithm** | **string** | Determines the digest algorithm used to digitally sign the SAML assertion and response | 
**HonorForceAuthn** | **bool** | Set to &#x60;true&#x60; to prompt users for their credentials when a SAML request has the &#x60;ForceAuthn&#x60; attribute set to &#x60;true&#x60; | 
**IdpIssuer** | **string** | SAML Issuer ID | 
**InlineHooks** | [**List&lt;SignOnInlineHook&gt;**](SignOnInlineHook.md) | Associates the app with SAML inline hooks. See [the SAML assertion inline hook reference](https://developer.okta.com/docs/reference/saml-hook/). | [optional] 
**ParticipateSlo** | [**SloParticipate**](SloParticipate.md) |  | [optional] 
**Recipient** | **string** | The location where the app may present the SAML assertion | 
**RecipientOverride** | **string** | Recipient override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm). | [optional] 
**RequestCompressed** | **bool** | Determines whether the SAML request is expected to be compressed | 
**ResponseSigned** | **bool** | Determines whether the SAML authentication response message is digitally signed by the IdP &gt; **Note:** Either (or both) &#x60;responseSigned&#x60; or &#x60;assertionSigned&#x60; must be &#x60;TRUE&#x60;. | 
**SamlAssertionLifetimeSeconds** | **int** | Determines the SAML app session lifetimes with Okta | [optional] 
**SignatureAlgorithm** | **string** | Determines the signing algorithm used to digitally sign the SAML assertion and response | 
**Slo** | [**SingleLogout**](SingleLogout.md) |  | [optional] 
**SpCertificate** | [**SamlSpCertificate**](SamlSpCertificate.md) |  | [optional] 
**SpIssuer** | **string** | The issuer ID for the Service Provider. This property appears when SLO is enabled. | [optional] 
**SsoAcsUrl** | **string** | Single Sign-On Assertion Consumer Service (ACS) URL | 
**SsoAcsUrlOverride** | **string** | Assertion Consumer Service (ACS) URL override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm). | [optional] 
**SubjectNameIdFormat** | **string** | Identifies the SAML processing rules. Supported values: | 
**SubjectNameIdTemplate** | **string** | Template for app user&#39;s username when a user is assigned to the app | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

