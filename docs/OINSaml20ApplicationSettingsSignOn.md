# Okta.Sdk.Model.OINSaml20ApplicationSettingsSignOn
Contains SAML 2.0 sign-on mode attributes. > **Note:** Set `destinationOverride` to configure any other SAML 2.0 attributes in this section.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AttributeStatements** | [**List&lt;SamlAttributeStatement&gt;**](SamlAttributeStatement.md) | A list of custom attribute statements for the app&#39;s SAML assertion. See [SAML 2.0 Technical Overview](https://docs.oasis-open.org/security/saml/Post2.0/sstc-saml-tech-overview-2.0-cd-02.html).  There are two types of attribute statements: | Type | Description | | - -- - | - -- -- -- -- -- | | EXPRESSION | Generic attribute statement that can be dynamic and supports [Okta Expression Language](https://developer.okta.com/docs/reference/okta-expression-language/) | | GROUP | Group attribute statement |  | [optional] 
**AudienceOverride** | **string** | Audience override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm). | [optional] 
**DefaultRelayState** | **string** | Identifies a specific application resource in an IdP-initiated SSO scenario | [optional] 
**DestinationOverride** | **string** | Destination override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm). | [optional] 
**RecipientOverride** | **string** | Recipient override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm). | [optional] 
**SamlAssertionLifetimeSeconds** | **int** | Determines the SAML app session lifetimes with Okta | [optional] 
**SsoAcsUrlOverride** | **string** | Assertion Consumer Service (ACS) URL override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm). | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

