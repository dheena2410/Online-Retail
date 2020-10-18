using System;
using Dapper;
using System.Configuration;
using RetailShop.BL.Models;
using RetailShop.BL.IRepo;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace RetailShop.DL
{
    public class OrderRepo : IOrderRepo
    {
        public readonly string Connection = ConfigurationManager.ConnectionStrings["RetailShopConnection"].ConnectionString;

            public int CheckProductAvailability(int productId)
        {
            try
            {
                string query = $"select ProductQuantity from product where ProductId = @productId and Active = 1 ";
                using (IDbConnection connection = new SqlConnection(Connection))
                {
                    var parameters = new
                    {
                        productId
                    };
                    var cmdDef = new CommandDefinition(query, parameters);
                    return connection.ExecuteScalar<int>(cmdDef);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
        public int  PlaceOrder(Order postObject)
        {
            try
            {
                var productQuantity = CheckProductAvailability(postObject.ProductId);
                if (postObject.ProductQuantity > productQuantity)
                {
                    return 0;
                }
                string query = $"Insert into OrderProduct (ProductId,ProductQuantity) values (@ProductId,@ProductQuantity); "
                    + "Update Product set ProductQuantity = ProductQuantity - @ProductQuantity where ProductId = @ProductId";
                using (IDbConnection connection = new SqlConnection(Connection))
                {
                    var parameters = new
                    {
                        postObject.ProductId,
                        postObject.ProductQuantity
                    };
                    var cmdDef = new CommandDefinition(query, parameters);
                    int result = connection.Execute(cmdDef);
                    return result;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public Order getPlacedOrderQuantity(int orderId)
        {
            try
            {
                string query = $"select ProductId,ProductQuantity from OrderProduct where OrderId = @orderId and Active = 1 ";
                using (IDbConnection connection = new SqlConnection(Connection))
                {
                    var parameters = new
                    {
                        orderId
                    };
                    var cmdDef = new CommandDefinition(query, parameters);
                   return connection.Query<Order>(cmdDef).FirstOrDefault();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public int CancelOrder(int orderId)
        {
                try
                {
                    var order = getPlacedOrderQuantity(orderId);
                    string query = $"Update OrderProduct set Active = 0 where OrderId = @orderId and Active = 1;  "
                                  + "Update Product set ProductQuantity = ProductQuantity + @ProductQuantity where ProductId = @ProductId";
                using (IDbConnection connection = new SqlConnection(Connection))
                    {
                        var parameters = new
                        {
                            orderId,
                            order.ProductQuantity,
                            order.ProductId
                        };
                        var cmdDef = new CommandDefinition(query, parameters);
                        int result = connection.Execute(cmdDef);
                        return result;
                    }
                }
                catch (Exception exception)
                {
                Console.WriteLine(exception.Message);
                throw;
            }
            }
    }
}
