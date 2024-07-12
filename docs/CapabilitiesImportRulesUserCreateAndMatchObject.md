# Okta.Sdk.Model.CapabilitiesImportRulesUserCreateAndMatchObject
Rules for matching and creating users

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AllowPartialMatch** | **bool** | Allows user import upon partial matching. Partial matching occurs when the first and last names of an imported user match those of an existing Okta user, even if the username or email attributes don&#39;t match. | [optional] 
**AutoActivateNewUsers** | **bool** | If set to &#x60;true&#x60;, imported new users are automatically activated. | [optional] 
**AutoConfirmExactMatch** | **bool** | If set to &#x60;true&#x60;, exact-matched users are automatically confirmed on activation. If set to &#x60;false&#x60;, exact-matched users need to be confirmed manually. | [optional] 
**AutoConfirmNewUsers** | **bool** | If set to &#x60;true&#x60;, imported new users are automatically confirmed on activation. This doesn&#39;t apply to imported users that already exist in Okta. | [optional] 
**AutoConfirmPartialMatch** | **bool** | If set to &#x60;true&#x60;, partially matched users are automatically confirmed on activation. If set to &#x60;false&#x60;, partially matched users need to be confirmed manually. | [optional] 
**ExactMatchCriteria** | **string** | Determines the attribute to match users | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

