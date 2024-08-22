# Okta.Sdk.Model.UserFactorActivatePush
Activation requests have a short lifetime and expire if activation isn't completed before the indicated timestamp. If the activation expires, use the returned `activate` link to restart the process.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ExpiresAt** | **DateTimeOffset** | Timestamp when the Factor verification attempt expires | [optional] [readonly] 
**FactorResult** | **UserFactorActivatePushResponseType** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

