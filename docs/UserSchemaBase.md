# Okta.Sdk.Model.UserSchemaBase
All Okta-defined profile properties are defined in a profile subschema with the resolution scope `#base`. You can't modify these properties, except to update permissions, to change the nullability of `firstName` and `lastName`, or to specify a pattern for `login`. They can't be removed.  The base user profile is based on the [System for Cross-domain Identity Management: Core Schema](https://tools.ietf.org/html/draft-ietf-scim-core-schema-22#section-4.1.1) and has the standard properties detailed below.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | The subschema name | [optional] [readonly] 
**Properties** | [**UserSchemaBaseProperties**](UserSchemaBaseProperties.md) |  | [optional] 
**Required** | **List&lt;string&gt;** | A collection indicating required property names | [optional] [readonly] 
**Type** | **string** | The object type | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

