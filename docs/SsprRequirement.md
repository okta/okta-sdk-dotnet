# Okta.Sdk.Model.SsprRequirement
<x-lifecycle class=\"oie\"></x-lifecycle> Describes the initial and secondary authenticator requirements a user needs to reset their password

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccessControl** | **string** | Determines which authentication requirements a user needs to perform self-service operations. &#x60;AUTH_POLICY&#x60; defers conditions and authentication requirements to the [Okta account management policy](https://developer.okta.com/docs/guides/okta-account-management-policy/main/). &#x60;LEGACY&#x60; refers to the requirements described by this rule. | [optional] 
**Primary** | [**SsprPrimaryRequirement**](SsprPrimaryRequirement.md) |  | [optional] 
**StepUp** | [**SsprStepUpRequirement**](SsprStepUpRequirement.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

