# Okta.Sdk.Model.Saml11ApplicationSettingsSignOn
SAML 1.1 sign-on mode attributes

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AudienceOverride** | **string** | The intended audience of the SAML assertion. This is usually the Entity ID of your application. | [optional] 
**DefaultRelayState** | **string** | The URL of the resource to direct users after they successfully sign in to the SP using SAML. See the SP documentation to check if you need to specify a RelayState. In most instances, you can leave this field blank. | [optional] 
**RecipientOverride** | **string** | The location where the application can present the SAML assertion. This is usually the Single Sign-On (SSO) URL. | [optional] 
**SsoAcsUrlOverride** | **string** | Assertion Consumer Services (ACS) URL value for the Service Provider (SP). This URL is always used for Identity Provider (IdP) initiated sign-on requests. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

