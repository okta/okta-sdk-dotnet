# Okta.Sdk.Model.DeviceAccessPolicyRuleCondition
<x-lifecycle class=\"oie\"></x-lifecycle> Specifies the device condition to match on

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Assurance** | [**DevicePolicyRuleConditionAssurance**](DevicePolicyRuleConditionAssurance.md) |  | [optional] 
**Managed** | **bool** | Indicates if the device is managed. A device is considered managed if it&#39;s part of a device management system. | [optional] 
**Registered** | **bool** | Indicates if the device is registered. A device is registered if the User enrolls with Okta Verify that&#39;s installed on the device. When the &#x60;managed&#x60; property is passed, you must also include the &#x60;registered&#x60; property and set it to &#x60;true&#x60;.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

