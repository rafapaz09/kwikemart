using System;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using Kwikemart_API.Models;
using System.Collections.Generic;
using System.Linq;

namespace Kwikemart_API.Services
{
    public class OrderService:IOrderService
    {

        public SqlConnection con { get; set; }

        public OrderService()
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

        public async Task SetOrderAsync(object Order)
        {
            try
            {
                string query = string.Empty;
                List<OrdersDetailsDto> detail = new List<OrdersDetailsDto>();

                detail = (List<OrdersDetailsDto>)((OrdersDto)Order).OrderDetails;
                if (detail.Count > 0)
                {
                    using (IDbConnection db = con)
                    {
                        db.Open();
                        using (var transaction = db.BeginTransaction())
                        {

                            //Creating new orderid
                            query = @"INSERT INTO [dbo].[Orders]([OrderUser]) VALUES (@OrderUser) " +
                                     "SELECT CAST(SCOPE_IDENTITY() AS INT)";

                            var id = await db.QuerySingleAsync<int>(query, Order, transaction);

                            //Setting new order ir to all the details
                            detail.Select(c => { c.OrderId = id; return c; }).ToList();

                            //Inserting all the order details
                            query = @"INSERT INTO [dbo].[ProductsOrders]([OrderId],[ProductId],[Quantity]) VALUES(@OrderId,@ProductId,@Quantity)";
                            var result = await db.ExecuteAsync(query, detail, transaction);
                            transaction.Commit();
                        }
                    }
                }
            }
            catch(SqlException sqex)
            {
                if(sqex.Number >= 50000)
                {
                    throw new Exception(sqex.Message);
                }
                else
                {
                    throw new Exception("An error ocurred on the database");
                }
            }
            catch(Exception ex)
            {   
                throw new Exception(ex.Message);
            }
        }

        //public Task<object> GetOrderByUserAsync(string user)
        //{
        //    try
        //    {

        //    }
        //    catch(Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

    }
}
