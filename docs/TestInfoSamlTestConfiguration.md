# Okta.Sdk.Model.TestInfoSamlTestConfiguration
SAML test details

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Idp** | **bool** | Indicates if your integration supports IdP-initiated sign-in | [optional] 
**Sp** | **bool** | Indicates if your integration supports SP-initiated sign-in | [optional] 
**Jit** | **bool** | Indicates if your integration supports Just-In-Time (JIT) provisioning | [optional] 
**SpInitiateUrl** | **string** | URL for SP-initiated sign-in flows (required if &#x60;sp &#x3D; true&#x60;) | 
**SpInitiateDescription** | **string** | Instructions on how to sign in to your app using the SP-initiated flow (required if &#x60;sp &#x3D; true&#x60;) | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

