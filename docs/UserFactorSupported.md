# Okta.Sdk.Model.UserFactorSupported

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Enrollment** | **string** | Indicates if the factor is required for the specified user | [optional] 
**FactorType** | **UserFactorType** |  | [optional] 
**Provider** | **UserFactorProvider** |  | [optional] 
**Status** | **UserFactorStatus** |  | [optional] 
**VendorName** | **string** | Name of the factor vendor. This is usually the same as the provider except for On-Prem MFA, which depends on admin settings. | [optional] [readonly] 
**Embedded** | **Dictionary&lt;string, Object&gt;** | Embedded resources related to the factor | [optional] [readonly] 
**Links** | [**UserFactorLinks**](UserFactorLinks.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

