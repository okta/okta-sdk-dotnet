# Okta.Sdk.Model.OAuth2ResourceServerJsonWebKey

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **string** | Timestamp when the JSON Web Key was created | [optional] [readonly] 
**E** | **string** | RSA key value (exponent) for key binding | [optional] 
**Id** | **string** | The unique ID of the JSON Web Key | [optional] [readonly] 
**Kid** | **string** | Unique identifier of the JSON Web Key in the Custom Authorization Server&#39;s Public JWKS | [optional] 
**Kty** | **string** | Cryptographic algorithm family for the certificate&#39;s key pair | [optional] 
**LastUpdated** | **string** | Timestamp when the JSON Web Key was updated | [optional] [readonly] 
**N** | **string** | RSA key value (modulus) for key binding | [optional] 
**Status** | **string** | The status of the encryption key. You can use only an &#x60;ACTIVE&#x60; key to encrypt tokens issued by the authorization server. | [optional] [default to StatusEnum.ACTIVE]
**Use** | **string** | Acceptable use of the JSON Web Key | [optional] 
**Links** | [**OAuthResourceServerKeyLinks**](OAuthResourceServerKeyLinks.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

