# Okta.Sdk.Model.SsprPrimaryRequirement
Defines the authenticators permitted for the initial authentication step of password recovery

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**MethodConstraints** | [**List&lt;AuthenticatorMethodConstraint&gt;**](AuthenticatorMethodConstraint.md) | Constraints on the values specified in the &#x60;methods&#x60; array. Specifying a constraint limits methods to specific authenticator(s). Currently, Google OTP is the only accepted constraint. | [optional] 
**Methods** | **List&lt;string&gt;** | Authenticator methods allowed for the initial authentication step of password recovery. Method &#x60;otp&#x60; requires a constraint limiting it to a Google authenticator. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

