# Okta.Sdk.Model.EnrollmentInitializationResponse
Yubico transport key in the form of a JSON Web Token (JWK), used to encrypt our fulfillment request to Yubico. The currently agreed protocol uses P-384.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CredRequests** | [**List&lt;WebAuthnCredRequest&gt;**](WebAuthnCredRequest.md) | List of credential requests for the fulfillment provider | [optional] 
**FulfillmentProvider** | **string** | Name of the fulfillment provider for the WebAuthn preregistration factor | [optional] 
**PinRequestJwe** | **string** | Encrypted JWE of PIN request for the fulfillment provider | [optional] 
**UserId** | **string** | ID of an existing Okta user | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

