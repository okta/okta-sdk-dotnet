# Okta.Sdk.Model.UserActivationToken

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**ActivationToken** | **string** | Token received as part of an activation user request. If a password was set before the user was activated, then user must sign in with their password or the &#x60;activationToken&#x60; and not the activation link. More information about using the &#x60;activationToken&#x60; to login can be found in the [Authentication API](https://developer.okta.com/docs/reference/api/authn/#primary-authentication-with-activation-token). | [optional] [readonly] 
**ActivationUrl** | **string** | If &#x60;sendEmail&#x60; is &#x60;false&#x60;, returns an activation link for the user to set up their account. The activation token can be used to create a custom activation link. | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

