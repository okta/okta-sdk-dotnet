# Okta.Sdk.Model.IdPKeyCredential
A [JSON Web Key](https://tools.ietf.org/html/rfc7517) for a signature or encryption credential for an IdP

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset** | Timestamp when the object was created | [optional] [readonly] 
**E** | **string** | The exponent value for the RSA public key | [optional] 
**ExpiresAt** | **DateTimeOffset** | Timestamp when the object expires | [optional] [readonly] 
**Kid** | **string** | Unique identifier for the key | [optional] 
**Kty** | **string** | Identifies the cryptographic algorithm family used with the key | [optional] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the object was last updated | [optional] [readonly] 
**N** | **string** | The modulus value for the RSA public key | [optional] 
**Use** | **string** | Intended use of the public key | [optional] 
**X5c** | **List&lt;string&gt;** | Base64-encoded X.509 certificate chain with DER encoding | [optional] 
**X5tS256** | **string** | Base64url-encoded SHA-256 thumbprint of the DER encoding of an X.509 certificate | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

