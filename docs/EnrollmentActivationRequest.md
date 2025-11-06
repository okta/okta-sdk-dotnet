# Okta.Sdk.Model.EnrollmentActivationRequest
Enrollment Initialization Request

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CredResponses** | [**List&lt;WebAuthnCredResponse&gt;**](WebAuthnCredResponse.md) | List of credential responses from the fulfillment provider | [optional] 
**FulfillmentProvider** | **string** | Name of the fulfillment provider for the WebAuthn preregistration factor | [optional] 
**PinResponseJwe** | **string** | Encrypted JWE of the PIN response from the fulfillment provider | [optional] 
**Serial** | **string** | Serial number of the YubiKey | [optional] 
**UserId** | **string** | ID of an existing Okta user | [optional] 
**_Version** | **string** | Firmware version of the YubiKey | [optional] 
**YubicoSigningJwks** | [**List&lt;ECKeyJWK&gt;**](ECKeyJWK.md) | List of usable signing keys from Yubico (in JSON Web Key Sets (JWKS) format). The signing keys are used to verify the JSON Web Signature (JWS) inside the JWE. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

