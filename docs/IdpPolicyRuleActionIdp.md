# Okta.Sdk.Model.IdpPolicyRuleActionIdp
Specifies IdP settings

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Providers** | [**List&lt;IdpPolicyRuleActionProvider&gt;**](IdpPolicyRuleActionProvider.md) | List of configured identity providers that a given rule can route to. Ability to define multiple providers is a part of the Identity Engine. This allows users to choose a provider when they sign in. Contact support for information on the Identity Engine. | [optional] 
**IdpSelectionType** | **IdpSelectionType** |  | [optional] 
**MatchCriteria** | [**List&lt;IdpPolicyRuleActionMatchCriteria&gt;**](IdpPolicyRuleActionMatchCriteria.md) | Required if &#x60;idpSelectionType&#x60; is set to &#x60;DYNAMIC&#x60; | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

