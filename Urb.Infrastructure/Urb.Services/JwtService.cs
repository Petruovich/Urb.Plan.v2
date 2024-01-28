using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Urb.Application.App.Settings;
using Urb.Application.ComponentModels;
using Urb.Application.IComponentModels;
using Urb.Application.Urb.IServices;
using Urb.Domain.Urb.Models;

namespace Urb.Infrastructure.Urb.Services
{
    public class JwtService: IJwtService
    {
        private readonly AppSettings _appSettings;
        private readonly User _user;

        public JwtService(IOptions<AppSettings> appSettings, User user)
        {
            _user = user;
            _appSettings = appSettings.Value;
        }

        public string GenerateToken(IUserAuthenticateModel model/*IdentityUser user*/)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_appSettings.JWTKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                { 
                    //new Claim(/*"id"*/"Email", model.Email.ToString()),
                new Claim(/*"id", model.UserId.ToString()*/"Email", model.Email)
                }),                              
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public int? ValidateToken(string token)
        {
            if (token == null)
            {
                return null;
            }

            AppSettings appSettings = new AppSettings();
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(appSettings.JWTKey);

            try
            {
                jwtSecurityTokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(tokenKey),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero

                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                return userId;
            }

            catch
            {
                return null;
            }
        }
    }
}
