# Okta.Sdk.Model.OrgGeneralSettingLinks
Specifies link relations (see [Web Linking](https://www.rfc-editor.org/rfc/rfc8288)) available for the org using the [JSON Hypertext Application Language](https://datatracker.ietf.org/doc/html/draft-kelly-json-hal-06) specification

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Contacts** | [**HrefObject**](HrefObject.md) | Link to the [Org Contacts](/openapi/okta-management/management/tag/OrgSettingContact/) resource | [optional] 
**Logo** | [**HrefObject**](HrefObject.md) | Link to the org logo | [optional] 
**OktaCommunication** | [**HrefObject**](HrefObject.md) | Link to the [Org Communication Settings](/openapi/okta-management/management/tag/OrgSettingCommunication/) resource | [optional] 
**OktaSupport** | [**HrefObject**](HrefObject.md) | Link to the [Org Support Settings](/openapi/okta-management/management/tag/OrgSettingSupport/) resource | [optional] 
**Preferences** | [**HrefObject**](HrefObject.md) | Link to the [Org Preferences](/openapi/okta-management/management/tag/OrgSettingCustomization/#tag/OrgSettingCustomization/operation/getOrgPreferences) resource | [optional] 
**UploadLogo** | [**HrefObject**](HrefObject.md) | Link to the [Upload Org Logo](/openapi/okta-management/management/tag/OrgSettingCustomization/#tag/OrgSettingCustomization/operation/uploadOrgLogo) resource | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

