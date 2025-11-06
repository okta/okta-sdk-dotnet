# Okta.Sdk.Model.LogRequest
The `Request` object describes details that are related to the HTTP request that triggers this event, if available. When the event isn't sourced to an HTTP request, such as an automatic update on the Okta servers, the `Request` object still exists, but the `ipChain` field is empty.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**IpChain** | [**List&lt;LogIpAddress&gt;**](LogIpAddress.md) | If the incoming request passes through any proxies, the IP addresses of those proxies are stored here in the format of clientIp, proxy1, proxy2, and so on. This field is useful when working with trusted proxies. | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

