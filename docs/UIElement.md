# Okta.Sdk.Model.UIElement
Specifies the configuration of an input field on an enrollment form

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Label** | **string** | Label name for the UI element | [optional] 
**Options** | [**UIElementOptions**](UIElementOptions.md) |  | [optional] 
**Scope** | **string** | Specifies the property bound to the input field. It must follow the format &#x60;#/properties/PROPERTY_NAME&#x60; where &#x60;PROPERTY_NAME&#x60; is a variable name for an attribute in &#x60;profile editor&#x60;. | [optional] 
**Type** | **string** | Specifies the relationship between this input element and &#x60;scope&#x60;. The &#x60;Control&#x60; value specifies that this input controls the value represented by &#x60;scope&#x60;. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

