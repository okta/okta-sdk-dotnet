# Okta.Sdk.Model.AppServiceAccount

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ContainerGlobalName** | **string** | The key name of the app in the Okta Integration Network (OIN) | [optional] [readonly] 
**ContainerInstanceName** | **string** | The app instance label | [optional] [readonly] 
**ContainerOrn** | **string** | The [ORN](/openapi/okta-management/guides/roles/#okta-resource-name-orn) of the relevant resource.  Use the specific app ORN format (&#x60;orn:{partition}:idp:{yourOrgId}:apps:{appType}:{appId}&#x60;) to identify an Okta app instance in your org. | 
**Created** | **DateTimeOffset** | Timestamp when the app service account was created | [optional] [readonly] 
**Description** | **string** | The description of the app service account | [optional] 
**Id** | **string** | The UUID of the app service account | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the app service account was last updated | [optional] [readonly] 
**Name** | **string** | The user-defined name for the app service account | 
**OwnerGroupIds** | **List&lt;string&gt;** | A list of IDs of the Okta groups who own the app service account | [optional] 
**OwnerUserIds** | **List&lt;string&gt;** | A list of IDs of the Okta users who own the app service account | [optional] 
**Password** | **string** | The app service account password. Required for apps that don&#39;t have provisioning enabled or don&#39;t support password synchronization. | [optional] 
**Status** | **ServiceAccountStatus** |  | [optional] 
**StatusDetail** | **ServiceAccountStatusDetail** |  | [optional] 
**Username** | **string** | The username that serves as the direct link to your managed app account. Ensure that this value precisely matches the identifier of the target app account. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

