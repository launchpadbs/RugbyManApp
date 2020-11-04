using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RugbyManager.ClassLibrary.Config;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RugbyManager.API.Utilities
{
    public class Security : ISecurity
    {
        private readonly JWTokenManagement _token;
        private readonly ILogger<Security> _logger;

        public Security(ILogger<Security> logger, IOptions<JWTokenManagement> options)
        {
            _logger = logger;
            _token = options.Value;
        }

        public async Task<string> GenerateJWTokenAsync(string user, IList<string> roles)
        {
            string token = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(user)) return token;

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user));
                claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString(), ClaimValueTypes.DateTime));

                foreach(var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                token = TokenGenerator(claims);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error generating security token for user session with message :{ex.Message}", ex);
                throw ex;
            }
            return token;
        }

        private string TokenGenerator(List<Claim> claims)
        {
            var signKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_token.Secret));
            var cred = new SigningCredentials(signKey, SecurityAlgorithms.HmacSha256Signature);

            var jwToken = new JwtSecurityToken(
                    _token.Issuer,
                    _token.Audience,
                    claims,
                    expires: DateTime.Now.AddMinutes(_token.AccessExpiration),
                    signingCredentials: cred
                );

            return new JwtSecurityTokenHandler().WriteToken(jwToken);
        }
    }
}
