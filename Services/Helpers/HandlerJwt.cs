using Microsoft.IdentityModel.Tokens;
using Services.DTO.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
    public static class HandlerJwt
    {
        public static IEnumerable<Claim> GetClaims(this JwtToken userAccount, Guid Id)
        {
            List<Claim> claims = new List<Claim>() {
                new Claim("Id", userAccount.Id.ToString()),
                new Claim(ClaimTypes.Name, userAccount.UserName),
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("MM ddd dd yyyy HH:mm:ss tt"))

            };

            if (userAccount.Role.ToLower().Equals(Roles.Admin.ToString().ToLower()))
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));

            }
            else if (userAccount.Role.ToLower().Equals( Roles.User.ToString().ToLower()))
            {

                claims.Add(new Claim(ClaimTypes.Role, "User"));
             

            }


            return claims;

        }

        public static IEnumerable<Claim> GetClaims(this JwtToken userAccount, out Guid Id)
        {
            Id = Guid.NewGuid();
            return GetClaims(userAccount, Id);


        }

        public static JwtToken GenerateToken(JwtToken model, JwtSettings jwtSenttings)
        {
            try
            {
                var userToken = new JwtToken();
                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }

                // obteniendo llave secreta

                var key = System.Text.Encoding.ASCII.GetBytes(jwtSenttings.IssueSigningKey);

                Guid Id;

                //expiracion del token 

                DateTime expireTime = DateTime.UtcNow.AddDays(1);

                // validar token 
                userToken.Validity = expireTime.TimeOfDay;

                // GENERAr nuestro token 

                var jwToken = new JwtSecurityToken(

                    issuer: jwtSenttings.ValidIssuer,
                    audience: jwtSenttings.ValidAudience,
                    claims: GetClaims(model, out Id),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(expireTime).DateTime,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256
                        ));


                userToken.Token = new JwtSecurityTokenHandler().WriteToken(jwToken);

                userToken.UserName = model.UserName;
                userToken.Id = model.Id;
              

                return userToken;



            }
            catch (Exception e)
            {
                throw new Exception("Error Generation the JWT", e);

            }
        }


    }
}

