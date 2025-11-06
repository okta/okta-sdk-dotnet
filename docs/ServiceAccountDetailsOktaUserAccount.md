# Okta.Sdk.Model.ServiceAccountDetailsOktaUserAccount
Details for managing an Okta user as a service account

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountType** | [**ServiceAccountType**](ServiceAccountType.md) |  | 
**Created** | **DateTimeOffset** | Timestamp when the service account was created | [optional] [readonly] 
**Description** | **string** | The description of the service account | [optional] 
**Id** | **string** | The UUID of the service account | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the service account was last updated | [optional] [readonly] 
**Name** | **string** | The user-defined name for the service account | 
**OwnerGroupIds** | **List&lt;string&gt;** | A list of IDs of the Okta groups that own the service account | [optional] 
**OwnerUserIds** | **List&lt;string&gt;** | A list of IDs of the Okta users that own the service account | [optional] 
**Status** | [**ServiceAccountStatus**](ServiceAccountStatus.md) |  | [optional] 
**StatusDetail** | [**ServiceAccountStatusDetail**](ServiceAccountStatusDetail.md) |  | [optional] 
**Details** | [**ServiceAccountDetailsOktaUserAccountSub**](ServiceAccountDetailsOktaUserAccountSub.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

