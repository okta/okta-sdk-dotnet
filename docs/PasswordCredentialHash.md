# Okta.Sdk.Model.PasswordCredentialHash
Specifies a hashed password to import into Okta. This allows an existing password to be imported into Okta directly from some other store. Okta supports the BCRYPT, SHA-512, SHA-256, SHA-1, MD5, and PBKDF2 hash functions for password import.  A hashed password may be specified in a password object when creating or updating a user, but not for other operations.  See the [Create user with imported hashed password](https://developer.okta.com/docs/api/openapi/okta-management/management/tag/User/#create-user-with-imported-hashed-password) description. When you update a user with a hashed password, the user must be in the `STAGED` status.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Algorithm** | **PasswordCredentialHashAlgorithm** |  | [optional] 
**DigestAlgorithm** | **DigestAlgorithm** |  | [optional] 
**IterationCount** | **int** | The number of iterations used when hashing passwords using PBKDF2. Must be &gt;&#x3D; 4096. Only required for PBKDF2 algorithm. | [optional] 
**KeySize** | **int** | Size of the derived key in bytes. Only required for PBKDF2 algorithm. | [optional] 
**Salt** | **string** | Only required for salted hashes. For BCRYPT, this specifies Radix-64 as the encoded salt used to generate the hash, which must be 22 characters long. For other salted hashes, this specifies the Base64-encoded salt used to generate the hash. | [optional] 
**SaltOrder** | **string** | Specifies whether salt was pre- or postfixed to the password before hashing. Only required for salted algorithms. | [optional] 
**Value** | **string** | For SHA-512, SHA-256, SHA-1, MD5, and PBKDF2, this is the actual base64-encoded hash of the password (and salt, if used). This is the Base64-encoded &#x60;value&#x60; of the SHA-512/SHA-256/SHA-1/MD5/PBKDF2 digest that was computed by either pre-fixing or post-fixing the &#x60;salt&#x60; to the &#x60;password&#x60;, depending on the &#x60;saltOrder&#x60;. If a &#x60;salt&#x60; was not used in the &#x60;source&#x60; system, then this should just be the Base64-encoded &#x60;value&#x60; of the password&#39;s SHA-512/SHA-256/SHA-1/MD5/PBKDF2 digest. For BCRYPT, this is the actual Radix-64 encoded hashed password. | [optional] 
**WorkFactor** | **int** | Governs the strength of the hash and the time required to compute it. Only required for BCRYPT algorithm. | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

