# Okta.Sdk.Model.HookKey
The `id` property in the response as `id` serves as the unique ID for the key, which you can specify when invoking other CRUD operations.   The `keyId` provided in the response is the alias of the public key that you can use to get details of the public key data in a separate call.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset?** | Timestamp when the key was created | [optional] [readonly] 
**Id** | **string** | The unique identifier for the key | [optional] [readonly] 
**IsUsed** | **bool** | Whether this key is currently in use by other applications | [optional] [readonly] 
**KeyId** | **string** | The alias of the public key | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset?** | Timestamp when the key was updated | [optional] [readonly] 
**Name** | **string** | Display name of the key | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

