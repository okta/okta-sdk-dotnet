# Okta.Sdk.Model.Realm

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset** | Timestamp when the realm was created | [optional] [readonly] 
**Id** | **string** | Unique ID for the realm | [optional] [readonly] 
**IsDefault** | **bool** | Indicates the default realm. Existing users will start out in the default realm and can be moved to other realms individually or through realm assignments. See [Realms Assignments API](/openapi/okta-management/management/tag/RealmAssignment/). | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the realm was updated | [optional] [readonly] 
**Profile** | [**RealmProfile**](RealmProfile.md) |  | [optional] 
**Links** | [**LinksSelf**](LinksSelf.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

