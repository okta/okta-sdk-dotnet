# Okta.Sdk.Model.WebAuthnPreregistrationFactor
User Factor variant used for WebAuthn Preregistration Factors

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset** | Timestamp indicating when the Factor was enrolled | [optional] [readonly] 
**FactorType** | **UserFactorType** |  | [optional] 
**Id** | **string** | ID of the Factor | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp indicating when the Factor was last updated | [optional] [readonly] 
**Profile** | **Object** | Specific attributes related to the Factor | [optional] 
**Provider** | **UserFactorProvider** |  | [optional] 
**Status** | **UserFactorStatus** |  | [optional] 
**VendorName** | **string** | Name of the Factor vendor. This is usually the same as the provider. | [optional] [readonly] 
**Links** | [**LinksSelf**](LinksSelf.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

