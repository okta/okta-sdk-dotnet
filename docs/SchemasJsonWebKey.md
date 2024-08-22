# Okta.Sdk.Model.SchemasJsonWebKey
A [JSON Web Key (JWK)](https://tools.ietf.org/html/rfc7517) is a JSON representation of a cryptographic key. Okta can use these keys to verify the signature of a JWT when provided for the `private_key_jwt` client authentication method or for a signed authorize request object. Okta supports both RSA and Elliptic Curve (EC) keys.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Alg** | **SigningAlgorithm** |  | [optional] 
**Kid** | **string** | The unique identifier of the key | [optional] 
**Kty** | **JsonWebKeyType** |  | [optional] 
**Status** | **JsonWebKeyStatus** |  | [optional] 
**Use** | **JsonWebKeyUse** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

