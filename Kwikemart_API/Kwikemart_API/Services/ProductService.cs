using System;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Kwikemart_API.Helpers;

namespace Kwikemart_API.Services
{
    public class ProductService:IProductService
    {

        public SqlConnection con { get; set; }
        public string sort { get; set; }
        private AppSettings _settings;

        public ProductService(IOptions<AppSettings> settings)
        {
            try
            {
                _settings = settings.Value;
                con = new SqlConnection(_settings.Database);
                sort = "Name ASC";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<object> GetProductsAsync(Dictionary<string,string> Filters)
        {
            try
            {
                object result = null;
                
                var parameters = new DynamicParameters();
                using (IDbConnection db = con)
                {
                    string query =
                        "SELECT data.ProductId," +
                        "       data.Name," +
                        "       data.Popularity ," +
                        "       pr.ProductPrice " +
                        "FROM (" +
                        "SELECT  p.ProductId, " +
                        "        MAX(p.ProductDescription) AS Name, " +
                        "        COUNT(pl.ProductId) AS Popularity," +
                        "        MAX(pr.PriceCreationDate) AS PriceCreation " +
                        "FROM    [dbo].[Products] AS p " +
                        "LEFT JOIN [dbo].[ProductsLikes] AS pl" +
                        "    ON p.ProductId = pl.ProductId " +
                        "LEFT JOIN [dbo].[ProductsPrices] AS pr " +
                        "   ON p.ProductId = pr.ProductId " +
                        "WHERE   p.ProductEnabled = 1 " +
                        "    AND p.ProductStock > 0 " +
                        " GROUP BY p.ProductId ) AS data" +
                        " LEFT JOIN[dbo].[ProductsPrices] AS pr " +
                        " ON[data].PriceCreation = pr.PriceCreationDate ";

                    //Get the total number of rows
                    string queryRows = "" +
                        "SELECT COUNT(p.ProductId) " +
                        "FROM   [dbo].[Products] AS p " +
                        "WHERE  p.ProductEnabled = 1" +
                        "   AND p.ProductStock > 0 ";

                    if (Filters.ContainsKey("search"))
                    {
                        query += " WHERE UPPER(data.Name) LIKE UPPER(@Name) ";
                        queryRows += " AND UPPER(p.ProductDescription) LIKE UPPER(@Name) ";
                        parameters.Add("@Name", "%" + Filters["search"] + "%");
                    }

                    query += " ORDER BY " + (Filters.ContainsKey("sort") ? Filters["sort"] : sort);

                    //Applying pagination to query
                    if (Filters.ContainsKey("skip") && Filters.ContainsKey("take"))
                    {
                        query += " OFFSET @skip ROWS " +
                                 " FETCH NEXT @take ROWS ONLY ";

                        parameters.Add("@skip", int.Parse(Filters["skip"]));
                        parameters.Add("@take", int.Parse(Filters["take"]));
                    }

                    var count = await db.QuerySingleAsync<int>(queryRows, parameters);

                    result = await db.QueryAsync<object>(query, parameters);
                    return new Dictionary<string, object>()
                    {
                        {"TotalRows",count.ToString() },
                        {"Data",result }
                    };
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<object> GetProductAsync(string name)
        {
            try
            {
                object result = null;
                var parameters = new DynamicParameters();
                using (IDbConnection db = con)
                {
                    string query =
                        "SELECT  p.ProductId, " +
                        "        MAX(p.ProductDescription) AS Name, " +
                        "        COUNT(pl.ProductId) AS Popularity " +
                        "FROM    [dbo].[Products] AS p " +
                        "LEFT JOIN [dbo].[ProductsLikes] AS pl" +
                        "    ON p.ProductId = pl.ProductId " +
                        "WHERE   p.ProductEnabled = 1 " +
                        "    AND p.ProductStock > 0 " +
                        "    AND UPPER(p.ProductDescription) LIKE '%UPPER(@Name)%'" +
                        " GROUP BY p.ProductId ";

                    parameters.Add("@Name", name);

                    result = await db.QuerySingleOrDefaultAsync<object>(query, parameters);
                }
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task SetProductAsync(object Product, string action)
        {
            try
            {
                string query = string.Empty;
                using (IDbConnection db = con)
                {
                    if (action.Equals("I"))
                    {
                        query = @"INSERT INTO [dbo].[Products]([ProductDescription], [ProductEnabled],[ProductCreationUser],[ProductStock]) " +
                                  "VALUES (@ProductDescription, @ProductEnabled,@ProductCreationUser,@ProductStock)";
                    }
                    else
                    {
                        query = @"UPDATE [dbo].[Products] " +
                                 " SET  [ProductDescription] = ISNULL(@ProductDescription,ProductDescription) ," +
                                 "      [ProductEnabled] = @ProductEnabled," +
                                 "      [ProductStock] = @ProductStock " +
                                 " WHERE [ProductId] = @ProductId ";
                    }
                    var result = await db.ExecuteAsync(query, Product);
                }
            }
            catch(Exception ex)
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
