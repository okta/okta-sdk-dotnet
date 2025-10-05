# Okta.Sdk.Model.LogAuthenticationContext
All authentication relies on validating one or more credentials that prove the authenticity of the actor's identity. Credentials are sometimes provided by the actor, as is the case with passwords, and at other times provided by a third party, and validated by the authentication provider.  The authenticationContext contains metadata about how the actor is authenticated. For example, an authenticationContext for an event, where a user authenticates with Integrated Windows Authentication (IWA), looks like the following: ``` {     \"authenticationProvider\": \"ACTIVE_DIRECTORY\",     \"authenticationStep\": 0,     \"credentialProvider\": null,     \"credentialType\": \"IWA\",     \"externalSessionId\": \"102N1EKyPFERROGvK9wizMAPQ\",     \"interface\": null,     \"issuer\": null } ``` In this case, the user enters an IWA credential to authenticate against an Active Directory instance. All of the user's future-generated events in this sign-in session are going to share the same `externalSessionId`.  Among other operations, this response object can be used to scan for suspicious sign-in activity or perform analytics on user authentication habits (for example, how often authentication scheme X is used versus authentication scheme Y).

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AuthenticationProvider** | **LogAuthenticationProvider** |  | [optional] 
**AuthenticationStep** | **int** | The zero-based step number in the authentication pipeline. Currently unused and always set to &#x60;0&#x60;. | [optional] [readonly] 
**CredentialProvider** | **LogCredentialProvider** |  | [optional] 
**CredentialType** | **LogCredentialType** |  | [optional] 
**ExternalSessionId** | **string** | A proxy for the actor&#39;s [session ID](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html) | [optional] [readonly] 
**Interface** | **string** | The third-party user interface that the actor authenticates through, if any. | [optional] [readonly] 
**Issuer** | [**LogIssuer**](LogIssuer.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

