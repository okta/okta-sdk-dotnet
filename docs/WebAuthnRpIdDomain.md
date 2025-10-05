# Okta.Sdk.Model.WebAuthnRpIdDomain
The RP domain object for the WebAuthn configuration

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**DnsRecord** | [**WebAuthnRpIdDomainDnsRecord**](WebAuthnRpIdDomainDnsRecord.md) |  | [optional] 
**Name** | **string** | The [RP ID](https://www.w3.org/TR/webauthn/#relying-party-identifier) domain value to be used for all WebAuthn operations.   If it isn&#39;t specified, the &#x60;domain&#x60; object isn&#39;t included in the request, and the domain value defaults to the domain of the current page (the domain of your org or a custom domain, for example).   &gt; **Note:** If you don&#39;t use a custom RP ID (the default behavior), the domain value defaults to the end user&#39;s current page. The domain value defaults to the full domain name of the page that the end user is on when they&#39;re attempting the WebAuthn credential operation (enrollment or verification). | [optional] 
**ValidationStatus** | **string** | Indicates the validation status of the domain | [optional] [readonly] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

