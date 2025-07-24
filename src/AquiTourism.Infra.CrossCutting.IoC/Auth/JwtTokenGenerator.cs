using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public static class JwtTokenGenerator
{
    public static string GenerateToken(int userId, string userName, string secretKey, int expireMinutes = 60)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, userName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "AquiTourism",
            audience: "AquiTourism",
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expireMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public static int? GetOperatorIdFromToken(string jwtToken)
    {
        if(string.IsNullOrEmpty(jwtToken))
            return null;

        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(jwtToken);

        var idClaim = token.Claims.FirstOrDefault(c => c.Type == "sub" || c.Type == "id");
        if(idClaim == null)
            return null;

        if(int.TryParse(idClaim.Value, out int operatorId))
            return operatorId;

        return null;
    }
}