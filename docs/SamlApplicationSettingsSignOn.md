# Okta.Sdk.Model.SamlApplicationSettingsSignOn
SAML sign-on attributes. > **Note:** Only for SAML 2.0, set either `destinationOverride` or `ssoAcsUrl` to configure any other SAML 2.0 attributes in this section.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**AcsEndpoints** | [**List&lt;AcsEndpoint&gt;**](AcsEndpoint.md) |  | [optional] 
**AllowMultipleAcsEndpoints** | **bool** |  | [optional] 
**AssertionSigned** | **bool** |  | [optional] 
**AttributeStatements** | [**List&lt;SamlAttributeStatement&gt;**](SamlAttributeStatement.md) |  | [optional] 
**Audience** | **string** |  | [optional] 
**AudienceOverride** | **string** | Audience override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm). | [optional] 
**AuthnContextClassRef** | **string** |  | [optional] 
**ConfiguredAttributeStatements** | [**List&lt;SamlAttributeStatement&gt;**](SamlAttributeStatement.md) |  | [optional] 
**DefaultRelayState** | **string** | Identifies a specific application resource in an IdP-initiated SSO scenario | [optional] 
**Destination** | **string** |  | [optional] 
**DestinationOverride** | **string** | Destination override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm). | [optional] 
**DigestAlgorithm** | **string** |  | [optional] 
**HonorForceAuthn** | **bool** | Set to &#x60;true&#x60; to prompt users for their credentials when a SAML request has the &#x60;ForceAuthn&#x60; attribute set to &#x60;true&#x60; | [optional] 
**IdpIssuer** | **string** |  | [optional] 
**InlineHooks** | [**List&lt;SignOnInlineHook&gt;**](SignOnInlineHook.md) |  | [optional] 
**ParticipateSlo** | [**SloParticipate**](SloParticipate.md) |  | [optional] 
**Recipient** | **string** |  | [optional] 
**RecipientOverride** | **string** | Recipient override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm). | [optional] 
**RequestCompressed** | **bool** |  | [optional] 
**ResponseSigned** | **bool** |  | [optional] 
**SamlAssertionLifetimeSeconds** | **int** | For SAML 2.0 only.&lt;br&gt;Determines the SAML app session lifetimes with Okta | [optional] 
**SignatureAlgorithm** | **string** |  | [optional] 
**Slo** | [**SingleLogout**](SingleLogout.md) |  | [optional] 
**SpCertificate** | [**SpCertificate**](SpCertificate.md) |  | [optional] 
**SpIssuer** | **string** |  | [optional] 
**SsoAcsUrl** | **string** | Single Sign-On Assertion Consumer Service (ACS) URL | [optional] 
**SsoAcsUrlOverride** | **string** | Assertion Consumer Service (ACS) URL override for CASB configuration. See [CASB config guide](https://help.okta.com/en-us/Content/Topics/Apps/CASB-config-guide.htm). | [optional] 
**SubjectNameIdFormat** | **string** |  | [optional] 
**SubjectNameIdTemplate** | **string** |  | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

