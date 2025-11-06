# Okta.Sdk.Model.AuthenticatorKeyTacAllOfProviderConfiguration
Define the configuration settings of the TAC

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**MinTtl** | **decimal** | Minimum time-to-live (TTL) of the TAC in minutes. The &#x60;minTtl&#x60; indicates the minimum amount of time that a TAC is valid. The &#x60;minTtl&#x60; must be less than the &#x60;maxTtl&#x60;. | 
**MaxTtl** | **decimal** | Maximum TTL of the TAC in minutes. The &#x60;maxTtl&#x60; indicates the maximum amount of time that a TAC is valid. The &#x60;maxTtl&#x60; must be greater than the &#x60;minTtl&#x60;. | 
**DefaultTtl** | **decimal** | The default TTL in minutes when you create a TAC. The &#x60;defaultTtl&#x60; indicates the actual amount of time that a TAC is valid before it expires. The &#x60;defaultTtl&#x60; must be greater than the &#x60;minTtl&#x60; and less than the &#x60;maxTtl&#x60;. | [default to 120M]
**Length** | **decimal** | Defines the number of characters in a TAC. For example, a &#x60;length&#x60; of &#x60;16&#x60; means that the TAC is 16 characters. | 
**Complexity** | [**AuthenticatorKeyTacAllOfProviderConfigurationComplexity**](AuthenticatorKeyTacAllOfProviderConfigurationComplexity.md) |  | 
**MultiUseAllowed** | **bool** | Indicates whether a TAC can be used multiple times. If set to &#x60;true&#x60;, the TAC can be used multiple times until it expires. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

