# Okta.Sdk.Model.IdPCsr
Defines a CSR for a signature or decryption credential for an IdP

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset** | Timestamp when the object was created | [optional] [readonly] 
**Csr** | **string** | Base64-encoded CSR in DER format | [optional] [readonly] 
**Id** | **string** | Unique identifier for the CSR | [optional] [readonly] 
**Kty** | **string** | Cryptographic algorithm family for the CSR&#39;s keypair | [optional] 
**Links** | [**IdPCsrLinks**](IdPCsrLinks.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

