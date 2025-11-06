# Okta.Sdk.Model.Org2OrgApplicationSettingsApplication
Org2Org app instance properties

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AcsUrl** | **string** | The Assertion Consumer Service (ACS) URL of the source org (for &#x60;SAML_2_0&#x60; sign-on mode) | [optional] 
**AudRestriction** | **string** | The entity ID of the SP (for &#x60;SAML_2_0&#x60; sign-on mode) | [optional] 
**BaseUrl** | **string** | The base URL of the target Okta org (for &#x60;SAML_2_0&#x60; sign-on mode) | 
**CreationState** | **string** | Used to track and manage the state of the app&#39;s creation or the provisioning process between two Okta orgs | [optional] 
**PreferUsernameOverEmail** | **bool** | Indicates that you don&#39;t want to use an email address as the username | [optional] 
**Token** | **string** | An API token from the target org that&#39;s used to secure the connection between the orgs | [optional] 
**TokenEncrypted** | **string** | Encrypted token to enhance security | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

