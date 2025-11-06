# Okta.Sdk.Model.WellKnownSSFMetadata
Metadata about Okta as a transmitter and relevant information for configuration.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AuthorizationSchemes** | [**List&lt;WellKnownSSFMetadataSpecUrn&gt;**](WellKnownSSFMetadataSpecUrn.md) | An array of JSON objects that specify the authorization scheme properties supported by the transmitter | [optional] 
**ConfigurationEndpoint** | **string** | The URL of the SSF Stream configuration endpoint | [optional] 
**DefaultSubjects** | **string** | A string that indicates the default behavior of newly created streams | [optional] 
**DeliveryMethodsSupported** | **List&lt;string&gt;** | An array of supported SET delivery methods | [optional] 
**Issuer** | **string** | The issuer used in Security Event Tokens. This value is set as &#x60;iss&#x60; in the claim. | [optional] 
**JwksUri** | **string** | The URL of the JSON Web Key Set (JWKS) that contains the signing keys for validating the signatures of Security Event Tokens (SETs) | [optional] 
**SpecVersion** | **string** | The version identifying the implementer&#39;s draft or final specification implemented by the transmitter | [optional] 
**VerificationEndpoint** | **string** | The URL of the SSF Stream verification endpoint | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

