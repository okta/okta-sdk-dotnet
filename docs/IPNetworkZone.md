# Okta.Sdk.Model.IPNetworkZone

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset** | Timestamp when the object was created | [optional] [readonly] 
**Id** | **string** | Unique identifier for the Network Zone | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the object was last modified | [optional] [readonly] 
**Name** | **string** | Unique name for this Network Zone | 
**Status** | [**NetworkZoneStatus**](NetworkZoneStatus.md) |  | [optional] 
**System** | **bool** | Indicates a system Network Zone: * &#x60;true&#x60; for system Network Zones * &#x60;false&#x60; for custom Network Zones  The Okta org provides the following default system Network Zones: * &#x60;LegacyIpZone&#x60; * &#x60;BlockedIpZone&#x60; * &lt;x-lifecycle class&#x3D;\&quot;ea\&quot;&gt;&lt;/x-lifecycle&gt; &#x60;DefaultEnhancedDynamicZone&#x60;  Admins can modify the name of the default system Network Zone and add up to 5000 gateway or proxy IP entries.  | [optional] [readonly] 
**Type** | [**NetworkZoneType**](NetworkZoneType.md) |  | 
**Usage** | [**NetworkZoneUsage**](NetworkZoneUsage.md) |  | [optional] 
**Links** | [**LinksSelfAndLifecycle**](LinksSelfAndLifecycle.md) |  | [optional] 
**Gateways** | [**List&lt;NetworkZoneAddress&gt;**](NetworkZoneAddress.md) | The IP addresses (range or CIDR form) for an IP Network Zone. The maximum array length is 150 entries for admin-created IP zones, 1000 entries for IP blocklist zones, and 5000 entries for the default system IP Zone. | [optional] 
**Proxies** | [**List&lt;NetworkZoneAddress&gt;**](NetworkZoneAddress.md) | The IP addresses (range or CIDR form) that are allowed to forward a request from gateway addresses for an IP Network Zone. These proxies are automatically trusted by Threat Insights and used to identify the client IP of a request. The maximum array length is 150 entries for admin-created zones and 5000 entries for the default system IP Zone. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)
