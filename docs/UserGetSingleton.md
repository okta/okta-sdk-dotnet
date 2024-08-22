# Okta.Sdk.Model.UserGetSingleton

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Activated** | **DateTimeOffset?** | The timestamp when the user status transitioned to &#x60;ACTIVE&#x60; | [optional] [readonly] 
**Created** | **DateTimeOffset** | The timestamp when the user was created | [optional] [readonly] 
**Credentials** | [**UserCredentials**](UserCredentials.md) |  | [optional] 
**Id** | **string** | The unique key for the user | [optional] [readonly] 
**LastLogin** | **DateTimeOffset?** | The timestamp of the last login | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | The timestamp when the user was last updated | [optional] [readonly] 
**PasswordChanged** | **DateTimeOffset?** | The timestamp when the user&#39;s password was last updated | [optional] [readonly] 
**Profile** | [**UserProfile**](UserProfile.md) |  | [optional] 
**RealmId** | **string** | &lt;div class&#x3D;\&quot;x-lifecycle-container\&quot;&gt;&lt;x-lifecycle class&#x3D;\&quot;ea\&quot;&gt;&lt;/x-lifecycle&gt;&lt;/div&gt;The ID of the Realm in which the user is residing | [optional] [readonly] 
**Status** | **UserStatus** |  | [optional] 
**StatusChanged** | **DateTimeOffset?** | The timestamp when the status of the user last changed | [optional] [readonly] 
**TransitioningToStatus** | **string** | The target status of an in-progress asynchronous status transition. This property is only returned if the user&#39;s state is transitioning. | [optional] [readonly] 
**Type** | [**UserType**](UserType.md) |  | [optional] 
**Embedded** | [**UserGetSingletonAllOfEmbedded**](UserGetSingletonAllOfEmbedded.md) |  | [optional] 
**Links** | [**UserLinks**](UserLinks.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

