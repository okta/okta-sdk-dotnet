# Okta.Sdk.Model.OINApplication

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Accessibility** | [**ApplicationAccessibility**](ApplicationAccessibility.md) |  | [optional] 
**Created** | **DateTimeOffset** | Timestamp when the Application object was created | [optional] [readonly] 
**Credentials** | [**SchemeApplicationCredentials**](SchemeApplicationCredentials.md) |  | [optional] 
**Features** | **List&lt;string&gt;** | Enabled app features | [optional] 
**Id** | **string** | Unique ID for the app instance | [optional] [readonly] 
**Label** | **string** | User-defined display name for app | [optional] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the Application object was last updated | [optional] [readonly] 
**Licensing** | [**ApplicationLicensing**](ApplicationLicensing.md) |  | [optional] 
**Name** | **string** | Unique key for the app definition | [optional] 
**Profile** | **Dictionary&lt;string, Object&gt;** | Contains any valid JSON schema for specifying properties that can be referenced from a request (only available to OAuth 2.0 client apps) | [optional] 
**Settings** | [**OINBaseSignOnModeApplicationSettings**](OINBaseSignOnModeApplicationSettings.md) |  | [optional] 
**SignOnMode** | **ApplicationSignOnMode** |  | [optional] 
**Status** | **ApplicationLifecycleStatus** |  | [optional] 
**Visibility** | [**ApplicationVisibility**](ApplicationVisibility.md) |  | [optional] 
**Embedded** | **Dictionary&lt;string, Object&gt;** |  | [optional] [readonly] 
**Links** | [**ApplicationLinks**](ApplicationLinks.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

