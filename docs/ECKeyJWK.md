# Okta.Sdk.Model.ECKeyJWK
Elliptic Curve Key in JWK format, currently used during enrollment to encrypt fulfillment requests to Yubico, or during activation to verify Yubico's JWS objects in fulfillment responses. The currently agreed protocol uses P-384.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Crv** | **string** |  | 
**Kid** | **string** | The unique identifier of the key | 
**Kty** | **string** | The type of public key | 
**Use** | **string** | The intended use for the key. The ECKeyJWK is always &#x60;enc&#x60; because Okta uses it to encrypt requests to Yubico. | 
**X** | **string** | The public x coordinate for the elliptic curve point | 
**Y** | **string** | The public y coordinate for the elliptic curve point | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

