# Okta.Sdk.Model.OAuth2ClientJsonWebKeyECRequest
An EC signing key

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Kty** | **string** | Cryptographic algorithm family for the certificate&#39;s key pair | [optional] 
**X** | **string** | The public x coordinate for the elliptic curve point | [optional] 
**Y** | **string** | The public y coordinate for the elliptic curve point | [optional] 
**Alg** | **string** | Algorithm used in the key | [optional] 
**Kid** | **string** | Unique identifier of the JSON Web Key in the OAUth 2.0 client&#39;s JWKS | [optional] 
**Status** | **string** | Status of the OAuth 2.0 client JSON Web Key | [optional] [default to StatusEnum.ACTIVE]
**Use** | **string** | Acceptable use of the JSON Web Key | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

