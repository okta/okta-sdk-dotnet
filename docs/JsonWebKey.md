# Okta.Sdk.Model.JsonWebKey

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Alg** | **string** | The algorithm used with the Key. Valid value: &#x60;RS256&#x60; | [optional] 
**Created** | **DateTimeOffset** | Timestamp when the object was created | [optional] [readonly] 
**E** | **string** | RSA key value (public exponent) for Key binding | [optional] [readonly] 
**ExpiresAt** | **DateTimeOffset** | Timestamp when the certificate expires | [optional] [readonly] 
**KeyOps** | **List&lt;string&gt;** | Identifies the operation(s) for which the key is intended to be used | [optional] 
**Kid** | **string** | Unique identifier for the certificate | [optional] [readonly] 
**Kty** | **string** | Cryptographic algorithm family for the certificate&#39;s keypair. Valid value: &#x60;RSA&#x60; | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the object was last updated | [optional] [readonly] 
**N** | **string** | RSA modulus value that is used by both the public and private keys and provides a link between them | [optional] 
**Status** | **string** | An &#x60;ACTIVE&#x60; Key is used to sign tokens issued by the authorization server. Supported values: &#x60;ACTIVE&#x60;, &#x60;NEXT&#x60;, or &#x60;EXPIRED&#x60;&lt;br&gt; A &#x60;NEXT&#x60; Key is the next Key that the authorization server uses to sign tokens when Keys are rotated. The &#x60;NEXT&#x60; Key might not be listed if it hasn&#39;t been generated yet. An &#x60;EXPIRED&#x60; Key is the previous Key that the authorization server used to sign tokens. The &#x60;EXPIRED&#x60; Key might not be listed if no Key has expired or the expired Key was deleted. | [optional] 
**Use** | **string** | Acceptable use of the certificate. Valid value: &#x60;sig&#x60; | [optional] [readonly] 
**X5c** | **List&lt;string&gt;** | X.509 certificate chain that contains a chain of one or more certificates | [optional] 
**X5t** | **string** | X.509 certificate SHA-1 thumbprint, which is the base64url-encoded SHA-1 thumbprint (digest) of the DER encoding of an X.509 certificate | [optional] [readonly] 
**X5tS256** | **string** | X.509 certificate SHA-256 thumbprint, which is the base64url-encoded SHA-256 thumbprint (digest) of the DER encoding of an X.509 certificate | [optional] [readonly] 
**X5u** | **string** | A URI that refers to a resource for the X.509 public key certificate or certificate chain corresponding to the key used to digitally sign the JWS (JSON Web Signature) | [optional] [readonly] 
**Links** | [**LinksSelf**](LinksSelf.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

