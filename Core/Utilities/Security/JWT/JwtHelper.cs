using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get;}
        private TokenOptions _options;
        private DateTime _expiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _options = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _expiration = DateTime.Now.AddHours(_options.AccessTokenExpiration);
            var security = SecurityKeyHelper.CreateSecurityKey(_options.SecurityKey);
            var signingCrentials = SigningCredentialsHelper.CreateSigningCredentials(security);
            var jwt = CreateJwtSecurityToken(_options,user,signingCrentials,operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _expiration,
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions options,User user,SigningCredentials signingCredentials,List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: options.Issuer,
                audience: options.Audience,
                expires : _expiration,
                signingCredentials: signingCredentials,
                notBefore:DateTime.Now,
                claims: SetClaims(user,operationClaims)
                );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user,List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddName($"{user.FirstName}{user.LastName}");
            claims.AddEmail(user.Email);
            claims.AddRoles(operationClaims.Select(x=>x.Name).ToArray());
            return claims;
        }

    }
}
