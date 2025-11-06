# Okta.Sdk.Model.WebAuthnCredRequest
Credential request object for the initialized credential, along with the enrollment and key identifiers to associate with the credential

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AuthenticatorEnrollmentId** | **string** | ID for a WebAuthn preregistration factor in Okta | [optional] 
**CredRequestJwe** | **string** | Encrypted JWE of credential request for the fulfillment provider | [optional] 
**KeyId** | **string** | ID for the Okta response key-pair used to encrypt and decrypt credential requests and responses | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

