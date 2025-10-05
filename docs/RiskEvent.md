# Okta.Sdk.Model.RiskEvent

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ExpiresAt** | **DateTimeOffset** | Timestamp at which the event expires (expressed as a UTC time zone using ISO 8601 format: yyyy-MM-dd&#x60;T&#x60;HH:mm:ss.SSS&#x60;Z&#x60;). If this optional field isn&#39;t included, Okta automatically expires the event 24 hours after the event is consumed. | [optional] 
**Subjects** | [**List&lt;RiskEventSubject&gt;**](RiskEventSubject.md) | List of risk event subjects | 
**Timestamp** | **DateTimeOffset** | Timestamp of when the event is produced (expressed as a UTC time zone using ISO 8601 format: yyyy-MM-dd&#x60;T&#x60;HH:mm:ss.SSS&#x60;Z&#x60;) | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

