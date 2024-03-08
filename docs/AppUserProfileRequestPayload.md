# Okta.Sdk.Model.AppUserProfileRequestPayload
Updates the assigned user profile > **Note:** The Okta API currently doesn't support entity tags for conditional updates. As long as you're the only user updating the the user profile, Okta recommends you fetch the most recent profile with [Retrieve an Application User](/openapi/okta-management/management/tag/ApplicationUsers/#tag/ApplicationUsers/operation/getApplicationUser), apply your profile update, and then `POST` back the updated profile.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Profile** | **Dictionary&lt;string, Object&gt;** | Specifies the default and custom profile properties for a user. Properties that are visible in the Admin Console for an app assignment can also be assigned through the API. Some properties are reference properties that are imported from the target app and can&#39;t be configured.  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

