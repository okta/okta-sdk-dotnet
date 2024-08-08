# Okta.Sdk.Model.OAuth2Token

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ClientId** | **string** | Client ID | [optional] [readonly] 
**Created** | **DateTimeOffset** | Timestamp when the object was created | [optional] [readonly] 
**ExpiresAt** | **DateTimeOffset** | Expiration time of the OAuth 2.0 Token | [optional] [readonly] 
**Id** | **string** | ID of the Token object | [optional] [readonly] 
**Issuer** | **string** | The complete URL of the authorization server that issued the Token | [optional] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the object was last updated | [optional] [readonly] 
**Scopes** | **List&lt;string&gt;** | Name of scopes attached to the Token | [optional] 
**Status** | **GrantOrTokenStatus** |  | [optional] 
**UserId** | **string** |  | [optional] 
**Embedded** | **Dictionary&lt;string, Object&gt;** | Embedded resources related to the object if the &#x60;expand&#x60; query parameter is specified | [optional] [readonly] 
**Links** | [**LinksSelf**](LinksSelf.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

