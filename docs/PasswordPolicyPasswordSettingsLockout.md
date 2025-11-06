# Okta.Sdk.Model.PasswordPolicyPasswordSettingsLockout
Lockout settings

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AutoUnlockMinutes** | **int** | Specifies the time interval (in minutes) a locked account remains locked before it is automatically unlocked: &#x60;0&#x60; indicates no limit | [optional] [default to 0]
**MaxAttempts** | **int** | Specifies the number of times Users can attempt to sign in to their accounts with an invalid password before their accounts are locked: &#x60;0&#x60; indicates no limit | [optional] [default to 10]
**ShowLockoutFailures** | **bool** | Indicates if the User should be informed when their account is locked | [optional] [default to false]
**UserLockoutNotificationChannels** | **List&lt;string&gt;** | How the user is notified when their account becomes locked. The only acceptable values are &#x60;[]&#x60; and &#x60;[&#39;EMAIL&#39;]&#x60;. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

