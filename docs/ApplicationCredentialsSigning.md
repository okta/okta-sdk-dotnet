# Okta.Sdk.Model.ApplicationCredentialsSigning
App signing key properties > **Note:** Only apps with SAML_2_0, SAML_1_1, WS_FEDERATION, or OPENID_CONNECT `signOnMode` support the key rotation feature. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Kid** | **string** | Key identifier used for signing assertions &gt; **Note:** Currently, only the X.509 JWK format is supported for apps with SAML_2_0 &#x60;signOnMode&#x60;. | [optional] 
**LastRotated** | **DateTimeOffset** | Timestamp when the signing key was last rotated | [optional] [readonly] 
**NextRotation** | **DateTimeOffset** | The scheduled time for the next signing key rotation | [optional] [readonly] 
**RotationMode** | **string** | The mode of key rotation | [optional] 
**Use** | **ApplicationCredentialsSigningUse** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

