using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Kwikemart_API.Services
{
    public interface IProductService
    {
        
        SqlConnection con { get; set; }

        //Get All the available Products
        Task<object> GetProductsAsync();

        //Modifying a product or adding new one
        Task SetProductAsync(object Product, string action);

        //Set Price to a product
        Task SetProductPriceAsync(object ProductPrice);

        //Set a like to a product
        Task SetProductLikeAsync(object ProductLike);


    }
}
