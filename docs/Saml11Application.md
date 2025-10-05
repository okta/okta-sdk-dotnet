# Okta.Sdk.Model.Saml11Application

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Accessibility** | [**ApplicationAccessibility**](ApplicationAccessibility.md) |  | [optional] 
**Created** | **DateTimeOffset** | Timestamp when the application object was created | [optional] [readonly] 
**Features** | **List&lt;string&gt;** | Enabled app features &gt; **Note:** See [Application Features](/openapi/okta-management/management/tag/ApplicationFeatures/) for app provisioning features.  | [optional] [readonly] 
**Id** | **string** | Unique ID for the app instance | [optional] [readonly] 
**Label** | **string** | User-defined display name for app | 
**LastUpdated** | **DateTimeOffset** | Timestamp when the application object was last updated | [optional] [readonly] 
**Licensing** | [**ApplicationLicensing**](ApplicationLicensing.md) |  | [optional] 
**Orn** | **string** | The Okta resource name (ORN) for the current app instance | [optional] [readonly] 
**Profile** | **Dictionary&lt;string, Object&gt;** | Contains any valid JSON schema for specifying properties that can be referenced from a request (only available to OAuth 2.0 client apps). For example, add an app manager contact email address or define an allowlist of groups that you can then reference using the Okta Expression Language &#x60;getFilteredGroups&#x60; function.  &gt; **Notes:** &gt; * &#x60;profile&#x60; isn&#39;t encrypted, so don&#39;t store sensitive data in it. &gt; * &#x60;profile&#x60; doesn&#39;t limit the level of nesting in the JSON schema you created, but there is a practical size limit. Okta recommends a JSON schema size of 1 MB or less for best performance. | [optional] 
**SignOnMode** | [**ApplicationSignOnMode**](ApplicationSignOnMode.md) |  | 
**Status** | [**ApplicationLifecycleStatus**](ApplicationLifecycleStatus.md) |  | [optional] 
**UniversalLogout** | [**ApplicationUniversalLogout**](ApplicationUniversalLogout.md) |  | [optional] 
**Visibility** | [**ApplicationVisibility**](ApplicationVisibility.md) |  | [optional] 
**Embedded** | [**ApplicationEmbedded**](ApplicationEmbedded.md) |  | [optional] 
**Links** | [**ApplicationLinks**](ApplicationLinks.md) |  | [optional] 
**Credentials** | [**ApplicationCredentials**](ApplicationCredentials.md) |  | [optional] 
**Name** | **string** | The key name for the SAML 1.1 app definition. You can&#39;t create a custom SAML 1.1 app integration instance. Only existing OIN SAML 1.1 app integrations are supported. | 
**Settings** | [**Saml11ApplicationSettings**](Saml11ApplicationSettings.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

