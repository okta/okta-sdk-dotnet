# Okta.Sdk.Model.OINSaml20ApplicationSettingsSignOn
Contains SAML 2.0 sign-on mode attributes. > **Note:** Set `destinationOverride` to configure any other SAML 2.0 attributes in this section.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AudienceOverride** | **string** | Audience override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm). | [optional] 
**ConfiguredAttributeStatements** | [**List&lt;SamlAttributeStatement&gt;**](SamlAttributeStatement.md) |  | [optional] 
**DefaultRelayState** | **string** | Identifies a specific application resource in an IdP-initiated SSO scenario | [optional] 
**DestinationOverride** | **string** | Destination override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm). | [optional] 
**RecipientOverride** | **string** | Recipient override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm). | [optional] 
**SamlAssertionLifetimeSeconds** | **int** | Determines the SAML app session lifetimes with Okta | [optional] 
**SsoAcsUrlOverride** | **string** | Assertion Consumer Service (ACS) URL override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm). | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

