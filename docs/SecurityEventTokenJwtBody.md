# Okta.Sdk.Model.SecurityEventTokenJwtBody
JSON Web Token body payload for a Security Event Token sent by the SSF Transmitter. For examples and more information, see [SSF Transmitter SET payload structures](https://developer.okta.com/docs/reference/ssf-transmitter-sets).

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Aud** | **string** | Audience | 
**Events** | [**SecurityEventTokenJwtEvents**](SecurityEventTokenJwtEvents.md) |  | 
**Iat** | **long** | Token issue time (UNIX timestamp) | 
**Iss** | **string** | Token issuer | 
**Jti** | **string** | Token ID | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

