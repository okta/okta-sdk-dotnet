# Okta.Sdk.Model.SAMLHookResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Commands** | [**List&lt;SAMLHookResponseCommandsInner&gt;**](SAMLHookResponseCommandsInner.md) | The &#x60;commands&#x60; object is where you tell Okta to add additional claims to the assertion or to modify the existing assertion statements.  &#x60;commands&#x60; is an array, allowing you to send multiple commands. In each array element, include a &#x60;type&#x60; property and a &#x60;value&#x60; property. The &#x60;type&#x60; property is where you specify which of the supported commands you want to execute, and &#x60;value&#x60; is where you supply an operand for that command. In the case of the SAML assertion inline hook, the &#x60;value&#x60; property is itself a nested object, in which you specify a particular operation, a path to act on, and a value. | [optional] 
**Error** | [**SAMLHookResponseError**](SAMLHookResponseError.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

