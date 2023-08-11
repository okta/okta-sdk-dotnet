# Okta.Sdk.Model.AppUser
The App User object defines a user's app-specific profile and credentials for an app.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset** | Timestamp when the App User object was created | [readonly] 
**Credentials** | [**AppUserCredentials**](AppUserCredentials.md) |  | [optional] 
**ExternalId** | **string** | The ID of the user in the target app that&#39;s linked to the Okta App User object. This value is the native app-specific identifier or primary key for the user in the target app.  The &#x60;externalId&#x60; is set during import when the user is confirmed (reconciled) or during provisioning when the user has been successfully created in the target app. This value isn&#39;t populated for SSO app assignments (for example, SAML or SWA) because it isn&#39;t synchronized with a target app. | [optional] [readonly] 
**Id** | **string** | Unique identifier of the App User object (only required for apps with &#x60;signOnMode&#x60; or authentication schemes that don&#39;t require credentials) | [optional] 
**LastSync** | **DateTimeOffset** | Timestamp of the last synchronization operation. This value is only updated for apps with the &#x60;IMPORT_PROFILE_UPDATES&#x60; or &#x60;PUSH PROFILE_UPDATES&#x60; feature. | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp when App User was last updated | [readonly] 
**PasswordChanged** | **DateTimeOffset?** | Timestamp when the App User password was last changed | [optional] [readonly] 
**Profile** | **Dictionary&lt;string, Object&gt;** | App user profiles are app-specific and can be customized by the Profile Editor in the Admin Console. SSO apps typically don&#39;t support app user profiles, while apps with user provisioning features have app-specific profiles. Properties that are visible in the Admin Console for an app assignment can also be assigned through the API. Some properties are reference properties that are imported from the target app and can&#39;t be configured. | [optional] 
**Scope** | **string** | Toggles the assignment between user or group scope | 
**Status** | **AppUserStatus** |  | 
**StatusChanged** | **DateTimeOffset** | Timestamp when the App User status was last changed | [readonly] 
**SyncState** | **AppUserSyncState** |  | [optional] 
**Embedded** | **Dictionary&lt;string, Object&gt;** | Embedded resources related to the App User using the [JSON Hypertext Application Language](https://datatracker.ietf.org/doc/html/draft-kelly-json-hal-06) specification | [optional] [readonly] 
**Links** | [**LinksAppAndUser**](LinksAppAndUser.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

