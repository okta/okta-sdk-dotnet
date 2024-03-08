# Okta.Sdk.Model.AppUserAssignRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset** |  | [optional] 
**Credentials** | [**AppUserCredentials**](AppUserCredentials.md) |  | [optional] 
**ExternalId** | **string** | The ID of the user in the target app that&#39;s linked to the Okta Application User object. This value is the native app-specific identifier or primary key for the user in the target app.  The &#x60;externalId&#x60; is set during import when the user is confirmed (reconciled) or during provisioning when the user is created in the target app. This value isn&#39;t populated for SSO app assignments (for example, SAML or SWA) because it isn&#39;t synchronized with a target app. | [optional] [readonly] 
**Id** | **string** | Unique identifier for the Okta User | 
**LastSync** | **DateTimeOffset** | Timestamp of the last synchronization operation. This value is only updated for apps with the &#x60;IMPORT_PROFILE_UPDATES&#x60; or &#x60;PUSH PROFILE_UPDATES&#x60; feature. | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** |  | [optional] 
**PasswordChanged** | **DateTimeOffset?** | Timestamp when the Application User password was last changed | [optional] [readonly] 
**Profile** | **Dictionary&lt;string, Object&gt;** | Specifies the default and custom profile properties for a user. Properties that are visible in the Admin Console for an app assignment can also be assigned through the API. Some properties are reference properties that are imported from the target app and can&#39;t be configured.  | [optional] 
**Scope** | **string** | Indicates if the assignment is direct (&#x60;USER&#x60;) or by group membership (&#x60;GROUP&#x60;). | [optional] 
**Status** | **AppUserStatus** |  | [optional] 
**StatusChanged** | **DateTimeOffset** | Timestamp when the Application User status was last changed | [optional] [readonly] 
**SyncState** | **AppUserSyncState** |  | [optional] 
**Embedded** | **Dictionary&lt;string, Object&gt;** | Embedded resources related to the Application User using the [JSON Hypertext Application Language](https://datatracker.ietf.org/doc/html/draft-kelly-json-hal-06) specification | [optional] [readonly] 
**Links** | [**LinksAppAndUser**](LinksAppAndUser.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

