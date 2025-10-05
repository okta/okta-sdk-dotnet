# Okta.Sdk.Model.LogDevice
The entity that describes a device enrolled with passwordless authentication using Okta Verify.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DeviceIntegrator** | **Object** | The integration platform or software used with the device | [optional] [readonly] 
**DiskEncryptionType** | **LogDiskEncryptionType** |  | [optional] 
**Id** | **string** | ID of the device | [optional] [readonly] 
**Jailbreak** | **bool** | If the device has removed software restrictions | [optional] [readonly] 
**Managed** | **bool** | Indicates if the device is configured for device management and is registered with Okta | [optional] [readonly] 
**Name** | **string** |  | [optional] [readonly] 
**OsPlatform** | **string** |  | [optional] [readonly] 
**OsVersion** | **string** |  | [optional] [readonly] 
**Registered** | **bool** | Indicates if the device is registered with an Okta org and is bound to an Okta Verify instance on the device | [optional] [readonly] 
**ScreenLockType** | **LogScreenLockType** |  | [optional] 
**SecureHardwarePresent** | **bool** | The availability of hardware security on the device | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

