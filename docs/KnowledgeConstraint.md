# Okta.Sdk.Model.KnowledgeConstraint

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Methods** | **List&lt;string&gt;** | The Authenticator methods that are permitted | [optional] 
**ReauthenticateIn** | **string** | The duration after which the user must re-authenticate regardless of user activity. This re-authentication interval overrides the Verification Method object&#39;s &#x60;reauthenticateIn&#x60; interval. The supported values use ISO 8601 period format for recurring time intervals (for example, &#x60;PT1H&#x60;). | [optional] 
**Types** | **List&lt;string&gt;** | The Authenticator types that are permitted | [optional] 
**AuthenticationMethods** | [**List&lt;AuthenticationMethodObject&gt;**](AuthenticationMethodObject.md) | This property specifies the precise authenticator and method for authentication. | [optional] 
**ExcludedAuthenticationMethods** | [**List&lt;AuthenticationMethodObject&gt;**](AuthenticationMethodObject.md) | This property specifies the precise authenticator and method to exclude from authentication. | [optional] 
**Required** | **bool** | This property indicates whether the knowledge or possession factor is required by the assurance. It&#39;s optional in the request, but is always returned in the response. By default, this field is &#x60;true&#x60;. If the knowledge or possession constraint has values for&#x60;excludedAuthenticationMethods&#x60; the &#x60;required&#x60; value is false. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

