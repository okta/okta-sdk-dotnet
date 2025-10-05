# Okta.Sdk.Model.SocialAuthToken
The social authentication token object provides the tokens and associated metadata provided by social providers during social authentication.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ExpiresAt** | **DateTimeOffset** | Timestamp when the object expires | [optional] [readonly] 
**Id** | **string** | Unique identifier for the token | [optional] [readonly] 
**Scopes** | **List&lt;string&gt;** | The scopes that the token is good for | [optional] [readonly] 
**Token** | **string** | The raw token | [optional] [readonly] 
**TokenAuthScheme** | **string** | The token authentication scheme as defined by the social provider | [optional] [readonly] 
**TokenType** | **string** | The type of token defined by the [OAuth Token Exchange Spec](https://tools.ietf.org/html/draft-ietf-oauth-token-exchange-07#section-3) | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

