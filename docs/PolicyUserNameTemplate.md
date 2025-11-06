# Okta.Sdk.Model.PolicyUserNameTemplate
[Okta Expression Language (EL) expression](https://developer.okta.com/docs/reference/okta-expression-language/) to generate or transform a unique username for the IdP user. * IdP user profile attributes can be referenced with the `idpuser` prefix such as `idpuser.subjectNameId`. * You must define an IdP user profile attribute before it can be referenced in an Okta EL expression. To define an IdP user attribute policy, you may need to create a new IdP instance without a base profile property. Then edit the IdP user profile to update the IdP instance with an expression that references the IdP user profile attribute that you just created.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Template** | **string** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

