using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT.Concrete
{
    public class JWTHelper : ITokenHelper
    {
        TokenOptions _tokenOptions;
        DateTime _accessTokenExpiration;
        public IConfiguration Configuration { get; }

        public JWTHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateAccessToken(User user, List<OperationClaim> operationCalims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwtSecurityToken = CreateJwtSecurityToken(user,operationCalims,_tokenOptions,signingCredentials);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(User user, List<OperationClaim> operationCalims, TokenOptions tokenOptions, SigningCredentials signingCredentials)
        {
            return new JwtSecurityToken(
                audience:tokenOptions.Audience,
                issuer:tokenOptions.Issuer,
                expires: _accessTokenExpiration,
                notBefore:DateTime.Now,
                signingCredentials:signingCredentials,
                claims:SetClaims(user,operationCalims)
                );
        }

        private List<Claim> SetClaims(User user, List<OperationClaim> operationCalims)
        {
            var claims= new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddFullName($"{user.FirstName} {user.LastName}");
            claims.AddClaimRoles(operationCalims.Select(oc=>oc.Name).ToArray());
            return claims;
        }
    }
}
