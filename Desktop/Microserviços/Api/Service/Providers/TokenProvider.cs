using Model;
using Service.Interfaces;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.IdentityModel.Tokens;

namespace Service.Providers;

public class TokenProvider : ITokenProvider
{
    public string Generate(User user)
    {
        var secret = "segredo_secreto_do_secretamento_secreto";
        var key = Encoding.ASCII.GetBytes(secret);
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescription = new SecurityTokenDescriptor
        {
            Subject =  new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.name),
                new Claim(ClaimTypes.Role, user.isAdmin ? "Admin" : "User"),
                new Claim(ClaimTypes.NameIdentifier, user.id.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(4),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescription);
        
        return tokenHandler.WriteToken(token);

    }
}