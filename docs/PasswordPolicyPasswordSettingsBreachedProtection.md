# Okta.Sdk.Model.PasswordPolicyPasswordSettingsBreachedProtection
Breached Protection settings

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DelegatedWorkflowId** | **string** | The &#x60;id&#x60; of the workflow that runs when a breached password is found during a sign-in attempt. | [optional] 
**ExpireAfterDays** | **int?** | Specifies the number of days after a breached password is found during a sign-in attempt that the user&#39;s password should expire. Valid values: 0 through 10. If set to 0, it happens immediately. | [optional] 
**LogoutEnabled** | **bool?** | (Optional, default is false) If true, you must also specify a value for &#x60;expireAfterDays&#x60;. When enabled, the user&#39;s session(s) are terminated immediately the first time the user&#39;s credentials are detected as part of a breach. | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

