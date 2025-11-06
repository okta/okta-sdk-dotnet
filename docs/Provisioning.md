# Okta.Sdk.Model.Provisioning
Specifies the behavior for just-in-time (JIT) provisioning of an IdP user as a new Okta user and their group memberships

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Action** | **ProvisioningAction** |  | [optional] 
**Conditions** | [**ProvisioningConditions**](ProvisioningConditions.md) |  | [optional] 
**Groups** | [**ProvisioningGroups**](ProvisioningGroups.md) |  | [optional] 
**ProfileMaster** | **bool** | Determines if the IdP should act as a source of truth for user profile attributes | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

