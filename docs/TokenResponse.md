# Okta.Sdk.Model.TokenResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccessToken** | **string** | An access token. | [optional] 
**DeviceSecret** | **string** | An opaque device secret. This is returned if the &#x60;device_sso&#x60; scope is granted. | [optional] 
**ExpiresIn** | **int** | The expiration time of the access token in seconds. | [optional] 
**IdToken** | **string** | An ID token. This is returned if the &#x60;openid&#x60; scope is granted. | [optional] 
**IssuedTokenType** | **TokenType** |  | [optional] 
**RefreshToken** | **string** | An opaque refresh token. This is returned if the &#x60;offline_access&#x60; scope is granted. | [optional] 
**Scope** | **string** | The scopes contained in the access token. | [optional] 
**TokenType** | **TokenResponseTokenType** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

