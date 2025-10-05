# Okta.Sdk.Model.UserFactorCall

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset** | Timestamp when the factor was enrolled | [optional] [readonly] 
**Id** | **string** | ID of the factor | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the factor was last updated | [optional] [readonly] 
**Status** | [**UserFactorStatus**](UserFactorStatus.md) |  | [optional] 
**VendorName** | **string** | Name of the factor vendor. This is usually the same as the provider except for On-Prem MFA, which depends on admin settings. | [optional] [readonly] 
**Embedded** | **Dictionary&lt;string, Object&gt;** |  | [optional] [readonly] 
**Links** | [**UserFactorLinks**](UserFactorLinks.md) |  | [optional] 
**FactorType** | **Object** |  | [optional] 
**Profile** | [**UserFactorCallProfile**](UserFactorCallProfile.md) |  | [optional] 
**Provider** | **string** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

