# Okta.Sdk.Model.Org2OrgApplication
Schema for the Okta Org2Org app (key name: `okta_org2org`)  To create an Org2Org app, use the [Create an Application](/openapi/okta-management/management/tag/Application/#tag/Application/operation/createApplication) request with the following parameters in the request body. > **Notes:** > * The Okta Org2Org (`okta_org2org`) app isn't available in Okta Integrator Free Plan orgs. If you need to test this feature in your Integrator Free Plan org, contact your Okta account team. > * The Okta Org2Org app supports `SAML_2_0` and `AUTO_LOGIN` sign-on modes. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Accessibility** | [**ApplicationAccessibility**](ApplicationAccessibility.md) |  | [optional] 
**Credentials** | [**SchemeApplicationCredentials**](SchemeApplicationCredentials.md) |  | [optional] 
**Label** | **string** | User-defined display name for app | 
**Licensing** | [**ApplicationLicensing**](ApplicationLicensing.md) |  | [optional] 
**Name** | **string** |  | 
**Profile** | **Dictionary&lt;string, Object&gt;** | Contains any valid JSON schema for specifying properties that can be referenced from a request (only available to OAuth 2.0 client apps) | [optional] 
**SignOnMode** | **string** |  | [optional] [default to SignOnModeEnum.SAML20]
**Status** | **ApplicationLifecycleStatus** |  | [optional] 
**Visibility** | [**ApplicationVisibility**](ApplicationVisibility.md) |  | [optional] 
**Settings** | [**Org2OrgApplicationSettings**](Org2OrgApplicationSettings.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

