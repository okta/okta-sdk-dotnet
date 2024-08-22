# Okta.Sdk.Model.Oidc
OIDC configuration details

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Doc** | **string** | The URL to your customer-facing instructions for configuring your OIDC integration. See [Customer configuration document guidelines](https://developer.okta.com/docs/guides/submit-app-prereq/main/#customer-configuration-document-guidelines). | 
**InitiateLoginUri** | **string** | The URL to redirect users when they click on your app from their Okta End-User Dashboard | [optional] 
**PostLogoutUris** | **List&lt;string&gt;** | The sign-out redirect URIs for your app. You can send a request to &#x60;/v1/logout&#x60; to sign the user out and redirect them to one of these URIs. | [optional] 
**RedirectUris** | **List&lt;string&gt;** | List of sign-in redirect URIs | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

