# Okta.Sdk.Model.OAuth2Claim

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AlwaysIncludeInToken** | **bool** | Specifies whether to include Claims in the token. The value is always &#x60;TRUE&#x60; for access token Claims. If the value is set to &#x60;FALSE&#x60; for an ID token claim, the Claim isn&#39;t included in the ID token when the token is requested with the access token or with the &#x60;authorization_code&#x60;. The client instead uses the access token to get Claims from the &#x60;/userinfo&#x60; endpoint. | [optional] 
**ClaimType** | **OAuth2ClaimType** |  | [optional] 
**Conditions** | [**OAuth2ClaimConditions**](OAuth2ClaimConditions.md) |  | [optional] 
**GroupFilterType** | **OAuth2ClaimGroupFilterType** |  | [optional] 
**Id** | **string** | ID of the Claim | [optional] [readonly] 
**Name** | **string** | Name of the Claim | [optional] 
**Status** | **LifecycleStatus** |  | [optional] 
**System** | **bool** | When &#x60;true&#x60;, indicates that Okta created the Claim | [optional] 
**Value** | **string** | Specifies the value of the Claim. This value must be a string literal if &#x60;valueType&#x60; is &#x60;GROUPS&#x60;, and the string literal is matched with the selected &#x60;group_filter_type&#x60;. The value must be an Okta EL expression if &#x60;valueType&#x60; is &#x60;EXPRESSION&#x60;. | [optional] 
**ValueType** | **OAuth2ClaimValueType** |  | [optional] 
**Links** | [**LinksSelf**](LinksSelf.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

