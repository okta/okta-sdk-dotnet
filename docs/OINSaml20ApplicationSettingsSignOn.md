# Okta.Sdk.Model.OINSaml20ApplicationSettingsSignOn
Contains the sign-in attributes available when configuring an app with `SAML_2_0` as the `signOnMode`

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DefaultRelayState** | **string** | Identifies a specific application resource in an IDP-initiated SSO scenario | [optional] 
**SsoAcsUrlOverride** | **string** | Assertion Consumer Service URL override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm) | [optional] 
**AudienceOverride** | **string** | Audience override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm) | [optional] 
**RecipientOverride** | **string** | Recipient override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm) | [optional] 
**SignOnMode** | **Object** |  | [optional] 
**DestinationOverride** | **string** | Destination override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm) | 
**HonorForceAuthn** | **bool** | Set to &#x60;true&#x60; to prompt users for their credentials when a SAML request has the &#x60;ForceAuthn&#x60; attribute set to &#x60;true&#x60; | [optional] 
**ConfiguredAttributeStatements** | [**List&lt;SamlAttributeStatement&gt;**](SamlAttributeStatement.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

