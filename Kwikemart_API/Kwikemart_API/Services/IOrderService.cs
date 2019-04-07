using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kwikemart_API.Services
{
    public interface IOrderService
    {

        SqlConnection con { get; set; }
        Task SetOrderAsync(object Order);
        //Task<object> GetOrderByUserAsync(string user);

    }
}
