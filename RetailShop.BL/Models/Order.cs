namespace RetailShop.BL.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public bool Active { get; set; }
    }
}
