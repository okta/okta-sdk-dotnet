# Okta.Sdk.Model.RealmProfile

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Domains** | **List&lt;string&gt;** | Array of allowed domains. No user in this realm can be created or updated unless they have a username and email from one of these domains.  The following characters aren&#39;t allowed in the domain name: &#x60;!$%^&amp;()&#x3D;*+,:;&lt;&gt;&#39;[]|/?\\&#x60; | [optional] 
**Name** | **string** | Name of a realm | 
**RealmType** | **string** | Used to store partner users. This property must be set to &#x60;PARTNER&#x60; to access Okta&#39;s external partner portal. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

