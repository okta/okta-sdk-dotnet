# Okta.Sdk.Model.EventHookChannelConfigAuthScheme
The authentication scheme used for this request.  To use Basic Auth for authentication, set `type` to `HEADER`, `key` to `Authorization`, and `value` to the Base64-encoded string of \"username:password\". Ensure that you include the scheme (including space) as part of the `value` parameter. For example, `Basic YWRtaW46c3VwZXJzZWNyZXQ=`.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Key** | **string** | The name for the authorization header | [optional] 
**Type** | **EventHookChannelConfigAuthSchemeType** |  | [optional] 
**Value** | **string** | The header value. This secret key is passed to your external service endpoint for security verification. This property is not returned in the response. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

