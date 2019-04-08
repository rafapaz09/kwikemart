using Kwikemart_API.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Kwikemart_API.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace Kwikemart_API.Services
{
    public class UserService:IUserService
    {

        public SqlConnection con { get; set; }

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<UserDTO> _users = new List<UserDTO>
        {
            new UserDTO { UserName = "admin", Password = "admin", Role = "Admin" },
            new UserDTO { UserName = "user", Password = "user", Role = "User" }
        };

        private AppSettings _settings;

        public UserService(IOptions<AppSettings> settings)
        {
            try
            {
                _settings = settings.Value;
                con = new SqlConnection(_settings.Database);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static string sha256(string stringHashable)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(stringHashable));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        public async Task<UserDTO> AuthenticateAsync(string UserName, string Password)
        {
            try
            {
                var parameters = new DynamicParameters();
                string PasswordHashable = sha256(Password);
                UserDTO user = new UserDTO();
                using (IDbConnection db = con)
                {
                    string query =
                        "   SELECT     u.UserName," +
                        "              r.RoleName AS Role" +
                        "   FROM       [dbo].[Users] AS u" +
                        "   INNER JOIN [dbo].[UsersRoles] AS ur" +
                        "       ON     u.UserName = ur.UserName" +
                        "   INNER JOIN [dbo].[Roles] AS r" +
                        "       ON     r.RoleId = ur.RoleId" +
                        "   WHERE      u.UserName = @UserName" +
                        "       AND    u.Password = @Password" +
                        "       AND    u.Enabled = 1";

                    parameters.Add("@UserName", UserName);
                    parameters.Add("@Password", PasswordHashable);
                    user = db.QuerySingleOrDefault<UserDTO>(query, parameters);

                    //return null if user not found
                    if (user == null)
                        return null;

                    var handler = new JwtSecurityTokenHandler();
                    var keyValue = Encoding.ASCII.GetBytes(_settings.Secret);
                    var Descriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim(ClaimTypes.Name,user.UserName),
                        new Claim(ClaimTypes.Role,user.Role)
                        }),
                        Expires = DateTime.UtcNow.AddHours(8),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyValue), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = handler.CreateToken(Descriptor);
                    user.Token = handler.WriteToken(token);
                    user.Password = null;
                    return user;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
