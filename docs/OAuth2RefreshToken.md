# Okta.Sdk.Model.OAuth2RefreshToken

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ClientId** | **string** | Client ID | [optional] 
**Created** | **DateTimeOffset** | Timestamp when the object was created | [optional] [readonly] 
**ExpiresAt** | **DateTimeOffset** | Expiration time of the OAuth 2.0 Token | [optional] [readonly] 
**Id** | **string** | ID of the Token object | [optional] [readonly] 
**Issuer** | **string** | The complete URL of the authorization server that issued the Token | [optional] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the object was last updated | [optional] [readonly] 
**Scopes** | **List&lt;string&gt;** | The scope names attached to the Token | [optional] 
**Status** | **GrantOrTokenStatus** |  | [optional] 
**UserId** | **string** | The ID of the user associated with the Token | [optional] 
**Embedded** | [**OAuth2RefreshTokenEmbedded**](OAuth2RefreshTokenEmbedded.md) |  | [optional] 
**Links** | [**OAuth2RefreshTokenLinks**](OAuth2RefreshTokenLinks.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

