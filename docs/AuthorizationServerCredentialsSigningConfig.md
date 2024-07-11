# Okta.Sdk.Model.AuthorizationServerCredentialsSigningConfig

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Kid** | **string** | The ID of the JSON Web Key used for signing tokens issued by the authorization server | [optional] [readonly] 
**LastRotated** | **DateTimeOffset** | The timestamp when the authorization server started using the &#x60;kid&#x60; for signing tokens | [optional] [readonly] 
**NextRotation** | **DateTimeOffset** | The timestamp when the authorization server changes the Key for signing tokens. This is only returned when &#x60;rotationMode&#x60; is set to &#x60;AUTO&#x60;. | [optional] [readonly] 
**RotationMode** | **AuthorizationServerCredentialsRotationMode** |  | [optional] 
**Use** | **AuthorizationServerCredentialsUse** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

