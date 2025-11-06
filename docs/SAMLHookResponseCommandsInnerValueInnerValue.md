# Okta.Sdk.Model.SAMLHookResponseCommandsInnerValueInnerValue
The value of the claim that you add or replace, and can also include other attributes. If adding to a claim, add another `value` attribute residing within an array called `attributeValues`.  See the following examples:  #### Simple value (integer or string)  `\"value\": 300` or `\"value\": \"replacementString\"`  #### Attribute value (object)  ` \"value\": {     \"authContextClassRef\": \"replacementValue\"   }`  #### AttributeValues array value (object)  ` \"value\": {     \"attributes\": {       \"NameFormat\": \"urn:oasis:names:tc:SAML:2.0:attrname-format:basic\"     },     \"attributeValues\": [       {\"attributes\": {         \"xsi:type\": \"xs:string\"       },       \"value\": \"4321\"}       ]     }`

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

