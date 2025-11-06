# Okta.Sdk.Model.ApplicationAccessibility
Specifies access settings for the app

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ErrorRedirectUrl** | **string** | Custom error page URL for the app | [optional] 
**LoginRedirectUrl** | **string** | Custom login page URL for the app &gt; **Note:** The &#x60;loginRedirectUrl&#x60; property is deprecated in Identity Engine. This property is used with the custom app login feature. Orgs that actively use this feature can continue to do so. See [Okta-hosted sign-in (redirect authentication)](https://developer.okta.com/docs/guides/redirect-authentication/) or [configure IdP routing rules](https://help.okta.com/okta_help.htm?type&#x3D;oie&amp;id&#x3D;ext-cfg-routing-rules) to redirect users to the appropriate sign-in app for orgs that don&#39;t use the custom app login feature. | [optional] 
**SelfService** | **bool** | Represents whether the app can be self-assignable by users | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

