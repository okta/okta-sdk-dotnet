# Okta.Sdk.Model.UserSchemaDefinitions
User profile subschemas  The profile object for a user is defined by a composite schema of base and custom properties using a JSON path to reference subschemas. The `#base` properties are defined and versioned by Okta, while `#custom` properties are extensible. Custom property names for the profile object must be unique and can't conflict with a property name defined in the `#base` subschema.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Base** | [**UserSchemaBase**](UserSchemaBase.md) |  | [optional] 
**Custom** | [**UserSchemaPublic**](UserSchemaPublic.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

