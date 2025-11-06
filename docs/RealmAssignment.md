# Okta.Sdk.Model.RealmAssignment

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Actions** | [**Actions**](Actions.md) |  | [optional] 
**Conditions** | [**Conditions**](Conditions.md) |  | [optional] 
**Created** | **DateTimeOffset** | Timestamp when the realm assignment was created | [optional] [readonly] 
**Domains** | **List&lt;string&gt;** | Array of allowed domains. No user in this realm can be created or updated unless they have a username and email from one of these domains.  The following characters aren&#39;t allowed in the domain name: &#x60;!$%^&amp;()&#x3D;*+,:;&lt;&gt;&#39;[]|/?\\&#x60; | [optional] 
**Id** | **string** | Unique ID of the realm assignment | [optional] [readonly] 
**IsDefault** | **bool** | Indicates the default realm. Existing users will start out in the default realm and can be moved individually to other realms. | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp of when the realm assignment was updated | [optional] [readonly] 
**Name** | **string** | Name of the realm | [optional] 
**Priority** | **int** | The priority of the realm assignment. The lower the number, the higher the priority. This helps resolve conflicts between realm assignments.  &gt; **Note:** When you create realm assignments in bulk, realm assignment priorities must be unique. | [optional] 
**Status** | **LifecycleStatus** |  | [optional] 
**Links** | [**LinksSelf**](LinksSelf.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

