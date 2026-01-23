# Okta.Sdk.Model.OAuth2ClientJsonEncryptionKeyRequest
<x-lifecycle-container><x-lifecycle class=\"ea\"></x-lifecycle></x-lifecycle-container>A [JSON Web Key (JWK)](https://tools.ietf.org/html/rfc7517) is a JSON representation of a cryptographic key. Okta uses an encryption key to encrypt an ID token JWT minted by the org authorization server or custom authorization server. Okta supports only RSA keys for encrypting tokens.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**E** | **string** | RSA key value (exponent) for key binding | [optional] 
**Kty** | **string** | Cryptographic algorithm family for the certificate&#39;s key pair | [optional] 
**N** | **string** | RSA key value (modulus) for key binding | [optional] 
**Use** | **string** | Acceptable use of the JSON Web Key | [optional] 
**Alg** | **string** | Algorithm used in the key | [optional] 
**Kid** | **string** | Unique identifier of the JSON Web Key in the OAUth 2.0 client&#39;s JWKS | [optional] 
**Status** | **string** | Status of the OAuth 2.0 client JSON Web Key | [optional] [default to StatusEnum.ACTIVE]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

