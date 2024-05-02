using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Okta.Sdk.Client
{
    public interface IDpopProofJwtGenerator
    {
        /// <summary>
        /// Dispose of the existing keys and create a new RSA key set.
        /// </summary>
        void RotateKeys();

        string GenerateJWT(String? nonce = null, String? httpMethod = null, String? uri = null, String? accessToken = null);
    }
    public class DefaultDpopProofJwtGenerator : IDpopProofJwtGenerator 
    {
        
        private readonly IReadableConfiguration _configuration;
        private RSA _rsa;

        public DefaultDpopProofJwtGenerator(IReadableConfiguration configuration)
        {
            _rsa = RSA.Create();

            if (configuration == null)
            {
                throw new ArgumentNullException("The Okta configuration cannot be null.");
            }

            _configuration = configuration;
        }

        /// <summary>
        /// Dispose of the existing keys and create a new RSA key set.
        /// </summary>
        public void RotateKeys()
        {
            _rsa.Clear();
            _rsa.Dispose();

            _rsa = RSA.Create();
        }

        /// <summary>
        /// Generate a new DPoP Proof JWT
        /// </summary>
        /// <param name="nonce">The nonce</param>
        /// <param name="httpMethod">The HTTP method of the request</param>
        /// <param name="uri">The HTTP URI of the request (without query and fragment parts)</param>
        /// <param name="accessToken">The access token</param>
        /// <returns>A DPoP Proof JWT</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public string GenerateJWT(String? nonce = null, String? httpMethod = null, String? uri = null, String? accessToken = null)
        {
            try
            {
                TimeSpan timeSpanIat = DateTime.UtcNow - new DateTime(1970, 1, 1);

                var payload = new JwtPayload
                {
                    { "htm", httpMethod ?? "POST" },
                    { "htu", uri ?? $"{ClientUtils.EnsureTrailingSlash(_configuration.OktaDomain)}oauth2/v1/token" },
                    { "iat", (int)timeSpanIat.TotalSeconds },
                    { "jti", Guid.NewGuid()}
                };

                if (!nonce.IsNullOrEmpty())
                {
                    payload.AddClaim(new Claim("nonce", nonce));
                }

                if (!accessToken.IsNullOrEmpty())
                {
                    payload.AddClaim(new Claim("ath", HashAccessTokenForDpopProof(accessToken)));
                }

                var publicKey = new RsaSecurityKey(_rsa.ExportParameters(false));
                var publicJsonWebKey = JsonWebKeyConverter.ConvertFromRSASecurityKey(publicKey);

                RsaSecurityKey keys = new RsaSecurityKey(_rsa.ExportParameters(true));

                var signingCredentials = new SigningCredentials(keys, SecurityAlgorithms.RsaSha256);
                
                var outboundAlgorithmMap = new Dictionary<string, string> { { "alg", SecurityAlgorithms.RsaSha256 } };

                var additionalHeaders = new Dictionary<string, object> { { "jwk", publicJsonWebKey } };

                var securityToken =
                    new JwtSecurityToken(
                        new JwtHeader(signingCredentials, outboundAlgorithmMap, "dpop+jwt", additionalHeaders),
                        payload);

                return new JwtSecurityTokenHandler().WriteToken(securityToken);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Something went wrong when creating the signed JWT. Verify your private key.", e);
            }
        }

        /// <summary>
        /// Hash of the access token. The value MUST be the result of a base64url encoding (as defined in Section 2 of [RFC7515]) the SHA-256 [SHS] hash of the ASCII encoding of the associated access token's value.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>The hash of the access token.</returns>
        private string HashAccessTokenForDpopProof(string accessToken)
        {
            var encodedAccessTokenBytes = Encoding.ASCII.GetBytes(accessToken);
            
            // Create an instance of SHA-256 algorithm
            using SHA256 sha256 = SHA256.Create();
            
            // Compute the hash
            var hashBytes = sha256.ComputeHash(encodedAccessTokenBytes);

            // Perform base64url encoding on the hash
            return ClientUtils.Base64UrlEncode(hashBytes);
        }

    }
}
