# Okta.Sdk.Model.UserFactorToken

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset** | Timestamp when the Factor was enrolled | [optional] [readonly] 
**FactorType** | [**UserFactorType**](UserFactorType.md) |  | [optional] 
**Id** | **string** | ID of the Factor | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the Factor was last updated | [optional] [readonly] 
**Provider** | [**UserFactorProviderType**](UserFactorProviderType.md) |  | [optional] 
**Status** | [**UserFactorStatus**](UserFactorStatus.md) |  | [optional] 
**VendorName** | **string** | Name of the Factor vendor. This is usually the same as the provider except for On-Prem MFA where it depends on administrator settings. | [optional] [readonly] 
**Embedded** | **Dictionary&lt;string, Object&gt;** |  | [optional] [readonly] 
**Links** | **Object** |  | [optional] 
**Profile** | [**UserFactorTokenProfile**](UserFactorTokenProfile.md) |  | [optional] 
**Verify** | [**VerifyFactorRequest**](VerifyFactorRequest.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

