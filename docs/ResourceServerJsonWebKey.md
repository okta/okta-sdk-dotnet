# Okta.Sdk.Model.ResourceServerJsonWebKey
A [JSON Web Key (JWK)](https://tools.ietf.org/html/rfc7517) is a JSON representation of a cryptographic key. Okta can use the active key to encrypt the access token minted by the authorization server. Okta supports only RSA keys with 'use: enc'.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**E** | **string** | The key exponent of a RSA key | [optional] 
**Kid** | **string** | The unique identifier of the key | [optional] 
**Kty** | **JsonWebKeyType** |  | [optional] 
**N** | **string** | The modulus of the RSA key | [optional] 
**Status** | **JsonWebKeyStatus** |  | [optional] 
**Use** | **JsonWebKeyUse** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

