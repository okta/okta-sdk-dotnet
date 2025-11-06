# Okta.Sdk.Model.UserFactorVerifyRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**PassCode** | **string** | OTP for the current time window | [optional] 
**UseNumberMatchingChallenge** | **bool** | Select whether to use a number matching challenge for a &#x60;push&#x60; factor.  &gt; **Note:** Sending a request with a body is required when you verify a &#x60;push&#x60; factor with a number matching challenge. | [optional] 
**Answer** | **string** | Answer to the question | [optional] 
**ClientData** | **string** | Base64-encoded client data from the WebAuthn authenticator | [optional] 
**SignatureData** | **string** | Base64-encoded signature data from the WebAuthn authenticator | [optional] 
**AuthenticatorData** | **string** | Base64-encoded authenticator data from the WebAuthn authenticator | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

