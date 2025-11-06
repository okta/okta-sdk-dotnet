# Okta.Sdk.Model.AuthenticationMethodChainMethod

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Type** | [**PolicyRuleVerificationMethodType**](PolicyRuleVerificationMethodType.md) |  | [optional] 
**Chains** | [**List&lt;AuthenticationMethodChain&gt;**](AuthenticationMethodChain.md) | Authentication method chains. Only supports 5 items in the array. Each chain can support maximum 3 steps. | [optional] 
**ReauthenticateIn** | **string** | Specifies how often the user is prompted for authentication using duration format for the time period. For example, &#x60;PT2H30M&#x60; for two and a half hours. Don&#39;t set this parameter if you&#39;re setting the &#x60;reauthenticateIn&#x60; parameter in &#x60;chains&#x60;. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

