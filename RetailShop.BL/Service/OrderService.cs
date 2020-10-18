using RetailShop.BL.IService;
using RetailShop.BL.IRepo;
using RetailShop.BL.Models;
using System;

namespace RetailShop.BL.Service
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }
        public int PlaceOrder(Order postObject)
        {
            try
            {
                return _orderRepo.PlaceOrder(postObject);
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
                return _orderRepo.CancelOrder(orderId);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }
    }
}
