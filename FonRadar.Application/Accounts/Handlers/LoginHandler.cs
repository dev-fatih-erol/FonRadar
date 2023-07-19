using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FonRadar.Application.Accounts.Commands;
using FonRadar.Application.Accounts.Responses;
using FonRadar.Application.Common.Exceptions;
using FonRadar.Infrastructure.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FonRadar.Application.Accounts.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public LoginHandler(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration configuration)
		{
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
                if (result.Succeeded)
                {
                    var date = DateTime.UtcNow;
                    var roles = await _userManager.GetRolesAsync(user);
                    var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, date.ToUniversalTime().ToString(), ClaimValueTypes.Integer64),
                            new Claim(ClaimTypes.Role, roles.First()),
                        };
                    var securityKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_configuration["JwtConfiguration:SecurityKey"]));
                    var securityToken = new JwtSecurityToken(
                        issuer: _configuration["JwtConfiguration:Issuer"],
                        audience: _configuration["JwtConfiguration:Audience"],
                        claims: claims,
                        notBefore: date,
                        expires: date.AddMinutes(60),
                        signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                    );

                    var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
                    
                    return new LoginResponse
                    {
                        Token = token,
                        Payload = securityToken.Payload
                    };
                }
            }

            throw new BadRequestException("Please try another email address or password.");
        }
    }
}