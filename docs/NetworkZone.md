# Okta.Sdk.Model.NetworkZone

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Asns** | **List&lt;string&gt;** | Dynamic network zone property. array of strings that represent an ASN numeric value | [optional] 
**Created** | **DateTimeOffset** | Timestamp when the network zone was created | [optional] [readonly] 
**Gateways** | [**List&lt;NetworkZoneAddress&gt;**](NetworkZoneAddress.md) | IP network zone property: the IP addresses (range or CIDR form) of this zone. The maximum array length is 150 entries for admin-created IP zones, 1000 entries for IP blocklist zones, and 5000 entries for the default system IP Zone. | [optional] 
**Id** | **string** | Unique identifier for the network zone | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the network zone was last modified | [optional] [readonly] 
**Locations** | [**List&lt;NetworkZoneLocation&gt;**](NetworkZoneLocation.md) | Dynamic network zone property: an array of geolocations of this network zone | [optional] 
**Name** | **string** | Unique name for this network zone. Maximum of 128 characters. | [optional] 
**Proxies** | [**List&lt;NetworkZoneAddress&gt;**](NetworkZoneAddress.md) | IP network zone property: the IP addresses (range or CIDR form) that are allowed to forward a request from gateway addresses These proxies are automatically trusted by Threat Insights, and used to identify the client IP of a request. The maximum array length is 150 entries for admin-created zones and 5000 entries for the default system IP Zone. | [optional] 
**ProxyType** | **string** | Dynamic network zone property: the proxy type used | [optional] 
**Status** | **NetworkZoneStatus** |  | [optional] 
**System** | **bool** | Indicates if this is a system network zone. For admin-created zones, this is always &#x60;false&#x60;. The system IP Policy Network Zone (&#x60;LegacyIpZone&#x60;) is included by default in your Okta org. Notice that &#x60;system&#x3D;true&#x60; for the &#x60;LegacyIpZone&#x60; object. Admin users can modify the name of this default system Zone and can add up to 5000 gateway or proxy IP entries. | [optional] 
**Type** | **NetworkZoneType** |  | [optional] 
**Usage** | **NetworkZoneUsage** |  | [optional] 
**Links** | [**NetworkZoneLinks**](NetworkZoneLinks.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

