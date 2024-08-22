# Okta.Sdk.Model.ApiTokenUpdate
An API Token Update Object for an Okta user. This token is NOT scoped any further and can be used for any API that the user has permissions to call.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ClientName** | **string** | The client name associated with the API Token | [optional] [readonly] 
**Created** | **DateTimeOffset** | The creation date of the API Token | [optional] [readonly] 
**Name** | **string** | The name associated with the API Token | [optional] 
**Network** | [**ApiTokenNetwork**](ApiTokenNetwork.md) |  | [optional] 
**UserId** | **string** | The userId of the user who created the API Token | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

