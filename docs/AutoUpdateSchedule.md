# Okta.Sdk.Model.AutoUpdateSchedule
The schedule of auto-update configured by the admin

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Cron** | **string** | The schedule of the update in cron format. The cron settings are limited to only the day of the month or the nth-day-of-the-week configurations. For example, &#x60;0 8 ? * 6#3&#x60; indicates every third Saturday at 8:00 AM. | [optional] 
**Delay** | **int** | Delay in days | [optional] 
**Duration** | **int** | Duration in minutes | [optional] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the update finished (only for a successful or failed update, not for a cancelled update). Null is returned if the job hasn&#39;t finished once yet. | [optional] 
**Timezone** | **string** | Timezone of where the scheduled job takes place | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

