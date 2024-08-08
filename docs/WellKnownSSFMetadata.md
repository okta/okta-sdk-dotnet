# Okta.Sdk.Model.WellKnownSSFMetadata
Metadata about Okta as a transmitter and relevant information for configuration.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ConfigurationEndpoint** | **string** | The URL of the SSF Stream configuration endpoint | [optional] 
**DeliveryMethodsSupported** | **List&lt;string&gt;** | An array of supported SET delivery methods | [optional] 
**Issuer** | **string** | The issuer used in Security Event Tokens. This value is set as &#x60;iss&#x60; in the claim. | [optional] 
**JwksUri** | **string** | The URL of the JSON Web Key Set (JWKS) that contains the signing keys for validating the signatures of Security Event Tokens (SETs) | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

