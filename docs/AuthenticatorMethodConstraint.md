# Okta.Sdk.Model.AuthenticatorMethodConstraint
Limits the authenticators that can be used for a given method. Currently, only the `otp` method supports constraints, and Google authenticator (key : 'google_otp') is the only allowed authenticator.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Method** | **string** |  | [optional] 
**AllowedAuthenticators** | [**List&lt;AuthenticatorIdentity&gt;**](AuthenticatorIdentity.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

