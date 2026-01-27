# Okta.Sdk.Model.OAuth2ClientJsonWebKeyRsaRequest
An RSA signing key

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**E** | **string** | RSA key value (exponent) for key binding | [optional] 
**Kty** | **string** | Cryptographic algorithm family for the certificate&#39;s key pair | [optional] 
**N** | **string** | RSA key value (modulus) for key binding | [optional] 
**Alg** | **string** | Algorithm used in the key | [optional] 
**Kid** | **string** | Unique identifier of the JSON Web Key in the OAUth 2.0 client&#39;s JWKS | [optional] 
**Status** | **string** | Status of the OAuth 2.0 client JSON Web Key | [optional] [default to StatusEnum.ACTIVE]
**Use** | **string** | Acceptable use of the JSON Web Key | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

