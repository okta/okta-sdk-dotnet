# Okta.Sdk.Model.ApiToken
An API token for an Okta User. This token is NOT scoped any further and can be used for any API the user has permissions to call.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ClientName** | **string** |  | [optional] [readonly] 
**Created** | **DateTimeOffset** |  | [optional] [readonly] 
**ExpiresAt** | **DateTimeOffset** |  | [optional] [readonly] 
**Id** | **string** |  | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** |  | [optional] [readonly] 
**Name** | **string** |  | 
**TokenWindow** | **string** | A time duration specified as an [ISO-8601 duration](https://en.wikipedia.org/wiki/ISO_8601#Durations). | [optional] 
**UserId** | **string** |  | [optional] 
**Link** | [**LinksSelf**](LinksSelf.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

