using AutoMapper.Configuration;
using Microsoft.IdentityModel.Tokens;
using NyaaySetu.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;


namespace NyaaySetu.Authentication
{
    public class JwtToken : IJwtToken
    {
        private readonly IConfiguration _config;
        public JwtToken(IConfiguration configuration)
        {
                _config = configuration;
        }
        public string GeneratJwtToken(UserModel userModel)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
           {
                new Claim(ClaimTypes.NameIdentifier, userModel.UserId.ToString()),
                new Claim(ClaimTypes.Name, userModel.Name.ToString()),
                new Claim(ClaimTypes.MobilePhone, userModel.MobileNumber.ToString()),
                new Claim(ClaimTypes.Role,userModel.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string RefreshJwtToken(UserModel userModel)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
           {
                new Claim(ClaimTypes.NameIdentifier, userModel.UserId.ToString()),
                new Claim(ClaimTypes.Name, userModel.Name.ToString()),
                new Claim(ClaimTypes.MobilePhone, userModel.MobileNumber.ToString()),
                new Claim(ClaimTypes.Role,userModel.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(15),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
