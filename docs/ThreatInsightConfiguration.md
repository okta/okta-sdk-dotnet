# Okta.Sdk.Model.ThreatInsightConfiguration

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Action** | **string** | Specifies how Okta responds to authentication requests from suspicious IP addresses | 
**Created** | **DateTimeOffset** | Timestamp when the ThreatInsight Configuration object was created | [optional] [readonly] 
**ExcludeZones** | **List&lt;string&gt;** | Accepts a list of [Network Zone](/openapi/okta-management/management/tag/NetworkZone/) IDs. IPs in the excluded network zones aren&#39;t logged or blocked. This ensures that traffic from known, trusted IPs isn&#39;t accidentally logged or blocked. | [optional] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the ThreatInsight Configuration object was last updated | [optional] [readonly] 
**Links** | [**LinksSelf**](LinksSelf.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

