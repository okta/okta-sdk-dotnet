# Okta.Sdk.Model.TestInfoOidcTestConfiguration
OIDC test details

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Idp** | **bool** | Read only.&lt;br&gt;Indicates if your integration supports IdP-initiated sign-in flows. If [&#x60;sso.oidc.initiateLoginUri&#x60;](/openapi/okta-management/management/tag/YourOinIntegrations/#tag/YourOinIntegrations/operation/createSubmission!path&#x3D;sso/oidc/initiateLoginUri&amp;t&#x3D;request) is specified, this property is set to &#x60;true&#x60;. If [&#x60;sso.oidc.initiateLoginUri&#x60;](/openapi/okta-management/management/tag/YourOinIntegrations/#tag/YourOinIntegrations/operation/createSubmission!path&#x3D;sso/oidc/initiateLoginUri&amp;t&#x3D;request) isn&#39;t set for the integration submission, this property is set to &#x60;false&#x60; | [optional] [readonly] 
**Sp** | **bool** | Read only.&lt;br&gt;Indicates if your integration supports SP-initiated sign-in flows and is always set to &#x60;true&#x60; for OIDC SSO | [optional] [readonly] 
**Jit** | **bool** | Indicates if your integration supports Just-In-Time (JIT) provisioning | [optional] 
**SpInitiateUrl** | **string** | URL for SP-initiated sign-in flows (required if &#x60;sp &#x3D; true&#x60;) | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

