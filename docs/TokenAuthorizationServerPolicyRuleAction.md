# Okta.Sdk.Model.TokenAuthorizationServerPolicyRuleAction

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccessTokenLifetimeMinutes** | **int** | Lifetime of the access token in minutes. The minimum is five minutes. The maximum is one day. | [optional] 
**InlineHook** | [**TokenAuthorizationServerPolicyRuleActionInlineHook**](TokenAuthorizationServerPolicyRuleActionInlineHook.md) |  | [optional] 
**RefreshTokenLifetimeMinutes** | **int** | Lifetime of the refresh token is the minimum access token lifetime. | [optional] 
**RefreshTokenWindowMinutes** | **int** | Timeframe when the refresh token is valid. The minimum is 10 minutes. The maximum is five years (2,628,000 minutes). | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

