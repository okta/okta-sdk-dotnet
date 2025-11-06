# Okta.Sdk.Model.LogGeographicalContext
Geographical context describes a set of geographic coordinates. In addition to containing latitude and longitude data, the `GeographicalContext` object also contains address data of postal code-level granularity. Within the `Client` object, the geographical context refers to the physical location of the client when it sends the request that triggers this event. All `Transaction` events with `type` equal to `WEB` have a geographical context set. `Transaction` events with `type` equal to `JOB` don't have a geographical context set. The geographical context data can be missing if the geographical data for a request can't be resolved.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**City** | **string** | The city that encompasses the area that contains the geolocation coordinates, if available (for example, Seattle, San Francisco) | [optional] [readonly] 
**Country** | **string** | Full name of the country that encompasses the area that contains the geolocation coordinates (for example, France, Uganda) | [optional] [readonly] 
**Geolocation** | [**LogGeolocation**](LogGeolocation.md) |  | [optional] 
**PostalCode** | **string** | Postal code of the area that encompasses the geolocation coordinates | [optional] [readonly] 
**State** | **string** | Full name of the state or province that encompasses the area that contains the geolocation coordinates (for example, Montana, Ontario) | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

