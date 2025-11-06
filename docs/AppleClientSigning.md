# Okta.Sdk.Model.AppleClientSigning
Information used to generate the secret JSON Web Token for the token requests to Apple IdP > **Note:** The `privateKey` property is required for a CREATE request. For an UPDATE request, it can be null and keeps the existing value if it's null. The `privateKey` property isn't returned for LIST and GET requests or UPDATE requests if it's null.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Kid** | **string** | The key ID that you obtained from Apple when you created the private key for the client | [optional] 
**PrivateKey** | **string** | The PKCS \\#8 encoded private key that you created for the client and downloaded from Apple | [optional] 
**TeamId** | **string** | The Team ID associated with your Apple developer account | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

