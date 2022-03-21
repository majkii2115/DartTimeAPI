using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DartTimeAPI.DTOs;
using DartTimeAPI.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace DartTimeAPI.Repositories
{
    public class TokenRepo : ITokenRepo
    {
        #region Variables
        private readonly SymmetricSecurityKey _key;
        #endregion

        #region Constructor
        public TokenRepo(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }
        #endregion

        #region Methods
        public string CreateToken(UserDTO user)
        {
            var claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.NameId, user.Username)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(10),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        #endregion
    }
}