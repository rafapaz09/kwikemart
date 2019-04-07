using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Kwikemart_API.Models;

namespace Kwikemart_API.Services
{
    public class ProductService:IProductService
    {

        public SqlConnection con { get; set; }

        public ProductService()
        {
            try
            {
                con = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Kwikemart;Integrated Security=true");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<object> GetProductsAsync()
        {
            try
            {
                object result = null;
                using (IDbConnection db = con)
                {
                    string query = 
                        "SELECT  ProductId," +
                        "        ProductDescription," +
                        "        ProductState " +
                        "FROM  dbo.Products " +
                        "WHERE ProductState = 1";
                    result = await db.QueryAsync<ProductsDto>(query);
                };
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task SetProductPriceAsync(object ProductPrice)
        {
            try
            {
                using (IDbConnection db = con)
                {
                    string insertQuery = @"INSERT INTO [dbo].[ProductsPrices]([ProductId], [ProductPrice], [PriceCreationUser]) VALUES (@ProductId, @ProductPrice, @PriceCreationUser)";
                    var result = await db.ExecuteAsync(insertQuery, ProductPrice);
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task SetProductLikeAsync(object ProductLike)
        {
            try
            {
                using (IDbConnection db = con)
                {
                    string insertQuery = @"INSERT INTO [dbo].[ProductsLikes]([ProductId], [User]) VALUES (@ProductId, @User)";
                    var result = await db.ExecuteAsync(insertQuery, ProductLike);
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
