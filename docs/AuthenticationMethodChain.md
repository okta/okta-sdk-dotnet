# Okta.Sdk.Model.AuthenticationMethodChain

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AuthenticationMethods** | [**List&lt;AuthenticationMethod&gt;**](AuthenticationMethod.md) |  | [optional] 
**Next** | **List&lt;Object&gt;** | The next steps of the authentication method chain. This is an array of &#x60;AuthenticationMethodChain&#x60;. Only supports one item in the array. | [optional] 
**ReauthenticateIn** | **string** | Specifies how often the user is prompted for authentication using duration format for the time period. For example, &#x60;PT2H30M&#x60; for two and a half hours. This parameter can&#39;t be set at the same time as the &#x60;reauthenticateIn&#x60; property on the &#x60;verificationMethod&#x60;. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

