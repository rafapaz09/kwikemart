using Kwikemart_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kwikemart_API.Services
{
    public interface IUserService
    {

        SqlConnection con { get; set; }
        Task<UserDTO> AuthenticateAsync(string username, string password);

    }
}
