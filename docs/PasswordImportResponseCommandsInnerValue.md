# Okta.Sdk.Model.PasswordImportResponseCommandsInnerValue
The parameter value of the command. * To indicate that the supplied credentials are valid, supply a type property set to `com.okta.action.update` together with a value property set to `{\"credential\": \"VERIFIED\"}`. * To indicate that the supplied credentials are invalid, supply a type property set to `com.okta.action.update` together with a value property set to `{\"credential\": \"UNVERIFIED\"}`. Alternatively, you can send an empty response (`204`). By default, the `data.action.credential` is always set to `UNVERIFIED`.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Credential** | **string** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

