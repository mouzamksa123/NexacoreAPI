using App.CommonLayer.DTOModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using NexaComAPI.Helpers.AppSettings;

namespace NexaComAPI.Helpers.JWT
{
    public static class GenerateToken
    {
        public static  UserLoginResponseModel TokenGenration(string username, AppSetting appSettings, string ipAddress)
        {
            try
            {
                UserLoginResponseModel login = new UserLoginResponseModel { UserName = username };
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(appSettings.JWTSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                         new Claim("Key", login.UserName.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(appSettings.JWTSettings.Expires),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);

                login.token = tokenHandler.WriteToken(token);
                login.loginDateTime = DateTime.Now;                
               
                return login;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
