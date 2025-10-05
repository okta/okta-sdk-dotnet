# Okta.Sdk.Model.PasswordPolicyPasswordSettingsAge
Age settings

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ExpireWarnDays** | **int** | Specifies the number of days prior to password expiration when a User is warned to reset their password: &#x60;0&#x60; indicates no warning | [optional] [default to 0]
**HistoryCount** | **int** | Specifies the number of distinct passwords that a User must create before they can reuse a previous password: &#x60;0&#x60; indicates none | [optional] [default to 0]
**MaxAgeDays** | **int** | Specifies how long (in days) a password remains valid before it expires: &#x60;0&#x60; indicates no limit | [optional] [default to 0]
**MinAgeMinutes** | **int** | Specifies the minimum time interval (in minutes) between password changes: &#x60;0&#x60; indicates no limit | [optional] [default to 0]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

