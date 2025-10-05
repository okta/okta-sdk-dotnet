# Okta.Sdk.Model.UserSchemaPublic
All custom profile properties are defined in a profile subschema with the resolution scope `#custom`.  > **Notes:**  > * When you refer to custom profile attributes that differ only by case, name collisions occur. This includes naming custom profile attributes the same as base profile attributes, for example, `firstName` and `FirstName`. > * Certain attributes are reserved and can't be used for custom user profiles. See [Review reserved attributes](https://help.okta.com/okta_help.htm?type=oie&id=reserved-attributes).

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | The subschema name | [optional] [readonly] 
**Properties** | [**Dictionary&lt;string, UserSchemaAttribute&gt;**](UserSchemaAttribute.md) | The &#x60;#custom&#x60; object properties | [optional] 
**Required** | **List&lt;string&gt;** | A collection indicating required property names | [optional] [readonly] 
**Type** | **string** | The object type | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

