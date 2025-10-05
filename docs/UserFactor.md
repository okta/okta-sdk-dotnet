# Okta.Sdk.Model.UserFactor

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset** | Timestamp when the factor was enrolled | [optional] [readonly] 
**FactorType** | **UserFactorType** |  | [optional] 
**Id** | **string** | ID of the factor | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the factor was last updated | [optional] [readonly] 
**Profile** | **Object** | Specific attributes related to the factor | [optional] 
**Provider** | **string** | Provider for the factor. Each provider can support a subset of factor types. | [optional] 
**Status** | **UserFactorStatus** |  | [optional] 
**VendorName** | **string** | Name of the factor vendor. This is usually the same as the provider except for On-Prem MFA, which depends on admin settings. | [optional] [readonly] 
**Embedded** | **Dictionary&lt;string, Object&gt;** |  | [optional] [readonly] 
**Links** | [**UserFactorLinks**](UserFactorLinks.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

