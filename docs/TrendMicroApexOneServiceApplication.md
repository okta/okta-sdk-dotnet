# Okta.Sdk.Model.TrendMicroApexOneServiceApplication
Schema for Trend Micro Apex One as a Service app (key name: `trendmicroapexoneservice`)  To create a Trend Micro Apex One as a Service app, use the [Create an Application](/openapi/okta-management/management/tag/Application/#tag/Application/operation/createApplication) request with the following parameters in the request body. > **Note:** The Trend Micro Apex One as a Service app only supports `SAML_2_0` sign-on mode. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Accessibility** | [**ApplicationAccessibility**](ApplicationAccessibility.md) |  | [optional] 
**Credentials** | [**SchemeApplicationCredentials**](SchemeApplicationCredentials.md) |  | [optional] 
**Label** | **string** | User-defined display name for app | 
**Licensing** | [**ApplicationLicensing**](ApplicationLicensing.md) |  | [optional] 
**Name** | **string** |  | 
**Profile** | **Dictionary&lt;string, Object&gt;** | Contains any valid JSON schema for specifying properties that can be referenced from a request (only available to OAuth 2.0 client apps) | [optional] 
**SignOnMode** | **string** |  | [optional] 
**Status** | **ApplicationLifecycleStatus** |  | [optional] 
**Visibility** | [**ApplicationVisibility**](ApplicationVisibility.md) |  | [optional] 
**Settings** | [**TrendMicroApexOneServiceApplicationSettings**](TrendMicroApexOneServiceApplicationSettings.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

