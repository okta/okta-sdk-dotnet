# Okta.Sdk.Model.IdentityProviderPolicy
Policy settings for the IdP. The following provisioning and account linking actions are supported by each IdP provider: | IdP type                                                          | User provisioning actions | Group provisioning actions            | Account link actions | Account link filters | | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- | - -- -- -- -- -- -- -- -- -- -- -- -- | - -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- -- | - -- -- -- -- -- -- -- -- -- - | - -- -- -- -- -- -- -- -- -- - | | `SAML2`                                                           | `AUTO` or `DISABLED`      | `NONE`, `ASSIGN`, `APPEND`, or `SYNC` | `AUTO`, `DISABLED`   | `groups`, `users`    | | `X509`, `IDV_PERSONA`, `IDV_INCODE`, and `IDV_CLEAR`              | `DISABLED`                | No support for JIT provisioning       |                      |                      | | All other IdP types                                               | `AUTO`, `DISABLED`        | `NONE` or `ASSIGN`                    | `AUTO`, `DISABLED`   | `groups`, `users`    |

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AccountLink** | [**PolicyAccountLink**](PolicyAccountLink.md) |  | [optional] 
**MaxClockSkew** | **int** | Maximum allowable clock skew when processing messages from the IdP | [optional] 
**Provisioning** | [**Provisioning**](Provisioning.md) |  | [optional] 
**Subject** | [**PolicySubject**](PolicySubject.md) |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

