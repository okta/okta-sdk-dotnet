# Okta.Sdk.Model.IdpPolicyRuleActionMatchCriteria

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**PropertyName** | **string** | The IdP property that the evaluated string should match to | [optional] 
**ProviderExpression** | **string** | You can provide an Okta Expression Language expression with the Login Context that&#39;s evaluated with the IdP. For example, the value &#x60;login.identifier&#x60; refers to the user&#39;s username. If the user is signing in with the username &#x60;john.doe@mycompany.com&#x60;, the expression &#x60;login.identifier.substringAfter(@))&#x60; is evaluated to the domain name of the user, for example: &#x60;mycompany.com&#x60;.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

