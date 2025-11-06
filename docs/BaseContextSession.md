# Okta.Sdk.Model.BaseContextSession
Details of the user session

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | The unique identifier for the user&#39;s session | [optional] 
**UserId** | **string** | The unique identifier for the user | [optional] 
**Login** | **string** | The username used to identify the user. This is often the user&#39;s email address. | [optional] 
**CreatedAt** | **DateTimeOffset** | Timestamp of when the session was created | [optional] 
**ExpiresAt** | **DateTimeOffset** | Timestamp of when the session expires | [optional] 
**Status** | **string** | Represents the current status of the user&#39;s session | [optional] 
**LastPasswordVerification** | **DateTimeOffset** | Timestamp of when the user was last authenticated | [optional] 
**Amr** | **List&lt;string&gt;** | The authentication method reference | [optional] 
**Idp** | [**SessionIdentityProvider**](SessionIdentityProvider.md) |  | [optional] 
**MfaActive** | **bool** | Describes whether multifactor authentication was enabled | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

