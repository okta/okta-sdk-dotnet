# Okta.Sdk.Model.AuthenticatorProfileTacRequest
Defines the authenticator specific parameters

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**MultiUse** | **bool** | Determines whether the enrollment can be used more than once. To enable multi-use, the org-level authenticator’s configuration must allow multi-use. | [optional] 
**Ttl** | **string** | Time-to-live (TTL) in minutes.  Specifies how long the TAC enrollment is valid after it&#39;s created and activated. The configured value must be between 10 minutes (&#x60;10&#x60;) and 10 days (&#x60;14400&#x60;), inclusive. The actual allowed range depends on the org-level authenticator configuration. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

