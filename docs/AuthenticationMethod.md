# Okta.Sdk.Model.AuthenticationMethod

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**HardwareProtection** | **string** | Indicates if any secrets or private keys used during authentication must be hardware protected and not exportable. This property is only set for &#x60;POSSESSION&#x60; constraints. | [optional] [default to HardwareProtectionEnum.OPTIONAL]
**Id** | **string** | An ID that identifies the authenticator | [optional] 
**Key** | **string** | A label that identifies the authenticator | 
**Method** | **string** | Specifies the method used for the authenticator | 
**PhishingResistant** | **string** | Indicates if phishing-resistant Factors are required. This property is only set for &#x60;POSSESSION&#x60; constraints | [optional] [default to PhishingResistantEnum.OPTIONAL]
**UserVerification** | **string** | Indicates if a user is required to be verified with a verification method. | [optional] [default to UserVerificationEnum.OPTIONAL]
**UserVerificationMethods** | **List&lt;string&gt;** | Indicates which methods can be used for user verification. &#x60;userVerificationMethods&#x60; can only be used when &#x60;userVerification&#x60; is &#x60;REQUIRED&#x60;. &#x60;BIOMETRICS&#x60; is currently the only supported method. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

