using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DOTNET_Day5;
using Microsoft.IdentityModel.Tokens;
public class JwtService : IJwtService
{
    private readonly string _key;
    private readonly string _issuer;
    private readonly string _audience;
    private readonly int _expiryMinutes;
    public JwtService(IConfiguration configuration)
    {
        _key = configuration["JwtSettings:Key"] ?? throw new InvalidOperationException("JWT Key is missing");
        _issuer = configuration["JwtSettings:Issuer"] ?? throw new InvalidOperationException("JWT Issuer is missing");
        _audience = configuration["JwtSettings:Audience"] ?? throw new InvalidOperationException("JWT Audience is missing");
        _expiryMinutes = int.TryParse(configuration["JwtSettings:ExpiryMinutes"], out int expiry) ? expiry : 10;
    }
    public string GenerateToken(string username)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username)
        };

        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_expiryMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
