# Okta.Sdk.Model.UserFactorCustomHOTP

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Created** | **DateTimeOffset** | Timestamp indicating when the Factor was enrolled | [optional] [readonly] 
**FactorType** | **UserFactorType** |  | [optional] 
**Id** | **string** | ID of the Factor | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp indicating when the Factor was last updated | [optional] [readonly] 
**Provider** | **UserFactorProvider** |  | [optional] 
**Status** | **UserFactorStatus** |  | [optional] 
**VendorName** | **string** | Name of the Factor vendor. This is usually the same as the provider except for On-Prem MFA where it depends on administrator settings. | [optional] [readonly] 
**Embedded** | **Dictionary&lt;string, Object&gt;** |  | [optional] [readonly] 
**Links** | [**LinksSelf**](LinksSelf.md) |  | [optional] 
**FactorProfileId** | **string** | ID of an existing Custom TOTP Factor profile. To create this, see [Custom TOTP Factor](https://help.okta.com/okta_help.htm?id&#x3D;ext-mfa-totp). | [optional] 
**Profile** | [**UserFactorCustomHOTPProfile**](UserFactorCustomHOTPProfile.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

