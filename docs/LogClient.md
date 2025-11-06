# Okta.Sdk.Model.LogClient
When an event is triggered by an HTTP request, the `client` object describes the [client](https://datatracker.ietf.org/doc/html/rfc2616) that issues the HTTP request. For instance, the web browser is the client when a user accesses Okta. When this request is received and processed, a sign-in event is fired. When the event isn't sourced to an HTTP request, such as an automatic update, the `client` object field is blank.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Device** | **string** | Type of device that the client operates from (for example, computer) | [optional] [readonly] 
**GeographicalContext** | [**LogGeographicalContext**](LogGeographicalContext.md) |  | [optional] 
**Id** | **string** | For OAuth requests, this is the ID of the OAuth [client](https://datatracker.ietf.org/doc/html/rfc6749#section-1.1) making the request. For SSWS token requests, this is the ID of the agent making the request. | [optional] [readonly] 
**IpAddress** | **string** | IP address that the client is making its request from | [optional] [readonly] 
**UserAgent** | [**LogUserAgent**](LogUserAgent.md) |  | [optional] 
**Zone** | **string** | The &#x60;name&#x60; of the [Zone](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/NetworkZone/#tag/NetworkZone/operation/getNetworkZone) that the client&#39;s location is mapped to | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

