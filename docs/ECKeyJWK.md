# Okta.Sdk.Model.ECKeyJWK
Elliptic curve key in JSON Web Key (JWK) format. It's used during enrollment to encrypt fulfillment requests to Yubico, or during activation to verify Yubico's JWS (JSON Web Signature) objects in fulfillment responses. The currently agreed protocol uses P-384.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Crv** | **string** | The elliptic curve protocol | 
**Kid** | **string** | The unique identifier of the key | 
**Kty** | **string** | The type of public key | 
**Use** | **string** | The intended use for the key. This value is either &#x60;enc&#x60; (encryption) during enrollment, when Okta uses the ECKeyJWK to encrypt requests to Yubico. Or it&#39;s &#x60;sig&#x60; (signature) during activation, when Okta uses the ECKeyJWK to verify the responses from Yubico. | 
**X** | **string** | The public x coordinate for the elliptic curve point | 
**Y** | **string** | The public y coordinate for the elliptic curve point | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

