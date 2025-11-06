# Okta.Sdk.Model.BasicApplicationSettings

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**EmOptInStatus** | **string** | The Governance Engine opt-in status for the app | [optional] [readonly] 
**IdentityStoreId** | **string** | Identifies an additional identity store app, if your app supports it. The &#x60;identityStoreId&#x60; value must be a valid identity store app ID. This identity store app must be created in the same org as your app. | [optional] 
**ImplicitAssignment** | **bool** | Controls whether Okta automatically assigns users to the app based on the user&#39;s role or group membership. | [optional] 
**InlineHookId** | **string** | Identifier of an inline hook. Inline hooks are outbound calls from Okta to your own custom code, triggered at specific points in Okta process flows. They allow you to integrate custom functionality into those flows. See [Inline hooks](/openapi/okta-management/management/tag/InlineHook/). | [optional] 
**Notes** | [**ApplicationSettingsNotes**](ApplicationSettingsNotes.md) |  | [optional] 
**Notifications** | [**ApplicationSettingsNotifications**](ApplicationSettingsNotifications.md) |  | [optional] 
**App** | [**BasicApplicationSettingsApplication**](BasicApplicationSettingsApplication.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

