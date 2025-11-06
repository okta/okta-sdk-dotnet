# Okta.Sdk.Model.EnhancedDynamicNetworkZone

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset** | Timestamp when the object was created | [optional] [readonly] 
**Id** | **string** | Unique identifier for the Network Zone | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the object was last modified | [optional] [readonly] 
**Name** | **string** | Unique name for this Network Zone | 
**Status** | [**NetworkZoneStatus**](NetworkZoneStatus.md) |  | [optional] 
**System** | **bool** | Indicates a system Network Zone: * &#x60;true&#x60; for system Network Zones * &#x60;false&#x60; for custom Network Zones  The Okta org provides the following default system Network Zones: * &#x60;LegacyIpZone&#x60; * &#x60;BlockedIpZone&#x60; * &#x60;DefaultEnhancedDynamicZone&#x60; * &#x60;DefaultExemptIpZone&#x60;  Admins can modify the name of the default system Network Zone and add up to 5000 gateway or proxy IP entries.  | [optional] [readonly] 
**Type** | [**NetworkZoneType**](NetworkZoneType.md) |  | 
**Usage** | [**NetworkZoneUsage**](NetworkZoneUsage.md) |  | [optional] 
**Links** | [**LinksSelfAndLifecycle**](LinksSelfAndLifecycle.md) |  | [optional] 
**Asns** | [**EnhancedDynamicNetworkZoneAllOfAsns**](EnhancedDynamicNetworkZoneAllOfAsns.md) |  | [optional] 
**Locations** | [**EnhancedDynamicNetworkZoneAllOfLocations**](EnhancedDynamicNetworkZoneAllOfLocations.md) |  | [optional] 
**IpServiceCategories** | [**EnhancedDynamicNetworkZoneAllOfIpServiceCategories**](EnhancedDynamicNetworkZoneAllOfIpServiceCategories.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

