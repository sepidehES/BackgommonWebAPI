using Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackgommonWebAPI.Helper
{
    //JWT : Json Web Token
    public class JwtHelper
    {
    //    //permet de recup les "appsettings.json"
    //    //Acces au valeur de appSetting.json
    //    private readonly IConfiguration _configuration;
    //    public JwtHelper(IConfiguration configuration)
    //    {
    //        _configuration = configuration;
    //    }
    //    public string createToken(Tournament players)
    //    {
    //        //génération des credentials du token
    //        SecurityKey securityKey = new SymmetricSecurityKey(
    //            Encoding.UTF8.GetBytes(_configuration["JWT: Secret"])
    //            );
    //        SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
    //        //informations qui seront contenu dans le JWT
    //        Claim[] claims =
    //        {
    //            new Claim(ClaimTypes.NameIdentifier, players.PlayerId.ToString()),
    //            new Claim(ClaimTypes.Email, players.Email),
    //        };
    //        JwtSecurityToken securityToken = new JwtSecurityToken(
    //            claims: claims,
    //            issuer: _configuration["JWT:Issuer"],
    //            audience: _configuration["JWT:Audience"],
    //            expires: DateTime.Now.AddDays(1),
    //            signingCredentials: credentials
    //            );
    //        //Envoyer le yoken sous la forme d'une chaine de caractere "JWT"
    //        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    //    }

    }
}
