# Okta.Sdk.Model.ProvisioningGroups
Provisioning settings for a user's group memberships

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Action** | **ProvisioningGroupsAction** |  | [optional] 
**Assignments** | **List&lt;string&gt;** | List of &#x60;OKTA_GROUP&#x60; group identifiers to add an IdP user as a member with the &#x60;ASSIGN&#x60; action | [optional] 
**Filter** | **List&lt;string&gt;** | Allowlist of &#x60;OKTA_GROUP&#x60; group identifiers for the &#x60;APPEND&#x60; or &#x60;SYNC&#x60; provisioning action | [optional] 
**SourceAttributeName** | **string** | IdP user profile attribute name (case-insensitive) for an array value that contains group memberships | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

