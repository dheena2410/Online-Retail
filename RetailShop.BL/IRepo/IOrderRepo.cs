using RetailShop.BL.Models;

namespace RetailShop.BL.IRepo
{
    public interface IOrderRepo
    {
        int PlaceOrder(Order postObject);
        int CancelOrder(int orderId);
    }
}
