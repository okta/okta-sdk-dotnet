# Okta.Sdk.Model.WebAuthnPreregistrationFactor
User factor variant used for WebAuthn preregistration factors

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset** | Timestamp indicating when the factor was enrolled | [optional] [readonly] 
**FactorType** | **UserFactorType** |  | [optional] 
**Id** | **string** | ID of the factor | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp indicating when the factor was last updated | [optional] [readonly] 
**Profile** | **Object** | Specific attributes related to the factor | [optional] 
**Provider** | **UserFactorProvider** |  | [optional] 
**Status** | **UserFactorStatus** |  | [optional] 
**VendorName** | **string** | Name of the factor vendor. This is usually the same as the provider. | [optional] [readonly] 
**Links** | [**LinksSelf**](LinksSelf.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

