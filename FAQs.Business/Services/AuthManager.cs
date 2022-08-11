using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FAQs.Data.DTOs;
using FAQs.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FAQs.Business.Services;

public class AuthManager : IAuthManager
{
    private readonly UserManager<ApiUser> _userManager;
    private readonly IConfiguration _configuration;
    private ApiUser _user;

    public AuthManager(UserManager<ApiUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<bool> ValidateUser(LoginUserDto userDto)
    {
        _user = await _userManager.FindByNameAsync(userDto.Email);
        return (_user != null && await _userManager.CheckPasswordAsync(_user, userDto.Password));
    }

    public async Task<string> CreateToken()
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaims();
        var token = GenerateTokenOptions(signingCredentials, claims);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var jwtSettings = _configuration.GetSection("Jwt");

        var token = new JwtSecurityToken(
            issuer: jwtSettings.GetSection("Issuer").Value,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("lifetime").Value)),
            signingCredentials: signingCredentials
        );

        return token;
    }

    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, _user.UserName)
        };

        var roles = await _userManager.GetRolesAsync(_user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        return claims;
    }

    private SigningCredentials GetSigningCredentials()
    {
        var key = Environment.GetEnvironmentVariable("KEY") ?? Guid.NewGuid().ToString();
        
        var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }
}