# Okta.Sdk.Model.UserFactorVerifyRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ActivationToken** | **string** |  | [optional] 
**Answer** | **string** | Answer to the question | [optional] 
**Attestation** | **string** | Base64-encoded attestation from the WebAuthn JavaScript call | [optional] 
**ClientData** | **string** | Base64-encoded client data from the WebAuthn authenticator | [optional] 
**NextPassCode** | **int** | OTP for the next time window | [optional] 
**PassCode** | **string** | OTP for the current time window | [optional] 
**RegistrationData** | **string** | Base64-encoded registration data from the U2F JavaScript call | [optional] 
**StateToken** | **string** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

