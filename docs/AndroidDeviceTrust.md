# Okta.Sdk.Model.AndroidDeviceTrust
<x-lifecycle-container><x-lifecycle class=\"ea\"></x-lifecycle></x-lifecycle-container>Android Device Trust integration provider

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DeviceIntegrityLevel** | **DeviceIntegrity** |  | [optional] 
**NetworkProxyDisabled** | **bool** | Indicates whether a device has a network proxy disabled | [optional] 
**PlayProtectVerdict** | **PlayProtectVerdict** |  | [optional] 
**RequireMajorVersionUpdate** | **bool** | Indicates whether the device needs to be on the latest major version available to the device  **Note:** This option requires an &#x60;osVersion.dynamicVersionRequirement&#x60; value to be supplied with the &#x60;osVersion.dynamicVersionRequirement.type&#x60; as either &#x60;MINIMUM&#x60; or &#x60;EXACT&#x60;.  | [optional] 
**ScreenLockComplexity** | **ScreenLockComplexity** |  | [optional] 
**UsbDebuggingDisabled** | **bool** | Indicates whether Android Debug Bridge (adb) over USB is disabled | [optional] 
**WifiSecured** | **bool** | Indicates whether a device is on a password-protected Wi-Fi network | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

