# Okta.Sdk.Model.UserSchema

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Schema** | **string** | JSON schema version identifier | [optional] [readonly] 
**Created** | **string** | Timestamp when the schema was created | [optional] [readonly] 
**Definitions** | [**UserSchemaDefinitions**](UserSchemaDefinitions.md) | User profile subschemas  The profile object for a user is defined by a composite schema of base and custom properties using a JSON path to reference subschemas. The &#x60;#base&#x60; properties are defined and versioned by Okta, while &#x60;#custom&#x60; properties are extensible. Custom property names for the profile object must be unique and can&#39;t conflict with a property name defined in the &#x60;#base&#x60; subschema. | [optional] 
**Id** | **string** | URI of user schema | [optional] [readonly] 
**LastUpdated** | **string** | Timestamp when the schema was last updated | [optional] [readonly] 
**Name** | **string** | Name of the schema | [optional] [readonly] 
**Properties** | [**UserSchemaProperties**](UserSchemaProperties.md) | User Object Properties | [optional] 
**Title** | **string** | User-defined display name for the schema | [optional] 
**Type** | **string** | Type of [root schema](https://tools.ietf.org/html/draft-zyp-json-schema-04#section-3.4) | [optional] [readonly] 
**Links** | [**LinksSelf**](LinksSelf.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

