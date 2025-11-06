# Okta.Sdk.Model.JsonWebKey

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset** | Timestamp when the object was created | [optional] [readonly] 
**E** | **string** | RSA key value (public exponent) for Key binding | [optional] [readonly] 
**ExpiresAt** | **DateTimeOffset** | Timestamp when the certificate expires | [optional] [readonly] 
**Kid** | **string** | Unique identifier for the certificate | [optional] [readonly] 
**Kty** | **string** | Cryptographic algorithm family for the certificate&#39;s keypair. Valid value: &#x60;RSA&#x60; | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the object was last updated | [optional] [readonly] 
**N** | **string** | RSA modulus value that is used by both the public and private keys and provides a link between them | [optional] 
**Use** | **string** | Acceptable use of the certificate. Valid value: &#x60;sig&#x60; | [optional] [readonly] 
**X5c** | **List&lt;string&gt;** | X.509 certificate chain that contains a chain of one or more certificates | [optional] [readonly] 
**X5tS256** | **string** | X.509 certificate SHA-256 thumbprint, which is the base64url-encoded SHA-256 thumbprint (digest) of the DER encoding of an X.509 certificate | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

