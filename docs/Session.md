# Okta.Sdk.Model.Session

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Amr** | [**List&lt;SessionAuthenticationMethod&gt;**](SessionAuthenticationMethod.md) | Authentication method reference | [optional] [readonly] 
**CreatedAt** | **DateTimeOffset** |  | [optional] [readonly] 
**ExpiresAt** | **DateTimeOffset** | A timestamp when the Session expires | [optional] [readonly] 
**Id** | **string** | A unique key for the Session | [optional] [readonly] 
**Idp** | [**SessionIdentityProvider**](SessionIdentityProvider.md) |  | [optional] 
**LastFactorVerification** | **DateTimeOffset** | A timestamp when the user last performed multifactor authentication | [optional] [readonly] 
**LastPasswordVerification** | **DateTimeOffset** | A timestamp when the user last performed the primary or step-up authentication with a password | [optional] [readonly] 
**Login** | **string** | A unique identifier for the user (username) | [optional] [readonly] 
**Status** | **SessionStatus** |  | [optional] 
**UserId** | **string** | A unique key for the user | [optional] [readonly] 
**Links** | [**LinksSelf**](LinksSelf.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

