# Okta.Sdk.Model.OrgCreationAdmin
Profile and credential information for the first super admin user of the child org. If you plan to configure and manage the org programmatically, create a system user with a dedicated email address and a strong password. > **Note:** If you don't provide `credentials`, the super admin user is prompted to set up their credentials when they sign in to the org for the first time.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Credentials** | [**OrgCreationAdminCredentials**](OrgCreationAdminCredentials.md) |  | [optional] 
**Profile** | [**OrgCreationAdminProfile**](OrgCreationAdminProfile.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

