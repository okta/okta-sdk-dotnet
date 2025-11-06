# Okta.Sdk.Model.SubmissionResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Config** | [**List&lt;SubmissionResponseConfigInner&gt;**](SubmissionResponseConfigInner.md) | List of org-level variables for the customer per-tenant configuration. For example, a &#x60;subdomain&#x60; variable can be used in the ACS URL: &#x60;https://${org.subdomain}.example.com/saml/login&#x60; | [optional] 
**Description** | **string** | A general description of your application and the benefits provided to your customers | [optional] 
**Id** | **string** | OIN Integration ID | [optional] [readonly] 
**LastPublished** | **string** | Timestamp when the OIN Integration was last published | [optional] [readonly] 
**LastUpdated** | **string** | Timestamp when the OIN Integration instance was last updated | [optional] [readonly] 
**LastUpdatedBy** | **string** | ID of the user who made the last update | [optional] [readonly] 
**Logo** | **string** | URL to an uploaded application logo. This logo appears next to your app integration name in the OIN catalog. You must first [Upload an OIN Integration logo](/openapi/okta-management/management/tag/YourOinIntegrations/#tag/YourOinIntegrations/operation/uploadSubmissionLogo) to obtain the logo URL before you can specify this value. | [optional] 
**Name** | **string** | The app integration name. This is the main title used for your integration in the OIN catalog. | [optional] 
**Provisioning** | [**ProvisioningDetails**](ProvisioningDetails.md) |  | [optional] 
**Sso** | [**Sso**](Sso.md) |  | [optional] 
**Status** | **string** | Status of the OIN Integration submission | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

