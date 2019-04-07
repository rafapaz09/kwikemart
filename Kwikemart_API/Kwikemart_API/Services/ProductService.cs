﻿using System;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Kwikemart_API.Services
{
    public class ProductService:IProductService
    {

        public SqlConnection con { get; set; }
        public string sort { get; set; }

        public ProductService()
        {
            try
            {
                con = new SqlConnection("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Kwikemart;Integrated Security=true");
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
                        "       data.Popularity " +
                        "FROM (" +
                        "SELECT  p.ProductId, " +
                        "        MAX(p.ProductDescription) AS Name, " +
                        "        COUNT(pl.ProductId) AS Popularity " +
                        "FROM    [dbo].[Products] AS p " +
                        "LEFT JOIN [dbo].[ProductsLikes] AS pl" +
                        "    ON p.ProductId = pl.ProductId " +
                        "WHERE   p.ProductEnabled = 1 " +
                        "    AND p.ProductStock > 0 " +
                        " GROUP BY p.ProductId ) AS data" +
                        " ORDER BY " + (Filters.ContainsKey("sort") ? Filters["sort"] : sort);

                    //Applying pagination to query
                    if (Filters.ContainsKey("skip") && Filters.ContainsKey("take"))
                    {
                        query += " OFFSET @skip ROWS " +
                                 " FETCH NEXT @take ROWS ONLY ";

                        parameters.Add("@skip", int.Parse(Filters["skip"]));
                        parameters.Add("@take", int.Parse(Filters["take"]));
                    }

                    result = await db.QueryAsync<object>(query, parameters);
                };
                return result;
            }
            catch (Exception ex)
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
