# Okta.Sdk.Model.OktaSignOnPolicyRuleSignonSessionActions
Properties governing the user's session lifetime

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**MaxSessionIdleMinutes** | **int** | Maximum number of minutes that a user session can be idle before the session is ended | [optional] [default to 120]
**MaxSessionLifetimeMinutes** | **int** | Maximum number of minutes (from when the user signs in) that a user&#39;s session is active. Set this to force users to sign in again after the number of specified minutes. Disable by setting to &#x60;0&#x60;. | [optional] [default to 0]
**UsePersistentCookie** | **bool** | If set to &#x60;false&#x60;, user session cookies only last the length of a browser session. If set to &#x60;true&#x60;, user session cookies last across browser sessions. This setting doesn&#39;t impact administrators who can never have persistent session cookies. This property is read-only for the default rule of the default global session policy. | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

