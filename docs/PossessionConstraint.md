# Okta.Sdk.Model.PossessionConstraint

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AuthenticationMethods** | [**List&lt;AuthenticationMethodObject&gt;**](AuthenticationMethodObject.md) | This property specifies the precise authenticator and method for authentication. &lt;x-lifecycle class&#x3D;\&quot;oie\&quot;&gt;&lt;/x-lifecycle&gt; | [optional] 
**ExcludedAuthenticationMethods** | [**List&lt;AuthenticationMethodObject&gt;**](AuthenticationMethodObject.md) | This property specifies the precise authenticator and method to exclude from authentication. &lt;x-lifecycle class&#x3D;\&quot;oie\&quot;&gt;&lt;/x-lifecycle&gt; | [optional] 
**Methods** | **List&lt;string&gt;** | The Authenticator methods that are permitted | [optional] 
**ReauthenticateIn** | **string** | The duration after which the user must re-authenticate regardless of user activity. This re-authentication interval overrides the Verification Method object&#39;s &#x60;reauthenticateIn&#x60; interval. The supported values use ISO 8601 period format for recurring time intervals (for example, &#x60;PT1H&#x60;). | [optional] 
**Required** | **bool** | This property indicates whether the knowledge or possession factor is required by the assurance. It&#39;s optional in the request, but is always returned in the response. By default, this field is &#x60;true&#x60;. If the knowledge or possession constraint has values for &#x60;excludedAuthenticationMethods&#x60; the &#x60;required&#x60; value is false. &lt;x-lifecycle class&#x3D;\&quot;oie\&quot;&gt;&lt;/x-lifecycle&gt; | [optional] 
**Types** | **List&lt;string&gt;** | The Authenticator types that are permitted | [optional] 
**DeviceBound** | **string** | Indicates if device-bound Factors are required. This property is only set for &#x60;POSSESSION&#x60; constraints. | [optional] [default to DeviceBoundEnum.OPTIONAL]
**HardwareProtection** | **string** | Indicates if any secrets or private keys used during authentication must be hardware protected and not exportable. This property is only set for &#x60;POSSESSION&#x60; constraints. | [optional] [default to HardwareProtectionEnum.OPTIONAL]
**PhishingResistant** | **string** | Indicates if phishing-resistant Factors are required. This property is only set for &#x60;POSSESSION&#x60; constraints. | [optional] [default to PhishingResistantEnum.OPTIONAL]
**UserPresence** | **string** | Indicates if the user needs to approve an Okta Verify prompt or provide biometrics (meets NIST AAL2 requirements). This property is only set for &#x60;POSSESSION&#x60; constraints. | [optional] [default to UserPresenceEnum.REQUIRED]
**UserVerification** | **string** | Indicates the user interaction requirement (PIN or biometrics) to ensure verification of a possession factor | [optional] [default to UserVerificationEnum.OPTIONAL]

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

