# Okta.Sdk.Model.CatalogApplication
An app in the OIN catalog

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Category** | **string** | Category for the app in the OIN catalog | [optional] [readonly] 
**Description** | **string** | Description of the app in the OIN catalog | [optional] [readonly] 
**DisplayName** | **string** | OIN catalog app display name | [optional] [readonly] 
**Features** | **List&lt;string&gt;** | Features supported by the app. See app [features](/openapi/okta-management/management/tag/Application/#tag/Application/operation/listApplications!c&#x3D;200&amp;path&#x3D;0/features&amp;t&#x3D;response). | [optional] [readonly] 
**Id** | **string** | ID of the app instance. Okta returns this property only for apps not in the OIN catalog. | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the object was last updated | [optional] [readonly] 
**Name** | **string** | App key name. For OIN catalog apps, this is a unique key for the app definition. | [optional] 
**SignOnModes** | **List&lt;string&gt;** | Authentication mode for the app. See app [signOnMode](/openapi/okta-management/management/tag/Application/#tag/Application/operation/listApplications!c&#x3D;200&amp;path&#x3D;0/signOnMode&amp;t&#x3D;response). | [optional] 
**Status** | **CatalogApplicationStatus** |  | [optional] 
**VerificationStatus** | **string** | OIN verification status of the catalog app | [optional] 
**Website** | **string** | Website of the OIN catalog app | [optional] 
**Links** | [**CatalogApplicationLinks**](CatalogApplicationLinks.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

