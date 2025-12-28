using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NTierArchTestProject.BusinessLogicLayer.Abstractions;
using NTierArchTestProject.CoreLayer.Options;
using NTierArchTestProject.DataAccessLayer.Context;
using NTierArchTestProject.DataAccessLayer.Identity.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NTierArchTestProject.BusinessLogicLayer.Services
{

    internal sealed class JwtProvider : IJwtProvider
    {
        private readonly AppDbContext _context;
        private readonly JwtOption _jwtOption;
                                               //OptionPattern
        public JwtProvider(AppDbContext context, IOptions<JwtOption> jwtOption)
        {
            _context = context;
            _jwtOption = jwtOption.Value;
        }
        public async Task<string> CreateTokenAsync(AppUser user)
        {
            //Add Claim
            Claim[] claims = new Claim[]
            {
                new Claim("NameSurname",user.NameSurname),
                new Claim(ClaimTypes.Email,user.Email!),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };
            //CreateToken
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
                (issuer: _jwtOption.Issuer,
                audience: _jwtOption.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddSeconds(20),//biz burda test amaçlı 20 saniye dedik ama en az 10dk olmalı en fazla 30dk
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.SecretKey)), SecurityAlgorithms.HmacSha512)
                );
            JwtSecurityTokenHandler jwtHandler=new JwtSecurityTokenHandler();
            string token = jwtHandler.WriteToken(jwtSecurityToken);
            return token;
        }
    }
}
