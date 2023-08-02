# Okta.Sdk.Model.SsprStepUpRequirement
Defines the secondary authenticators needed for password reset if `required` is true. The following are three valid configurations: * `required`=false * `required`=true with no methods to use any SSO authenticator * `required`=true with `security_question` as the method

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Methods** | **List&lt;string&gt;** | Authenticator methods required for secondary authentication step of password recovery. Specify this value only when &#x60;required&#x60; is true and &#x60;security_question&#x60; is permitted for the secondary authentication. | [optional] 
**Required** | **bool** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

