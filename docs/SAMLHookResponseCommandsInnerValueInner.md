# Okta.Sdk.Model.SAMLHookResponseCommandsInnerValueInner

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Op** | **string** | The name of one of the supported ops: &#x60;add&#x60;:  Add a new claim to the assertion &#x60;replace&#x60;: Modify any element of the assertion  &gt; **Note:** If a response to the SAML assertion inline hook request isn&#39;t received from your external service within three seconds, a timeout occurs. In this scenario, the Okta process flow continues with the original SAML assertion returned. | [optional] 
**Path** | **string** | Location, within the assertion, to apply the operation | [optional] 
**Value** | [**SAMLHookResponseCommandsInnerValueInnerValue**](SAMLHookResponseCommandsInnerValueInnerValue.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

