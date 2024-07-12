# Okta.Sdk.Model.AAGUIDGroupObject
<x-lifecycle class=\"ea\"></x-lifecycle> The AAGUID Group object supports the Early Access (Self-Service) Allow List for FIDO2 (WebAuthn) Authenticators feature. Enable the feature for your org from the **Settings** > **Features** page in the Admin Console.  This feature has several limitations when enrolling a security key:   - Enrollment is currently unsupported on Firefox.   - Enrollment is currently unsupported on Chrome if User Verification is set to DISCOURAGED and a PIN is set on the security key.   - If prompted during enrollment, users must allow Okta to see the make and model of the security key. 

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Aaguids** | **List&lt;string&gt;** | A list of YubiKey hardware FIDO2 Authenticator Attestation Global Unique Identifiers (AAGUIDs). The available [AAGUIDs](https://support.yubico.com/hc/en-us/articles/360016648959-YubiKey-Hardware-FIDO2-AAGUIDs) (opens new window) are provided by the FIDO Alliance Metadata Service. | [optional] 
**Name** | **string** | A name to identify the group of YubiKey hardware FIDO2 AAGUIDs | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

