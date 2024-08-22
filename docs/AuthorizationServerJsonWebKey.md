# Okta.Sdk.Model.AuthorizationServerJsonWebKey

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Alg** | **string** | The algorithm used with the Key. Valid value: &#x60;RS256&#x60; | [optional] 
**E** | **string** | RSA key value (public exponent) for Key binding | [optional] [readonly] 
**Kid** | **string** | Unique identifier for the key | [optional] [readonly] 
**Kty** | **string** | Cryptographic algorithm family for the certificate&#39;s keypair. Valid value: &#x60;RSA&#x60; | [optional] [readonly] 
**N** | **string** | RSA modulus value that is used by both the public and private keys and provides a link between them | [optional] 
**Status** | **string** | An &#x60;ACTIVE&#x60; Key is used to sign tokens issued by the authorization server. Supported values: &#x60;ACTIVE&#x60;, &#x60;NEXT&#x60;, or &#x60;EXPIRED&#x60;&lt;br&gt; A &#x60;NEXT&#x60; Key is the next Key that the authorization server uses to sign tokens when Keys are rotated. The &#x60;NEXT&#x60; Key might not be listed if it hasn&#39;t been generated. An &#x60;EXPIRED&#x60; Key is the previous Key that the authorization server used to sign tokens. The &#x60;EXPIRED&#x60; Key might not be listed if no Key has expired or the expired Key was deleted. | [optional] 
**Use** | **string** | Acceptable use of the key. Valid value: &#x60;sig&#x60; | [optional] [readonly] 
**Links** | [**LinksSelf**](LinksSelf.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

