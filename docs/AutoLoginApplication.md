# Okta.Sdk.Model.AutoLoginApplication

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Accessibility** | [**ApplicationAccessibility**](ApplicationAccessibility.md) |  | [optional] 
**Created** | **DateTimeOffset** | Timestamp when the Application object was created | [optional] [readonly] 
**Features** | **List&lt;string&gt;** | Enabled app features | [optional] 
**Id** | **string** | Unique ID for the app instance | [optional] [readonly] 
**Label** | **string** | User-defined display name for app | 
**LastUpdated** | **DateTimeOffset** | Timestamp when the Application object was last updated | [optional] [readonly] 
**Licensing** | [**ApplicationLicensing**](ApplicationLicensing.md) |  | [optional] 
**Profile** | **Dictionary&lt;string, Object&gt;** | Contains any valid JSON schema for specifying properties that can be referenced from a request (only available to OAuth 2.0 client apps) | [optional] 
**SignOnMode** | [**ApplicationSignOnMode**](ApplicationSignOnMode.md) |  | 
**Status** | [**ApplicationLifecycleStatus**](ApplicationLifecycleStatus.md) |  | [optional] 
**Visibility** | [**ApplicationVisibility**](ApplicationVisibility.md) |  | [optional] 
**Embedded** | **Dictionary&lt;string, Object&gt;** |  | [optional] [readonly] 
**Links** | [**ApplicationLinks**](ApplicationLinks.md) |  | [optional] 
**Credentials** | [**SchemeApplicationCredentials**](SchemeApplicationCredentials.md) |  | [optional] 
**Name** | **string** | A unique key is generated for the custom SWA app instance when you use AUTO_LOGIN &#x60;signOnMode&#x60;. | [optional] [readonly] 
**Settings** | [**AutoLoginApplicationSettings**](AutoLoginApplicationSettings.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

