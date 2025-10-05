# Okta.Sdk.Model.AuthenticatorMethodWebAuthnAllOfSettings
The settings for the WebAuthn authenticator method

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AaguidGroups** | [**List&lt;AAGUIDGroupObject&gt;**](AAGUIDGroupObject.md) | The FIDO2 Authenticator Attestation Global Unique Identifiers (AAGUID) groups available to the WebAuthn authenticator | [optional] 
**UserVerification** | **UserVerificationEnum** |  | [optional] 
**Attachment** | **WebAuthnAttachmentEnum** |  | [optional] 
**EnableAutofillUI** | **bool** | &lt;x-lifecycle-container&gt;&lt;x-lifecycle class&#x3D;\&quot;ea\&quot;&gt;&lt;/x-lifecycle&gt;&lt;/x-lifecycle-container&gt;Enables the passkeys autofill UI to display available WebAuthn discoverable credentials (\&quot;resident key\&quot;) from the Sign-In Widget username field | [optional] [default to false]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

