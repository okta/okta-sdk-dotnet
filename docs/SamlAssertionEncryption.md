# Okta.Sdk.Model.SamlAssertionEncryption
Determines if the app supports encrypted assertions

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Enabled** | **bool** | Indicates whether Okta encrypts the assertions that it sends to the Service Provider | [optional] 
**EncryptionAlgorithm** | **string** | The encryption algorithm used to encrypt the SAML assertion | [optional] 
**KeyTransportAlgorithm** | **string** | The key transport algorithm used to encrypt the SAML assertion | [optional] 
**X5c** | **List&lt;string&gt;** | A list that contains exactly one x509 encoded certificate which Okta uses to encrypt the SAML assertion with | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

