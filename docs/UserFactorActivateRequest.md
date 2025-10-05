# Okta.Sdk.Model.UserFactorActivateRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**PassCode** | **string** | OTP for the current time window | [optional] 
**UseNumberMatchingChallenge** | **bool** | Select whether to use a number matching challenge for a &#x60;push&#x60; factor.  &gt; **Note:** Sending a request with a body is required when you verify a &#x60;push&#x60; factor with a number matching challenge. | [optional] 
**ClientData** | **string** | Base64-encoded client data from the WebAuthn authenticator | [optional] 
**RegistrationData** | **string** | Base64-encoded registration data from the U2F token | [optional] 
**Attestation** | **string** | Base64-encoded attestation from the WebAuthn authenticator | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

