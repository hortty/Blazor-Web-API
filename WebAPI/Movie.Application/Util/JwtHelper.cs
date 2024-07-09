using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlazorWebApp.Util
{
    public class JwtHelper
    {

        public JwtHelper()
        {
        }

        public static string GenerateJwtToken(Guid id, string nome, string role)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                int expiresTime = 2;
                //TODO: colocar no Appsettings
                var key = Encoding.ASCII.GetBytes("44fbff63fe7af888051137e46eec30be79dd7a4d");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                        new Claim(ClaimTypes.Name, nome),
                        new Claim(ClaimTypes.Role, role)
                    }),
                    Expires = DateTime.UtcNow.AddHours(expiresTime),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
