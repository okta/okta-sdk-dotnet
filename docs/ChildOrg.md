# Okta.Sdk.Model.ChildOrg

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Admin** | [**OrgCreationAdmin**](OrgCreationAdmin.md) |  | 
**Created** | **DateTimeOffset** | Timestamp when the org was created | [optional] [readonly] 
**Edition** | **string** | Edition for the org. &#x60;SKU&#x60; is the only supported value. | 
**Id** | **string** | Org ID | [optional] [readonly] 
**LastUpdated** | **DateTimeOffset** | Timestamp when the org was last updated | [optional] [readonly] 
**Name** | **string** | Unique name of the org. This name appears in the HTML &#x60;&lt;title&gt;&#x60; tag of the new org sign-in page. Only less than 4-width UTF-8 encoded characters are allowed. | 
**Settings** | **Dictionary&lt;string, Object&gt;** | Settings associated with the created org | [optional] [readonly] 
**Status** | **string** | Status of the org. &#x60;ACTIVE&#x60; is returned after the org is created. | [optional] [readonly] 
**Subdomain** | **string** | Subdomain of the org. Must be unique and include no spaces. | 
**Token** | **string** | API token associated with the child org super admin account. Use this API token to provision resources (such as policies, apps, and groups) on the newly created child org. This token is revoked if the super admin account is deactivated. &gt; **Note:** If this API token expires, sign in to the Admin Console as the super admin user and create a new API token. See [Create an API token](https://developer.okta.com/docs/guides/create-an-api-token/). | [optional] [readonly] 
**TokenType** | **string** | Type of returned &#x60;token&#x60;. See [Okta API tokens](https://developer.okta.com/docs/guides/create-an-api-token/main/#okta-api-tokens). | [optional] [readonly] 
**Website** | **string** | Default website for the org | [optional] 
**Links** | **Dictionary&lt;string, Object&gt;** | Specifies available link relations (see [Web Linking](https://www.rfc-editor.org/rfc/rfc8288)) using the [JSON Hypertext Application Language](https://datatracker.ietf.org/doc/html/draft-kelly-json-hal-06) specification | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

