# Okta.Sdk.Model.OAuth2ClientJsonSigningKeyRequest
A [JSON Web Key (JWK)](https://tools.ietf.org/html/rfc7517) is a JSON representation of a cryptographic key. Okta uses signing keys to verify the signature of a JWT when provided for the `private_key_jwt` client authentication method or for a signed authorize request object. Okta supports both RSA and Elliptic Curve (EC) keys for signing tokens.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Kid** | **string** | Unique identifier of the JSON Web Key in the OAUth 2.0 client&#39;s JWKS | [optional] 
**Status** | **string** | Status of the OAuth 2.0 client JSON Web Key | [optional] [default to StatusEnum.ACTIVE]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

