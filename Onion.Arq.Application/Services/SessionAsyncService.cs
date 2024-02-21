using AutoMapper;
using Onion.Arq.Application.Interfaces;
using Onion.Arq.Application.Interfaces.Services;
using Onion.Arq.Application.Models;
using Onion.Arq.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Onion.Arq.Application.Services
{
    public class SessionAsyncService : ISessionAsyncService
    {
        private readonly IUserQueryService _userService;
        private readonly IConfiguration _conf;

        public SessionAsyncService(IUserQueryService userService, IConfiguration conf)
        {
            _userService = userService;
            _conf = conf;
        }
        public async Task<SessionDto> GetSessionAsync(string email, string password)
        {
            UserDto userDto = await _userService.GetByEmailAsync(email)
                ?? throw new Exception("Incorrect Credentials");

            if (userDto.Password != password)
                throw new Exception("wrong user or password");

            userDto.Password = null;

            SessionDto session = new SessionDto()
            {
                User = userDto,
                CreatedDate = DateTime.Now,
                Activated = true,
                Active = true,
                Token = GetTokenJWT(userDto)
            };

            return session;
        }

        private string GetTokenJWT(UserDto userInfo)
        {
            // Creating the headers
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_conf["JWT:SecretKey"])
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            // Claims
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, userInfo.Id.ToString()),
                new Claim("name", userInfo.Name),
                new Claim("lastname", userInfo.LastName),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email)
            };

            // Creating the payload 
            var _Payload = new JwtPayload(
                    issuer: _conf["JWT:Issuer"],
                    audience: _conf["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    // Exipra a la 24 horas.
                    expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(_conf["JWT:Timeout"]))
                );

            // Generating the token 
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
    }
}
