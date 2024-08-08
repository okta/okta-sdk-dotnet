# Okta.Sdk.Model.PrivilegedResourceAccountOkta

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset** | Timestamp when the object was created | [optional] [readonly] 
**CredentialChanged** | **DateTimeOffset** | Timestamp when the credential was changed | [optional] [readonly] 
**CredentialSyncState** | **CredentialSyncState** |  | [optional] 
**Id** | **string** | ID of the privileged resource | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the object was last updated | [optional] [readonly] 
**ResourceType** | **PrivilegedResourceType** |  | [optional] 
**Status** | **PrivilegedResourceStatus** |  | [optional] 
**ResourceId** | **string** | The user ID associated with the Okta privileged resource | 
**Credentials** | [**PrivilegedResourceCredentials**](PrivilegedResourceCredentials.md) |  | [optional] 
**Profile** | **Dictionary&lt;string, Object&gt;** | Specific profile properties for the privileged account | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

