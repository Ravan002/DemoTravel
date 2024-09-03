using Core.Entites.Concrete;
using Core.Extensions;
using Core.Helpers.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Helpers.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        private IConfiguration _configuration { get; }
        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        private TokenOptions _tokenOptions;
        private DateTime _expirationDate;

        public AccessToken CreateAccessToken(User user, List<OperationClaim> operationClaims)
        {
            _expirationDate = DateTime.UtcNow.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredential(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, signingCredentials, user, operationClaims);
            var jwtSecurityHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityHandler.WriteToken(jwt);


            return new AccessToken
            {
                Expiration = _expirationDate,
                Token = token,
            };
        }

        private SecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, SigningCredentials signingCredentials, User user, List<OperationClaim> operationClaims)
        {
            var jwtSecurityToken = new JwtSecurityToken(
               issuer: tokenOptions.Issuer,
               audience: tokenOptions.Audience,
               expires: _expirationDate,
               notBefore: DateTime.UtcNow,
               signingCredentials: signingCredentials,
               claims: SetClaims(user, operationClaims)
                );

            return jwtSecurityToken;
        }

        private static List<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            List<Claim> claims = [];
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            //    [
            //    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            //    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
            //    new Claim(ClaimTypes.Email, user.Email),
            //    ];

            //foreach (var claim in operationClaims)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, claim.Name));
            //}

            return claims;
        }
    }
}
