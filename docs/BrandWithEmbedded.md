# Okta.Sdk.Model.BrandWithEmbedded

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Embedded** | **Object** |  | [optional] [readonly] 
**Links** | [**LinksSelf**](LinksSelf.md) |  | [optional] 
**AgreeToCustomPrivacyPolicy** | **bool** | Consent for updating the custom privacy URL. Not required when resetting the URL. | [optional] 
**CustomPrivacyPolicyUrl** | **string** | Custom privacy policy URL | [optional] 
**DefaultApp** | [**DefaultApp**](DefaultApp.md) |  | [optional] 
**EmailDomainId** | **string** | The ID of the email domain | [optional] 
**Id** | **string** | The Brand ID | [optional] [readonly] 
**IsDefault** | **bool** | If &#x60;true&#x60;, the Brand is used for the Okta subdomain | [optional] [readonly] 
**Locale** | **string** | The language specified as an [IETF BCP 47 language tag](https://datatracker.ietf.org/doc/html/rfc5646) | [optional] 
**Name** | **string** | The name of the Brand | [optional] 
**RemovePoweredByOkta** | **bool** | Removes \&quot;Powered by Okta\&quot; from the sign-in page in redirect authentication deployments, and \&quot;© [current year] Okta, Inc.\&quot; from the Okta End-User Dashboard | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

