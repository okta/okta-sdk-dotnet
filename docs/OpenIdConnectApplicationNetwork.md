# Okta.Sdk.Model.OpenIdConnectApplicationNetwork
<x-lifecycle-container><x-lifecycle class=\"ea\"></x-lifecycle></x-lifecycle-container>The network restrictions of the client

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Connection** | **string** | The connection type of the network. Can be &#x60;ANYWHERE&#x60; or &#x60;ZONE&#x60;.  | 
**Exclude** | **List&lt;string&gt;** | If &#x60;ZONE&#x60; is specified as a connection, then specify the excluded IP network zones here. Value can be \&quot;ALL_IP_ZONES\&quot; or an array of zone IDs. | [optional] 
**Include** | **List&lt;string&gt;** | If &#x60;ZONE&#x60; is specified as a connection, then specify the included IP network zones here. Value can be \&quot;ALL_IP_ZONES\&quot; or an array of zone IDs. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

