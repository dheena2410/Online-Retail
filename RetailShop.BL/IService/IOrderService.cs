using RetailShop.BL.Models;

namespace RetailShop.BL.IService
{
    public interface IOrderService
    {
        int PlaceOrder(Order postObject);
        int CancelOrder(int orderId);
    }
}
