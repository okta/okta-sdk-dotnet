# Okta.Sdk.Model.AutoUpdateSchedule
The schedule of auto-update configured by admin.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Cron** | **string** |  | [optional] 
**Delay** | **int** | delay in days | [optional] 
**Duration** | **int** | duration in minutes | [optional] 
**LastUpdated** | **DateTimeOffset** | last time when the updated finished (success or failed, exclude cancelled), null if job haven&#39;t finished once yet. | [optional] 
**Timezone** | **string** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

