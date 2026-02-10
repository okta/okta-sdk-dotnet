# Okta.Sdk.Model.DeviceAssuranceAndroidPlatform

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CreatedBy** | **string** |  | [optional] [readonly] 
**CreatedDate** | **string** |  | [optional] [readonly] 
**DevicePostureChecks** | [**DevicePostureChecks**](DevicePostureChecks.md) |  | [optional] 
**DisplayRemediationMode** | **string** | &lt;x-lifecycle-container&gt;&lt;x-lifecycle class&#x3D;\&quot;ea\&quot;&gt;&lt;/x-lifecycle&gt;&lt;/x-lifecycle-container&gt;Represents the remediation mode of this device assurance policy when users are denied access due to device noncompliance | [optional] 
**GracePeriod** | [**GracePeriod**](GracePeriod.md) |  | [optional] 
**Id** | **string** |  | [optional] [readonly] 
**LastUpdate** | **string** |  | [optional] [readonly] 
**LastUpdatedBy** | **string** |  | [optional] [readonly] 
**Name** | **string** | Display name of the device assurance policy | [optional] 
**Platform** | [**Platform**](Platform.md) |  | [optional] 
**Links** | [**LinksSelf**](LinksSelf.md) |  | [optional] 
**DiskEncryptionType** | [**DeviceAssuranceAndroidPlatformAllOfDiskEncryptionType**](DeviceAssuranceAndroidPlatformAllOfDiskEncryptionType.md) |  | [optional] 
**Jailbreak** | **bool** |  | [optional] 
**OsVersion** | [**OSVersion**](OSVersion.md) |  | [optional] 
**ScreenLockType** | [**DeviceAssuranceAndroidPlatformAllOfScreenLockType**](DeviceAssuranceAndroidPlatformAllOfScreenLockType.md) |  | [optional] 
**SecureHardwarePresent** | **bool?** | Indicates if the device contains secure hardware functionality. When specified, only &#x60;true&#x60; is a valid value. | [optional] 
**ThirdPartySignalProviders** | [**DeviceAssuranceAndroidPlatformAllOfThirdPartySignalProviders**](DeviceAssuranceAndroidPlatformAllOfThirdPartySignalProviders.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

