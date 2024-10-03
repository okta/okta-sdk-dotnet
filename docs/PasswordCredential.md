# Okta.Sdk.Model.PasswordCredential
When a user has a valid password, imported hashed password, or password hook, and a response object contains a password credential, then the password object is a bare object without the value property defined (for example, `password: {}`). This  indicates that a password value exists. You can modify password policy requirements in the Admin Console by editing the Password authenticator:  **Security** > **Authenticators** > **Password** (or for Okta Classic orgs, use **Security** > **Authentication** > **Password**).

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Hash** | [**PasswordCredentialHash**](PasswordCredentialHash.md) |  | [optional] 
**Hook** | [**PasswordCredentialHook**](PasswordCredentialHook.md) |  | [optional] 
**Value** | **string** | Specifies the password for a user. The Password Policy validates this password. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

